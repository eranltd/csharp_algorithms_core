using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterView.DataStructres
{
    internal class Stack
    {
        static readonly int MAX = 1000;
        int top;
        int currentMax;
        
        int[] stack = new int[MAX];

        bool IsEmpty()
        {
            return (top < 0); //top is currently set to -1, because it is empty and it is inside the c'tor. 
        }

        public Stack()
        {
            top = -1;
            currentMax = -1;
        }

        internal bool Push(int data)
        {
            if (top > MAX) //stack is full
            {
                Console.WriteLine($"stackOverflow reached {MAX}");
                return false;
            }
            else //stack is not full yet!
            {
                if(currentMax < data)
                {
                    currentMax = data;
                    stack[++top] = data; //higest!
                }
                else
                {
                    int temp = Pop(); //this is the highest!
                    stack[++top] = data;
                    stack[++top] = temp;
                }
                return true;
            }
        }

        internal int Pop()
        {
            if (top < 0)
            {
                Console.WriteLine("Stack Underflow");
                return 0;
            }
            else
            {
                int value = stack[top--];
                return value;
            }
        }
        internal int Peek()
        {
            if (top < 0)
            {
                Console.WriteLine("Stack Underflow");
                return -1;
            }
            else
                Console.WriteLine("The topmost element of Stack is : {0}", stack[top]);
            return stack[top];
        }
        internal void PrintStack()
        {
            if (top < 0)
            {
                Console.WriteLine("Stack Underflow");
                return;
            }
            else
            {
                Console.WriteLine("Items in the Stack are :");
                for (int i = top; i >= 0; i--)
                {
                    Console.WriteLine(stack[i]);
                }
            }
        }

        internal bool isEmpty() => top == -1;
        internal void SortStack()
        {
            //helperStack exists.
            Stack helperStack = new Stack();

            

            while(!isEmpty()) //as long there is input
            {
                int temp = this.Pop();

                while (!helperStack.isEmpty() && helperStack.Peek() > temp)
                {
                    // pop from temporary stack and push 
                    // it to the input stack 
                    this.Push(helperStack.Pop());
                }
                
                helperStack.Push(temp);
            }

            this.stack = helperStack.stack;



        }

    }
}
