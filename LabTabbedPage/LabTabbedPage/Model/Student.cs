using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

using System.Net.Http;
using Newtonsoft.Json;

namespace LabTabbedPage.Model
{
    public class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public ObservableCollection<Homework> LstHomeworks { get; set; }
        public string Picture { get; set; }
        public int Grade { get; set; }

        public static async Task<ObservableCollection<Student>> getAllStudents() {


            ObservableCollection<Student> lstStudent = new ObservableCollection<Student>();
            using(HttpClient client = new HttpClient())
            {
                var uri = new Uri("http://50cf4af0.ngrok.io/Student/getAllStudents");
                var json = JsonConvert.SerializeObject(new { ID=1});
                var content = new StringContent(json, Encoding.UTF8,"application/json");

                HttpResponseMessage responseMessage = await client.PostAsync(uri, content).ConfigureAwait(false);

                string ans = await responseMessage.Content.ReadAsStringAsync();
                lstStudent = JsonConvert.DeserializeObject<ObservableCollection<Student>>(ans);

                return lstStudent;
            }

        }
        public static async Task<ObservableCollection<Student>> GetStudents()
        {
            ObservableCollection<Student> lstStudents;
            lstStudents = new ObservableCollection<Student>() {
                new Student(){ID=123, Name="Diego", Grade=0, Picture="http://image.ibb.co/iHDecn/if_matureman2_628283_Cream.png" },
                new Student(){ID=456, Name="Juan", Grade=0,  Picture="http://image.ibb.co/hACBq7/if_male3_403019.png"},
                new Student(){ID=789, Name="Pedro", Grade=0, Picture="http://image.ibb.co/mf5mOS/if_matureman1_628284.png" },
                new Student(){ID=012, Name="Jorge", Grade=0, Picture="http://image.ibb.co/mf5mOS/if_matureman1_628284.png" }
            };

            return lstStudents;

        }

        #region INotifyPropertyChange Interface Implementation

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {

            if (propertyName != null && PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }


        #endregion
    }
}
