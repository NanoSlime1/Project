using System;
using System.Collections.Generic;

public class PlayerAccount
{
    public string UserName = "";
    public int Rating = 0;
    public List<GameHistory> History = new List<GameHistory>();
    
    public PlayerAccount(string UserName = " ", int Rating = 0)
    {
        this.UserName = UserName;
        this.Rating = Rating;
    }

    public void WinGame(string OpponentName, Game game)
    {
        var currentGame = new GameHistory(game.GameRating, OpponentName, true);
        History.Add(currentGame);
    }

    public void LoseGame(string OpponentName, Game game)
    {
        var currentGame = new GameHistory(-game.GameRating, OpponentName, false);
        History.Add(currentGame);
    }
    
    public void WriteStats()
    {
        Console.WriteLine("Stats:\n\n");
        Console.WriteLine($"Name: {this.UserName}");
        Console.WriteLine($"Rating: {this.Rating}");
    }
    
    public void WriteGameHistory()
    {
        Console.WriteLine("\nGame history:");
        foreach(var elem in History)
        {
            string Res = elem.IsWin ? "Win" : "Lose";
            
            Console.WriteLine($"\nOpponent: {elem.OpponentName}");
            Console.WriteLine($"Res: {Res}");
            Console.WriteLine($"Game ID: {elem.GameID}");
            Console.WriteLine($"Game rating: {elem.GameRating}\n");
        }
    }
}