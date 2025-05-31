// <copyright file="TicTacToeGame.cs" company="Ilya Krivtsov">
// Copyright (c) Ilya Krivtsov. All rights reserved.
// </copyright>

namespace TicTacToe;

/// <summary>
/// The game of tic-tac-toe.
/// </summary>
public class TicTacToeGame
{
    private readonly Cell[,] cells = new Cell[3, 3];

    private Cell turn;

    private MoveResult? winner = null;

    /// <summary>
    /// Initializes a new instance of the <see cref="TicTacToeGame"/> class.
    /// </summary>
    public TicTacToeGame()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                cells[i, j] = Cell.Empty;
            }
        }

        turn = Cell.X;
    }

    /// <summary>
    /// Makes a move and returns <see langword="true"/>, if player won this turn.
    /// </summary>
    /// <param name="column">Column on the board to set X or O.</param>
    /// <param name="row">Row on the board to set X or O.</param>
    /// <returns><see langword="true"/> if player won the game with this move, <see langword="false"/> otherwise.</returns>
    public MoveResult MakeMove(int column, int row)
    {
        if (winner != null)
        {
            return winner.Value;
        }

        if (column < 0 || column > 2 || row < 0 || row > 2)
        {
            return MoveResult.IncorrectMove;
        }

        if (cells[column, row] != Cell.Empty)
        {
            return MoveResult.IncorrectMove;
        }

        cells[column, row] = turn;

        if (CheckVictory(turn))
        {
            winner = turn == Cell.X ? MoveResult.XWins : MoveResult.OWins;
            return winner.Value;
        }

        var oldTurn = turn;

        turn = turn == Cell.X ? Cell.O : Cell.X;

        return oldTurn == Cell.X ? MoveResult.XTurn : MoveResult.OTurn;
    }

    private bool CheckVictory(Cell cell)
    {
        if (cell != Cell.X && cell != Cell.O)
        {
            return false;
        }

        for (int y = 0; y < 3; y++)
        {
            if (Enumerable.Range(0, 3).All(i => cells[i, y] == cell))
            {
                return true;
            }
        }

        for (int x = 0; x < 3; x++)
        {
            if (Enumerable.Range(0, 3).All(i => cells[x, i] == cell))
            {
                return true;
            }
        }

        if (Enumerable.Range(0, 3).All(i => cells[i, i] == cell))
        {
            return true;
        }

        if (Enumerable.Range(0, 3).All(i => cells[2 - i, i] == cell))
        {
            return true;
        }

        return false;
    }
}
