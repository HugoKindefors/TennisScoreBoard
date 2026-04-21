import type { TennisScoreDto } from "../types";
import "./ScoreBoard.css";

type ScoreBoardProps = {
  match: TennisScoreDto;
};

function normalizePoint(rawPoint: string): string {
  const point = rawPoint.trim().toUpperCase();

  if (point === "AD" || point === "ADV" || point === "ADVANTAGE") {
    return "AD";
  }

  if (point === "0" || point === "15" || point === "30" || point === "40") {
    return point;
  }

  const numeric = Number(point);
  if (Number.isNaN(numeric)) return point;

  return numeric === 0
    ? "0"
    : numeric === 1
      ? "15"
      : numeric === 2
        ? "30"
        : numeric === 3
          ? "40"
          : point;
}

export function ScoreBoard({ match }: ScoreBoardProps) {
  const playerADisplay = normalizePoint(match.playerAPointDisplay);
  const playerBDisplay = normalizePoint(match.playerBPointDisplay);
  const normalizedServer = match.server.trim().toUpperCase();
  const isServerA =
    normalizedServer === "A" ||
    normalizedServer === "PLAYER A" ||
    normalizedServer === "PLAYERA";
  const isServerB =
    normalizedServer === "B" ||
    normalizedServer === "PLAYER B" ||
    normalizedServer === "PLAYERB";

  return (
    <section
      className="broadcast-scoreboard"
      aria-label="Broadcast tennis scoreboard"
    >
      <div className="scoreboard-bar">
        <div className="scoreboard-row player-a-row">
          <div className="player-name-wrap">
            <span
              className={`server-dot ${isServerA ? "is-active" : ""}`}
              aria-label={isServerA ? "Player A serves" : "Player A receives"}
            ></span>
            <div className="player-name">PLAYER A</div>
          </div>
          <div className="sets-column">
            <span className="set-box">{match.playerASets}</span>
          </div>
          <div className="games-column">
            <span className="games-value">{match.playerAGames}</span>
          </div>
          <div className="point-column">
            <span className="point-box point-flash">{playerADisplay}</span>
          </div>
        </div>

        <div className="scoreboard-row player-b-row">
          <div className="player-name-wrap">
            <span
              className={`server-dot ${isServerB ? "is-active" : ""}`}
              aria-label={isServerB ? "Player B serves" : "Player B receives"}
            ></span>
            <div className="player-name">PLAYER B</div>
          </div>
          <div className="sets-column">
            <span className="set-box">{match.playerBSets}</span>
          </div>
          <div className="games-column">
            <span className="games-value">{match.playerBGames}</span>
          </div>
          <div className="point-column">
            <span className="point-box point-flash">{playerBDisplay}</span>
          </div>
        </div>
      </div>

      {match.winner && (
        <div className="scoreboard-info">
          <div className="info-item">
            <span className="info-label">Winner:</span>
            <span className="info-value">{match.winner}</span>
          </div>
        </div>
      )}
    </section>
  );
}
