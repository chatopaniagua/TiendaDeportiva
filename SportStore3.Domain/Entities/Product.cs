﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore3.Domain.Entities
{
    public class Product
    {
        public string Name { get; set; }
        public int ProductID { get; set; }
        public string Description { get; set;}
        public string Category { get; set; }
        public decimal Price { get; set; }
    }
}
