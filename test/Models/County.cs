using System.ComponentModel.DataAnnotations;

namespace test.Models
{
    public class County
    {
        [Key]
        public string county_name { get; set; }
    }
}
