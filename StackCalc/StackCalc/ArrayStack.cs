namespace StackCalc;

using System.Diagnostics;

/// <inheritdoc/>
public class ArrayStack<T> : IStack<T>
{
    private T?[] array = new T[8];
    private int head = -1;

    /// <inheritdoc/>
    public bool IsEmpty => this.head == -1;

    /// <inheritdoc/>
    public void Push(T value)
    {
        this.head++;
        if (this.head >= this.array.Length)
        {
            Array.Resize(ref this.array, this.array.Length * 2);
        }

        this.array[this.head] = value;
    }

    /// <inheritdoc/>
    public T Pop()
    {
        if (this.head == -1)
        {
            throw new InvalidOperationException();
        }

        var value = this.array[this.head];
        this.array[this.head] = default;

        Debug.Assert(value != null, "Value is null");

        this.head--;
        return value;
    }
}
