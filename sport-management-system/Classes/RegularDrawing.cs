using sport_management_system.Entities;
using sport_management_system.Interfaces;

namespace sport_management_system.Classes;

public class RegularDrawing : IDrawing
{
    private readonly DateTime _startTime = DateTime.Parse("12:00:00");
    private readonly Dictionary<string, int> GroupOccurance = new Dictionary<string, int>();
    public DateTime CalculateStartTime(ApplicationRecord application)
    {
        if (!GroupOccurance.ContainsKey(application.Group))
            GroupOccurance[application.Group] = 0;
        return _startTime.AddMinutes(GroupOccurance[application.Group]++);
    }
}