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
                Spacing = 60,
                VerticalOptions = LayoutOptions.Start
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
                Spacing = 2,
                VerticalOptions = LayoutOptions.Center
            };

            Label lbCardNumber = new Label
            {
                FontSize = 14,
                HorizontalOptions = LayoutOptions.Start,
                Text = "Card Number"
            };

            Entry entCardNumber = new ExtendedEntry()
            {
                Placeholder = "",
                HasBorder = true,
                BorderColor = Color.Gray,
                XAlign = TextAlignment.Center,
                WidthRequest = 300,
                HorizontalOptions = LayoutOptions.Center
            };

            Label lbCardMonth = new Label
            {
                FontSize = 14,
                HorizontalOptions = LayoutOptions.Start,
                Text = "MM/YY"
            };

            Entry entDate = new ExtendedEntry()
            {                
                Placeholder = "",
                HasBorder = true,
                BorderColor = Color.Gray,
                XAlign = TextAlignment.Center,
                WidthRequest = 300,
                HorizontalOptions = LayoutOptions.Center
            };

            Label lbCardCode = new Label
            {
                FontSize = 14,
                HorizontalOptions = LayoutOptions.Fill,
                Text = "CVV"
            };

            Entry entCVV = new ExtendedEntry()
            {
                Placeholder = "",
                HasBorder = true,
                BorderColor = Color.Gray,
                XAlign = TextAlignment.Center,
                WidthRequest = 300,
                HorizontalOptions = LayoutOptions.Center
            };

            CardPanel.Children.Add(lbCardNumber);
            CardPanel.Children.Add(entCardNumber);
            CardPanel.Children.Add(lbCardMonth);
            CardPanel.Children.Add(entDate);
            CardPanel.Children.Add(lbCardCode);
            CardPanel.Children.Add(entCVV);
            InputsPanel.Children.Add(CardPanel);
            MainPanel.Children.Add(InputsPanel);
            Content = MainPanel;
        }
    }
}
