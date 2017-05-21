using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using EasyMarket.Classes;

namespace EasyMarket.Pages
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Payment : ContentPage
    {
        public Payment()
        {
            InitializeComponent();
            BindingContext = new PaymentPageViewModel();
            
        }

        private void LVPaymentItems_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as BasicPageMenuItem;
            if (item == null)
                return;
            if (!item.Title.Equals("Cash"))
            {
                var page = (Page)Activator.CreateInstance(item.TargetType);
                page.Title = "Add Credit Card";
                Navigation.PushAsync(new NavigationPage(page));
            }
            else
            {
                DisplayAlert("Payment Method", "You have change your payment method to cash","OK");
            }
        }
    }

    class PaymentPageViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<BasicPageMenuItem> MenuItems { get; }
        public PaymentPageViewModel()
        {
            MenuItems = new ObservableCollection<BasicPageMenuItem>(new[]
            {
                    new BasicPageMenuItem { Id = 0, Title = "Cash", Icon = "cash128.png", TargetType = typeof(HomePage) },
                    new BasicPageMenuItem { Id = 1, Title = "Credit Card", Icon = "creditcard2128.png", TargetType = typeof(AddCard) },
                });
        }
        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName]string propertyName = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    class PaymentViewModel : INotifyPropertyChanged
    {

        public PaymentViewModel()
        {
            IncreaseCountCommand = new Command(IncreaseCount);
        }

        int count;

        string countDisplay = "You clicked 0 times.";
        public string CountDisplay
        {
            get { return countDisplay; }
            set { countDisplay = value; OnPropertyChanged(); }
        }

        public ICommand IncreaseCountCommand { get; }

        void IncreaseCount() =>
            CountDisplay = $"You clicked {++count} times";
        
        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName]string propertyName = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        
    }
}
