using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App1
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {


        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            this.npk.CurrentItem = 20.ToString();
        }
    }
}
