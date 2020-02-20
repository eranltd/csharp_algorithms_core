using InterView.DataStructres;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterView.Questions
{
    public static class StackWithMax
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
            myStack.PrintStack();
        }
    }
}
