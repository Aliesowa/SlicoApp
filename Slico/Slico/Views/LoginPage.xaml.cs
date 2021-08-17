using Slico.Models;
using Slico.ViewModels;
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
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            init();
        }
        void init()
        {
            BackgroundColor = Constants.BackgroundColor;
            lblMarketerCode.TextColor = Constants.TextColor;
            lblslider1.TextColor = Constants.TextColor;
            lblslider2.TextColor = Constants.TextColor;
            LogoIcon.HeightRequest = Constants.IconHeight;
            Activityspinner.IsVisible = false;

            markerterCode.Completed += (s, e) => login_Clicked(s, e);


        }

        private void login_Clicked(object sender, EventArgs e)
        {
            Users user = new Users(markerterCode.Text);
            if (user.CheckInformation())
            {

                DisplayAlert("Login", "Login Clicked", "Okay");
                Navigation.PushAsync(new Register());

            }
            else
            {
                DisplayAlert("Login", "Please Input your Marketer code", "Okay");
            }

        }

        private void Switch_Toggled(object sender, ToggledEventArgs e)
        {
            if (identifier.IsToggled)
            {
                lblMarketerCode.Text = "Customer Code";
                markerterCode.Placeholder = "Enter Customer Code";
            }
            else if (!identifier.IsToggled)
            {
                lblMarketerCode.Text = "Markerter Code";
                markerterCode.Placeholder = "Enter Marketer Code";
            }
        }
    }
}