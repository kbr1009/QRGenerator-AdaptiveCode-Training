using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Domain.Models.Shared;

namespace Domain.Models.Materials
{
    public class TypeAndSize
    {
        public ProductType Type { get; }
        public Size Size { get; }
        public TypeAndSize(ProductType productType, Size size) 
        { 
            this.Type = productType;
            this.Size = size;
        }
    }
}
