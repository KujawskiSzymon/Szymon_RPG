using System;
using System.Collections.Generic;
using System.Text;

namespace Szymon_RPG.Models
{
    public class Character
    {
      public  string name { get; set; }
        public static int exp { get; set; } = 0;
      public  int lvl { get; set; }
      public  int hp { get; set; }
      public  int mp { get; set; }
        public int atk { get; set; }
        public int def { get; set; }
        public int matk { get; set; }
        public int mdef { get; set; }
        public int luck { get; set; }
        public int agi { get; set; }
        public  int skillPoints { get; set; } = 0;
        public static bool canExp = true;
        public Inventory inventory { get; set; }
        

        public int maxHP { get; set; }
        public int maxMP { get; set; }
        public int reqExp { get; set; }

       

        public void checkLevel()
        {
            if (exp >= reqExp)
            {
                exp -= reqExp;
                lvlUp();
            }
        }

        public void lvlUp()
        {
            if (lvl + 1 == Constants.maxLvl)
            {
                canExp = false;

            }
            lvl++;
            skillPoints += 10;

        }

    }
}
