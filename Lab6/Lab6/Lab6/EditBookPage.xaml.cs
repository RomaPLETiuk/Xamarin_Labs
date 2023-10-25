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
	public partial class EditBookPage : ContentPage
	{
        private Book bookToEdit; // Об'єкт книги, яку ми редагуємо

        public EditBookPage(Book book)
        {
            InitializeComponent();

            bookToEdit = book;

            // Заповнюємо поля введення поточними значеннями книги
            TitleEntry.Text = bookToEdit.Title;
            AutorEntry.Text = bookToEdit.Autor;
            YearEntry.Text = bookToEdit.Year.ToString();
            PageEntry.Text = bookToEdit.Page.ToString();
        }

        private void Save_Clicked(object sender, EventArgs e)
        {
            // Оновлюємо дані книги на основі введених даних
            bookToEdit.Title = TitleEntry.Text;
            bookToEdit.Autor = AutorEntry.Text;
            bookToEdit.Year = int.Parse(YearEntry.Text);
            bookToEdit.Page = int.Parse(PageEntry.Text);

            // Оновлюємо запис у базі даних
            App.Db.UpdateBook(bookToEdit);

            //using (var db = App.Db)
            //{
            //    db.UpdateBook(bookToEdit);
            //}

            DisplayAlert("Success", "Book updated successfully", "OK");

            // Повертаємося на попередню сторінку або оновлюємо список книг на цій сторінці
            Navigation.PopAsync();
        }
    }
}