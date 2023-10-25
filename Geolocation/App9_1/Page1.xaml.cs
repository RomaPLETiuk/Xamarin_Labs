using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App9_1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage
    {
        public Page1()
        {
            InitializeComponent();
            string message = "Roman Pletiuk";
            string imageUrl = "https://img.freepik.com/premium-photo/siberian-kitten-on-a-blue-background-3d-illustration_890887-9916.jpg";
            messageLabel.Text = message;
            image.Source = imageUrl;
        }


        private async void S1Clicked(object sender, EventArgs e)
        {


            var PageS1 = new PageS1();

            await Navigation.PushModalAsync(PageS1);
        }

        private async void S2Clicked(object sender, EventArgs e)
        {


            var PageS2 = new PageS2();

            await Navigation.PushModalAsync(PageS2);
        }


        private async void S3Clicked(object sender, EventArgs e)
        {


            var PageS3 = new PageS3();

            await Navigation.PushModalAsync(PageS3);
        }
    }
}