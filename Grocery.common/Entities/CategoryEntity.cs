﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grocery.common.Entities
{
    public class CategoryEntity
    {
        [Key]
        public int categopry_id { get; set; }
        public string? category_name { get; set; }
    }
}
