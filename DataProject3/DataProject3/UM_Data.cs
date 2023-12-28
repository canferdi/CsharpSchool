using DataProject2;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProject3
{
    public class UM_Data
    {
        string heritageName;
        List<String> cityNames = new List<String>();
        int declarationYear;
        List<UM_Alani> umList = new List<UM_Alani>();

        string[] cities = {
            "Adana", "Adıyaman","Afyon","Ağrı","Amasya","Ankara","Antalya","Artvin","Aydın","Balıkesir","Bilecik",
            "Bingöl","Bitlis","Bolu","Burdur","Bursa","Çanakkale","Çankırı","Çorum","Denizli","Diyarbakır","Edirne","Elazığ",
            "Erzincan","Erzurum","Eskişehir","Gaziantep","Giresun","Gümüşhane","Hakkari","Hatay","Isparta","Mersin","İstanbul",
            "İzmir","Kars","Kastamonu","Kayseri","Kırklareli","Kırşehir","Kocaeli","Konya","Kütahya","Malatya","Manisa",
            "Kahramanmaraş","Mardin","Muğla","Muş","Nevşehir","Niğde","Ordu","Rize","Sakarya","Samsun","Siirt","Sinop",
            "Sivas","Tekirdağ","Tokat","Trabzon","Tunceli","Şanlıurfa","Uşak","Van","Yozgat","Zonguldak","Aksaray","Bayburt",
            "Karaman","Kırıkkale","Batman","Şırnak","Bartın","Ardahan","Iğdır","Yalova","Karabük","Kilis","Osmaniye","Düzce"
            };

        public List<UM_Alani> UmCatch()
        {
            string path = @"C:\Users\fcan5\OneDrive\Belgeler\DataLab\DataProject3\DataProject3\UM_Alanlari.txt";
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
                            string[] cityArr = cityNames.ToArray();
                            umList.Add(new UM_Alani(heritageName, cityArr, declarationYear));
                            cityNames.Clear();
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Hata: " + e.Message);
            }

            string dosyaYolu = @"C:\Users\fcan5\OneDrive\Belgeler\DataLab\DataProject3\DataProject3\Words.txt"; // Okunacak metin dosyasının yolu

            List<List<string>> kelimeListesi = new List<List<string>>();
            List<string> geciciListe = new List<string>();

            // Metin dosyasını satır satır oku
            using (StreamReader sr = new StreamReader(dosyaYolu))
            {
                int i = 0;
                while (!sr.EndOfStream)
                {

                    string satir = sr.ReadLine();

                    if (string.IsNullOrWhiteSpace(satir))
                    {
                        // Boş satır geldiğinde geciciListe'yi kelimeListesi'ne ekle
                        if (geciciListe.Count > 0)
                        {
                            umList[i].addInfoText(geciciListe);
                            //kelimeListesi.Add(geciciListe);
                            geciciListe = new List<string>();
                        }
                        i++;
                    }
                    else
                    {
                        // Satırdaki kelimeleri ayır ve geciciListe'ye ekle
                        string[] kelimeler = satir.Split(' ');
                        geciciListe.AddRange(kelimeler);
                    }
                    
                }

                // Dosyanın sonunda boş satır olmadığı durumu kontrol et
                if (geciciListe.Count > 0)
                {
                    umList[i].addInfoText(geciciListe);
                    //kelimeListesi.Add(geciciListe);
                }
            }


            return umList;
        }

    }
}
