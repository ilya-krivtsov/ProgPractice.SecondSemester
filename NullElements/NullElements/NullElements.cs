// <copyright file="NullElements.cs" company="Ilya Krivtsov">
// Copyright (c) Ilya Krivtsov. All rights reserved.
// </copyright>

namespace NullElements;

/// <summary>
/// Extension class that contains <c>CountNullElements</c> function.
/// </summary>
public static class NullElements
{
    /// <summary>
    /// Counts null elements in the list.
    /// </summary>
    /// <typeparam name="T">Type of objects.</typeparam>
    /// <param name="list">List to count objects from.</param>
    /// <param name="comparer">Comparer that checks whether object is null.</param>
    /// <returns>Count of null elements.</returns>
    public static int CountNullElements<T>(this BasicList<T> list, INullComparer<T> comparer)
        => list.Count(comparer.IsNull);
}
