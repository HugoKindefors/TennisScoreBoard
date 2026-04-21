Tennis Score Board

En fullstack-applikation för att räkna tennispoäng i realtid.
Byggd med React i frontend och ASP.NET Core Web API i backend.

Applikationen stödjer:

Poängsättning för två spelare
Ångra senaste poäng (undo)
Återställning av match (reset)
Visar vem som servar

Teknikstack

Frontend

React
TypeScript
Vite

Backend

ASP.NET Core Web API (.NET 10)

Kommunikation

REST API mellan frontend och backend
Förkrav

Se till att följande är installerat:

Git
.NET SDK 10.0
Node.js 22 (LTS rekommenderas)
npm (ingår i Node.js)

Kontrollera versioner:

dotnet --version
node --version
npm --version

Kom igång
1. Klona projektet
git clone <din-repo-url>
cd TennisScoreBoard
2. Starta backend (ASP.NET Core)
cd TennisScore
dotnet restore
dotnet run --launch-profile https

Backend körs på:

https://localhost:7193
http://localhost:5250
3. Starta frontend (Vite)

Öppna ett nytt terminalfönster:

cd frontend
npm install
npm run dev

Frontend körs på:

http://localhost:5173
4. Öppna appen

Gå till:

http://localhost:5173

API-endpoints
Metod	Endpoint	Beskrivning
GET	/api/match	Hämta aktuell matchstatus
POST	/api/match/score/{player}	Lägg till poäng (A eller B)
POST	/api/match/reset	Återställ match
POST	/api/match/undo	Ångra senaste poäng

Framtida utveckling

Projektet är förberett för att kunna byggas ut med:

Databaslagring av matcher och spelare
Matchhistorik och statistik
Flera samtidiga matcher
