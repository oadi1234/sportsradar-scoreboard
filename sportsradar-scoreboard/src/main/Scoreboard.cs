using sportsradar_scoreboard.main.domain;

namespace sportsradar_scoreboard.main;

public class Scoreboard
{
    private List<Match> ongoingMatches = new();

    public void StartMatch(Team homeTeam, Team awayTeam)
    {
        if (IsOneOfTeamsCurrentlyPlaying(homeTeam, awayTeam))
            throw new ArgumentException("One of the teams already present");
        ongoingMatches.Add(new Match(homeTeam, awayTeam));
    }

    public string GetInProgressSummary()
    {
        var result = "";
        var summaryPosition = 1;
        foreach (var match in ongoingMatches)
        {
            result += summaryPosition + ". " + match;
            summaryPosition++;
        }

        return result;
    }

    private bool IsOneOfTeamsCurrentlyPlaying(Team team1, Team team2)
    {
        return ongoingMatches.Any(match => match.TeamPresent(team1) || match.TeamPresent(team2));
    }
}