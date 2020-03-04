using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Szymon_RPG.Models
{
   public class Quest : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string name { get; set; }
        public string desc { get; set; }
        public string reqToEnd { get; set; }
        private string progress;
        public String Progress
        {
            get
            {
                return progress;
            }
            set
            {
                progress = value;
                OnPropertyChanged("Progress");
            }
        }
        public int done { get; set; }
        public int reqDone { get; set; }
        private bool showInfo = false;
        public Boolean ShowInfo
        {
            get
            {
                return showInfo;
            }
            set
            {
                showInfo = value;
                OnPropertyChanged("ShowInfo");
            }
        }
        public string reward { get; set; }
        public Item itemReward { get; set; }
        public int gold { get; set; }
        public int exp { get; set; }
        public bool activable { get; set; } = true;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}
