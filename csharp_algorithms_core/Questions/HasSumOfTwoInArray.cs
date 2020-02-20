using InterView.DataStructres;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterView.Questions
{
    //given array of N integers, return the smallest positive value (x>0) that does not occur on A
    public static class HasSumOfTwoInArray
    {
        public static void Run()
        {
            int[] A = new int[6] { 1, 3, 6, 4, 1, 2 };
            int[] B = new int[3] { 1, 2, 3 };
            int[] C = new int[2] { -1, 3 };


            Console.WriteLine($"HasSumOfTwo({A.ToString()},6,3) -> {HasSumOfTwo(A, 6, 3)}");
            Console.WriteLine($"HasSumOfTwoSecondRevision({A.ToArray()},6,3) -> {HasSumOfTwoSecondRevision(A, 6, 3)}");

        }

        internal static bool HasSumOfTwo(int[] A,int size,int sum)
        {
            int l = 0;
            int r = A.Length - 1;

            while(l < r)
            {
                if (A[l] + A[r] == sum)
                    return true;
                else if (A[l] + A[r] < sum)
                    l++;
                else if (A[l] + A[r] > sum)
                    r--;
            }

            return false;
        }

        internal static bool HasSumOfTwoSecondRevision(int[] A, int size, int sum)
        {

            HashSet<int> hashSet = new HashSet<int>();
            for(int i = 0; i < size; i++)
            {
                int missingNumber = sum - A[i];
                if (hashSet.Contains(missingNumber))
                    return true;

                hashSet.Add(A[i]);
            }
            return false;
        }
    }
}
