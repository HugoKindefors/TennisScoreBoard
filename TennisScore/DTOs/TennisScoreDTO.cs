using TennisScore.Domain;

namespace TennisScore.DTOs;

public class TennisScoreDTO
{
    public int PlayerAScore { get; set; }
    public int PlayerBScore { get; set; }
    public int PlayerAGames { get; set; }
    public int PlayerBGames { get; set; }
    public int PlayerASets { get; set; }
    public int PlayerBSets { get; set; }
    public string Server { get; set; } = string.Empty;
    public string? Winner { get; set; }
    public string PlayerAPointDisplay { get; set; } = string.Empty;
    public string PlayerBPointDisplay { get; set; } = string.Empty;

    public static TennisScoreDTO FromMatch(TennisMatch match)
    {
        return new TennisScoreDTO
        {
            PlayerAScore = match.CurrentGame.PlayerAScore,
            PlayerBScore = match.CurrentGame.PlayerBScore,
            PlayerAGames = match.CurrentSet.PlayerAGames,
            PlayerBGames = match.CurrentSet.PlayerBGames,
            PlayerASets = match.PlayerASets,
            PlayerBSets = match.PlayerBSets,
            Server = match.Server.ToString(),
            Winner = match.Winner?.ToString(),
            PlayerAPointDisplay = match.CurrentGame.PlayerAPointDisplay,
            PlayerBPointDisplay = match.CurrentGame.PlayerBPointDisplay
        };
    }
}