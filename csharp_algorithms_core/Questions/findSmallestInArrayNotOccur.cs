using InterView.DataStructres;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterView.Questions
{
    //given array of N integers, return the smallest positive value (x>0) that does not occur on A
    public static class FindSmallestInArrayNotOccur
    {
        public static void Run()
        {
            int[] A = new int[6] { 1, 3, 6, 4, 1, 2 };
            int[] B = new int[3] { 1, 2, 3 };
            int[] C = new int[2] { -1, 3 };

            Console.WriteLine($"getSmallestNotExist for A : {getSmallestNotExist(A)}");
            Console.WriteLine($"getSmallestNotExist for B : {getSmallestNotExist(B)}");
            Console.WriteLine($"getSmallestNotExist for C : {getSmallestNotExist(C)}");


            Console.WriteLine($"getSmallestNotExistBetter for A : {getSmallestNotExistBetter(A)}");
            Console.WriteLine($"getSmallestNotExistBetter for B : {getSmallestNotExistBetter(B)}");
            Console.WriteLine($"getSmallestNotExistBetter for C : {getSmallestNotExistBetter(C)}");
        }

        public static void SwapNum(ref int x, ref int y)
        {

            var tempswap = x;
            x = y;
            y = tempswap;

        }

        //O(nlogn);
        public static int getSmallestNotExist(int [] arr)
        {
            for(int i=1;i<1000;i++)
            {
                if (Array.Exists(arr, item => item == i))
                    continue;
                else
                    return i;
            }
            return 1;
        }
    

    //O(n)
    public static int getSmallestNotExistBetter(int[] arr)
    {
        int n = arr.Length;


        //seregate

        for(int i=0;i<n;i++)
        {
            if (arr[i] <= 0 && (i + 1) < n)
                SwapNum(ref arr[i],ref arr[i+1]); //move all negative to the side
        }


            // Mark arr[i] as visited by making arr[arr[i] - 1] negative.
            for (int i = 0; i < n; i++)
            {
                if (Math.Abs(arr[i]) - 1 < n && arr[Math.Abs(arr[i]) - 1] > 0)
                    arr[Math.Abs(arr[i]) - 1] = -arr[Math.Abs(arr[i]) - 1];
            }

            // Return the first index value at which is positive
            for (int i = 0; i < n; i++)
                if (arr[i] > 0)
                    return i + 1;

            return n + 1;



           
    }
}
}
