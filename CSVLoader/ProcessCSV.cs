using System.Globalization;
using System.Text;
using WebAPI.Model;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.EntityFrameworkCore;

namespace CSVProcess
{
    public class ReadCSV
    {
        public static void ProcessCSVFile(string location)
        {
            var options = new DbContextOptionsBuilder<DBContext>()
                .Options;
            var databaseContext = new DBContext(options);
            // db is cleared before loading a file
            databaseContext.Database.EnsureDeleted();
            databaseContext.Database.EnsureCreated();
            string[] read;
            char[] seperators = { ',' };
            StreamReader sr = new StreamReader(location);
            string data = sr.ReadLine();
            databaseContext.ChangeTracker.AutoDetectChangesEnabled = false;
            // instead of checking db to see if its been stored, created a hashset to keep track of the id
            var processedId = new HashSet<Int32>();
            // using a counter to save to db after x rows of the file to save time
            int counter = 0;
            HashSet<Fund> fundSet = new HashSet<Fund>();
            HashSet<FundValues> fundValueSet = new HashSet<FundValues>();
            Console.WriteLine("Starting...");
            while ((data = sr.ReadLine()) != null)
            {
                read = data.Split(seperators, StringSplitOptions.None);
                if (Int32.TryParse(read[0], out int value) && DateTime.TryParse(read[3], out DateTime dateTime))
                {
                    int fundId = Int32.Parse(read[0]);
                    DateTime value_date = DateTime.Parse(read[3], CultureInfo.InvariantCulture);
                    decimal value_value = Decimal.Parse(read[4]);
                    if (processedId.Contains(fundId))
                    {
                        fundValueSet.Add(new FundValues { fund_id = fundId, value_date = value_date, value = value_value });
                        counter++;
                    }
                    else
                    {
                        fundSet.Add(new Fund { Id = fundId, name = read[1], description = read[2] });
                        fundValueSet.Add(new FundValues { fund_id = fundId, value_date = value_date, value = value_value });
                        Console.WriteLine("Adding new Id [{0}]", fundId);
                        processedId.Add(fundId);
                        counter++;
                    }
                }
                if (counter >= 50000)
                {
                    databaseContext.AddRange(fundSet);
                    databaseContext.AddRange(fundValueSet);
                    // hashsets are cleared after the data they have is added to db
                    fundSet.Clear();
                    fundValueSet.Clear();
                    databaseContext.SaveChanges();
                    //Console.WriteLine("counter reset");
                    counter = 0;
                }
            }
            // once file is processed, it will save whatever is in fundSet and fundValueSet if counter didnt hit X
            databaseContext.AddRange(fundSet);
            databaseContext.AddRange(fundValueSet);
            databaseContext.SaveChanges();
            databaseContext.ChangeTracker.AutoDetectChangesEnabled = true;
        }
    }
}
