// <copyright file="TicTacToeGameTests.cs" company="Ilya Krivtsov">
// Copyright (c) Ilya Krivtsov. All rights reserved.
// </copyright>

namespace TicTacToe.Tests;

public class TicTacToeGameTests
{
    private TicTacToeGame game;

    [SetUp]
    public void Setup()
    {
        game = new();
    }

    [Test]
    public void FirstRow_OfX_Wins()
    {
        Assert.That(game.MakeMove(0, 0), Is.EqualTo(MoveResult.XTurn));
        Assert.That(game.MakeMove(0, 1), Is.EqualTo(MoveResult.OTurn));

        Assert.That(game.MakeMove(1, 0), Is.EqualTo(MoveResult.XTurn));
        Assert.That(game.MakeMove(1, 1), Is.EqualTo(MoveResult.OTurn));

        Assert.That(game.MakeMove(2, 0), Is.EqualTo(MoveResult.XWins));
    }

    [Test]
    public void FirstRow_OfO_Wins()
    {
        Assert.That(game.MakeMove(0, 0), Is.EqualTo(MoveResult.XTurn));
        Assert.That(game.MakeMove(0, 1), Is.EqualTo(MoveResult.OTurn));

        Assert.That(game.MakeMove(1, 0), Is.EqualTo(MoveResult.XTurn));
        Assert.That(game.MakeMove(1, 1), Is.EqualTo(MoveResult.OTurn));

        Assert.That(game.MakeMove(2, 2), Is.EqualTo(MoveResult.XTurn));
        Assert.That(game.MakeMove(2, 1), Is.EqualTo(MoveResult.OWins));
    }

    [Test]
    public void FirstColumn_OfO_Wins()
    {
        Assert.That(game.MakeMove(1, 0), Is.EqualTo(MoveResult.XTurn));
        Assert.That(game.MakeMove(0, 0), Is.EqualTo(MoveResult.OTurn));

        Assert.That(game.MakeMove(1, 2), Is.EqualTo(MoveResult.XTurn));
        Assert.That(game.MakeMove(0, 1), Is.EqualTo(MoveResult.OTurn));

        Assert.That(game.MakeMove(2, 2), Is.EqualTo(MoveResult.XTurn));
        Assert.That(game.MakeMove(0, 2), Is.EqualTo(MoveResult.OWins));
    }

    [Test]
    public void Diagonal_OfX_Wins()
    {
        Assert.That(game.MakeMove(0, 0), Is.EqualTo(MoveResult.XTurn));
        Assert.That(game.MakeMove(0, 1), Is.EqualTo(MoveResult.OTurn));

        Assert.That(game.MakeMove(1, 1), Is.EqualTo(MoveResult.XTurn));
        Assert.That(game.MakeMove(1, 2), Is.EqualTo(MoveResult.OTurn));

        Assert.That(game.MakeMove(2, 2), Is.EqualTo(MoveResult.XWins));
    }
}
