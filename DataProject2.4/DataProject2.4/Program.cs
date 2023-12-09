using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DataProject2._4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] products = { 10, 4, 8, 6, 7, 1, 15, 9, 3, 2 };
            int customersNum = products.Length;
            double processTime = 2.5;
            double totalTime = 0;

            Queue queue = new Queue(customersNum);
            PriorityQueue pq = new PriorityQueue();

            foreach (int product in products)
            {
                queue.enque(product);
                pq.enqueue(product);
            }
            Console.WriteLine(queue.Length);
            Console.WriteLine("---KUYRUK KULLANARAK---");
            int length = queue.Length;
            for (int i = 0; i < length; i++)
            {
                Console.WriteLine("bok " + i);
                int productNum = queue.deque();
                Console.WriteLine(productNum);
                double waitingTime = productNum * processTime * (customersNum - i);
                totalTime += waitingTime;
                Console.WriteLine($"{i + 1}. Müşteri: ");
                Console.WriteLine($"Ürün sayısı: {productNum}");
                Console.WriteLine($"Bekleme süresi: {totalTime}");
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            }
            Console.WriteLine($"Toplam bekleme süresi: {totalTime}");
            Console.WriteLine($"Ortalama bekleme süresi: {totalTime / customersNum}");

            totalTime = 0;
            Console.WriteLine("\n---AYRICALIKLI KUYRUK KULLAIMI---");
            length = pq.Length;
            for (int i = 0; i < length; i++)
            {
                int productNum = pq.deque();
                double waitingTime = productNum * processTime * (customersNum - i);
                totalTime += waitingTime;
                Console.WriteLine($"{i + 1}. Müşteri: ");
                Console.WriteLine($"Ürün sayısı: {productNum}");
                Console.WriteLine($"Bekleme süresi: {totalTime}");
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            }
            Console.WriteLine($"Ortalama bekleme süresi: {totalTime / customersNum}");
        }
    }
}
