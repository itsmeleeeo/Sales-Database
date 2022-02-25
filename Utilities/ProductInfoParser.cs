using Assignment1_lfe_gfr_41_82.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Threading.Tasks;

namespace Assignment1_lfe_gfr_41_82.Utilities
{
    class ProductInfoParser
    {
        //file reader
        public static List<ProductInfo> storage = new List<ProductInfo>();

        public static List<ProductInfo> ParseRoster(string fileContents)
        {
            string[] lines = fileContents.Split('\n');

            foreach(string line in lines)
            {
                //spliting the lines that are separated by pipes
                string[] fields = line.Trim().Split('|');

                if(fields.Length != 12)
                {
                } else {
                    try
                    {
                        //adding all values to it's field and binding it to the object
                        ProductInfo np = new ProductInfo(
                            Convert.ToInt32(fields[0]),
                            Convert.ToInt32(fields[1]),
                            Convert.ToDouble(fields[2]),
                            fields[3].Trim(),
                            Convert.ToDouble(fields[4]),
                            Convert.ToDouble(fields[5]),
                            fields[6].Trim(),
                            fields[7].Trim(),
                            fields[8].Trim(),
                            fields[9].Trim(),
                            fields[10].Trim(),
                            fields[10].Trim());
                        storage.Add(np);
                    } catch(Exception ex)
                    {
                        Console.WriteLine($"Error {ex}");
                    }
                }
            }
            return storage;
        }
    }
}
