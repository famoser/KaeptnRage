using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Famoser.FrameworkEssentials.Singleton;
using Famoser.KaeptnRage.Business.Repositories;
using Famoser.KaeptnRage.Business.Repositories.Interfaces;
using Famoser.KaeptnRage.Business.Repositories.Mocks;
using Famoser.KaeptnRage.Data.Services;
using Famoser.KaeptnRage.Data.Services.Interfaces;
using Famoser.KaeptnRage.View.Services.Interfaces;
using Famoser.KaeptnRage.View.ViewModels.Base;
using GalaSoft.MvvmLight.Ioc;
using Xamarin.Forms;

namespace Famoser.KaeptnRage.View.ViewModels
{
    public class BaseViewModelLocator : SingletonBase<BaseViewModelLocator>
    {
        private static IPlatformHook _hook;
        public static void RegisterIPlatform(IPlatformHook hook)
        {
            _hook = hook;
        }
        public BaseViewModelLocator()
        {
            if (BaseViewModel.IsInDesignModeXamarin)
            {
                SimpleIoc.Default.Register<IPlayItemRepository, PlayItemRepositoryMock>();
            }
            else
            {
                SimpleIoc.Default.Register<IPlayItemRepository, PlayItemRepository>();
            }


            var ph = DependencyService.Get<IPlatformHook>() ?? _hook;
            ph.RegisterServices();

            SimpleIoc.Default.Register<IDataService, DataService>();

            SimpleIoc.Default.Register<MainViewModel>();
        }

        public MainViewModel MainViewModel => SimpleIoc.Default.GetInstance<MainViewModel>();
    }
}
