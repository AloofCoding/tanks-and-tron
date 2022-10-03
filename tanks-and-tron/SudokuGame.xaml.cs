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
            CreateSudoku();
            //MessageBox.Show("finished creation");
            
        }

        private void CreateSudoku() 
        {
            bool secondrow = false;
            int[,] grid = new int[9, 9];
            Random rnd = new Random();
            bool reshuffle = false;
            bool reshuffleBlock = false;

            for (int iy = 0; iy < 9; iy++)
            {
                int[] arr = Enumerable.Range(1, 9).OrderBy(c => rnd.Next()).ToArray();
                for (int ix = 0; ix < 9; ix++)
                {
                    grid[iy, ix] = arr[ix]; //adds shuffled numbers 1-9 to grid (horizontal line)
                }

                #region check of columns
                if (secondrow) //activated after second row
                {
                    for (int ix = 0; ix < 9; ix++) // ix = number of column
                    {
                        HashSet<int> set = new HashSet<int>();
                        for (int i = 0; i <= iy; i++)
                        {
                            /*adding 
                             * 0,0 | 
                             * 1,0 | 
                             * ... 
                             * then checking whether the numbers are unique in that column*/
                            set.Add(grid[i, ix]);
                        }
                        if (set.Count <= iy)
                        {
                            reshuffle = true;
                            break;
                        }
                    }
                }
                #endregion

                #region check of blocks
                // is unable to write sth in textbox aka doesn't reach conclusion
                if((iy+1) / 3 == 1)
                {
                    HashSet<int> set = new HashSet<int>();
                    for (int i1 = 0; i1 < 2; i1++)
                    {
                        for (int i2 = 0; i2 < 2; i2++)
                        {
                            set.Add(grid[i1, i2]);
                        }
                    }
                    if (set.Count < 9)
                    {
                        reshuffleBlock = true;
                    }
                }

                #endregion

                #region Consequences of Checking
                if (!reshuffle && !reshuffleBlock)
                {
                    for (int i = iy; i <= iy; i++)
                    {
                        txt_output.Text += grid[i, 0] + " | " + grid[i, 1] + " | " + grid[i, 2] + " | " + grid[i, 3] + " | " + grid[i, 4] + " | " + grid[i, 5] + " | " + grid[i, 6] + " | " + grid[i, 7] + " | " + grid[i, 8] + Environment.NewLine;
                    }
                }
                if (reshuffle)
                {
                    iy -= 1;
                    reshuffle = false;
                }
                if (reshuffleBlock)
                {
                    iy -= 2;
                    reshuffleBlock = false;
                }
                #endregion

                // ToDo: implement checking of 3x3 boxes and combine it with check of columns

                secondrow = true;
            }
            btn_create.IsEnabled = true;
        }
    }
}
