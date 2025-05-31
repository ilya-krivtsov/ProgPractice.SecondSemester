// <copyright file="MainWindow.axaml.cs" company="Ilya Krivtsov">
// Copyright (c) Ilya Krivtsov. All rights reserved.
// </copyright>

namespace TicTacToe.UI;

using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Media;
using Avalonia.VisualTree;
using MsBox.Avalonia;

public partial class MainWindow : Window
{
    private readonly TicTacToeGame game;

    private bool won = false;

    public MainWindow()
    {
        InitializeComponent();

        game = new();

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                var button = new Button()
                {
                    HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Stretch,
                    VerticalAlignment = Avalonia.Layout.VerticalAlignment.Stretch,
                    HorizontalContentAlignment = Avalonia.Layout.HorizontalAlignment.Center,
                    VerticalContentAlignment = Avalonia.Layout.VerticalAlignment.Center,
                    FontSize = 64,
                };
                int row = i;
                int column = j;

                button.Click += (o, e) => OnClick(button, row, column);

                Grid.SetRow(button, row);
                Grid.SetColumn(button, column);
                mainGrid.Children.Add(button);
            }
        }
    }

    private void OnClick(Button button, int row, int column)
    {
        if (won)
        {
            return;
        }

        var result = game.MakeMove(column, row);

        var xTurn = result is MoveResult.XTurn or MoveResult.XWins;
        var oTurn = result is MoveResult.OTurn or MoveResult.OWins;

        if (!xTurn && !oTurn)
        {
            return;
        }

        if (result is MoveResult.XWins or MoveResult.OWins)
        {
            won = true;
            MessageBoxManager
                .GetMessageBoxStandard("Win!", $"{(result == MoveResult.XWins ? "X" : "O")} has won!")
                .ShowWindowAsync();
        }

        button.Content = xTurn ? "X" : "O";
        button.Foreground = xTurn ? SolidColorBrush.Parse("#f02020") : SolidColorBrush.Parse("#2020f0");
    }
}
