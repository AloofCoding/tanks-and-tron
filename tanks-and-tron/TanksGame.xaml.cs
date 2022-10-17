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
using System.Windows.Threading;
using System.Drawing;

namespace tanks_and_tron
{
    /// <summary>
    /// Interaktionslogik für TanksGame.xaml
    /// </summary>
    public partial class TanksGame : Window
    {
        DispatcherTimer dTimer;

        public TanksGame()
        {
            InitializeComponent();
            MainGrid.Focus();

            dTimer = new DispatcherTimer();
            dTimer.Interval = TimeSpan.FromMilliseconds(100);
            dTimer.Tick += DTimer_Tick;
        }

        private void DTimer_Tick(object? sender, EventArgs e)
        {
            TimeSpan.FromMilliseconds(-100);
            //move bullet
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

            if (e.Key == Key.W && Keyboard.IsKeyDown(Key.D) || e.Key == Key.D && Keyboard.IsKeyDown(Key.W))
            {
                #region margin version
                Thickness mt = tank.Margin;
                mt.Top -= 10;
                mt.Left += 10;
                tank.RenderTransform = new RotateTransform(45);
                Thickness mc = cannon.Margin;
                mc.Top -= 10;
                mc.Left += 10;
                tank.Margin = mt;
                cannon.Margin = mc;
                #endregion

                #region get/set values version --> ?!?
                tank.RenderTransform = new TranslateTransform(TopProperty = 10);
                tank.SetValue(LeftProperty, 10.0);
                tank.RenderTransform = new RotateTransform(45);
                #endregion
            }
            else if(e.Key == Key.S && Keyboard.IsKeyDown(Key.D) || e.Key == Key.D && Keyboard.IsKeyDown(Key.S))
            {
                #region margin version
                Thickness mt = tank.Margin;
                mt.Top += 10;
                mt.Left += 10;
                tank.RenderTransform = new RotateTransform(135);
                Thickness mc = cannon.Margin;
                mc.Top += 10;
                mc.Left += 10;
                tank.Margin = mt;
                cannon.Margin = mc;
                #endregion


            }
            else if (e.Key == Key.S && Keyboard.IsKeyDown(Key.A) || e.Key == Key.A && Keyboard.IsKeyDown(Key.S))
            {
                #region margin version
                Thickness mt = tank.Margin;
                mt.Top += 10;
                mt.Left -= 10;
                tank.RenderTransform = new RotateTransform(225);
                Thickness mc = cannon.Margin;
                mc.Top += 10;
                mc.Left -= 10;
                tank.Margin = mt;
                cannon.Margin = mc;
                #endregion
            }
            else if (e.Key == Key.W && Keyboard.IsKeyDown(Key.A) || e.Key == Key.A && Keyboard.IsKeyDown(Key.W))
            {
                #region margin version
                Thickness mt = tank.Margin;
                mt.Top -= 10;
                mt.Left -= 10;
                tank.RenderTransform = new RotateTransform(315);
                Thickness mc = cannon.Margin;
                mc.Top -= 10;
                mc.Left -= 10;
                tank.Margin = mt;
                cannon.Margin = mc;
                #endregion
            }
            else if (e.Key == Key.S)
            {
                #region margin version
                Thickness mt = tank.Margin;
                mt.Top += 10;
                tank.RenderTransform = new RotateTransform(0);
                Thickness mc = cannon.Margin;
                mc.Top += 10;
                tank.Margin = mt;
                cannon.Margin = mc;
                #endregion
            }
            else if (e.Key == Key.W)
            {
                #region margin version
                Thickness mt = tank.Margin;
                mt.Top -= 10;
                tank.RenderTransform = new RotateTransform(0);
                Thickness mc = cannon.Margin;
                mc.Top -= 10;
                tank.Margin = mt;
                cannon.Margin = mc;
                #endregion
            }
            else if (e.Key == Key.A)
            {
                #region margin version
                Thickness mt = tank.Margin;
                mt.Left -= 10;
                tank.RenderTransform = new RotateTransform(90);
                Thickness mc = cannon.Margin;
                mc.Left -= 10;
                tank.Margin = mt;
                cannon.Margin = mc;
                #endregion
            }
            else if (e.Key == Key.D)
            {
                #region margin version
                Thickness mt = tank.Margin;
                mt.Left += 10;
                tank.RenderTransform = new RotateTransform(90);
                Thickness mc = cannon.Margin;
                mc.Left += 10;
                tank.Margin = mt;
                cannon.Margin = mc;
                #endregion
            }
            else
            {

            }
        }

