using sportsradar_scoreboard.main.domain;

namespace sportsradar_scoreboard.main.utils;

public class MatchComparer : IComparer<Match>
{
    public int Compare(Match? x, Match? y)
    {
        if (x == null && y == null) return 0;
        if (y == null) return 1;
        if (x == null) return -1;
        var result = y.GetTotalScore() - x.GetTotalScore();
        return result == 0 ? y.CreatedAt().CompareTo(x.CreatedAt()) : result;
    }
}