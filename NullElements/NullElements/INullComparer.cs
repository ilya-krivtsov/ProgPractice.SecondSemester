// <copyright file="INullComparer.cs" company="Ilya Krivtsov">
// Copyright (c) Ilya Krivtsov. All rights reserved.
// </copyright>

namespace NullElements;

/// <summary>
/// Interface that can be used to check whether object is null.
/// </summary>
/// <typeparam name="T">Type of object to check.</typeparam>
public interface INullComparer<T>
{
    /// <summary>
    /// Checks whether specified object is null.
    /// </summary>
    /// <param name="item">Object to check.</param>
    /// <returns><see langword="true"/> if specified object is null, <see langword="false"/> otherwise.</returns>
    public bool IsNull(T item);
}
