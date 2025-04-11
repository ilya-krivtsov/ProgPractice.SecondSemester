namespace PriorityQueue.Tests;

public abstract class GenericPriorityQueueTests<TElement, TPriority>
{
    private PriorityQueue<TElement, TPriority> queue;

    public virtual IComparer<TPriority>? Comparer { get; }

    public abstract ItemPair SingleTestPair { get; }

    public abstract IEnumerable<ItemPair> SamePriorityTestPairs { get; }

    public abstract IEnumerable<ItemPair> IncreasingPriorityTestPairs { get; }

    [SetUp]
    public void Setup()
    {
        queue = Comparer == null ? new() : new(Comparer);
    }

    [Test]
    public void Empty_ShouldBeTrue_ForEmptyQueue()
    {
        Assert.That(queue.Empty, Is.True);
    }

    [Test]
    public void Empty_ShouldBeFalse_ForNonEmptyQueue()
    {
        queue.Enqueue(SingleTestPair.Element, SingleTestPair.Priority);
        Assert.That(queue.Empty, Is.False);
    }

    [Test]
    public void Dequeue_ShouldThrow_IfQueueIsEmpty()
    {
        Assert.Throws<InvalidOperationException>(() => queue.Dequeue());
    }

    [Test]
    public void Dequeue_ShouldReturn_EnqueuedItem()
    {
        queue.Enqueue(SingleTestPair.Element, SingleTestPair.Priority);
        Assert.That(queue.Dequeue(), Is.EqualTo(SingleTestPair.Element));
    }

    [Test]
    public void Dequeue_ShouldReturn_EnqueuedItems_InSameOrder_IfPriorityIsSame()
    {
        foreach (var (element, priority) in SamePriorityTestPairs)
        {
            queue.Enqueue(element, priority);
        }

        foreach (var (element, priority) in SamePriorityTestPairs)
        {
            Assert.That(queue.Dequeue(), Is.EqualTo(element));
        }
    }

    [Test]
    public void Dequeue_ShouldReturn_EnqueuedItems_InReverseOrder_IfPriorityIsDecreasing()
    {
        foreach (var (element, priority) in IncreasingPriorityTestPairs.Reverse())
        {
            queue.Enqueue(element, priority);
        }

        foreach (var (element, priority) in IncreasingPriorityTestPairs)
        {
            Assert.That(queue.Dequeue(), Is.EqualTo(element));
        }
    }

    public readonly record struct ItemPair(TElement Element, TPriority Priority);
}
