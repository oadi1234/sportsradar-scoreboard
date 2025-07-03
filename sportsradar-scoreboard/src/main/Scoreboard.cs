using sportsradar_scoreboard.main.domain;
using sportsradar_scoreboard.main.utils;

namespace sportsradar_scoreboard.main;

public class Scoreboard
{
    private List<Match> ongoingMatches = new();

    public void StartMatch(string homeTeam, string awayTeam)
    {
        ThrowExceptionIfOneOfTeamsIsAlreadyPlaying(homeTeam, awayTeam);
        ongoingMatches.Add(new Match(homeTeam, awayTeam));
    }

    public string GetInProgressSummary()
    {
        var result = "";
        var summaryPosition = 1;
        ongoingMatches.Sort(new MatchComparer());

        foreach (var match in ongoingMatches)
        {
            result += summaryPosition + ". " + match + Environment.NewLine;
            summaryPosition++;
        }

        return result.TrimEnd();
    }

    public void UpdateScore(string homeTeam, string awayTeam, int homeTeamScore, int awayTeamScore)
    {
        CheckIfScoreIsCorrect(homeTeamScore);
        CheckIfScoreIsCorrect(awayTeamScore);

        var match = ongoingMatches.Single(match => match.TeamPresent(homeTeam) && match.TeamPresent(awayTeam));

        match.UpdateScore(homeTeamScore, awayTeamScore);
    }

    public bool FinishMatch(string homeTeam, string awayTeam)
    {
        var match = ongoingMatches.SingleOrDefault(match => match.TeamPresent(homeTeam) && match.TeamPresent(awayTeam),
            new Match());
        return ongoingMatches.Remove(match);
    }

    private void CheckIfScoreIsCorrect(int score)
    {
        if (score < 0)
        {
            throw new ArgumentException("Score cannot be negative");
        }
    }

    private void ThrowExceptionIfOneOfTeamsIsAlreadyPlaying(string homeTeam, string awayTeam)
    {
        if (IsTeamCurrentlyPlaying(homeTeam))
            throw new ArgumentException($"Home team is already playing: {homeTeam}");

        if (IsTeamCurrentlyPlaying(awayTeam))
            throw new ArgumentException($"Away team is already playing: {awayTeam}");
    }

    private bool IsTeamCurrentlyPlaying(string team1)
    {
        return ongoingMatches.Any(match => match.TeamPresent(team1));
    }
}