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
            Constants.Hero = new Models.Character() { inventory = new Models.Inventory(), name = "Szymon" };
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
            ObservableCollection<Models.Item> items = new ObservableCollection<Item>();
            items.Add(item1);
            items.Add(oneHand1);

            Quest firstQuest = new Quest() { active = false, exp = 30, done = 0, desc = "Tutaj znajduje się opis pierwszego questa", gold = 50, itemReward = null, name = "Pierwszy Quest", reqDone = 3, reward = "Tutaj znajduje się opis nagrody" };
            ObservableCollection<Quest> firstTown = new ObservableCollection<Quest>();
            firstTown.Add(firstQuest);
            TownModel town = new TownModel() { Name = "Deling", Quests = firstTown, Shop = items, isUnlocked = true};
            Constants.towns.Add(town);
            Constants.Hero.inventory.items = new ObservableCollection<Item>();
            Constants.allItems = new Dictionary<string, Item>();
            Constants.allItems.Add(item1.name, item1);
            Constants.allItems.Add(oneHand1.name, oneHand1);

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