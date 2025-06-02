using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs
{
    public record ProductAddRequest(Guid Id,
        string ProductName,
        string Category,
        double? UnitPrice,
        int? QuantityInStock)
    {
        public ProductAddRequest() : this(default,default,default,default,default)
        {
            
        }
    }

          
}
