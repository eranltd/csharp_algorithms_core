using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterView.DataStructres
{
    public class O_1_DS
    {
        int len;
        Tuple<int,DateTime>[] array;

        private bool setAllFlag;
        private int joker;
        private DateTime jokerSetTime;

        public O_1_DS(int length)
        {
            len = length;
            array = new Tuple<int, DateTime>[len];
        }


        public void setAll(int val)
        {
            setAllFlag = true;
            joker = val;
            jokerSetTime = DateTime.Now;
        }

        public int get(int i)
        {
            if (i > len) return -1;

            if(setAllFlag)
            {
                return joker;
            }
            else
            {
                return array[i] == null?0: array[i].Item1;
            }

        }

        public bool set(int i,int val)
        {

            if (setAllFlag == true)
            {
                setAllFlag = false;
            }

            if (i > len)
                return false;

            array[i] = new Tuple<int, DateTime>(val, DateTime.Now);
            return true; 

        }
        public void Print()
        {
            for (int i = 0; i < array.Length; ++i)
            {
                Console.WriteLine($"[{get(i)}]");
            }

            
        }
    }
}
