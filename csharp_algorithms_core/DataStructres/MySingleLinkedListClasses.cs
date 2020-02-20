using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterView.DataStructres
{
    public class MySingleLinkedListClasses
    {
        internal class Node
        {
            internal int data;
            internal Node next;
            public Node(int d)
            {
                data = d;
                next = null;
            }
        }



        internal class SingleLinkedList
        {
            internal Node head;
        }

        static internal void InsertFront(SingleLinkedList singlyList, int new_data)
        {
            Node new_node = new Node(new_data);
            new_node.next = singlyList.head;
            singlyList.head = new_node;
        }

        static internal void PrintList(Node node)
        {
            if (node != null)
                Console.WriteLine($"[{node.data}]");
            else
                return;
            PrintList(node.next);
        }


        static internal void ReverseLinkedList(SingleLinkedList singlyList)
        {
            //3 pointers;

            Node prev = null;
            Node current = singlyList.head;
            Node temp = null;



            while (current != null)
            {
                
                
                temp = current.next;

                current.next = prev;
                


                prev = current;
                
                current = temp;


            }
            singlyList.head = prev;
        }
    }
}
