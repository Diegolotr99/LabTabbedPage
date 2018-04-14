using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace LabTabbedPage.Model
{
    public class Homework
    {
        private string _ID { get; set; }
        public string ID {
            get { return _ID; }
            set { _ID = value;
                OnPropertyChanged("ID");
            }
        }

        private string _File { get; set; }
        public string File {
            get { return _File;}
            set { _File = value;
                OnPropertyChanged("File");
            }
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
