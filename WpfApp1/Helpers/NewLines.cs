using System;
using System.IO;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Helpers
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
                    MessageBox.Show("No se encuentra el paquete especificado, verifique su paquete de archivos.\n\n" + path_);
                }
            }
            catch (Exception e_)
            {
                MessageBox.Show(e_ + "");
            }
        }
    }
}
