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

        int[,] block1 = new int[3, 3];
        int[,] block2 = new int[3, 3];
        int[,] block3 = new int[3, 3];
        int[,] block4 = new int[3, 3];
        int[,] block5 = new int[3, 3];
        int[,] block6 = new int[3, 3];
        int[,] block7 = new int[3, 3];
        int[,] block8 = new int[3, 3];
        int[,] block9 = new int[3, 3];

        int s1;
        int s2;
        int s3;


        private void CreateSudoku() 
        {
            bool ok = false;
            int countrows;
            Random rnd = new Random();
            int[] arr = Enumerable.Range(1, 9).OrderBy(c => rnd.Next()).ToArray();
            s1 = 0;
            s2 = 0;
            s3 = 0;


            #region block 1, 2
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
                if (countrows >= 3)
                {
                    ok = true;
                }
            }
            ok = false;

            //MessageBox.Show("Block 1 & 2");

            #endregion

            #region block 3
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

            txt_300.Text = block3[0, 0].ToString();
            txt_301.Text = block3[0, 1].ToString();
            txt_302.Text = block3[0, 2].ToString();
            txt_310.Text = block3[1, 0].ToString();
            txt_311.Text = block3[1, 1].ToString();
            txt_312.Text = block3[1, 2].ToString();
            txt_320.Text = block3[2, 0].ToString();
            txt_321.Text = block3[2, 1].ToString();
            txt_322.Text = block3[2, 2].ToString();

            //MessageBox.Show("block 3");

            #endregion

            #region block 4
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

            //MessageBox.Show("block 4");

            #endregion

            #region block 5
            //ToDo: edit list from which random numbers are chosen by deleting numbers which e.g. interfere with block 2, so the chance to get a correct combination rises
            //Check: where to enhance block 5 so it is generated faster
            ok = false;
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
            ok = false;

            txt_500.Text = block5[0, 0].ToString();
            txt_501.Text = block5[0, 1].ToString();
            txt_502.Text = block5[0, 2].ToString();
            txt_510.Text = block5[1, 0].ToString();
            txt_511.Text = block5[1, 1].ToString();
            txt_512.Text = block5[1, 2].ToString();
            txt_520.Text = block5[2, 0].ToString();
            txt_521.Text = block5[2, 1].ToString();
            txt_522.Text = block5[2, 2].ToString();

            //MessageBox.Show("block 5");

            #endregion

            #region block 6
            bool retry = false;
            HashSet<int> set1 = new HashSet<int>();
            HashSet<int> set2 = new HashSet<int>();
            HashSet<int> set3 = new HashSet<int>();


            do
            {
                List<int> numbersforblock6 = new List<int>();
                numbersforblock6.AddRange(Enumerable.Range(1, 9).OrderBy(c => rnd.Next()).ToArray());

                numbersforblock6.Remove(block5[0, 0]);
                numbersforblock6.Remove(block5[0, 1]);
                numbersforblock6.Remove(block5[0, 2]);
                numbersforblock6.Remove(block4[0, 0]);
                numbersforblock6.Remove(block4[0, 1]);
                numbersforblock6.Remove(block4[0, 2]);


                bool ok1 = false;
                int i6 = 0;
                Comparison comparer = new Comparison();
                Comp2 comp2 = new Comp2();
                while (!ok1)
                {
                    switch (i6)
                    {
                        case 1:
                            numbersforblock6.Sort(comparer);
                            break;
                        case 2:
                            numbersforblock6.Sort(comp2);
                            break;
                        default:
                            numbersforblock6.OrderBy(c => rnd.Next()).ToList();
                            break;
                    }
                    block6[0, 0] = numbersforblock6.ElementAt<int>(0);
                    block6[0, 1] = numbersforblock6.ElementAt<int>(1);
                    block6[0, 2] = numbersforblock6.ElementAt<int>(2);

                    set1.Clear();
                    set2.Clear();
                    set3.Clear();

                    set1.Add(block3[0, 0]);
                    set1.Add(block3[1, 0]);
                    set1.Add(block3[2, 0]);
                    set1.Add(block6[0, 0]);

                    set2.Add(block3[0, 1]);
                    set2.Add(block3[1, 1]);
                    set2.Add(block3[2, 1]);
                    set2.Add(block6[0, 1]);

                    set3.Add(block3[0, 2]);
                    set3.Add(block3[1, 2]);
                    set3.Add(block3[2, 2]);
                    set3.Add(block6[0, 2]);

                    if (set1.Count > 3 && set2.Count > 3 && set3.Count > 3)
                    {
                        ok1 = true;
                    }
                    else if (i6 > 10)
                    {
                        retry = true;
                        break;
                    }

                    i6++;
                }


                List<int> numbersforblock6row2 = new List<int>();
                numbersforblock6row2.AddRange(Enumerable.Range(1, 9).OrderBy(c => rnd.Next()).ToArray());

                numbersforblock6row2.Remove(block5[1, 0]);
                numbersforblock6row2.Remove(block5[1, 1]);
                numbersforblock6row2.Remove(block5[1, 2]);
                numbersforblock6row2.Remove(block4[1, 0]);
                numbersforblock6row2.Remove(block4[1, 1]);
                numbersforblock6row2.Remove(block4[1, 2]);

                bool ok2 = false;
                i6 = 0;
                while (!ok2)
                {
                    switch (i6)
                    {
                        case 1:
                            numbersforblock6row2.Sort(comparer);
                            break;
                        case 2:
                            numbersforblock6row2.Sort(comp2);
                            break;
                        default:
                            numbersforblock6row2.OrderBy(c => rnd.Next()).ToList();
                            break;
                    }

                    block6[1, 0] = numbersforblock6row2.ElementAt<int>(0);
                    block6[1, 1] = numbersforblock6row2.ElementAt<int>(1);
                    block6[1, 2] = numbersforblock6row2.ElementAt<int>(2);

                    set1.Clear();
                    set2.Clear();
                    set3.Clear();

                    set1.Add(block3[0, 0]);
                    set1.Add(block3[1, 0]);
                    set1.Add(block3[2, 0]);
                    set1.Add(block6[1, 0]);

                    set2.Add(block3[0, 1]);
                    set2.Add(block3[1, 1]);
                    set2.Add(block3[2, 1]);
                    set2.Add(block6[1, 1]);

                    set3.Add(block3[0, 2]);
                    set3.Add(block3[1, 2]);
                    set3.Add(block3[2, 2]);
                    set3.Add(block6[1, 2]);

                    if (set1.Count > 3 && set2.Count > 3 && set3.Count > 3)
                    {
                        ok2 = true;
                    }
                    else if (i6 > 10)
                    {
                        retry = true;
                        break;
                    }

                    i6++;
                }

                List<int> numbersforblock6row3 = new List<int>();
                numbersforblock6row3.AddRange(Enumerable.Range(1, 9).OrderBy(c => rnd.Next()).ToArray());

                numbersforblock6row3.Remove(block5[2, 0]);
                numbersforblock6row3.Remove(block5[2, 1]);
                numbersforblock6row3.Remove(block5[2, 2]);
                numbersforblock6row3.Remove(block4[2, 0]);
                numbersforblock6row3.Remove(block4[2, 1]);
                numbersforblock6row3.Remove(block4[2, 2]);

                i6 = 0;
                bool ok3 = false;
                while (!ok3)
                {
                    switch (i6)
                    {
                        case 1:
                            numbersforblock6row3.Sort(comparer);
                            break;
                        case 2:
                            numbersforblock6row3.Sort(comp2);
                            break;
                        default:
                            numbersforblock6row3.OrderBy(c => rnd.Next()).ToList();
                            break;
                    }

                    block6[2, 0] = numbersforblock6row3.ElementAt<int>(0);
                    block6[2, 1] = numbersforblock6row3.ElementAt<int>(1);
                    block6[2, 2] = numbersforblock6row3.ElementAt<int>(2);

                    set1.Clear();
                    set2.Clear();
                    set3.Clear();

                    set1.Add(block3[0, 0]);
                    set1.Add(block3[1, 0]);
                    set1.Add(block3[2, 0]);
                    set1.Add(block6[2, 0]);

                    set2.Add(block3[0, 1]);
                    set2.Add(block3[1, 1]);
                    set2.Add(block3[2, 1]);
                    set2.Add(block6[2, 1]);

                    set3.Add(block3[0, 2]);
                    set3.Add(block3[1, 2]);
                    set3.Add(block3[2, 2]);
                    set3.Add(block6[2, 2]);

                    if (set1.Count > 3 && set2.Count > 3 && set3.Count > 3)
                    {
                        ok3 = true;
                    }
                    else if (i6 > 10)
                    {
                        retry = true;
                        break;
                    }
                    i6++;
                }

                if (ok1 && ok2 && ok3)
                {
                    retry = false;
                }

            } while (retry);

            txt_600.Text = block6[0, 0].ToString();
            txt_601.Text = block6[0, 1].ToString();
            txt_602.Text = block6[0, 2].ToString();
            txt_610.Text = block6[1, 0].ToString();
            txt_611.Text = block6[1, 1].ToString();
            txt_612.Text = block6[1, 2].ToString();
            txt_620.Text = block6[2, 0].ToString();
            txt_621.Text = block6[2, 1].ToString();
            txt_622.Text = block6[2, 2].ToString();

            MessageBox.Show("block 6");

            #endregion
            
            #region block 7, 8, 9
            bool incorrect = true;
            bool incorrect2 = true;
            do
            {
                List<int> numbersforblock7col1 = numbersforcol(block1, block4, 0);

                List<int> numbersforblock7col2 = numbersforcol(block1, block4, 1);

                List<int> numbersforblock7col3 = numbersforcol(block1, block4, 2);

                List<int> numbersforblock8col1 = numbersforcol(block2, block5, 0);

                List<int> numbersforblock8col2 = numbersforcol(block2, block5, 1);

                List<int> numbersforblock8col3 = numbersforcol(block2, block5, 2);

                List<int> numbersforblock9col1 = numbersforcol(block3, block6, 0);

                List<int> numbersforblock9col2 = numbersforcol(block3, block6, 1);

                List<int> numbersforblock9col3 = numbersforcol(block3, block6, 2);

                while (incorrect2)
                {
                    block7 = LastRow(numbersforblock7col1, numbersforblock7col2, numbersforblock7col3);
                    block8 = LastRow(numbersforblock8col1, numbersforblock8col2, numbersforblock8col3);
                    block9 = LastRow(numbersforblock9col1, numbersforblock9col2, numbersforblock9col3);


                    set1.Clear();
                    set2.Clear();
                    set3.Clear();

                    set1.Add(block7[0, 0]);
                    set1.Add(block7[0, 1]);
                    set1.Add(block7[0, 2]);
                    set1.Add(block9[0, 0]);
                    set1.Add(block9[0, 1]);
                    set1.Add(block9[0, 2]);
                    set1.Add(block8[0, 0]);
                    set1.Add(block8[0, 1]);
                    set1.Add(block8[0, 2]);

                    set2.Add(block7[1, 0]);
                    set2.Add(block7[1, 1]);
                    set2.Add(block7[1, 2]);
                    set2.Add(block9[1, 0]);
                    set2.Add(block9[1, 1]);
                    set2.Add(block9[1, 2]);
                    set2.Add(block8[1, 0]);
                    set2.Add(block8[1, 1]);
                    set2.Add(block8[1, 2]);

                    set3.Add(block7[2, 0]);
                    set3.Add(block7[2, 1]);
                    set3.Add(block7[2, 2]);
                    set3.Add(block9[2, 0]);
                    set3.Add(block9[2, 1]);
                    set3.Add(block9[2, 2]);
                    set3.Add(block8[2, 0]);
                    set3.Add(block8[2, 1]);
                    set3.Add(block8[2, 2]);

                    if (set1.Count > 8 && set2.Count > 8 && set3.Count > 8)
                    {
                        incorrect2 = false;
                    }
                    else
                    {
                        MessageBox.Show(set1.Count + ", " + set2.Count + ", " + set3.Count);
                    }
                }

            } while (incorrect);
            //ToDo: think of reshuffling several blocks so the sudoku can be completed. Until now, it's possible that the last block cannot be made because existing numbers interfere with it unsolvable.
            txt_700.Text = block7[0, 0].ToString();
            txt_710.Text = block7[1, 0].ToString();
            txt_720.Text = block7[2, 0].ToString();
            txt_701.Text = block7[0, 1].ToString();
            txt_711.Text = block7[1, 1].ToString();
            txt_721.Text = block7[2, 1].ToString();
            txt_702.Text = block7[0, 2].ToString();
            txt_712.Text = block7[1, 2].ToString();
            txt_722.Text = block7[2, 2].ToString();

            txt_800.Text = block8[0, 0].ToString();
            txt_810.Text = block8[1, 0].ToString();
            txt_820.Text = block8[2, 0].ToString();
            txt_801.Text = block8[0, 1].ToString();
            txt_811.Text = block8[1, 1].ToString();
            txt_821.Text = block8[2, 1].ToString();
            txt_802.Text = block8[0, 2].ToString();
            txt_812.Text = block8[1, 2].ToString();
            txt_822.Text = block8[2, 2].ToString();

            txt_900.Text = block9[0, 0].ToString();
            txt_910.Text = block9[1, 0].ToString();
            txt_920.Text = block9[2, 0].ToString();
            txt_901.Text = block9[0, 1].ToString();
            txt_911.Text = block9[1, 1].ToString();
            txt_921.Text = block9[2, 1].ToString();
            txt_902.Text = block9[0, 2].ToString();
            txt_912.Text = block9[1, 2].ToString();
            txt_922.Text = block9[2, 2].ToString();

            #endregion


            MessageBox.Show("block 9");

            MessageBox.Show("end reached.");

            btn_create.IsEnabled = true;
        }

        /// <summary>
        /// to sort a list ascending.
        /// </summary>
        class Comparison : IComparer<int>
        {
            public int Compare(int x, int y)
            {
                if (x == 0 || y == 0)
                {
                    return 0;
                }

                // CompareTo() method
                return x.CompareTo(y);
            }
        }

        /// <summary>
        /// to sort a list descending.
        /// </summary>
        class Comp2 : IComparer<int>
        {
            public int Compare(int x, int y)
            {
                if (x == 0 || y == 0)
                {
                    return 0;
                }

                // CompareTo() method
                return y.CompareTo(x);
            }
        }

        /// <summary>
        /// a method that deletes vertical given values from vertical1 and vertical2 out of a 1-9 list at the specified column.
        /// </summary>
        /// <param name="vertical1">first block that is considered</param>
        /// <param name="vertical2">second block that is considered</param>
        /// <param name="col">specify the column you want to make (0, 1, 2)</param>
        /// <returns>returns a list with 3 values from 1-9</returns>
        private List<int> numbersforcol(int[,] vertical1, int[,] vertical2, int col)
        {
            List<int> numbers = new List<int>() { 1,2,3,4,5,6,7,8,9 };
            numbers.Remove(vertical1[0, col]);
            numbers.Remove(vertical1[1, col]);
            numbers.Remove(vertical1[2, col]);
            numbers.Remove(vertical2[0, col]);
            numbers.Remove(vertical2[1, col]);
            numbers.Remove(vertical2[2, col]);

            return numbers;
        }

        private int[,] LastRow(List<int> row1, List<int> row2, List<int> row3)
        {
            List<int> numbers = new List<int>();
            Random rnd = new Random();
            int[,] block = new int[3, 3];

            numbers = row1.OrderBy(c => rnd.Next()).ToList();
            block[0, 0] = numbers.ElementAt<int>(0);
            block[1, 0] = numbers.ElementAt<int>(1);
            block[2, 0] = numbers.ElementAt<int>(2);

            numbers = row2.OrderBy(c => rnd.Next()).ToList();
            block[0, 1] = numbers.ElementAt<int>(0);
            block[1, 1] = numbers.ElementAt<int>(1);
            block[2, 1] = numbers.ElementAt<int>(2);

            numbers = row3.OrderBy(c => rnd.Next()).ToList();
            block[0, 2] = numbers.ElementAt<int>(0);
            block[1, 2] = numbers.ElementAt<int>(1);
            block[2, 2] = numbers.ElementAt<int>(2);

            return block;
        }
    }
}
