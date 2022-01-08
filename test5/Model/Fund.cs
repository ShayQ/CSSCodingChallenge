using System.ComponentModel.DataAnnotations;

namespace test5.Model
{
    public class Fund
    {
        [Key]
        public int Id { get; set; }
        public string? name { get; set; }
        public string? description { get; set; }
        public List<FundValues>? FundValues { get; set; }

    }
}
