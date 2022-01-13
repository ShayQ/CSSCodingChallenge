using System.Linq;
using Microsoft.EntityFrameworkCore;
using Xunit;
using WebAPI.Controllers;
using WebAPI.Model;
using System;

namespace WebAPITest
{
    public class FundControllerTest
    {
        public DbContextOptions<DBContext> ContextOptions { get; }
        //public FundControllerTest(DbContextOptions<DBContext> contextOptions)
        //{
        //    //ContextOptions = contextOptions;
        //    ContextOptions = new DbContextOptionsBuilder<DBContext>()
        //      .UseInMemoryDatabase(databaseName: "Test")
        //      .Options;
        //    Seed();
        //}

        //private void Seed()
        //{
        //    using (var _context = new DBContext(ContextOptions)) 
        //    {
        //        _context.Database.EnsureDeleted();
        //        _context.Database.EnsureCreated();

        //        var fund1 = new Fund { Id = 1, name = "fund_1_value", description = "fund_1_value" };
        //        var fund2 = new Fund { Id = 2, name = "fund_2_values", description = "fund_2_values" };
        //        var fund3 = new Fund { Id = 3, name = "fund_no_values", description = "fund_no_values" };

        //        var fundValues1 = new FundValues { fund_id = 1, value_date = new DateTime(2021, 06, 30), value = 630 };
        //        var fundValues2 = new FundValues { fund_id = 2, value_date = new DateTime(2021, 09, 30), value = 930 };
        //        var fundValues3 = new FundValues { fund_id = 2, value_date = new DateTime(2021, 12, 31), value = 1231 };

        //        _context.AddRange(fund1, fund2, fund3, fundValues1, fundValues2, fundValues3);
        //        _context.SaveChanges();
        //    }
        //}

        //[Fact]
        //public void Can_get_funds()
        //{
        //    using (var _context = new DBContext(ContextOptions))
        //    {
        //        var controller = new FundsController(_context);

        //        var items = controller.GetFunds().ToList();

        //        //Console.WriteLine(items);
        //        //Console.WriteLine("count: " + items.Count());
        //        Assert.Equal(2, items.Count());
        //        //Assert.Equal("fund_1_value", items.Find(f => f.name == "fund_1_value"));
        //        //Assert.Equal("fund_1_value", items.Where(x => x.name == "fund_1_value").Select(i => i.name);
        //        //Assert.Equal("ItemThree", items[1].Name);
        //        //Assert.Equal("ItemTwo", items[2].Name);
        //    }
        //}
        //[Fact]
        //public void PassingTest()
        //{
        //    Assert.Equal(4, 4);
        //}

        //[Fact]
        //public void Can_get_fund_history()
        //{
        //    using (var _context = new DBContext(ContextOptions))
        //    {
        //        var controller = new FundsController(_context);

        //        var item = controller.GetFundHistory("ItemTwo");

        //        Assert.Equal("ItemTwo", item.Name);
        //    }
        //}
    }
}