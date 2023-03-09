using CsvHelper.Configuration.Attributes;

namespace sport_management_system.Entities;

public class StartRecord
{
    [Index(0)] public int Number { get; init; } = 0;
    [Index(1)] public string LastName { get; init; } = "";
    [Index(2)] public string FirstName { get; init; } = "";
    [Index(3)] public int BirthYear { get; init; } = 0;
    [Index(4)] public string Category { get; init; } = "";
    [Index(5)] public string Team { get; init; } = "";
    [Index(6)] [Format("HH:mm:ss")] public DateTime StartTime { get; init; } = DateTime.Now;
}