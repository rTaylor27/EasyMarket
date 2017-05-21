using Android.Locations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;
using Plugin.Geolocator;
using Windows.Devices.Geolocation;
using Android.OS;

namespace EasyMarket
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePageDetail : ContentPage
    {

        //private Plugin.Geolocator.Abstractions.Position lPosition;
        private Map map;
        private bool hasLocation;
        private bool hasEnded;

        public HomePageDetail()
        {
            InitializeComponent();
            hasEnded = false;

            //var result = getUserLocation();

            //while (!hasEnded) { }

            //if (!hasLocation)
            //{
            //    map = new Map(
            //        MapSpan.FromCenterAndRadius(
            //            new Position(10.0000000, -84.0000000), Distance.FromMiles(0.3)))
            //    {
            //        IsShowingUser = true,
            //        HeightRequest = 100,
            //        WidthRequest = 960,
            //        VerticalOptions = LayoutOptions.FillAndExpand
            //    };
            //}

            map = new Map(
                    MapSpan.FromCenterAndRadius(
                        new Position(10.0000000, -84.0000000), Distance.FromMiles(0.3)))
            {
                IsShowingUser = true,
                HeightRequest = 100,
                WidthRequest = 960,
                VerticalOptions = LayoutOptions.FillAndExpand
            };

            map.MapType = MapType.Hybrid;

            var slider = new Slider(1, 18, 1);
            slider.ValueChanged += (sender, e) =>
            {
                var zoomLevel = e.NewValue; // between 1 and 18
                var latlongdegrees = 360 / (Math.Pow(2, zoomLevel));
                map.MoveToRegion(new MapSpan(map.VisibleRegion.Center, latlongdegrees, latlongdegrees));
            };

            var stack = new StackLayout { Spacing = 0 };
            stack.Children.Add(map);
            stack.Children.Add(slider);
            Content = stack;
            //Console.WriteLine("Position Status: {0}", position.Timestamp);
            //Console.WriteLine("Position Latitude: {0}", position.Latitude);
            //Console.WriteLine("Position Longitude: {0}", position.Longitude);

            //Task task = Task.Factory.StartNew(() => getUserLocation());
            //Task.WaitAll(new[] { task });

            //await getUserLocation();

            //initPage();

            //map = new Map(
            //    MapSpan.FromCenterAndRadius(
            //        new Position(10.0000000, -84.0000000), Distance.FromMiles(0.3)))
            //{
            //    IsShowingUser = true,
            //    HeightRequest = 100,
            //    WidthRequest = 960,
            //    VerticalOptions = LayoutOptions.FillAndExpand
            //};

            ////var position = new Position(37, -122); // Latitude, Longitude
            ////map.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(position.Latitude, position.Longitude),
            ////                                            Distance.FromMiles(1)));
            ////var pin = new Pin
            ////{
            ////    Type = PinType.Place,
            ////    Position = position,
            ////    Label = "custom pin",
            ////    Address = "custom detail info"
            ////};
            ////map.Pins.Add(pin);

            //map.MapType = MapType.Hybrid;

            //var slider = new Slider(1, 18, 1);
            //slider.ValueChanged += (sender, e) => {
            //    var zoomLevel = e.NewValue; // between 1 and 18
            //    var latlongdegrees = 360 / (Math.Pow(2, zoomLevel));
            //    map.MoveToRegion(new MapSpan(map.VisibleRegion.Center, latlongdegrees, latlongdegrees));
            //};

            //var stack = new StackLayout { Spacing = 0 };
            //stack.Children.Add(map);
            //stack.Children.Add(slider);
            //Content = stack;
        }

        //public void initPage()
        //{

        //    Task task = getUserLocation();
        //    task.Wait();
        //    //await getUserLocation();
        //    //var task = getUserLocation();
        //    //task.Wait();
        //    //var result = task.Result;

        //    //map = new Map(
        //    //    MapSpan.FromCenterAndRadius(
        //    //        new Position(10.0000000, -84.0000000), Distance.FromMiles(0.3)))
        //    //{
        //    //    IsShowingUser = true,
        //    //    HeightRequest = 100,
        //    //    WidthRequest = 960,
        //    //    VerticalOptions = LayoutOptions.FillAndExpand
        //    //};

        //    //var position = new Position(37, -122); // Latitude, Longitude
        //    //map.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(position.Latitude, position.Longitude),
        //    //                                            Distance.FromMiles(1)));
        //    //var pin = new Pin
        //    //{
        //    //    Type = PinType.Place,
        //    //    Position = position,
        //    //    Label = "custom pin",
        //    //    Address = "custom detail info"
        //    //};
        //    //map.Pins.Add(pin);

            
        //}

        public async Task getUserLocation()
        {
            try
            {
                var locator = CrossGeolocator.Current;
                locator.DesiredAccuracy = 50;

                var position = await locator.GetPositionAsync(10000);
                if (position == null)
                {  
                    hasLocation = false;
                    hasEnded = true;
                    return;
                }

                map = new Map(
                MapSpan.FromCenterAndRadius(
                    new Position(position.Latitude, position.Longitude), Distance.FromMiles(0.3)))
                {
                    IsShowingUser = true,
                    HeightRequest = 100,
                    WidthRequest = 960,
                    VerticalOptions = LayoutOptions.FillAndExpand
                };

                hasLocation = true;
                hasEnded = true;
                //map.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(position.Latitude, position.Longitude), Distance.FromMiles(1)));

                //var time = ("Position Status: {0}" + position.Timestamp);
                //var lat = ("Position Latitude: {0}" + position.Latitude);
                //var lon = ("Position Longitude: {0}" + position.Longitude);
            }
            catch (Exception ex)
            {
               var str = ("Unable to get location, may need to increase timeout: " + ex);
            }
        }

    }
}
