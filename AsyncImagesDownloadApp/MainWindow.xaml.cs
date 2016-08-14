using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace AsyncImagesDownloadApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        async void startButtonClick(object sender, RoutedEventArgs e)
        {
            resultsTextBox.Clear();
            IEnumerable<Data> data = BindData();

            var asyncImagesDownloader = new AsyncImagesDownloader(data);

            try
            {
                data = await asyncImagesDownloader.GetDownloadedData();

                ShowThumbnails(data.ToList());

                resultsTextBox.Text += "Downloads complete.\r\n";
            }

            catch (Exception)
            {
                ShowDefaultThumbnails();
                resultsTextBox.Text += "Downloads failed. Connection error, incorrect image URL or download canceled!\r\n";
            }
        }

        private void ShowThumbnails(List<Data> data)
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(imgThumbnail); i++)
            {
                var grid = (Grid)VisualTreeHelper.GetChild(imgThumbnail, i);

                for (var j = 0; j < VisualTreeHelper.GetChildrenCount(grid); j++)
                {
                    var child = VisualTreeHelper.GetChild(grid, j);
                    if (child.GetType() == typeof(Image))
                    {
                        var c = (Image)child;

                        foreach (var d in data)
                        {
                            if (d.ImageComponentName == c.Name)
                            {
                                BitmapImage imageTemp = new BitmapImage();
                                imageTemp.BeginInit();
                                imageTemp.CacheOption = BitmapCacheOption.OnLoad;
                                imageTemp.UriSource = new Uri(d.DownloadedImagePath, UriKind.Absolute);
                                imageTemp.CreateOptions = BitmapCreateOptions.IgnoreImageCache;

                                imageTemp.EndInit();
                                c.Source = imageTemp;
                            }
                        }
                    }
                }
            }
        }

        private void ShowDefaultThumbnails()
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(imgThumbnail); i++)
            {
                var grid = (Grid)VisualTreeHelper.GetChild(imgThumbnail, i);

                for (var j = 0; j < VisualTreeHelper.GetChildrenCount(grid); j++)
                {
                    var child = VisualTreeHelper.GetChild(grid, j);
                    if (child.GetType() == typeof(Image))
                    {
                        var image = (Image)child;

                        BitmapImage imageTemp = new BitmapImage();
                        imageTemp.BeginInit();
                        imageTemp.UriSource = new Uri("pack://application:,,,/AsyncImagesDownloadApp;component/img/async.png");
                        imageTemp.EndInit();

                        image.Source = imageTemp;
                    }
                }
            }
        }


        //binding name and text of TextBox component with name of Image component
        private IEnumerable<Data> BindData()
        {
            List<Data> data = new List<Data>();

            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(imgThumbnail); i++)
            {
                var imgUrl = "";
                var textBoxName = "";
                var imageName = "";

                var grid = (Grid)VisualTreeHelper.GetChild(imgThumbnail, i);

                for (int j = 0; j < VisualTreeHelper.GetChildrenCount(grid); j++)
                {
                    var gridChild = VisualTreeHelper.GetChild(grid, j);

                    if (gridChild.GetType() == typeof(TextBox))
                    {
                        imgUrl = ((TextBox)gridChild).Text;
                        textBoxName = ((TextBox)gridChild).Name;
                    }

                    if (gridChild.GetType() == typeof(Image))
                    {
                        imageName = ((Image)gridChild).Name;
                    }
                }

                data.Add(new Data
                {
                    Id = i,
                    ImageUrl = imgUrl,
                    TextBoxComponentName = textBoxName,
                    ImageComponentName = imageName
                });
            }

            return data;
        }
    }
}
