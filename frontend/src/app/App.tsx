import { useMatch } from "../features/match/hooks/useMatch";
import { ScoreBoard } from "../features/match/components/ScoreBoard";
import { ScoreControls } from "../features/match/components/ScoreControls";

function App() {
  const { match, loading, error, scorePoint, reset, undo } = useMatch();

  return (
    <main className="broadcast-page">
      <section className="overlay-zone">
        {loading && <p className="status-text">Loading scoreboard...</p>}

        {!loading && error && <p className="error">Error: {error}</p>}

        {!loading && !error && match && <ScoreBoard match={match} />}
      </section>

      {!loading && !error && match && (
        <section className="control-panel-wrap">
          <ScoreControls
            onScoreA={() => void scorePoint("A")}
            onScoreB={() => void scorePoint("B")}
            onReset={() => void reset()}
            onUndo={() => void undo()}
            isMatchFinished={Boolean(match.winner)}
          />
        </section>
      )}
    </main>
  );
}

export default App;
