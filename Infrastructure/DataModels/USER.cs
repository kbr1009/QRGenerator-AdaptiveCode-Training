using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DataModels
{
    public class USER
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string EmailAddress { get; set; }
        public int Gender { get; set; }
        public bool IsDeleted { get; set; }
    }
}
