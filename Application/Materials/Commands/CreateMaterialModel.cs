using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Materials.Commands
{
    public class CreateMaterialModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int MaterialTypeId { get; set; }
        public string ProductType { get; set; }
        public float? Size { get; set; }
        public float? Consumption { get; set; }
        public float? Length { get; set; }
        public float? Weight { get; set; }
    }
}
