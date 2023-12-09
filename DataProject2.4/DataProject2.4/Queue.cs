using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProject2._4
{
    internal class Queue
    {
            private int size;
            private int[] queueArr;
            private int first, last;
            private int length;

        public int Length { get => length; set => length = value; }

        public Queue(int size)
            {
                this.size = size;
                queueArr = new int[size];
                this.first = 0;
                this.last = -1;
                this.length = 0;
            }

            public void enque(int um)
            {
                if (last == size - 1)
                {
                    last = -1;
                }
                queueArr[++last] = um;
                length++;
            }

            public int deque()
            {
                int temp = queueArr[first++];
                if (first == size)
                {
                    first = 0;
                }
                length--;
                return temp;
            }

            public bool isEmpty()
            {
                return (length == 0);
            }

            
        }
    }


