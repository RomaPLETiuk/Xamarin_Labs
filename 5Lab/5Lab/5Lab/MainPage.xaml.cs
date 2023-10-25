using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace _5Lab
{
  



    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

          
        }
        private async void OnAuthorButtonClicked(object sender, EventArgs e)
        {
            string message = "Плетюк Роман Михайлович  ";
            string imageUrl = "https://i.pinimg.com/474x/4b/c0/a8/4bc0a8ec6f24aaeef96c127d1d461151.jpg"; // 

            var customAlertPage = new CustomAlertPage(message, imageUrl);

            await Navigation.PushModalAsync(customAlertPage);
        }





        private  void OnSelectFolderButtonClicked(object sender, EventArgs e)
        {
            SecondPage secondPage = new SecondPage();

            // Викликати метод Navigation.PushAsync, щоб перейти на SecondPage
            Navigation.PushAsync(secondPage);



        }
        private void OnSelectFolderButtonClicked2(object sender, EventArgs e)
        {
            Page1 Page1 = new Page1();

            // Викликати метод Navigation.PushAsync, щоб перейти на SecondPage
            Navigation.PushAsync(Page1);



        }




    }
}
