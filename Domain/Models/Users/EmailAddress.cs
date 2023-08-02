using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Domain.Models.Users
{
    public class EmailAddress
    {
        public string Value { get; }

        private const string PATTERN = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";

        public EmailAddress(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("メールアドレスの入力は必須です。");

            if (!Regex.IsMatch(value, PATTERN))
                throw new ArgumentException("メールアドレスは「xxxx@yyyy.zzz」の形式で入力してください。");

            this.Value = value;
        }

        public static EmailAddress FromPartsCreate(string principal, string domain)
        {
            if (string.IsNullOrWhiteSpace(principal))
                throw new Exception("メールアドレス作成エラー：プリンシパル名が入力されていません。");
            if (string.IsNullOrWhiteSpace(domain))
                throw new Exception("メールアドレス作成エラー：ドメイン名が入力されていません。");
            
            return new EmailAddress(
                string.Format("{0}@{1}", principal, domain));
        }

        public string GetPrincipal() => Value.Split('@')[0];

        public string GetDomain() => Value.Split('@')[1];
    }
}
