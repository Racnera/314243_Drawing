/*314243 Ethan Hunter
 * 3/24/19
 *make a simple drawing program that create rectangles and Ellipses
 * Allows user to choose object's shape, colour, dimensions, and position on canvas
 * 
 * Need to incorporate way to save last used information to a txt file, so that is usable the next time the program is run.
 */


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

        private void setColour_Click(object sender, RoutedEventArgs e)//runs pick colour window
        {
            pickColor p = new pickColor();
            p.ShowDialog();
        }
        private void btnDraw_Click(object sender, RoutedEventArgs e)//prints object to screen
        {
            string input = txtInput.Text;//input from textbox
            string[] inSplit = input.Split(',');//split at commas, used later
            string shape="";
            //check whether ellipse or rectangle is chosen
            if (rbEli.IsChecked == true)
            {
                shape = "Ellipse";
            }//shape created on screen will be an ellipse
            else if (rbRec.IsChecked == true)
            {
                shape = "Rectangle";
            }//shape created on screen will be a Rectangle

            //sets canvas,first object in list is height from top(found with .split),2nd object is distance from left,     VVV
            //3rd is shape's height, 4th is shape's width, b is the assigned colour from pickColor window, shape is assigned via radio button    VVV
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
            if (Shape == "Rectangle")//assigns values for the rectangle about to be created
            {
                r = new Rectangle();
                r.Height = H;
                r.Width = W;

                r.Fill = Colour;

                c.Children.Add(r); //creates the rectangle

                Canvas.SetTop(r, y);//sets location
                Canvas.SetLeft(r, x);//||     ||
            }
            else if (Shape == "Ellipse")//assign values for the ellipse about to be created
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
