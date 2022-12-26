

public class GameHistory
{
     public readonly int GameRating; 
    public readonly string OpponentName = "";
    public readonly bool IsWin;
    public readonly int GameID;
    private static int GameIDCounter = 1;

    public GameHistory(int gameRating, string opponentName, bool isWin)
    {
        GameRating = gameRating;
        OpponentName = opponentName;
        IsWin = isWin;

        GameID = (GameIDCounter + 1) / 2;
        GameIDCounter++;
    } 


}