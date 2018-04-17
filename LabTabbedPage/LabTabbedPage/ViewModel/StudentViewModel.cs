
using LabTabbedPage.ModalNavigation;
using LabTabbedPage.Model;
using LabTabbedPage.View;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace LabTabbedPage.ViewModel
{
    public class StudentViewModel : INotifyPropertyChanged
    {

        #region singleton

        private static StudentViewModel instance = null;
        public StudentViewModel()
        {
            InitClass();
            InitCommandsAsync();

        }
        public static StudentViewModel GetInstance()
        {

            if (instance == null)
                instance = new StudentViewModel();

            return instance;
        }
        #endregion
        #region instances
        private TabbedPage CurrentTabbedPage { get; set; }
        private ObservableCollection<Course> initialLstCourse = new ObservableCollection<Course>();
        private ObservableCollection<Course> _LstCourses = new ObservableCollection<Course>();
        public ObservableCollection<Course> LstCourses
        {
            get
            {
                return _LstCourses;
            }

            set
            {
                _LstCourses = value;
                OnPropertyChanged("LstCourses");

            }

        }
        private ObservableCollection<Student> initialLstStudents = new ObservableCollection<Student>();
        private ObservableCollection<Student> _lstStudents = new ObservableCollection<Student>();
        public ObservableCollection<Student> lstStudents
        {
            get
            {
                return _lstStudents;
            }

            set
            {
                _lstStudents = value;
                OnPropertyChanged("lstStudents");

            }

        }

        private Student _ActualStudent { get; set; }
        public Student ActualStudent
        {
            get
            {
                return _ActualStudent;
            }
            set
            {
                _ActualStudent = value;
                OnPropertyChanged("ActualStudent");
            }
        }
        private Course _ActualCourse { get; set; }
        public Course ActualCourse
        {
            get
            {
                return _ActualCourse;
            }
            set
            {
                _ActualCourse = value;
                OnPropertyChanged("ActualCourse");
            }
        }
        private string ImageTakenFilePath { get; set; }
        private Image _ImageStudent { get; set; }
        public Image ImageStudent {
            get { return _ImageStudent; }
            set {
                _ImageStudent = value;
                OnPropertyChanged("ImageStudent");
            }

        }
        private string _IDNewCourse { get; set; }
        public string IDNewCourse {
            get { return _IDNewCourse; }
            set
            {
                _IDNewCourse = value;
                OnPropertyChanged("IDNewCourse");
            }
        }
        
        private string _TitleNewCourse { get; set; }
        public string TitleNewCourse
        {
            get { return _TitleNewCourse; }
            set
            {
                _TitleNewCourse = value;
                OnPropertyChanged("TitleNewCourse");
            }
        }
        private string _IconNewCourse { get; set; }
        public string IconNewCourse
        {
            get { return _IconNewCourse; }
            set
            {
                _IconNewCourse = value;
                OnPropertyChanged("IconNewCourse");
            }
        }
        private string _IDNewStudent { get; set; }
        public string IDNewStudent {
            get { return _IDNewStudent; }
            set { _IDNewStudent = value;
                OnPropertyChanged("IDNewStudent");
            }

        }
        private string _NameNewStudent { get; set; }
        public string NameNewStudent
        {
            get { return _NameNewStudent; }
            set
            {
                _NameNewStudent = value;
                OnPropertyChanged("NameNewStudent");
            }

        }
        private int _GradeNewStudent { get; set; }
        public int GradeNewStudent
        {
            get { return _GradeNewStudent; }
            set
            {
                _GradeNewStudent = value;
                OnPropertyChanged("GradeNewStudent");
            }

        }

        private string _IDNewHomework { get; set; }
        public string IDNewHomework
        {
            get { return _IDNewHomework; }
            set
            {
                _IDNewHomework = value;
                OnPropertyChanged("IDNewHomework");
            }
        }
        private string _FileNewHomework { get; set; }
        public string FileNewHomework
        {
            get { return _FileNewHomework; }
            set
            {
                _FileNewHomework = value;
                OnPropertyChanged("FileNewHomework");
            }
        }
        #endregion
        #region init
        private async void InitClass()
        {

           
            LstCourses = await Course.GetCourses();
            initialLstCourse = LstCourses;

            ImageStudent = new Image();
            ImageStudent.Source = "Contacts_100px.png";

            lstStudents = await Student.getAllStudents();
            initialLstStudents = lstStudents;
        }
        private async Task InitCommandsAsync()
        {
            SeeStudentDetailCommand = new Command<string>(SeeStudentDetail);
            SeeCourseStudentsCommand = new Command<string>(SeeCourseDetail);
            AddStudentToCourseCommand = new Command(AddStudentToCourse);
            AddNewCourseCommand = new Command(AddNewCourseWindowAsync);
            OnAddCourseButtonClickedCommand = new Command(AddNewCourse);
            OnDismissButtonClickedCommand = new Command(DismissAddNew);
            OnAddHomeworkButtonClickedCommand = new Command(AddNewHomework);
            AddNewHomeworkCommand = new Command(OnAddHomeworkButtonClicked);
            TakeStudentPictureCommand = new Command(TakeCameraPicture);
        }
        #endregion
        #region Declare Commands
        public ICommand SeeStudentDetailCommand { get; set; }
        public ICommand SeeCourseStudentsCommand { get; set; }
        public ICommand AddStudentToCourseCommand { get; set; }
        public ICommand AddNewCourseCommand { get; set; }
        public ICommand OnAddCourseButtonClickedCommand { get; set; }
        public ICommand OnDismissButtonClickedCommand { get; set; }
        public ICommand OnAddHomeworkButtonClickedCommand { get; set; }
        public ICommand AddNewHomeworkCommand { get; set; }
        public ICommand TakeStudentPictureCommand { get; set; }
        #endregion
        #region commands methods
        private void SeeStudentDetail(string pID)
        {
            if (ActualCourse.ListStudents.Count > 0) {

                ActualStudent = ActualCourse.ListStudents.Where(x => x.ID == Int32.Parse(pID)).FirstOrDefault();
                CurrentTabbedPage.CurrentPage = CurrentTabbedPage.Children[2];
            }


        }
        private void SeeCourseDetail(string pID)
        {
            ActualCourse = initialLstCourse.Where(x => x.ID == pID).FirstOrDefault();

            CurrentTabbedPage = new MainTabNavigation();
            CurrentTabbedPage.CurrentPage = CurrentTabbedPage.Children[1];
            CurrentTabbedPage.Title = ActualCourse.Title;

            (App.Current.MainPage).Navigation.PushAsync(CurrentTabbedPage);

        }
        private void AddStudentToCourse()
        {
            if (IDNewStudent == "" || IDNewStudent == null || NameNewStudent == "" || NameNewStudent == null)
            {
                Application.Current.MainPage.DisplayAlert("Missing Values", "Please set values ID and Name", "OK");
            } else {

                Student newStudent = new Student { ID = Int32.Parse(IDNewStudent), Name = NameNewStudent, Grade = GradeNewStudent, LstHomeworks = new ObservableCollection<Homework>() };
                //Next Line to be replaced by the image captured or image uploaded
                if (ImageTakenFilePath == "" || ImageTakenFilePath == null)
                    newStudent.Picture = "Contacts_100px";
                else {
                    newStudent.Picture = ImageTakenFilePath;
                   
                }
                ActualCourse.ListStudents.Add(newStudent);

                IDNewStudent = "";
                NameNewStudent = "";
                GradeNewStudent = 0;

                CurrentTabbedPage.CurrentPage = CurrentTabbedPage.Children[1];
                ImageStudent= new Image();
                ImageStudent.Source = "Contacts_100px.png";
            }
        }

        private async void AddNewCourseWindowAsync()
        {
            await App.Current.MainPage.Navigation.PushModalAsync(new AddNewCourseView());
        }
        private async void OnAddHomeworkButtonClicked() {

            await App.Current.MainPage.Navigation.PushModalAsync(new AddNewHomeworkView());
        }
        private void AddNewCourse()
        {
            if (IDNewCourse == null || IDNewCourse == "" || TitleNewCourse == null || TitleNewCourse == "")
            {
                Application.Current.MainPage.DisplayAlert("Missing Values", "Please set values for ID and Title", "OK");

            }
            else {

                Course newCourse = new Course { ID = IDNewCourse, Title = TitleNewCourse, ListStudents = new ObservableCollection<Student>() };
                newCourse.Icon = "Books_96px";
                LstCourses.Add(newCourse);

                IDNewCourse = "";
                TitleNewCourse = "";

                DismissAddNew();

            }
        }
        private void AddNewHomework() {

            if (IDNewHomework == null || IDNewHomework == "" || FileNewHomework == null || FileNewHomework == "")
            {
                Application.Current.MainPage.DisplayAlert("Missing Values", "Please set values ID and File", "OK");

            }
            else {
                Homework newHomework = new Homework { ID = IDNewHomework, File = FileNewHomework };
                ActualStudent.LstHomeworks.Add(newHomework);
                IDNewHomework = "";
                FileNewHomework = "";

                DismissAddNew();
            }

        }
        private async void DismissAddNew() {

            IDNewCourse = "";
            TitleNewCourse = "";
            IDNewHomework = "";
            FileNewHomework = "";
            await App.Current.MainPage.Navigation.PopModalAsync();
        }
        #endregion
        #region Camera Async Methods
        private async void  TakeCameraPicture() {


            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await DisplayMessage("Error", "No Camera Available");
                return;
            }

            var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                Directory = "Test",
                SaveToAlbum = true,
                CompressionQuality = 75,
                CustomPhotoSize = 50,
                PhotoSize = PhotoSize.MaxWidthHeight,
                MaxWidthHeight = 2000,
                DefaultCamera = CameraDevice.Front

            });

            if (file == null)
                return;

            //Application.Current.MainPage.DisplayAlert("File Location", file.Path, "OK");

            ImageStudent = new Image();
            ImageStudent.Source = ImageSource.FromStream(() =>
                {
                    var stream = file.GetStream();
                    file.Dispose();
                    return stream;
                });
            ImageTakenFilePath = file.Path;
        }
        private async Task DisplayMessage(string head, string body) {
            Application.Current.MainPage.DisplayAlert(head, body, "OK");
        }
        #endregion
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
