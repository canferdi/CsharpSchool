using DataProject2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProject3
{
    public class Heap
    {
        private List<UM_Alani> heap;

        public Heap()
        {
            this.heap = new List<UM_Alani>();
        }

        public List<UM_Alani> getHeap()
        {
            return new List<UM_Alani>(heap);
        }

        private int leftChild(int index)
        {
            return 2 * index + 1;
        }

        private int rightChild(int index)
        {
            return 2 * index + 2;
        }

        private int parent(int index)
        {
            return (index - 1) / 2;
        }

        private void swap(int index1, int index2)
        {
            UM_Alani temp = heap[index1];
            heap[index1] = heap[index2];
            heap[index2] = temp;
        }

        public void insert(UM_Alani value)
        {
            heap.Add(value);
            int current = heap.Count - 1;

            while (heap[current].compareTo(heap[parent(current)])<0)
            {
                swap(current, parent(current));
                current = parent(current);
            }
        }

        public void sinkDown(int index)
        {
            int minIndex = index;
            int leftIndex = leftChild(index);
            int rightIndex = rightChild(index);
            while (true)
            {
                if (leftIndex < heap.Count && heap[leftIndex].compareTo( heap[minIndex])<0)
                {
                    minIndex = leftIndex;
                }
                if (rightIndex < heap.Count && heap[rightIndex].compareTo(heap[minIndex]) < 0)
                {
                    minIndex = rightIndex;
                }
                if (minIndex != index)
                {
                    swap(index, minIndex);
                    minIndex = index;
                }
                else
                {
                    return;
                }
            }
        }

        public UM_Alani remove()
        {
            if (heap.Count == 0) return null;
            if (heap.Count == 1)
            {
                UM_Alani removedValue = heap[0];
                heap.RemoveAt(0);
                return removedValue;
            }
            UM_Alani minValue = heap[0];
            heap[0] = heap[heap.Count - 1];
            heap.RemoveAt(heap.Count - 1);
            sinkDown(0);
            return minValue;
        }


    }
}
