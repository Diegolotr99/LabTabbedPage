using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace LabTabbedPage.Model
{
    public class Course
    {

        public string ID { get; set; }
        public string Title { get; set; }
        public string Icon { get; set; }
        public ObservableCollection<Student> ListStudents { get; set; }


        public static async Task<ObservableCollection<Course>> GetCourses()
        {
            ObservableCollection<Course> lstCourses;
            lstCourses = new ObservableCollection<Course>() {
                new Course(){ID="M-101", Title="Mathematics", Icon="Numbers_96px", ListStudents=new ObservableCollection<Student>()},
                new Course(){ID="CH-101", Title="Chemistry",  Icon="TestTube_96px", ListStudents=new ObservableCollection<Student>()}, 
                new Course(){ID="BI-101", Title="Biology", Icon="Biotech_96px", ListStudents=new ObservableCollection<Student>()},
                new Course(){ID="PS-101", Title="Psychology", Icon="Psychology_96px", ListStudents=new ObservableCollection<Student>()},
                new Course(){ID="CU-101", Title="Culture", Icon="Globe_96px", ListStudents=new ObservableCollection<Student>()},
                new Course(){ID="LA-101", Title="English", Icon="ABC_96px", ListStudents=new ObservableCollection<Student>()}
            };

            return lstCourses;

        }
    }
}
