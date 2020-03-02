using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using Szymon_RPG.Models;

namespace Szymon_RPG.ViewModels
{
   public class InventoryViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private bool isConsumable;
        private bool anyItems;

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

        private List<Item> items;
        public List<Item> Items
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
       public InventoryViewModel()
        {
            Items = Constants.Hero.inventory.items;
            if (items == null)
            {
                AnyItems = false;
                MsgAnyItems = true;
            }
            else {
                AnyItems = Items?.Count == 0 ? false : true;
                MsgAnyItems = !AnyItems;
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
