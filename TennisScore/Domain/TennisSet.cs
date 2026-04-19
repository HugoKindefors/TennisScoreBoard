namespace TennisScore.Domain;

public class TennisSet
{
    public int PlayerAGames { get; private set; }
    public int PlayerBGames { get; private set; }

    public bool IsOver => Winner is not null;
    public Player? Winner { get; private set; }

    public void AwardGame(Player player)
    {
        if (IsOver) return;

        if (player == Player.A) PlayerAGames++;
        else PlayerBGames++;

        TrySetWinner();
    }

    private void TrySetWinner()
    {
        if (PlayerAGames >= 6 && PlayerAGames - PlayerBGames >= 2)
            Winner = Player.A;
        else if (PlayerBGames >= 6 && PlayerBGames - PlayerAGames >= 2)
            Winner = Player.B;
    }

}
