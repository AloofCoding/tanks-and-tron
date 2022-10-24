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

        double x = 0.0;
        double y = 0.0;

        private void MainGrid_KeyDown(object sender, KeyEventArgs e)
        {
            #region not margin version
            if (e.Key == Key.W && Keyboard.IsKeyDown(Key.D) || e.Key == Key.D && Keyboard.IsKeyDown(Key.W))
            {
                tank.RenderTransform = new RotateTransform(45.0);
                tank.RenderTransform = new TranslateTransform(x += 10.0, y -= 10.0);
                cannon.RenderTransform = tank.RenderTransform;                
            }
            else if (e.Key == Key.S && Keyboard.IsKeyDown(Key.D) || e.Key == Key.D && Keyboard.IsKeyDown(Key.S))
            {
                tank.RenderTransform = new RotateTransform(135.0);
                tank.RenderTransform = new TranslateTransform(x += 10.0, y += 10.0);
                cannon.RenderTransform = tank.RenderTransform;
            }
            else if (e.Key == Key.S && Keyboard.IsKeyDown(Key.A) || e.Key == Key.A && Keyboard.IsKeyDown(Key.S))
            {
                tank.RenderTransform = new RotateTransform(225.0);
                tank.RenderTransform = new TranslateTransform(x -= 10.0, y += 10.0);
                cannon.RenderTransform = tank.RenderTransform;
            }
            else if (e.Key == Key.W && Keyboard.IsKeyDown(Key.A) || e.Key == Key.A && Keyboard.IsKeyDown(Key.W))
            {
                tank.RenderTransform = new RotateTransform(315.0);
                tank.RenderTransform = new TranslateTransform(x -= 10.0, y -= 10.0);
                cannon.RenderTransform = tank.RenderTransform;
            }
            else if (e.Key == Key.S)
            {
                tank.RenderTransform = new RotateTransform(180.0);
                tank.RenderTransform = new TranslateTransform(x += 0.0, y += 10.0);
                cannon.RenderTransform = tank.RenderTransform;
            }
            else if (e.Key == Key.W)
            {
                tank.RenderTransform = new RotateTransform(0.0);
                tank.RenderTransform = new TranslateTransform(x += 0.0, y -= 10.0);
                cannon.RenderTransform = tank.RenderTransform;
            }
            else if (e.Key == Key.A)
            {
                tank.RenderTransform = new RotateTransform(270.0);
                tank.RenderTransform = new TranslateTransform(x -= 10.0, y += 0.0);
                cannon.RenderTransform = tank.RenderTransform;
            }
            else if (e.Key == Key.D)
            {
                tank.RenderTransform = new RotateTransform(90.0);
                tank.RenderTransform = new TranslateTransform(x += 10.0, y -= 0.0);
                cannon.RenderTransform = tank.RenderTransform;
            }
            else
            {

            }
            tank.UpdateLayout();
            cannon.UpdateLayout();
            #endregion

            #region margin version
            /*
            if (e.Key == Key.W && Keyboard.IsKeyDown(Key.D) || e.Key == Key.D && Keyboard.IsKeyDown(Key.W))
            {
                Thickness mt = tank.Margin;
                mt.Top -= 10;
                mt.Left += 10;
                tank.RenderTransform = new RotateTransform(45);
                Thickness mc = cannon.Margin;
                mc.Top -= 10;
                mc.Left += 10;
                tank.Margin = mt;
                cannon.Margin = mc;             
            }
            else if(e.Key == Key.S && Keyboard.IsKeyDown(Key.D) || e.Key == Key.D && Keyboard.IsKeyDown(Key.S))
            {
                Thickness mt = tank.Margin;
                mt.Top += 10;
                mt.Left += 10;
                tank.RenderTransform = new RotateTransform(135);
                Thickness mc = cannon.Margin;
                mc.Top += 10;
                mc.Left += 10;
                tank.Margin = mt;
                cannon.Margin = mc;
            }
            else if (e.Key == Key.S && Keyboard.IsKeyDown(Key.A) || e.Key == Key.A && Keyboard.IsKeyDown(Key.S))
            {
                Thickness mt = tank.Margin;
                mt.Top += 10;
                mt.Left -= 10;
                tank.RenderTransform = new RotateTransform(225);
                Thickness mc = cannon.Margin;
                mc.Top += 10;
                mc.Left -= 10;
                tank.Margin = mt;
                cannon.Margin = mc;
            }
            else if (e.Key == Key.W && Keyboard.IsKeyDown(Key.A) || e.Key == Key.A && Keyboard.IsKeyDown(Key.W))
            {
                Thickness mt = tank.Margin;
                mt.Top -= 10;
                mt.Left -= 10;
                tank.RenderTransform = new RotateTransform(315);
                Thickness mc = cannon.Margin;
                mc.Top -= 10;
                mc.Left -= 10;
                tank.Margin = mt;
                cannon.Margin = mc;
            }
            else if (e.Key == Key.S)
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
            */
            #endregion
        }

        private void Window_MouseMove_1(object sender, MouseEventArgs e)
        {
            #region not margin version
            //here would be my code for a non margin cannon rotation
            //...
            //if i'd have one
            #endregion

            #region margin version
            
            System.Windows.Point point = e.GetPosition(MainGrid);
            var cannon_X = cannon.Margin.Left + cannon.Width/2;
            var cannon_Y = cannon.Margin.Top + cannon.Height/2;

            double side_b = cannon_X - point.X;
            double side_a = cannon_Y - point.Y;

            //var side_c = Math.Sqrt(Math.Pow(side_a, 2) + Math.Pow(side_b, 2));

            float angle = (float)Math.Atan2(side_b,side_a) * (float)(180/Math.PI) * (-1);

            //MessageBox.Show(angle.ToString());

            cannon.RenderTransform = new RotateTransform(angle);
            
            #endregion
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