using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterView.Questions
{
    public static class SortStackRecursive
    {


        public static void Run()
        {
            Stack s = new Stack();
            s.Push(30);
            s.Push(-5);
            s.Push(18);
            s.Push(14);
            s.Push(-3);

            Console.WriteLine("Stack elements before sorting: ");
            printStack(s);

            sortStack(s);

            Console.WriteLine(" \n\nStack elements after sorting:");
            printStack(s);
        }

        // Recursive Method to insert an item x in sorted way  
        static void sortedInsert(Stack s, int x)
        {
            // Base case: Either stack is empty or   
            // newly inserted item is greater than top  
            // (more than all existing)  
            if(s.Count == 0 || x > (int)s.Peek())
            {
                s.Push(x);
                return;
            }

            // If top is greater, remove  
            // the top item and recur  
            int temp = (int)s.Peek();
            s.Pop();



            sortedInsert(s, x); 


            // Put back the top item removed earlier  
            s.Push(temp);

        }


        // Recursive Method to sort stack  
        static void sortStack(Stack input) //the first while
        {
            // If stack is not empty  
            if (input.Count > 0)
            {
                // Remove the top item(s)  
                int x = (int)input.Peek();
                input.Pop();

                // Sort remaining stack  //pop all other items
                sortStack(input);

                // Push the top items back in sorted stack  
                sortedInsert(input, x);
            }

        }


        // Utility Method to print contents of stack  
        static void printStack(Stack s)
        {
            foreach (int c in s)
            {
                Console.Write(c + " ");
            }
        }


        


    }
}
