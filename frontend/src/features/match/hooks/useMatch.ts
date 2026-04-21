import { useCallback, useEffect, useState } from "react";
import { matchApi } from "../../../api/matchApi";
import type { Player, TennisScoreDto } from "../types";

export function useMatch() {
  const [match, setMatch] = useState<TennisScoreDto | null>(null);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState<string | null>(null);

  const runAction = useCallback(
    async (action: () => Promise<TennisScoreDto>) => {
      setError(null);

      try {
        const data = await action();
        setMatch(data);
      } catch (err) {
        const message =
          err instanceof Error ? err.message : "Ett okänt fel uppstod.";
        setError(message);
      } finally {
        setLoading(false);
      }
    },
    [],
  );

  useEffect(() => {
    void runAction(matchApi.getState);
  }, [runAction]);

  const scorePoint = useCallback(
    async (player: Player) => {
      await runAction(() => matchApi.scorePoint(player));
    },
    [runAction],
  );

  const reset = useCallback(async () => {
    await runAction(matchApi.reset);
  }, [runAction]);

  const undo = useCallback(async () => {
    await runAction(matchApi.undo);
  }, [runAction]);

  return {
    match,
    loading,
    error,
    scorePoint,
    reset,
    undo,
  };
}
