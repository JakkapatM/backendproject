﻿using System.ComponentModel.DataAnnotations;

namespace test.Models
{
    public class Spare_part
    {
        [Key]
        public int spare_id { get; set; }
        public string? spare_name { get; set; }
        public int? spare_price { get; set; }
        public int? quantity { get; set; }
        public int? sparetype_id { get; set; }
    }
}
