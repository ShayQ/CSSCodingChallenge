using CsvHelper.Configuration.Attributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Model
{
    public class Fund
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Name("fund_id")] // CSVHelper tag to map file headers to db columns
        public int Id { get; set; }
        [Name("fund_name")] // CSVHelper tag to map file headers to db columns
        public string? name { get; set; }
        [Name("fund_description")] // CSVHelper tag to map file headers to db columns
        public string? description { get; set; }
        public IEnumerable<FundValues>? FundValues { get; set; }

    }
}
