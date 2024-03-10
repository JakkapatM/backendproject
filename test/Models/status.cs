using System.ComponentModel.DataAnnotations;

namespace test.Models
{
    public class Status
    {
        internal string status_phase;

        [Key]
        public string county_name { get; set; }
    }
}