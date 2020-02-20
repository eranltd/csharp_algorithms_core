using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterView.Questions
{
    public static class RemoveOccurFromStr
    {
        public static void Run()
        {
            char[] example = "my Daddyyyy weeent too work!".ToCharArray();
            char lastChar = '`';
            
            
            Console.WriteLine("RemoveOccurFromStr");

            Console.WriteLine($"String before: {new string(example)}");

            for (int i=0;i<example.Length;i++)
            {
                if(lastChar ==  example.ElementAt(i))
                {
                    example[i] = ' ';
                }
                lastChar = example.ElementAt(i);
            }


            Console.WriteLine($"String after: {new string(example)}");




        }
    }
}
