using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace App9_1
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PageS1 : ContentPage
	{
		public PageS1 ()
		{
			InitializeComponent ();
		}

        private async void Clicked_1S(object sender, EventArgs e)
        {
            if (double.TryParse(latitudeEntry.Text, out double latitude) &&
                double.TryParse(longitudeEntry.Text, out double longitude))
            {

                var location = await Geolocation.GetLocationAsync();
                var lat = location.Latitude;
                var lon = location.Longitude;
                var startLocation = new Position(lat, lon);
                    var endLocation = new Position(latitude, longitude);

                // Создание маркера для начальной и конечной точек
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

        }
        


    }
}