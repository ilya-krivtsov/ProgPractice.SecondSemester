namespace StackCalc;

/// <summary>
/// Stack of elements.
/// </summary>
/// <typeparam name="T">Type of elements.</typeparam>
public interface IStack<T>
{
    /// <summary>
    /// Gets a value indicating whether stack is not empty.
    /// </summary>
    public bool IsEmpty { get; }

    /// <summary>
    /// Pushes <paramref name="item"/> on top of stack.
    /// </summary>
    /// <param name="item">The item to push.</param>
    public void Push(T item);

    /// <summary>
    /// Pops value off top of stack.
    /// </summary>
    /// <returns>
    /// Value of top.
    /// </returns>
    public T Pop();
}
