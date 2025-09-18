# DotNet Baht Text

Convert numbers to Thai currency full text with zero dependencies. (C#)

[![Build Status](https://github.com/jukbot/dotnet-baht-text/workflows/CI/badge.svg)](https://github.com/jukbot/dotnet-baht-text/actions)
[![NuGet](https://img.shields.io/nuget/v/DotNetBahtText.svg)](https://www.nuget.org/packages/DotNetBahtText)

## Features

- Convert decimal amounts to Thai baht text representation
- Convert integers to Thai number text representation
- Support for negative numbers
- Zero dependencies
- .NET 8.0 compatible
- Full unit test coverage

## Installation

Install via NuGet Package Manager:

```bash
dotnet add package DotNetBahtText
```

Or via Package Manager Console:

```powershell
Install-Package DotNetBahtText
```

## Usage

### Basic Currency Conversion

```csharp
using DotNetBahtText;

// Convert currency amounts
var result1 = BahtTextConverter.Convert(1234.56m);
// Result: "หนึ่งพันสองร้อยสามสิบสี่บาทห้าสิบหกสตางค์"

var result2 = BahtTextConverter.Convert(0);
// Result: "ศูนย์บาทถ้วน"

var result3 = BahtTextConverter.Convert(1000);
// Result: "หนึ่งพันบาทถ้วน"
```

### Number Conversion

```csharp
using DotNetBahtText;

// Convert numbers to Thai text
var result1 = BahtTextConverter.ConvertNumber(123);
// Result: "หนึ่งร้อยยี่สิบสาม"

var result2 = BahtTextConverter.ConvertNumber(0);
// Result: "ศูนย์"

var result3 = BahtTextConverter.ConvertNumber(-50);
// Result: "ลบห้าสิบ"
```

## API Reference

### BahtTextConverter.Convert(decimal amount)

Converts a decimal amount to Thai baht text representation.

**Parameters:**
- `amount` (decimal): The monetary amount to convert

**Returns:**
- `string`: Thai text representation of the amount in baht and satang

### BahtTextConverter.ConvertNumber(long number)

Converts a long integer to Thai number text representation.

**Parameters:**
- `number` (long): The number to convert

**Returns:**
- `string`: Thai text representation of the number

## Examples

See the [sample application](samples/DotNetBahtText.Sample) for more usage examples.

To run the sample:

```bash
cd samples/DotNetBahtText.Sample
dotnet run
```

## Building from Source

```bash
# Clone the repository
git clone https://github.com/jukbot/dotnet-baht-text.git
cd dotnet-baht-text

# Build the solution
dotnet build

# Run tests
dotnet test

# Run sample application
dotnet run --project samples/DotNetBahtText.Sample
```

## Contributing

Contributions are welcome! Please feel free to submit a Pull Request.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Acknowledgments

- Inspired by the need for Thai language number-to-text conversion in .NET applications
- Special thanks to the Thai language community for linguistic guidance
