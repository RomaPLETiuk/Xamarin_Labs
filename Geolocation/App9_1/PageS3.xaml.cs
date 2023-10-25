using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace App9_1
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PageS3 : ContentPage
	{
		public PageS3 ()
		{
			InitializeComponent ();
		}

       


        
        private Position endLocation;

        private void Map_Tapped(object sender, MapClickedEventArgs e)
        {
            endLocation = new Position(e.Position.Latitude, e.Position.Longitude);

            var endPin = new Pin
            {
                Position = endLocation,
                Label = "End"
            };

            map.Pins.Add(endPin);

            // Тут ви також можете оновити маршрут або інші дії, які вам потрібні

            //// Оновлення карти, якщо потрібно
            //var bounds = MapSpan.FromCenterAndRadius(endLocation, Distance.FromMiles(1.0));
            //map.MoveToRegion(bounds);
        }


        private async void Clicked_3S(object sender, EventArgs e)
        {



            //var address = addressEntry.Text;
            //var approximateLocations = await geocoder.GetPositionsForAddressAsync(address);
            //var approximateLocation = approximateLocations.FirstOrDefault();
            var location = await Geolocation.GetLocationAsync();
            var lat = location.Latitude;
            var lon = location.Longitude;
            

            Position startLocation =   new Position(lat, lon);

            if (endLocation != null)
                {
                   
                    

                    var startPin = new Pin
                    {
                        Position = startLocation,
                        Label = "Start"
                    };

                    var endPin = new Pin
                    {
                        Position = endLocation,
                        Label = "End"
                    };

                    map.Pins.Add(startPin);
                    map.Pins.Add(endPin);

                    var route = new Polyline
                    {
                        StrokeColor = Color.Red,
                        StrokeWidth = 5,
                    };

                    var distance = Location.CalculateDistance(
                            startLocation.Latitude, startLocation.Longitude,
                            endLocation.Latitude, endLocation.Longitude, DistanceUnits.Kilometers);

                    route.Geopath.Add(startLocation);
                    route.Geopath.Add(endLocation);

                    map.MapElements.Add(route);

                    var bounds = MapSpan.FromCenterAndRadius(startLocation, Distance.FromMiles(1.0));
                    map.MoveToRegion(bounds);

                    await DisplayAlert("Відстань", $"Відстань між точками: {distance} км", "OK");
                }
                else
                {
                    await DisplayAlert("Помилка", "Не вдалося знайти координати для вибраної точки.", "OK");
                }
            
        }






    }
}