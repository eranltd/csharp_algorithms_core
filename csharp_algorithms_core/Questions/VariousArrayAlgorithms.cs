﻿using InterView.DataStructres;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        public static List<int> TestNumbers = new List<int>() { 32, 5, 51712, 1041, 15  , 2147483647 , 1376796946 , 1073741825 , 1610612737 , 6291457 , 1162, 561892, 6291457, 74901729 };
        
        
        public static void PrintArr(int[] arr) { Console.WriteLine(); arr.ToList().ForEach(item => Console.Write($"[{item}] ")); Console.WriteLine(); }
        public static void Run()
        {
            int[] arr = { 38, 27, 43, 3, 9, 82, 10 };

            Console.WriteLine("VariousArrayAlgorithms");

            //Console.WriteLine("Find a local minima in an array");
            //int[] localMinimaArr = { 9, 6, 3, 14, 5, 7, 4 };
            //FindLocalMinimaBinarySearch(localMinimaArr);
            //Console.WriteLine();
            //Console.WriteLine("************************************************************");
            ////int[] SubArrayZero = { 6, 3, -1, -3, 4, -2, 2, 4, 6, -12, -7 };
            //int[] SubArrayZero = { 6,3,-9,-2,2,4,-4 };
            //PrintArr(SubArrayZero);
            //Console.WriteLine("Print all subarrays with 0 sum");
            //Console.WriteLine("Print all subarrays with 0 sum - O(n^2)");
            //PrintAllSubarraysZeroSum(SubArrayZero);
            //Console.WriteLine("Print all subarrays with 0 sum - Hashing Algorithm");
            //PrintAllSubarraysZeroSumHashing(SubArrayZero);
            //Console.WriteLine("************************************************************");
            //Console.WriteLine($"countSubarray with  sum < 10  = {countSubarray(SubArrayZero,10)}");

            //Console.WriteLine("************************************************************");
            //Console.WriteLine($"bruteforce -> get max sum of sub-array ");


            //int k = 4;
            //int n = arr.Length;
            //Console.WriteLine(maxSum(arr, n, k));


            //Console.WriteLine($"sliding window -> get max sum of sub-array ");
            //Console.WriteLine(MaxSumSlidingWindow(arr, n, k));

            //SelectionSort(arr);
            // BubbleSort(arr);


            //BubbleSortRecursive(arr, arr.Length);
            //InsertionSort(arr);

            //MergeSort(arr);
            //Sort012();
            //QuickSort();

            //AddToSortedArray();
            //ShuffleArray();
            //RangeFunctionEmulator();
            //LengthOfLongestConsecutiveZeroesInTheBinaryRepresentation();
            //FindOddElement();
            //RotateArrayDemo();
            //MissingElementFind();
            //TapeEquilibrium();
            //FrogOneLeap();
            // PermCheck();
            //MissingInteger();
            //MaxCounters();
            //MushroomPicker();

            PassingCars();
        }


        #region FindLocalMinima
        static void FindLocalMinima(int[] arr)
        {
            int localMinimaIndex = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                int left = i - 1;
                int right = i + 1;
                if (left > 0 && right < arr.Length)
                {
                    if (arr[left] > arr[i] && arr[right] > arr[i])
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
        #endregion

        #region sub-arrays
        //solve using 'sliding window' count number of subarrays sum < maxSum
        static int countSubarray(int[] arr, int maxSum)
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

        //A simple solution is to consider all subarrays one by one and check if sum of every subarray is equal to 0 or not. The complexity of this solution would be O(n^2).
        static void PrintAllSubarraysZeroSum(int[] arr)
        {
            //find which sub-array sum is zero
            //List<int[]> subArrays = GetSubArrays(arr);
            List<int[]> sub_arrays = new List<int[]>();

            GetSubArraysRecursive(ref sub_arrays, arr, 0, 0);

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
            List<(int first, int second)> SubArraysFoundByIndex = new List<(int first, int second)>();

            // Maintains sum of elements so far 
            int sum = 0;


            for (int i = 0; i < arr.Length; i++)
            {
                // add current element to sum  
                sum += arr[i];

                // if sum is 0, we found a subarray starting  
                // from index 0 and ending at index i  
                if (sum == 0)
                    SubArraysFoundByIndex.Add((0, i));





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

            for (int i = 0; i < arrLength; i++)//starting point
            {
                for (int j = i; j < arrLength; j++)//end point
                {
                    List<int> tempArr = new List<int>();
                    for (int k = i; k <= j; k++)//iterating on array
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
            if (end == arr.Length)
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


        // Returns maximum sum in a  subarray of size k. 

        static int maxSum(int[] arr, int n,int k)
        {
            int maxSum = 0;
            // Consider all blocks starting 
            // with i. 

            for(int i=0; i < n-k+1 ;i++)
            {
                int current_sum = 0;
                for (int j = 0; j < k; j++)
                    current_sum = current_sum + arr[i + j];

                // Update result if required. 
                maxSum = Math.Max(current_sum,maxSum);
            }
            return maxSum;

        }

        static int MaxSumSlidingWindow(int[] arr,int n,int k)
        {
            int maxSum = 0;

            if (n < k)
                return -1;

            int window_sum = 0;
            int start = 0;

            //get initial sum size of first k elements.
            for (int i = 0; i < k; i++)
            {
                window_sum += arr[i];
            }

            maxSum = window_sum;
            for (int i=k ; i<n; i++)
            {
                window_sum += arr[i];
                window_sum -= arr[start++];
                maxSum = Math.Max(window_sum, maxSum);

            }
            return maxSum;
        }

        #endregion

        #region Sorting Algorithms
        
        
        static void SelectionSort(int[] arr)
        {
            Console.WriteLine("Before SelectionSort");
            PrintArr(arr);

            int n = arr.Length;
            for (int i=0;i< n; i++)
            {
                for(int j=i;j<n;j++)
                {
                    if (arr[j] < arr[i])
                        SWAP(ref arr[j], ref arr[i]);
                }
            }

            Console.WriteLine("After SelectionSort");
            PrintArr(arr);
        }

        static void MergeSort(int[] arr)
        {
            Console.WriteLine("Before MergeSort");
            PrintArr(arr);

            List<int> sorted = MergeSortHelperRec(arr.ToList());





            Console.WriteLine("After MergeSort");
            PrintArr(sorted.ToArray());
        }

        private static List<int> MergeSortHelperRec(List<int> unsorted)
        {
            int middle = unsorted.Count / 2;
            List<int> leftSubList = new List<int>();
            List<int> rightSubList = new List<int>();

            if (unsorted.Count <= 1)
                return unsorted;

            //populate left list
            for (int i = 0; i < middle; i++)
                leftSubList.Add(unsorted[i]);

            //populate right list
            for (int i = middle; i <= (unsorted.Count-1); i++)
                rightSubList.Add(unsorted[i]);


            //recursive calls;

            leftSubList = MergeSortHelperRec(leftSubList);
            rightSubList = MergeSortHelperRec(rightSubList);
            return MergeSortedLists(leftSubList, rightSubList);

        }

        private static List<int> MergeSortedLists(List<int> left, List<int> right)
        {
            List<int> result = new List<int>();

            while(left.Count > 0 || right.Count > 0) //as long you have orgrans in 
            {
                var leftItem = left.FirstOrDefault();
                var rightItem = right.FirstOrDefault();

                if (left.Count > 0 && right.Count > 0) 
                {
                   

                    //iterate on both of them together and check who is bigger
                    if (leftItem <= rightItem)  //Comparing First two elements to see which is smaller
                    {
                        result.Add(leftItem);
                        left.Remove(leftItem);

                    }
                    else if(leftItem >= rightItem)
                    {
                        result.Add(rightItem);
                        right.Remove(rightItem);
                    }
                     
                       
                }
                else if(left.Count > 0)//right list is empty 
                {
                    result.Add(leftItem);
                    left.Remove(leftItem);
                }
                else if (right.Count > 0) //left list is empty 
                {
                    result.Add(rightItem);
                    right.Remove(rightItem);
                }
            }




            return result;
        }

        //The above function always runs O(n^2) time even if the array is sorted. It can be optimized by stopping the algorithm if inner loop didn’t cause any swap.
        static void BubbleSort(int[] arr)
        {
            Console.WriteLine("Before BubbleSort");
            PrintArr(arr);

            int n = arr.Length;
            bool swapped;

            for (int i = 0; i < n; i++)
            {
                swapped = false;

                for (int j=0;j<n;j++)
                {
                    if (arr[j] > arr[i])
                    {
                        SWAP(ref arr[j], ref arr[i]);
                        swapped = true;
                    }
                }
                // IF no two elements were  
                // swapped by inner loop, then break 
                if (swapped == false)
                    break;
            }



            Console.WriteLine("After BubbleSort");
            PrintArr(arr);
        }

        static void BubbleSortRecursive(int[] arr,int n)
        {
            Console.WriteLine($"Recursive call BubbleSort, n={n}");
            PrintArr(arr);

            if (n == 1)
                return;


            //one pass of bubblesort and then recursive call
            //pass the largest to the right
            for(int i = 0; i < n-1; i++)
            {
                if (arr[i] > arr[i + 1])
                    SWAP(ref arr[i], ref arr[i + 1]);
            }


            BubbleSortRecursive(arr, n - 1);

        }

        static void InsertionSort(int[] arr)
        {

            int n = arr.Length;
           
            Console.WriteLine("Before InsertionSort");
            PrintArr(arr);

           

            for (int i = 0; i < n; i++)
            {
                int putInHeadItem = arr[i];
                int marker = i-1;

                // Move elements of arr[marker...n], 
                // that are greater than putInHeadItem(arr[i]), 
                // to one position ahead of their current position (shift right)

                while (marker >= 0 && arr[marker] > putInHeadItem)
                    {
                        arr[marker + 1] = arr[marker];
                        marker--;
                    }

                    arr[marker + 1] = putInHeadItem;
            }



            Console.WriteLine("After InsertionSort");
            PrintArr(arr);
        }

        static void InsertionSortRecursive(int[] arr,int n)
        {

            // Base case 
            if (n <= 1)
                return;

            // Sort first n-1 elements 
            InsertionSortRecursive(arr, n - 1);

            // Insert last element at  
            // its correct position 
            // in sorted array. 
            int last = arr[n - 1];
            int j = n - 2;

            /* Move elements of arr[0..i-1],  
            that are greater than key, to  
            one position ahead of their 
            current position */
            while (j >= 0 && arr[j] > last)
            {
                arr[j + 1] = arr[j];
                j--;
            }
            arr[j + 1] = last;
        }

        static void SWAP(ref int a,ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        // Sort the input array, the array is assumed to 
        // have values in {0, 1, 2} 
        static void Sort012()
        {
            int[] a = { 0, 1, 1, 0, 1, 2, 1, 2, 0, 0, 0, 1 };
            Console.WriteLine("Before Sort 0's 1's 2's");
            PrintArr(a);

            int n = a.Length, low = 0,mid = 0,high=n-1;
            while(mid<=high)
            {
                switch (a[mid])
                {
                    case 0:
                        SWAP(ref a[mid++], ref a[low++]);
                        break;
                    case 1:
                        mid++;
                        break;
                    case 2:
                        SWAP(ref a[mid], ref a[high--]);
                        break;
                }
            }

            Console.WriteLine("After Sort 0's 1's 2's");
            PrintArr(a);
        }

        static void QuickSort()
        {
            int[] arr = { 10, 7, 8, 9, 1, 5 };
            Console.WriteLine("Before QuickSort");
            PrintArr(arr);

            QuickSortRecursive(arr, 0, arr.Length-1);

            Console.WriteLine("After QuickSort");
            PrintArr(arr);
        }

        /* The main function that implements QuickSort() 
    arr[] --> Array to be sorted, 
    low --> Starting index, 
    high --> Ending index */
        static void QuickSortRecursive(int[] arr, int low, int high)
        {
            if (low < high)
            {

                /* pi is partitioning index, arr[pi] is now at right place */
                int pi = Partition(arr, low, high);

                // Recursively sort elements before 
                // partition and after partition 
                QuickSortRecursive(arr, low, pi - 1);
                QuickSortRecursive(arr, pi + 1, high);
            }

        }

        /* This function takes last element as pivot, 
    places the pivot element at its correct 
    position in sorted array, and places all 
    smaller (smaller than pivot) to left of 
    pivot and all greater elements to right 
    of pivot */
        static int Partition(int[] arr, int low,
                                       int high)
        {

            int pivot = arr[high]; //we can select the last, the first, the random or the median for that task
            // index of smaller element 

            int i = (low - 1);
            for(int j = low; j < high; j++)
            {

                // If current element is smaller  
                // than the pivot 
                if (arr[j] < pivot)
                {
                    // swap arr[i] and arr[j] 
                    SWAP(ref arr[++i], ref arr[j]);
                    
                }
            }

            // swap arr[i+1] and arr[high] (or pivot) 
            SWAP(ref arr[i+1], ref arr[high]);

            return i + 1;
        }

        #endregion

        #region Add-Element-To-Sorted-Array

        static void AddToSortedArray()
        {
            int[] a = { 1,2,3,4,5,7,8,9 };
            Console.WriteLine("Before Sort");
            PrintArr(a);

            bool inserted = false;
            int insertMe = 6;
            //create a new array at size n+1
            //copy all elements to pivot and from pivot

            int[] b = new int[a.Length + 1];
            int looperA = 0;
            int looperB = 0;

            while (looperA <= a.Length - 1)
            {
                if(a[looperA] > insertMe && !inserted)
                {
                    b[looperB++] = insertMe;
                    inserted = true;
                    continue;
                }
                b[looperB] = a[looperA++];
                looperB++;
            }
            Console.WriteLine("After Sort");
            PrintArr(b);
        }


        #endregion

        #region implement Range(start,stop,step) & shuffle(arr)


        static void ShuffleArray()
        {
            int[] arr = {1,2,3,4,5,6,7,8,9 };
            Console.WriteLine("Before ShuffleArray");
            PrintArr(arr);

            ShuffleHelper(arr);

            Console.WriteLine("After ShuffleArray");
            PrintArr(arr);

        }
        static void ShuffleHelper(int[] arr)
        {
            Random rnd = new Random();
            int[] dirtyItems = new int[arr.Length];

            for(int i=0;i<arr.Length-1;i++)
            {
                int index = rnd.Next(0, 3);
                if (dirtyItems[i] == 0)
                {
                    SWAP(ref arr[i],ref arr[index]);
                    dirtyItems[i] = 1;
                    dirtyItems[index] = 1;
                }
            }
        }
        static void RangeFunctionEmulator(int start = -50,int end = 10,int step = 10)
        {
            Console.WriteLine($"Range({start},{end},{step}");
            step = start > end ? -step : step;

            List<int> rangeList = new List<int>();
            for(int i=start;i != end; i+= step)
            {
                rangeList.Add(i);
            }
            rangeList.Add(end);
            PrintArr(rangeList.ToArray());
        }


        #endregion

        #region find element who does not have pair in array.

        static void FindOddElement()
        {
            //int[] arr = { 6,6,9,9,3 };
            //int[] arr = new int[0];

            int[] arr = { 2,2,2,1,1 };
            


            Console.WriteLine("FindOddElement");

            PrintArr(arr);

            Console.WriteLine($"Found {FindOddElementHelper(arr)}");
            Console.WriteLine($"Found {FindOddElementSecondHelper(arr)}");

        }
        static int FindOddElementHelper(int[] arr)
        {
            //there are x pairs in this array, and one element who has no pair at all.
            if (arr.Length == 0 || arr == null)
                return 0;



            //solve it using MAP?

            Dictionary<int, int> hash = new Dictionary<int, int>(); //<number, numberofoccurences>

            foreach (int number in arr)
            {
                //exist in dict
                if (hash.ContainsKey(number))
                {
                    hash[number]++;
                }
                else //not exist
                {
                    hash.Add(number, 1);
                }
            }

            if (hash.Where(item => item.Value == 1).FirstOrDefault().Value > 2)
                return 0;

            //later iterate on dictionary and find who has 1 occur.
            int oddOccur = hash.Where(item => item.Value == 1).FirstOrDefault().Key; //what happens if there is no one?
            return oddOccur;
        }
        static int FindOddElementSecondHelper(int[] arr)
        {
            int result = 0;
            foreach(var num in arr)
            {
                result ^= num;
            }

            return result;
        }

        #endregion


        #region rotateArrayToTheRight

        static void RotateArrayDemo()
        {
            int k = 3;

            //int[] arr = { 3, 8, 9, 7, 6 };
            int[] arr = { 1, 2, 3, 4 };


            Console.WriteLine("RotateArrayDemo Before K =3");

            PrintArr(arr);


            Console.WriteLine("RotateArrayDemo After K =3");
            RotateArrayDemoHelper(arr, 4);
            PrintArr(arr);

        }
        static void RotateArrayDemoHelper(int[] A, int K)
        {
            int len = A.Length - 1;

            if (K == 0 || A.Length < 2 || A == null) return;
            while (K-- > 0)
            {
               
                int tmp = A[len];
                for (int i = len; i > 0; i--)
                {
                    A[i] = A[i - 1];
                }
                A[0] = tmp; //now "rotate" last to first.
            }

        }


        #endregion



        #region rotateArrayToTheRight

        static void MissingElementFind()
        {

            int[] arr = { 1, 2, 3, 5 };


            Console.WriteLine("MissingElementFind");

            PrintArr(arr);


            Console.WriteLine($"Missing Element is : {MissingElementFindHelper(arr)}");
           

        }
        static int MissingElementFindHelper(int[] A)
        {
                if (A.Length == 0 || A == null)
                    return 1;

                if (A.Length == 1 && A[0] == 1)
                    return 2;

                if (A.Length == 1 && A[0] == 2)
                    return 1;

                int len = A.Length;

                int accumulatingSum = 0;
                int runningSum = 0;

                int i = 0;
                for (i = 0; i < len; i++)
                {
                    runningSum += A[i];
                    accumulatingSum += i;
                }
                accumulatingSum += len + 1;
                accumulatingSum += len ;


        

         


                return (accumulatingSum - runningSum);

        }


        #endregion




        #region FrogOneLeap

        /*The goal is to find the earliest time when the frog can jump to the other side of the river. The frog can cross only when leaves appear at every position across the river from 1 to X (that is, we want to find the earliest moment when all the positions from 1 to X are covered by leaves). You may assume that the speed of the current in the river is negligibly small, i.e. the leaves do not change their positions once they fall in the river.
        */
        static void FrogOneLeap()
        {

            int[] arr = { 5 };
            //int[] arr = { 1, 3, 1, 4, 2, 3, 5, 4 };


            Console.WriteLine("FrogOneLeap");

            Console.WriteLine($"smallest FrogOneLeap is : {FrogOneLeapHelper(arr,5)}");


        }
        static int FrogOneLeapHelper(int[] A,int X)
        {
            if (A.Length == 1 && A[0] == X)
                return 1;

            int indexesLen = A.Length ;
            Dictionary<int, int> leaves = new Dictionary<int, int>();


            for (int i = 0; i< indexesLen ; i++)
            {
                if(leaves.TryGetValue(A[i],out int index))
                {

                }
                else
                    leaves.Add(A[i], i);
            }

            return leaves.Count() == X ? leaves.Values.Max() :-1 ;
        }


        #endregion


        #region MissingInteger

        /*that, given an array A of N integers, returns the smallest positive integer (greater than 0) that does not occur in A.
        For example, given A = [1, 3, 6, 4, 1, 2], the function should return 5.*/


        static void MissingInteger()
        {
            int[] arr = { 1, 2, 3 };
           int[] arr2 = { -1, -3 };
            int[] arr3 = { 1, 3, 6, 4, 1, 2 };

            Console.WriteLine("MissingInteger");
            Console.WriteLine($"MissingInteger returned : {MissingIntegerHelper(arr3)}");


        }
        static int MissingIntegerHelper(int[] A)
        {
            int len = A.Length;
            HashSet<int> realSet = new HashSet<int>();
            HashSet<int> perfectSet = new HashSet<int>();

            int i = 0;
            while ( i < len)
            {
                realSet.Add(A[i]);   //convert array to set to get rid of duplicates, order int's
                perfectSet.Add(i + 1);  //create perfect set so can find missing int
                i++;
            }
            perfectSet.Add(i + 1);

            if (realSet.All(item => item < 0))
                return 1;

            int notContains = perfectSet.Except(realSet).Where(item=>item!=0).FirstOrDefault();
            return notContains;



        }


        #endregion

        #region MaxCounters

        /*Calculate the values of counters after applying all alternating operations: increase counter by 1; set value of all counters to current maximum..*/


        static void MaxCounters()
        {
            Console.WriteLine("MaxCounters");

            int[] arr = { 3,4,4,6,1,4,4 };
            PrintArr(arr);

            int[] result = MaxCountersHelper(5, arr);


            Console.WriteLine($"MaxCounters returned.");
            PrintArr(result);


        }

        //N - number of counters
        //A - actions on numbers - if A[K] = X, such that 1 ≤ X ≤ N, then operation K is increase(X),if A[K] = N + 1 then operation K is max counter.
        static int[] MaxCountersHelper(int N, int[] A)
        {
            int len = A.Length;

            int[] result = new int[N];

            foreach(var it in A)
            {
                if (it >= 1 && it <= N)
                    result[it-1]++;
                else
                {
                    int max = result.Max();
                    ResetArray(result, max);
                }

            }





            return result;
        }


        public static int[] MaxCountersHelperEfficient(int N, int[] A)
        {
            int[] counters = new int[N];
            for (var index = 0; index < counters.Length; ++index)
            {
                counters[index] = 0;
            }

            var maxCounter = 0;
            var effectiveMaxCounter = 0;

            foreach (var e in A)
            {
                if (e <= N)
                {
                    if (counters[e - 1] > effectiveMaxCounter)
                    {
                        counters[e - 1]++;
                    }
                    else
                    {
                        counters[e - 1] = effectiveMaxCounter + 1;
                    }
                    maxCounter = Math.Max(maxCounter, counters[e - 1]);
                }
                else
                {
                    effectiveMaxCounter = maxCounter;
                }
            }

            for (var index = 0; index < counters.Length; ++index)
            {
                counters[index] = Math.Max(counters[index], effectiveMaxCounter);
            }

            return counters;
        }
   

    static void ResetArray(int[] arr,int value)
        {
            int len = arr.Length;
            for (int i = 0; i < len; i++)
            {
                arr[i] = value;
            }
        }


        #endregion
        




        #region PermCheck

        /*check that A contains 1,2,3,4,5, if contains 1,2,3,5 -> false*/
        static void PermCheck()
        {

           
            int[] arr = { 4, 1, 3 };


            Console.WriteLine("FrogOneLeap");

            Console.WriteLine($"PermCheckHelper returned : {PermCheckHelper(arr)}");


        }
        static int PermCheckHelper(int[] A)
        {

            int len = A.Length;
            HashSet<int> leaves = new HashSet<int>(A);
            return leaves.Count() == len && A.Max() == len ? 1 : 0;
        }


        #endregion





        #region TapeEquilibrium

        /*A non-empty array A consisting of N integers is given. Array A represents numbers on a tape.

        Any integer P, such that 0 < P < N, splits this tape into two non-empty parts: A[0], A[1], ..., A[P − 1] and A[P], A[P + 1], ..., A[N − 1].

        The difference between the two parts is the value of: |(A[0] + A[1] + ... + A[P − 1]) − (A[P] + A[P + 1] + ... + A[N − 1])|

        In other words, it is the absolute difference between the sum of the first part and the sum of the second part.
        
        Return the smallest diff.
        */
        static void TapeEquilibrium()
        {

            //int[] arr = { 3,1,2,4,3 };

            //int[] arr = {-2,1,3 };

            //int[] arr = { -3000,1000};
            int[] arr = GenerateRandomArrayOfNumbers(20,0,5);



            Console.WriteLine("TapeEquilibrium");

            //PrintArr(arr);


            Console.WriteLine($"smallest TapeEquilibrium is : {TapeEquilibriumHelper(arr)}");


        }
        static int TapeEquilibriumHelper(int[] A)
        {
            int len = A.Length;

            if (len < 2 || A == null)
                return 0;

            if (len == 2)
                return (Math.Abs(A[0] - A[1]));

            if (len == 1)

                return (Math.Abs(A[0]));



            int partitionLeft = 0;

            int accumLeftSum = 0;
            int totalSum = 0;

            foreach (var num in A)
                totalSum += num;

            int smallestAccum = int.MaxValue;


            while (partitionLeft < len ) //O(n)
            {
                accumLeftSum += A[partitionLeft];
                int rightSum = totalSum - accumLeftSum;
                partitionLeft++;
                smallestAccum = Math.Min(Math.Abs(Math.Abs(accumLeftSum) - Math.Abs(rightSum)), Math.Abs(smallestAccum));
            }

            return smallestAccum;
        }


        #endregion



        #region Length of longest consecutive zeroes in the binary representation of a number.

        /*Input  : N = 14
                    Output : 1
                    Binary representation of 14 is 
                    1110. There is only one 0 in
                    the binary representation.

                    Input : N = 9 
                    Output : 2
         */

        static void LengthOfLongestConsecutiveZeroesInTheBinaryRepresentation()
        {         
            //count the number of zeros, when this number is represented as Binary.
            foreach(var N in TestNumbers)
            {
                Console.WriteLine($"LengthOfLongestConsecutiveZeroesInTheBinaryRepresentation of Decimal = [{N}], Binary = [{Convert.ToString(N, 2)}] is {LengthOfLongestConsecutiveZeroesInTheBinaryRepresentationHelper(N)}");

            }


        }


        //we need to trail zeroes from the right!
        static int LengthOfLongestConsecutiveZeroesInTheBinaryRepresentationHelper(int N)
        {
            int RunningNumOfZeros = 0;
            int MaxNumOfZeros = -1;
            int lastMaxNumOfZeros = 0;
            int numberOfOnes = 0;
            
            bool trailing_zeroes = false;

            while (N != 0)

            {
                if ((N & 1) == 0)
                {
                    RunningNumOfZeros++;
                    trailing_zeroes = false;
                }
                else
                {
                    RunningNumOfZeros = 0;
                    numberOfOnes++;
                    lastMaxNumOfZeros = MaxNumOfZeros;
                    trailing_zeroes = !trailing_zeroes;
                }
                N >>= 1;

                MaxNumOfZeros = Math.Max(RunningNumOfZeros, MaxNumOfZeros);
                
            }
            return (numberOfOnes == 1)?0:MaxNumOfZeros;
        }




        #endregion


        #region Prefix sums


        static void MushroomPicker()
        {
            Console.WriteLine("MushroomPicker");
            int[] A = new int[7] { 2, 3, 7, 5, 1, 3, 9 };


            //int[] A = new int[3] { 2, 3, 7};

            var n = A.Length;
            var k = 4;
            var result = 0;
            var m = 6;

            int[] prefixes = PrefixSums(A);

            for(int p = 0;p< Math.Min(k,m)+1;p++)
            {
                var left_pos = k - p;
                var right_pos = Math.Min(n - 1, Math.Max(k, k + m - 2 * p));
                result = Math.Max(result, CountTotal(prefixes, left_pos, right_pos));
            }


            for (int p = 0; p < Math.Min(m+1,n-k); p++)
            {

                var right_pos = k + p;
                var left_pos = Math.Max(0, Math.Min(k, k - (m - 2 * p)));

                result = Math.Max(result, CountTotal(prefixes, left_pos, right_pos));
            }


            Console.WriteLine($"Maximum Number of pickable mushrooms  is {result} given m={m}, k={k}");

        }

        static void CountDiv()
        {
            Console.WriteLine("CountDiv");
        }


        /*
         The consecutive elements of array A represent consecutive cars on a road.
        Array A contains only 0s and/or 1s:
        0 represents a car traveling east,
        1 represents a car traveling west.
        The goal is to count passing cars. We say that a pair of cars (P, Q), where 0 ≤ P < Q < N, is passing when P is traveling to the east and Q is traveling to the west.
*/
        static void PassingCars()
        {


            Console.WriteLine("PassingCars");
            //int[] A = new int[5] { 0,1,0,0,1 };

            int[] A = GenerateRandomArrayOfNumbers((int)Math.Pow(10, 9) + 1, 0, 2);

            var n = A.Length;

            //PrintArr(A);

            var prefixSumArr = PrefixSumsCars(A);
            Console.WriteLine($"counted passing cars  is {prefixSumArr}");

        }


        static int PrefixSumsCars(int[] A)
        {
            double result = 0 ;

            #region  inEfficient sol
            //inEfficient sol
            //int n = arr.Length;

            ////The function should return −1 if the number of pairs of passing cars exceeds 1,000,000,000.
            //if (n > Math.Pow(10, 9))
            //    return -1;

            //(int ,int )[] tmp = new (int east,int west)[n + 1];

            //for (int k = 1; k < n + 1; k++)
            //{
            //    (int ,int ) acc = (arr[k - 1] == 0?1:0,  arr[k - 1] == 1?1:0);
            //    tmp[k].Item1 = tmp[k - 1].Item1 + acc.Item1;
            //    tmp[k].Item2 = tmp[k - 1].Item2 + acc.Item2;

            //}

            //double result = (tmp[tmp.Length - 1]).Item1 + (tmp[tmp.Length - 1]).Item2;
            #endregion
            #region  Efficient sol
            //pair include eather west or easy so...
            int east = 0;
            foreach (int car in A)
            {
                if (car == 0)
                {
                    east = east + 1;
                }

                if (east > 0)
                {
                    if (car == 1)
                    {
                        result = result + east;
                        if (result > 1000000000)
                        {
                            return -1;
                        }
                    }
                }
            }


            return (int)result;
        
        
        }


        static int[] PrefixSums(int[] arr)
        {
            int n = arr.Length;
            int[] tmp = new int[n + 1];

            for (int k = 1; k < n + 1; k++)
            {
                tmp[k] = tmp[k - 1] + arr[k - 1];

            }
            return tmp;
        }

        //Total of one slice — O(1).
        static int CountTotal(int[] P, int x, int y) => P[y + 1] - P[x];

        #endregion

        static private IEnumerable<int> WhileYieldFunc(int n = 5, int minValue = 0, int maxValue = 5)
        {
            Random rnd = new Random();
            while (n-- > 0)
            {
                yield return rnd.Next(minValue, maxValue);
            }
        }

        static int[] GenerateRandomArrayOfNumbers(int n=5,int minValue=0,int maxValue=5)
        {
            Stopwatch stopWatch = new Stopwatch();
            //List<int> randomNumbers = new List<int>();
            int[] randomNumbers = new int[n];
            n--;
            //Console.WriteLine($"GenerateRandomArrayOfNumbers using Parallel.ForEach n={n}, minValue={minValue}, maxValue ={maxValue}");

            //stopWatch.Start();
            //Parallel.ForEach(WhileYieldFunc(n, minValue,maxValue), new ParallelOptions() { MaxDegreeOfParallelism=50}, new Action<int>((val) =>
            //{
            //    randomNumbers.Add(val);
            //}));
            //stopWatch.Stop();

            //Console.WriteLine($"GenerateRandomArrayOfNumbers using Parallel.ForEach took {stopWatch.Elapsed.TotalSeconds} seconds.");

            //randomNumbers.Clear();
            //stopWatch.Restart();


            stopWatch.Start();
            Console.WriteLine($"GenerateRandomArrayOfNumbers using normal syntax n={n}, minValue={minValue}, maxValue ={maxValue}");
            Random rnd = new Random();
            while (n > 0)
            {
                randomNumbers[n] = (rnd.Next(minValue, maxValue));
                n--;
            }

            stopWatch.Stop();
            Console.WriteLine($"GenerateRandomArrayOfNumbers using normal took {stopWatch.Elapsed.TotalSeconds} seconds.");

            return randomNumbers;
        }
    }
}
