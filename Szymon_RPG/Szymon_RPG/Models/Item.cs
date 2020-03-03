using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;

namespace Szymon_RPG.Models
{
    public class Item : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        private bool isEquable = false;

        public bool IsEquable
        {
            get
            {
                return isEquable;
            }
            set
            {
                isEquable = value;
                OnPropertyChanged("IsEquipped");
            }
        }

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



        public string image { get; set; }
        public string name { get; set; }
        public int price { get; set; }
        public int type { get; set; }
        private int quantity { get; set; } = 0;


        public bool isConsuamble { get; set; } = false;
       


        public enum itemType { CONSUMABLE, ONEHAND, SHIELD, HELMET, ARMOR, BOOTS, RING, TWOHAND };

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        // Need to get know where to put this to work correctly...
        private string buttonText="Załóż";

        public String ButtonText{
            get
            {
                return buttonText;
            }
            set
            {
                buttonText = value;
                OnPropertyChanged("ButtonText");
            }
            }

    }
}
