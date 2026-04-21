using TennisScore.Domain;
using TennisScore.Domain.Entities;
using TennisScore.DTOs;
using TennisScore.Interface;

namespace TennisScore.Services;

public class MatchService : IMatchService
{
    private TennisMatch _match = new();

    public TennisScoreDTO GetState()
    {
        return TennisScoreDTO.FromMatch(_match);
    }

    public TennisScoreDTO ScorePoint(Player player)
    {
        _match.ScorePoint(player);
        return TennisScoreDTO.FromMatch(_match);
    }

    public TennisScoreDTO Reset()
    {
        _match = new TennisMatch();
        return TennisScoreDTO.FromMatch(_match);
    }

    public TennisScoreDTO Undo()
    {
        _match.Undo();
        return TennisScoreDTO.FromMatch(_match);
    }
}