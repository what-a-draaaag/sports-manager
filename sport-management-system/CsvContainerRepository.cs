namespace sport_management_system;

public class CsvContainerRepository<T>
{
    public static CsvContainerRepository<T> LoadFromFileList(List<string> files)
    {
        var containers = new Dictionary<string, CsvContainer<T>>();
        foreach (var filename in files)
        {
            var container = CsvContainer<T>.LoadFromFile(filename);
            containers[container.Identifier] = container;
        }

        return new CsvContainerRepository<T>(containers);
    }

    public static CsvContainerRepository<T> LoadFromFolder(string folderpath)
    {
        return LoadFromFileList(Directory.GetFiles(folderpath).ToList());
    }

    private Dictionary<string, CsvContainer<T>> CsvContainers { get; }

    public CsvContainerRepository() : this(new Dictionary<string, CsvContainer<T>>())
    {
    }

    public CsvContainerRepository(Dictionary<string, CsvContainer<T>> csvContainers)
    {
        CsvContainers = csvContainers;
    }

    public List<string> GetCsvContainersNames()
    {
        return CsvContainers.Keys.ToList();
    }

    public CsvContainer<T> GetCsvContainer(string key)
    {
        if (!CsvContainers.ContainsKey(key))
            CsvContainers[key] = new CsvContainer<T>(key);
        return CsvContainers[key];
    }

    public void SaveToFolder(string folderpath)
    {
        foreach (var (name, container) in CsvContainers)
        {
            container.SaveToFile(Path.Join(folderpath, $"{name}.csv"));
        }
    }
}