﻿using System.ComponentModel.DataAnnotations;

namespace test.Models
{
    public class Spare_type
    {
        [Key]
        public int sparetype_id { get; set; }
        public string? sparetype_name { get; set; }
    }
}
