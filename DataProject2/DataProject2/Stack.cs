using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace DataProject2
{
    internal class Stack
    {
        private Node top;
        private int height;

        public Stack(int value)
        {
            Node newNode = new Node(value);
            top = newNode;
            height = 1;
        }

        public class Node
        {
            public Node next;
            public int value;

            public Node(int value)
            {
                this.value = value;
            }
        }

        public void push(int value)
        {
            Node newNode = new Node(value);
            if (height == 0)
            {
                top = newNode;
                height = 1;
            }
            else
            {
                newNode.next = top;
                top = newNode;
            }
        }

        public Node pop()
        {
            if(height == 0) return null;
            Node temp = top;
            top = top.next;
            temp.next = null;
            height--;
            return temp;
        }

    }
}
