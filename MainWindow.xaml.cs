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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _314243Drawing
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        public static Brush b;//sets brush 'b' from pick colour window
        public MainWindow()
        {
            InitializeComponent();
        }

        private void setColour_Click(object sender, RoutedEventArgs e)
        {
            pickColor p = new pickColor();
            p.ShowDialog();
        }

        private void btnDraw_Click(object sender, RoutedEventArgs e)
        {
            DrawingHelper DH = new DrawingHelper(canvas, 10, 10, 100, 100, b,"Rectangle");
        }
    }
    class DrawingHelper //class to assign values for whats being drawn
    {
        private Canvas c;
        private Rectangle r;
        private Ellipse e;
        public DrawingHelper(Canvas c, double y, double x, double W, double H, Brush Colour, string Shape)
        {
            if (Shape == "Rectangle")//
            {
                r = new Rectangle();
                r.Height = H;
                r.Width = W;

                r.Fill = Colour;

                c.Children.Add(r);

                Canvas.SetTop(r, y);
                Canvas.SetLeft(r, x);
            }
        }
    }
}
