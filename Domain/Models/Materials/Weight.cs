using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models.Shared;

namespace Domain.Models.Materials
{
    public class Weight
    {
        public float? Value { get; }
        public Weight(float? value)
        {
            Value = value;
        }
    }
}
