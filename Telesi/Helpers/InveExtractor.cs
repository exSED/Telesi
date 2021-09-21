using System;
using System.IO;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telesi.Types;

namespace Telesi.Helpers
{
    class InveExtractor{
        private List<Products> ListInventory = new List<Products>();
        public List<Products> Inventario(string path_)
        {
            try
            {               
                if (File.Exists(path_))
                {
                    string[] dataInventory = File.ReadAllLines(path_);
                    if (dataInventory.Length != 0)
                    {
                        for (int i = 0; i < dataInventory.Length; i++)
                        {
                            string dP = dataInventory[i].Replace("\t", "\r\n");
                            string[]  dataProduct = dP.Split("\r\n");
                            ListInventory.Add(new Products
                            {
                                id_ = dataProduct[0],
                                name_ = dataProduct[1],
                                count_ = dataProduct[2],
                                price_ = dataProduct[3]
                            });
                        }
                        return ListInventory;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    File.Create(path_);
                    MessageBox.Show("El paquete de inventario a sido escrito por el vacio");
                    return null;
                }
            }
            catch (Exception e_)
            {
                MessageBox.Show(e_ + "");
                return null;
            }
        }
    }
}
