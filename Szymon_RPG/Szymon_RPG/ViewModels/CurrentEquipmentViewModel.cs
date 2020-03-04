using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using Szymon_RPG.Models;

namespace Szymon_RPG.ViewModels
{
    class CurrentEquipmentViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;


        private ObservableCollection<string> equipItems;

        public ObservableCollection<String> EquipItems
        {
            get
            {
                return equipItems;
            }
            set
            {
                equipItems = value;
                OnPropertyChanged("EquipItems");
            }
        }

        public CurrentEquipmentViewModel()
        {
            equipItems = new ObservableCollection<string>();
            EquipItems.Add(checkNullName(Constants.Hero.inventory.oneHand));
            EquipItems.Add(checkNullName(Constants.Hero.inventory.shield));
            EquipItems.Add(checkNullName(Constants.Hero.inventory.helmet));
            EquipItems.Add(checkNullName(Constants.Hero.inventory.body));
            EquipItems.Add(checkNullName(Constants.Hero.inventory.boots));
            EquipItems.Add(checkNullName(Constants.Hero.inventory.ring));
          

        }


        private string checkNullName(Item item)
        {
            if (item == null)
            {
                return "Brak";
            }
            else
            {
                return item.name;
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
