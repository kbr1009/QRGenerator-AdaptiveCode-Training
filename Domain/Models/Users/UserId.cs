using Domain.Models.Users.Sheard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Users
{
    public class UserId : ValueObject
    {
        public UserId(string val) : base(val) { }
        public static UserId Generate()
        {
            return new UserId(Guid.NewGuid().ToString("N"));
        }
    }
}
