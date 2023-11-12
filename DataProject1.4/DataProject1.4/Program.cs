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
            int[,] distanceMtrx = new int[81, 81];
            string path = @"C:\Users\fcan5\OneDrive\Belgeler\DataLab\ilmesafe.xlsx";
            distanceArr = xlReader.ReadExcelDistance(path, distanceArr);
            distanceMtrx = xlReader.ReadExcelDistance(path, distanceMtrx);
            string[] cityArr = xlReader.ReadExcelCity(path);
            City city = new City(cityArr, distanceArr, distanceMtrx);
            short select = 0;
            while (select != -1)
            {
                Console.WriteLine("-------------------------------------------------------------------------------------------------"+
                                  "\n1- Verilen ilden belli bir uzaklığa kadar olan illerin ve uzaklıklarının listelenmesi." +
                                  "\n2- Türkiye’deki birbirine en yakın iki ilin ve en uzak iki ilin bulunması." +
                                  "\n3- Verilen ilden verilen mesafe kullanılarak en fazla kaç il dolaşılabildiğinin bulunması." +
                                  "\n4- Rastgele 5 şehir seçerek bu şehirleri matris şeklinde döndürür." +
                                  "\nÇıkış için -1'e basınız."+
                                  "\n-------------------------------------------------------------------------------------------------");
                Console.Write("Seçiminiz : ");
                if(!Int16.TryParse(Console.ReadLine(),out select)) // Sayı dışında veri girişi durumunda kontrol
                {
                    select = 0;
                }
                int plateNum, distance;
                switch (select)
                {

                    case 1:
                        Console.Write("Seçmek istediğiniz ilin adı veya plakası: ");
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
                        Console.Write("Şehir adı veya plakası : ");
                        int startingCityIndex;
                        cityName = Console.ReadLine().ToUpper();
                        if (int.TryParse(cityName, out plateNum))
                        {
                            startingCityIndex = plateNum - 1;
                        }
                        else
                        {
                            startingCityIndex = Array.IndexOf(cityArr, cityName);
                        }
                        Console.Write("Gidilecek maksimum mesafe : ");
                        int maxDistance = Int16.Parse(Console.ReadLine());

                        List<int> shortPath = new List<int>();
                        List<int> maxCitiesPath = new List<int>();

                        int maxCities = city.FindMaxCities(startingCityIndex, maxDistance, shortPath, maxCitiesPath);

                        Console.WriteLine($"Başlangıç şehri {cityArr[startingCityIndex]} için maksimum {maxDistance} km mesafede gidilebilecek en fazla şehir sayısı: {maxCitiesPath.Count()}");
                        Console.WriteLine("Güzergah : ");
                        int end = maxCitiesPath.Count();
                        int totalDist = 0;
                        for (int i = 0; i < end - 1; i++)
                        {
                            int cityIndex = maxCitiesPath[i];
                            int nextCityIndex = maxCitiesPath[i + 1];
                            int tempDistance = distanceMtrx[cityIndex, nextCityIndex];
                            Console.Write($"{cityArr[cityIndex]} ->({tempDistance}km)-> ");
                            totalDist += tempDistance;
                        }
                        Console.Write(cityArr[maxCitiesPath[end - 1]] + "\n");
                        Console.WriteLine($"Gidilen toplam yol: {totalDist}km");
                        break;
                    case 4:
                    // TODO: Random şehir bulma kısmı eklenecek
                    default:
                        // Menüdeki seçenekler dışında bir şey seçilirse.
                        Console.WriteLine("Hatalı seçim yaptınız! Lütfen tekrar deneyiniz.");
                        break;
                }
            }
        }
    }
}
