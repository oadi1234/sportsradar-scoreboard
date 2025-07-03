using sportsradar_scoreboard.main;

namespace sportsradar_scoreboard.test;

public class ScoreboardTest
{
    private static readonly string TEAM_SLOVENIA = "Slovenia";
    private static readonly string TEAM_SLOVAKIA = "Slovakia";
    private static readonly string TEAM_AUSTRALIA = "Australia";

    [Fact]
    public void ShouldStartNewMatch()
    {
        var scoreboard = new Scoreboard();
        scoreboard.StartMatch(homeTeam: TEAM_SLOVENIA, awayTeam: TEAM_SLOVAKIA);
        Assert.Equal("1. Slovenia 0 - Slovakia 0", scoreboard.GetInProgressSummary());
    }

    [Fact]
    public void ShouldNotStartMatchWhenTeamAlreadyPlaying()
    {
        var scoreboard = new Scoreboard();
        scoreboard.StartMatch(homeTeam: TEAM_SLOVENIA, awayTeam: TEAM_SLOVAKIA);
        Assert.Throws<ArgumentException>(() => scoreboard.StartMatch(homeTeam: TEAM_AUSTRALIA, awayTeam: TEAM_SLOVAKIA));
    }

    [Fact]
    public void ShouldUpdateScore()
    {
        var scoreboard = new Scoreboard();
        scoreboard.StartMatch(homeTeam: TEAM_SLOVENIA, awayTeam: TEAM_SLOVAKIA);

        scoreboard.UpdateScore(homeTeam: TEAM_SLOVENIA, awayTeam: TEAM_SLOVAKIA, homeTeamScore: 1, awayTeamScore: 0);
        Assert.Equal("1. Slovenia 1 - Slovakia 0", scoreboard.GetInProgressSummary());
    }

    [Fact]
    public void ShouldNotUpdateScoreToNegative()
    {
        var scoreboard = new Scoreboard();
        scoreboard.StartMatch(homeTeam: TEAM_SLOVENIA, awayTeam: TEAM_SLOVAKIA);

        Assert.Throws<ArgumentException>(() => scoreboard.UpdateScore(homeTeam: TEAM_SLOVENIA, awayTeam: TEAM_SLOVAKIA, -1, 0));
    }

    [Fact]
    public void ShouldFinishMatch()
    {
        var scoreboard = new Scoreboard();
        scoreboard.StartMatch(homeTeam: TEAM_SLOVENIA, awayTeam: TEAM_SLOVAKIA);
        Assert.True(scoreboard.FinishMatch(homeTeam: TEAM_SLOVENIA, awayTeam: TEAM_SLOVAKIA));
    }

    [Fact]
    public void ShouldNotFinishMatchIfNotPresent()
    {
        var scoreboard = new Scoreboard();
        Assert.False(scoreboard.FinishMatch(homeTeam: TEAM_SLOVENIA, awayTeam: TEAM_SLOVAKIA));
    }

    [Fact]
    public void ShouldPrintSummaryInCorrectOrder()
    {
    }
}