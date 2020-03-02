using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Text;

namespace Szymon_RPG.Models
{
    public static class Constants
    {
        public static bool isDev = true;

        public static Color BackgroundColor = Color.FromArgb(50, 153, 215);
        public static Color MainTextColor = Color.White;

        public static int LoginIconHeight = 120;


        //---LOGIN
        public static string LoginUrl = "https://test.com/api/Auth/Login";


        // Startowa Postac Debug

        public static Character Hero;

        public static Dictionary<int, int> levelRate = new Dictionary<int, int>();
        public static int maxLvl = 25;

        public static int gold = 0;

        // Miasto

        public static ObservableCollection<TownModel> towns;
        public static int actualTown = 0;


        // Wszystkie Przedmioty??

        public static Dictionary<string, Item> allItems;
        
        

    }
}
