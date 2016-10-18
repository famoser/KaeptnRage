using GalaSoft.MvvmLight;

namespace Famoser.KaeptnRage.View.ViewModels.Base
{
    public class BaseViewModel : ViewModelBase
    {
        public static bool IsInDesignModeXamarin => Xamarin.Forms.Application.Current == null;
    }
}
