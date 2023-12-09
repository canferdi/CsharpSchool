
using System;

namespace DataProject2
{
    internal class StackUM
    {
        private int maxSize;
        private UM_Alani[] stackArray;
        private int top;

        public StackUM(int max)
        {
            this.maxSize = max;
            this.stackArray = new UM_Alani[maxSize];
            top = -1;
        }

        public void push(UM_Alani um)
        {
            stackArray[++top] = um;
        }
        public UM_Alani pop()
        {
            if (isEmpty())
            {
                Console.WriteLine("Stack boş, pop işlemi yapılamaz.");
                return null;
            }

            return stackArray[top--];
        }

        public bool isEmpty()
        {
            return top == -1;
        }

    }
}
