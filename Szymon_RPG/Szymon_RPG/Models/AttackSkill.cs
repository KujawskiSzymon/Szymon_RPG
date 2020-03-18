using System;
using System.Collections.Generic;
using System.Text;

namespace Szymon_RPG.Models
{
  public class AttackSkill : Skill
    {
       public int skillStr;
        Object status;

        public int useSkill(int attack, ref int mana) {
            mana = mana -  manaCost;
            return skillStr + attack;
        }
    }
}
