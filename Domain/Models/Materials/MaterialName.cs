using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Domain.Models.Shared;

namespace Domain.Models.Materials
{
    public class MaterialName : SingleValueObject<string>
    {
        public MaterialName(string value) : base(value) { }
    }
}
