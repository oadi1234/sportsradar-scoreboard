using sportsradar_scoreboard.main;
using sportsradar_scoreboard.main.domain;

namespace sportsradar_scoreboard.test;

public class ScoreboardTest
{
    private static readonly Team TEAM_1 = new("Slovenia", "SLO");
    private static readonly Team TEAM_2 = new("Slovakia", "SVK");
    private static readonly Team TEAM_3 = new("Australia", "AUS");

    [Fact]
    public void ShouldStartNewMatch()
    {
        var scoreboard = new Scoreboard();
        scoreboard.StartMatch(homeTeam: TEAM_1, awayTeam: TEAM_2);
        Assert.Equal("1. Slovenia 0 - Slovakia 0", scoreboard.GetInProgressSummary());
    }

    [Fact]
    public void ShouldNotStartMatchWhenTeamAlreadyPlaying()
    {
        var scoreboard = new Scoreboard();
        scoreboard.StartMatch(homeTeam: TEAM_1, awayTeam: TEAM_2);
        Assert.Throws<ArgumentException>(() => scoreboard.StartMatch(homeTeam: TEAM_3, awayTeam: TEAM_2));
    }

    [Fact]
    public void ShouldUpdateScore()
    {
        var scoreboard = new Scoreboard();
        scoreboard.StartMatch(homeTeam: TEAM_1, awayTeam: TEAM_2);

        scoreboard.UpdateScore(homeTeam: TEAM_1, awayTeam: TEAM_2, homeTeamScore: 1, awayTeamScore: 0);
        Assert.Equal("1. Slovenia 1 - Slovakia 0", scoreboard.GetInProgressSummary());
    }

    [Fact]
    public void ShouldNotUpdateScoreToNegative()
    {
        var scoreboard = new Scoreboard();
        scoreboard.StartMatch(homeTeam: TEAM_1, awayTeam: TEAM_2);

        Assert.Throws<ArgumentException>(() => scoreboard.UpdateScore(homeTeam: TEAM_1, awayTeam: TEAM_2, -1, 0));
    }

    [Fact]
    public void ShouldFinishMatch()
    {
    }

    [Fact]
    public void ShouldDoNothingOnFinishingNonExistentMatch()
    {
    }

    [Fact]
    public void ShouldPrintSummaryInCorrectOrder()
    {
    }
}