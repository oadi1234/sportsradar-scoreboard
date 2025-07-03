using sportsradar_scoreboard.main;

namespace sportsradar_scoreboard.test;

public class ScoreboardTest
{
    private static readonly string TEAM_SLOVENIA = "Slovenia";
    private static readonly string TEAM_SLOVAKIA = "Slovakia";
    private static readonly string TEAM_AUSTRALIA = "Australia";
    private static readonly string TEAM_URUGUAY = "Uruguay";
    private static readonly string TEAM_ITALY = "Italy";
    private static readonly string TEAM_SPAIN = "Spain";
    private static readonly string TEAM_BRAZIL = "Brazil";
    private static readonly string TEAM_MEXICO = "Mexico";
    private static readonly string TEAM_CANADA = "Canada";
    private static readonly string TEAM_ARGENTINA = "Argentina";
    private static readonly string TEAM_GERMANY = "Germany";
    private static readonly string TEAM_FRANCE = "France";

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
        Assert.Throws<ArgumentException>(() =>
            scoreboard.StartMatch(homeTeam: TEAM_AUSTRALIA, awayTeam: TEAM_SLOVAKIA));
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

        Assert.Throws<ArgumentException>(() =>
            scoreboard.UpdateScore(homeTeam: TEAM_SLOVENIA, awayTeam: TEAM_SLOVAKIA, -1, 0));
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
        var scoreboard = new Scoreboard();
        scoreboard.StartMatch(homeTeam: TEAM_MEXICO, awayTeam: TEAM_CANADA);
        scoreboard.UpdateScore(homeTeam: TEAM_MEXICO, awayTeam: TEAM_CANADA, 0, 5);
        scoreboard.StartMatch(homeTeam: TEAM_SPAIN, awayTeam: TEAM_BRAZIL);
        scoreboard.UpdateScore(homeTeam: TEAM_SPAIN, awayTeam: TEAM_BRAZIL, 10, 2);
        scoreboard.StartMatch(homeTeam: TEAM_GERMANY, awayTeam: TEAM_FRANCE);
        scoreboard.UpdateScore(homeTeam: TEAM_GERMANY, awayTeam: TEAM_FRANCE, 2, 2);
        scoreboard.StartMatch(homeTeam: TEAM_URUGUAY, awayTeam: TEAM_ITALY);
        scoreboard.UpdateScore(homeTeam: TEAM_URUGUAY, awayTeam: TEAM_ITALY, 6, 6);
        scoreboard.StartMatch(homeTeam: TEAM_ARGENTINA, awayTeam: TEAM_AUSTRALIA);
        scoreboard.UpdateScore(homeTeam: TEAM_ARGENTINA, awayTeam: TEAM_AUSTRALIA, 3, 1);
        
        Assert.Equal("1. Uruguay 6 - Italy 6" + Environment.NewLine +
                     "2. Spain 10 - Brazil 2" + Environment.NewLine +
                     "3. Mexico 0 - Canada 5" + Environment.NewLine +
                     "4. Argentina 3 - Australia 1" + Environment.NewLine +
                     "5. Germany 2 - France 2", scoreboard.GetInProgressSummary());
    }
}