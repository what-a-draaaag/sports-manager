using sport_management_system.Classes;
using sport_management_system.Entities;
using sport_management_system.Interfaces;

namespace sport_management_system;

internal static class Program
{
    private static readonly INumberGenerator _numberGenerator = new RegularNumberGenerator();
    private static readonly IDrawing _drawing = new RegularDrawing();
    private static readonly IScoreCalculator _scoreCalculator = new RegularScoreCalculator();

    private static SportManagementSystem _sms = new(_numberGenerator, _drawing, _scoreCalculator);

    public static void Main(string[] args)
    {
        switch (args[0])
        {
            case "generate-start":
                {
                    string folderIn = args[1];
                    string folderOut = args[2];
                    var applicationRepository =
                        CsvContainerRepository<ApplicationRecord>.LoadFromFolder(folderIn);
                    var startProtocol = _sms.GenerateStartProtocolRepository(applicationRepository);
                    startProtocol.SaveToFolder(folderOut);
                    break;
                }
            case "generate-group-result":
                {
                    string folderInStartProtocols = args[1];
                    string folderInControlPoint = args[2];
                    string folderOut = args[3];
                    var startProtocolsRepository =
                        CsvContainerRepository<StartRecord>.LoadFromFolder(folderInStartProtocols);
                    var controlPointRepository =
                        CsvContainerRepository<ControlPointRecord>.LoadFromFolder(folderInControlPoint);
                    var groupResultRepository =
                        _sms.GenerateGroupResultProtocolRepository(startProtocolsRepository, controlPointRepository);
                    groupResultRepository.SaveToFolder(folderOut);
                    break;
                }
            case "generate-team-result":
                {
                    string folderIn = args[1];
                    string fileOut = args[2];
                    var groupResultRepository =
                        CsvContainerRepository<GroupResultRecord>.LoadFromFolder(folderIn);
                    var teamResult = _sms.GenerateTeamResultProtocol(groupResultRepository);
                    teamResult.SaveToFile(fileOut);
                    break;
                }
        }
    }
}