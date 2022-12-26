using System;

public class Menu 
{   
    
    private Exceptions checker = new Exceptions();
    public void LoginScreen(GameSession gameSession)
    {
        Console.Clear();
        Console.WriteLine("Enter to your account:\n");

        Console.Write("Enter your login: ");
        string Login = Console.ReadLine();
        
        Console.Write("Enter your current rating: ");
        int Rating = Convert.ToInt32(Console.ReadLine());

        gameSession.AddPlayer(Login, Rating);
    }
        
    public void MenuScreen(GameSession gameSession)
    {
        Console.Clear();
        Console.WriteLine(" Lets Play!!");
        Console.WriteLine("Your choose:");
        Console.WriteLine("1 - Check stats");
        Console.WriteLine("2 - Play with computer");
        Console.WriteLine("3 - Play with your friend");
        Console.WriteLine("4 - Exit");

        Console.Write("Enter number: ");
        int command = Convert.ToInt32(Console.ReadLine());
        checker.CheckCommand(command);

        gameSession.Commands(command);
    }

    public void BoardScreen(Game game, string CurrentPlayer = "Computer")
    {
        Console.WriteLine($"Current Player: {CurrentPlayer}\n");
        
        for(int i = 0; i < 3; i++)
        {
            Console.WriteLine("|     |     |     |");
            Console.Write("|  ");
            for(int j = 0; j < 3; j++)
            {
                switch(game.GameBoard[i,j])
                {
                    case -1:
                        Console.Write($"O  |  ");
                        break;
                    case 0:
                        Console.Write($"-  |  ");
                        break;
                    case 1:
                        Console.Write($"X  |  ");
                        break;
                }
            }
            Console.WriteLine("\n|     |     |     |");
            if(i < 2) Console.WriteLine("-------------------");
        }
    }

    public void backToMenu(GameSession gameSession)
    {
        Console.WriteLine("0 -- Return");
        Console.WriteLine("1 -- Check stats");
        Console.WriteLine("4 -- Exit");

        Console.Write("Enter the number: ");
        int command = Convert.ToInt32(Console.ReadLine());
        checker.CheckCommand(command);

        gameSession.AddCommand(command);
    }

    public void OpponentMenu(GameSession gameSession)
    {  
        Console.Clear();
        Console.WriteLine("Opponent!\n\n");

        Console.WriteLine($"0 - Create new opponent account");

        for(int i = 1; i < gameSession.Players.Count; i++)
        {
            if(gameSession.Players[i].UserName != "Computer")
            {Console.WriteLine($"\t-- {gameSession.Players[i].UserName} [Enter {i}]");}
        }
    }

    public void PlayerStats(GameSession gameSession)
    {
        Console.Clear();
        Console.WriteLine("Choose player\n");

        for(int i = 0; i < gameSession.Players.Count; i++)
        {
            if (gameSession.Players[i].UserName == "Computer") continue;
            
            Console.WriteLine($"{i} - {gameSession.Players[i].UserName} ");
        }

        Console.Write("Your number: ");
        int index = Convert.ToInt32(Console.ReadLine());
        
        showPlayerStats(gameSession, index);
    }

    public void showPlayerStats(GameSession gameSession, int Index)
    {
        Console.Clear();
        gameSession.Players[Index].WriteStats();
        if (gameSession.Players[Index].History.Count != 0)
        {
            gameSession.Players[Index].WriteGameHistory();
        }
    }
}