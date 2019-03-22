using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace _314243Drawing
{
    /// <summary>
    /// Interaction logic for pickColor.xaml
    /// </summary>
    public partial class pickColor : Window
    {
        public pickColor()
        {
            InitializeComponent();
            //to do: added nested loops to handle green and blue
            for (int i = 0; i <= 2; i++)
            {
                if (i == 0)
                {
                    for (int r = 0; r < 256; r = r + 33)
                    {
                        Button b = new Button();
                        b.Background = new SolidColorBrush(Color.FromRgb((byte)r, 0, 0));
                        b.Content = " ";
                        b.Click += btnPickColor_Click;
                        stackPanel.Children.Add(b);
                    }
                }
                if (i == 1)
                {
                    for (int g = 0; g < 256; g += 33)
                    {
                        Button b = new Button();
                        b.Background = new SolidColorBrush(Color.FromRgb(0, (byte)g, 0));
                        b.Content = " ";
                        b.Click += btnPickColor_Click;
                        stackPanel.Children.Add(b);
                    }
                }
                if (i == 2)
                {
                    for (int bl = 0; bl < 256; bl = bl + 33)
                    {
                        Button b = new Button();
                        b.Background = new SolidColorBrush(Color.FromRgb(0, 0, (byte)bl));
                        b.Content = " ";
                        b.Click += btnPickColor_Click;
                        stackPanel.Children.Add(b);
                    }
                }
            }
        }

        private void btnPickColor_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.b = ((Button)sender).Background;
            DialogResult = true;
        }
    }
}