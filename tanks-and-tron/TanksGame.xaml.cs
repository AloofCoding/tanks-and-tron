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
using Microsoft.Windows.Themes;

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
            MouseMove += Window_MouseMove_1;
            KeyDown += MainGrid_KeyDown;

        }

        private void DTimer_Tick(object? sender, EventArgs e)
        {
            
        }

        double xt = 0.0;
        double yt = 0.0;
        double xc = 0.0;
        double yc = 0.0;

        private double translateX;

        public double TranslateX
        {
            get { return translateX; }
            set { translateX = value; }
        }

        private double translateY;

        public double TranslateY
        {
            get { return translateY; }
            set { translateY = value; }
        }

        private float storeAngle;

        public float StoreAngle
        {
            get { return storeAngle; }
            set { storeAngle = value; }
        }


        private void MainGrid_KeyDown(object sender, KeyEventArgs e)
        {
            var tfg_tank = new TransformGroup();
            var tfg_cannon = new TransformGroup();
            #region not margin version
            if (e.Key == Key.W && Keyboard.IsKeyDown(Key.D) || e.Key == Key.D && Keyboard.IsKeyDown(Key.W))
            {
                Rect Hitbox = new Rect(Canvas.GetLeft(tank), Canvas.GetTop(tank), tank.Width, tank.Height);
                foreach (Rect rect in MainGrid.Children)
                {
                    if (Hitbox.IntersectsWith(rect))
                    {
                        
                    }
                }
                TranslateX = 1.25;
                TranslateY = -1.25;
                tfg_tank.Children.Add(new RotateTransform(41.25));
                tfg_tank.Children.Add(new TranslateTransform(xt += TranslateX, yt += TranslateY));
                tfg_cannon.Children.Add(new RotateTransform(StoreAngle));
                tfg_cannon.Children.Add(new TranslateTransform(xc += TranslateX, yc += TranslateY));

                tank.RenderTransform = tfg_tank;   
                cannon.RenderTransform = tfg_cannon;
            }
            else if (e.Key == Key.S && Keyboard.IsKeyDown(Key.D) || e.Key == Key.D && Keyboard.IsKeyDown(Key.S))
            {
                TranslateX = 1.25;
                TranslateY = 1.25;
                tfg_tank.Children.Add(new RotateTransform(131.25));
                tfg_tank.Children.Add(new TranslateTransform(xt += TranslateX, yt += TranslateY));
                tfg_cannon.Children.Add(new RotateTransform(StoreAngle));
                tfg_cannon.Children.Add(new TranslateTransform(xc += TranslateX, yc += TranslateY));

                tank.RenderTransform = tfg_tank;
                cannon.RenderTransform = tfg_cannon;
            }
            else if (e.Key == Key.S && Keyboard.IsKeyDown(Key.A) || e.Key == Key.A && Keyboard.IsKeyDown(Key.S))
            {
                TranslateX = -1.25;
                TranslateY = 1.25;
                tfg_tank.Children.Add(new RotateTransform(221.25));
                tfg_tank.Children.Add(new TranslateTransform(xt += TranslateX, yt += TranslateY));
                tfg_cannon.Children.Add(new RotateTransform(StoreAngle));
                tfg_cannon.Children.Add(new TranslateTransform(xc += TranslateX, yc += TranslateY));

                tank.RenderTransform = tfg_tank;
                cannon.RenderTransform = tfg_cannon;
            }
            else if (e.Key == Key.W && Keyboard.IsKeyDown(Key.A) || e.Key == Key.A && Keyboard.IsKeyDown(Key.W))
            {
                TranslateX = -1.25;
                TranslateY = -1.25;
                tfg_tank.Children.Add(new RotateTransform(311.25));
                tfg_tank.Children.Add(new TranslateTransform(xt += TranslateX, yt += TranslateY));
                tfg_cannon.Children.Add(new RotateTransform(StoreAngle));
                tfg_cannon.Children.Add(new TranslateTransform(xc += TranslateX, yc += TranslateY));

                tank.RenderTransform = tfg_tank;
                cannon.RenderTransform = tfg_cannon;
            }
            else if (e.Key == Key.S)
            {
                TranslateX = 0.0;
                TranslateY = 2.5;
                tfg_tank.Children.Add(new RotateTransform(180.0));
                tfg_tank.Children.Add(new TranslateTransform(xt += TranslateX, yt += TranslateY));
                tfg_cannon.Children.Add(new RotateTransform(StoreAngle));
                tfg_cannon.Children.Add(new TranslateTransform(xc += TranslateX, yc += TranslateY));

                tank.RenderTransform = tfg_tank;
                cannon.RenderTransform = tfg_cannon;
            }
            else if (e.Key == Key.W)
            {
                TranslateX = 0.0;
                TranslateY = -2.5;
                tfg_tank.Children.Add(new RotateTransform(0.0));
                tfg_tank.Children.Add(new TranslateTransform(xt += TranslateX, yt += TranslateY));
                tfg_cannon.Children.Add(new RotateTransform(StoreAngle));
                tfg_cannon.Children.Add(new TranslateTransform(xc += TranslateX, yc += TranslateY));

                tank.RenderTransform = tfg_tank;
                cannon.RenderTransform = tfg_cannon;
            }
            else if (e.Key == Key.A)
            {
                TranslateX = -2.5;
                TranslateY = 0.0;
                tfg_tank.Children.Add(new RotateTransform(270.0));
                tfg_tank.Children.Add(new TranslateTransform(xt += TranslateX, yt += TranslateY));
                tfg_cannon.Children.Add(new RotateTransform(StoreAngle));
                tfg_cannon.Children.Add(new TranslateTransform(xc += TranslateX, yc += TranslateY));

                tank.RenderTransform = tfg_tank;
                cannon.RenderTransform = tfg_cannon;
            }
            else if (e.Key == Key.D)
            {
                TranslateX = 2.5;
                TranslateY = 0.0;
                tfg_tank.Children.Add(new RotateTransform(90.0));
                tfg_tank.Children.Add(new TranslateTransform(xt += TranslateX, yt += TranslateY));
                tfg_cannon.Children.Add(new RotateTransform(StoreAngle));
                tfg_cannon.Children.Add(new TranslateTransform(xc += TranslateX, yc += TranslateY));

                tank.RenderTransform = tfg_tank;
                cannon.RenderTransform = tfg_cannon;
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
            System.Windows.Point point = e.GetPosition(MainGrid);
            System.Windows.Point pos = cannon.TranslatePoint(new System.Windows.Point(0, 0), MainGrid);
            var cannon_X = pos.X + cannon.Width / 2;
            var cannon_Y = pos.Y + cannon.Height / 2;

            double side_b = cannon_X - point.X;
            double side_a = cannon_Y - point.Y;

            float angle = (float)Math.Atan2(side_b, side_a) * (float)(180 / Math.PI) * (-1);
            StoreAngle = angle;

            var tfg = new TransformGroup();
            tfg.Children.Add(new RotateTransform(StoreAngle));
            tfg.Children.Add(new TranslateTransform(xc, yc));

            cannon.RenderTransform = tfg;
            cannon.UpdateLayout();
            #endregion

            
            #region margin version
            /*
            System.Windows.Point point = e.GetPosition(MainGrid);
            var cannon_X = cannon.Margin.Left + cannon.Width/2;
            var cannon_Y = cannon.Margin.Top + cannon.Height/2;

            double side_b = cannon_X - point.X;
            double side_a = cannon_Y - point.Y;

            //var side_c = Math.Sqrt(Math.Pow(side_a, 2) + Math.Pow(side_b, 2));

            float angle = (float)Math.Atan2(side_b,side_a) * (float)(180/Math.PI) * (-1);

            //MessageBox.Show(angle.ToString());

            cannon.RenderTransform = new RotateTransform(angle);
            */
            #endregion            
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            #region bullet using image - current status: on
            var tfg_bullet = new TransformGroup();
            Image bullet = new Image();
            bullet.BeginInit();
            BitmapImage bitmap = new BitmapImage(new Uri("pack://application:,,,/bullet.png"));
            bullet.Source = bitmap;
            bullet.VerticalAlignment = VerticalAlignment.Top;
            bullet.HorizontalAlignment = HorizontalAlignment.Left;
            bullet.Margin = new Thickness(300, 500, 0, 0);
            tfg_bullet.Children.Add(new TranslateTransform(xc, yc));
            //tfg_bullet.Children.Add(new RotateTransform(StoreAngle));
            bullet.RenderTransform = tfg_bullet;            
            //MessageBox.Show("X: " + xc.ToString() + " | Y: " + yc.ToString());
            Panel.SetZIndex(bullet, -1);
            bullet.Visibility = Visibility.Visible;
            bullet.Height = tank.Height;
            bullet.Width = tank.Width;
            MainGrid.Children.Add(bullet);
            bullet.EndInit();
            dTimer.Start();
            #endregion

            #region bullet using ellipse - current status: off
            //Ellipse ellipse;
            //ellipse = new Ellipse();
            //ellipse.Height = tank.Height;
            //ellipse.Width = tank.Height;
            //ellipse.Stroke = Brushes.Red;
            //ellipse.Fill = Brushes.Red;
            //ellipse.StrokeThickness = 5;
            //Panel.SetZIndex(ellipse, -2);
            //ellipse.RenderTransform = new TranslateTransform(xc, yc);
            //MessageBox.Show(tank.GetValue(LeftProperty).ToString());
            //MessageBox.Show(tank.GetValue(TopProperty).ToString());
            //MainGrid.Children.Add(ellipse);
            ////MessageBox.Show(tank.GetValue(LeftProperty).ToString());
            #endregion



            //destroy image when out of sight
            //prevent spawning bullets on click spam
            dTimer.Stop();
        }      
    }
}