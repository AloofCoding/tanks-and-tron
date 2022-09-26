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

namespace tanks_and_tron
{
    /// <summary>
    /// Interaktionslogik für TanksGame.xaml
    /// </summary>
    public partial class TanksGame : Window
    {
        public TanksGame()
        {
            InitializeComponent();
            MainGrid.Focus();
        }

        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            Point point = e.GetPosition(MainGrid);
            var cannon_X = cannon.Margin.Left;
            var cannon_Y = cannon.Margin.Top;
            double side_a;
            double side_b;

            if(point.X < cannon_X)
            {
                side_b = cannon_X - point.X;
            }
            else
            {
                side_b = point.X - cannon_X;
            }
            if (point.Y < cannon_Y)
            {
                side_a = cannon_Y - point.Y;
            }
            else
            {
                side_a = point.Y - cannon_Y;
            }

            var side_c = sqrt(side_a ^ 2 + side_b ^ 2);
        }



        private void MainGrid_KeyDown(object sender, KeyEventArgs e)
        {
            #region 2 keys
            //MessageBox.Show("Event registriert!");
            /*
            if (e.Key == Key.W && Keyboard.IsKeyDown(Key.D))
            {
                Thickness mt = tank.Margin;
                mt.Left += 10;
                mt.Top -= 10;
                tank.Margin = mt;
                tank.RenderTransform = new RotateTransform(45);
            }
            else if (e.Key == Key.D && Keyboard.IsKeyDown(Key.S))
            {
                Thickness mt = tank.Margin;
                mt.Left += 10;
                mt.Top += 10;
                tank.Margin = mt;
                tank.RenderTransform = new RotateTransform(135);
            }
            else if (e.Key == Key.S && Keyboard.IsKeyDown(Key.A))
            {
                Thickness mt = tank.Margin;
                mt.Left -= 10;
                mt.Top += 10;
                tank.Margin = mt;
                tank.RenderTransform = new RotateTransform(225);
            }
            else if (e.Key == Key.A && Keyboard.IsKeyDown(Key.W))
            {
                Thickness mt = tank.Margin;
                mt.Left -= 10;
                mt.Top -= 10;
                tank.Margin = mt;
                tank.RenderTransform = new RotateTransform(315); 
            }
            */
            /*else*/
            #endregion
            if (e.Key == Key.S)
            {
                Thickness mt = tank.Margin;
                mt.Top += 10;
                tank.RenderTransform = new RotateTransform(0);
                Thickness mc = cannon.Margin;
                mc.Top += 10;
                tank.Margin = mt;
                cannon.Margin = mc;
            }
            else if (e.Key == Key.W)
            {
                Thickness mt = tank.Margin;
                mt.Top -= 10;
                tank.RenderTransform = new RotateTransform(0);
                Thickness mc = cannon.Margin;
                mc.Top -= 10;
                tank.Margin = mt;
                cannon.Margin = mc;
            }
            else if (e.Key == Key.A)
            {
                Thickness mt = tank.Margin;
                mt.Left -= 10;
                tank.RenderTransform = new RotateTransform(90);
                Thickness mc = cannon.Margin;
                mc.Left -= 10;
                tank.Margin = mt;
                cannon.Margin = mc;
            }
            else if (e.Key == Key.D)
            {
                Thickness mt = tank.Margin;
                mt.Left += 10;
                tank.RenderTransform = new RotateTransform(90);
                Thickness mc = cannon.Margin;
                mc.Left += 10;
                tank.Margin = mt;
                cannon.Margin = mc;
            }
            else
            {

            }
        }
    }
}
