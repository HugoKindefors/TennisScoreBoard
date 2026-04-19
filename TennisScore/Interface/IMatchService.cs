using TennisScore.Domain;
using TennisScore.DTOs;

namespace TennisScore.Interface;

public interface IMatchService
{
    TennisScoreDTO GetState();
    TennisScoreDTO ScorePoint(Player player);
    TennisScoreDTO Reset();
}