using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace studentBook_v2
{
    public class MainWindowViewModel // without mvvmlight !
    {
        public ObservableCollection<Student> Students { get; set; }
        public Student SelectedStudent { get; set; }

        public MainWindowViewModel()
        {
            Students = new ObservableCollection<Student>();
            LoadStudentsFromJson();
        }

        private void LoadStudentsFromJson()
        {
            string url = "http://users.nik.uni-obuda.hu/siposm/db/students.json";

            WebClient wc = new WebClient();
            string jsonContent = wc.DownloadString(url);
            JsonConvert.DeserializeObject<List<Student>>(jsonContent).ForEach(x =>
            {
                Students.Add(x);
            });
        }

        public void AddClick()
        {
            // új student binding ablak létrehozása
        }

        public void ModClick()
        {
            // szintén...
        }

        public void DelClick()
        {
            Students.Remove(SelectedStudent);
        }

        public void PurClick()
        {
            Students.Clear();
        }
    }
}
