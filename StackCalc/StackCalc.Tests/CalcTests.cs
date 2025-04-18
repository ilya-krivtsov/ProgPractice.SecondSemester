namespace StackCalc.Tests;

public class CalcTests
{
    private static readonly (string Input, double Result)[] TestData =
    [
        ("1 2 +", 3),
        ("9 4 -", 5),
        ("3 4 *", 12),
        ("8 2 /", 4),
    ];

    private static readonly string[] IncorrectInputs =
    [
        string.Empty,
        "123 456",
        "123 456 %",
        "123 456 + -",
        "123 456 + 789 - 111 * 222 / +",
    ];

    private Calc calc;

    [SetUp]
    public void Setup()
    {
        calc = new(new ArrayStack<double>());
    }

    [Test]
    public void Calc_Evaluate_IsCorrect([ValueSource(nameof(TestData))] (string Input, double Result) data)
    {
        Assert.That(calc.Evaluate(data.Input), Is.EqualTo(data.Result).Within(0.0001));
    }

    [Test]
    public void Calc_Evaluate_Throws([ValueSource(nameof(IncorrectInputs))] string input)
    {
        Assert.Throws<Exception>(() => calc.Evaluate(input));
    }
}
