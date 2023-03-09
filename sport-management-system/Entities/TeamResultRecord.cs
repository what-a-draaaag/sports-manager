using CsvHelper.Configuration.Attributes;

namespace sport_management_system.Entities;

public class TeamResultRecord
{
    [Index(0)] public int Position { get; init; } = 0;
    [Index(1)] public int Score { get; init; } = 0;
    [Index(2)] public string Name { get; init; } = "";
}