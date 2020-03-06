using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Szymon_RPG.Models;

namespace Szymon_RPG.ViewModels
{
    public class FightViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public FightViewModel()
        {

        }



        private string image = Constants.allEnemies[Constants.enemyNo].image;
        private int maxHp = Constants.allEnemies[Constants.enemyNo].maxHP;
        private int hp = Constants.allEnemies[Constants.enemyNo].hp;
        private int maxMp = Constants.allEnemies[Constants.enemyNo].maxMP;
        private int mp = Constants.allEnemies[Constants.enemyNo].mp;
        private int playermaxHp = Constants.Hero.maxHP;
        private int playerhp = Constants.Hero.hp;
        private int playermaxMp = Constants.Hero.maxMP;
        private int playermp = Constants.Hero.mp;

        public int PlayermaxHp
        {
            get
            {
                return playermaxHp;
            }
            set
            {
                playermaxHp = value;
                OnPropertyChanged("PlayermaxHp");
            }
        }
        public int Playerhp
        {
            get
            {
                return playerhp;
            }
            set
            {
                playerhp = value;
                OnPropertyChanged("Playerhp");
            }
        }
        public int PlayermaxMp
        {
            get
            {
                return playermaxMp;
            }
            set
            {
                playermaxMp = value;
                OnPropertyChanged("PlayermaxMp");
            }
        }
        public int Playermp
        {
            get
            {
                return playermp;
            }
            set
            {
                playermp = value;
                OnPropertyChanged("Playermp");
            }
        }

        public String Image
        {
            get
            {
                return image;
            }
            set
            {
                image = value;
                OnPropertyChanged("Image");
            }
        }
        public int MaxHp
        {
            get
            {
                return maxHp;
            }
            set
            {
                maxHp = value;
                OnPropertyChanged("MaxHp");
            }
        }
        public int Hp
        {
            get
            {
                return hp;
            }
            set
            {
                hp = value;
                OnPropertyChanged("Hp");
            }
        }
        public int MaxMp
        {
            get
            {
                return maxMp;
            }
            set
            {
                maxMp = value;
                OnPropertyChanged("MaxMp");
            }
        }
        public int Mp
        {
            get
            {
                return mp;
            }
            set
            {
                mp = value;
                OnPropertyChanged("Mp");
            }
        }






        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
