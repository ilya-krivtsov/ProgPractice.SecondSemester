namespace StackCalc.Tests;

public class StackTests
{
    private static readonly double[][] Data =
    [
        [.. Enumerable.Range(1, 16)]
    ];

    private static IStack<double>[] Stacks => [new LinkedStack<double>(), new ArrayStack<double>()];

    [Test]
    public void TestStack([ValueSource(nameof(Stacks))] IStack<double> stack, [ValueSource(nameof(Data))] double[] data)
    {
        Assert.That(stack.IsEmpty, Is.True);

        for (int i = 0; i < data.Length; i++)
        {
            Assert.DoesNotThrow(() => stack.Push(data[i]));
        }

        Assert.That(stack.IsEmpty, Is.False);

        for (int i = data.Length - 1; i >= 0; i--)
        {
            Assert.Multiple(() =>
            {
                var value = stack.Pop();
                Assert.That(value, Is.EqualTo(data[i]));
            });
        }

        Assert.That(stack.IsEmpty, Is.True);
        stack.Pop();
    }
}
