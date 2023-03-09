using CsvHelper.Configuration.Attributes;

namespace sport_management_system.Entities;

public class ApplicationRecord
{
    [Index(0)] public string LastName { get; init; } = "";
    [Index(1)] public string FirstName { get; init; } = "";
    [Index(2)] public int BirthYear { get; init; } = 0;
    [Index(3)] public string Category { get; init; } = "";
    [Index(4)] public string Group { get; init; } = "";
}