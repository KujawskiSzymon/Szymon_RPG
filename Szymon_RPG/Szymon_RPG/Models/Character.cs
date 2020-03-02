using System;
using System.Collections.Generic;
using System.Text;

namespace Szymon_RPG.Models
{
    public class Character
    {
      public  string name { get; set; }
        public static int exp { get; set; } = 0;
        public int lvl { get; set; } = 1;
        public int hp { get; set; }
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

        //Raw Stats
        public  int live { get; set; } = 10;
        public  int str { get; set; } = 10;
        public  int mpRaw { get; set; } = 10;
        public  int vit { get; set; } = 10;
        public  int mag { get; set; } = 10;
        public  int spr { get; set; }=10;
        public  int luckRaw { get; set; } = 10;
        public  int speed { get; set; } = 10;
       



        public int maxHP { get; set; }
        public int maxMP { get; set; }
        public int reqExp { get; set; }

        public void updateStats()
        {


            hp = Convert.ToInt32(live * 7 * 1.2) ;
            mp  = Convert.ToInt32(mpRaw * 2.2 * 1.2);
           atk  = Convert.ToInt32(str * 1.2) + (Constants.Hero.inventory.oneHand == null ? 0 : Constants.Hero.inventory.oneHand.atk);
         def = Convert.ToInt32(vit * 1.2);
        matk  = Convert.ToInt32(mag * 1.2);
        mdef = Convert.ToInt32(spr * 1.2);
       luck  = Convert.ToInt32(luckRaw * 1.2);
       agi= Convert.ToInt32(speed * 1.2);

    }

       

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
