using Domain.Models.Materials;
using Domain.Models.Materials.MaterialTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Materials
{
    public class MaterialService
    {
        private readonly IMaterialRepository _repository;

        public MaterialService(IMaterialRepository repository)
        {
            this._repository = repository;
        }

        public bool IsDuplicatedId(MaterialId id)
        {
            Material material = _repository.Find(id.Id);

            return material != null;
        }

        public bool IsOverAddedMaterialA()
        {
            var materials = _repository.Find(MaterialType.A.Id);

            return materials.Count() >= 2;
        }

        public bool IsOverAddedTypeAndSize(TypeAndSize typeAndWidth)
        {
            var materials = _repository.Find(MaterialType.B.Id);

            var count = materials.Count(x => x.TypeAndSize.Equals(typeAndWidth));

            return count >= 2;
        }
    }
}
