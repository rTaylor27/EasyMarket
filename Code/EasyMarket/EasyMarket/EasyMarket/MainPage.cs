using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace EasyMarket
{
    class MainPage : ContentPage
    {
        public MainPage()
        {
            //var s = new Style(typeof(Button));
            //s.Setters.Add(new Setter { Property = Button.BackgroundColorProperty, Value = Color.Red });

            NavigationPage.SetHasNavigationBar(this, false);

            StackLayout MainPanel = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                Spacing = 60,
                VerticalOptions = LayoutOptions.FillAndExpand
            };
            StackLayout LoginPanel = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                Spacing = 10,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            StackLayout ButtonsPanel = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                Spacing = 1,
                VerticalOptions = LayoutOptions.End
            };

            //LoginPanel.Children.Add(new Image
            //{
            //    Source = ImageSource.FromFile("market.png"),
            //    WidthRequest = 200.0,
            //    HeightRequest = 200.0
            //});                
            LoginPanel.Children.Add(new ExtendedEntry
            {
                Placeholder = "Username",
                WidthRequest = 300,
                XAlign = TextAlignment.Center,
                HorizontalOptions = LayoutOptions.Center,
                HasBorder = true,
                TextColor = Color.White,
                BorderColor = Color.White,
                PlaceholderTextColor = Color.White
            });
            LoginPanel.Children.Add(new ExtendedEntry
            {
                Placeholder = "Password",
                IsPassword = true,
                WidthRequest = 300,
                XAlign = TextAlignment.Center,
                HorizontalOptions = LayoutOptions.Center,
                HasBorder = true,
                TextColor = Color.White,
                BorderColor = Color.White,
                PlaceholderTextColor = Color.White
            });
            LoginPanel.Children.Add(new FontAwesomeLabel
            {
                Text = "FORGOT PASSWORD? " + '\uf13e'.ToString(),
                Font = Font.SystemFontOfSize(12,FontAttributes.Bold),
                WidthRequest = 300,
                HorizontalTextAlignment = TextAlignment.Center,
                HorizontalOptions = LayoutOptions.Center,
                TextColor = Color.White
            });
            Button btnLogin = new Button()
            {
                Text = "Login",
                TextColor = Color.White,
                FontSize = 16,
                BorderRadius = 80,
                WidthRequest = 280,
                BorderColor = Color.White,
                BackgroundColor = Color.DarkRed,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            Button btnRegister = new Button
            {
                Text = "REGISTER",
                TextColor = Color.White,
                FontSize = 16,
                BorderRadius = 80,
                WidthRequest = 280,
                BorderColor = Color.White,
                BackgroundColor = Color.DarkRed,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            btnLogin.Clicked += BtnLogin_Clicked;
            btnRegister.Clicked += BtnRegister_Clicked;

            ButtonsPanel.Children.Add(btnLogin);
            ButtonsPanel.Children.Add(btnRegister);                        
            
            MainPanel.Children.Add(LoginPanel);
            MainPanel.Children.Add(ButtonsPanel);
            
            this.BackgroundImage = "main.png";                        
            this.Content = MainPanel;
        }

        private async void BtnLogin_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HomePage());
        }

        private async void BtnRegister_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegisterPage { Title = "Register Page"});
        }        
    }
}
