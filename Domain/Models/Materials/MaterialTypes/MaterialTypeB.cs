using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Materials.MaterialTypes
{
    public class MaterialTypeB : MaterialType
    {
        public MaterialTypeB() : base(1, "部材B") { }
        public override bool ValidateConsumption(Consumption consumption)
        {
            return true;
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
            bool validateOk = typesize.Size.Value != null && typesize.Type.Value != null;
            return validateOk;
        }

        public override bool ValidateWeight(Weight weight)
        {
            return weight.Value != null;
        }
    }
}
