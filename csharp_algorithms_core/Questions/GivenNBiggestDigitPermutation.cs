using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterView.Questions
{
    public static class GivenNBiggestDigitPermutation
    {
        public static void Run()
        {
            int N = -112345;
            int M = 0;
            int X = 12346;
            int Y = -0;

            Console.WriteLine($"solution({X}) -> {solution(X)}");
        }

        public static long solution(int N)
        {
            const int DIGIT = 5;
            long biggestNum = 0;
            bool isNegative =  N < 0;//remember if negative
            N = isNegative ?- N:N;

            string strNum = N.ToString();
            int numOfDigits = strNum.Length;

            for (int i = 0; i < numOfDigits; i++)
            {
                string tempStr = strNum.Insert(i, DIGIT.ToString());
                long possibleNum = Int64.Parse(tempStr);

                if (biggestNum < possibleNum )
                    biggestNum = possibleNum;

                else if (isNegative && biggestNum > possibleNum )
                {
                    biggestNum = possibleNum;
                }
            }

            //return the minus sign again.
            return (isNegative) ? -biggestNum : biggestNum;
        }
    }
}
