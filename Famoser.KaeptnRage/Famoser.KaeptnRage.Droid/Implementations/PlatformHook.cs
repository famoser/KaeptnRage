using Famoser.FrameworkEssentials.Services.Interfaces;
using Famoser.KaeptnRage.View.Services.Interfaces;
using GalaSoft.MvvmLight.Ioc;

namespace Famoser.KaeptnRage.Droid.Implementations
{
    public partial class PlatformHook : IPlatformHook
    {
        public void RegisterServices()
        {
            SimpleIoc.Default.Register<IPlayService, PlayService>();
            SimpleIoc.Default.Register<IStorageService, StorageService>();
        }
    }
}