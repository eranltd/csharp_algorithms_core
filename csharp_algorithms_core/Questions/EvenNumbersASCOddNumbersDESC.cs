using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterView.Questions
{
    public class EvenNumbersASCOddNumbersDESC
    {
        public static void Run()
        {
            Console.WriteLine("EvenNumbersASCOddNumbersDESC");
            int[] A = new int[7] { 1, 2, 3, 5, 4, 7, 10 };
            Console.WriteLine("solution({ 1, 2, 3, 5, 4, 7, 10 }) ->"); //should output {7, 5, 3, 1, 2, 4, 10}
            A = solution(A);
            A.ToList().ForEach(item => Console.WriteLine(item));
        }

        public static int[] solution(int[] A)
        {
            int left = 0;
            int right = A.Length - 1;
            while(left < right)
            {
                // Find first odd number from left side. 
                while(A[left] % 2 !=0)
                {
                    left++;
                }

                // Find first even number from right side. 
                while(A[right] % 2 ==0)
                {
                    right--;
                }

                // Swap odd number present on left and even 
                // number right. 
                if(left<right)
                {
                    int temp = A[left];
                    A[left] = A[right];
                    A[right] = temp;
                }
            }

            Array.Sort(A, 0, left);  //sort odd numbers Desc
            Array.Reverse(A, 0, left);

            Array.Sort(A, left, (A.Length - 1) - left); //sort even number asc
            return A;

        }
    }
}
