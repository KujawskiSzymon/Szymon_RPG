using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Szymon_RPG.Models
{
  public class StatInfo : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string label;
        private string info;

        public string Label
        {
            get
            {
                return label;
            }
            set
            {
                label = value; OnPropertyChanged("Label");
            }
        }
        public string Info
        {
            get
            {
                return info;
            }
            set
            {
                info = value;

                OnPropertyChanged("Info");
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
