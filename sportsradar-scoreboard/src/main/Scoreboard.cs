using sportsradar_scoreboard.main.domain;

namespace sportsradar_scoreboard.main;

public class Scoreboard
{
    private List<Match> ongoingMatches = new();

    public void StartMatch(Team homeTeam, Team awayTeam)
    {
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
}