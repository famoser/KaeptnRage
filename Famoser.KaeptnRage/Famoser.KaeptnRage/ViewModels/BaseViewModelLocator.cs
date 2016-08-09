using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Famoser.KaeptnRage.Business.Repositories;
using Famoser.KaeptnRage.Business.Repositories.Interfaces;
using Famoser.KaeptnRage.Business.Repositories.Mocks;
using Famoser.KaeptnRage.View.ViewModels.Base;
using GalaSoft.MvvmLight.Ioc;

namespace Famoser.KaeptnRage.View.ViewModels
{
    public class BaseViewModelLocator : BaseViewModel
    {
        public BaseViewModelLocator()
        {
            if (IsInDesignMode)
            {
                SimpleIoc.Default.Register<IPlayItemRepository, PlayItemRepositoryMock>();
            }
            else
            {
                SimpleIoc.Default.Register<IPlayItemRepository, PlayItemRepository>();
            }

            SimpleIoc.Default.Register<MainViewModel>();
        }

        public MainViewModel MainViewModel => SimpleIoc.Default.GetInstance<MainViewModel>();
    }
}
