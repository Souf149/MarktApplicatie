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
        public static string data_folder_path = AppDomain.CurrentDomain.BaseDirectory + @"data\";
        public static string custom_fruit_path = data_folder_path + @"\custom_fruits.txt";
        public static string compositions_path = data_folder_path + @"\compositions\";

        public static string default_fruit = @"Appel|#FF0000;Banaan|#ffe119;Limoen|#bcf60c;Draken fruit|#911eb4";
        public static int GRID_SIZE = 48;


        // returns all file names in a string
        public static string[] GetAllCompositions() {

            CreateDataFolder();
            CreateDirectory(compositions_path);

            return Directory.GetFiles(compositions_path);
        }



        public static string[][] GetAllFruits()
        {

            // if the folder does not exist create one.
            CreateDataFolder();

            // if the file does not exist give it default value
            CreateFile(custom_fruit_path, default_fruit);
            


            // load fruits from file and split it into each fruit with their respective color.
            string data = File.ReadAllText(custom_fruit_path);
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


        private static void CreateDirectory(string folder_path) {
            // if the folder does not exist
            if (!Directory.Exists(folder_path)) {
                Directory.CreateDirectory(folder_path);
            }
        }

        public static void CreateFile(string file_path, string value = "") {
            // if the file does not exist give it default value
            if (!File.Exists(file_path)) {
                FileStream file = File.Create(file_path);
                file.Close();
            }
            File.WriteAllText(file_path, value);
        }

        private static void CreateDataFolder() {
            // if the folder does not exist create one
            CreateDirectory(data_folder_path);
        }

        public static SolidColorBrush GetColor(string code) {
            return (SolidColorBrush)(new BrushConverter().ConvertFrom(code));
        }

        

        
    // ref: https://www.programmingalgorithms.com/algorithm/decimal-to-hexadecimal/
    public static string DecimalToHexadecimal(int dec) {
            if (dec < 1) return "0";
            string hexStr = string.Empty;

            while (dec > 0) {
                int hex = dec % 16;

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
