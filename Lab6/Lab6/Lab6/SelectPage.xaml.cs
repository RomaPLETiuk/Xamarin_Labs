using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtonsoft.Json;
using System.IO;

namespace Lab6
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SelectPage : ContentPage
    {
        private string jsonFilePath;
        public SelectPage()
        {
            InitializeComponent();

            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
             jsonFilePath = Path.Combine(documentsPath, "older_books.json");

            //List<Book> olderBooks = db.GetBooksOlderThan10Years();
            //int totalBooksCount = db.GetBooks().Count;
            //int olderBooksCount = olderBooks.Count;

            //double percentage = CalculatePercentage(olderBooksCount, totalBooksCount);
            //BookListView.ItemsSource = olderBooks; // Встановлюємо джерело даних для таблиці
            //// Відобразіть отримані дані в інтерфейсі, наприклад, у якийсь Label чи текстовому полі
            //PercentageLabel.Text = $"Older books: {percentage:F2}% of {totalBooksCount} books";


            int currentYear = DateTime.Now.Year;
                int tenYearsAgo = currentYear - 10;


                var olderBooks = App.Db.GetBooksOlderThan10Years();
                int totalBooksCount = App.Db.GetBooks().Count;
                int olderBooksCount = olderBooks.Count;

                double percentage = CalculatePercentage(olderBooksCount, totalBooksCount);

                BookListView.ItemsSource = olderBooks; // Встановлюємо джерело даних для таблиці
                PercentageLabel.Text = $"Older books: {percentage:F2}% of {totalBooksCount} books";

            //string jsonFileName = "older_books.json";

            //// Створення JSON-рядка зі списком книг
            //string json = JsonConvert.SerializeObject(olderBooks);

            //// Запис JSON-рядка у файл
            //File.WriteAllText(jsonFileName, json);
            SaveDataToJson(olderBooks);


        }

        private double CalculatePercentage(int olderBooksCount, int totalBooksCount)
        {
            if (totalBooksCount == 0)
                return 0.0;

            return (double)olderBooksCount / totalBooksCount * 100.0;
        }
       

        private void SaveDataToJson(List<Book> olderBooks)
        {
            

            // Створення JSON-рядка зі списком книг
            string json = JsonConvert.SerializeObject(olderBooks);

            // Запис JSON-рядка у файл
            File.WriteAllText(jsonFilePath, json);
        }

        private void ShowLabelClicked(object sender, EventArgs e)
        {
           // string jsonFileName = "older_books.json"; // Шлях до вашого JSON-файлу

            try
            {
                if (File.Exists(jsonFilePath))
                {
                    string json = File.ReadAllText(jsonFilePath);

                    // Встановлюємо вміст файлу як текст для Label
                    YourLabelName.Text = json;
                }
                else
                {
                    // Обробка випадку, коли файл не знайдено
                    YourLabelName.Text = "Файл не знайдено.";
                }
            }
            catch (Exception ex)
            {
                // Обробка можливих помилок при роботі з файлом
                YourLabelName.Text = $"Помилка: {ex.Message}";
            }
        }


    }
}