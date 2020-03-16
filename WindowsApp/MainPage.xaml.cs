using IntersectionLibrary;
using System;
using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Shapes;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace WindowsApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }


        List<SimpleObject> simpleObjects = new List<SimpleObject>();
        Dictionary<Shape, SimpleObject> dict = new Dictionary<Shape, SimpleObject>();


        // To delete object.
        private void Object_DoubleTapped(object sender, RoutedEventArgs e)
        {
            Shape shape = (Shape)sender;
            simpleObjects.Remove(dict[shape]);
            dict.Remove(shape);
            myCanvas.Children.Remove(shape);
        }

        // To add object.
        private void Add(SimpleObject obj)
        {
            Shape shape = Model.Draw.DrawObject(obj);
            shape.DoubleTapped += Object_DoubleTapped;
            dict.Add(shape, obj);
            myCanvas.Children.Add(shape);
        }


        private async void AppBarButton_Click_OpenFile(object sender, RoutedEventArgs e)
        {
            var picker = new Windows.Storage.Pickers.FileOpenPicker();
            picker.ViewMode = Windows.Storage.Pickers.PickerViewMode.Thumbnail;
            picker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.ComputerFolder;
            picker.FileTypeFilter.Add(".txt");

            try
            {
                Windows.Storage.StorageFile file = await picker.PickSingleFileAsync();
                string text = await Windows.Storage.FileIO.ReadTextAsync(file);

                if (simpleObjects.Count > 0)
                {
                    myCanvas.Children.Clear();
                }

                simpleObjects = Helper.Parse(text);

                foreach (SimpleObject obj in simpleObjects)
                {
                    Add(obj);
                }
            }    
            catch (Exception)
            {
                // User not open file.
            }
        }


        private void AppBarButton_Click_ReFresh(object sender, RoutedEventArgs e)
        {
            // todo: need to draw intersection points.
            int count = Helper.Compute(simpleObjects).Count;

            TextBlock textBlock = new TextBlock();
            textBlock.Text = "Total " + count + " Points.";
            textBlock.Width = 240;
            textBlock.IsTextSelectionEnabled = true;
            textBlock.TextWrapping = TextWrapping.Wrap;
            flyout.Content = textBlock;

            FlyoutBase.ShowAttachedFlyout((FrameworkElement)sender);
        }


        private void AppBarButton_Click_Add(object sender, RoutedEventArgs e)
        {
            // todo: maybe let user input added object?
            List<double> args = new List<double>();
            Random rnd = new Random();
            args.Add(rnd.Next(0, 1000));
            args.Add(rnd.Next(0, 1000));
            args.Add(rnd.Next(0, 1000));
            args.Add(rnd.Next(0, 1000));
            SimpleObject obj = new StraightLine(args);
            Add(obj);
            simpleObjects.Add(obj);
        }
    }
}
