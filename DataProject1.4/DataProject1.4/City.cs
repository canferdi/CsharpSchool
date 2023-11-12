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

        List<int> shortestPath = new List<int>();
        Stack<int> cityStack = new Stack<int>();
        bool[] visitedCities = new bool[81];


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

        /*public void CityWander(int plate, int distance)
        {
            FindNearestCity(cityStack.Pop(), distance);
            //PrintCityStack();

        }*/

        /*public int FindNearestCity(int row, int targetDist)
        {
            int smallestDistance = int.MaxValue;
            
            int nearCityInd = 0;
            // Console.WriteLine("near dist: " +nearDist);
            cityStack.Push(row);  // Seçilen şehri stacke ekler
            for (int col = 0; col < 81; col++) // En yakın şehri bulan döngü
            {
                if ((distanceMtrx[row, col] < smallestDistance) && (row != col) && (!cityStack.Contains(col)) && (!visitedCities[col]))
                {
                    smallestDistance = distanceMtrx[row, col];
                    nearCityInd = col;  // En yakın şehrin indexi
                }
            }
            //Console.WriteLine("smallest distance : " + smallestDistance);

            totalDist += distanceMtrx[row, nearCityInd];
            //Console.WriteLine($"total dist1: {totalDist}");

            if (totalDist > targetDist)  // Seçilen mesafe katedildiyse
            {
                cityStack.Pop();
                totalDist -= smallestDistance;
                Console.WriteLine($"total dist2: {totalDist}");
                if (cityStack.Count > shortestPath.Count) // En fazla şehir gidilen yolu tutar
                {
                    shortestPath.Clear();
                    //Console.WriteLine("en kısa yol:");
                    foreach (int city in cityStack)
                    {
                        shortestPath.Add(city);
                    }
                }
                visitedCities[cityStack.Pop()] = true;

                int nearDist = targetDist - totalDist;
                Console.WriteLine("TARGET DİST: " + targetDist);
                Console.WriteLine("NEAR DİST: " + nearDist);
                if (!HasNextCity(nearCityInd, nearDist) && cityStack.Count>=1) // Yakın şehir var mı
                {
                    Console.WriteLine("Target 1 : " + targetDist);
                    //visitedCities[cityStack.Pop()] = true;
                    FindNearestCity(cityStack.Peek(), nearDist);
                }
                else if(HasNextCity(nearCityInd, nearDist) && cityStack.Count >= 1)
                {
                    Console.WriteLine("target2: " + targetDist);
                    cityStack.Pop();
                    FindNearestCity(cityStack.Peek(), nearDist);
                }

                if (cityStack.Count == 0) // Kontrol edilecek şehir kalmadıysa
                {
                    return 0;
                }
                else
                {
                    visitedCities[cityStack.Peek()] = true;
                    int x = cityStack.Peek();
                    nearCityInd = cityStack.Pop();

                    totalDist -= distanceMtrx[x, nearCityInd];
                }

            }
            return FindNearestCity(nearCityInd, targetDist);



        }*/

        public int FindMaxCities(int currentCityIndex, int remainingDistance, List<int> path, List<int> maxCitiesPath)
        {
            path.Add(currentCityIndex);

            if (path.Count > maxCitiesPath.Count)
            {
                maxCitiesPath.Clear();
                maxCitiesPath.AddRange(path);
            }

            int maxCities = path.Count;

            for (int i = 0; i < distanceMtrx.GetLength(1); i++)
            {
                if (!path.Contains(i) && distanceMtrx[currentCityIndex, i] <= remainingDistance)
                {
                    int cities = FindMaxCities(i, remainingDistance - distanceMtrx[currentCityIndex, i], new List<int>(path), maxCitiesPath);
                    if (cities > maxCities)
                    {
                        maxCities = cities;
                    }
                }
            }

            return maxCities;
        }







        public void PrintCityStack()
        {
            Console.WriteLine("city stack:");
            foreach (int city in cityStack)
            {
                Console.WriteLine(cityArr[city]);
            }
        }

        public void PrintShortestPath()
        {
            Console.WriteLine("shortest path:");
            foreach (int city in shortestPath)
            {

                Console.WriteLine(cityArr[city]);
            }
        }

        public void PrintVisitedCities()
        {
            for (int i = 0; i < 81; i++)
            {
                Console.WriteLine(visitedCities[i]);
            }
        }
    }
}

