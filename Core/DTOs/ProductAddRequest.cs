using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs
{
    public record ProductAddRequest(Guid id,
        string ProductName,
        string category,
        double? UnitPrice,
        int? QuantityOfStock);

          
}
