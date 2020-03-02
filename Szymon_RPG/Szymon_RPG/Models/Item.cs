﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Szymon_RPG.Models
{
   public  class Item
    {
        public string image { get; set; }
        public string name { get; set; }
        public int price { get; set; }

        public bool isConsuamble { get; set; } = false;
        public bool isEquable { get; set; } = false;

    }
}
