using CsvHelper.Configuration.Attributes;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Model
{
    public class Fund
    {
        [Key]
        [Name("fund_id")]
        public int Id { get; set; }
        [Name("fund_name")] 
        public string? name { get; set; }
        [Name("fund_description")] 
        public string? description { get; set; }
        public IEnumerable<FundValues>? FundValues { get; set; }

    }
}
