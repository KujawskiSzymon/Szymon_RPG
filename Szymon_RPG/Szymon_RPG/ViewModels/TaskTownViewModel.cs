using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Szymon_RPG.Models;
using Xamarin.Forms;

namespace Szymon_RPG.ViewModels
{
    class TaskTownViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand startQuest { get; set; }
        private ObservableCollection<Quest> quests;
        public ObservableCollection<Quest> Quests
        {
            get
            {
                return quests;
            }
            set
            {
                quests = value;
                OnPropertyChanged("Quests");
            }
        }

        public TaskTownViewModel()
        {
            Quests = Constants.towns[Constants.actualTown].Quests;
            startQuest = new Command(execute: (sender) =>
            {
                //buyItem(sender);
            });
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
