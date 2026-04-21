export type Player = "A" | "B";

export interface TennisScoreDto {
  playerAScore: number;
  playerBScore: number;
  playerAGames: number;
  playerBGames: number;
  playerASets: number;
  playerBSets: number;
  server: string;
  winner: string | null;
  playerAPointDisplay: string;
  playerBPointDisplay: string;
}
