using System;
using System.Collections.Generic;
using System.Text;

namespace Szymon_RPG.Models
{
   public class Quest
    {
        public string name { get; set; }
        public string desc { get; set; }
        public string reqToEnd { get; set; }
        public int done { get; set; }
        public int reqDone { get; set; }
        public bool active { get; set; } = false;
        public string reward { get; set; }
        public Item itemReward { get; set; }
        public int gold { get; set; }
        public int exp { get; set; }

    }
}
