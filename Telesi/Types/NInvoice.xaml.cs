using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Telesi.Types;
using Telesi.Helpers;

namespace Telesi.Types
{
    /// <summary>
    /// Lógica de interacción para NInvoice.xaml
    /// </summary>
    public partial class NInvoice : UserControl
    {
        private InvoExtractor ieo = new InvoExtractor();
        private InveExtractor iee = new InveExtractor();
        private DataLength dl = new DataLength();
        private AllPaths ap = new AllPaths();
        private List<Invoice> dataInvo;
        private List<Products> dataInve, lim;
        private Label content_ = new Label();
        private string value_;
        public NInvoice()
        {
            dataInvo = ieo.Invoices(ap.Invo_(), ap.ProdInvo_());
            dataInve = iee.Inventario(ap.Inve_());
            InitializeComponent();
        }
        private void UpdateList(object sender, SizeChangedEventArgs e)
        {

        }
        private void TBoxF(object sender, RoutedEventArgs e)
        {
            var c = e.OriginalSource as FrameworkElement;
            value_ = c.Name;
            c.SetValue(TextBox.TextProperty, "");
        }
        private void TBoxLF(object sender, RoutedEventArgs e)
        {
            var c = e.OriginalSource as FrameworkElement;
            if (c.GetValue(TextBox.TextProperty).ToString() == "")
            {
                c.SetValue(TextBox.TextProperty, value_);
            }
        }
        private void NumberLim(object sender, KeyEventArgs e)
        {
            if (e.Key >= Key.D0 && e.Key <= Key.D9 || e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
        private void Acs(object sender, MouseButtonEventArgs e)
        {

        }
        private void cans(object sender, MouseButtonEventArgs e)
        {
            content_.Content = ;
            PPP.Children.Add(content_);
        }
        private void NumInv(object sender, TextChangedEventArgs e)
        {
            if (NInvo.Text != String.Empty && NInvo.Text != "Número de factura")
            {
                for (int i=0; i < dataInvo.Count; i++)
                {
                    if (NInvo.Text == dataInvo[i].number_)
                    {
                        RefProd.Visibility = Visibility.Hidden;
                    }
                    else
                    {
                        RefProd.Visibility = Visibility.Visible;
                    }
                }
            }
        }
        private void RefProdT(object sender, TextChangedEventArgs e)
        {
            if (RefProd.Text != String.Empty && RefProd.Text != "Referencia")
            {

                for (int i = 0; i < dataInve.Count; i++)
                {
                    if (RefProd.Text == dataInve[i].id_)
                    {
                        CountProd.Visibility = Visibility.Visible;
                        lim.Add(dataInve[i]);
                    }
                }
            }
        }
        private void RefCountT(object sender, TextChangedEventArgs e)
        {
            if ((CountProd.Text != String.Empty && CountProd.Text != "Cantidad") && CountProd.Visibility == Visibility.Visible)
            {
                DescuProd.Visibility = Visibility.Visible;
            }
        }
        private void RefDesT(object sender, TextChangedEventArgs e)
        {
            if ((DescuProd.Text != String.Empty && DescuProd.Text != "Descuento") && DescuProd.Visibility == Visibility.Visible)
            {
                NewInvoOk.Visibility = Visibility.Visible;
            }
        }
    }
}
