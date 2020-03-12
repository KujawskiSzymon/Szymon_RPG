using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Szymon_RPG.Models;
using Xamarin.Forms;

namespace Szymon_RPG.ViewModels
{
    public class FightViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public FightViewModel()
        {
            attackButton = new Command(execute: () =>
            {
                playerAttack();
            }
            );
        }

        public ICommand attackButton { get; set; }
        private string battleLog = "";
        private bool isMenu = true;
        private string image = Constants.allEnemies[Constants.enemyNo].image;
        private int maxHp = Constants.allEnemies[Constants.enemyNo].maxHP;
        private int hp = Constants.allEnemies[Constants.enemyNo].hp;
        private int maxMp = Constants.allEnemies[Constants.enemyNo].maxMP;
        private int mp = Constants.allEnemies[Constants.enemyNo].mp;
        private int playermaxHp = Constants.Hero.maxHp;
        private int playerhp = Constants.Hero.hp;
        private int playermaxMp = Constants.Hero.maxMp;
        private int playermp = Constants.Hero.mp;

        public Boolean IsMenu
        {
            get
            {
                return isMenu;
            }
            set
            {
                isMenu = value;
                OnPropertyChanged("IsMenu");
            }
        }

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
        public String BattleLog
        {
            get
            {
                return battleLog;
            }
            set
            {
                battleLog = value;
                OnPropertyChanged("BattleLog");
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

        public async void battle()
        {
            if (isPLayerAlive() && isEnemyAlive())
            {
                IsMenu = true;

            }
            else
            {
                var navigationPage = Application.Current.MainPage;
                await navigationPage.Navigation.PopAsync().ConfigureAwait(true);
            }

        }
        public bool isPLayerAlive()
        {
            return  playerhp > 0;
        }
        public bool isEnemyAlive()
        {
           return hp > 0;
        }

       public void playerAttack()
        {
            IsMenu = false;
            string msg;
            int damage = Constants.Hero.atk - Constants.allEnemies[Constants.enemyNo].def;
            if (damage <= 0)
                damage = 1;
            if (isHit(0))
            {
                hp -= damage;
                msg = Constants.Hero.name + " trafia i zadaje " + damage + " obrażeń\n";
            }
            else
                msg = Constants.Hero.name + " nie trafia !\n";
            BattleLog += msg;
            battle();

        }
        public void enemyAttack()
        {
            string msg;
            int damage = Constants.allEnemies[Constants.enemyNo].str - Constants.Hero.def;
            if (damage <= 0)
                damage = 1;
            if (isHit(1))
            {
                Constants.Hero.hp -= damage;

                msg = Constants.allEnemies[Constants.enemyNo].name + " trafia i zadaje " + damage + " obrażeń\n";
            }
            else
                msg = Constants.allEnemies[Constants.enemyNo].name + " nie trafia !\n";
            BattleLog += msg;
            battle();

        }

        public bool isHit(int who)
        {
            Random r = new Random();
            int modify = r.Next(80, 120)/100;
            int playerStat =Convert.ToInt32( modify * Convert.ToInt32(Constants.Hero.atk * 0.25 + Constants.Hero.agi + Constants.Hero.luck * 0.25));
            modify = r.Next(80, 120) / 100;
            int enemyStat = Convert.ToInt32( modify * Convert.ToInt32(Constants.allEnemies[Constants.enemyNo].str * 0.25 + Constants.allEnemies[Constants.enemyNo].speed + Constants.allEnemies[Constants.enemyNo].luck * 0.25));
            if (who == 0) // 0 is a player
                return playerStat > enemyStat;
            else
                return enemyStat > playerStat;
        }

        
    }
}
