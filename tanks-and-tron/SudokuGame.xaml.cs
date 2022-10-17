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
            #region AttemptBlocks
            bool ok = false;
            int countrows;
            Random rnd = new Random();
            int[] arr = Enumerable.Range(1, 9).OrderBy(c => rnd.Next()).ToArray();

            int[,] block1 = new int[3, 3];
            int[,] block2 = new int[3, 3];
            int[,] block3 = new int[3, 3];
            int[,] block4 = new int[3, 3];
            int[,] block5 = new int[3, 3];
            int[,] block6 = new int[3, 3];
            int[,] block7 = new int[3, 3];


            //blocks 1 and 2
            while (!ok)
            {
                int i = 0;
                countrows = 0;   
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


                for (int irow = 0; irow < 3; irow++)
                {
                    HashSet<int> set = new HashSet<int>();
                    for (int icolumn = 0; icolumn < 3; icolumn++)
                    {
                        set.Add(block1[irow, icolumn]);
                        set.Add(block2[irow, icolumn]);
                    }
                    if (set.Count < 6)
                    {
                        //MessageBox.Show("Incorrect: " + irow);
                    }
                    else
                    {
                        countrows++;
                    }
                }
                if(countrows >= 3)
                {
                    ok = true;
                }
            }
            ok = false;

            //block 3
            List<int> numbersforblock3 = new List<int>();
            numbersforblock3.AddRange(Enumerable.Range(1, 9).OrderBy(c => rnd.Next()).ToArray());
            
            numbersforblock3.Remove(block1[0, 0]);
            numbersforblock3.Remove(block1[0, 1]);
            numbersforblock3.Remove(block1[0, 2]);
            numbersforblock3.Remove(block2[0, 0]);
            numbersforblock3.Remove(block2[0, 1]);
            numbersforblock3.Remove(block2[0, 2]);
            
            numbersforblock3.OrderBy(c => rnd.Next()).ToArray();

            block3[0, 0] = numbersforblock3.ElementAt<int>(0);
            block3[0, 1] = numbersforblock3.ElementAt<int>(1);
            block3[0, 2] = numbersforblock3.ElementAt<int>(2);

            txt_300.Text = block3[0, 0].ToString();
            txt_301.Text = block3[0, 1].ToString();
            txt_302.Text = block3[0, 2].ToString();

            List<int> numbersforblock3row2 = new List<int>();
            numbersforblock3row2.AddRange(Enumerable.Range(1, 9).OrderBy(c => rnd.Next()).ToArray());

            numbersforblock3row2.Remove(block1[1, 0]);
            numbersforblock3row2.Remove(block1[1, 1]);
            numbersforblock3row2.Remove(block1[1, 2]);
            numbersforblock3row2.Remove(block2[1, 0]);
            numbersforblock3row2.Remove(block2[1, 1]);
            numbersforblock3row2.Remove(block2[1, 2]);

            numbersforblock3row2.OrderBy(c => rnd.Next()).ToArray();

            block3[1, 0] = numbersforblock3row2.ElementAt<int>(0);
            block3[1, 1] = numbersforblock3row2.ElementAt<int>(1);
            block3[1, 2] = numbersforblock3row2.ElementAt<int>(2);

            txt_310.Text = block3[1, 0].ToString();
            txt_311.Text = block3[1, 1].ToString();
            txt_312.Text = block3[1, 2].ToString();

            List<int> numbersforblock3row3 = new List<int>();
            numbersforblock3row3.AddRange(Enumerable.Range(1, 9).OrderBy(c => rnd.Next()).ToArray());

            numbersforblock3row3.Remove(block1[2, 0]);
            numbersforblock3row3.Remove(block1[2, 1]);
            numbersforblock3row3.Remove(block1[2, 2]);
            numbersforblock3row3.Remove(block2[2, 0]);
            numbersforblock3row3.Remove(block2[2, 1]);
            numbersforblock3row3.Remove(block2[2, 2]);

            numbersforblock3row3.OrderBy(c => rnd.Next()).ToArray();

            block3[2, 0] = numbersforblock3row3.ElementAt<int>(0);
            block3[2, 1] = numbersforblock3row3.ElementAt<int>(1);
            block3[2, 2] = numbersforblock3row3.ElementAt<int>(2);

            txt_320.Text = block3[2, 0].ToString();
            txt_321.Text = block3[2, 1].ToString();
            txt_322.Text = block3[2, 2].ToString();

            //block4
            while (!ok)
            {
                int i = 0;
                countrows = 0;

                i = 0;
                arr = Enumerable.Range(1, 9).OrderBy(c => rnd.Next()).ToArray();
                for (int i1 = 0; i1 < 3; i1++)
                {
                    for (int i2 = 0; i2 < 3; i2++)
                    {
                        block4[i1, i2] = arr[i];
                        i++;
                    }
                }
                txt_400.Text = block4[0, 0].ToString();
                txt_401.Text = block4[0, 1].ToString();
                txt_402.Text = block4[0, 2].ToString();
                txt_410.Text = block4[1, 0].ToString();
                txt_411.Text = block4[1, 1].ToString();
                txt_412.Text = block4[1, 2].ToString();
                txt_420.Text = block4[2, 0].ToString();
                txt_421.Text = block4[2, 1].ToString();
                txt_422.Text = block4[2, 2].ToString();

                //checking if block 4 doesn't interfere with block 1 vertically


                for (int icolumn = 0; icolumn < 3; icolumn++)
                {
                    HashSet<int> set = new HashSet<int>();
                    for (int irow = 0; irow < 3; irow++)
                    {
                        set.Add(block1[irow, icolumn]);
                        set.Add(block4[irow, icolumn]);
                    }
                    if (set.Count < 6)
                    {
                        //MessageBox.Show("Incorrect: " + irow);
                    }
                    else
                    {
                        countrows++;
                    }
                }
                if (countrows >= 3)
                {
                    ok = true;
                }
            }
            ok = false;



            //block 7
            List<int> numbersforblock7 = new List<int>();
            numbersforblock7.AddRange(Enumerable.Range(1, 9).OrderBy(c => rnd.Next()).ToArray());

            numbersforblock7.Remove(block1[0, 0]);
            numbersforblock7.Remove(block1[1, 0]);
            numbersforblock7.Remove(block1[2, 0]);
            numbersforblock7.Remove(block4[0, 0]);
            numbersforblock7.Remove(block4[1, 0]);
            numbersforblock7.Remove(block4[2, 0]);

            numbersforblock7.OrderBy(c => rnd.Next()).ToArray();

            block7[0, 0] = numbersforblock7.ElementAt<int>(0);
            block7[1, 0] = numbersforblock7.ElementAt<int>(1);
            block7[2, 0] = numbersforblock7.ElementAt<int>(2);

            txt_700.Text = block7[0, 0].ToString();
            txt_710.Text = block7[1, 0].ToString();
            txt_720.Text = block7[2, 0].ToString();

            List<int> numbersforblock7col2 = new List<int>();
            numbersforblock7col2.AddRange(Enumerable.Range(1, 9).OrderBy(c => rnd.Next()).ToArray());

            numbersforblock7col2.Remove(block1[0, 1]);
            numbersforblock7col2.Remove(block1[1, 1]);
            numbersforblock7col2.Remove(block1[2, 1]);
            numbersforblock7col2.Remove(block4[0, 1]);
            numbersforblock7col2.Remove(block4[1, 1]);
            numbersforblock7col2.Remove(block4[2, 1]);

            numbersforblock7col2.OrderBy(c => rnd.Next()).ToArray();

            block7[0, 1] = numbersforblock7col2.ElementAt<int>(0);
            block7[1, 1] = numbersforblock7col2.ElementAt<int>(1);
            block7[2, 1] = numbersforblock7col2.ElementAt<int>(2);

            txt_701.Text = block7[0, 1].ToString();
            txt_711.Text = block7[1, 1].ToString();
            txt_721.Text = block7[2, 1].ToString();

            List<int> numbersforblock7row3 = new List<int>();
            numbersforblock7row3.AddRange(Enumerable.Range(1, 9).OrderBy(c => rnd.Next()).ToArray());

            numbersforblock7row3.Remove(block1[0, 2]);
            numbersforblock7row3.Remove(block1[1, 2]);
            numbersforblock7row3.Remove(block1[2, 2]);
            numbersforblock7row3.Remove(block4[0, 2]);
            numbersforblock7row3.Remove(block4[1, 2]);
            numbersforblock7row3.Remove(block4[2, 2]);

            numbersforblock7row3.OrderBy(c => rnd.Next()).ToArray();

            block7[0, 2] = numbersforblock7row3.ElementAt<int>(0);
            block7[1, 2] = numbersforblock7row3.ElementAt<int>(1);
            block7[2, 2] = numbersforblock7row3.ElementAt<int>(2);

            txt_702.Text = block7[0, 2].ToString();
            txt_712.Text = block7[1, 2].ToString();
            txt_722.Text = block7[2, 2].ToString();

            //block 5

            //ToDo: edit list from which random numbers are chosen by deleting numbers which e.g. interfere with block 2, so the chance to get a correct combination rises
            while (!ok)
            {
                int i = 0;
                countrows = 0;
                int countcolumns = 0;

                i = 0;
                arr = Enumerable.Range(1, 9).OrderBy(c => rnd.Next()).ToArray();
                for (int i1 = 0; i1 < 3; i1++)
                {
                    for (int i2 = 0; i2 < 3; i2++)
                    {
                        block5[i1, i2] = arr[i];
                        i++;
                    }
                }

                txt_500.Text = block5[0, 0].ToString();
                txt_501.Text = block5[0, 1].ToString();
                txt_502.Text = block5[0, 2].ToString();
                txt_510.Text = block5[1, 0].ToString();
                txt_511.Text = block5[1, 1].ToString();
                txt_512.Text = block5[1, 2].ToString();
                txt_520.Text = block5[2, 0].ToString();
                txt_521.Text = block5[2, 1].ToString();
                txt_522.Text = block5[2, 2].ToString();

                for (int irow = 0; irow < 3; irow++)
                {
                    HashSet<int> set = new HashSet<int>();
                    for (int icolumn = 0; icolumn < 3; icolumn++)
                    {
                        set.Add(block4[irow, icolumn]);
                        set.Add(block5[irow, icolumn]);
                    }
                    if (set.Count < 6)
                    {
                        //MessageBox.Show("Incorrect: " + irow);
                    }
                    else
                    {
                        countrows++;
                    }
                }
                for (int icolumn = 0; icolumn < 3; icolumn++)
                {
                    HashSet<int> set = new HashSet<int>();
                    for (int irow = 0; irow < 3; irow++)
                    {
                        set.Add(block2[irow, icolumn]);
                        set.Add(block5[irow, icolumn]);
                    }
                    if (set.Count < 6)
                    {
                        //MessageBox.Show("Incorrect: " + irow);
                    }
                    else
                    {
                        countcolumns++;
                    }
                }
                if (countrows >= 3 && countcolumns >= 3)
                {
                    ok = true;
                    
                }
            }
            ok=false;

            //block 6
            List<int> numbersforblock6 = new List<int>();
            numbersforblock6.AddRange(Enumerable.Range(1, 9).OrderBy(c => rnd.Next()).ToArray());

            numbersforblock6.Remove(block5[0, 0]);
            numbersforblock6.Remove(block5[0, 1]);
            numbersforblock6.Remove(block5[0, 2]);
            numbersforblock6.Remove(block4[0, 0]);
            numbersforblock6.Remove(block4[0, 1]);
            numbersforblock6.Remove(block4[0, 2]);


            //ToDo: this code messes up the whole thing again because it focuses on 0,0 | 0,1 | 0,2 without checking if all of them are OK
            while (!ok)
            {
                numbersforblock6.OrderBy(c => rnd.Next()).ToArray();
                HashSet<int> set = new HashSet<int>();
                set.Add(block3[0, 0]);
                set.Add(block3[1, 0]);
                set.Add(block3[2, 0]);
                set.Add(block6[0, 0]);
                if(set.Count >= 4)
                {
                    ok = true;
                }
            }
            ok = false;
            while (!ok)
            {
                numbersforblock6.OrderBy(c => rnd.Next()).ToArray();
                HashSet<int> set = new HashSet<int>();
                set.Add(block3[0, 1]);
                set.Add(block3[1, 1]);
                set.Add(block3[2, 1]);
                set.Add(block6[0, 1]);
                if (set.Count >= 4)
                {
                    ok = true;
                }
            }
            ok = false;
            while (!ok)
            {
                numbersforblock6.OrderBy(c => rnd.Next()).ToArray();
                HashSet<int> set = new HashSet<int>();
                set.Add(block3[0, 1]);
                set.Add(block3[1, 1]);
                set.Add(block3[2, 1]);
                set.Add(block6[0, 1]);
                if (set.Count >= 4)
                {
                    ok = true;
                }
            }
            ok = false;

            block6[0, 0] = numbersforblock6.ElementAt<int>(0);
            block6[0, 1] = numbersforblock6.ElementAt<int>(1);
            block6[0, 2] = numbersforblock6.ElementAt<int>(2);

            txt_600.Text = block6[0, 0].ToString();
            txt_601.Text = block6[0, 1].ToString();
            txt_602.Text = block6[0, 2].ToString();

            List<int> numbersforblock6col2 = new List<int>();
            numbersforblock6col2.AddRange(Enumerable.Range(1, 9).OrderBy(c => rnd.Next()).ToArray());

            numbersforblock6col2.Remove(block5[1, 0]);
            numbersforblock6col2.Remove(block5[1, 1]);
            numbersforblock6col2.Remove(block5[1, 2]);
            numbersforblock6col2.Remove(block4[1, 0]);
            numbersforblock6col2.Remove(block4[1, 1]);
            numbersforblock6col2.Remove(block4[1, 2]);

            numbersforblock6col2.OrderBy(c => rnd.Next()).ToArray();

            block6[1, 0] = numbersforblock6col2.ElementAt<int>(0);
            block6[1, 1] = numbersforblock6col2.ElementAt<int>(1);
            block6[1, 2] = numbersforblock6col2.ElementAt<int>(2);

            txt_610.Text = block6[1, 0].ToString();
            txt_611.Text = block6[1, 1].ToString();
            txt_612.Text = block6[1, 2].ToString();

            List<int> numbersforblock6row3 = new List<int>();
            numbersforblock6row3.AddRange(Enumerable.Range(1, 9).OrderBy(c => rnd.Next()).ToArray());

            numbersforblock6row3.Remove(block5[2, 0]);
            numbersforblock6row3.Remove(block5[2, 1]);
            numbersforblock6row3.Remove(block5[2, 2]);
            numbersforblock6row3.Remove(block4[2, 0]);
            numbersforblock6row3.Remove(block4[2, 1]);
            numbersforblock6row3.Remove(block4[2, 2]);

            numbersforblock6row3.OrderBy(c => rnd.Next()).ToArray();

            block6[2, 0] = numbersforblock6row3.ElementAt<int>(0);
            block6[2, 1] = numbersforblock6row3.ElementAt<int>(1);
            block6[2, 2] = numbersforblock6row3.ElementAt<int>(2);

            txt_620.Text = block6[2, 0].ToString();
            txt_621.Text = block6[2, 1].ToString();
            txt_622.Text = block6[2, 2].ToString();

            //ToDo: implement check of block 6
            //block 6 not working

            MessageBox.Show("end reached.");

            btn_create.IsEnabled = true;
            #endregion

        }

        //private void comment() 
        //{ 
        //    #region RowColumnBlock
        //    bool secondrow = false;
        //    int[,] grid = new int[9, 9];
        //    Random rnd = new Random();
        //    bool reshuffle = false;
        //    bool reshuffleBlock = false;

        //    for (int iy = 0; iy < 9; iy++)
        //    {
        //        int[] arr = Enumerable.Range(1, 9).OrderBy(c => rnd.Next()).ToArray();
        //        for (int ix = 0; ix < 9; ix++)
        //        {
        //            grid[iy, ix] = arr[ix]; //adds shuffled numbers 1-9 to grid (horizontal line)
        //        }

        //        #region check of columns
        //        if (secondrow) //activated after second row
        //        {
        //            for (int ix = 0; ix < 9; ix++) // ix = number of column
        //            {
        //                HashSet<int> set = new HashSet<int>();
        //                for (int i = 0; i <= iy; i++)
        //                {
        //                    /*adding 
        //                     * 0,0 | 
        //                     * 1,0 | 
        //                     * ... 
        //                     * then checking whether the numbers are unique in that column*/
        //                    set.Add(grid[i, ix]);
        //                }
        //                if (set.Count <= iy)
        //                {
        //                    reshuffle = true;
        //                    break;
        //                }
        //            }
        //        }
        //        #endregion

        //        #region check of blocks
        //        // is unable to write sth in textbox aka doesn't reach conclusion
        //        if ((iy + 1) / 3 == 1)
        //        {
        //            HashSet<int> set = new HashSet<int>();
        //            for (int i1 = 0; i1 < 2; i1++)
        //            {
        //                for (int i2 = 0; i2 < 2; i2++)
        //                {
        //                    set.Add(grid[i1, i2]);
        //                }
        //            }
        //            if (set.Count < 9)
        //            {
        //                reshuffleBlock = true;
        //            }
        //        }

        //        #endregion

        //        #region Consequences of Checking
        //        if (!reshuffle && !reshuffleBlock)
        //        {
        //            for (int i = iy; i <= iy; i++)
        //            {
        //                txt_output.Text += grid[i, 0] + " | " + grid[i, 1] + " | " + grid[i, 2] + " | " + grid[i, 3] + " | " + grid[i, 4] + " | " + grid[i, 5] + " | " + grid[i, 6] + " | " + grid[i, 7] + " | " + grid[i, 8] + Environment.NewLine;
        //            }
        //        }
        //        else if (reshuffle)
        //        {
        //            MessageBox.Show("reshuffle = true");
        //            iy -= 1;
        //            for (int ix = 0; ix < 9; ix++)
        //            {
        //                grid[iy, ix] = 10; //adds shuffled numbers 1-9 to grid (horizontal line)
        //            }
        //            reshuffle = false;
        //        }
        //        else if (reshuffleBlock)
        //        {
        //            MessageBox.Show("reshuffle Block = true");
        //            iy -= 2;
        //            for (int ix = 0; ix < 9; ix++)
        //            {
        //                grid[iy, ix] = 10; //adds shuffled numbers 1-9 to grid (horizontal line)
        //            }
        //            reshuffleBlock = false;
        //        }
        //        #endregion

        //        // ToDo: implement checking of 3x3 boxes and combine it with check of columns

        //        secondrow = true;
        //    }

        //    btn_create.IsEnabled = true; 
        //    #endregion
        //}
    }
}
