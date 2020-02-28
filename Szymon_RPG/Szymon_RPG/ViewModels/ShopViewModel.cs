using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;
using Szymon_RPG.Models;
using Xamarin.Forms;

namespace Szymon_RPG.ViewModels
{
    class ShopViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

       private ObservableCollection<Item> items;
        public ICommand ButtonClicked { get; set; }

        public ObservableCollection<Item> Items
        {
            get
            {
                return items;
            }
            set
            {
                items = value;
                OnPropertyChanged("Items");
            }
        }

        public ShopViewModel()
        {
            ButtonClicked = new Command(execute: () =>
            {
                buyItem();
            });
            items = new ObservableCollection<Item>();
            Items = Constants.towns[Constants.actualTown].Shop;
        }


        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

         private void buyItem()
        {
            Debug.WriteLine("Test");
        }


    }



}
