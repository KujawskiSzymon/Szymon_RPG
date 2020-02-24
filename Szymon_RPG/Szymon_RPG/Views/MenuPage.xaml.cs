using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Szymon_RPG.Menu;
using Szymon_RPG.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Szymon_RPG.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : MasterDetailPage
    {

        public List<MasterPageItem> menuList { get; set; }


        public MenuPage()
        {
            
            InitializeComponent();
            var characterInfoPage = new MasterPageItem() { Title = "Postać", Icon="knight.png", TargetType = typeof(CharacterInfo) };
            var travelInfoPage = new MasterPageItem() { Title = "Podróż", Icon = "desert.png", TargetType = typeof(Travel) };
            var inventoryInfoPage = new MasterPageItem() { Title = "Ekwipunek", Icon = "chest.png",TargetType = typeof(Inventory) };
            var questsInfoPage = new MasterPageItem() { Title = "Zadania", Icon = "question.png", TargetType = typeof(Quests) };
            var arenaInfoPage = new MasterPageItem() { Title = "Arena", Icon = "arena.png", TargetType = typeof(BattleArena)};
            var wBosseslInfoPage = new MasterPageItem() { Title = "Bossowie", Icon = "dragon.png", TargetType = typeof(WorldBosses) };

            menuList = new List<MasterPageItem>();
            menuList.Add(characterInfoPage);
            menuList.Add(travelInfoPage);
            menuList.Add(inventoryInfoPage);
            menuList.Add(questsInfoPage);
            menuList.Add(arenaInfoPage);
            menuList.Add(wBosseslInfoPage);

            navigationDrawerList.ItemsSource = menuList;

            Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(CharacterInfo)));

        }

        private void OnMenuItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = (MasterPageItem)e.SelectedItem;
            Type page = item.TargetType;

            Detail = new NavigationPage((Page)Activator.CreateInstance(page));
            IsPresented = false;
        }
    }
}