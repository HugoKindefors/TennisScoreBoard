using Microsoft.AspNetCore.Mvc;
using TennisScore.Domain;
using TennisScore.Interface;

namespace TennisScore.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MatchController : ControllerBase
{
    private readonly IMatchService _matchService;

    public MatchController(IMatchService matchService)
    {
        _matchService = matchService;
    }

    [HttpGet]
    public IActionResult GetState()
    {
        return Ok(_matchService.GetState());
    }

    [HttpPost("score/{player}")]
    public IActionResult ScorePoint(string player)
    {
        if (!Enum.TryParse<Player>(player, true, out var parsedPlayer))
            return BadRequest("Invalid player. Use A or B.");

        return Ok(_matchService.ScorePoint(parsedPlayer));
    }

    [HttpPost("reset")]
    public IActionResult Reset()
    {
        return Ok(_matchService.Reset());
    }
}