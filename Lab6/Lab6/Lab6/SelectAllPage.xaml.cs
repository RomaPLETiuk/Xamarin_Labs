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
    public partial class SelectAllPage : ContentPage
    {
        public SelectAllPage()
        {
            InitializeComponent();

            var AllBoook = App.Db.GetBooks();

            BookListView.ItemsSource = AllBoook;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            var AllBoook = App.Db.GetBooks();

            BookListView.ItemsSource = AllBoook;
        }

        private async void BookListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item is Book selectedBook)
            {
                // Відкрити сторінку редагування книги та передати об'єкт книги
                await Navigation.PushAsync(new EditBookPage(selectedBook));
            }

                 // Скидання виділення елементу списку
                 ((ListView)sender).SelectedItem = null;
        }

    }
}