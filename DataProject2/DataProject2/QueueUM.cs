
namespace DataProject2
{
    internal class QueueUM
    {
        private int size;
        private UM_Alani[] queueArr;
        private int first, last;
        private int length;

        public QueueUM(int size)
        {
            this.size = size;
            queueArr = new UM_Alani[size];
            this.first = 0;
            this.last = -1;
            this.length = 0;
        }

        public void enque(UM_Alani um)
        {
            if (last == size - 1)
            {
                last = -1;
            }
            queueArr[++last] = um;
            length++;
        }

        public UM_Alani deque()
        {
            UM_Alani temp = queueArr[first++];
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
