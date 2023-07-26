using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Materials
{
    public class Size
    {
        public float? Value { get; }
        public Size(float? value) 
        { 
            Value = value;
        }
    }
}
