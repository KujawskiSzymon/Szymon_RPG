using System;
using System.Collections.Generic;
using System.Text;

namespace Szymon_RPG.Models
{
   public class OneHandItem : Item
    {
        public int hp { get; set; } = 0;
        public int mp { get; set; } = 0;
        public int atk { get; set; } = 0;
        public int def { get; set; } = 0;
        public int matk { get; set; } = 0;
        public int mdef { get; set; } = 0;
        public int luck { get; set; } = 0;
        public int agi { get; set; } = 0;
    }
}
