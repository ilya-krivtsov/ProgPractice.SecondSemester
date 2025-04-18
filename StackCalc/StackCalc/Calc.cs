namespace StackCalc;

/// <summary>
/// Stack calculator.
/// </summary>
public class Calc(IStack<double> stack)
{
    private readonly IStack<double> stack = stack;

    /// <summary>
    /// Evaluates <paramref name="input"/> as <see langword="double"/>.
    /// </summary>
    /// <param name="input">Input string in reverse polish notation.</param>
    /// <returns>Evaluation result.</returns>
    public double Evaluate(string input)
    {
        var tokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        foreach (var token in tokens)
        {
            if (int.TryParse(token, out int number))
            {
                stack.Push(number);
            }
            else
            {
                var rightOperand = stack.Pop();
                var leftOperand = stack.Pop();

                var operationResult = token switch
                {
                    "+" => leftOperand + rightOperand,
                    "-" => leftOperand - rightOperand,
                    "*" => leftOperand * rightOperand,
                    "/" => leftOperand / rightOperand,
                    _ => throw new(),
                };

                stack.Push(operationResult);
            }
        }

        var result = stack.Pop();

        if (!stack.IsEmpty)
        {
            throw new();
        }

        return result;
    }
}
