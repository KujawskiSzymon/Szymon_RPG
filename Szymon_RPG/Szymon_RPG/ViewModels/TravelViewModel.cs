using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;

using System.Windows.Input;
using Szymon_RPG.Models;
using Szymon_RPG.Views;
using Xamarin.Forms;

namespace Szymon_RPG.ViewModels
{
   public class TravelViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand fightButton{ get; set; }
        private string infoText="";
        private string rewardText="";
        private string enemyImg="";
        private bool isImageEnemy = false;
        private string rewardColor;
        private bool isFightable = false;
        public int townCount;




        public ICommand ButtonClicked { get; set; }
       public TravelViewModel()
        {
            fightButton = new Command(execute: () =>
             {
                 var navigationPage = Application.Current.MainPage;
                 navigationPage.Navigation.PushAsync(new Fight());
             }
            );

            ButtonClicked = new Command(execute: () =>
                 {
                     IsFightable = false;
                     IsImageEnemy = false;
                     Random random = new Random();
                     int fate = random.Next(1, 1000);
                     switch (fate)
                     {
                         case int n when (n <= 60):
                             Travel60();
                             break;
                         case int n when (n > 61 && n < 130):
                             Travel61();
                             break;
                         case int n when (n > 129 && n < 199):
                             Travel130();
                             break;
                         case int n when (n > 200 && n<262):
                             Travel199();
                             break;
                         case int n when (n > 261 && n<325):
                             Travel262();
                             break;
                         case int n when (n > 324 && n<400):
                             Travel325();
                             break;
                         case int n when (n > 400 && n <475):
                             Travel400();
                             break;
                         case int n when (n > 476 && n < 530):
                             Travel475();
                             break;
                         case int n when (n > 530 && n<600):
                             Travel530();
                             break;
                         case int n when (n >= 600 && n<680 ):
                             Travel600();
                             break;
                         case int n when (n >= 680 && n < 735):
                             Travel680();
                             break;
                         case int n when (n >= 735 && n<800):
                             Travel735();
                             break;
                        case int n when (n >= 800 && n<860):
                             Travel800();
                             break;
                        case int n when (n >= 860 && n<900):
                             Travel860();
                             break;

                         case int n when (n >= 900 && n<930):
                             Travel900();
                             break;
                         case int n when (n >= 931 && n<961):
                             Travel930();
                             break;
                         case int n when (n >= 961):
                             Travel961();
                             break;
                     }
                     townCount = Constants.actualTown;
                 }
                 
            );
        }

        public Boolean IsFightable
        {
            get
            {
                return isFightable;
            }
            set
            {
                isFightable = value;
                OnPropertyChanged("IsFightable");
            }
        }

        public String RewardColor
        {
            get
            {
                return rewardColor;
            }
            set
            {
                rewardColor = value;
                OnPropertyChanged("RewardColor");
            }
        }

        public Boolean IsImageEnemy
        {
            get
            {
                return isImageEnemy;
            }
            set
            {
                isImageEnemy = value;
                OnPropertyChanged("IsImageEnemy");
            }
        }

        public String InfoText
        {
            get
            {
                return infoText;
            }
            set
            {
                infoText = value;
                OnPropertyChanged("InfoText");
            }
        }
        public String RewardText
        {
            get
            {
                return rewardText;
            }
            set
            {
                rewardText = value;
                OnPropertyChanged("RewardText");
            }
        }
        public String EnemyImg
        {
            get
            {
                return enemyImg;
            }
            set
            {
                enemyImg = value;
                OnPropertyChanged("EnemyImg");
            }
        }
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private void Travel60()
        {
            switch (Constants.actualTown)
            {
                case 0:
                    InfoText = "Podczas podróży zgubiłeś dużo złota !";
                    int lost = Convert.ToInt32(Constants.gold * 0.15);
                    Constants.gold -= Convert.ToInt32(Constants.gold * 0.3);
                    if (Constants.gold < 0)
                    {
                        Constants.gold = 0;
                    }
                    RewardColor = "Red";
                    RewardText = "Straciłeś " + lost + " sztuk złota!";
                    break;
            }

        }

