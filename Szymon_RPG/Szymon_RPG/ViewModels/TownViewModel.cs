using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Windows.Input;
using Szymon_RPG.Views;
using Xamarin.Forms;

namespace Szymon_RPG.ViewModels
{
    class TownViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand ButtonClicked { get; set; }

        public TownViewModel()
        {
            ButtonClicked = new Command(execute: () =>
            {
                var navigationPage = Application.Current.MainPage;
                navigationPage.Navigation.PushAsync(new Shop());
            });
        }

    }
}
