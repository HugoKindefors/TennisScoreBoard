using TennisScore.Domain.Entities;

namespace TennisScore.Domain;

public class TennisMatch
{
    public TennisSet CurrentSet { get; private set; } = new();
    public TennisGame CurrentGame { get; private set; } = new();

    public int PlayerASets { get; private set; }
    public int PlayerBSets { get; private set; }

    public Player Server { get; private set; } = Player.A;
    public Player? Winner { get; private set; }

    public bool IsOver => Winner is not null;

    private readonly List<Player> _pointHistory = new();

    public void ScorePoint(Player player)
    {
        if (IsOver) return;

        _pointHistory.Add(player);
        ApplyPoint(player);
    }

    public void Undo()
    {
        if (_pointHistory.Count == 0) return;

        _pointHistory.RemoveAt(_pointHistory.Count - 1);

        var historyToReplay = _pointHistory.ToList();

        Reset();

        foreach (var player in historyToReplay)
        {
            ScorePoint(player);
        }
    }

    private void ApplyPoint(Player player)
    {
        CurrentGame.ScorePoint(player);

        if (CurrentGame.Winner is null) return;

        CurrentSet.AwardGame(CurrentGame.Winner.Value);
        CurrentGame.Reset();
        Server = Server == Player.A ? Player.B : Player.A;

        if (CurrentSet.Winner is null) return;

        AwardSet(CurrentSet.Winner.Value);

        if (!IsOver)
        {
            CurrentSet = new TennisSet();
            CurrentGame = new TennisGame();
        }
    }

    private void AwardSet(Player player)
    {
        if (player == Player.A) PlayerASets++;
        else PlayerBSets++;

        if (PlayerASets == 2) Winner = Player.A;
        if (PlayerBSets == 2) Winner = Player.B;
    }

    public void Reset()
    {
        CurrentSet = new TennisSet();
        CurrentGame = new TennisGame();
        PlayerASets = 0;
        PlayerBSets = 0;
        Server = Player.A;
        Winner = null;

        _pointHistory.Clear();
    }
}