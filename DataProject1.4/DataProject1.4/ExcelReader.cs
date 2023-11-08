using System;
using System.IO;
using OfficeOpenXml;

namespace DataProject1._4
{
    internal class ExcelReader
    {
        public int[][] ReadExcelDistance(string filePath, int[][] distanceArr)
        {
            FileInfo fileInfo = new FileInfo(filePath);
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (ExcelPackage package = new ExcelPackage(fileInfo))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets[0]; // İlk çalışma sayfasını seç

                // Excel tablosundan veri oku ve arraye yerleştir
                for (int row = 0; row < 81; row++)
                {
                    distanceArr[row] = new int[row + 1];
                    for (int col = 0; col <= row; col++)
                    {
                        if (int.TryParse(worksheet.Cells[row + 3, col + 3].Value?.ToString(), out int value))
                        {
                            distanceArr[row][col] = value;
                        }
                        else
                        {
                            // Hata durumunda yapılacak işlemi belirleyin row==col olma durumu
                            distanceArr[row][col] = 0;
                        }
                    }
                }
                return distanceArr;
            }
        }

        public int[,] ReadExcelDistance(string filePath, int[,] distanceMtrx)
        {
            FileInfo fileInfo = new FileInfo(filePath);
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (ExcelPackage package = new ExcelPackage(fileInfo))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets[0]; // İlk çalışma sayfasını seç

                // Excel tablosundan veri oku ve arraye yerleştir
                for (int row = 0; row < 81; row++)
                {
                    for (int col = 0; col < 81; col++)
                    {
                        if (int.TryParse(worksheet.Cells[row + 3, col + 3].Value?.ToString(), out int value))
                        {
                            distanceMtrx[row,col] = value;
                        }
                        else
                        {
                            // Hata durumunda yapılacak işlemi belirleyin row==col olma durumu
                            distanceMtrx[row,col] = 0;
                        }
                    }
                }
                return distanceMtrx;
            }
        }

        public string[] ReadExcelCity(string filePath)
        {
            FileInfo fileInfo = new FileInfo(filePath);
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (ExcelPackage package = new ExcelPackage(fileInfo))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets[0]; // İlk çalışma sayfasını seç

                // 81'lik bir dizi oluştur
                string[] cityArr = new string[81];

                // Excel tablosundan veri oku ve matrise yerleştir
                for (int row = 0; row < 81; row++)
                {
                    cityArr[row] = worksheet.Cells[row+3, 2].Value?.ToString();
                }

                return cityArr;
            }
        }

        public void PrintMatrix(int[][] distanceArr)
        {
            for (int i = 0; i < distanceArr.GetLength(0); i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    Console.Write(distanceArr[i][j] + "  ");
                }
                Console.WriteLine();
            }
        }

        public void PrintMatrix(string[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }
        }
    }
}
