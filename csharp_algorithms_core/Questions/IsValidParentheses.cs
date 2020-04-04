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

        public static int solution(string S)
        {
            Stack<Char> stack = new Stack<Char>();

            for (int i = 0; i < S.Length; i++)
            {
                char c = S[i];

                switch (c)
                {
                    case ')':
                        if (stack.Count == 0 || stack.Pop() != '(')
                            return 0;
                        break;
                    case ']':
                        if (stack.Count == 0 || stack.Pop() != '[')
                            return 0;
                        break;
                    case '}':
                        if (stack.Count == 0 || stack.Pop() != '{')
                            return 0;
                        break;
                    default:
                        stack.Push(c);
                        break;
                }
            }

            return stack.Count == 1 ? 0 : 1;

        }
    }

    }
