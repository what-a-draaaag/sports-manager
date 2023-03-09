using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using sport_management_system.Entities;

namespace sport_management_system;

public class CsvContainer<T>
{
    public static CsvContainer<T> LoadFromFile(string filename)
    {
        var config = new CsvConfiguration(CultureInfo.InvariantCulture) { HasHeaderRecord = false };
        using var reader = new StreamReader(filename);
        using var csv = new CsvReader(reader, config);

        var name = Path.GetFileNameWithoutExtension(filename);
        var records = csv.GetRecords<T>().ToList();
        return new CsvContainer<T>(name, records);
    }

    public string Identifier { get; }
    public List<T> Records { get; }

    public CsvContainer(string identifier) : this(identifier, new List<T>())
    {
    }

    public CsvContainer(string identifier, List<T> records)
    {
        Identifier = identifier;
        Records = records;
    }

    public void SaveToFile(string filename)
    {
        var config = new CsvConfiguration(CultureInfo.InvariantCulture) { HasHeaderRecord = false };
        using var writer = new StreamWriter(filename);
        using var csv = new CsvWriter(writer, config);
        csv.WriteRecords(Records);
    }
}