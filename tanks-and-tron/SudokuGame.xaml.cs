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
//ToDo: Name Textboxes in a useful manner
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
            #region AttemptBlocks
            Random rnd = new Random();
            int[] arr = Enumerable.Range(1, 9).OrderBy(c => rnd.Next()).ToArray();

            int[,] block1 = new int[3, 3];
            int i = 0;
            for (int i1 = 0; i1 < 3; i1++)
            {
                for (int i2 = 0; i2 < 3; i2++)
                {
                    block1[i1, i2] = arr[i];
                    i++;
                }
            }
            txt_100.Text = block1[0, 0].ToString();
            txt_101.Text = block1[0, 1].ToString();
            txt_102.Text = block1[0, 2].ToString();
            txt_110.Text = block1[1, 0].ToString();
            txt_111.Text = block1[1, 1].ToString();
            txt_112.Text = block1[1, 2].ToString();
            txt_120.Text = block1[2, 0].ToString();
            txt_121.Text = block1[2, 1].ToString();
            txt_122.Text = block1[2, 2].ToString();

            int[,] block2 = new int[3, 3];
            i = 0;
            arr = Enumerable.Range(1, 9).OrderBy(c => rnd.Next()).ToArray();
            for (int i1 = 0; i1 < 3; i1++)
            {
                for (int i2 = 0; i2 < 3; i2++)
                {
                    block2[i1, i2] = arr[i];
                    i++;
                }
            }
            txt_200.Text = block2[0, 0].ToString();
            txt_201.Text = block2[0, 1].ToString();
            txt_202.Text = block2[0, 2].ToString();
            txt_210.Text = block2[1, 0].ToString();
            txt_211.Text = block2[1, 1].ToString();
            txt_212.Text = block2[1, 2].ToString();
            txt_220.Text = block2[2, 0].ToString();
            txt_221.Text = block2[2, 1].ToString();
            txt_222.Text = block2[2, 2].ToString();

            //checking if block 1 doesn't interfere with block 2 horizontally
            

            for (int irow = 0;  irow < 3;  irow++)
            {
                HashSet<int> set = new HashSet<int>();
                for (int icolumn = 0; icolumn < 3; icolumn++)
                {
                    set.Add(block1[irow, icolumn]);
                    set.Add(block2[irow, icolumn]);
                }
                if(set.Count < 6)
                {
                    MessageBox.Show("Incorrect: "+irow);
                }
            }
            btn_create.IsEnabled = true;
            #endregion

        }

        private void comment() 
        { 
            #region RowColumnBlock
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
                if ((iy + 1) / 3 == 1)
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
                else if (reshuffle)
                {
                    MessageBox.Show("reshuffle = true");
                    iy -= 1;
                    for (int ix = 0; ix < 9; ix++)
                    {
                        grid[iy, ix] = 10; //adds shuffled numbers 1-9 to grid (horizontal line)
                    }
                    reshuffle = false;
                }
                else if (reshuffleBlock)
                {
                    MessageBox.Show("reshuffle Block = true");
                    iy -= 2;
                    for (int ix = 0; ix < 9; ix++)
                    {
                        grid[iy, ix] = 10; //adds shuffled numbers 1-9 to grid (horizontal line)
                    }
                    reshuffleBlock = false;
                }
                #endregion

                // ToDo: implement checking of 3x3 boxes and combine it with check of columns

                secondrow = true;
            }

            btn_create.IsEnabled = true; 
            #endregion

        }
    }
}
