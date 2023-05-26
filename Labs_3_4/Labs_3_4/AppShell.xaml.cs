using Labs_3_4.ViewModels;
using Labs_3_4.Views;
using System;
using System.Collections.Generic;
using Xamarin.Essentials;
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

        private async void MailItemClicked(object sender, EventArgs e)
        {
            await Launcher.OpenAsync(new Uri($"mailto:{MailItem.Text}"));
        }

        private async void PhoneItem_Clicked(object sender, EventArgs e)
        {
            await Launcher.OpenAsync($"tel:{PhoneItem.Text}");
        }

        private async void SocialItem_Clicked(object sender, EventArgs e)
        {
            await Browser.OpenAsync("https://www.facebook.com");
        }
    }
}
