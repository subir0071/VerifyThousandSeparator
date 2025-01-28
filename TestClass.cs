using NUnit.Framework;
using System;
using System.Globalization;
namespace VerifyThousandSeparator;

public class TestClass
{
    [Test]
    [SetCulture("fr-FR")]
    public void Should_not_fail_with_basic_assert()
    {
       // const decimal input = 1000.31m;
       // Assert.That($"{input:C0}", Is.EqualTo("1\u202F000 €"));

       const decimal input = 1000.31m;

        // Convert decimal to bytes
        byte[] inputBytes = BitConverter.GetBytes(input);

        // Print the hex values of each byte of the decimal value
        string hexValues = string.Join(" ", inputBytes.Select(b => b.ToString("X2")));
        TestContext.WriteLine($"Hex value of input (decimal 1000.31m): {hexValues}");

        // Act: Format the decimal value using the French culture
        string formattedValue = string.Format(CultureInfo.GetCultureInfo("fr-FR"), "{0:C0}", input);

        // Print the formatted value for debugging
        TestContext.WriteLine($"Formatted Value: '{formattedValue}'");

        // Assert: Compare the result with the expected output containing U+202F (narrow no-break space)
        Assert.That(formattedValue, Is.EqualTo("1\u202F000 €"));
    }
    }
}

