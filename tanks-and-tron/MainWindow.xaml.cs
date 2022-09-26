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

namespace tanks_and_tron
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_sudoku_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_tron_Click(object sender, RoutedEventArgs e)
        {
            TronGame tronGame = new TronGame();
            tronGame.Show();
            this.Close();

        }

        private void btn_tanks_Click(object sender, RoutedEventArgs e)
        {
            TanksGame tanksGame = new TanksGame();
            tanksGame.Show();
            this.Close();
        }
    }
}
