using System;
using System.IO;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telesi.Helpers
{
    class NewLines
    {
        public void writer(string arg, string path_)
        {
            try
            {
                if (File.Exists(path_))
                {
                    using (StreamWriter sw = File.CreateText(path_))
                    {
                        sw.WriteLine(arg);
                    }
                }
                else
                {
                    MessageBox.Show("No se encuentra el paquete especificado (Inventario), verifique su paquete de archivos.\n\n");
                }
            }
            catch (Exception e_)
            {
                MessageBox.Show(e_ + "");
            }
        }
    }
}
