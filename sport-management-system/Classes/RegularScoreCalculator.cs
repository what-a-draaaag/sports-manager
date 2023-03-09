using sport_management_system.Entities;
using sport_management_system.Interfaces;

namespace sport_management_system.Classes;

public class RegularScoreCalculator : IScoreCalculator
{
    public int CalculateScore(GroupResultRecord targetResult, GroupResultRecord bestResult)
    {
        return Math.Max(0, (int)(100 * (2 - targetResult.RoundTime.TotalSeconds / bestResult.RoundTime.TotalSeconds)));
    }
}