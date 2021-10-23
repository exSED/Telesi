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
        private OneLine ol = new OneLine();
        private NewLines nl = new NewLines();
        private List<Invoice> dataInvo;
        private List<Products> dataInve, lim;
        private Grid content_ = new Grid();
        private Label pin_ = new Label();
        private string value_;
        private int f = 0;
        public NInvoice()
        {
            dataInvo = ieo.Invoices(ap.Invo_(), ap.ProdInvo_());
            dataInve = iee.Inventario(ap.Inve_());
            lim = new List<Products>();
            InitializeComponent();
            DateL.Content = DateTime.Today.Day + "-" + DateTime.Today.Month + "-" + DateTime.Today.Year;
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
        private void AddProds(object sender, MouseButtonEventArgs e)
        {
            bool q2 = false;
            for (int j = 0; j < lim.Count; j++)
            {
                if (lim[j].id_ == Referencia.Text)
                {
                    q2 = true;
                    break;
                }
            }
            if (q2 == false)
            {
                lim.Add(new Products
                {
                    id_ = dataInve[f].id_,
                    name_ = dataInve[f].name_,
                    count_ = Cantidad.Text,
                    price_ = ((Int32.Parse(dataInve[f].price_) * Int32.Parse(Cantidad.Text)) - Int32.Parse(Descuento.Text)).ToString()
                });
                TotalL.Content = "0";
                PPP.Children.Remove(content_);
                PPP.Children.Clear();
                content_.RowDefinitions.Clear();
                content_.Children.Clear();
                for (int i = 0; i < lim.Count; i++)
                {
                    string d2 = "";
                    content_.RowDefinitions.Add(new RowDefinition() { Height = ColumnReference.Width });
                    d2 = lim[i].id_ + "\t\t" + Cantidad.Text + "\t\t$" + lim[i].price_ + "\t" + lim[i].name_ + "\r\n";
                    pin_ = new Label { Content = d2, Name = "id_" + i };
                    pin_.SetValue(Grid.RowProperty, i);
                    content_.Children.Add(pin_);
                    TotalL.Content = "$" + (Int32.Parse(TotalL.Content.ToString().Replace("$", "")) + Int32.Parse(lim[i].price_));
                }
                PPP.Children.Add(content_);
                RetraRee.Visibility = Visibility.Visible;
            }
            else
            {
                MessageBox.Show(" Este articulo ya existe en la factura, porfavor verifique");
            }
            
        }
        private void NumInv(object sender, TextChangedEventArgs e)
        {
            if (No_Factura.Text == " ")
            {
                No_Factura.Text = "";
            }
            if (No_Factura.Text != String.Empty && No_Factura.Text != "No_Factura")
            {
                if (dataInvo != null)
                {
                    for (int i = 0; i < dataInvo.Count; i++)
                        {
                        if (No_Factura.Text == dataInvo[i].number_)
                        {
                            Referencia.Visibility = Visibility.Hidden;
                            Cantidad.Visibility = Visibility.Hidden;
                            Descuento.Visibility = Visibility.Hidden;
                            NewInvoOk.Visibility = Visibility.Hidden;
                            lim.Clear();
                            TotalL.Content = "0";
                            PPP.Children.Remove(content_);
                            PPP.Children.Clear();
                            content_.RowDefinitions.Clear();
                            content_.Children.Clear();
                            PPP.Children.Add(content_);
                            break;
                        }
                        else
                        {
                            Referencia.Visibility = Visibility.Visible;
                        }
                    }
                }
                else
                {
                    Referencia.Visibility = Visibility.Visible;
                }
            }            
            else
            {
                if (Referencia != null)
                {
                    Referencia.Visibility = Visibility.Hidden;
                    Cantidad.Visibility = Visibility.Hidden;
                    Descuento.Visibility = Visibility.Hidden;
                    NewInvoOk.Visibility = Visibility.Hidden;
                    lim.Clear();
                    TotalL.Content = "0";
                    PPP.Children.Remove(content_);
                    PPP.Children.Clear();
                    content_.RowDefinitions.Clear();
                    content_.Children.Clear();
                    PPP.Children.Add(content_);
                }
            }
        }
        private void RefProdT(object sender, TextChangedEventArgs e)
        {
            if (Referencia.Text == " ")
            {
                Referencia.Text = "";
            }
            if (Referencia.Text != String.Empty && Referencia.Text != "Referencia")
            {
                for (int i = 0; i < dataInve.Count; i++)
                {
                    if (Referencia.Text == dataInve[i].id_)
                    {
                        Cantidad.Visibility = Visibility.Visible;
                        f = i;
                        RefCountT(null, null);
                        break;
                    }
                    else
                    {
                        Cantidad.Visibility = Visibility.Hidden;
                        Descuento.Visibility = Visibility.Hidden;
                        NewInvoOk.Visibility = Visibility.Hidden;
                    }
                }
            }
            else 
            {
                if (Cantidad != null && Descuento != null) {
                    Cantidad.Visibility = Visibility.Hidden;
                    Descuento.Visibility = Visibility.Hidden;
                    NewInvoOk.Visibility = Visibility.Hidden;
                }
            }
        }
        private void RefCountT(object sender, TextChangedEventArgs e)
        {
            if (Cantidad.Text != String.Empty && Cantidad.Text != "Cantidad")
            {
                if (Cantidad.Text != "0")
                {
                    Descuento.Visibility = Visibility.Visible;
                    RefDesT(null,null);
                }
                else
                {
                    Descuento.Visibility = Visibility.Hidden;
                    NewInvoOk.Visibility = Visibility.Hidden;
                }
            }
            else
            {
                if (Descuento != null)
                {
                    Descuento.Visibility = Visibility.Hidden;
                    NewInvoOk.Visibility = Visibility.Hidden;
                }
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
                if (NewInvoOk != null)
                {
                    NewInvoOk.Visibility = Visibility.Hidden;
                }
            }
        }
        private void EresEnd(object sender, MouseButtonEventArgs e)
        {
            if (lim.Count == 0)
            {
                RetraRee.Visibility = Visibility.Hidden;
            }
            else
            {
                lim.Remove(lim.Last());
                TotalL.Content = "0";
                PPP.Children.Remove(content_);
                PPP.Children.Clear();
                content_.RowDefinitions.Clear();
                content_.Children.Clear();
                string d2;
                for (int i = 0; i < lim.Count; i++)
                {
                    content_.RowDefinitions.Add(new RowDefinition() { Height = ColumnReference.Width });
                    d2 = lim[i].id_ + "\t" + "\t" + Cantidad.Text + "\t" + Descuento.Text + "\t\t" + lim[i].name_ + "\r\n";
                    pin_ = new Label { Content = d2, Name = "id_" + i };
                    pin_.SetValue(Grid.RowProperty, i);
                    content_.Children.Add(pin_);
                    TotalL.Content = "$" + (Int32.Parse(TotalL.Content.ToString().Replace("$", "")) + Int32.Parse(lim[i].price_));
                }
                PPP.Children.Add(content_);
                RetraRee.Visibility = Visibility.Visible;
            }
        }
        private void Acs(object sender, MouseButtonEventArgs e)
        {
            if (No_Factura.Text != "" && No_Factura.Text != "No_Factura")
            {
                if (lim.Count != 0)
                {
                    for (int i = 0; i < dataInve.Count; i++)
                    {
                        for (int j = 0; j < lim.Count; j++)
                        {
                            if (lim[j].id_ == dataInve[i].id_)
                            {
                                dataInve[i].count_ = (Int32.Parse(dataInve[i].count_) - Int32.Parse(lim[j].count_)).ToString();
                            }
                        }
                    }
                    string dr2 = No_Factura.Text + "\t" + DateL.Content.ToString() + "\t" + "0";
                    nl.writer(ol.oneLine(ap.Invo_()) + dr2, ap.Invo_());
                    nl.writer(ol.oneLine(ap.ProdInvo_()) + ol.newPorsIvo_(lim), ap.ProdInvo_());
                    nl.writer(ol.newInven_(dataInve), ap.Inve_());
                    lim.Clear();
                    TotalL.Content = "0";
                    PPP.Children.Remove(content_);
                    PPP.Children.Clear();
                    content_.RowDefinitions.Clear();
                    content_.Children.Clear();
                    PPP.Children.Add(content_);
                    No_Factura.Text = "";
                    Referencia.Text = "";
                }
                else
                {
                    MessageBox.Show("Na hay productos, añade algunos", "Error");
                }
            }
        }
        private void Descart(object sender, MouseButtonEventArgs e)
        {
            if (MessageBox.Show("¿Desea eliminar todos los productos ingresados a la factura actual", "Descartar productos", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                lim.Clear();
                TotalL.Content = "0";
                PPP.Children.Remove(content_);
                PPP.Children.Clear();
                content_.RowDefinitions.Clear();
                content_.Children.Clear();
                PPP.Children.Add(content_);
            }
        }
    }
}
