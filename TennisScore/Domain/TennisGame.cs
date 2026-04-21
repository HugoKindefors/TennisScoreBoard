using TennisScore.Domain.Entities;

namespace TennisScore.Domain;

public class TennisGame
{
    public int PlayerAScore { get; private set; }
    public int PlayerBScore { get; private set; }
    public Player? Winner { get; private set; }

    public string PlayerAPointDisplay => GetPointDisplay(PlayerAScore, PlayerBScore);
    public string PlayerBPointDisplay => GetPointDisplay(PlayerBScore, PlayerAScore);


    public bool IsOver => Winner is not null;

    public void ScorePoint(Player player)
    {
        if (IsOver) return;

        if (player == Player.A) PlayerAScore++;
        else PlayerBScore++;

        TryGameWinner();
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

    private string GetPointDisplay(int myScore, int opponentScore)
    {
        if (myScore >= 3 && opponentScore >= 3)
        {
            return myScore > opponentScore ? "AD" : "40";
        }

        return ScoreToNumber(myScore);
    }


    private static string ScoreToNumber(int score) => score switch
    {
        0 => "0",
        1 => "15",
        2 => "30",
        3 => "40",
        _ => "0"
    };

}
