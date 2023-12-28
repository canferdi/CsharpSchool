using DataProject2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProject3
{
    public class BalancedBST
    {
        private UM_Alani[] UMArr;
        private int size;

        public BalancedBST(UM_Alani[] UMArr)
        {
            this.size = UMArr.Length;
            this.UMArr = UMArr;
        }

        public UM_Alani remove(int index)
        {
            UM_Alani temp = UMArr[index];
            for (int i = index; i < size; i++)
            {
                if (i < size-1)
                {
                    UMArr[i] = UMArr[++i];
                }  
            }
            size--;
            return temp;
        }
        
        public BinarySearchTree createBalancedBST()
        {
            BinarySearchTree bst = new BinarySearchTree();
            createBalancedBSTHelper(bst, 0, UMArr.Length - 1);

            return bst;
        }

        public void createBalancedBSTHelper(BinarySearchTree bst, int start, int end)
        {
            if (start <= end)
            {
                int mid = (start + end) / 2;
                bst.insert(UMArr[mid]);

                createBalancedBSTHelper(bst, start, mid - 1); // Sol taraf
                createBalancedBSTHelper(bst, mid + 1, end); // Sağ taraf
            }

        }

    }
}
