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
public partial class SecondPage : ContentPage

{

        private CarouselView photoCarousel;
        private int currentIndex = 0;

        public SecondPage()
    {
        InitializeComponent();
            // Оголосити CarouselView
            photoCarousel = new CarouselView
            {
                ItemsSource = GetPhotoCollection(),
                ItemTemplate = new DataTemplate(() =>
                {
                    var image = new Image();
                    image.SetBinding(Image.SourceProperty, "Url");

                    var doubleTapGestureRecognizer = new TapGestureRecognizer();
                    doubleTapGestureRecognizer.Tapped += OnImageDoubleTapped;
                    doubleTapGestureRecognizer.NumberOfTapsRequired = 2;
                    image.GestureRecognizers.Add(doubleTapGestureRecognizer);
                    return image;
                })
            };

            // Додати CarouselView на сторінку
            Content = photoCarousel;

            // Обробка жестів свайпу
            var gestureRecognizer = new SwipeGestureRecognizer();
            gestureRecognizer.Swiped += OnSwiped;
            gestureRecognizer.Direction = SwipeDirection.Left | SwipeDirection.Right;
            photoCarousel.GestureRecognizers.Add(gestureRecognizer);
        }

        private List<PhotoItem> GetPhotoCollection()
        {
            // Отримати список фотографій
            return new List<PhotoItem>
        {
            new PhotoItem("https://kalix.club/uploads/posts/2022-12/1671534022_kalix-club-p-oboi-na-noutbuk-kotiki-krasivo-2.jpg"),
            new PhotoItem("https://ichef.bbci.co.uk/news/640/cpsprodpb/68C3/production/_93791862_thinkstockphotos-585524268.jpg"),
            new PhotoItem("https://zoobonus.ua/storage/news/inner-page/ggkcvQHEZmU3MM9YwFvHG9gCfBiiBccfJt1UuI1E.jpg")
        };
        }

        private void OnSwiped(object sender, SwipedEventArgs e)
        {
            if (e.Direction == SwipeDirection.Left && currentIndex < ((List<PhotoItem>)photoCarousel.ItemsSource).Count - 1)
            {
                currentIndex++;
                photoCarousel.Position = currentIndex;
            }
            else if (e.Direction == SwipeDirection.Right && currentIndex > 0)
            {
                currentIndex--;
                photoCarousel.Position = currentIndex;
            }
        }

        private void OnImageDoubleTapped(object sender, EventArgs e)
        {
            if (sender is Image image)
            {
                // Перевіряємо, чи зображення вже масштабоване
                if (image.Scale == 1)
                {
                    // Збільшуємо масштаб до 2
                    image.Scale = 2;
                }
                else
                {
                    // Повертаємо масштаб до початкового значення
                    image.Scale = 1;
                }
            }
        }

    }






    public class PhotoItem
    {
        public string Url { get; }

        public PhotoItem(string url)
        {
            Url = url;
        }
    }
}