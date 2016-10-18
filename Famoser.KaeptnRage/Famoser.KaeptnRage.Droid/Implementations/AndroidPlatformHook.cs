using Famoser.FrameworkEssentials.Services.Interfaces;
using Famoser.KaeptnRage.Droid.Implementations;
using Famoser.KaeptnRage.View.Services.Interfaces;
using GalaSoft.MvvmLight.Ioc;
using Xamarin.Forms;

[assembly: Dependency(typeof(AndroidPlatformHook))] 
namespace Famoser.KaeptnRage.Droid.Implementations
{
    public class AndroidPlatformHook : IPlatformHook
    {
        public void RegisterServices()
        {
            SimpleIoc.Default.Register<IPlayService, PlayService>();
            SimpleIoc.Default.Register<IStorageService, StorageService>();
        }
    }
}