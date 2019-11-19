using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace MarktApplicatie {
    public static class SoufTools {

        public static string path = AppDomain.CurrentDomain.BaseDirectory;
        public static string custom_fruit_path = path + @"data\custom_fruits.txt";

        
        public static string[][] GetAllFruits()
        {
            // load fruits from file and split it into each fruit with their respective color.
            string data = File.ReadAllText(SoufTools.custom_fruit_path);
            string[] data_fruits = data.Split(';');

            string[][] fruit_names = new string[data_fruits.Length][];

            int i = 0;
            foreach (string fruit in data_fruits)
            {
                // if you reached the end of the line
                if (fruit.Length == 0)
                {
                    break;
                }

                // every fruit with their color gets split and combined into a new item
                string[] d = fruit.Split('|');

                fruit_names[i++] = new string[] { d[0], d[1] };
                
            }
            return fruit_names;


        }

        public static SolidColorBrush GetColor(string code) {
            return (SolidColorBrush)(new BrushConverter().ConvertFrom(code));
        }

        /*
         ref: https://www.programmingalgorithms.com/algorithm/decimal-to-hexadecimal/
        */
    public static string DecimalToHexadecimal(int dec) {
            if (dec < 1) return "0";

            int hex = dec;
            string hexStr = string.Empty;

            while (dec > 0) {
                hex = dec % 16;

                if (hex < 10)
                    hexStr = hexStr.Insert(0, Convert.ToChar(hex + 48).ToString());
                else
                    hexStr = hexStr.Insert(0, Convert.ToChar(hex + 55).ToString());

                dec /= 16;
            }

            return hexStr;
        }
    }
}
