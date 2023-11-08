using OfficeOpenXml.Table;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Schema;

namespace DataProject1._4
{
    internal class City
    {
        int totalDist = 0;
        List<int> visitedCities = new List<int>();
      
        Stack<int> shortestPath = new Stack<int>();
        Stack<int> cityStack = new Stack<int>();
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
                    else if(tempDist > maxDist)
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
            //Stack<int> cityStack = new Stack<int>();
            
            bool[,] isVisited = new bool[81, 81]; // varsayılan false değeri atanmış
            int totalDist = 0;
            // İlk seçilen ili listeye ekler
            int row = Array.IndexOf(cityArr, cityName); 
            isVisited[row,row] = true;
            //cityStack.Push(row);  // ziyaret edilen şehirleri stacke ekler
            visitedCities.Add(row);

            int shortestWay = int.MaxValue;
            int cityCounter = 0;
            int nearCityInd = 0;
            while (true)
            {
                //nearCityInd =FindNearestCity(row, distance);
                //cityStack.Push(nearCityInd);
                visitedCities.Add(nearCityInd);

            }
        }

        public int FindNearestCity(int row, int targetDist)
        {
            
            int minDist = int.MaxValue;
            int nearCityInd = 0;
            
            cityStack.Push(row);
            for (int col =0; col < 81; col++)
            {
                if ((distanceMtrx[row,col]<minDist) &&(row!=col) && (!cityStack.Contains(col)))
                {
                    minDist = distanceMtrx[row,col];
                    nearCityInd = col;
                }
            }
            totalDist += distanceMtrx[row, nearCityInd];
            Console.WriteLine(totalDist);
            if(totalDist > targetDist)
            {
                cityStack.Pop();
                if(cityStack.Count > shortestPath.Count) 
                {
                    Console.WriteLine("en kısa yol");
                }
                Console.WriteLine("bitti");
                return 0;
            }
            return FindNearestCity(nearCityInd, targetDist);


        }
        public void PrintCityStack()
        {
            foreach (int city in cityStack)
            {
                Console.WriteLine(cityArr[city]);
            }
        }
        
        public void PrintShortestPath()
        {
            foreach (int city in shortestPath)
            {
                Console.WriteLine(cityArr[city]);
            }
        }
    }
}

