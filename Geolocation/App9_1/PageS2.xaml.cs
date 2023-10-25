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
	public partial class PageS2 : ContentPage
	{
		public PageS2 ()
		{
			InitializeComponent ();
		}


        private async void Clicked_2S(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(addressEntry.Text))
            {
                var geocoder = new Geocoder();

                var address = addressEntry.Text;
                var approximateLocations = await geocoder.GetPositionsForAddressAsync(address);
                var approximateLocation = approximateLocations.FirstOrDefault();


                if (approximateLocation != null)
                {
                    var location = await Geolocation.GetLocationAsync();
                    var lat = location.Latitude;
                    var lon = location.Longitude;
                    var startLocation = new Position(lat, lon);
                    var endLocation = approximateLocation;

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
                    await DisplayAlert("Помилка", "Не вдалося знайти координати для введеної адреси.", "OK");
                }
            }
            else
            {
                await DisplayAlert("Помилка", "Будь ласка, введіть адресу.", "OK");
            }
        }

    }
}