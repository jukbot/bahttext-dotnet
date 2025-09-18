namespace DotNetBahtText.Tests;

public class BahtTextConverterTests
{
    [Fact]
    public void Convert_Zero_ReturnsCorrectText()
    {
        // Arrange
        var amount = 0m;

        // Act
        var result = BahtTextConverter.Convert(amount);

        // Assert
        Assert.Equal("ศูนย์บาทถ้วน", result);
    }

    [Fact]
    public void Convert_OneBasht_ReturnsCorrectText()
    {
        // Arrange
        var amount = 1m;

        // Act
        var result = BahtTextConverter.Convert(amount);

        // Assert
        Assert.Equal("หนึ่งบาทถ้วน", result);
    }

    [Fact]
    public void Convert_WithSatang_ReturnsCorrectText()
    {
        // Arrange
        var amount = 1.50m;

        // Act
        var result = BahtTextConverter.Convert(amount);

        // Assert
        Assert.Equal("หนึ่งบาทห้าสิบสตางค์", result);
    }

    [Fact]
    public void Convert_NegativeAmount_ReturnsCorrectText()
    {
        // Arrange
        var amount = -10m;

        // Act
        var result = BahtTextConverter.Convert(amount);

        // Assert
        Assert.Equal("ลบสิบบาทถ้วน", result);
    }

    [Fact]
    public void ConvertNumber_Zero_ReturnsCorrectText()
    {
        // Arrange
        var number = 0L;

        // Act
        var result = BahtTextConverter.ConvertNumber(number);

        // Assert
        Assert.Equal("ศูนย์", result);
    }

    [Fact]
    public void ConvertNumber_PositiveNumber_ReturnsCorrectText()
    {
        // Arrange
        var number = 123L;

        // Act
        var result = BahtTextConverter.ConvertNumber(number);

        // Assert
        Assert.NotNull(result);
        Assert.NotEmpty(result);
    }

    [Fact]
    public void ConvertNumber_NegativeNumber_ReturnsCorrectText()
    {
        // Arrange
        var number = -50L;

        // Act
        var result = BahtTextConverter.ConvertNumber(number);

        // Assert
        Assert.StartsWith("ลบ", result);
    }
}