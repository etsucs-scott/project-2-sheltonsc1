using System;
using System.Collections.Generic;
using WarGame.Core;

Console.Write("Enter the number of players (2-4): ");
int count = int.Parse(Console.ReadLine());

var players = new List<string>();
for (int i = 1; i <= count; i++)
{
    Console.Write($"Enter the name of player {i}: ");
    players.Add(Console.ReadLine());
}

var game = new WarGame(players);
string result = game.PlayGame();

Console.WriteLine("\n::::::::: GAME OVER :::::::::");
Console.WriteLine(result);