using Infrastructure.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.InMemoryDatabase
{
    public class AppContext
    {
        public List<USER> Users = InMemoryDB.UserTable;
    }
}
