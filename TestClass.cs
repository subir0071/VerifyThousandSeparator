namespace VerifyThousandSeparator;

public class TestClass
{
    private readonly VerifySettings _verifySettings = new();

    public TestClass()
    {
        _verifySettings.UseDirectory("Snapshots");
    }

    [Test]
    [SetCulture("fr-FR")]
    public async Task Verify_should_not_fail_when_checking_a_number_formatted_as_C0_in_FR_culture()
    {
        const decimal input = 1000.31m;
        await Verify($"{input:C0}", _verifySettings);
    }

    [Test]
    [SetCulture("fr-FR")]
    public void Should_not_fail_with_basic_assert()
    {
        const decimal input = 1000.31m;
        Assert.That($"{input:C0}", Is.EqualTo("1\u202f000 €"));
    }
}