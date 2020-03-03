using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Szymon_RPG.Models
{
   public  class Inventory
    {
        public ObservableCollection<Item> items;
        public OneHandItem oneHand;
        
    }
}
