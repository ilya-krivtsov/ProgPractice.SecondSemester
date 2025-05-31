// <copyright file="MoveResult.cs" company="Ilya Krivtsov">
// Copyright (c) Ilya Krivtsov. All rights reserved.
// </copyright>

namespace TicTacToe;

/// <summary>
/// Result of the move on the tic-tac-toe board.
/// </summary>
public enum MoveResult
{
    /// <summary>
    /// X made turn.
    /// </summary>
    XTurn,

    /// <summary>
    /// X made turn.
    /// </summary>
    OTurn,

    /// <summary>
    /// X wins.
    /// </summary>
    XWins,

    /// <summary>
    /// O wins.
    /// </summary>
    OWins,

    /// <summary>
    /// Incorrect move has been made.
    /// </summary>
    IncorrectMove,
}
