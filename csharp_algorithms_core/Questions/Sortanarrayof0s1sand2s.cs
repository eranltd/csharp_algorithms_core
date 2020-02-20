using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterView.Questions
{
	/* C# program to solve Rat in a Maze problem using backtracking */

	public static class Sortanarrayof0s1sand2s
	{
		public static void Run()
		{
            int[] arr = { 0, 1, 1, 0, 1, 2, 1, 2, 0, 0, 0, 1 };
            int arr_size = arr.Length;
            sort012(arr, arr_size);

            Console.Write("Array after seggregation ");

            printArray(arr, arr_size);
        }

        private static void sort012(int[] arr, int arr_size)
        {
            //reduction of problem ---> sort 1's and 0's an array.

            int low = 0;
            int i = 0;
            int high = arr.Length - 1;
            int temp;

            while(i <= high)
            {
                switch(arr[i])
                {
                    case 0:
                        //swap and increment low
                        temp = arr[low];
                        arr[low] = arr[i];
                        arr[i] = temp;

                        low++;
                        i++;
                        break;

                    case 1:
                        i++;
                        break;
                    case 2:
                        //swap and decrement high

                        temp = arr[i];
                        arr[i] = arr[high];
                        arr[high] = temp; 
                        high--;
                        break;
                }
            }

        }

        private static void printArray(int[] arr, int arr_size)
        {
            int i;

            for (i = 0; i < arr_size; i++)
                Console.Write(arr[i] + " ");
            Console.WriteLine("");
        }

        internal static void swapChars<T>(ref T x, ref T y)
        {
            T tmp = x;
            x = y;
            y = tmp;
        }
    }
}
