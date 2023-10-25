using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Lab6
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddPage : ContentPage
    {
        public AddPage()
        {
            InitializeComponent();
        }

        //private void SaveBook_Clicked(object sender, EventArgs e)
        //{

        //    string title = TitleEntry.Text;
        //    string autor = AutorEntry.Text;
        //    int year = int.Parse(YearEntry.Text);
        //    int page = int.Parse(PageEntry.Text);

        //    Book newBook = new Book
        //    {
        //        Title = title,
        //        Autor = autor,
        //        Year = year,
        //        Page = page
        //    };

        //    using (var db = App.Db)
        //    {
        //        db.conn.Insert(newBook);
        //    }

        //    DisplayAlert("Success", "Book added successfully", "OK");

        //    // Повернутися на попередню сторінку або оновити список книг на цій сторінці
        //    Navigation.PopAsync();
        //}

        private void SaveBook_Clicked(object sender, EventArgs e)
        {
            string title = TitleEntry.Text;
            string autor = AutorEntry.Text;
            int year;
            int page;

            if (int.TryParse(YearEntry.Text, out year) && int.TryParse(PageEntry.Text, out page))
            {
                Book newBook = new Book
                {
                    Title = title,
                    Autor = autor,
                    Year = year,
                    Page = page
                };

                 App.Db.SavePersonAsync(newBook);
                

                DisplayAlert("Success", "Book added successfully", "OK");

                // Повернутися на попередню сторінку або оновити список книг на цій сторінці
                Navigation.PopAsync();
            }
            else
            {
                DisplayAlert("Error", "Invalid year or page input", "OK");
            }
        }

    }
}