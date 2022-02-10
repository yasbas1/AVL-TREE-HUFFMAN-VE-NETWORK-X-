using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVL
{
    class AVLTree
    {
        public class AVL
        {
            class Node
            {
                public int data;
                public Node left;
                public Node right;
                public Node(int data)
                {
                    this.data = data;
                }
            }
            Node root;
            public AVL()
            {
            }
            public void Insertion(int data)
            {
                Node newItem = new Node(data);
                if (root == null)
                {
                    root = newItem;
                }
                else
                {
                    root = RecursiveInsert(root, newItem);
                }
            }
            private Node RecursiveInsert(Node current, Node n)
            {
                if (current == null)
                {
                    current = n;
                    return current;
                }
                else if (n.data < current.data)
                {
                    current.left = RecursiveInsert(current.left, n);
                    current = balance_tree(current);
                }
                else if (n.data > current.data)
                {
                    current.right = RecursiveInsert(current.right, n);
                    current = balance_tree(current);
                }
                return current;
            }
            private Node balance_tree(Node current)
            {
                int b_factor = balance_factor(current);
                if (b_factor > 1)
                {
                    if (balance_factor(current.left) > 0)
                    {
                        current = RotateLL(current);
                    }
                    else
                    {
                        current = RotateLR(current);
                    }
                }
                else if (b_factor < -1)
                {
                    if (balance_factor(current.right) > 0)
                    {
                        current = RotateRL(current);
                    }
                    else
                    {
                        current = RotateRR(current);
                    }
                }
                return current;
            }
            private int max(int l, int r)
            {
                return l > r ? l : r;
            }
            private int getHeight(Node current)
            {
                int height = 0;
                if (current != null)
                {
                    int l = getHeight(current.left);
                    int r = getHeight(current.right);
                    int m = max(l, r);
                    height = m + 1;
                }
                return height;
            }
            private int balance_factor(Node current)
            {
                int l = getHeight(current.left);
                int r = getHeight(current.right);
                int b_factor = l - r;
                return b_factor;
            }
            private Node RotateRR(Node parent)
            {
                Node pivot = parent.right;
                parent.right = pivot.left;
                pivot.left = parent;
                return pivot;
            }
            private Node RotateLL(Node parent)
            {
                Node pivot = parent.left;
                parent.left = pivot.right;
                pivot.right = parent;
                return pivot;
            }
            private Node RotateLR(Node parent)
            {
                Node pivot = parent.left;
                parent.left = RotateRR(pivot);
                return RotateLL(parent);
            }
            private Node RotateRL(Node parent)
            {
                Node pivot = parent.right;
                parent.right = RotateLL(pivot);
                return RotateRR(parent);
            }
            public void DisplayTree()
            {
                if (root == null)
                {
                    Console.WriteLine("Tree is empty");
                    return;
                }
                Console.WriteLine("AVL Tree'mizin inOrder biçimde dolaşılarak yazılmış hali :  ");
                InOrderDisplayTree(root);
                Console.WriteLine();
            }
            private void InOrderDisplayTree(Node current)
            {
                if (current != null)
                {
                    Console.Write("({0}) ", current.data);
                    InOrderDisplayTree(current.left);
                    InOrderDisplayTree(current.right);
                }
            }
        }
        public static void Main(String[] args)
        {
            AVL avlTree = new AVL();

            avlTree.Insertion(10);
            avlTree.Insertion(3);
            avlTree.Insertion(15);
            avlTree.Insertion(2);
            avlTree.Insertion(7);
            avlTree.Insertion(12);
            avlTree.Insertion(1);
            avlTree.Insertion(5);

            avlTree.DisplayTree();
            Console.Read();

            
        }
    }
    
}

