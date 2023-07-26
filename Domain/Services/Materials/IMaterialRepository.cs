using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models.Materials;

namespace Domain.Services.Materials
{
    public interface IMaterialRepository
    {
        Material Find(string id);
        IEnumerable<Material> Find(int id);
        Material Save(Material material);
    }
}
