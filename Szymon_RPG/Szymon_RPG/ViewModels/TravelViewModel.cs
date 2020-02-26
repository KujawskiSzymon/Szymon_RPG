using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;
using Szymon_RPG.Models;
using Xamarin.Forms;

namespace Szymon_RPG.ViewModels
{
   public class TravelViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string infoText="Info";
        private string rewardText="Reward";
        private string enemyImg;
        private bool isImageEnemy;
        private string rewardColor;


        public ICommand ButtonClicked { get; set; }
       public TravelViewModel()
        {
            ButtonClicked = new Command(execute: () =>
                 {
                     Random random = new Random();
                     int fate = random.Next(1, 1000);
                     switch (fate)
                     {
                         case int n when (n <= 200):
                             loseTravel();
                             break;
                         case int n when (n > 200 && n < 399):
                             minTravel();
                             break;
                         case int n when (n > 400 && n < 799):
                             fightTravel();
                             break;
                         case int n when (n > 800):
                             MaxTravel();
                             break;
                     }
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
                rewardText = value;
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

        private void loseTravel()
        {
            InfoText = "Szedłeś i straciłeś";
            RewardColor = "Red";
            RewardText = "Pech - TODO gold/cokolwiek loss";
        }
        private void minTravel()
        {
            InfoText = "Szedłeś i coś małego zyskałeś";
            RewardColor = "Blue";
            RewardText = "Pech - TODO gold/Cokolwiek zysk";
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
