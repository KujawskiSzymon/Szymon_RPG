using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Windows.Input;
using Szymon_RPG.Views;
using Xamarin.Forms;
using Szymon_RPG.Models;

namespace Szymon_RPG.ViewModels
{
    class TownViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand shopButton { get; set; }
        public ICommand tasksButton { get; set; }

        private string townName;

        public String TownName{
            get
            {
                return townName;
            }
            set
            {
                townName = value;
                OnPropertyChanged("TownName");
            }
        }
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }


        private string imageTown;

        public String ImageTown
        {
            get
            {
                return imageTown;
            }
            set
            {
                imageTown = value;
                OnPropertyChanged("ImageTown");
            }
        }

        public TownViewModel()
        {
            TownName = Constants.towns[Constants.actualTown].Name;
            ImageTown = Constants.towns[Constants.actualTown].image;


            shopButton = new Command(execute: () =>
            {
                var navigationPage = Application.Current.MainPage;
                navigationPage.Navigation.PushAsync(new Shop());
            });
            tasksButton = new Command(execute: () =>
            {
                var navigationPage = Application.Current.MainPage;
                navigationPage.Navigation.PushAsync(new TaskTown());
            });
        }

    }
}
