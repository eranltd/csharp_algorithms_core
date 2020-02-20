using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterView.DataStructres
{
    class BSTNode
    {
        public int value;
        public BSTNode left;
        public BSTNode right;
    }

    class BinarySearchTree
    {
        public BSTNode insert(BSTNode root, int v)
        {
            if (root == null)
                root = new BSTNode() { value = v };

            else if (v < root.value)
            {
                root.left = insert(root.left, v);
            }
            else if(v > root.value)
            {
                root.right = insert(root.right, v);
            }
            return root;
        }



        public void traverse(BSTNode root)
        {
            if (root == null)
            {
                return;
            }
            traverse(root.left);
            traverse(root.right);
        }

        internal int GetTreeHeight(BSTNode root)
        {
            if (root == null)
                return 0;

            int leftheight = GetTreeHeight(root.left);
            int rightheight = GetTreeHeight(root.right);

            if (leftheight < rightheight) return 1+rightheight;
            else return 1+leftheight;
        }

        internal int GetTreeDepth(BSTNode root)
        {
            //Minimum

            if (root == null)
                return 0;
            else if (root != null && root.left == null && root.right == null)
                return 1;

            if (root.right == null)
                return 1 + GetTreeDepth(root.left);


            if (root.left == null)
                return 1 + GetTreeDepth(root.right);

            return  Math.Min(GetTreeDepth(root.left) , GetTreeDepth(root.right))+1;
        }

        internal int GetNumberOfNodes(BSTNode root)
        {
            if (root == null)
                return 0;
           

            return 1 + (GetNumberOfNodes(root.left)) + (GetNumberOfNodes(root.right));

        }
    }

}
