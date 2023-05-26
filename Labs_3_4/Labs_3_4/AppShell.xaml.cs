using Labs_3_4.ViewModels;
using Labs_3_4.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Labs_3_4
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
            Routing.RegisterRoute(nameof(NewItemBasePage), typeof(NewItemBasePage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }

        private void MailItemClicked(object sender, EventArgs e)
        {

        }
    }
}
