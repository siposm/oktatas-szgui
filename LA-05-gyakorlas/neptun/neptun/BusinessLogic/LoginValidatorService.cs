using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace neptun.BusinessLogic
{
    class LoginValidatorService
    {
        private Dictionary<string, string> GetValidUsers()
        {
            // ~ adatbázis lekérdezés

            return new Dictionary<string, string>()
            {
                // username <> password (sha256) >> never use plain text!
                { "admin" , "240be518fabd2724ddb6f04eeb1da5967448d7e831c08c8fa822809f74c720a9" },
                { "hero" , "ae6c79d10f1fd410650790e63186ec108fa106325b52fbd88de21a43540e6f2c" },
                { "root" , "ce5ca673d13b36118d54a7cf13aeb0ca012383bf771e713421b4d1fd841f539a" }
            };
            // online sha generator: https://emn178.github.io/online-tools/sha256.html
        }


        public bool ValidateCredentials(string username, string passwdHash)
        {
            Dictionary<string, string> database = GetValidUsers();
            if (database.ContainsKey(username) && database.ContainsValue(passwdHash))
                return true;

            throw new Exception("[ERR] Invalid credentials, please try again.");
        }

        public string GenerateHash(string input)
        {
            var z = SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(input)).Select(x => x.ToString("x2"));
            string hashedPasswd = string.Empty;
            foreach (var item in z)
                hashedPasswd += item;
            return hashedPasswd;
        }
    }
}
