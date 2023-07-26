using Domain.Models.Materials.MaterialTypes;
using Domain.Models.Materials;
using Domain.Services.Materials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Application.Materials.Commands
{
    public class MaterialCreateCommand : IMaterialCreateCommand
    {
        private readonly IMaterialRepository _repository;
        public MaterialCreateCommand(IMaterialRepository materialRepository)
        { 
            _repository = materialRepository;
        }

        public void Execute(CreateMaterialModel createMaterialModel)
        {
            var id = new MaterialId(createMaterialModel.Id);
            var name = new MaterialName(createMaterialModel.Name);
            var type = MaterialType.GetMaterialType(createMaterialModel.MaterialTypeId);
            var productType = new ProductType(createMaterialModel.ProductType);
            var size = new Size(createMaterialModel.Size);
            var typeAndSize = new TypeAndSize(productType, size);
            var consumption = new Consumption(createMaterialModel.Consumption);
            var length = new Length(createMaterialModel.Length);
            var weight = new Weight(createMaterialModel.Weight);

            // 値個別のバリデーションは、エンティティを生成する時に行う
            var target = new Material(id, name, type, typeAndSize, consumption, length, weight);

            var service = new MaterialService(_repository);

            if (service.IsDuplicatedId(target.Id))
            {
                throw new Exception("IDが重複しています");
            }

            if (type.Id == MaterialType.A.Id && service.IsOverAddedMaterialA())
            {
                throw new Exception("部材区分Aが2件登録されています");
            }

            if (type.Id == MaterialType.B.Id && service.IsOverAddedTypeAndSize(typeAndSize))
            {
                throw new Exception($"{productType}と{size}の組み合わせは2件登録されています");
            }
            _repository.Save(target);
        }
    }
}
