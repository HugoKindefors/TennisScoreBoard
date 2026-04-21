import { apiFetch } from "./client";
import type { Player, TennisScoreDto } from "../features/match/types";

export const matchApi = {
  getState: () => apiFetch<TennisScoreDto>("/api/match"),
  scorePoint: (player: Player) =>
    apiFetch<TennisScoreDto>(`/api/match/score/${player}`, { method: "POST" }),
  reset: () => apiFetch<TennisScoreDto>("/api/match/reset", { method: "POST" }),
  undo: () => apiFetch<TennisScoreDto>("/api/match/undo", { method: "POST" }),
};
