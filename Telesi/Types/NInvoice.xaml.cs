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
        private Grid content_ = new Grid();
        private Label pin_ = new Label();
        private string value_;
        public NInvoice()
        {
            dataInvo = ieo.Invoices(ap.Invo_(), ap.ProdInvo_());
            dataInve = iee.Inventario(ap.Inve_());
            lim = new List<Products>();
            InitializeComponent();
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
            PPP.
            string d;
            for (int i = 0; i < lim.Count; i++)
            {
                content_.RowDefinitions.Add(new RowDefinition() { Height = ColumnReference.Width });
                d = lim[i].id_ + "\t" + lim[i].name_ + "\t\t\t" + CountProd.Text + "\t" + DescuProd.Text + "\r\n";
                pin_ = new Label { Content = d, Name = "id_" + i };
                pin_.SetValue(Grid.RowProperty, i);
                content_.Children.Add(pin_);
            }
            PPP.Children.Add(content_);
        }
        private void NumInv(object sender, TextChangedEventArgs e)
        {
            if (No_Factura.Text != String.Empty && No_Factura.Text != "No_Factura")
            {
                for (int i=0; i < dataInvo.Count; i++)
                {
                    if (No_Factura.Text == dataInvo[i].number_)
                    {
                        Referencia.Visibility = Visibility.Hidden;
                    }
                    else
                    {
                        Referencia.Visibility = Visibility.Visible;
                    }
                }
            }
        }
        private void RefProdT(object sender, TextChangedEventArgs e)
        {
            if (Referencia.Text != String.Empty && Referencia.Text != "Referencia")
            {

                for (int i = 0; i < dataInve.Count; i++)
                {
                    if (Referencia.Text == dataInve[i].id_)
                    {
                        Cantidad.Visibility = Visibility.Visible;
                        lim.Add(new Products { 
                            id_=dataInve[i].id_, 
                            name_=dataInve[i].name_, 
                            count_=dataInve[i].count_,
                            price_=dataInve[i].price_});
                    }
                    else
                    {
                        Cantidad.Visibility = Visibility.Hidden;
                    }
                }
            }
        }
        private void RefCountT(object sender, TextChangedEventArgs e)
        {
            if (Cantidad.Text != String.Empty && Cantidad.Text != "Cantidad")
            {
                Descuento.Visibility = Visibility.Visible;
            }
            else
            {
                Descuento.Visibility = Visibility.Hidden;
            }
        }
        private void RefDesT(object sender, TextChangedEventArgs e)
        {
            if (Descuento.Text != String.Empty && Descuento.Text != "Descuento")
            {
                NewInvoOk.Visibility = Visibility.Visible;
            }
            else
            {
                NewInvoOk.Visibility = Visibility.Hidden;
            }
        }
    }
}
