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

    public override string ToString()
    {
        return $"{homeTeam.GetTeamName()} {homeTeamScore} - {awayTeam.GetTeamName()} {awayTeamScore}";
    }
}