using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Users.UserNames
{
    public class UserName
    {
        private FirstName _firstName;
        public FirstName FirstName { get => _firstName; }

        private LastName _lastName;
        public LastName LastName { get => _lastName; }
        public string Value
        {
            get => $"{_lastName.Value} {_firstName.Value}";
        }
        public int Length
        {
            get => _firstName.WordCount + _lastName.WordCount + 1;
        }

        public UserName(FirstName firstName, LastName lastName)
        {
            _firstName = firstName;
            _lastName = lastName;
        }
    }
}
