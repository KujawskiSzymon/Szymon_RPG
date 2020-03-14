using System;
using System.Collections.Generic;
using System.Text;

namespace Szymon_RPG.Models
{
   public class Enemy
    {
        public Enemy()
        {
           
            
        }

        public int id; //[]in list??
        public string image;
        public string rarity;
        public int lvl; // ?
        public string name;
        public int maxHP;
        public int hp;
        public int maxMP;
        public int mp;
        public int exp;
        public int gold;
        public  List<Item> loot;
        public int str;
        public int def;
        public int mag;
        public int spr;
        public int luck;
        public int speed;
        public List<Item> items; //uses in fight

        public void addItems(List<Item> items)
        {
            items = new List<Item>();
            foreach (Item item in items)
            {
                this.items.Add(item);
            }
        }
      public  void addLoot(List<Item> items)
        {
            
            foreach (Item item in items)
            {
                loot.Add(item);
            }
        }

       
        
    }
}
