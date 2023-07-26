using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Materials
{
    public class MaterialId
    {
        public string Id { get; }
        public MaterialId(string materialId)
        {
            Id = materialId;
        }
    }
}
