using sport_management_system.Entities;

namespace sport_management_system.Interfaces;

public interface IDrawing
{
    DateTime CalculateStartTime(ApplicationRecord application);
}