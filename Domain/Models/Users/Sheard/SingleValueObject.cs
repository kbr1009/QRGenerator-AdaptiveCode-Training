using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Users.Sheard
{
    public abstract class ValueObject
    {
        public string Value { get; }

        public int WordCount
        {
            get => Value.Length;
        }

        protected ValueObject(string value)
        {
            Value = value ?? throw new ArgumentNullException(nameof(value), "値を設定してください。");
        }
    }
}
