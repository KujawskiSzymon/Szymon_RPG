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
        public List<Item> loots;


        public FightViewModel()
        {
            attackButton = new Command(execute: () =>
            {
                playerAttack();
            }
            );
            exitButton = new Command(execute: () =>
            {
                exit();
            }
            );
            loots = new List<Item>();

        }

        public ICommand attackButton { get; set; }
        public ICommand exitButton { get; set; }
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
        private string rewardInfo = "";
        private bool isExit=false;

        public Boolean IsExit
        {
            get
            {
                return isExit;
            }
            set
            {
                isExit = value;
                OnPropertyChanged("IsExit");
            }
        }

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

        public String RewardInfo
        {
            get
            {
                return rewardInfo;
            }
            set
            {
                rewardInfo = value;
                OnPropertyChanged("RewardInfo");
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

        public async void checkBattleStatus()
        {
            if (isPLayerAlive())
            {
                if (isEnemyAlive())
                {
                    /// the battle continues...
                }
                else
                {
                    winBattle();
                }

            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Powiadomienie", "Przegrałeś", "Ok").ConfigureAwait(true);
               await  Application.Current.MainPage.Navigation.PopToRootAsync(true).ConfigureAwait(true);
            }


        }
        public bool isPLayerAlive()
        {
            return Playerhp > 0;
        }
        public bool isEnemyAlive()
        {
           return Hp > 0;
        }

       public void playerAttack()
        {
            IsMenu = false;
            string msg;
            int damage = Constants.Hero.atk - Constants.allEnemies[Constants.enemyNo].def;
            Random r = new Random();
            int modify = r.Next(70, 130);
            double mod = (double)modify / 100;
            damage = Convert.ToInt32(damage * mod);
            if (damage <= 0)
                damage = 1;
            if (isHit(0))
            {
                Hp -= damage;
                msg = Constants.Hero.name + " trafia i zadaje " + damage + " obrażeń\n";
            }
            else
                msg = Constants.Hero.name + " nie trafia !\n";
            BattleLog += msg;
            
            checkBattleStatus();
            enemyAttack();

        }
        public void enemyAttack()
        {
            string msg;
            int damage = Constants.allEnemies[Constants.enemyNo].str - Constants.Hero.def;
         
            Random r = new Random();
            int modify = r.Next(70, 130);
            double mod = (double)modify / 100;
            damage = Convert.ToInt32(damage * mod);
            if (damage <= 0)
                damage = 1;
            if (isHit(1))
            {
                Playerhp -= damage;

                msg = Constants.allEnemies[Constants.enemyNo].name + " trafia i zadaje " + damage + " obrażeń\n";
            }
            else
                msg = Constants.allEnemies[Constants.enemyNo].name + " nie trafia !\n";
            BattleLog += msg;
            
            checkBattleStatus();
            IsMenu = true;
           

        }

        public bool isHit(int who)
        {
            int baseHit = 80;

            Random r = new Random();
            int modify = r.Next(80, 120);
            double mod = modify / 100;
            int playerStat =Convert.ToInt32( mod * Convert.ToInt32(Constants.Hero.atk * 0.1 + Constants.Hero.agi * 0.5 + Constants.Hero.luck * 0.25));
            modify = r.Next(80, 120);
            mod = modify / 100;
            int enemyStat = Convert.ToInt32( mod * Convert.ToInt32(Constants.allEnemies[Constants.enemyNo].str * 0.1 + Constants.allEnemies[Constants.enemyNo].speed * 0.5 + Constants.allEnemies[Constants.enemyNo].luck * 0.25));
            if (who == 0) // 0 is a player
            {
                baseHit += playerStat - enemyStat;
                int hit = r.Next(1, 100);
                return baseHit > hit;
            }
            else
            {
                baseHit += enemyStat - playerStat;
                int hit = r.Next(1, 100);
                return baseHit > hit;
            }
                
        }
        public void winBattle()
        {
            IsExit = true;
            IsMenu = false;
            loot();
            RewardInfo = "Otrzymano " + Constants.allEnemies[Constants.enemyNo].exp + " doświadczenia oraz " + Constants.allEnemies[Constants.enemyNo].gold + " złota";
            if (loots.Count > 0)
            {
                foreach(Item item in loots)
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
                    RewardInfo += " Znalaziono " + item.name+"\n";
                }
            }
            else
            {
                RewardInfo += " Nie zdobyto żadnych przedmiotów";
            }
        
        }

        public void loot()
        {
            Random r = new Random();
            int chance = 0;
            if (Constants.allEnemies[Constants.enemyNo].loot != null)
            {
                foreach(Item item in Constants.allEnemies[Constants.enemyNo].loot)
                {
                    chance = r.Next(0, 100);
                    if (item.lootPercent > chance)
                    {

                    }
                    else
                    {
                        loots.Add(item);
                    }
                }
            }

            
        }

        public async void exit()
        {
            var navigation = Application.Current.MainPage;
          await  navigation.Navigation.PopAsync();
        }

        
    }
}
