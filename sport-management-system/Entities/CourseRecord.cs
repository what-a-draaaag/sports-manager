using CsvHelper.Configuration.Attributes;

namespace sport_management_system.Entities;

public class CourseRecord
{
    [Index(0)] public string ControlPoint { get; init; } = "";
    [Index(1)] [Format("HH:mm:ss")] public DateTime PassTime { get; init; } = DateTime.Now;
}