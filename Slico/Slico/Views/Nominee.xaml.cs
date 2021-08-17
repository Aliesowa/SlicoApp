using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Slico.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Nominee : ContentPage
    {
        public Nominee()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("New Customer Details", "Saved Successfully", "Done");
            Navigation.PushAsync(new ItemsPage());
        }
    }
}