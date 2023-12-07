using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DataProject2
{
    internal class UM_Data
    {
        string[] cities = {
            "Adana", "Adıyaman","Afyonkarahisar","Ağrı","Amasya","Ankara","Antalya","Artvin","Aydın","Balıkesir","Bilecik",
            "Bingöl","Bitlis","Bolu","Burdur","Bursa","Çanakkale","Çankırı","Çorum","Denizli","Diyarbakır","Edirne","Elazığ",
            "Erzincan","Erzurum","Eskişehir","Gaziantep","Giresun","Gümüşhane","Hakkâri","Hatay","Isparta","Mersin","İstanbul",
            "İzmir","Kars","Kastamonu","Kayseri","Kırklareli","Kırşehir","Kocaeli","Konya","Kütahya","Malatya","Manisa",
            "Kahramanmaraş","Mardin","Muğla","Muş","Nevşehir","Niğde","Ordu","Rize","Sakarya","Samsun","Siirt","Sinop",
            "Sivas","Tekirdağ","Tokat","Trabzon","Tunceli","Şanlıurfa","Uşak","Van","Yozgat","Zonguldak","Aksaray","Bayburt",
            "Karaman","Kırıkkale","Batman","Şırnak","Bartın","Ardahan","Iğdır","Yalova","Karabük","Kilis","Osmaniye","Düzce"
            };

        Dictionary<string, int> cityRegionMap = new Dictionary<string, int>
        {
            // Akdeniz Bölgesi
            {"Antalya", 0},{"Burdur", 0},{"Isparta", 0},{"Mersin", 0},
            {"Adana", 0},{"Hatay", 0},{"Osmaniye", 0},{"Kahramanmaraş", 0},
            // Doğu Anadolu Bölgesi
            {"Malatya", 1},{"Erzincan", 1},{"Elazığ", 1},
            {"Tunceli", 1},{"Bingöl", 1},{"Erzurum", 1},
            {"Muş", 1},{"Bitlis", 1},{"Şırnak", 1},
            {"Kars", 1},{"Ağrı", 1},{"Ardahan", 1},
            {"Van", 1},{"Iğdır", 1},{"Hakkari", 1},
            // Ege Bölgesi
            {"İzmir", 2},{"Aydın", 2},{"Muğla", 2},{"Manisa", 2},
            {"Denizli", 2},{"Uşak", 2},{"Kütahya", 2},{"Afyon", 2},
            // Güneydoğu Anadolu Bölgesi
            {"Gaziantep", 3},{"Kilis", 3},
            {"Adıyaman", 3},{"Şanlıurfa", 3},
            {"Diyarbakır", 3},{"Mardin", 3},
            {"Batman", 3},{"Siirt", 3},
            // İç Anadolu Bölgesi
            {"Eskişehir", 4},{"Konya", 4},{"Ankara", 4},{"Çankırı", 4},
            {"Aksaray", 4},{"Kırıkkale", 4},{"Kırşehir", 4},{"Yozgat", 4},
            {"Niğde", 4},{"Nevşehir", 4},{"Kayseri", 4},{"Karaman", 4},
            {"Sivas", 4},
            // Karadeniz Bölgesi
            {"Bolu", 5},{"Düzce", 5},{"Zonguldak", 5},{"Karabük", 5},
            {"Bartın", 5},{"Kastamonu", 5},{"Çorum", 5},{"Sinop", 5},
            {"Samsun", 5},{"Amasya", 5},{"Tokat", 5},{"Ordu", 5},
            {"Giresun", 5},{"Gümüşhane", 5},{"Trabzon", 5},{"Bayburt", 5},
            {"Rize", 5},{"Artvin", 5},
            // Marmara Bölgesi
            {"Çanakkale", 6},{"Balıkesir", 6},{"Edirne", 6},{"Tekirdağ", 6},
            {"Kırklareli", 6},{"İstanbul", 6},{"Bursa", 6},{"Yalova", 6},
            {"Kocaeli", 6},{"Bilecik", 6},{"Sakarya", 6}
        };

        string[] regions = { "Akdeniz", "Doğu Anadolu", "Ege", "Güneydoğu Anadolu", "İç Anadolu", "Karadeniz", "Marmara" };

        string heritageName;
        List<String> cityNames = new List<String>();
        int declarationYear;
        List<UM_Alani>[] umAreaArray = new List<UM_Alani>[7];

        public void UmCatch()
        {
            string path = @"C:\Users\fcan5\Desktop\UM_Alanlari.txt";
            for (int i = 0; i < 7; i++)
            {
                umAreaArray[i] = new List<UM_Alani>();
            }
            try
            {
                // Dosyadan okuma işlemi
                using (StreamReader sr = new StreamReader(path, Encoding.UTF8))
                {
                    string line;

                    // Dosyanın sonuna kadar her satırı oku
                    while ((line = sr.ReadLine()) != null)
                    {
                        //Miras alanını alma
                        if (line.Length > 0)
                        {
                            int indexOfOpeningParenthesis = line.IndexOf('(');
                            if (indexOfOpeningParenthesis != -1)
                            {
                                int startIndex = line.IndexOf(' ') + 1;
                                int length = indexOfOpeningParenthesis - startIndex;

                                if (length > 0)
                                {
                                    string newText = line.Substring(startIndex, length).Trim();
                                    heritageName = newText;
                                }
                            }
                            //Şehri alma
                            foreach (string city in cities)
                            {
                                if (line.Contains(city))
                                {
                                    cityNames.Add(city);
                                }
                            }
                            //Tarihi alma
                            string[] words = line.Split(' ');
                            foreach (string word in words)
                            {
                                if (int.TryParse(word, out declarationYear))
                                {
                                    break; // Eğer bir sayı bulunursa döngüden çık
                                }
                            }

                            int regionInd;
                            foreach (string city in cityNames)
                            {
                                regionInd = cityRegionMap[city];
                                string[] cityArr = cityNames.ToArray();
                                umAreaArray[regionInd].Add(new UM_Alani(heritageName, cityArr, declarationYear));

                            }
                        }
                        cityNames.Clear();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Hata: " + e.Message);
            }

            for (int i = 0; i < 7; i++)
            {
                Console.WriteLine(regions[i] + " Bölgesi:");
                for (int j = 0; j < umAreaArray[i].Count(); j++)
                {
                    //Console.WriteLine("i: " + i + " - j: " + j);
                    umAreaArray[i][j].printInfo();
                }
                Console.WriteLine();

            }
        }

    }
}