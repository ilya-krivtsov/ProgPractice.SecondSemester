namespace PriorityQueue.Tests;

public abstract class GenericPriorityQueueTests<TElement, TPriority>
{
    private PriorityQueue<TElement, TPriority> queue;

    public virtual IComparer<TPriority>? Comparer { get; }

    public abstract ItemPair SingleTestPair { get; }

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

    public readonly record struct ItemPair(TElement Element, TPriority Priority);
}
