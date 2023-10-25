using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace _5Lab
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CustomAlertPage : ContentPage
	{
        public CustomAlertPage(string message, string imageUrl)
        {
            InitializeComponent();
            messageLabel.Text = message;
            image.Source = imageUrl;
        }
    }
}