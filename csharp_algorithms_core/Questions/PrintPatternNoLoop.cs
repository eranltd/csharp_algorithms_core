using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterView.Questions
{
    public static class PrintPatternNoLoop
    {
        public static void Run()
        {
            Console.WriteLine("PrintPatternNoLoop");
            Console.Write(@"Input: n = 16
                            Output: 16, 11, 6, 1, -4, 1, 6, 11, 16

                            Input: n = 10
                            Output: 10, 5, 0, 5, 10");
            Console.WriteLine("");

            printPattern(16,16,true);

        }


        // Recursive function to print the pattern. 
        // n indicates input value 
        // m indicates current value to be printed 
        // flag indicates whether we need to add 5 or 
        // subtract 5. 
        static void printPattern(int n, int m, bool towardZero)
        {
            var direction = towardZero ? "towared 0" : $"towared {n}";
            Console.WriteLine(m + $"Direction: {direction}");
            
            // If we are moving back toward the n and 
            // we have reached there, then we are done 
            if (towardZero == false && n == m)
                return;


            // If we are moving toward 0 or negative. 
            if (towardZero)
            {
                // If m is greater, then 5, recur with  
                // true flag 
                if (m - 5 > 0)
                    printPattern(n, m - 5, true);
                else // recur with false flag 
                    printPattern(n, m - 5, false);

            }
            else  // If flag is false. 
                printPattern(n, m + 5, false);

        }
        }
    }
