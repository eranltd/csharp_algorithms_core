using InterView.DataStructres;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterView.Questions
{

    public static class BSTQuestions
    {
        public static void Run()
        {
            Console.WriteLine("BSTQuestions");

            BSTNode root = null;
            BinarySearchTree bst = new BinarySearchTree();

            root = bst.insert(root,2);
            root = bst.insert(root, 1);
            root = bst.insert(root, 3);
            root = bst.insert(root, 4);
            root = bst.insert(root, 5);
            root = bst.insert(root, 6);


            /*****************************/
            var height = bst.GetTreeHeight(root);
            Console.WriteLine($"GetTreeHeight: {height}");


            var depth = bst.GetTreeDepth(root);
            Console.WriteLine($"GetMinTreeDepth: {depth}");

            var numberOfNodes = bst.GetNumberOfNodes(root);
            Console.WriteLine($"NumberOfNodes: {numberOfNodes}");


        }
    }
}
