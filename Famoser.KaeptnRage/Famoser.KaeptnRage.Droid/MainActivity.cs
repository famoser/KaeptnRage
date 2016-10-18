using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Famoser.KaeptnRage.Droid.Implementations;
using Famoser.KaeptnRage.View;
using Famoser.KaeptnRage.View.Services.Interfaces;
using Famoser.KaeptnRage.View.ViewModels;
using Xamarin.Forms;

namespace Famoser.KaeptnRage.Droid
{
    [Activity(Label = "Famoser.KaeptnRage", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            PlayService.Context = this;
            Implementations.StorageService.Context = this;

            DependencyService.Register<IPlatformHook, AndroidPlatformHook>();
            BaseViewModelLocator.RegisterIPlatform(new AndroidPlatformHook());

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);

            LoadApplication(new App());
        }
    }
}

