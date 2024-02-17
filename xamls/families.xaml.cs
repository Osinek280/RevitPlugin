using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace RevitPlugin.xamls
{
    public partial class families : UserControl
    {
        public families()
        {
            InitializeComponent();

            AllowDrop = true;
            Drop += OnDrop;

            LoadIconFromFile();
        }

        private void LoadIconFromFile()
        {
            string filePath = "C:\\Users\\biuro\\Desktop\\Adobe Premiere Pro Auto-Save";

            string[] files = Directory.GetFiles(filePath);

            foreach (string file in files)
            {
                try
                {
                    System.Drawing.Icon fileIcon = System.Drawing.Icon.ExtractAssociatedIcon(file);

                    BitmapSource iconSource = System.Windows.Interop.Imaging.CreateBitmapSourceFromHIcon(
                        fileIcon.Handle,
                        System.Windows.Int32Rect.Empty,
                        BitmapSizeOptions.FromEmptyOptions());

                    Image imageControl = new Image();
                    imageControl.Source = iconSource;

                    FilesList.Children.Add(imageControl);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error loading icon: " + ex.Message);
                }
            }
        }

        private void OnDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

                foreach (string file in files)
                {
                    Console.WriteLine("Dropped file: " + file);
                }
            }
        }
    }
}
