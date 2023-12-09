using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProject2._4
{
    internal class PriorityQueue
    {
        private List<int> data;
        private int length = 0;

        public int Length { get => length; set => length = value; }

        public PriorityQueue()
        {
            this.data = new List<int>();
        }

        public void enqueue(int item)
        {
            this.data.Add(item);
            Length++;
        }

        public int deque()
        {
            if (this.data.Count == 0) return 0;
            
            int minItem = data[0];
            int minIndex = 0;

            for (int i = 1; i < data.Count; i++)
            {
                if (data[i].CompareTo(minItem) < 0)
                {
                    minItem = data[i];
                    minIndex = i;
                }
            }
            data.RemoveAt(minIndex);
            Length--;

            return minItem;
        }
    }
}
