using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterView.Questions
{

    //https://www.geeksforgeeks.org/print-all-subarrays-with-0-sum/
    //https://www.geeksforgeeks.org/count-of-subarrays-with-sum-at-least-k/
    //https://www.geeksforgeeks.org/number-subarrays-sum-less-k/
    //https://www.geeksforgeeks.org/find-number-subarrays-even-sum/
    //https://www.geeksforgeeks.org/number-subarrays-given-product/
    //https://www.geeksforgeeks.org/generating-subarrays-using-recursion/
    //https://www.geeksforgeeks.org/sum-of-minimum-elements-of-all-subarrays/
    //https://www.geeksforgeeks.org/number-of-subarrays-with-gcd-equal-to-1/
    //https://www.geeksforgeeks.org/count-subarrays-with-same-even-and-odd-elements/
    //https://www.geeksforgeeks.org/count-the-number-of-contiguous-increasing-and-decreasing-subsequences-in-a-sequence/
    //https://www.geeksforgeeks.org/count-of-non-decreasing-arrays-of-length-n-formed-with-values-in-range-l-to-r/
    //https://www.geeksforgeeks.org/find-the-count-of-strictly-decreasing-subarrays/
    //https://www.geeksforgeeks.org/number-subarrays-sum-less-k/

    //https://www.programcreek.com/2012/11/top-10-algorithms-for-coding-interview/

    //https://www.geeksforgeeks.org/window-sliding-technique/

    public static class VariousArrayAlgorithms
    {


        public static void Run()
        {
            Console.WriteLine("VariousArrayAlgorithms");
            Console.WriteLine("Find a local minima in an array");

            int[] localMinimaArr = { 9, 6, 3, 14, 5, 7, 4 };
            FindLocalMinimaBinarySearch(localMinimaArr);
            Console.WriteLine();


            Console.WriteLine("************************************************************");
            //int[] SubArrayZero = { 6, 3, -1, -3, 4, -2, 2, 4, 6, -12, -7 };

            int[] SubArrayZero = { 6,3,-9,-2,2,4,-4 };

            SubArrayZero.ToList().ForEach(item => Console.Write($"[{item}] "));
            Console.WriteLine("Print all subarrays with 0 sum");

            Console.WriteLine("Print all subarrays with 0 sum - O(n^2)");

            PrintAllSubarraysZeroSum(SubArrayZero);

            Console.WriteLine("Print all subarrays with 0 sum - Hashing Algorithm");

            PrintAllSubarraysZeroSumHashing(SubArrayZero);
            Console.WriteLine("************************************************************");

            Console.WriteLine($"countSubarray with  sum < 10  = {countSubarray(SubArrayZero,10)}");




        }


        //solve using 'slideing window'
        static int countSubarray(int[] arr,
                              int maxSum)
        {
            int n = arr.Length;
            int start = 0, end = 0;
            int count = 0, sum = arr[0];

            while (start < n && end < n)
            {
                // If sum is less than k, 
                // move end by one position. 
                // Update count and sum 
                // accordingly. 
                if (sum < maxSum)
                {
                    end++;

                    if (end >= start)
                        count += end - start;

                    // For last element, 
                    // end may become n. 
                    if (end < n)
                        sum += arr[end];
                }

                // If sum is greater than or 
                // equal to k, subtract 
                // arr[start] from sum and 
                // decrease sliding window by 
                // moving start by one position 
                else
                {
                    sum -= arr[start];
                    start++;
                }
            }

            return count;
        
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

            // create an empty map  
            Dictionary<int, List<int>> TrackingSubSumArray = new Dictionary<int, List<int>>();

            // create an empty vector of pairs to store  
            // subarray starting and ending index  
            List<(int first,int second)> SubArraysFoundByIndex = new List<(int first, int second)>();

            // Maintains sum of elements so far 
            int sum = 0;


            for (int i = 0; i < arr.Length; i++)
            {
                // add current element to sum  
                sum += arr[i];

                // if sum is 0, we found a subarray starting  
                // from index 0 and ending at index i  
                if (sum == 0)
                    SubArraysFoundByIndex.Add((0,i));





                //find sub-arrays
                List<int> al = new List<int>(); //

                // If sum already exists in the map there exists  
                // at-least one subarray ending at index i with  
                // 0 sum  


                if (TrackingSubSumArray.ContainsKey(sum))
                {
                    // TrackingSubSumArray[sum] stores starting index  
                    // of all subarrays


                    al = TrackingSubSumArray[sum];



                    for (int it = 0; it < al.Count; it++)
                    {
                        SubArraysFoundByIndex.Add((al[it] + 1, i));
                    }

                }



                al.Add(i);
                if (TrackingSubSumArray.ContainsKey(sum))
                    TrackingSubSumArray[sum] = al;
                else
                    TrackingSubSumArray.Add(sum, al);



            }

            // if we did not find any subarray with 0 sum,  
            // then subarray does not exists  
            if (SubArraysFoundByIndex.Count == 0)
                Console.WriteLine("No subarray exists");
            else
                SubArraysFoundByIndex.ForEach(p => Console.WriteLine("Subarray found from Index " +
                               p.first + " to " + p.second));


            
            ;


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
