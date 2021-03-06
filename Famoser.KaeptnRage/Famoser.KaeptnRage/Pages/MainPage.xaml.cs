﻿using System;
using Famoser.KaeptnRage.View.ViewModels;
using GalaSoft.MvvmLight.Ioc;
using Xamarin.Forms;

namespace Famoser.KaeptnRage.View.Pages
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            
            BindingContext = BaseViewModelLocator.Instance.MainViewModel;
        }

        private void Button_OnClicked(object sender, EventArgs e)
        {
            var butt = sender as Button;
            BaseViewModelLocator.Instance.MainViewModel.PlayFileCommand.Execute(butt?.BindingContext);
        }

        private void Refresh(object sender, EventArgs e)
        {
            BaseViewModelLocator.Instance.MainViewModel.RefreshCommand.Execute(null);
        }

        /// <summary>
        /// disable annoying selection color
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ((ListView) sender).SelectedItem = null;
        }
    }
}
