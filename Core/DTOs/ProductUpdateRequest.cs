using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs
{
    public record ProductUpdateRequest(Guid Id,
        string ProductName,
        CategoryOptions Category,
        double? UnitPrice,
        int? QuantityInStock)
    {

        public ProductUpdateRequest() : this(default,default,default,default,default)
        {

        }
    }


}
