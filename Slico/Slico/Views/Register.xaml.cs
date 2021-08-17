using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Slico.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Register : ContentPage
    {
        private string connectionString = "Server = SQL5056.site4now.net; Database=db_a5796b_slicodb; user id=db_a5796b_slicodb_admin; Password=Comsoft@2016;";

        public Register()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            string fname = firstname.Text;
            string lname = lastname.Text;

            //string connectionString = @"Server=<ipAddress>;Database=<DBName>;User Id=<username>;Password=<password>;Trusted_Connection=true";

            string qury = $"insert into Customer(Firstname, Lastname) values ('{fname}' ,'{lname}' )";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //open connection
                connection.Open();

                SqlCommand command = new SqlCommand();

                command.Connection = connection;
                command.CommandText = qury;
                var result = command.ExecuteReader();
                
                

                Navigation.PushAsync(new RegisterWitness());
            } 
        }

    }
}