using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Materials.MaterialTypes
{
    public class MaterialTypeA : MaterialType
    {
        public MaterialTypeA() : base(0, "部材A") { }

        public override bool ValidateConsumption(Consumption consumption)
        {
            return consumption.Value != null;
        }

        public override bool ValidateLength(Length length)
        {
            return length.Value != null;
        }

        public override bool ValidateName(MaterialName name)
        {
            return name.Value != null;
        }

        public override bool ValidateTypeAndSize(TypeAndSize typesize)
        {
            return true;
        }

        public override bool ValidateWeight(Weight weight)
        {
            return weight.Value != null;
        }
    }
}
