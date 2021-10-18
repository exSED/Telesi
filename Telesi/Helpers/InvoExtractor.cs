using System;
using System.IO;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telesi.Types;
using Telesi.Helpers;

namespace Telesi.Helpers
{
    class InvoExtractor
    {
        private DataLength dl = new DataLength();
        private AllPaths ap = new AllPaths();
        private List<Invoice> ListInvoice = new List<Invoice>();
        private List<PProds_> ListPProds = new List<PProds_>();
        public List<Invoice> Invoices(string pathInvo_, string pathProds_)
        {
            try
            {
                if (File.Exists(pathInvo_)&& File.Exists(pathProds_))
                {
                    string[] dataInvoice1 = File.ReadAllLines(pathInvo_);
                    string[] dataProduct1 = File.ReadAllLines(pathProds_);

                    if (dataProduct1.Length > 0 && dataProduct1[0] != String.Empty)
                    {
                        for (int i = 0; i < dataInvoice1.Length; i++)
                        {
                            List<Products> ListProds = new List<Products>();
                            string dP = dataProduct1[i].Replace("|", "\r\n");
                            string[] dataProduct = dP.Split("\r\n");
                            for (int j = 0; j < dataProduct.Length; j++)
                            {
                                string dPr = dataProduct[j].Replace("-", "\r\n");
                                string[] dataProd = dPr.Split("\r\n");
                                ListProds.Add(new Products
                                {
                                    id_ = dataProd[0],
                                    name_ = dataProd[1],
                                    count_ = dataProd[2],
                                    price_ = dataProd[3]
                                });
                            }
                            ListPProds.Add(new PProds_{
                                lol = ListProds
                            });
                            
                        }
                    }

                    if (dataInvoice1.Length > 0 && dataInvoice1[0] != String.Empty)
                    {
                        for (int i = 0; i < dataInvoice1.Length; i++)
                        {
                            string dI = dataInvoice1[i].Replace("\t", "\r\n");
                            string[] dataInvoice = dI.Split("\r\n");

                            ListInvoice.Add(new Invoice
                            {
                                number_ = dataInvoice[0],
                                date_ = dataInvoice[1],
                                total_ = dataInvoice[2],
                                Product = ListPProds[i].lol
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
                    File.Create(pathInvo_);
                    File.Create(pathProds_);
                    MessageBox.Show("El paquete de facturas a sido escrito por el vacio");
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
