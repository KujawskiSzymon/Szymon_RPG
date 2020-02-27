using System;
using System.Collections.Generic;
using System.Text;

namespace Szymon_RPG.Models
{
    class BodyItem : Item
    {
        public int hp { get; set; }
        public int mp { get; set; }
        public int atk { get; set; }
        public int def { get; set; }
        public int matk { get; set; }
        public int mdef { get; set; }
        public int luck { get; set; }
        public int agi { get; set; }
    }
}
