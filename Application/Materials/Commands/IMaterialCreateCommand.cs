using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Materials.Commands
{
    public interface IMaterialCreateCommand
    {
        void Execute(CreateMaterialModel createMaterialModel);
    }
}
