using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;

namespace Assignment1_lfe_gfr_41_82.Utilities
{
    //class responsible to read the file 
    class FileService
    {
        static StreamReader sr;

        public static string ReadFile(string fileName)
        {
            string fileContents = "";
            //a try catch to handling possible errors while opens the file
            try
            {
                sr = new StreamReader(fileName);
                fileContents = sr.ReadToEnd();
            }
            catch (IOException ioe)
            {
                MessageBox.Show($"There was a problem opening the file: {fileName}. {ioe.Message}");
            }

            return fileContents;
        }
    }
}
