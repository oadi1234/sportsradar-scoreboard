namespace sportsradar_scoreboard.main.domain;

public class Team
{
    private string teamName;
    private string teamShortName;

    public Team(string teamName, string teamShortName)
    {
        this.teamName = teamName;
        this.teamShortName = teamShortName;
    }

    public string GetShortName()
    {
        return teamShortName;
    }
}