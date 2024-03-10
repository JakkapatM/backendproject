using System.ComponentModel.DataAnnotations;

namespace test.Models
{
    public class Dbtask
    {
        [Key]
        public int task_id { get; set; }
        public int? vehicle_id { get; set; }
        public DateTime? date { get; set; }
        public int? price { get; set; }
        public int? employee_id { get; set; }
        public string? Detail { get; set; }
        public DateTime? appointment { get; set; }
        public int? task_amount { get; set; }
        public string? status { get; set; }
    }
}
