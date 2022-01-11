using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSSCodingChallenge.Model
{
    public class FundValues
    {
        [Key]
        public int fund_id { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        public Fund? Fund { get; set; }

        [DataType(DataType.Date)]
        public DateTime value_date { get; set; }
        public decimal value { get; set; }

    }
}
