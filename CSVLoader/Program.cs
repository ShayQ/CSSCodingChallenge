using CsvHelper;
using CsvHelper.Configuration;
//using LumenWorks.Framework.IO.Csv;
using System.Data;
using System.Globalization;
using WebAPI.Model;

string fileName = "funds.csv";
string SeedFolderPath = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"..\..\..\SeedData\"));
string SeedDataPath = Path.Combine(SeedFolderPath, fileName);
CSVProcess.ReadCSV.ProcessCSVFile(SeedDataPath);
//CSVProcess.ReadCSV.GetDatabaseContext();

//void Main()
//{

//    string fileName = "funds.csv";
//    string SeedFolderPath = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"..\..\..\SeedData\"));
//    string SeedDataPath = Path.Combine(SeedFolderPath, fileName);
//    Console.WriteLine("test1");
//    var config = new CsvConfiguration(CultureInfo.InvariantCulture)
//    {
//        Delimiter = "|"
//    };
//    using (var reader = new StreamReader(SeedDataPath))
//    using (var csv = new CsvReader(reader, config))
//    {
//        //csv.

//        //var fundRecords = csv.GetRecords<Fund>();
//        //var valueRecords = csv.GetRecords<FundValues>();
//        //foreach (var fund in fundRecords)
//        //{
//        //    //Console.WriteLine("record [{0}]", record.Id);
//        //    Console.WriteLine("Id: [{0}] | name [{1}]", fund.Id, fund.name);
//        //}
//        //foreach (var value in valueRecords)
//        //{
//        //    //Console.WriteLine("record [{0}]", record.Id);
//        //    Console.WriteLine("fund_id: [{0}] | value_date [{1}]", value.fund_id, value.value_date);
//        //}
//    }
//}

//Main();

// fund_id | fund_name | fund_description | value_date | value_value

//string fileName = "funds.csv";
//string SeedFolderPath = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"..\..\..\SeedData\"));
//string SeedDataPath = Path.Combine(SeedFolderPath, fileName);
//var config = new CsvConfiguration(CultureInfo.InvariantCulture)
//{
//    Delimiter = "|"
//};
////DataTable datatable = new DataTable();
////StreamReader streamreader = new StreamReader(SeedDataPath);
////char[] delimiter = new char[] { '|' };
////string[] columnheaders = streamreader.ReadLine().Split(delimiter);
////foreach (string columnheader in columnheaders)
////{
////    datatable.Columns.Add(columnheader); // I've added the column headers here.
////    Console.WriteLine("columnheader [{0}]", columnheader);
////}

////while (streamreader.Peek() > 0)
////{
////    DataRow datarow = datatable.NewRow();
////    datarow.ItemArray = streamreader.ReadLine().Split(delimiter);
////    datatable.Rows.Add(datarow);
////}

////foreach (DataRow row in datatable.Rows)
////{
////    Console.WriteLine("----Row No: " + datatable.Rows.IndexOf(row) + "----");

////    foreach (DataColumn column in datatable.Columns)
////    {

////    }
////}
////Console.ReadLine();

//using (var reader = new StreamReader(SeedDataPath))
//using (var csv = new LumenWorks.Framework.IO.Csv.CsvReader(reader, config))
//{
//    while (csv.ReadNextRecord())
//    {
//        //listA.Add(new Tuple<string, string, string>(csv[0], csv[1], csv[11]));
//    }
//}