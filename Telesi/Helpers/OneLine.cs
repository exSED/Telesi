using System;
using System.IO;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telesi.Helpers
{
    class OneLine
    {
        private DataLength dl = new DataLength();
        public string oneLine(string path_)
        {
            string refe = String.Empty;
            if (File.Exists(path_))
            {
                if (dl.dataLength(path_) != 0)
                {
                    for (int i = 0; i < dl.dataLength(path_); i++)
                    {
                        string[] dataInventory = File.ReadAllLines(path_);
                        refe += dataInventory[i] + "\n\r";
                    }
                    return refe;
                }
                else
                {
                    return "";
                }
            }
            else
            {
                MessageBox.Show("El vacio es inexistencia");
                return null;
            }
        }
    }
}
