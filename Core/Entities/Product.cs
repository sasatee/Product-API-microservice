﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Product
    {

        public Guid Id { get; set; }

        public string ProductName { get; set; } = string.Empty;

        public string  Category { get; set; } = string.Empty;

        public double? UnitPrice { get; set; }

        public int? QuantityInStock { get; set; }
        


    }
}
