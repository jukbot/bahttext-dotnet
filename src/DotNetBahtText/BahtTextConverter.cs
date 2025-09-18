namespace DotNetBahtText;

/// <summary>
/// Converts numeric values to Thai currency text representation.
/// </summary>
public static class BahtTextConverter
{
    private static readonly string[] Units = { "", "หนึ่ง", "สอง", "สาม", "สี่", "ห้า", "หก", "เจ็ด", "แปด", "เก้า" };
    private static readonly string[] Tens = { "", "", "ยี่", "สาม", "สี่", "ห้า", "หก", "เจ็ด", "แปด", "เก้า" };
    private static readonly string[] Places = { "", "สิบ", "ร้อย", "พัน", "หมื่น", "แสน", "ล้าน" };

    /// <summary>
    /// Converts a decimal number to Thai baht text representation.
    /// </summary>
    /// <param name="amount">The amount to convert.</param>
    /// <returns>Thai text representation of the amount in baht.</returns>
    public static string Convert(decimal amount)
    {
        if (amount == 0)
            return "ศูนย์บาทถ้วน";

        var isNegative = amount < 0;
        amount = Math.Abs(amount);

        var baht = (long)Math.Floor(amount);
        var satang = (int)Math.Round((amount - baht) * 100);

        var result = "";

        if (isNegative)
            result += "ลบ";

        if (baht == 0)
        {
            result += "ศูนย์บาท";
        }
        else
        {
            result += ConvertIntegerPart(baht) + "บาท";
        }

        if (satang == 0)
        {
            result += "ถ้วน";
        }
        else
        {
            result += ConvertIntegerPart(satang) + "สตางค์";
        }

        return result;
    }

    /// <summary>
    /// Converts a long integer to Thai text representation.
    /// </summary>
    /// <param name="number">The number to convert.</param>
    /// <returns>Thai text representation of the number.</returns>
    public static string ConvertNumber(long number)
    {
        if (number == 0)
            return "ศูนย์";

        var isNegative = number < 0;
        number = Math.Abs(number);

        var result = "";

        if (isNegative)
            result += "ลบ";

        result += ConvertIntegerPart(number);

        return result;
    }

    private static string ConvertIntegerPart(long number)
    {
        if (number == 0)
            return "";

        var result = "";
        var digitCount = 0;

        while (number > 0)
        {
            var digit = (int)(number % 10);
            number /= 10;

            if (digit == 0)
            {
                digitCount++;
                continue;
            }

            var digitText = "";

            // Handle different digit positions
            if (digitCount == 0) // ones place
            {
                if (digit == 1 && number > 0)
                {
                    digitText = "เอ็ด";
                }
                else
                {
                    digitText = Units[digit];
                }
            }
            else if (digitCount == 1) // tens place
            {
                if (digit == 1)
                {
                    digitText = "สิบ";
                }
                else if (digit == 2)
                {
                    digitText = "ยี่สิบ";
                }
                else
                {
                    digitText = Tens[digit] + "สิบ";
                }
            }
            else // hundreds, thousands, etc.
            {
                digitText = Units[digit];
                if (digitCount < Places.Length)
                {
                    digitText += Places[digitCount];
                }
            }

            result = digitText + result;
            digitCount++;
        }

        return result;
    }
}
