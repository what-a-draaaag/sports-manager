using NUnit.Framework;

namespace sport_management_system;

[TestFixture]
public class ProgramTests
{
    public string MakeInPath(string s) => Path.Join("../../../TestData/In", s);
    public string MakeOutPath(string s) => Path.Join("../../../TestData/Out", s);

    [Test]
    public void TestGenerateStart()
    {
        Console.WriteLine(MakeInPath("Test"));
        Program.Main(new[] { "generate-start", MakeInPath("Applications"), MakeOutPath("StartProtocol") });
        Assert.That(File.Exists(MakeOutPath("StartProtocol/М10.csv")));
        Assert.AreEqual(File.ReadAllText(MakeOutPath("StartProtocol/М10.csv")),
            File.ReadAllText(MakeInPath("StartProtocol/М10.csv")));
        Assert.That(File.Exists(MakeOutPath("StartProtocol/М21.csv")));
        Assert.AreEqual(File.ReadAllText(MakeOutPath("StartProtocol/М21.csv")),
            File.ReadAllText(MakeInPath("StartProtocol/М21.csv")));
        Assert.That(File.Exists(MakeOutPath("StartProtocol/М40.csv")));
        Assert.AreEqual(File.ReadAllText(MakeOutPath("StartProtocol/М40.csv")),
            File.ReadAllText(MakeInPath("StartProtocol/М40.csv")));
    }

    [Test]
    public void TestGenerateGroupResult()
    {
        Program.Main(new[] {
        
            "generate-group-result", MakeInPath("StartProtocol"), MakeInPath("ControlPoint"), MakeOutPath("GroupResult")
        });
        Assert.That(File.Exists(MakeOutPath("GroupResult/М10.csv")));
        Assert.AreEqual(File.ReadAllText(MakeOutPath("GroupResult/М10.csv")),
            File.ReadAllText(MakeInPath("GroupResult/М10.csv")));
        Assert.That(File.Exists(MakeOutPath("GroupResult/М21.csv")));
        Assert.AreEqual(File.ReadAllText(MakeOutPath("GroupResult/М21.csv")),
            File.ReadAllText(MakeInPath("GroupResult/М21.csv")));
        Assert.That(File.Exists(MakeOutPath("GroupResult/М40.csv")));
        Assert.AreEqual(File.ReadAllText(MakeOutPath("GroupResult/М40.csv")),
            File.ReadAllText(MakeInPath("GroupResult/М40.csv")));
    }

    [Test]
    public void TestTeamResult()
    {
        Program.Main(new[] { "generate-team-result", MakeInPath("GroupResult"), MakeOutPath("Result.csv") });
        Assert.That(File.Exists(MakeOutPath("Result.csv")));
        Assert.AreEqual(File.ReadAllText(MakeOutPath("Result.csv")),
            File.ReadAllText(MakeInPath("Result.csv")));
    }
}