using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace EasyMarket.Pages
{
    public class AddCard : ContentPage
    {
        public AddCard()
        {
            StackLayout MainPanel = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                Spacing = 40,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            StackLayout InputsPanel = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                Spacing = 20,
                VerticalOptions = LayoutOptions.Center
            };

            StackLayout CardPanel = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                Spacing = 10,
                VerticalOptions = LayoutOptions.Center
            };

            // Dictionary to get Country from color name.
            Dictionary<string, string> dcCountry = new Dictionary<string, string>
            {
                { "Costa Rica", "Costa Rica" }, { "Panama", "Panama" },
                { "United States", "United States" }
            };

            Entry entCardNumber = new ExtendedEntry()
            {
                Placeholder = "Card Number",
                HasBorder = true,
                BorderColor = Color.Gray,
                XAlign = TextAlignment.Center,
                WidthRequest = 300,
                HorizontalOptions = LayoutOptions.Center
            };

            DatePicker datePicker = new DatePicker
            {
                Format = "D",
                VerticalOptions = LayoutOptions.Center,
                Date = DateTime.Today
            };           

            Entry entCVV = new ExtendedEntry()
            {
                Placeholder = "CVV",
                HasBorder = true,
                BorderColor = Color.Gray,
                XAlign = TextAlignment.Center,
                WidthRequest = 300,
                HorizontalOptions = LayoutOptions.Center
            };                   
            
            Picker picker = new Picker
            {
                Title = "Country",
                VerticalOptions = LayoutOptions.Center
            };

            foreach (string colorName in dcCountry.Keys)
            {
                picker.Items.Add(colorName);
            }

            // Create BoxView for displaying picked Color
            BoxView boxView = new BoxView
            {
                WidthRequest = 150,
                HeightRequest = 150,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };

            //HANDLE THE EVENT.
            picker.SelectedIndexChanged += (sender, args) =>
            {
                if (picker.SelectedIndex == -1)
                {
                    
                }
                else
                {
                    string strSelectedIndex = picker.Items[picker.SelectedIndex];
                    string strValue = dcCountry[strSelectedIndex];
                }
            };

            Entry entZIP = new ExtendedEntry()
            {
                Placeholder = "ZIP Code",
                HasBorder = true,
                BorderColor = Color.Gray,
                XAlign = TextAlignment.Center,
                WidthRequest = 300,
                HorizontalOptions = LayoutOptions.Center
            };

            CardPanel.Children.Add(entCardNumber);            
            CardPanel.Children.Add(entCVV);
            CardPanel.Children.Add(entZIP);
            CardPanel.Children.Add(datePicker);
            CardPanel.Children.Add(new StackLayout
            {
                Spacing = 1,
                Children =
                {
                    picker,
                    boxView
                }
            });
            
            InputsPanel.Children.Add(CardPanel);
            InputsPanel.Children.Add(new Button
            {
                Text = "Add Card",
                BackgroundColor = Color.Gray,
                TextColor = Color.White
            });
            MainPanel.Children.Add(InputsPanel);
            Content = MainPanel;
        }
    }
}
