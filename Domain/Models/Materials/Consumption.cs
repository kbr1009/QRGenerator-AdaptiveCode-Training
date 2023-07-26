using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models.Shared;

namespace Domain.Models.Materials
{
    public class Consumption
    {
        public float? Value { get; }
        public Consumption(float? value)
        {
            Value = value;
        }
    }
}
