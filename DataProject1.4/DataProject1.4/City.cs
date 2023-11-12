using OfficeOpenXml.Table;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Schema;

namespace DataProject1._4
{
    internal class City
    {

        private string[] cityArr;
        private int[][] distanceArr;
        private int[,] distanceMtrx;

        public City(string[] cityArr, int[][] distanceArr, int[,] distanceMtrx)
        {
            this.cityArr = cityArr;
            this.distanceArr = distanceArr;
            this.distanceMtrx = distanceMtrx;
        }

        public void CityByDistance(string cityName, int distance)
        {
            int row, col;
            Boolean isReverse = false;

            for (row = 0; row < 81; row++)  // Seçilen ilin satırını row değişkenine atar
            {
                if (cityArr[row].Equals(cityName)) { break; }

            }
            Console.WriteLine();
            for (col = 0; col < 81; col++)
            {
                if (col == row)
                {
                    isReverse = true;
                    continue;
                }
                if (!isReverse)  // Kontrol mekanizmasının yönünü değiştirir
                {
                    if (distanceArr[row][col] < distance)
                    {
                        Console.WriteLine($"{cityName} <-> {cityArr[col].PadRight(20)}->  {distanceArr[row][col]}km");
                    }
                }
                else
                {
                    if (distanceArr[col][row] < distance)
                    {
                        Console.WriteLine($"{cityName} <-> {cityArr[col].PadRight(20)}->  {distanceArr[col][row]}km");
                    }
                }
            }
            Console.WriteLine();
        }

        public void MinMaxDistance()
        {
            int minDist = int.MaxValue; int maxDist = int.MinValue;
            string maxCty1 = "", maxCty2 = "", minCty1 = "", minCty2 = "";

            for (int row = 0; row < 81; row++)
            {
                for (int col = 0; col < row; col++)
                {
                    int tempDist = distanceArr[row][col];
                    if (tempDist < minDist)
                    {
                        minDist = tempDist;
                        minCty1 = cityArr[col];
                        minCty2 = cityArr[row];
                    }
                    else if (tempDist > maxDist)
                    {
                        maxDist = tempDist;
                        maxCty1 = cityArr[col];
                        maxCty2 = cityArr[row];
                    }
                }
            }
            Console.WriteLine("En yakın iki şehir: " + minCty1 + "-" + minCty2 + "  " + minDist + "km");
            Console.WriteLine("En uzak iki şehir: " + maxCty1 + "-" + maxCty2 + "  " + maxDist + "km\n");
        }

        public int FindMaxCities(int currentCityIndex, int remainingDistance, List<int> path, List<int> maxCitiesPath)
        {
            path.Add(currentCityIndex);

            if (path.Count > maxCitiesPath.Count)
            {
                maxCitiesPath.Clear();
                maxCitiesPath.AddRange(path);
            }

            int maxCities = maxCitiesPath.Count;

            for (int i = 0; i < distanceMtrx.GetLength(1); i++)
            {
                if (!path.Contains(i) && distanceMtrx[currentCityIndex, i] <= remainingDistance)
                {
                    FindMaxCities(i, remainingDistance - distanceMtrx[currentCityIndex, i], path, maxCitiesPath);
                }
            }

            // Herhangi bir değişiklik yapmadan önce şu anki şehiri çıkartıyoruz.
            path.RemoveAt(path.Count - 1);

            return maxCities;
        }

        public void RandomCityDistance()
        {
            int[,] randomcitymatrix = new int[5, 5];
            int[] randomplatenumbers = new int[5];
            Random r = new Random();
            for (int i = 0; i < 5; i++)
            {
                int randomplate = r.Next(0, 81);
                randomplatenumbers[i] = randomplate;
            }
            Console.Write("".PadRight(15));
            foreach (int i in randomplatenumbers)
            {
                Console.Write(cityArr[i].ToString().PadRight(15));
            }
            Console.WriteLine();

            for (int i = 0; i < 5; i++)
            {
                Console.Write(cityArr[randomplatenumbers[i]].PadRight(15));
                for (int j = 0; j < 5; j++)
                {
                    randomcitymatrix[i, j] = distanceMtrx[randomplatenumbers[i], randomplatenumbers[j]];
                    Console.Write(randomcitymatrix[i, j].ToString().PadRight(15));
                }
                Console.WriteLine();
            }

        }

    }
}

