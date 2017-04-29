using Xamarin.Forms;

namespace EasyMarket
{
    public partial class App : Application
    {
        public App()
        {
            NavigationPage MainNavigationPage = new NavigationPage(new MainPage { Title = "EasyMarket" });
            MainNavigationPage.BarBackgroundColor = Color.Red;
            MainNavigationPage.BarTextColor = Color.White;
            MainPage = MainNavigationPage;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
