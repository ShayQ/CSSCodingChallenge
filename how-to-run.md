# Initial Create #
To create the initial database and set up tables you need to add a migration
* Add-Migration "InitialCreate"
* Update-Database

# Populate DB #
To seed the database, place a csv file called 'funds.csv' in CSVProcess.SeedData and run CSVProcess project
* headers should be [fund_id,fund_name,fund_description,value_date,value_value] 
* comma delimited
* value_date must be in yyyy-MM-dd format
* loads 10 funds of 100k rows in 30seconds

# API #
Database is created with EF Core using Code First approach.
FundController has two methods
* GetFunds()
    * This will return every fund and the latest value for that fund. If no value exists then it will not display that fund
* GetFundHistory(id)
    * This will return a history of the chosen fund. If no value exists then it will not display that fund

# Unit Tests #
A new DBContext is created before each test and the seed data is inserted fresh each time. Its done using InMemoryDB to make it quicker.
GetFundsTest_2FundsReturned()
* This test will ensure that when a fund doesnt have fundvalues data then it wont appear in GetFunds() result
GetFundsTest_LatestDataReturned()
* This will ensure that GetFunds() will always display the latest value that this fund has
GetFundsHistoryTest_FullHistoryReturned()
* This will ensure that a full history is returned when there is more than 1 value