        private void Travel61()
        {
            switch (Constants.actualTown)
            {
                case 0:
                    InfoText = "Podczas podróży zgubiłeś złoto !";
                    int lost = Convert.ToInt32(Constants.gold * 0.07);
                    Constants.gold -= Convert.ToInt32(Constants.gold * 0.3);
                    if (Constants.gold < 0)
                    {
                        Constants.gold = 0;
                    }
                    RewardColor = "Red";
                    RewardText = "Straciłeś "+lost+ " sztuk złota!";
                    break;
            }
            
        }
        private void Travel130()
        {
            switch (Constants.actualTown)
            {
                case 0:
                    InfoText = "Nie wydarzyło się nic ciekawego...";
                    RewardColor = "Red";
                    RewardText = "";
                    break;
            }
            
        }
        private void Travel199()
        {
            switch (Constants.actualTown)
            {
                case 0:
                    InfoText = "Znalazłeś miksturę życia !";
                    RewardColor = "Green";
                    RewardText = "Uzyskano miksturę życia!";
                    Item item;
                    if (Constants.allItems.TryGetValue("Mikstura Życia", out item))
                    {
                        if (Constants.Hero.inventory.items.Contains(item))
                        {
                            item.Quantity += 1;
                        }
                        else
                        {
                            Constants.Hero.inventory.items.Add(item);
                            item.Quantity += 1;
                        }
                    }
                    else
                    {
                        //Error
                    }

                        break;
                    
            }
            
        }
        private void Travel262()
        {
            switch (Constants.actualTown)
            {
                case 0:
            
                    Enemy enemy = Constants.allEnemies[0];
                    Constants.enemyNo = enemy.id;
                    InfoText = "Zaatakaowała Cię Osa!\n"+"Poziom: "+enemy.lvl+"\n";
                    EnemyImg = enemy.image;
                    IsImageEnemy = true;
                    IsFightable = true;
                    RewardColor = "Blue";
                    RewardText = "";
                    break;
            }
            
        }
        private void Travel325()
        {
            switch (Constants.actualTown)
            {
                case 0:
                    Enemy enemy = Constants.allEnemies[1];
                    Constants.enemyNo = enemy.id;
                    InfoText = "Zaatakował Cię "+enemy.name+"\n"+"Poziom: "+enemy.lvl+"\n";
                    EnemyImg = enemy.image;
                    IsImageEnemy = true;
               
                    IsFightable = true;
                    RewardColor = "Blue";
                    RewardText = "";
                    break;

                   
            }
            
        }
        private void Travel400()
        {
            switch (Constants.actualTown)
            {
                case 0:
                    InfoText = "Łatwy przeciwnik 3";
                    IsImageEnemy = true;
                    EnemyImg = "spooky.png";
                    RewardColor = "Blue";
                    RewardText = "";
                    break;
            }
           
        }
        private void Travel475()
        {
            switch (Constants.actualTown)
            {
                case 0:
                    Random r = new Random();
                    int exp = r.Next(1, 10);
                    InfoText = "Pomogłeś pobliskim mieszkańcom";
                    RewardColor = "Green";
                    RewardText = "Zdobyłeś "+ exp+ " doświadczenia";
                    Constants.Hero.exp += exp; //Check Level
                    break;
            }
            
        }
        private void Travel530()
        {
            switch (Constants.actualTown)
            {
                case 0:
                    Random r = new Random();
                    int exp = r.Next(10, 60);
                    InfoText = "Znalazłeś sakiewkę z pieniędzmi";
                    RewardColor = "Green";
                    RewardText = "Zdobyłeś " + exp + " złota";
                    Constants.gold += exp; //Check Level
                    break;
            }
            
        }
        private void Travel600()
        {
            switch (Constants.actualTown)
            {
                case 0:
                    InfoText = "Uncommon 1";
                    IsImageEnemy = true;
                    EnemyImg = "spooky.png";
                    RewardColor = "Blue";
                    RewardText = "";
                    break;
            }
            
        }

        private void Travel680()
        {
            switch (Constants.actualTown)
            {
                case 0:
                    InfoText = "Tutaj odblokujesz coś nowego w grze";
                    RewardColor = "Blue";
                    RewardText = "TODO";
                    break;
            }
        
        }
        private void Travel735()
        {
            switch (Constants.actualTown)
            {
                case 0:
                    InfoText = "Uncommon 2";
                    IsImageEnemy = true;
                    EnemyImg = "spooky.png";
                    RewardColor = "Blue";
                    RewardText = "";
                    break;
            }
            
        }
        private void Travel800()
        {
            switch (Constants.actualTown)
            {
                case 0:
                    InfoText = "Znalazłeś skrzynię";
                    RewardColor = "Red";
                    RewardText = "TODO: wybór otworzenia - losowanie przemdiotu/mimic";
                    break;
            }
            
        }
        private void Travel860()
        {
            switch (Constants.actualTown)
            {
                case 0:
                    InfoText = "Uratowałeś turystę przed dzikimi zwierzętami";
                    Random r = new Random();
                    int exp = r.Next(15, 35);
                    RewardColor = "Green";
                    Constants.Hero.exp += exp;
                    RewardText = "Zyskujesz "+exp+" punktów doświadczenia";
                    break;
            }
            
        }
        private void Travel900()
        {
            switch (Constants.actualTown)
            {
                case 0:
                    InfoText = "Rare";
                    IsImageEnemy = true;
                    EnemyImg = "spooky.png";
                    RewardColor = "Blue";
                    RewardText = "";
                    break;
            }
            
        }
        private void Travel930()
        {
            switch (Constants.actualTown)
            {
                case 0:
                    InfoText = "Tutaj zdobędziesz jednorazowo umiejętność/zdobędziesz exp/gold";
                    RewardColor = "Green";
                    RewardText = "TODO";
                    break;
            }
            
        }
        private void Travel961()
        {
            switch (Constants.actualTown)
            {
                case 0:
                    InfoText = "Znalazłeś ukrytą skrzynię pełną pieniędzy!";
                    Random r = new Random();
                    int exp = r.Next(200, 800);
                    RewardColor = "Green";
                    Constants.gold += exp;
                    RewardText = "Zyskujesz " + exp + " złota";
                    break;
            }
           
        }
     
      
    }
}
