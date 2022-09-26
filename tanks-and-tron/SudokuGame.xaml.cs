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
    /// Interaktionslogik für SudokuGame.xaml
    /// </summary>
    public partial class SudokuGame : Window
    {
        public SudokuGame()
        {
            InitializeComponent();
            
        }

        private void btn_create_Click(object sender, RoutedEventArgs e)
        {
            btn_create.IsEnabled = false;
            txt_output.Text = "";
            bool secondrow = false;
            byte[] numbers = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int[,] grid = new int[9,9];
            Random rnd = new Random();
            
            for (int iy = 0; iy < 9; iy++)
            {
                int[] arr = Enumerable.Range(1, 9).OrderBy(c => rnd.Next()).ToArray();
                for (int ix = 0; ix < 9; ix++)
                {
                    grid[iy, ix] = arr[ix]; //adds shuffled 1-9 to grid (horizontal)                   
                }

                //MessageBox.Show(grid.GetLength(0) + "");
                
                if (secondrow)
                {
                    for (int ix = 0; ix < 8; ix++)
                    {
                        HashSet<byte> set = new HashSet<byte>();
                        for (int i = 0; i < iy; i++)
                        {
                            set.Add(((byte)grid[i, ix]));
                        }
                        if(set.Count < iy)
                        {
                            //MessageBox.Show("Reshuffling needed.");
                        }
                    }
                }
                for (int i = iy; i  <= iy; i++) 
                {
                    txt_output.Text += grid[i, 0] + " | " + grid[i, 1] + " | " + grid[i, 2] + " | " + grid[i, 3] + " | " + grid[i, 4] + " | " + grid[i, 5] + " | " + grid[i, 6] + " | " + grid[i, 7] + " | " + grid[i, 8] + Environment.NewLine;
                } 
                secondrow = true;

            }
            MessageBox.Show("finished with loop");
            btn_create.IsEnabled = true;
        }
    }
}
