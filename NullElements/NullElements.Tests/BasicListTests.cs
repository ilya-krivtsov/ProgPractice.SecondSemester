// <copyright file="BasicListTests.cs" company="Ilya Krivtsov">
// Copyright (c) Ilya Krivtsov. All rights reserved.
// </copyright>

namespace NullElements.Tests;

public class BasicListTests
{
    private BasicList<int> list;

    [SetUp]
    public void Setup()
    {
        list = [];
    }

    [Test]
    public void EmptyList_ShouldReturn_EmptyEnumerator()
    {
        Assert.That(list.SequenceEqual([]), Is.True);
    }

    [Test]
    public void ListWithOneValue_ShouldReturn_EnumeratorWithOneElement()
    {
        int value = 42;
        list.Add(value);
        Assert.That(list.SequenceEqual([value]), Is.True);
    }

    [Test]
    public void ListWithManyValues_ShouldReturn_EnumeratorWithSameValules()
    {
        var values = Enumerable.Range(0, 1000);
        foreach (var value in values)
        {
            list.Add(value);
        }

        Assert.That(list.SequenceEqual(values), Is.True);
    }

    [Test]
    public void ModifyingList_WhileIterating_ShouldThrow()
    {
        var values = Enumerable.Range(0, 1000);
        foreach (var value in values)
        {
            list.Add(value);
        }

        var enumerator = list.GetEnumerator();
        enumerator.MoveNext();
        list.Add(1010101);
        Assert.Throws<InvalidOperationException>(() => enumerator.MoveNext());
    }
}
