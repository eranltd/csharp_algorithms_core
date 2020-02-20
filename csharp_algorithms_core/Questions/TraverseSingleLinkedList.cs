using InterView.DataStructres;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterView.Questions
{


    public static class TraverseSingleLinkedList
    {
        public static void Run()
        {
            Console.WriteLine("TraverseSingleLinkedList");

            var linkedList = new MySingleLinkedListClasses.SingleLinkedList();

            MySingleLinkedListClasses.InsertFront(linkedList, 1);
            MySingleLinkedListClasses.InsertFront(linkedList, 2);
            MySingleLinkedListClasses.InsertFront(linkedList, 3);
            MySingleLinkedListClasses.InsertFront(linkedList, 4);

            MySingleLinkedListClasses.PrintList(linkedList.head);

            Console.WriteLine("After Reverese with one pointer only.");

            MySingleLinkedListClasses.ReverseLinkedList(linkedList);

            MySingleLinkedListClasses.PrintList(linkedList.head);




        }
    }
}