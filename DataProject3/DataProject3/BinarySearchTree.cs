using DataProject2;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Metadata.W3cXsd2001;

namespace DataProject3
{
    public class BinarySearchTree
    {
        List<UM_Alani> results = new List<UM_Alani>();
        Node root;
        int countOfNode = 0;

        public int CountOfNode { get => countOfNode; set => countOfNode = value; }

        public class Node
        {
            public UM_Alani value;
            public Node left;
            public Node right;

            public Node(UM_Alani value)
            {
                this.value = value;
            }
        }

        public Node getRoot()
        {
            return root;
        }

        public bool insert(UM_Alani value)
        {
            Node newNode = new Node(value);
            if (root == null)
            {
                root = newNode;
                return true;
            }

            Node temp = root;
            while (true)
            {
                if (newNode.value.compareTo(temp.value) == 0)
                    return false;

                if (newNode.value.compareTo(temp.value) < 0)
                {
                    if (temp.left == null)
                    {
                        temp.left = newNode;
                        return true;
                    }
                    temp = temp.left;
                }
                else
                {
                    if (temp.right == null)
                    {
                        temp.right = newNode;
                        return true;
                    }
                    temp = temp.right;
                }
            }
        }

        public bool contains(UM_Alani value)
        {
            Node temp = root;
            while (temp != null)
            {
                if (value.compareTo(temp.value) < 0)
                {
                    temp = temp.left;
                }
                else if (value.compareTo(temp.value) > 0)
                {
                    temp = temp.right;
                }
                else
                {
                    return true;
                }
            }
            return false;
        }

        // Ağacın derinliğini hesaplar
        public int calculateDepth(Node root)
        {
            if (root == null)
                return 0;
            int leftDepth = calculateDepth(root.left);
            int rightDepth = calculateDepth(root.right);

            return 1 + Math.Max(leftDepth, rightDepth);
        }

        // In-Order'la dolaşma
        public List<UM_Alani> DFSInOrder()
        {
            void Traverse(Node currentNode)
            {
                countOfNode++;
                if (currentNode.left != null)
                {
                    Traverse(currentNode.left);
                }
                results.Add(currentNode.value);
                if (currentNode.right != null)
                {
                    Traverse(currentNode.right);
                }
            }
            Traverse(root);
            return results;
        }

        // Verilen harflerle başlayan UM_Alanları arasını listeler
        public void searchInRange(char start, char end)
        {
            Boolean x = false;
            foreach (UM_Alani um in results)
            {
                if (um.HeritageName[0] == start || x)
                {
                    x = true;
                    Console.WriteLine(um.HeritageName);
                }
                if (um.HeritageName[0] == end) return;
            }
        }

        // Dengeli halindeki derinliğini hesaplayan kod
        public int balancedDepth()
        {
            int nodeCounter = 0;
            int balancedDepth = 0;
            while(nodeCounter < countOfNode)
            {
                nodeCounter += Convert.ToInt32(Math.Pow(2, balancedDepth));
                balancedDepth++;
            }
            return balancedDepth;
        }
        
        // Bilgileri yazdır
        public void printInfo()
        {
            DFSInOrder();
            foreach (UM_Alani um in results)
            {
                um.printInfo();
            }
        }

    }
}