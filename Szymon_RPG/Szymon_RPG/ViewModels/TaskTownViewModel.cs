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
            foreach(Quest quest in Constants.towns[Constants.actualTown].Quests)
            {
                quest.Progress= quest.done + "/" + quest.reqDone;
            }
            Quests = Constants.towns[Constants.actualTown].Quests;
            startQuest = new Command(execute: (sender) =>
            {
                start(sender);
            });
        }



        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

       async private void start (Object sender){
            Button button = (Button)sender;
            Quest x = (Quest)button.BindingContext;

            x.activable = false;
            button.IsVisible = false;
            x.ShowInfo = true;
            await Application.Current.MainPage.DisplayAlert("Zadanie", "Rozpocząłeś zadanie!", "OK").ConfigureAwait(true);
        }

    }
}
