using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Szymon_RPG.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;



namespace Szymon_RPG.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            Init();
        }


        void Init()
        {
            BackgroundColor = Constants.BackgroundColor;
            Lbl_Username.TextColor = Constants.MainTextColor;
            Lbl_Password.TextColor = Constants.MainTextColor;
            ActivitySpinner.IsVisible = false;
            LoginIcon.HeightRequest = Constants.LoginIconHeight;

            Entry_Username.Completed += (sender, e) => Entry_Password.Focus();
            Entry_Password.Completed += (sender, e) => SignInProcedure(sender, e);
            Constants.towns = new ObservableCollection<TownModel>();
            Constants.Hero = new Models.Character() { hp = 40, mp=10,inventory = new Models.Inventory(), name = "Szymon" };
            Constants.Hero.updateStats();
            Constants.levelRate.Add(1, 50);
            Constants.levelRate.Add(2, 75);
            Constants.levelRate.Add(3, 125);
            Constants.levelRate.Add(4, 200);
            Constants.levelRate.Add(5, 300);
            Constants.levelRate.Add(6, 430);
            Constants.levelRate.Add(7, 580);
            Constants.levelRate.Add(8, 700);
            Constants.levelRate.Add(9, 1000);
            Constants.levelRate.Add(10, 1350);
            Constants.levelRate.Add(11, 1900);
            Constants.levelRate.Add(12, 2600);
            Constants.levelRate.Add(13, 3500);
            Constants.levelRate.Add(14, 4500);
            Constants.levelRate.Add(15, 6000);
            Constants.levelRate.Add(16, 7800);
            Constants.levelRate.Add(17, 9800);
            Constants.levelRate.Add(18, 12500);
            Constants.levelRate.Add(19, 14000);
            Constants.levelRate.Add(20, 18000);
            Constants.levelRate.Add(21, 25000);
            Constants.levelRate.Add(22, 35000);
            Constants.levelRate.Add(23, 50000);
            Constants.levelRate.Add(24, 67000);
            Constants.levelRate.Add(25, 83500);
            /*Constants.levelRate.Add(26, 50);
          
            */
            //Przedmioty Startowe dopóki nie ma dwóch miast jest to na sztywno
            ConsumableItem item1 = new ConsumableItem() { name = "Mikstura Życia", type=0, hpRestore = 500, price = 50, image = "elixir.png", isConsuamble=true };
            OneHandItem oneHand1 = new OneHandItem() { atk = 3, type=1, name = "Sztylet",  price = 200, image = "dagger.png", IsEquable = true };
            ShieldItem ShieldItem1 = new ShieldItem() { def = 3, type=2, name = "Prosta Tarcza",  price = 200, image = "shield.png", IsEquable = true };
            HelmetItem helmet1 = new HelmetItem() { mdef=2, type=3, name = "Prosty Hełm",  price = 200, image = "viking.png", IsEquable = true };
            BodyItem body1 = new BodyItem() { def = 3, mdef=1, type=4, name = "Łachmany",  price = 500, image = "armor.png", IsEquable = true };
            BootItem boot1 = new BootItem() { luck = 3, type=5, name = "Buty",  price = 200, image = "boots.png", IsEquable = true };
            RingItem ring1 = new RingItem() { hp = 30, type=6, name = "Pierscień Życia",  price = 200, image = "shenRing.png", IsEquable = true };
          //  TwoHandItem twohand = new TwoHandItem() { atk = 3, type=7, name = "Sztylet",  price = 200, image = "swords.png", IsEquable = true };
            
            ObservableCollection<Models.Item> items = new ObservableCollection<Item>();
            items.Add(item1);
            items.Add(oneHand1);
            items.Add(ShieldItem1);
            items.Add(helmet1);
            items.Add(body1);
            items.Add(boot1);
            items.Add(ring1);
            //Twohand!



            Quest firstQuest = new Quest() {  exp = 30, done = 0, desc = "Tutaj znajduje się opis pierwszego questa", gold = 50, itemReward = null, name = "Pierwszy Quest", reqDone = 3, reward = "armor.png" };
            ObservableCollection<Quest> firstTown = new ObservableCollection<Quest>();
            firstTown.Add(firstQuest);

            //enemies


            Enemy enemy = new Enemy() {name = "Osa", rarity = "Common", image="bee.png", def=3, exp= 10, gold = 10, hp=40, id=0, items=null,loot=null, mag=3, str=3, luck=3 , lvl=1, mp= 12, spr=3, speed= 5, maxHP=40,maxMP=12};

            Constants.allEnemies = new List<Enemy>();
            Constants.allEnemies.Add(enemy);
           
       
            
            TownModel town = new TownModel() { image="village.jpg",noTown=0, Name = "Deling", Quests = firstTown, Shop = items, isUnlocked = true};
            Constants.towns.Add(town);
            Constants.actualTown = 0;
            Constants.Hero.inventory.items = new ObservableCollection<Item>();
            Constants.allItems = new Dictionary<string, Item>();
            Constants.allItems.Add(item1.name, item1);
            Constants.allItems.Add(oneHand1.name, oneHand1);
            Constants.allItems.Add(ShieldItem1.name, ShieldItem1);
            Constants.allItems.Add(helmet1.name, helmet1);
            Constants.allItems.Add(body1.name, body1);
            Constants.allItems.Add(boot1.name, boot1);
            Constants.allItems.Add(ring1.name, ring1);

        }





       async void SignInProcedure(object sender, EventArgs e)
        {
            User user = new User(Entry_Username.Text, Entry_Password.Text);
            if (user.checkInformation())
            {
                await DisplayAlert("Powiadomienie", "Zalogowano Pomyślnie", "Ok");
                // var  result = await App.RestService.Login(user);
                // if (result.AccessToken != null)
                // {
                //   App.UserDatabase.SaveUser(user);
                // }

                //  new NavigationPage(new MenuPage());
                
             await   Navigation.PushAsync(new MenuPage());
            }
            else
            {
               await DisplayAlert("Powiadomienie", "Nie udało się zalogować", "Ok");
            }
        }

    }

   
}