using Labs_3_4.Services;
using System;
using Xamarin.Forms;

namespace Labs_3_4
{
    public partial class App : Application
    {
        public static event Action Started;
        public static event Action Sleep;
        public static event Action Resumed;

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
            Started?.Invoke();
        }

        protected override void OnSleep()
        {
            Sleep?.Invoke();
        }

        protected override void OnResume()
        {
            Resumed?.Invoke();
        }        
    }
}
