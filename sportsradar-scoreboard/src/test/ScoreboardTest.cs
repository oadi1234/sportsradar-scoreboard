using sportsradar_scoreboard.main;
using sportsradar_scoreboard.main.domain;

namespace sportsradar_scoreboard.test;

public class ScoreboardTest
{
    private static readonly Team TEAM_1 = new("Slovenia", "SLO");
    private static readonly Team TEAM_2 = new("Slovakia", "SVK");
    
    [Fact]
    public void ShouldStartNewMatch()
    {
        var scoreboard = new Scoreboard();
        scoreboard.StartMatch(TEAM_1, TEAM_2);
        Assert.Equal("1. Slovenia 0 - Slovakia 0", scoreboard.GetInProgressSummary());
    }
    
    [Fact]
    public void ShouldNotStartMatchWithTeamAlreadyPresentOnScoreboard()
    {
    }
    
    [Fact]
    public void ShouldUpdateScore()
    {
    }

    [Fact]
    public void ShouldNotUpdateScoreWhenMatchIsFinished()
    {
        
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