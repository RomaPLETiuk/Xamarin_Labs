using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Newtonsoft.Json;
using System.IO;

namespace Lab_2
{
    public class CalculationResult
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Result { get; set; }
    }



    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }



        private void CalculateButton_Clicked(object sender, EventArgs e)
        {
            var results = new List<CalculationResult>();

            if (double.TryParse(NumberEntry.Text, out double start) &&
                double.TryParse(NumberEntry2.Text, out double end) &&
                double.TryParse(NumberEntry3.Text, out double step))
            {
                ResultLabel.Text = "Results:\n";
                double finalRez = 0.0;
                for (double x = start; x <= end; x += step)
                {
                    double y = CalculateY(x); // Calculate the y value based on x
                    double result = CalculateFunctionValue(x, y); // Calculate the function value
                    finalRez = result;
                    //ResultLabel.Text += $"x = {x}, y = {y}, result = {result}\n";

                    results.Add(new CalculationResult { X = x, Y = y, Result = result });
                }
                ResultLabel.Text += $" {finalRez}\n";

                string json = JsonConvert.SerializeObject(results);
                string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "results.json");
                File.WriteAllText(filePath, json);
            }
            else
            {
                ResultLabel.Text = "Invalid input. Please enter valid numeric values.";
            }
        }

        private double CalculateY(double x)
        {
            // You can implement the y calculation here based on your formula
            // For example, y = some_expression_based_on_x
            return Math.Sin(x); // Just a placeholder example
        }

        private double CalculateFunctionValue(double x, double y)
        {
            int a = 1; int b = 1; int c = 1;
            // Implement your given function here
            // Replace 'a', 'b', and 'c' with actual values
            return (Math.Pow(Math.Tan(y), 3) + Math.Pow(Math.Sin(x * Math.Sqrt(b - c)), 5)) / Math.Sqrt(a - b + c);
        }

        

        private async void ReadFileButton_Clicked(object sender, EventArgs e)
        {
            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "results.json");
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);

                // Відкриття нової сторінки для відображення змісту файлу
                await Navigation.PushAsync(new Page1(json));
            }
            else
            {
                await DisplayAlert("Помилка", "Файл не знайдено", "OK");
            }
        }



        private async void DrawGraphButton_Clicked(object sender, EventArgs e)
        {
            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "results.json");
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);

                await Navigation.PushAsync(new GraphPage(json));
            }
            else
            {
                await DisplayAlert("Помилка", "Файл не знайдено", "OK");
            }
        }


        private void ShowImageCheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            ImageLabel.IsVisible = e.Value;
            SampleImage.IsVisible = e.Value;
        }
    }
}
