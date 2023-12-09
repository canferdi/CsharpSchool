using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProject2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UM_Data um = new UM_Data();
            List<UM_Alani> umList = um.UmCatch(); //UM_Alanı nesneleri tutuluyor.

            while (true)
            {
                Console.WriteLine("1- 1.Ödev\n" +
                "2- 2.a Ödev\n" +
                "3- 2.b Ödev\n" +
                "4- 3. Ödev\n" +
                "0- Çıkış\n");
                Console.Write("Seçiminiz : ");
                int select = int.Parse(Console.ReadLine());
                Console.WriteLine();
                switch (select)
                {
                    case 0:
                        break;
                    case 1:
                        um.addList(umList);
                        break;
                    case 2:
                        um.addStack(umList);
                        break;
                    case 3:
                        um.addQueue(umList);
                        break;
                    case 4:
                        um.addPqueue(umList);
                        break;
                }
            }

        }
    }
}
