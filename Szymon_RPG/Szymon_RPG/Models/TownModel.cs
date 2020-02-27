using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Szymon_RPG.Models
{
    public class TownModel
    {
        public string Name { get; set; }
       public ObservableCollection<Item> Shop { get; set; }
        public ObservableCollection<Quest> Quests { get; set; }
        public bool isUnlocked { get; set; }

    }
}
