using sportsradar_scoreboard.main.domain;

namespace sportsradar_scoreboard.main;

public class Scoreboard
{
    private List<Match> ongoingMatches = new();

    public void StartMatch(Team homeTeam, Team awayTeam)
    {
        ThrowExceptionIfOneOfTeamsIsAlreadyPlaying(homeTeam, awayTeam);
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

    public void UpdateScore(Team homeTeam, Team awayTeam, int homeTeamScore, int awayTeamScore)
    {
        foreach (var match in ongoingMatches.Where(match => match.TeamPresent(homeTeam) && match.TeamPresent(awayTeam)))
        {
            match.UpdateScore(homeTeamScore, awayTeamScore);
        }
    }

    private void ThrowExceptionIfOneOfTeamsIsAlreadyPlaying(Team homeTeam, Team awayTeam)
    {
        if (IsTeamCurrentlyPlaying(homeTeam))
            throw new ArgumentException($"Home team is already playing: {homeTeam.TeamName}");

        if (IsTeamCurrentlyPlaying(awayTeam))
            throw new ArgumentException($"Away team is already playing: {awayTeam.TeamName}");
    }

    private bool IsTeamCurrentlyPlaying(Team team1)
    {
        return ongoingMatches.Any(match => match.TeamPresent(team1));
    }
}