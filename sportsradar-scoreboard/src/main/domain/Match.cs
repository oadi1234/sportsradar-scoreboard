namespace sportsradar_scoreboard.main.domain;

public class Match
{
    private Team homeTeam;
    private Team awayTeam;
    private int homeTeamScore;
    private int awayTeamScore;

    public Match(Team homeTeam, Team awayTeam)
    {
        this.homeTeam = homeTeam;
        this.awayTeam = awayTeam;
        homeTeamScore = 0;
        awayTeamScore = 0;
    }

    public bool TeamPresent(Team team)
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
        return $"{homeTeam.TeamName} {homeTeamScore} - {awayTeam.TeamName} {awayTeamScore}";
    }
}