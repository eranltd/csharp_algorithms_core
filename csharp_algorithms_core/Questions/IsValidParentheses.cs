using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterView.Questions
{

    public class IsValidParentheses
    {
        public static void Run()
        {

            //var valid = "(())";
            var valid = @"[288 votes so far. Categories: {""Everything Else"" (47 votes), C# (61 votes), C++ (39 votes), Database (44 votes), Mobile (45 votes), Web Dev (52 votes)}]";
            var inValid = " < Root >< First > Test </ First <</ Root > ";
            Console.WriteLine($"solution({valid}) -> {solution(valid)}");
            Console.WriteLine($"solution({inValid}) -> {solution(inValid)}");
        }

        public static bool solution(string str)
        {
            Stack<Char> stack = new Stack<char>();
            //convert str to array of chars.

            var charArr = str.ToCharArray();
            foreach (var chr in charArr)
            {
                if (isOpenPar(chr))
                {
                    stack.Push(chr);
                }
                else if (isClosePar(chr))
                    if (stack.Count == 0 || !isOppositePara(stack.Pop(), chr))
                        return false;
            }

            return stack.Count() == 0 ? true : false;
        }


        static bool isOpenPar(Char c) => (c == '(' || c == '{' || c == '[' || c == '<');

        static bool isClosePar(Char c) => (c == ')' || c == '}' || c == ']' || c == '>');

        static bool isOppositePara(Char open, Char close) => (isOpenPar(open) && isClosePar(close));

    }

    }
