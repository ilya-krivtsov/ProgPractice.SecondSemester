namespace PriorityQueue;

/// <summary>
/// Prioirty queue data structure.
/// </summary>
/// <typeparam name="TElement">Type of elements.</typeparam>
/// <typeparam name="TPriority">Type of priority associated with each element.</typeparam>
public class PriorityQueue<TElement, TPriority>
{
    private IComparer<TPriority> comparer;
    private Item? head;

    /// <summary>
    /// Initializes a new instance of the <see cref="PriorityQueue{TValue, TPriority}"/> class.
    /// </summary>
    /// <param name="comparer">Comparer to use; if <see langword="null"/>, defaults to <see cref="Comparer{TPriority}.Default"/>.</param>
    public PriorityQueue(IComparer<TPriority>? comparer = null)
    {
        head = null;
        this.comparer = comparer ?? Comparer<TPriority>.Default;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="PriorityQueue{TValue, TPriority}"/> class.
    /// </summary>
    public PriorityQueue()
        : this(null)
    {
    }

    /// <summary>
    /// Gets a value indicating whether queue is empty.
    /// </summary>
    public bool Empty => head == null;

    /// <summary>
    /// Enqueues element into the queue.
    /// </summary>
    /// <param name="element">Element to enqueue.</param>
    /// <param name="priority">Priority of the <paramref name="element"/>.</param>
    public void Enqueue(TElement element, TPriority priority)
    {
        var item = head;
        if (item == null)
        {
            item = new(element, priority, null);
            head = item;
            return;
        }

        if (comparer.Compare(priority, item.Priority) < 0)
        {
            var newHead = new Item(element, priority, item);
            head = newHead;
            return;
        }

        while (item.Next != null && comparer.Compare(priority, item.Next.Priority) >= 0)
        {
            item = item.Next;
        }

        var newItem = new Item(element, priority, item.Next);
        item.Next = newItem;
    }

    /// <summary>
    /// Dequeues element with the least priority from the queue.
    /// </summary>
    /// <returns>Element with the least priority .</returns>
    public TElement Dequeue()
    {
        if (head == null)
        {
            throw new InvalidOperationException("Queue is empty");
        }

        var item = head;
        head = item.Next;
        return item.Element;
    }

    private class Item(TElement element, TPriority priority, Item? next)
    {
        public TElement Element => element;

        public TPriority Priority => priority;

        public Item? Next { get; set; } = next;
    }
}
