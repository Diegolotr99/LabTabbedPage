using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace LabTabbedPage.Model
{
    public class Student
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public ObservableCollection<Homework> LstHomeworks { get; set; }
        public string Picture { get; set; }
        public double Grade { get; set; }

        public static async Task<ObservableCollection<Student>> GetStudents()
        {
            ObservableCollection<Student> lstStudents;
            lstStudents = new ObservableCollection<Student>() {
                new Student(){ID="123", Name="Diego", Grade=0, Picture="http://image.ibb.co/iHDecn/if_matureman2_628283_Cream.png" },
                new Student(){ID="456", Name="Juan", Grade=0,  Picture="http://image.ibb.co/hACBq7/if_male3_403019.png"},
                new Student(){ID="789", Name="Pedro", Grade=0, Picture="http://image.ibb.co/mf5mOS/if_matureman1_628284.png" },
                new Student(){ID="012", Name="Jorge", Grade=0, Picture="http://image.ibb.co/mf5mOS/if_matureman1_628284.png" }
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
