using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterView.Questions
{
    public static class SortStack
    {
        public static void Run()
        {
            Stack myStack = new Stack();

            myStack.Push(10);
            myStack.Push(20);
            myStack.Push(30);
            myStack.Push(10);
            myStack.Push(20);
            myStack.Push(30);
            myStack.Push(2);
            myStack.Push(3);
            myStack.Push(90);
            myStack.Push(4);
            myStack.Push(4);
            myStack.Push(4);
            myStack.Push(90);
            myStack.Push(10);
            myStack.Push(20);
            myStack.Push(30);


            myStack = SortStackMethod(myStack);


            while (myStack.Count != 0)
            {
                Console.WriteLine(myStack.Pop());
            }
        }
    
        public static Stack SortStackMethod(Stack input)
        {
            Stack helperStack = new System.Collections.Stack();
            while(input.Count != 0) 
            {
                int temp = (int)input.Pop();
                while(helperStack.Count >0  && (int)helperStack.Peek() > temp)
                {
                    input.Push(helperStack.Pop());
                }

                helperStack.Push(temp);
            }
            return helperStack;
        }
    }
}
