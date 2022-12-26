using System;
using System.Threading;


public class GameLauncher
{
    private Exceptions checker = new Exceptions(); 
    public int chooseFriendOpponent(GameSession gameSession)
     {
        Console.Write("\t>> ");
        string ind = Console.ReadLine();

        int index;
        bool ch = int.TryParse(ind, out index);

        if(index == 0) {gameSession.Screen.LoginScreen(gameSession); return gameSession.Players.Count - 1;}
        
        checker.CheckPlayer(index, gameSession.Players.Count - 1);
        return index;
     }
     
     public void Launch(GameSession gameSession, int GameType)
     { 
        int OpponentIndex = 0;
        switch (GameType)
        {
            case 2:
            {
                Console.WriteLine("Game with computer!"); 
                Thread.Sleep(2000);

                //Find Opponent
                for(int i = 1; i < gameSession.Players.Count; i++)
                {
                    if (gameSession.Players[i].UserName != "Computer") continue;
                    
                    OpponentIndex = i; 
                    break;
                }

                if(OpponentIndex == 0) 
                {
                    PlayerAccount Computer = new PlayerAccount("Computer");
                    gameSession.Players.Add(Computer);

                    OpponentIndex = gameSession.Players.Count - 1;
                }
            
                Game game = new GameWithComputer();
                game.PlayGame(gameSession, gameSession.Players[OpponentIndex]);
                break;
            }
            case 3:
            {
                Console.WriteLine("Game with friend!"); 
                Thread.Sleep(1500);
            
                if(gameSession.Players.Count < 2 || (gameSession.Players.Count < 3 && gameSession.Players[1].UserName == "Computer"))
                {
                    Console.WriteLine("Login for second player: ");
                    Thread.Sleep(2500);
                    gameSession.Screen.LoginScreen(gameSession);
                    OpponentIndex = gameSession.Players.Count - 1;
                }
                else 
                {
                    gameSession.Screen.OpponentMenu(gameSession); 
                    OpponentIndex = chooseFriendOpponent(gameSession);
                }

                Game game = new GameWithFriend();
                game.PlayGame(gameSession, gameSession.Players[OpponentIndex]);
                break;
            }
        }
     }
}