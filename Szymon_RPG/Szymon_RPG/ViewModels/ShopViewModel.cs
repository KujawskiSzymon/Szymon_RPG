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
            ButtonClicked = new Command(execute: (sender) =>
            {
                buyItem(sender);
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

      async  private void buyItem(object sender)
        {
            ImageButton  button = (ImageButton)sender;
           Item x =  (Item)button.BindingContext;
            if (Constants.gold > x.price)
            {
                Constants.gold -= x.price;
                Item item;
                if (Constants.allItems.TryGetValue(x.name, out item))
                {
                    Constants.Hero.inventory.items.Add(item);
                }
                await Application.Current.MainPage.DisplayAlert("Sklep", "Zakup Udany", "OK").ConfigureAwait(true);
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Sklep", "Brak funduszy", "OK").ConfigureAwait(true);
            }
            



        }


    }



}
