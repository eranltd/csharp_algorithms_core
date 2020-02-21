using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterView.Questions
{

    //https://www.geeksforgeeks.org/print-all-subarrays-with-0-sum/
    //https://www.geeksforgeeks.org/sum-of-xor-of-all-subarrays/
    //https://www.geeksforgeeks.org/sum-of-all-subarrays/
    //https://www.geeksforgeeks.org/count-of-subarrays-with-sum-at-least-k/
    //https://www.geeksforgeeks.org/number-subarrays-sum-less-k/
    //https://www.geeksforgeeks.org/find-number-subarrays-even-sum/
    //https://www.geeksforgeeks.org/number-subarrays-given-product/
    //https://www.geeksforgeeks.org/generating-subarrays-using-recursion/
    //https://www.geeksforgeeks.org/sum-of-minimum-elements-of-all-subarrays/
    //https://www.geeksforgeeks.org/number-of-subarrays-with-gcd-equal-to-1/



    public static class VariousArrayAlgorithms
    {


        public static void Run()
        {
            Console.WriteLine("VariousArrayAlgorithms");
            Console.WriteLine("Find a local minima in an array");

            int[] localMinimaArr = { 9, 6, 3, 14, 5, 7, 4 };
            FindLocalMinimaBinarySearch(localMinimaArr);

            Console.WriteLine("Print all subarrays with 0 sum");

            //int[] SubArrayZero = { 6, 3, -1, -3, 4, -2, 2, 4, 6, -12, -7 };

            int[] SubArrayZero = { 2, -2 };
            PrintAllSubarraysZeroSum(SubArrayZero);

        }






        static void FindLocalMinima(int[] arr)
        {
            int localMinimaIndex = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                int left = i - 1;
                int right = i + 1;
                if (left > 0 && right < arr.Length)
                {
                    if (arr[left] > arr[i] && arr[right]> arr[i])
                        localMinimaIndex = i;
                    break;
                }

            }
            Console.WriteLine($"Local Minima Found at arr[{localMinimaIndex}] = {arr[localMinimaIndex]}");

        }

        static int localMinUtil(int[] arr, int low,
                                   int high, int n)
        {
            // Find index of middle element 
            int mid = low + (high - low) / 2;


            // Compare middle element with its neighbours 
            // (if neighbours exist) 
            if (mid == 0 || arr[mid - 1] > arr[mid] &&
               mid == n - 1 || arr[mid] < arr[mid + 1])
                return mid;

            // If middle element is not minima and its left 
            // neighbour is smaller than it, then left half 
            // must have a local minima. 
            else if (mid > 0 && arr[mid - 1] < arr[mid])
                return localMinUtil(arr, low, mid - 1, n);

            // If middle element is not minima and its right 
            // neighbour is smaller than it, then right half 
            // must have a local minima. 
            return localMinUtil(arr, mid + 1, high, n);
        }
        static void FindLocalMinimaBinarySearch(int[] arr)
        {
            int localMinimaIndex = 0;
            int n = arr.Length;
            localMinimaIndex = localMinUtil(arr, 0, n - 1, n);
            Console.WriteLine($"Local Minima Found at arr[{localMinimaIndex}] = {arr[localMinimaIndex]}");
        }




        //A simple solution is to consider all subarrays one by one and check if sum of every subarray is equal to 0 or not. The complexity of this solution would be O(n^2).
        static void PrintAllSubarraysZeroSum(int[] arr)
        {
            //find which sub-array sum is zero
            //List<int[]> subArrays = GetSubArrays(arr);
            List<int[]> sub_arrays = new List<int[]>();

            GetSubArraysRecursive(ref sub_arrays, arr,0,0);

            //find which sub-array sum is zero
            foreach (var subArray in sub_arrays)
            {
                int sum = subArray.Sum();
                if (sum == 0)
                {
                    Console.WriteLine();
                    Console.Write("Found Sub-Array with sum = 0 : ");
                    subArray.ToList().ForEach(item => Console.Write($"[{item}] "));
                    Console.WriteLine();

                }
            }

        }

        static void PrintAllSubarraysZeroSumHashing(int[] arr)
        {
            List<int[]> subArrays = GetSubArrays(arr);
        }

        private static List<int[]> GetSubArrays(int[] arr)
        {
            List<int[]> sub_arrays = new List<int[]>();

            int arrLength = arr.Length;

            for(int i=0;i <arrLength;i++)//starting point
            {
                for(int j=i;j< arrLength; j++)//end point
                {
                    List<int> tempArr = new List<int>();
                    for (int k=i;k<=j;k++)//iterating on array
                    {
                        tempArr.Add(arr[k]);

                    }
                    sub_arrays.Add(tempArr.ToArray());
                }

            }





            return sub_arrays;
        }

        private static void GetSubArraysRecursive(ref List<int[]> subArrays, int[] arr, int start, int end)
        {
            if (end == arr.Length )
                return;


            //start from 0 and increment end point by 1 till reacting end
            else if (start > end)
                GetSubArraysRecursive(ref subArrays, arr, 0, end + 1);

            else
            {
                //between start and end -> prepare sub-array
                List<int> tempArr = new List<int>();

                for (int i = start; i <= end; i++)
                {
                    tempArr.Add(arr[i]);
                }
                subArrays.Add(tempArr.ToArray());
                GetSubArraysRecursive(ref subArrays, arr, start + 1, end);
            }



        }



    }
}
