using System;
using System.Threading;


public class GameWithComputer : Game
{
    protected override int GetTurnPosition(int turn)
    {
        int Res;

        if(turn % 2 != 0)
        {
            Random rand = new Random();
            Res = rand.Next(1, 10);
            Thread.Sleep(1000);
        }
        else
        {
            Console.Write("Enter a turn position (1 - 9): ");
            Res = Convert.ToInt32(Console.ReadLine());
        }

        return Res - 1;
    }
}