using Famoser.KaeptnRage.View.ViewModels;
using Xamarin.Forms;

namespace Famoser.KaeptnRage.View.Pages
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            BindingContext = new MainViewModel();
        }
    }
}
