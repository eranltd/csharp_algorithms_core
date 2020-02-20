using InterView.DataStructres;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterView.Questions
{


    public static class Implement_set_all_set_get_o_1
    {
        public static void Run()
        {
            Console.WriteLine("Implement_set_all_set_get_o_1");
            O_1_DS ds = new O_1_DS(10);


            int res;

            ds.setAll(6);
            res = ds.get(3);

            ds.set(3, 10);
            res = ds.get(3);


            res = ds.get(3);

            res = ds.get(15);

            ds.set(4, 7);

            res = ds.get(4);

            res = ds.get(3);

            ds.setAll(6);

            ds.set(8, 2);

            res = ds.get(3);

            ds.Print();
        }
    }
}
