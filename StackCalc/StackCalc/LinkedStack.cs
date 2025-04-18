namespace StackCalc;

/// <inheritdoc/>
public class LinkedStack<T> : IStack<T>
{
    private Element? head;

    /// <inheritdoc/>
    public bool IsEmpty => head == null;

    /// <inheritdoc/>
    public void Push(T item)
        => head = new(item, head);

    /// <inheritdoc/>
    public T Pop()
    {
        if (head == null)
        {
            throw new InvalidOperationException();
        }

        var value = head.Value;
        head = head.Next;

        return value;
    }

    private record Element(T Value, Element? Next);
}
