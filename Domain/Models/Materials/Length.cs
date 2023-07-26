using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models.Shared;

namespace Domain.Models.Materials
{
    public class Length
    {
        public float? Value { get; }
        public Length(float? value)
        {
            Value = value;
        }
    }
}
