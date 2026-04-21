import { Button } from "../../../shared/ui/Button";
import "./ScoreControls.css";

type ScoreControlsProps = {
  onScoreA: () => void;
  onScoreB: () => void;
  onReset: () => void;
  onUndo: () => void;
  isMatchFinished: boolean;
};

export function ScoreControls({
  onScoreA,
  onScoreB,
  onReset,
  onUndo,
  isMatchFinished,
}: ScoreControlsProps) {
  return (
    <section className="controls" aria-label="Match controls">
      <Button
        onClick={onScoreA}
        disabled={isMatchFinished}
        className="btn-large"
      >
        Point Player A
      </Button>
      <Button
        onClick={onScoreB}
        disabled={isMatchFinished}
        className="btn-large"
      >
        Point Player B
      </Button>
      <Button variant="neutral" onClick={onUndo} className="btn-secondary">
        Undo
      </Button>
      <Button variant="danger" onClick={onReset} className="btn-secondary">
        Reset
      </Button>
    </section>
  );
}
