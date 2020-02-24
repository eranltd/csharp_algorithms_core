using InterView.DataStructres;
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

        public static void PrintArr(int[] arr) { Console.WriteLine(); arr.ToList().ForEach(item => Console.Write($"[{item}] ")); Console.WriteLine(); }
        public static void Run()
        {
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
            
            int[] arr = { 38, 27, 43, 3, 9, 82, 10 };

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
            RangeFunctionEmulator();
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


        static void RangeFunctionEmulator()
        {
            int start = -10;
            int end = 50;
            int step = 10;

            Console.WriteLine($"Range({start},{end},{step}");

            List<int> rangeList = new List<int>();
            
            for(int i=start;Math.Abs(i) < Math.Abs(end);i+=step)
            {
                rangeList.Add(i);
            }
            PrintArr(rangeList.ToArray());
        }
       
        
        #endregion





    }
}
