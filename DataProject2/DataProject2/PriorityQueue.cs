using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProject2
{
    internal class PriorityQueue
    {
        private List<UM_Alani> umAlanlari;

        public PriorityQueue()
        {
            umAlanlari = new List<UM_Alani>();
        }

        public void enque(UM_Alani item)
        {
            umAlanlari.Add(item);
        }

        public UM_Alani deque()
        {
            if (isEmpty())
            {
                Console.WriteLine("Öncelikli kuyruk boş.");
                return null;
            }

            UM_Alani minItem = findMin();
            umAlanlari.Remove(minItem);
            return minItem;
        }

        public bool isEmpty()
        {
            return umAlanlari.Count == 0;
        }

        private UM_Alani findMin()
        {
            UM_Alani minItem = umAlanlari[0];
            foreach (UM_Alani umAlani in umAlanlari)
            {
                if (minItem.getMinCity().CompareTo(umAlani.getMinCity()) > 0){
                    minItem = umAlani;
                }
            }
            return minItem;
        }
    }
}