        private void Window_MouseMove_1(object sender, MouseEventArgs e)
        {
            System.Windows.Point point = e.GetPosition(MainGrid);
            var cannon_X = cannon.Margin.Left + cannon.Width/2;
            var cannon_Y = cannon.Margin.Top + cannon.Height/2;
            double side_a;
            double side_b;

            #region complicated dumb way for the 2 lines of code below
            //if (point.X < cannon_X && point.Y < cannon_Y) // top right
            //{
            //    side_b = cannon_X - point.X;
            //    side_a = cannon_Y - point.Y;
            //}
            //else if (point.X < cannon_X && point.Y > cannon_Y) // bottom right
            //{
            //    side_b = cannon_X - point.X;
            //    side_a = cannon_Y - point.Y;
            //}
            //else if (point.X > cannon_X && point.Y < cannon_Y) // top left
            //{
            //    side_b = cannon_X - point.X;
            //    side_a = cannon_Y - point.Y;
            //}
            //else if (point.X > cannon_X && point.Y > cannon_Y) // bottom left
            //{
            //    side_b = cannon_X - point.X;
            //    side_a = cannon_Y - point.Y;
            //}
            //else // shouldn't happen !!!
            //{
            //    side_a = 0;
            //    side_b = 0;
            //}
            #endregion

            side_b = cannon_X - point.X;
            side_a = cannon_Y - point.Y;

            //var side_c = Math.Sqrt(Math.Pow(side_a, 2) + Math.Pow(side_b, 2));

            float angle = (float)Math.Atan2(side_b,side_a) * (float)(180/Math.PI) * (-1);

            //MessageBox.Show(angle.ToString());

            cannon.RenderTransform = new RotateTransform(angle);
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            #region bullet using image - current status: off
            //Image bullet = new Image();
            //bullet.BeginInit();
            //BitmapImage bitmap = new BitmapImage(new Uri("pack://application:,,,/bullet.png"));
            //bullet.Source = bitmap;
            //bullet.Margin = tank.Margin;
            //Panel.SetZIndex(bullet, -1);
            //bullet.Visibility = Visibility.Visible;
            //bullet.Height = tank.Height;
            //bullet.Width = tank.Width;
            //MainGrid.Children.Add(bullet);
            ////MessageBox.Show("bullet created");
            //bullet.EndInit();
            #endregion

            #region bullet using ellipse - current status: on
            Ellipse ellipse;
            ellipse = new Ellipse();
            ellipse.Height = tank.Height;
            ellipse.Width = tank.Height;
            ellipse.Stroke = Brushes.Red;
            ellipse.Fill = Brushes.Red;
            ellipse.StrokeThickness = 5;
            //ellipse.Margin = tank.Margin;
            Panel.SetZIndex(ellipse, -2);
            ellipse.SetValue(LeftProperty,tank.GetValue(LeftProperty));
            MessageBox.Show(tank.GetValue(LeftProperty).ToString());
            ellipse.SetValue(TopProperty, tank.GetValue(TopProperty));
            MessageBox.Show(tank.GetValue(TopProperty).ToString());
            MainGrid.Children.Add(ellipse);
            //MessageBox.Show(tank.GetValue(LeftProperty).ToString());
            #endregion


            System.Windows.Point point = e.GetPosition(MainGrid);
            var cannon_X = cannon.Margin.Left + cannon.Width / 2;
            var cannon_Y = cannon.Margin.Top + cannon.Height / 2;
            double side_a;
            double side_b;

            side_b = cannon_X - point.X;
            side_a = cannon_Y - point.Y;

            float angle = (float)Math.Atan2(side_b, side_a) * (float)(180 / Math.PI) * (-1);
            cannon.RenderTransform = new RotateTransform(angle);

            dTimer.Start();
            //get angle from cannon
            //move image straight forward along the angle
            //destroy image when out of sight
            //prevent spawning bullets on click spam
            dTimer.Stop();
        }
    }
}