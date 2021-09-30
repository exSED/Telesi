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
    class InvoExtractor
    {
        private DataLength dl = new DataLength();
        private List<Invoice> ListInvoice = new List<Invoice>();
        public List<Invoice> Invoices(string path_)
        {
            try
            {
                if (File.Exists(path_))
                {
                    string[] dataInvoice1 = File.ReadAllLines(path_);
                    if (dataInvoice1.Length > 0 && dataInvoice1[0] != String.Empty)
                    {
                        for (int i = 0; i < dataInvoice1.Length; i++)
                        {
                            string dP = dataInvoice1[i].Replace("\t", "\r\n");
                            string[] dataInvoice = dP.Split("\r\n");
                            ListInvoice.Add(new Invoice {
                                number_ = dataInvoice[0],
                                date_ = dataInvoice[1],
                                total_ = dataInvoice[2],
                            });
                        }
                        return ListInvoice;
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
