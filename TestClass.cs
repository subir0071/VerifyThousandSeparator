using NUnit.Framework;

namespace VerifyThousandSeparator;

public class TestClass
{
    [Test]
    [SetCulture("fr-FR")]
    public void Should_not_fail_with_basic_assert()
    {
        const decimal input = 1000.31m;
        Assert.That($"{input:C0}", Is.EqualTo("1\u0020000 €"));
    }
}
