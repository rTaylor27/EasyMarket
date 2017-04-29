using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EasyMarket
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePageMaster : ContentPage
    {
        public ListView ListView => ListViewMenuItems;
        public Image image = new Image { Source = "header.png" };

        public HomePageMaster()
        {
            InitializeComponent();
            BindingContext = new HomePageMasterViewModel();
        }

        class HomePageMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<HomePageMenuItem> MenuItems { get; }
            public HomePageMasterViewModel()
            {
                MenuItems = new ObservableCollection<HomePageMenuItem>(new[]
                {
                    new HomePageMenuItem { Id = 0, Title = "Payment", Icon = "creditcard128.png" },
                    new HomePageMenuItem { Id = 1, Title = "Profile", Icon = "profile128.png" },
                    new HomePageMenuItem { Id = 2, Title = "Buy", Icon = "buy128.png" },
                    new HomePageMenuItem { Id = 3, Title = "Rides", Icon = "rides128.png" },
                    new HomePageMenuItem { Id = 4, Title = "Settings", Icon = "settings128.png" },
                });
            }
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName]string propertyName = "") =>
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
