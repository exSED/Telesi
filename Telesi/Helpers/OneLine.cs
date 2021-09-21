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
            if (File.Exists(path_))
            {
                string refe = String.Empty;
                string[] dataInventory = File.ReadAllLines(path_);
                if (dataInventory.Length != 0)
                {
                    for (int i = 0; i < dl.dataLength(path_); i++)
                    {
                        refe += dataInventory[i] + "\n";
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
