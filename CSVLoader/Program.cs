
string fileName = "funds.csv";
string SeedFolderPath = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"..\..\..\SeedData\"));
string SeedDataPath = Path.Combine(SeedFolderPath, fileName);
CSVProcess.ReadCSV.ProcessCSVFile(SeedDataPath);
