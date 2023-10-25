using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using static System.Net.Mime.MediaTypeNames;


namespace App9_1
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            //latitudeEntry.Text = $"Latitude: {50.38142387863212}";
            //longitudeEntry.Text = $"Longitude: {30.495883248758602}";

            //// Set an initial map position
            //var initialPosition = new Position(51.5033640, -0.1276250); // London, UK
            //openStreetMap.MoveToRegion(MapSpan.FromCenterAndRadius(initialPosition, Distance.FromMiles(1)));

            //// Add a custom pin (marker)
            //var customPin = new Pin
            //{
            //    Type = PinType.Place,
            //    Position = new Position(51.5033640, -0.1276250),
            //    Label = "London",
            //    Address = "The city of London"
            //};
            //openStreetMap.Pins.Add(customPin);
        }


        private async void SearchButton_Clicked(object sender, EventArgs e)
        {
            var cityName = cityEntry.Text;

            if (!string.IsNullOrEmpty(cityName))
            {
                var locations = await Geocoding.GetLocationsAsync(cityName);

                if (locations != null && locations.Any())
                {
                    var location = locations.First();
                    var position = new Position(location.Latitude, location.Longitude);

                    map.MoveToRegion(MapSpan.FromCenterAndRadius(position, Distance.FromMiles(0.1)));

                    var pin = new Pin
                    {
                        Type = PinType.Place,
                        Position = position,
                        Label = cityName,
                        Address = "Введене місто"
                    };
                    map.Pins.Add(pin);
                }
                else
                {
                    // Відобразити повідомлення про помилку, якщо місто не знайдено.
                }
            }
        }






        private async void MeClicked(object sender, EventArgs e)
        {
            

            var Page1= new Page1();

            await Navigation.PushModalAsync(Page1);
        }

        private async void OnGetLocationClicked(object sender, EventArgs e)
        {
            try
            {
                var location = await Xamarin.Essentials.Geolocation.GetLocationAsync();
                if (location != null)
                {
                    var latitude = location.Latitude;
                    var longitude = location.Longitude;
                    latitudeLabel.Text = $"Latitude: {latitude}";
                    longitudeLabel.Text = $"Longitude: {longitude}";

                    // Отримати карту та встановити маркер на місці розташування
                    map.MoveToRegion(MapSpan.FromCenterAndRadius(
                        new Position(latitude, longitude), Distance.FromMiles(0.1)));

                    var pin = new Pin
                    {
                        Type = PinType.Place,
                        Position = new Position(latitude, longitude),   //Position = new Position(50.38142387863212, 30.495883248758602),
                        Label = "Моя локація",
                        Address = "Тут я"
                    };
                    map.Pins.Add(pin);
                }
                else
                {
                    latitudeLabel.Text = "Unable to determine location.";
                    longitudeLabel.Text = "Unable to determine location.";
                }
            }
            catch (Exception ex)
            {
                // Handle exception
            }
        }





        private  void  OnGetInsertedLocationClicked(object sender, EventArgs e)
        {
            try
            {

                    
                
                   // latitudeEntry.Text = $"Latitude: {50.38142387863212}";
                   // longitudeEntry.Text = $"Longitude: {30.495883248758602}";




                    // Отримати карту та встановити маркер на місці розташування
                    map.MoveToRegion(MapSpan.FromCenterAndRadius(
                      new Position(Double.Parse(latitudeEntry.Text), Double.Parse(longitudeEntry.Text)), Distance.FromMiles(0.1)));

                    var pin = new Pin
                    {
                        Type = PinType.Place,
                        Position = new Position(Double.Parse(latitudeEntry.Text), Double.Parse(longitudeEntry.Text)),
                        Label = "Вибране місце",
                        Address = "За координатами"
                    };
                    map.Pins.Add(pin);
                
                   
                
            }
            catch (Exception ex)
            {
                DisplayAlert(Title, ex.Message, "ok");
            }
        }


    }
}
