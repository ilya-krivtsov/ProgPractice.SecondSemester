// <copyright file="BasicList.cs" company="Ilya Krivtsov">
// Copyright (c) Ilya Krivtsov. All rights reserved.
// </copyright>

namespace NullElements;

using System.Collections;

/// <summary>
/// Basic array-backed list.
/// </summary>
/// <typeparam name="T">Type of items.</typeparam>
public class BasicList<T> : IEnumerable<T>
{
    private T[] values = new T[4];
    private int count = 0;
    private int version = 0;

    /// <summary>
    /// Initializes a new instance of the <see cref="BasicList{T}"/> class.
    /// </summary>
    public BasicList()
    {
        values = new T[4];
        count = 0;
    }

    /// <summary>
    /// Adds item to the list.
    /// </summary>
    /// <param name="item">Item to add.</param>
    public void Add(T item)
    {
        if (count >= values.Length)
        {
            var newValues = new T[values.Length * 2];
            Array.Copy(values, newValues, values.Length);
            values = newValues;
        }

        values[count] = item;
        count++;
        version++;
    }

    /// <inheritdoc/>
    public IEnumerator<T> GetEnumerator()
    {
        int lastVersion = version;

        for (int i = 0; i < count; i++)
        {
            if (version != lastVersion)
            {
                throw new InvalidOperationException();
            }

            yield return values[i];
        }
    }

    /// <inheritdoc/>
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
