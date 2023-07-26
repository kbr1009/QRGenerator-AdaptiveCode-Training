using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models.Users.Sheard;

namespace Domain.Models.Users.UserNames
{
    public class FirstName : ValueObject
    {
        public FirstName(string val) : base(val) { }
    }
}
