namespace PriorityQueue.Tests;

public static class TypedPriorityQueueTests
{
    public class IntPriorityQueue : GenericPriorityQueueTests<int, int>
    {
        public override ItemPair SingleTestPair => new(123, 456);
    }
}
