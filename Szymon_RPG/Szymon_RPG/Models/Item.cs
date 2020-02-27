using System;
using System.Collections.Generic;
using System.Text;

namespace Szymon_RPG.Models
{
   public  class Item
    {
        public string image { get; set; }
        public string name { get; set; }
        public int price { get; set; }
        public enum typeItem{ CONSUMABLE,ONEHAND,SHIELD,HELMET,BODY,RING,TWOHAND};
    }
}
