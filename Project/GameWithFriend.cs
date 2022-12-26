using System;


public class GameWithFriend : Game
{
    
    protected override int GetTurnPosition(int turn)
    {
        int res;
        
        Console.Write("Enter a turn position (1 - 9): ");
        res = Convert.ToInt32(Console.ReadLine());
        
        return res - 1;
    }
}