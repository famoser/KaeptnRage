using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Famoser.KaeptnRage.ViewModels.Base
{
    public class BaseViewModel
    {
        protected bool IsInDesignMode => Xamarin.Forms.Application.Current == null;
    }
}
