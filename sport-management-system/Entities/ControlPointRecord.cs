using CsvHelper.Configuration.Attributes;

namespace sport_management_system.Entities;

public class ControlPointRecord
{
    [Index(0)] public int Number { get; init; } = 0;
    [Index(1)] [Format("HH:mm:ss")] public DateTime PassTime { get; init; } = DateTime.Now;
}