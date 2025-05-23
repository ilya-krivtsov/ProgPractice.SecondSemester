// <copyright file="NullElementsTests.cs" company="Ilya Krivtsov">
// Copyright (c) Ilya Krivtsov. All rights reserved.
// </copyright>

namespace NullElements.Tests;

using System.Numerics;

public class NullElementsTests
{
    [Test]
    public void CountNullElements_IsCorrect_ForReferenceTypes()
    {
        BasicList<object> list = [null, 42, null, "abc", null];
        Assert.That(list.CountNullElements(new ReferenceNullComparer<object>()), Is.EqualTo(3));
    }

    [Test]
    public void CountNullElements_IsCorrect_ForNumberTypes()
    {
        BasicList<int> intList = [0, 1, 0, 2, 0, 100, 0, -100];
        Assert.That(intList.CountNullElements(new NumberNullComparer<int>()), Is.EqualTo(4));

        BasicList<float> floatList = [0, 0.1f, 0, 0.2f, 0, 100.100f, 0, -42.42f, 0.00000001f, 0];
        Assert.That(floatList.CountNullElements(new NumberNullComparer<float>()), Is.EqualTo(5));
    }

    [Test]
    public void CountNullElements_IsCorrect_ForStrings()
    {
        BasicList<string> list = [null, string.Empty, "abc", "def", null, "apple", string.Empty];
        Assert.That(list.CountNullElements(new StringNullComparer()), Is.EqualTo(4));
    }

    private class ReferenceNullComparer<T> : INullComparer<T>
        where T : class
    {
        public bool IsNull(T item) => item == null;
    }

    private class NumberNullComparer<T> : INullComparer<T>
        where T : INumber<T>
    {
        public bool IsNull(T item) => T.IsZero(item);
    }

    private class StringNullComparer : INullComparer<string>
    {
        public bool IsNull(string item) => string.IsNullOrEmpty(item);
    }
}
