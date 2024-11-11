
using Payment.Model;
using Payment.Interface;
using Payment.Model.TransactionModel;
using Application;
using Newtonsoft.Json;

public class LogJsonService : IDatabaseJsonService
{
    private const string FilePathData = "Database/Transactions.json";
    public List<Transaction> ListTransaction { get; private set; }
    public LogJsonService()
    {
        ListTransaction = ReadJsonDesirialize();

    }
    public List<Transaction> ReadJsonDesirialize()
    {
        List<Transaction> items = new List<Transaction>();
        string json = this.ReadJsonStringData();
        if (string.IsNullOrEmpty(json))
        {
            return items;
        }
        items = JsonConvert.DeserializeObject<List<Transaction>>(json);
        return items;
    }

    public void LogTransaction()
    {
        foreach (Transaction transaction in ListTransaction)
        {
            transaction.XuatThongTin();
        }
    }

    public bool WriteJson(List<Transaction> data)
    {
        ListTransaction.AddRange(data);
        string currentDir = Environment.CurrentDirectory;
        DirectoryInfo directory = new DirectoryInfo(currentDir);
        string pathCombine = Path.Combine(currentDir, FilePathData);

        try
        {
            string json = JsonConvert.SerializeObject(ListTransaction);
            File.WriteAllText(pathCombine, json);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            return false;
        }
        return true;

    }

    public string ReadJsonStringData()
    {
        string currentDir = Environment.CurrentDirectory;
        DirectoryInfo directory = new DirectoryInfo(currentDir);
        string pathCombine = Path.Combine(currentDir, FilePathData);

        StreamReader r = new StreamReader(pathCombine);
        string json = r.ReadToEnd();
        r.Dispose();
        return json;

    }
}