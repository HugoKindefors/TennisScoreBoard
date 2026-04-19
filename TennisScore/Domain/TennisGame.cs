namespace TennisScore.Domain;

public class TennisGame
{
    public int PlayerAScore { get; private set; }
    public int PlayerBScore { get; private set; }
    public Player? Winner { get; private set; }


    public bool IsOver => Winner is not null;

    public void ScorePoint(Player player)
    {
        if (IsOver) return;

        if (player == Player.A) PlayerAScore++;
        else PlayerBScore++;

        TryGameWinner();
    }

    public void UndoPoint(Player player)
    {
        if (IsOver) return;

        if (player == Player.A && PlayerAScore > 0) PlayerAScore--;
        else if (player == Player.B && PlayerBScore > 0) PlayerBScore--;
    }

    private void TryGameWinner()
    {
        if (PlayerAScore >= 4 && PlayerAScore - PlayerBScore >= 2)
            Winner = Player.A;
        else if (PlayerBScore >= 4 && PlayerBScore - PlayerAScore >= 2)
            Winner = Player.B;
    }

    public void Reset()
    {
        PlayerAScore = 0;
        PlayerBScore = 0;
        Winner = null;
    }
    public string GetScoreDisplay()
    {
        var a = PlayerAScore;
        var b = PlayerBScore;

        if (a >= 3 && b >= 3)
        {
            if (a == b) return "Deuce";
            return a > b ? "Advantage A" : "Advantage B";
        }

        string ToTennisPoint(int p) => p switch
        {
            0 => "Love",
            1 => "Fifteen",
            2 => "Thirty",
            3 => "Forty",
            _ => p.ToString()
        };

        if (a == b)
            return $"{ToTennisPoint(a)}-All";

        return $"{ToTennisPoint(a)}-{ToTennisPoint(b)}";
    }

}
