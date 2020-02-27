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

            Entry_Username.Completed +=(sender,e) => Entry_Password.Focus();
            Entry_Password.Completed += (sender, e) => SignInProcedure(sender,e);
            Constants.towns = new ObservableCollection<TownModel>();
            Constants.Hero = new Models.Character() { name = "Szymon", atk = 10, def = 10, agi = 10, hp = 150, luck = 10, lvl = 1, matk = 10, mdef = 10, mp = 16 };
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
            Constants.levelRate.Add(27, 50);
            Constants.levelRate.Add(28, 50);
            Constants.levelRate.Add(29, 50);
            Constants.levelRate.Add(30, 50);
            Constants.levelRate.Add(31, 50);
            Constants.levelRate.Add(32, 50);
            Constants.levelRate.Add(33, 50);
            Constants.levelRate.Add(34, 50);
            Constants.levelRate.Add(35, 50);
            Constants.levelRate.Add(36, 50);
            Constants.levelRate.Add(37, 50);
            Constants.levelRate.Add(38, 50);
            Constants.levelRate.Add(39, 50);
            Constants.levelRate.Add(40, 50);
            Constants.levelRate.Add(41, 50);
            Constants.levelRate.Add(42, 50);
            Constants.levelRate.Add(43, 50);
            Constants.levelRate.Add(44, 50);
            Constants.levelRate.Add(45, 50);
            Constants.levelRate.Add(46, 50);
            Constants.levelRate.Add(47, 50);
            Constants.levelRate.Add(48, 50);
            Constants.levelRate.Add(49, 50);
            Constants.levelRate.Add(50, 50);
            */

            ConsumableItem item1 = new ConsumableItem() { name = "Mikstura Życia", hpRestore = 500, price = 50, image="elixir.png" };
            ObservableCollection<Models.Item> items = new ObservableCollection<Item>();
            items.Add(item1);
           

            Quest firstQuest = new Quest() { active = false, exp = 30, done = 0, desc = "Tutaj znajduje się opis pierwszego questa", gold = 50, itemReward = null, name = "Pierwszy Quest", reqDone = 3, reward = "Tutaj znajduje się opis nagrody" };
            ObservableCollection<Quest> firstTown = new ObservableCollection<Quest>();
            firstTown.Add(firstQuest);
            TownModel town = new TownModel() { Name = "Deling", Quests = firstTown, Shop = items, isUnlocked = true};
            Constants.towns.Add(town);
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