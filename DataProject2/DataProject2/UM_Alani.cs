using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Console.Write(heritageName + ",\t");
            foreach (string city in cityNames)
            {
                Console.Write(city+" ");
            }
            Console.WriteLine(",\t"+declarationYear);
        }
        }
    }
