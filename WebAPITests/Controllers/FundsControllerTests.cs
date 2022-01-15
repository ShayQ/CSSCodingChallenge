using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebAPI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Controllers.Tests
{
    [TestClass()]
    public class FundsControllerTests
    {
        // create test db and populate it
        private async Task<DBContext> GetDatabaseContext()
        {
            var options = new DbContextOptionsBuilder<DBContext>()
                //.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=CSSCodingChallengeTesting;Trusted_Connection=True;MultipleActiveResultSets=true")
                .UseInMemoryDatabase(databaseName: "Test")
                .Options;
            var databaseContext = new DBContext(options);
            databaseContext.Database.EnsureDeleted();
            databaseContext.Database.EnsureCreated();

            // create fund data to load for testing
            var fund1 = new Fund { name = "fund_1_value", description = "fund_1_value" };
            var fund2 = new Fund { name = "fund_2_values", description = "fund_2_values" };
            var fund3 = new Fund { name = "fund_no_values", description = "fund_no_values" };

            // save changes so can get fund1.id etc
            databaseContext.AddRange(fund1, fund2, fund3);
            await databaseContext.SaveChangesAsync();

            // create fund values data to load for testing
            var fundValues1 = new FundValues { fund_id = fund1.Id, value_date = new DateTime(2021, 06, 30), value = 630 };
            var fundValues2 = new FundValues { fund_id = fund2.Id, value_date = new DateTime(2021, 09, 30), value = 930 };
            var fundValues3 = new FundValues { fund_id = fund2.Id, value_date = new DateTime(2021, 12, 31), value = 1231 };

            // store seed data to db and save changes
            databaseContext.AddRange(fundValues1, fundValues2, fundValues3);
            await databaseContext.SaveChangesAsync();
            return databaseContext;
        }

        // test that only 2 funds are returned with GetFunds() (fund without fundValue data is ignored)
        [TestMethod()]
        public async Task GetFundsTest_2FundsReturned()
        {
            // in GetDatabaseContext() fund2 was created with 2 fundValues entities. This test verifies that only 1 is returned
            var dbContext = await GetDatabaseContext();
            var fundController = new FundsController(dbContext);
            var items = fundController.GetFunds().ToList();

            Assert.AreEqual(2, items.Count());
        }

        //// test that the latest fund value is returned for GetFunds()
        [TestMethod()]
        public async Task GetFundsTest_LatestDataReturned()
        {
            var dbContext = await GetDatabaseContext();
            var fundController = new FundsController(dbContext);
            var fund = fundController.GetFunds()
                .Where(f => f.name == "fund_2_values")
                .Select(f => f.Id);
            var items = fundController.GetFundHistory(fund.FirstOrDefault());
            var maxDate = items
                .Select(f => f.FundValues.Max(v => v.value_date));
            Assert.AreEqual(new DateTime(2021, 12, 31).Date, maxDate.FirstOrDefault().Date);
        }

        // test that GetFundHistory() will return more than 1 fundValue
        [TestMethod()]
        public async Task GetFundsHistoryTest_FullHistoryReturned()
        {
            // in GetDatabaseContext() fund2 was created with 2 fundValues entities. This test verifies that both are returned with GetFundHistory()
            var dbContext = await GetDatabaseContext();
            var fundController = new FundsController(dbContext);
            var fund = fundController.GetFunds()
                .Where(f => f.name == "fund_2_values")
                .Select(f => f.Id);
            //Console.WriteLine("fund [{0}]", fund.FirstOrDefault());
            var items = fundController.GetFundHistory(fund.FirstOrDefault());

            Assert.AreEqual(2, items.FirstOrDefault().FundValues.Count());
        }
    }
}