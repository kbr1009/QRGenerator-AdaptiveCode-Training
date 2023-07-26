using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Materials.MaterialTypes
{
    public abstract class MaterialType : Enumeration
    {
        public static MaterialType A = new MaterialTypeA();
        public static MaterialType B = new MaterialTypeB();

        protected MaterialType(int id, string name) : base(id, name) { }

        public abstract bool ValidateConsumption(Consumption consumption);
        public abstract bool ValidateLength(Length length);
        public abstract bool ValidateName(MaterialName name);
        public abstract bool ValidateTypeAndSize(TypeAndSize typesize);
        public abstract bool ValidateWeight(Weight weight);

        public static MaterialType GetMaterialType(int id)
        {
            var materialTypes = GetAll<MaterialType>().Cast<MaterialType>();

            return materialTypes.FirstOrDefault(x => x.Id == id);
        }
    }
}
