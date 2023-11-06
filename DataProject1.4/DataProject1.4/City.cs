using OfficeOpenXml.Table;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProject1._4
{
    internal class City
    {
        //private string cityName;
        //private int distance;
        private string[] cityArr;
        private int[][] distanceArr;

        public City(string[] cityArr, int[][] distanceArr)
        {
            //this.cityName = cityName;
            //this.distance = distance;
            this.cityArr = cityArr;
            this.distanceArr = distanceArr;
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
                        Console.WriteLine(cityArr[col] + "-" + distanceArr[row][col] + "km");
                    }
                }
                else
                {
                    if (distanceArr[col][row] < distance)
                    {
                        Console.WriteLine(cityArr[col] + "-" + distanceArr[col][row] + "km");
                    }
                }
            }
            Console.WriteLine();
        }

        public void MinMaxDistance()
        {
            int minDist = 2147483647; int maxDist = -2147483648;
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
                    else
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

        public void CityWander(string cityName, int distance)
        {
            int[][] copiedDistanceArr = new int[distanceArr.Length][];
            for (int i = 0; i < distanceArr.Length; i++)
            {
                copiedDistanceArr[i] = new int[distanceArr[i].Length];
                Array.Copy(distanceArr[i], copiedDistanceArr[i], distanceArr[i].Length);
            }
            int row = NearestCityFinder(cityName, distance,copiedDistanceArr)[0];
            int col = NearestCityFinder(cityName, distance, copiedDistanceArr)[1];
            copiedDistanceArr[row][col] = 0;
            cityName = cityArr[col];
            distance = copiedDistanceArr[row][col];


        }



        // En yakın şehir olmaması durumunda result {0,0}
        public int[] NearestCityFinder(string cityName, int distance, int[][]copiedDistanceArr)
        {
            int row, col;
            int minDist = 2147483647;
            Boolean isReverse = false;

            for (row = 0; row < 81; row++)  // Seçilen ilin satırını row değişkenine atar
            {
                if (cityArr[row].Equals(cityName)) { break; }
            }

            int[] result = new int[2];
            for (col = 0; col < 81; col++)
            {
                if (col == row)
                {
                    isReverse = true;
                    continue;
                }
                if (!isReverse)  // Kontrol mekanizmasının yönünü değiştirir
                {
                    if ((copiedDistanceArr[row][col] < minDist) && (copiedDistanceArr[row][col] <= distance))
                    {
                        result[0] = row;
                        result[1] = col;
                    }
                }
                else
                {
                    if ((distanceArr[col][row] < minDist) && (copiedDistanceArr[col][row] <= distance))
                    {
                        result[0] = col;
                        result[1] = row;
                    }
                }
            }
            return result;
        }

        public void RandomFiveCity()
        {
            Random random = new Random();

        }
    }
}

