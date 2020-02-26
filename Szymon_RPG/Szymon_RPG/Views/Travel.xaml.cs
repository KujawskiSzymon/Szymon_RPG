using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Szymon_RPG.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Travel : ContentPage
    {
        public Travel()
        {
            InitializeComponent();
        }

        private void TravelStart(object sender, EventArgs e)
        {
            Random random = new Random();
            int fate = random.Next(1, 1000);
            switch (fate)
               {
                case int n when (n <= 200):
                    Console.WriteLine();
                    break;
                case int n when (n > 200 && n < 399):
                    Console.WriteLine();
                    break;
                case int n when (n > 400 && n < 600):
                    Console.WriteLine();
                    break;
                case int n when (n > 800):
                    Console.WriteLine();
                    break;
            }

        }
        
    }
}