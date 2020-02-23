using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterView.Questions
{


    public static class VariousAlgorithms
    {
        static int ROW = 2, COL = 2;

        public static void Run()
        {
            Console.WriteLine("VariousAlgorithms");


            //var charArray = "Data Structures and Algorithms in JAVA".ToCharArray();
            //Console.WriteLine($"charCircularMaker : n=6: {charCircularMaker(charArray, 6)}");

            //int[,] M = new int[,] { { 1, 1, 0, 0, 0 },
            //                      { 0, 1, 0, 0, 1 },
            //                      { 1, 0, 0, 1, 1 },
            //                      { 0, 0, 0, 0, 0 },
            //                      { 1, 0, 1, 0, 1 } };

            //int[,] square2 = new int[,] {{  1, 1 },
            //                             { 0, 1, } };



            //Console.Write("Number of islands is: " + FindTheNumberOfIslands(square2));



            //int convertMe = 217;
            //List<char> result = new List<char>();
            //convertToBinary(convertMe, result);

            //Console.WriteLine($"Representation of int({convertMe}) ---> binary(");
            //result.ForEach(item => Console.Write((char)item + ','));

            //Console.WriteLine();
            //int[] CountDistinctElementsArr = { 1, 2, 1, 3, 4, 2, 3 };
            //Console.WriteLine("CountDistinctElementsINEveryWndowOfSizeK:");


            //CountDistinctElementsArr.ToList().ForEach(item => Console.Write($"[{item}] "));
            //Console.WriteLine();
            //Console.WriteLine("CountDistinctElementsINEveryWndowOfSize 4:");
            //CountDistinctElementsINEveryWndowOfSizeK(CountDistinctElementsArr, 4);


            //Console.WriteLine();
            //int[] majorityArr = { 1, 1, 2, 1, 3, 5, 1 };
            //Console.Write("findMajority arr:"); majorityArr.ToList().ForEach(item => Console.Write($"[{item}] "));
            //Console.WriteLine();
            //FindAndPrintMajority(majorityArr);

            PowRecursive();
            SumOfDigitsRecursive();
            FiboRecursive();
            //FiboIterative();
        }



        private static void FindAndPrintMajority(int[] arr)
        {
            int minCountTimes = arr.Length / 2;
            Dictionary<int, int> map = new Dictionary<int, int>();

            for (int i = 0; i < arr.Length; i++)
            {
                if (map.ContainsKey(arr[i]))
                {
                    map[arr[i]] = map[arr[i]] + 1;
                    if (map[arr[i]] > minCountTimes)
                    {
                        Console.WriteLine("Majority found ->  " +
                                                    arr[i]);
                        return;
                    }
                }
                else
                    map[arr[i]] = 1;
            }
        }
        internal static void convertToBinary(int n, List<char> chars)
        {

            if (n > 1)
            {
                convertToBinary(n / 2, chars);
            }

            chars.Add((n % 2 == 0) ? '0' : '1');

        }

        internal static String charCircularMaker(char[] chars, int n)
        {
            string str = new string(chars);

            return (str.Substring(n)) + (str.Substring(0, n));
        }

        // A function to check if 
        // a given cell (row, col) 
        // can be included in DFS 






        // row number is in range, 
        // column number is in range 
        // and value is 1 and not 
        // yet visited 
        static bool isSafe(int[,] M, int row, int col, bool[,] visited) => (row >= 0) && (row < ROW)
                && (col >= 0) && (col < COL)
                && (M[row, col] == 1
                && !visited[row, col]);


        // A utility function to do 
        // DFS for a 2D boolean matrix. 
        // It only considers the 8 
        // neighbors as adjacent vertices 
        static void DFS(int[,] M, int row, int col, bool[,] visited)
        {
            // These arrays are used to 
            // get row and column numbers 
            // of 8 neighbors of a given cell 
            int[] rowNbr = new int[] { -1, -1, -1, 0, 0, 1, 1, 1 };

            int[] colNbr = new int[] { -1, 0, 1, -1, 1, -1, 0, 1 };

            // Mark this cell 
            // as visited 
            visited[row, col] = true;

            // Recur for all 
            // connected neighbours 
            for (int k = 0; k < 8; ++k)

                if (isSafe(M, row + rowNbr[k], col + colNbr[k], visited))
                {
                    DFS(M, row + rowNbr[k], col + colNbr[k], visited);
                    Console.WriteLine($"k={ k}");
                    PrintBoolMatrix(visited);
                }



        }


        static void PrintBoolMatrix(bool[,] M)
        {

            int m = ROW;
            int n = COL;


            Console.WriteLine("Printing Matrix: ");
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(M[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }

        internal static int FindTheNumberOfIslands(int[,] M)
        {
            // Make a bool array to 
            // mark visited cells. 
            // Initially all cells 
            // are unvisited 
            bool[,] visited = new bool[ROW, COL];
            // Initialize count as 0 and 
            // travese through the all 
            // cells of given matrix 
            int count = 0;
            for (int i = 0; i < ROW; ++i)
                for (int j = 0; j < COL; ++j)
                    if (M[i, j] == 1 && !visited[i, j])
                    {
                        // If a cell with value 1 is not 
                        // visited yet, then new island 
                        // found, Visit all cells in this 
                        // island and increment island count 
                        DFS(M, i, j, visited);
                        ++count;
                    }

            return count;


        }


        internal static void CountDistinctElementsINEveryWndowOfSizeK(int[] arr, int windowSize)
        {
            int arrSize = arr.Length;
            // Traverse through every window 
            for (int i = 0; i <= arrSize - windowSize; i++)
            {
                int[] newArr = new int[windowSize];
                Array.Copy(arr, i, newArr, 0, windowSize);
                newArr.ToList().ForEach(item => Console.Write(item + ", "));
                Console.WriteLine("----->" + CountDistinctNumbersInArr(newArr));
            }
        }

        internal static int CountDistinctNumbersInArr(int[] arr) {
            HashSet<int> set = new System.Collections.Generic.HashSet<int>(arr);
            return set.Count;
        }

        internal static void PowRecursive() {

            Console.WriteLine("FactorialRecursive of n=4, b=4");
            Console.WriteLine(PowRecursiveHelper(4, 4));
        }
        internal static int PowRecursiveHelper(int n, int b) 
        {
            if (b == 1)
                return n;

            return PowRecursiveHelper(n,b-1) * n;
        
        }


        internal static void SumOfDigitsRecursive()
        {
            Console.WriteLine("SumOfDigitsRecursive of n=123456789");
            Console.WriteLine(SumOfDigitsRecursiveHelper(123456789));
        }
        internal static int SumOfDigitsRecursiveHelper(int n)
        {
            if (n == 0)
                return 0;

            return SumOfDigitsRecursiveHelper(n / 10) + n % 10;
        }

        internal static void FiboRecursive()
        {
            Console.WriteLine("FiboRecursive of n=11");
            Console.WriteLine(SumOfDigitsRecursiveHelper(11));
        }
        internal static int FiboRecursiveHelper(int n)
        {
            if (n == 1 || n == 1 )
                return 1;

            return FiboRecursiveHelper(n-1) + FiboRecursiveHelper(n - 2) +n;
        }
    }

    }
