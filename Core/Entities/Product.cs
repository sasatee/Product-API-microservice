using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Product
    {
        [Key]
        public Guid ProductId { get; set; }

        public string ProductName { get; set; } = string.Empty;

        public string  Category { get; set; } = string.Empty;

        public double? UnitPrice { get; set; }

        public int? QuantityInStock { get; set; }

        public static explicit operator List<object>(Product? v)
        {
            throw new NotImplementedException();
        }
    }
}
