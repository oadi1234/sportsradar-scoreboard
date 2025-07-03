namespace sportsradar_scoreboard.main.domain;

public class Match
{
    private string homeTeam;
    private string awayTeam;
    private int homeTeamScore;
    private int awayTeamScore;

    public Match(string homeTeam, string awayTeam)
    {
        this.homeTeam = homeTeam;
        this.awayTeam = awayTeam;
        homeTeamScore = 0;
        awayTeamScore = 0;
    }

    public Match()
    {
    }

    public bool TeamPresent(string team)
    {
        return team == homeTeam || team == awayTeam;
    }

    public void UpdateScore(int homeTeamScore, int awayTeamScore)
    {
        this.homeTeamScore = homeTeamScore;
        this.awayTeamScore = awayTeamScore;
    }

    public override string ToString()
    {
        return $"{homeTeam} {homeTeamScore} - {awayTeam} {awayTeamScore}";
    }
}