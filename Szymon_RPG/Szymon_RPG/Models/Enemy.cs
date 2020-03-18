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
        public bool isAi = false;
        public List<Skill> skills;
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
        public int freqAi = 100;
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

        public bool willAI()
        {
            Random r = new Random();
            int toUse = r.Next(0, 100);
            return toUse > freqAi;
        }

        public bool hasMana(int manacost)
        {
            return manacost < mp;
        }
       
        public int useAi()
        {
            Random r = new Random();

            int skillNo = r.Next(0, skills.Count - 1);
                var x = skills[skillNo] as AttackSkill;
                if (x != null && hasMana(x.manaCost))

                    return x.useSkill(this.str,ref mp);
                else
                    return str;
            
           
        }

        public int getSkill()
        {
            Random r = new Random();

            int skillNo = r.Next(0, skills.Count - 1);
            return skillNo;
        }

        
        
    }
}
