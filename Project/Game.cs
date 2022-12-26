using System;
using System.Collections.Generic;
using System.Threading;


public class Game
{
    public int GameRating = 0; 

    public PlayerAccount Winner = new PlayerAccount();

    public PlayerAccount Loser = new PlayerAccount();

    public bool gameStatus; 
    public int[,] GameBoard = new int[3,3] {{0,0,0},{0,0,0},{0,0,0}};

    public Menu screen = new Menu();

    protected virtual int GetTurnPosition(int turn)
    {
        int res;
        
        Random rand = new Random();
        res = rand.Next(1, 10);
        
        return res - 1;
    }
    
    public void GameMove(int turn, int index)
    {
        int position, row, col;
        while(true)
        {
            position = GetTurnPosition(turn);
            row = position / 3;
            col = position - (3 * row);

            if(GameBoard[row, col] == 0) break;
            Console.WriteLine("\n\t-- This position has been already chosen! Try another one)"); 
        }
        
        GameBoard[row, col] = index;
    }

    protected bool checkWinCondition()
    {
        int maind_sum = Math.Abs(this.GameBoard[0,0] + this.GameBoard[1,1] + this.GameBoard[2,2]);
        int subd_sum = Math.Abs(this.GameBoard[0,2] + this.GameBoard[1,1] + this.GameBoard[2,0]);
        if(maind_sum == 3 || subd_sum == 3) return true;

        int row_sum, col_sum; 
        for(int i = 0; i < 3; i++)
        {
            row_sum = Math.Abs(this.GameBoard[i,0] + this.GameBoard[i,1] + this.GameBoard[i,2]);
            col_sum = Math.Abs(this.GameBoard[0,i] + this.GameBoard[1,i] + this.GameBoard[2,i]);

            if(row_sum == 3 || col_sum == 3) return true;
        }
        
        return false;
    }

    public virtual void PlayGame(GameSession gameSession, PlayerAccount Opponet)
    {
        List<PlayerAccount> GamePlayers = new List<PlayerAccount>();
        GamePlayers.Add(gameSession.Players[0]);
        GamePlayers.Add(Opponet);
        
        Random rand = new Random();
        int Index = rand.Next(0, 2);

        int Turns = 0, valueIndex = 1;
        
        Console.Clear();
        screen.BoardScreen(this, GamePlayers[Index].UserName);

        bool Win = false;
        while(Turns < 9 && Win == false)
        {
            GameMove(Index, valueIndex);
            Console.Write("Waiting...");
            Win = checkWinCondition();

            Turns++;
            Index = 1 - Index;
            valueIndex -= 2 * valueIndex;
            
            Thread.Sleep(1000);
            Console.Clear();
            screen.BoardScreen(this, GamePlayers[Index].UserName);
        }

        gameStatus = Win;
        Winner = GamePlayers[1 - Index];
        Loser = GamePlayers[Index];

        gameSession.EndGameSession(this);
    }
}