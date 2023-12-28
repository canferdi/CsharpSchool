using DataProject2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DataProject3
{
    public class Program
    {
        static Dictionary<string, UM_Alani> umDict = new Dictionary<string, UM_Alani>();
        static void Main(string[] args)
        {
            UM_Data umData = new UM_Data();
            List<UM_Alani> umList = umData.UmCatch();
            BinarySearchTree bst = new BinarySearchTree();
            Heap heap = new Heap();

            // UM_Alanlarını belirtilen veri yapılarına ekleme
            foreach (UM_Alani umAlani in umList)
            {
                bst.insert(umAlani);
                umDict.Add(umAlani.HeritageName, umAlani);
                heap.insert(umAlani);
            }

            // Menü
            while (true)
            {
                Console.WriteLine("----------------------------------\n" +
                    "1 - Binary Search Tree Kısmı:\n" +
                    "2 - HashTable Kısmı:\n" +
                    "3 - Heap kısmı:\n" +
                    "0 - Çıkış\n" +
                    "----------------------------------");
                int select;
                select = Int16.Parse(Console.ReadLine());
                switch (select)
                {
                    case 0:
                        break;
                    case 1:
                        List<UM_Alani> results = bst.DFSInOrder();
                        Console.WriteLine($"Düğüm sayısı : {bst.CountOfNode}");
                        UM_Alani[] UMArr = results.ToArray();

                        Console.Write("1- Binary Search Tree : \n" +
                            "2- Dengeli Binary Search Tree : \n" +
                            "Seçiminiz :");
                        int choose = Int16.Parse(Console.ReadLine());
                        switch (choose)
                        {
                            case 1:
                                //BST'nin derinliği
                                int depth = bst.calculateDepth(bst.getRoot());
                                Console.WriteLine($"Derinlik : {depth}");
                                //BST dengeli olsaydı derinliğinin kaç olacağı
                                int balancedDepth = bst.balancedDepth();
                                //Bilgileri yazdırma
                                Console.WriteLine($"Dengeli olsaydı derinlik {balancedDepth} olurdu");
                                Console.WriteLine("Düğümlerin İsimleri : ");
                                foreach (UM_Alani um in results)
                                {
                                    Console.WriteLine(um.HeritageName);
                                }
                                Console.WriteLine("Düğümlerin Bilgileri: ");
                                bst.printInfo();
                                Console.WriteLine();
                                //Belirtilen iki harf arasındaki UM_Alanları
                                Console.Write("Başlangıç UM harfi : ");
                                char start = char.Parse(Console.ReadLine());
                                start = char.ToUpper(start);
                                Console.Write("Bitiş UM harfi : ");
                                char end = char.Parse(Console.ReadLine());
                                end = char.ToUpper(end);
                                bst.searchInRange(start, end);
                                break;
                            case 2:
                                BalancedBST balancedBST = new BalancedBST(UMArr);
                                BinarySearchTree balancedTree = balancedBST.createBalancedBST();
                                balancedTree.printInfo();
                                break;
                        }

                        break;
                    case 2:
                        foreach (var um in umDict)
                        {
                            Console.WriteLine(um);
                        }
                        Console.Write("\nDeğiştirmek İstediğiniz UM Alanı Adı: ");
                        string oldKey = Console.ReadLine();
                        Console.Write("Yeni UM Alanı Adı: ");
                        string newKey = Console.ReadLine();
                        Console.Write($"\nYeni key :{newKey}, Value: ");
                        swapKey(oldKey, newKey).printInfo();
                        break;
                    case 3:
                        Console.WriteLine("İLK 3 ELEMAN: ");
                        for (int i = 0; i < 3; i++)
                        {
                            UM_Alani um = heap.remove();
                            um.printInfo();
                        }

                        break;
                }
            }
        }

        // Dictionarydeki istenen keyi yeni keyle değiştirme
        public static UM_Alani swapKey(string oldKey, string newKey)
        {
            UM_Alani tempValue = umDict[oldKey];
            umDict.Remove(oldKey);
            umDict.Add(newKey, tempValue);
            return umDict[newKey];
        }
    }
}
