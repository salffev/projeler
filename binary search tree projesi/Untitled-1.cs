cemal akif özateş/salffev
#-------------------------------------------------------------------------------------------------------------------#
# (7, 5, 1, 8, 3, 6, 0, 9, 4, 2) dizisinin Binary-Search-Tree

#1-İlk eleman olan 7, kök olarak seçilir.

#2-Diğer elemanlar, kökten küçük olanlar sol dala, büyük olanlar sağ dala eklenir.

#3-5, kökten küçük olduğu için sol dala eklenir.

#4-1, kökten daha küçük olduğu için sol dala eklenir.

#5-8, kökten büyük olduğu için sağ dala eklenir.

#6-3, kökten küçük olduğu için sol dala eklenir.

#7-6, kökten büyük olduğu için sağ dala eklenir.

#8-0, kökten daha küçük olduğu için sol dala eklenir.

#9-9, kökten büyük olduğu için sağ dala eklenir.

#10-4, kökten büyük olduğu için sağ dala eklenir.

#11-2, kökten küçük olduğu için sol dala eklenir.
#-------------------------------------------------------------------------------------------------------------------#
using System;

namespace BinarySearchTree
{
    class Program
    {
        static void Main(string[] args)
        {
            // Dizi oluşur
            int[] list = { 7, 5, 1, 8, 3, 6, 0, 9, 4, 2 };

            // Binary-Search-Tree oluşur
            TreeNode root = null;
            foreach (int value in list)
            {
                root = Insert(root, value);
            }

            // Binary-Search-Tree'yi yazar
            PrintTree(root);
        }

        static TreeNode Insert(TreeNode root, int value)
        {
            if (root == null)
            {
                return new TreeNode(value);
            }

            if (value < root.value)
            {
                root.left = Insert(root.left, value);
            }
            else if (value > root.value)
            {
                root.right = Insert(root.right, value);
            }

            return root;
        }

        static void PrintTree(TreeNode root)
        {
            if (root == null)
            {
                return;
            }

            PrintTree(root.left);
            Console.WriteLine(root.value);
            PrintTree(root.right);
        }

        public class TreeNode
        {
            public int value;
            public TreeNode left;
            public TreeNode right;

            public TreeNode(int value)
            {
                this.value = value;
            }
        }
    }
}