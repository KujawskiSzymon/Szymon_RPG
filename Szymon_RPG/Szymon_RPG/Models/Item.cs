using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;

namespace Szymon_RPG.Models
{
   public  class Item : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        public int Quantity
        {
            get
            {
                return quantity;
            }
            set
            {
                quantity = value;
                OnPropertyChanged("Quantity");

            }
        }

        public bool IsEquipped
        {
            get
            {
                return isEquipped;
            }
            set
            {
                isEquipped = value;
                OnPropertyChanged("IsEquipped");
            }
        }

        public string image { get; set; }
        public string name { get; set; }
        public int price { get; set; }
        public int type { get; set; }
        private int quantity { get; set; } = 0;


        public bool isConsuamble { get; set; } = false;
        public bool isEquable { get; set; } = false;
        public bool isEquipped { get; set; } = false;

        public  enum itemType { CONSUMABLE,ONEHAND,TWOHAND,HELMET,ARMOR,BOOTS,RING,SHIELD};

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}
