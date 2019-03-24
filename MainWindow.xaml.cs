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
            string input = txtInput.Text;
            string[] inSplit = input.Split(',');
            string shape;
            
        }

        private void setColour_Click(object sender, RoutedEventArgs e)
        {
            pickColor p = new pickColor();
            p.ShowDialog();
        }
        private void btnDraw_Click(object sender, RoutedEventArgs e)
        {
            string input = txtInput.Text;
            string[] inSplit = input.Split(',');
            string shape="";
            //check whether ellipse or rectangle is chosen
            if (rbEli.IsChecked == true)
            {
                shape = "Ellipse";
            }
            else if (rbRec.IsChecked == true)
            {
                shape = "Rectangle";
            }
            DrawingHelper DH = new DrawingHelper(canvas, double.Parse(inSplit[0]), double.Parse(inSplit[1]), double.Parse(inSplit[2]), double.Parse(inSplit[3]), b, shape);
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
            else if (Shape == "Ellipse")//
            {
                e = new Ellipse();
                e.Height = H;
                e.Width = W;

                e.Fill = Colour;

                c.Children.Add(e);

                Canvas.SetTop(e, y);
                Canvas.SetLeft(e, x);
            }
        }
    }
}