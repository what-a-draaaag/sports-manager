using sport_management_system.Entities;

namespace sport_management_system.Interfaces;

public interface INumberGenerator
{
    int GenerateNextNumber(ApplicationRecord application);
}