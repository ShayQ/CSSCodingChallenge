using CsvHelper.Configuration.Attributes;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Model
{
    public class FundValues
    {
        [Key]
        [Name("fund_id")] // CSVHelper tag to map file headers to db columns
        public int fund_id { get; set; }
        [System.Text.Json.Serialization.JsonIgnore] // this is to ignore 'Fund' field of this table from the api call
        public Fund? Fund { get; set; }

        [DataType(DataType.Date)]
        [Name("value_date")] // CSVHelper tag to map file headers to db columns
        public DateTime value_date { get; set; }
        [Name("value_value")] // CSVHelper tag to map file headers to db columns
        public decimal value { get; set; }

    }
}
