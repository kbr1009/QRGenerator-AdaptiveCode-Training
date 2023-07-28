using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Users.UserNames
{
    public class UserName
    {
        private string _firstName;
        public string FirstName { get => _firstName; }

        private string _lastName;
        public string LastName { get => _lastName; }
        public string Value
        {
            get => $"{_lastName} {_firstName}";
        }
        public int Length
        {
            get => _firstName.Length + _lastName.Length + 1;
        }

        public UserName(string firstName, string lastName)
        {
            _firstName = firstName;
            _lastName = lastName;
        }

        public UserName(string userName)
        {
            var lastAndFirstName = userName.Split(' ');
            _firstName = lastAndFirstName[1];
            _lastName = lastAndFirstName[0];
        }
    }
}
