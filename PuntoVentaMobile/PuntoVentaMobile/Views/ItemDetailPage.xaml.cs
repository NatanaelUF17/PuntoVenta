using PuntoVentaMobile.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace PuntoVentaMobile.Views
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