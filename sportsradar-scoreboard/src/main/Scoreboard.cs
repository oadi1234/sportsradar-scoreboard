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
        var debugString = "";
        var i = 1;
        foreach (var match in ongoingMatches)
        {
            debugString += i + ". " + match;
            i++;
        }

        return debugString;
    }
}