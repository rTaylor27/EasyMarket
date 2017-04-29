using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace EasyMarket
{
    public class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            StackLayout MainPanel = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                Spacing = 50,
                VerticalOptions = LayoutOptions.Center
            };

            StackLayout ButtonsPanel = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                Spacing = 10,
                VerticalOptions = LayoutOptions.Center
            };

            StackLayout EntriesPanel = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                Spacing = 10,
                VerticalOptions = LayoutOptions.Center
            };

            Entry lbName = new ExtendedEntry() {
                Placeholder = "Name",
                HasBorder = true,
                BorderColor = Color.Gray,
                XAlign = TextAlignment.Center,
                WidthRequest = 300,
                HorizontalOptions = LayoutOptions.Center
            };

            Entry lbLastName = new ExtendedEntry() {
                Placeholder = "Last Name",
                HasBorder = true,
                BorderColor = Color.Gray,
                XAlign = TextAlignment.Center,
                WidthRequest = 300,
                HorizontalOptions = LayoutOptions.Center
            };

            Entry lbEmail = new ExtendedEntry() {
                Placeholder = "Email",
                HasBorder = true,
                BorderColor = Color.Gray,
                XAlign = TextAlignment.Center,
                Keyboard = Keyboard.Email,
                WidthRequest = 300,
                HorizontalOptions = LayoutOptions.Center
            };

            Entry lbPassword = new ExtendedEntry() {
                Placeholder = "Password",
                BorderColor = Color.Gray,
                IsPassword = true,
                HasBorder = true,
                XAlign = TextAlignment.Center,
                WidthRequest = 300,
                HorizontalOptions = LayoutOptions.Center
            };

            Entry lbPasswordConfirm = new ExtendedEntry() {
                Placeholder = "Confirm Password",
                IsPassword = true,
                HasBorder = true,
                BorderColor = Color.Gray,
                XAlign = TextAlignment.Center,
                WidthRequest = 300,
                HorizontalOptions = LayoutOptions.Center
            };

            Button btnRegister = new Button()
            {
                Text = "REGISTER",
                TextColor = Color.White,
                FontSize = 18,
                BorderRadius = 80,
                BackgroundColor = Color.Green,
                WidthRequest = 280,
                HorizontalOptions = LayoutOptions.Center
            };

            Button btnCancel = new Button()
            {
                Text = "CANCEL",
                TextColor = Color.White,
                FontSize = 18,
                BorderRadius = 80,
                BackgroundColor = Color.Red,
                WidthRequest = 280,
                HorizontalOptions = LayoutOptions.Center
            };

            btnRegister.Clicked += BtnRegister_Clicked;
            btnCancel.Clicked += BtnCancel_Clicked;

            EntriesPanel.Children.Add(lbName);
            EntriesPanel.Children.Add(lbLastName);
            EntriesPanel.Children.Add(lbEmail);
            EntriesPanel.Children.Add(lbPassword);
            EntriesPanel.Children.Add(lbPasswordConfirm);
            
            ButtonsPanel.Children.Add(btnRegister);
            ButtonsPanel.Children.Add(btnCancel);

            MainPanel.Children.Add(EntriesPanel);
            MainPanel.Children.Add(ButtonsPanel);

            this.Content = MainPanel;
        }

        private void BtnCancel_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage.Navigation.PopAsync();           
        }

        private async void BtnRegister_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HomePage() { Title = "Home Page" });
        }
    }
}
