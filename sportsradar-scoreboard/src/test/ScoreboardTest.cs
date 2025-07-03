namespace sportsradar_scoreboard.test;

public class ScoreboardTest
{
    private static Team TEAM_1 = new Team("Slovenia", "SLO");
    private static Team TEAM_2 = new Team("Slovakia", "SVK");
    
    [Fact]
    public void ShouldStartNewMatch()
    {
        var scoreboard = new Scoreboard();
        scoreboard.StartMatch(TEAM_1, TEAM_2);
        Assert.Equal("1. SLO 0 - SVK 0", scoreboard.GetInProgressSummary());
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