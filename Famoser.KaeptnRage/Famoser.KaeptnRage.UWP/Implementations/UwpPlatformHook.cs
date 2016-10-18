using Famoser.FrameworkEssentials.Services.Interfaces;
using Famoser.FrameworkEssentials.UniversalWindows.Platform;
using Famoser.KaeptnRage.UWP.Implementations;
using Famoser.KaeptnRage.View.Services.Interfaces;
using GalaSoft.MvvmLight.Ioc;
using Xamarin.Forms;

[assembly: Dependency(typeof(UwpPlatformHook))]
namespace Famoser.KaeptnRage.UWP.Implementations
{
    public class UwpPlatformHook : IPlatformHook
    {
        public void RegisterServices()
        {
            SimpleIoc.Default.Register<IStorageService>(() => new StorageService());
            SimpleIoc.Default.Register<IPlayService, PlayService>();
        }
    }
}
