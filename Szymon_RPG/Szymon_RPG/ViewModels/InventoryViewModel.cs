﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Szymon_RPG.Models;
using Xamarin.Forms;

namespace Szymon_RPG.ViewModels
{
   public class InventoryViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private bool isConsumable;
        private bool anyItems;
        public ICommand useItem { get; set; }
        public ICommand equipItem { get; set; }
        public ICommand unequipItem { get; set; }

        public InventoryViewModel()
        {
            Items = Constants.Hero.inventory.items;
            if (items == null)
            {
                AnyItems = false;
                MsgAnyItems = true;
            }
            else
            {
                AnyItems = Items?.Count == 0 ? false : true;
                MsgAnyItems = !AnyItems;
            }

            useItem = new Command(execute: (sender) =>
            {
                use(sender);
            });
            equipItem = new Command(execute: (sender) =>
            {
                 equip(sender);
            });
         
        }

        

        public Boolean IsConsumable
        {
            get
            {
                return isConsumable;
            }
            set
            {
                anyItems = value;
                OnPropertyChanged("IsConsumable");
            }
        }

        public Boolean AnyItems
        {
            get
            {
                return anyItems;
            }
            set
            {
                anyItems = value;
                OnPropertyChanged("AnyItems");
            }
        }

        private bool msganyItems;
        public Boolean MsgAnyItems
        {
            get
            {
                return msganyItems;
            }
            set
            {
                msganyItems = value;
                OnPropertyChanged("MsgAnyItems");
            }
        }

        private ObservableCollection<Item> items;
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
       

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        async private void use(object sender)
        {
            Button button = (Button)sender;
            ConsumableItem x = (ConsumableItem)button.BindingContext;
            /*
            if (Constants.gold > x.price)
            {
                Constants.gold -= x.price;
                */
            Item item;
            if (Constants.allItems.TryGetValue(x.name, out item))
            {
                ConsumableItem theItem = (ConsumableItem)item;
                theItem.Quantity -= 1;
                if (theItem.Quantity == 0)
                {
                    Constants.Hero.inventory.items.Remove(theItem);
                    Items.Remove(theItem);
                    if (Constants.Hero.inventory.items.Count == 0)
                    {
                        AnyItems = false;
                        MsgAnyItems = true;
                    }
                    
                }
                
            }
            await Application.Current.MainPage.DisplayAlert("Ekwipunek", "Zużyto przedmiot", "OK").ConfigureAwait(true);
            /* }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Sklep", "Brak funduszy", "OK").ConfigureAwait(true);
            }
            */




        }
        async private void equip(object sender)
        {
            Button button = (Button)sender;
            Item x = (Item)button.BindingContext;

            Item item;
            if (button.Text.Equals("Załóż"))
            {
              
                if (Constants.allItems.TryGetValue(x.name, out item))
                {
                    switch (item.type)
                    {
                        case 1:
                            Constants.Hero.inventory.oneHand = (OneHandItem)item;
                            break;
                        case 2:
                            Constants.Hero.inventory.shield = (ShieldItem)item;
                            break;
                        case 3:
                            Constants.Hero.inventory.helmet = (HelmetItem)item;
                            break;
                           
                        case 4:
                            Constants.Hero.inventory.body = (BodyItem)item;
                            break;
                         
                        case 5:
                            Constants.Hero.inventory.boots = (BootItem)item;
                            break;
                 
                        case 6:
                            Constants.Hero.inventory.ring = (RingItem)item;
                            break;
                          
                        case 7:
                       //     Constants.Hero.inventory.twoHand = (OneHandItem)item;
                            break;

                    }
                    // Constants.Hero.inventory.oneHand = item;
                    item.ButtonText = "Zdejmij";
                }
                await Application.Current.MainPage.DisplayAlert("Ekwipunek", "Ekwipunek założony", "OK").ConfigureAwait(true);
                /* }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Sklep", "Brak funduszy", "OK").ConfigureAwait(true);
                }
                */




            }
            else
            {
             
                if (Constants.allItems.TryGetValue(x.name, out item))
                {
                    switch (item.type)
                    {
                        case 1:
                            Constants.Hero.inventory.oneHand = null;
                            break;
                        case 2:
                            Constants.Hero.inventory.shield = null;
                            break;
                        case 3:
                            Constants.Hero.inventory.helmet = null;
                            break;
                        case 4:
                            Constants.Hero.inventory.body = null;
                            break;
                        case 5:
                            Constants.Hero.inventory.boots = null;
                            break;
                        case 6:
                            Constants.Hero.inventory.ring = null;
                            break;
                        case 7:
                            Constants.Hero.inventory.twoHand = null;
                            break;

                    }
                    // Constants.Hero.inventory.oneHand = item;
                    item.ButtonText = "Załóż";
                }
                await Application.Current.MainPage.DisplayAlert("Ekwipunek", "Ekwipunek zdjęty", "OK").ConfigureAwait(true);

            }
        }
        async private void unequip(object sender)
        {
            Button button = (Button)sender;
           
            /* }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Sklep", "Brak funduszy", "OK").ConfigureAwait(true);
            }
            */




        }

    }
}
