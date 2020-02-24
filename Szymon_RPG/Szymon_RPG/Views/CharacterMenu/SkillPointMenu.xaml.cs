using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Szymon_RPG.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Szymon_RPG.Views.CharacterMenu
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SkillPointMenu : ContentPage, INotifyPropertyChanged
    {
        private string remainingSkillPoints;
        public event PropertyChangedEventHandler PropertyChanged;

        public List<SkillStatInfo>  menuStats { get; set; }
        public string RemainingSkillPoints { get { return remainingSkillPoints; } set {
                remainingSkillPoints = value; OnPropertyChanged("RemainingSkillPoints"); 
            } }

        public SkillPointMenu()
        {
            InitializeComponent();
            menuStats = new List<SkillStatInfo>();
            RemainingSkillPoints = "Punkty Umiejętności: "+Constants.Hero.skillPoints.ToString();
            menuStats.Add(new SkillStatInfo { Label = "Żywotność", Stat = Constants.Hero.hp });
            menuStats.Add(new SkillStatInfo { Label = "Siła", Stat = Constants.Hero.atk });
            menuStats.Add(new SkillStatInfo { Label = "Magia", Stat = Constants.Hero.matk });
            menuStats.Add(new SkillStatInfo { Label = "Obrona", Stat = Constants.Hero.def });
            menuStats.Add(new SkillStatInfo { Label = "Obrona Magiczna", Stat = Constants.Hero.mdef });
            menuStats.Add(new SkillStatInfo { Label = "Szybkość", Stat = Constants.Hero.agi });
            menuStats.Add(new SkillStatInfo { Label = "Szczęście", Stat = Constants.Hero.luck });
            MenuStats.ItemsSource = menuStats;
            SkillPoints.Text = RemainingSkillPoints;





        }
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }


        private void plusButton_Clicked(object sender, EventArgs e)
        {

            Button button = (Button)sender;
            try
            {
                SkillStatInfo x = (SkillStatInfo)button.BindingContext;
                if (x.Label.Equals("Żywotność"))
                {
                    Constants.Hero.hp+=10; x.Stat += 10;
                }
                if (x.Label.Equals("Siła"))
                {
                    Constants.Hero.atk++; x.Stat += 1;
                }
                if (x.Label.Equals("Magia"))
                {
                    Constants.Hero.matk++; x.Stat += 1;
                }

                if (x.Label.Equals("Obrona"))
                {
                    Constants.Hero.def++; x.Stat += 1;
                }

                if (x.Label.Equals("Obrona Magiczna"))
                {
                    Constants.Hero.mdef++; x.Stat += 1;
                }

                if (x.Label.Equals("Szybkość"))
                {
                    Constants.Hero.agi++; x.Stat += 1;
                }
                if (x.Label.Equals("Szczęście"))
                {
                    Constants.Hero.luck++;
                    x.Stat += 1;
                }



                
                Constants.Hero.skillPoints -=1;
                RemainingSkillPoints = "Punkty Umiejętności: " + Constants.Hero.skillPoints.ToString();
                SkillPoints.Text = RemainingSkillPoints;

            }
            catch(Exception ex)
            {
                
            }
           
            
            
            if (Constants.Hero.skillPoints > 0)
            {
                
            }
        }
    }
}