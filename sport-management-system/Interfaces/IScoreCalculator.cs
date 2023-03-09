using sport_management_system.Entities;

namespace sport_management_system.Interfaces;

public interface IScoreCalculator
{
    int CalculateScore(GroupResultRecord targetResult, GroupResultRecord bestResult);
}