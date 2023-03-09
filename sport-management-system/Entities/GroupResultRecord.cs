using CsvHelper.Configuration.Attributes;

namespace sport_management_system.Entities;

public class GroupResultRecord
{
    [Index(0)] public int Position { get; init; } = 0;
    [Index(1)] public int Number { get; init; } = 0;
    [Index(2)] public string LastName { get; init; } = "";
    [Index(3)] public string FirstName { get; init; } = "";
    [Index(4)] public int BirthYear { get; init; } = 0;
    [Index(5)] public string Category { get; init; } = "";
    [Index(6)] public string Team { get; init; } = "";
    [Index(7)] public TimeSpan RoundTime { get; init; } = TimeSpan.Zero;
}