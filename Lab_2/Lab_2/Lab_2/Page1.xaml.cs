using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtonsoft.Json;
using System.IO;

namespace Lab_2
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Page1 : ContentPage
	{
		public Page1 (string content)
		{

          
            InitializeComponent ();
            //string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "results.json");
            //if (File.Exists(filePath))
            //{
            //    string json = File.ReadAllText(filePath);
            //    List<CalculationResult> results = JsonConvert.DeserializeObject<List<CalculationResult>>(json);

            //    listView.ItemsSource = results;
            //}
            ContentLabel.Text = content;




        }

        private async void OnBackButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync(); // Повернутися назад на попередню сторінку
        }
    }
}