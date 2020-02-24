using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Szymon_RPG.Models
{
   public class SkillStatInfo : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string label;
        private int stat;
        public string Label { get {
                return label;
            } set {
                label = value;OnPropertyChanged("Label");
            } }
        public int Stat {
            get
            {
                return stat; 
            }
            set
            {
                stat = value;

                OnPropertyChanged("Stat");
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
