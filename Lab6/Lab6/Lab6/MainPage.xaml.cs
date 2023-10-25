using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Newtonsoft.Json;
using System.IO;
using Xamarin.Essentials;
using System.Net.NetworkInformation;
using Xamarin.Forms.Maps;

namespace Lab6
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            //ReadContacts();
        }



        private async void OnGetLocationClicked(object sender, EventArgs e)
        {
            try
            {
                var location = await Geolocation.GetLocationAsync();
                if (location != null)
                {
                    var latitude = location.Latitude;
                    var longitude = location.Longitude;

                    //Position position = new Position(latitude, longitude);
                    //MapSpan mapSpan = new MapSpan(position, 0.01, 0.01);
                    //Map map = new Map(mapSpan);

                    

                    map.MoveToRegion(MapSpan.FromCenterAndRadius(
                        new Position(latitude, longitude), Distance.FromMiles(1)));

                    var pin = new Pin
                    {
                        Position = new Position(latitude, longitude),
                        Address = "The city with a boardwalk",
                        Label = "My Location"
                    };
                    //map.Pins.Clear();
                    map.Pins.Add(pin);

                    locationLabel.Text = $"Latitude: {latitude}, Longitude: {longitude}";
                }
                else
                {
                    locationLabel.Text = "Unable to determine location.";
                    await DisplayAlert("Location Error", "Unable to determine location.", "OK");
                }
            }
            catch (Exception ex)
            {
                // Обробка помилок
            }
        }





    }
}

//public class ContactViewModel
//{
//    public string DisplayName { get; set; }
//    public string PhoneNumber { get; set; }
//    public string Email { get; set; }
//}





//private async void ReadContacts()
//{
//    try
//    {
//        var contacts = await Contacts.GetAllAsync();
//        var contactList = new List<ContactViewModel>();

//        foreach (var contact in contacts)
//        {
//            contactList.Add(new ContactViewModel
//            {
//                DisplayName = contact.DisplayName,
//                PhoneNumber = contact.Phones.FirstOrDefault()?.ToString(),
//                Email = contact.Emails.FirstOrDefault()?.ToString()
//            });
//        }

//        contactListView.ItemsSource = contactList;
//    }
//    catch (Exception ex)
//    {
//        // Обробка помилок, якщо доступ до контактів заборонений або інші помилки.
//        Console.WriteLine(ex.Message);
//    }
//}







//private void ShowContactsButton_Clicked(object sender, EventArgs e)
//{
//    try
//    {
//        var contacts = Contacts.GetAllAsync().GetAwaiter().GetResult();
//        var contactList = new List<ContactViewModel>();

//        foreach (var contact in contacts)
//        {
//            var phoneNumbers = contact.Phones.Where(phone => phone.PhoneNumber.EndsWith("7"));
//            if (phoneNumbers.Any())
//            {
//                contactList.Add(new ContactViewModel
//                {
//                    DisplayName = contact.DisplayName,
//                    PhoneNumber = string.Join(", ", phoneNumbers),
//                    Email = contact.Emails.FirstOrDefault()?.ToString()
//                });
//            }
//        }

//        if (contactList.Count > 0)
//        {
//            contactListView.ItemsSource = contactList;
//        }
//        else
//        {
//            DisplayAlert("Немає контактів", "Не знайдено контактів з номерами, що закінчуються на 7.", "OK");
//        }
//    }
//    catch (Exception ex)
//    {
//        // Обробка помилок, якщо доступ до контактів заборонений або інші помилки.
//        DisplayAlert("Немає контактів", ex.Message, "OK");
//    }
//}



//private void AddClicked(object sender, EventArgs e)
//{
//    AddPage secondPage = new AddPage();

//    // Викликати метод Navigation.PushAsync, щоб перейти на SecondPage
//    Navigation.PushAsync(secondPage);

//}
//private void SelectClicked(object sender, EventArgs e)
//{
//    SelectPage ndPage = new SelectPage();

//    // Викликати метод Navigation.PushAsync, щоб перейти на SecondPage
//    Navigation.PushAsync(ndPage);

//}


//    private void SelectAllClicked(object sender, EventArgs e)
//{
//    SelectAllPage dPage = new SelectAllPage();

//    // Викликати метод Navigation.PushAsync, щоб перейти на SecondPage
//    Navigation.PushAsync(dPage);

//}

//private  void ShowLabelClicked(object sender, EventArgs e)
//{
//    string jsonFileName = "older_books.json"; // Шлях до вашого JSON-файлу

//    try
//    {
//        if (File.Exists(jsonFileName))
//        {
//            string json = File.ReadAllText(jsonFileName);

//            // Встановлюємо вміст файлу як текст для Label
//            YourLabelName.Text = json;
//        }
//        else
//        {
//            // Обробка випадку, коли файл не знайдено
//            YourLabelName.Text = "Файл не знайдено.";
//        }
//    }
//    catch (Exception ex)
//    {
//        // Обробка можливих помилок при роботі з файлом
//        YourLabelName.Text = $"Помилка: {ex.Message}";
//    }
//}


//private async void OnGetLocationClicked(object sender, EventArgs e)
//{
//    try
//    {
//        var location = await Geolocation.GetLocationAsync();
//        if (location != null)
//        {
//            latitudeLabel.Text = $"Latitude: {location.Latitude}";
//            longitudeLabel.Text = $"Longitude: {location.Longitude}";
//        }
//        else
//        {
//            latitudeLabel.Text = "Unable to determine location.";
//            longitudeLabel.Text = "Unable to determine location.";
//        }
//    }
//    catch (Exception ex)
//    {
//        // Handle exception
//    }
//}

