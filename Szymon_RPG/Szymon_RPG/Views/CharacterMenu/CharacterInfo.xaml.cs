using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Szymon_RPG.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Szymon_RPG.Views.CharacterMenu;

namespace Szymon_RPG.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CharacterInfo : ContentPage
    {
       
        public List<StatInfo> menuStats { get; set; }
        public CharacterInfo()
        {
            
            InitializeComponent();
           
         
        }

        private void  GoToSkillPoints(object sender, EventArgs e)
        {
           Navigation.PushAsync(new SkillPointMenu());
        }

        private void GotoEquipment(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CurrentEquipment());
        }
      protected override void OnAppearing()
        {
            Constants.Hero.updateStats();
            menuStats = new List<StatInfo>();
            StatInfo name = new StatInfo() { Label = "Nazwa Gracza", Info = Constants.Hero.name };
            StatInfo hp = new StatInfo() { Label = "HP", Info = Constants.Hero.hp.ToString() };
            StatInfo mp = new StatInfo() { Label = "MP", Info = Constants.Hero.mp.ToString() };
            StatInfo lvl = new StatInfo() { Label = "Level", Info = Constants.Hero.lvl.ToString() };
            StatInfo str = new StatInfo() { Label = "Siła", Info = Constants.Hero.atk.ToString() };
            StatInfo mag = new StatInfo() { Label = "Magia", Info = Constants.Hero.matk.ToString() };
            StatInfo def = new StatInfo() { Label = "Obrona", Info = Constants.Hero.def.ToString() };
            StatInfo mdef = new StatInfo() { Label = "Obrona Magiczna", Info = Constants.Hero.mdef.ToString() };
            StatInfo speed = new StatInfo() { Label = "Szybkość", Info = Constants.Hero.agi.ToString() };
            StatInfo luck = new StatInfo() { Label = "Szczęście", Info = Constants.Hero.luck.ToString() };

            menuStats.Add(name);
            menuStats.Add(lvl);
            menuStats.Add(hp);
            menuStats.Add(mp);
            menuStats.Add(str);
            menuStats.Add(mag);
            menuStats.Add(def);
            menuStats.Add(mdef);
            menuStats.Add(speed);
            menuStats.Add(luck);




            HeroStats.ItemsSource = menuStats;
        }
    }
}