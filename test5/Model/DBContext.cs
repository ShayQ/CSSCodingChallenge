using Microsoft.EntityFrameworkCore;

namespace WebAPI.Model
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Fund>? Fund { get; set; }
        public virtual DbSet<FundValues>? FundValues { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FundValues>()
                .HasOne(f => f.Fund)
                .WithMany(v => v.FundValues)
                .HasForeignKey(f => f.fund_id);

            modelBuilder.Entity<FundValues>()
                .HasKey(v => new { v.fund_id, v.value_date });

            modelBuilder.Entity<Fund>().HasData(
                new Fund { Id = 1, name = "testName1", description = "testDescription1" },
                new Fund { Id = 2, name = "testName2", description = "testDescription2" });
            modelBuilder.Entity<FundValues>().HasData(
            new FundValues { fund_id = 1, value_date = new DateTime(2021, 06, 30), value = 630 },
            new FundValues { fund_id = 2, value_date = new DateTime(2021, 09, 30), value = 930 },
            new FundValues { fund_id = 2, value_date = new DateTime(2021, 12, 31), value = 1231 });

        }
    }
}
