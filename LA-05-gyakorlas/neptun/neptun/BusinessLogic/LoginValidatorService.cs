using System;
using System.Collections.Generic;
using System.Linq;
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
                // username <> password
                { "admin" , "admin123" },
                { "hero" , "hero" },
                { "root" , "toor" }
            };
        }

        public bool ValidateCredentials(string username, string password)
        {
            Dictionary<string, string> database = GetValidUsers();
            if (database.ContainsKey(username) && database.ContainsValue(password))
                return true;

            throw new Exception("[ERR] Invalid credentials, please try again.");
        }
    }
}
