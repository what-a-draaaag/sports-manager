using sport_management_system.Entities;
using sport_management_system.Interfaces;

namespace sport_management_system;

public class SportManagementSystem
{
    private readonly INumberGenerator _numberGenerator;
    private readonly IDrawing _drawing;
    private readonly IScoreCalculator _scoreCalculator;

    public SportManagementSystem(INumberGenerator numberGenerator, IDrawing drawing,
        IScoreCalculator scoreCalculator)
    {
        _numberGenerator = numberGenerator;
        _drawing = drawing;
        _scoreCalculator = scoreCalculator;
    }

    public CsvContainerRepository<StartRecord> GenerateStartProtocolRepository(
        CsvContainerRepository<ApplicationRecord> applicationsRepository)
    {
        var startProtocolRepository = new CsvContainerRepository<StartRecord>();
        foreach (var team in applicationsRepository.GetCsvContainersNames())
        {
            var application = applicationsRepository.GetCsvContainer(team);
            foreach (var record in application.Records)
            {
                startProtocolRepository.GetCsvContainer(record.Group).Records.Add(new StartRecord()
                {
                    Category = record.Category,
                    Number = _numberGenerator.GenerateNextNumber(record),
                    BirthYear = record.BirthYear,
                    FirstName = record.FirstName,
                    LastName = record.LastName,
                    StartTime = _drawing.CalculateStartTime(record),
                    Team = team,
                });
            }
        }

        return startProtocolRepository;
    }

    public CsvContainerRepository<GroupResultRecord> GenerateGroupResultProtocolRepository(
        CsvContainerRepository<StartRecord> startRepository,
        CsvContainerRepository<ControlPointRecord> controlPointsRepository)
    {
        var groupResultProtocolRepository = new CsvContainerRepository<GroupResultRecord>();
        var cpFinish = controlPointsRepository.GetCsvContainer("finish");
        foreach (var group in startRepository.GetCsvContainersNames())
        {
            var startProtocol = startRepository.GetCsvContainer(group);
            var startRecords = from startRecord in startProtocol.Records
                let finishRecord = cpFinish.Records.Find((r) => r.Number == startRecord.Number)
                where finishRecord != null
                let timespan = finishRecord.PassTime - startRecord.StartTime
                orderby timespan
                select new Tuple<StartRecord, ControlPointRecord>(startRecord, finishRecord);

            var groupResultRecords = startRecords.Select(((tup, i) => new GroupResultRecord()
            {
                Category = tup.Item1.Category,
                Number = tup.Item1.Number,
                BirthYear = tup.Item1.BirthYear,
                FirstName = tup.Item1.FirstName,
                LastName = tup.Item1.LastName,
                Position = i + 1,
                RoundTime = tup.Item2.PassTime - tup.Item1.StartTime,
                Team = tup.Item1.Team,
            }));

            groupResultProtocolRepository.GetCsvContainer(group).Records.AddRange(groupResultRecords);
        }

        return groupResultProtocolRepository;
    }

    public CsvContainer<TeamResultRecord> GenerateTeamResultProtocol(
        CsvContainerRepository<GroupResultRecord> groupResultRepository)
    {
        var scores = new Dictionary<string, int>();
        foreach (var group in groupResultRepository.GetCsvContainersNames())
        {
            var groupResultProtocol = groupResultRepository.GetCsvContainer(group);
            var bestResult = groupResultProtocol.Records.MinBy(r => r.RoundTime.TotalSeconds);
            if (bestResult == null) continue;
            foreach (var groupResult in groupResultProtocol.Records)
            {
                if (!scores.ContainsKey(groupResult.Team))
                    scores[groupResult.Team] = 0;
                scores[groupResult.Team] += _scoreCalculator.CalculateScore(groupResult, bestResult);
            }
        }

        var pairs = scores.OrderByDescending(v => v.Value);
        var teamResultProtocol = new CsvContainer<TeamResultRecord>("Result", pairs.Select((pair, i) =>
            new TeamResultRecord()
            {
                Name = pair.Key,
                Position = i + 1,
                Score = pair.Value,
            }).ToList());

        return teamResultProtocol;
    }
}