using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterView.Questions
{
    public class BiggestReplicaInArray
    {
        public static void Run()
        {

            int[] A = new int[6] { -993, 2, 5, -3, 993,3 };
            Console.WriteLine($"solution({A.ToString()}) -> {solution(A)}");
        }

        public static int solution(int[] A)
        {
            int arrSize = A.Length;
            HashSet<int> hashSet = new HashSet<int>();
            int max = 0; //initial value
            
            for (int i = 0; i < arrSize; i++) //o(n)
            {
                int missingNumber = A[i];

                //max number found that exists in hashmap
                if (missingNumber > max && hashSet.Contains(-missingNumber)) //o(1)
                    max = missingNumber;

                hashSet.Add(missingNumber); //o(1)
            }
            return max; //no such element was found
        }
    }
}
