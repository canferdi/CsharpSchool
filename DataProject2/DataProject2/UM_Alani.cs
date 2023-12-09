using System;

namespace DataProject2
{
    internal class UM_Alani
    {
        private string heritageName;
        private string[] cityNames;
        private int declarationYear;

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
            Console.WriteLine(", " + declarationYear);
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
    }
}
