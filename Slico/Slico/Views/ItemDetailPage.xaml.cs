using Slico.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace Slico.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}