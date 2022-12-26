using System;
using System.Collections.Generic;

public class GameSession
{
    public Menu Screen = new Menu();
    public List<PlayerAccount> Players = new List<PlayerAccount>();
    public GameLauncher Launcher = new GameLauncher();

    public void StartGame()
    {
        Screen.LoginScreen(this);
        Screen.MenuScreen(this);
    }

    public void AddPlayer(string username, int rating)
    {
        PlayerAccount Player = new PlayerAccount(username, rating);
        Players.Add(Player);
    }
    
    public void AddCommand(int command)
    {
        switch (command)
        {
            case 1:
                Screen.PlayerStats(this); Screen.backToMenu(this);
                break;
            case 0:
                Screen.MenuScreen(this);
                break;
            default:
                EndGame();
                break;
        }
    }
    
    public void Commands(int command)
    {
        switch (command)
        {
            case 3:
            case 2:
                Launcher.Launch(this, command);
                break;
            case 1:
                Screen.PlayerStats(this); Screen.backToMenu(this);
                break;
            default:
                EndGame();
                break;
        }
    }

    public void EndGameSession(Game game)
    {
        Console.Write("Game ended\nResult: ");
        if (game.gameStatus == true)
        {
            Console.WriteLine($"{game.Winner.UserName} have won.");
        }
        else
        {
            Console.WriteLine("Draw");
        }
       
        game.Winner.WinGame(game.Loser.UserName, game);
        game.Loser.LoseGame(game.Winner.UserName, game);

        Screen.backToMenu(this);
    }

    public void EndGame()
    {
        Console.WriteLine("Waiting for a return soon!!");
    }
}