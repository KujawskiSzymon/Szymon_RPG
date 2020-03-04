using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;

using System.Windows.Input;
using Szymon_RPG.Models;
using Xamarin.Forms;

namespace Szymon_RPG.ViewModels
{
   public class TravelViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string infoText="";
        private string rewardText="";
        private string enemyImg="";
        private bool isImageEnemy = false;
        private string rewardColor;

        public int townCount;


        public ICommand ButtonClicked { get; set; }
       public TravelViewModel()
        {
            ButtonClicked = new Command(execute: () =>
                 {
                     IsImageEnemy = false;
                     Random random = new Random();
                     int fate = random.Next(1, 1000);
                     switch (fate)
                     {
                         case int n when (n <= 60):
                             //
                             break;
                         case int n when (n > 61 && n < 130):
                            //);
                             break;
                         case int n when (n > 129 && n < 199):
                             fightTravel();
                             break;
                         case int n when (n > 200 && n<262):
                             MaxTravel();
                             break;
                         case int n when (n > 261 && n<325):
                             MaxTravel();
                             break;
                         case int n when (n > 324 && n<400):
                             MaxTravel();
                             break;
                         case int n when (n > 400 && n <475):
                             MaxTravel();
                             break;
                         case int n when (n > 476 && n < 530):
                             MaxTravel();
                             break;
                         case int n when (n > 530 && n<600):
                             MaxTravel();
                             break;
                         case int n when (n >= 600 && n<680 ):
                             MaxTravel();
                             break;
                         case int n when (n >= 680 && n < 735):
                             MaxTravel();
                             break;
                         case int n when (n >= 735 && n<800):
                             MaxTravel();
                             break;
                        case int n when (n >= 800 && n<860):
                             MaxTravel();
                             break;
                        case int n when (n >= 860 && n<900):
                             MaxTravel();
                             break;

                         case int n when (n >= 900 && n<930):
                             MaxTravel();
                             break;
                         case int n when (n >= 931 && n<961):
                             MaxTravel();
                             break;
                         case int n when (n >= 961):
                             MaxTravel();
                             break;
                     }
                     townCount = Constants.actualTown;
                 }
                 
            );
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
            InfoText = "Szedłeś i straciłeś";
            RewardColor = "Red";
            RewardText = "Pech - TODO gold/cokolwiek loss";
        }
        private void Travel130()
        {
            InfoText = "Szedłeś i straciłeś";
            RewardColor = "Red";
            RewardText = "Pech - TODO gold/cokolwiek loss";
        }
        private void Travel199()
        {
            InfoText = "Szedłeś i straciłeś";
            RewardColor = "Red";
            RewardText = "Pech - TODO gold/cokolwiek loss";
        }
        private void Travel262()
        {
            InfoText = "Szedłeś i straciłeś";
            RewardColor = "Red";
            RewardText = "Pech - TODO gold/cokolwiek loss";
        }
        private void Travel325()
        {
            InfoText = "Szedłeś i straciłeś";
            RewardColor = "Red";
            RewardText = "Pech - TODO gold/cokolwiek loss";
        }
        private void Travel400()
        {
            InfoText = "Szedłeś i straciłeś";
            RewardColor = "Red";
            RewardText = "Pech - TODO gold/cokolwiek loss";
        }
        private void Travel475()
        {
            InfoText = "Szedłeś i straciłeś";
            RewardColor = "Red";
            RewardText = "Pech - TODO gold/cokolwiek loss";
        }
        private void Travel530()
        {
            InfoText = "Szedłeś i straciłeś";
            RewardColor = "Red";
            RewardText = "Pech - TODO gold/cokolwiek loss";
        }
        private void Travel600()
        {
            InfoText = "Szedłeś i straciłeś";
            RewardColor = "Red";
            RewardText = "Pech - TODO gold/cokolwiek loss";
        }

        private void Travel680()
        {
            InfoText = "Szedłeś i coś małego zyskałeś";
            RewardColor = "Blue";
            RewardText = "Pech - TODO gold/Cokolwiek zysk";
        }
        private void Travel735()
        {
            InfoText = "Szedłeś i straciłeś";
            RewardColor = "Red";
            RewardText = "Pech - TODO gold/cokolwiek loss";
        }
        private void Travel800()
        {
            InfoText = "Szedłeś i straciłeś";
            RewardColor = "Red";
            RewardText = "Pech - TODO gold/cokolwiek loss";
        }
        private void Travel860()
        {
            InfoText = "Szedłeś i straciłeś";
            RewardColor = "Red";
            RewardText = "Pech - TODO gold/cokolwiek loss";
        }
        private void Travel900()
        {
            InfoText = "Szedłeś i straciłeś";
            RewardColor = "Red";
            RewardText = "Pech - TODO gold/cokolwiek loss";
        }
        private void Travel930()
        {
            InfoText = "Szedłeś i straciłeś";
            RewardColor = "Red";
            RewardText = "Pech - TODO gold/cokolwiek loss";
        }
        private void Travel961()
        {
            InfoText = "Szedłeś i straciłeś";
            RewardColor = "Red";
            RewardText = "Pech - TODO gold/cokolwiek loss";
        }
     
        private void fightTravel()
        {
            InfoText = "Walka";
            IsImageEnemy = true;
            EnemyImg = "spooky.png";
            
            RewardText = "";
        }
        private void MaxTravel()
        {
            InfoText = "Szedłeś i zyskałeś";
            RewardColor = "Green";
            RewardText = "Duzy zysk";
        }
    }
}
