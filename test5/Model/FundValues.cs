using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace test5.Model
{
    public class FundValues
    {
        [Key]
        //[ForeignKey("Fund")]
        public int fund_id { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        public Fund? Fund { get; set; }

        [DataType(DataType.Date)]
        public DateTime value_date { get; set; }
        public decimal value { get; set; }
        //public virtual Fund Fund { get; set; }

    }
}
