using neptun.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace neptun.BusinessLogic
{
    class DataLoadingService
    {
        public string GenerateID()
        {
            string x = string.Empty;
            Random r = new Random();

            for (int i = 0; i < 3; i++)
                x += (char)r.Next('A', 'Z');

            for (int i = 0; i < 3; i++)
                x += r.Next(0, 10).ToString();

            return x;
        }

        public List<Profile> FetchData()
        {
            string url = "http://users.nik.uni-obuda.hu/siposm/db/students_v2.json";
            WebClient wc = new WebClient();
            string x = wc.DownloadString(url);
            return JsonConvert.DeserializeObject<List<Profile>>(x);
        }
    }
}
