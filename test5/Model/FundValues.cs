using CsvHelper.Configuration.Attributes;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Model
{
    public class FundValues
    {
        [Key]
        [Name("fund_id")] 
        public int fund_id { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        public Fund? Fund { get; set; }

        [DataType(DataType.Date)]
        [Name("value_date")] 
        public DateTime value_date { get; set; }
        [Name("value_value")]
        public decimal value { get; set; }

    }
}
