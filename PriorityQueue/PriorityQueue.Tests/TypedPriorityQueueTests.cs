namespace PriorityQueue.Tests;

public static class TypedPriorityQueueTests
{
    public class IntPriorityQueue : GenericPriorityQueueTests<int, int>
    {
        public override ItemPair SingleTestPair => new(123, 456);

        public override IEnumerable<ItemPair> SamePriorityTestPairs => Enumerable.Range(1, 64).Select(x => new ItemPair(x, 123));

        public override IEnumerable<ItemPair> IncreasingPriorityTestPairs => Enumerable.Range(1, 64).Select(x => new ItemPair(x, x));
    }

    public class StringPriorityQueue : GenericPriorityQueueTests<string, string>
    {
        public override IComparer<string>? Comparer { get; } = new NumberStringComparer();

        public override ItemPair SingleTestPair => new("1234", "4444");

        public override IEnumerable<ItemPair> SamePriorityTestPairs => Enumerable.Range(1, 64)
            .Select(x => x.ToString().PadLeft(3, '0')).Select(x => new ItemPair(x, x));

        public override IEnumerable<ItemPair> IncreasingPriorityTestPairs => Enumerable.Range(1, 8)
            .Select(x => new string('1', x)).Select(x => new ItemPair(x, x));

        private class NumberStringComparer : IComparer<string>
        {
            public int Compare(string? x, string? y)
                => int.Parse(x ?? "0") - int.Parse(y ?? "0");
        }
    }
}
