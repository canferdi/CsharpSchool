using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace DataProject2
{
    public class UM_Alani 
    {
        private string heritageName;
        private string[] cityNames;
        private int declarationYear;
        private List<String> infoText;

        public string HeritageName { get => heritageName; set => heritageName = value; }

        public UM_Alani(string heritageName, string[] cityNames, int declarationYear)
        {
            this.heritageName = heritageName;
            this.cityNames = cityNames;
            this.declarationYear = declarationYear;
        }

        public void printInfo()
        {
            Console.Write(heritageName + ", ");
            Console.Write("[");
            for (int i = 0; i < cityNames.Length - 1; i++)
            {
                Console.Write(cityNames[i] + "-");
            }
            Console.Write(cityNames[cityNames.Length - 1]);
            Console.Write("]");
            Console.WriteLine(", " + declarationYear + "\n");
            foreach (String word in infoText)
            {
                Console.Write(word + " ");
            }
            Console.WriteLine("\n----------------------------------------------------------");
        }

        public string getMinCity()
        {
            string minCity = cityNames[0];
            foreach (string cityName in cityNames)
            {
                if (cityName.CompareTo(minCity) < 0)
                {
                    minCity = cityName;
                }
            }
            return minCity;
        }

        public string[] getCityNames()
        {
            return cityNames;
        }

        public int compareTo(UM_Alani other)
        {
            return this.heritageName.CompareTo(other.heritageName);
        }

        public void addInfoText(List<String> infoText)
        {
            this.infoText = infoText;
        }
    }
}
