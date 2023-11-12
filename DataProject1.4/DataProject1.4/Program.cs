using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProject1._4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ExcelReader xlReader = new ExcelReader();
            int[][] distanceArr = new int[81][];
            int[,] distanceMtrx = new int[81,81];
            string path = @"C:\Users\fcan5\OneDrive\Belgeler\DataLab\ilmesafe.xlsx";
            distanceArr = xlReader.ReadExcelDistance(path,distanceArr);
            distanceMtrx = xlReader.ReadExcelDistance(path, distanceMtrx);
            string[] cityArr = xlReader.ReadExcelCity(path);
            City city = new City(cityArr, distanceArr,distanceMtrx);
            int select = 0;
            while (select != -1)
            {
                Console.WriteLine("1- Verilen ilden belli bir uzaklığa kadar olan illerin ve uzaklıklarının listelenmesi: " +
                                  "\n2- Türkiye’deki birbirine en yakın iki ilin ve en uzak iki ilin bulunması:" +
                                  "\n3- Verilen ilden verilen mesafe kullanılarak en fazla kaç il dolaşılabildiğinin bulunması:" +
                                  "\nÇıkış için -1 e basınız\n");
                select = Int16.Parse(Console.ReadLine());
                int plateNum, distance;
                switch (select)
                {
                    
                    case 1:
                        Console.Write("Lütfen seçmek istediğiniz ilin adını veya plakasını giriniz: ");
                        string cityName = Console.ReadLine().ToUpper();
                        if (int.TryParse(cityName, out plateNum))
                        {
                            cityName = cityArr[plateNum - 1];
                        }
                        Console.Write("Lütfen mesafeyi giriniz: ");
                        distance = Int16.Parse(Console.ReadLine());
                        city.CityByDistance(cityName, distance);
                        break;
                    case 2:
                        city.MinMaxDistance();
                        break;
                    case 3:
                        Console.Write("Şehir indexi : ");
                        int startingCityIndex = Int16.Parse(Console.ReadLine());
                        Console.Write("Max mesafe : ");
                        int maxDistance = Int16.Parse(Console.ReadLine());

                        List<int> shortPath = new List<int>();
                        List<int> maxCitiesPath = new List<int>();

                        int maxCities = city.FindMaxCities(startingCityIndex, maxDistance, shortPath, maxCitiesPath);

                        Console.WriteLine($"Başlangıç şehri {cityArr[startingCityIndex]} için maksimum {maxDistance} km mesafede gidilebilecek en fazla şehir sayısı: {maxCities}");
                        Console.WriteLine("En çok gidilen path:");
                        foreach (var cityIndex in maxCitiesPath)
                        {
                            Console.Write(cityArr[cityIndex] + " -> ");
                        }
                        Console.WriteLine();
                        
                        break;

                    default:
                        break;
                }
            }
        }
    }
}
