using sport_management_system.Entities;
using sport_management_system.Interfaces;

namespace sport_management_system.Classes;

public class RegularNumberGenerator : INumberGenerator
{
    private int _lastNumber = 1;
    public int GenerateNextNumber(ApplicationRecord application)
    {
        return _lastNumber++;
    }
}