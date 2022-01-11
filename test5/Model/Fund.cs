using System.ComponentModel.DataAnnotations;

namespace CSSCodingChallenge.Model
{
    public class Fund
    {
        [Key]
        public int Id { get; set; }
        public string? name { get; set; }
        public string? description { get; set; }
        public IEnumerable<FundValues>? FundValues { get; set; }

    }
}
