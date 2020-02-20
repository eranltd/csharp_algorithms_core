using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterView.Questions
{
    public static class PermutationsOfString
    {
        public static void Run()
        {
            string str = "abc";
            Console.WriteLine($"PermutationsOfString: {str}");
            int count = 0;
            List<string> permutations = new List<string>();

            permute(str,0,str.Length-1, ref permutations,ref count );

            Console.WriteLine($"Executed: {count}");

            foreach(var item in permutations)
            {
                Console.WriteLine(item);
            }
        }

        internal static void permute(string str,int l,int r, ref List<string> lst,ref int count)
        {
            if(l == r) //print / save to lst
            {
                lst.Add(str);
                return; 
            }
    
            for (int i=l;i<=r;++i)  //no need for stopping condition at the recursion
            {
                count++;
                permute(swapCharsInArray(str, l, i), l+1, r, ref lst,ref count);
            }
        }

        internal static String swapCharsInArray(string str, int i,int j)
        {
            if (i == j)
                return str;

            char[] chars = str.ToCharArray();
            if (i >= 0 && i < str.Length-1 && j >= 0 && j <= str.Length-1)
                swapChars(ref chars[i], ref chars[j]);

            return new string(chars);
        }

        internal static void swapChars(ref char x, ref char y)
        {
            char tmp = x;
            x = y;
            y = tmp;
        }

       



    }
}


