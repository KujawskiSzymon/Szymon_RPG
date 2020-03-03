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
            int toAddHp = 0;
            addHp(ref toAddHp);
            int toAddMp = 0;
            addMp(ref toAddMp);
            int toAddStr = 0;
            addAtk(ref toAddStr);
            int toAddDef = 0;
            addDef(ref toAddDef);
            int toAddMatk = 0;
            addMatk(ref toAddMatk);
            int toAddMdef = 0;
            addMdef(ref toAddMdef);
            int toAddAgi = 0;
            addAgi(ref toAddAgi);
            int toAddLuck = 0;
            addLuck(ref toAddLuck);

            


            hp = Convert.ToInt32(live * 7 * 1.2) + toAddHp ;
            mp  = Convert.ToInt32(mpRaw * 2.2 * 1.2) + toAddMp;
           atk  = Convert.ToInt32(str * 1.2) + toAddStr;
         def = Convert.ToInt32(vit * 1.2)+ toAddDef;
        matk  = Convert.ToInt32(mag * 1.2)+ toAddMatk;
        mdef = Convert.ToInt32(spr * 1.2)+ toAddMdef;
       luck  = Convert.ToInt32(luckRaw * 1.2)+ toAddLuck;
       agi= Convert.ToInt32(speed * 1.2)+ toAddAgi;

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

        public void addHp( ref int stat)
        {
            stat += Constants.Hero.inventory.oneHand == null ? 0 : Constants.Hero.inventory.oneHand.hp;
            stat += Constants.Hero.inventory.twoHand == null ? 0 : Constants.Hero.inventory.twoHand.hp;
            stat += Constants.Hero.inventory.shield == null ? 0 : Constants.Hero.inventory.shield.hp;
            stat += Constants.Hero.inventory.helmet == null ? 0 : Constants.Hero.inventory.helmet.hp;
            stat += Constants.Hero.inventory.boots == null ? 0 : Constants.Hero.inventory.boots.hp;
            stat += Constants.Hero.inventory.body == null ? 0 : Constants.Hero.inventory.body.hp;
            stat += Constants.Hero.inventory.ring == null ? 0 : Constants.Hero.inventory.ring.hp;

        }
        public void addMp(ref int stat)
        {
            stat += Constants.Hero.inventory.oneHand == null ? 0 : Constants.Hero.inventory.oneHand.mp;
            stat += Constants.Hero.inventory.twoHand == null ? 0 : Constants.Hero.inventory.twoHand.mp;
            stat += Constants.Hero.inventory.shield == null ? 0 : Constants.Hero.inventory.shield.mp;
            stat += Constants.Hero.inventory.helmet == null ? 0 : Constants.Hero.inventory.helmet.mp;
            stat += Constants.Hero.inventory.boots == null ? 0 : Constants.Hero.inventory.boots.mp;
            stat += Constants.Hero.inventory.body == null ? 0 : Constants.Hero.inventory.body.mp;
            stat += Constants.Hero.inventory.ring == null ? 0 : Constants.Hero.inventory.ring.mp;

        }
        public void addAtk(ref int stat)
        {
            stat += Constants.Hero.inventory.oneHand == null ? 0 : Constants.Hero.inventory.oneHand.atk;
            stat += Constants.Hero.inventory.twoHand == null ? 0 : Constants.Hero.inventory.twoHand.atk;
            stat += Constants.Hero.inventory.shield == null ? 0 : Constants.Hero.inventory.shield.atk;
            stat += Constants.Hero.inventory.helmet == null ? 0 : Constants.Hero.inventory.helmet.atk;
            stat += Constants.Hero.inventory.boots == null ? 0 : Constants.Hero.inventory.boots.atk;
            stat += Constants.Hero.inventory.body == null ? 0 : Constants.Hero.inventory.body.atk;
            stat += Constants.Hero.inventory.ring == null ? 0 : Constants.Hero.inventory.ring.atk;

        }
        public void addDef(ref int stat)
        {
            stat += Constants.Hero.inventory.oneHand == null ? 0 : Constants.Hero.inventory.oneHand.def;
            stat += Constants.Hero.inventory.twoHand == null ? 0 : Constants.Hero.inventory.twoHand.def;
            stat += Constants.Hero.inventory.shield == null ? 0 : Constants.Hero.inventory.shield.def;
            stat += Constants.Hero.inventory.helmet == null ? 0 : Constants.Hero.inventory.helmet.def;
            stat += Constants.Hero.inventory.boots == null ? 0 : Constants.Hero.inventory.boots.def;
            stat += Constants.Hero.inventory.body == null ? 0 : Constants.Hero.inventory.body.def;
            stat += Constants.Hero.inventory.ring == null ? 0 : Constants.Hero.inventory.ring.def;

        }
        public void addMatk(ref int stat)
        {
            stat += Constants.Hero.inventory.oneHand == null ? 0 : Constants.Hero.inventory.oneHand.matk;
            stat += Constants.Hero.inventory.twoHand == null ? 0 : Constants.Hero.inventory.twoHand.matk;
            stat += Constants.Hero.inventory.shield == null ? 0 : Constants.Hero.inventory.shield.matk;
            stat += Constants.Hero.inventory.helmet == null ? 0 : Constants.Hero.inventory.helmet.matk;
            stat += Constants.Hero.inventory.boots == null ? 0 : Constants.Hero.inventory.boots.matk;
            stat += Constants.Hero.inventory.body == null ? 0 : Constants.Hero.inventory.body.matk;
            stat += Constants.Hero.inventory.ring == null ? 0 : Constants.Hero.inventory.ring.matk;

        }
        public void addMdef(ref int stat)
        {
            stat += Constants.Hero.inventory.oneHand == null ? 0 : Constants.Hero.inventory.oneHand.mdef;
            stat += Constants.Hero.inventory.twoHand == null ? 0 : Constants.Hero.inventory.twoHand.mdef;
            stat += Constants.Hero.inventory.shield == null ? 0 : Constants.Hero.inventory.shield.mdef;
            stat += Constants.Hero.inventory.helmet == null ? 0 : Constants.Hero.inventory.helmet.mdef;
            stat += Constants.Hero.inventory.boots == null ? 0 : Constants.Hero.inventory.boots.mdef;
            stat += Constants.Hero.inventory.body == null ? 0 : Constants.Hero.inventory.body.mdef;
            stat += Constants.Hero.inventory.ring == null ? 0 : Constants.Hero.inventory.ring.mdef;

        }
        public void addLuck(ref int stat)
        {
            stat += Constants.Hero.inventory.oneHand == null ? 0 : Constants.Hero.inventory.oneHand.luck;
            stat += Constants.Hero.inventory.twoHand == null ? 0 : Constants.Hero.inventory.twoHand.luck;
            stat += Constants.Hero.inventory.shield == null ? 0 : Constants.Hero.inventory.shield.luck;
            stat += Constants.Hero.inventory.helmet == null ? 0 : Constants.Hero.inventory.helmet.luck;
            stat += Constants.Hero.inventory.boots == null ? 0 : Constants.Hero.inventory.boots.luck;
            stat += Constants.Hero.inventory.body == null ? 0 : Constants.Hero.inventory.body.luck;
            stat += Constants.Hero.inventory.ring == null ? 0 : Constants.Hero.inventory.ring.luck;

        }
        public void addAgi(ref int stat)
        {
            stat += Constants.Hero.inventory.oneHand == null ? 0 : Constants.Hero.inventory.oneHand.agi;
            stat += Constants.Hero.inventory.twoHand == null ? 0 : Constants.Hero.inventory.twoHand.agi;
            stat += Constants.Hero.inventory.shield == null ? 0 : Constants.Hero.inventory.shield.agi;
            stat += Constants.Hero.inventory.helmet == null ? 0 : Constants.Hero.inventory.helmet.agi;
            stat += Constants.Hero.inventory.boots == null ? 0 : Constants.Hero.inventory.boots.agi;
            stat += Constants.Hero.inventory.body == null ? 0 : Constants.Hero.inventory.body.agi;
            stat += Constants.Hero.inventory.ring == null ? 0 : Constants.Hero.inventory.ring.agi;

        }

    }
}
