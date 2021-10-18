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
    public partial class NInvoiceP : UserControl
    {
        private InvoExtractor ieo2 = new InvoExtractor();
        private InveExtractor iee2 = new InveExtractor();
        private DataLength dl2 = new DataLength();
        private AllPaths ap2 = new AllPaths();
        private OneLine ol2 = new OneLine();
        private NewLines nl2 = new NewLines();
        private List<Invoice> dataInvo2;
        private List<Products> dataInve2, lim2;
        private Grid content_2 = new Grid();
        private Label pin_2= new Label();
        private string value_2;
        private int f2 = 0;
        public NInvoiceP()
        {
            dataInvo2 = ieo2.Invoices(ap2.Invo_(), ap2.ProdInvo_());
            dataInve2 = iee2.Inventario(ap2.Inve_());
            lim2 = new List<Products>();
            InitializeComponent();
            DateL2.Content = DateTime.Today.Day+"-"+ DateTime.Today.Month + "-" + DateTime.Today.Year ;
        }
        private void TBoxF2(object sender, RoutedEventArgs e)
        {
            var c2 = e.OriginalSource as FrameworkElement;
            value_2 = c2.Name;
            c2.SetValue(TextBox.TextProperty, "");
        }
        private void TBoxLF2(object sender, RoutedEventArgs e)
        {
            var c2 = e.OriginalSource as FrameworkElement;
            if (c2.GetValue(TextBox.TextProperty).ToString() == "")
            {
                c2.SetValue(TextBox.TextProperty, value_2);
            }
        }
        private void NumberLim2(object sender, KeyEventArgs e)
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
        private void AddProds2(object sender, MouseButtonEventArgs e)
        {
            bool q2 = false;
            for (int j = 0; j < lim2.Count; j++)
            {
                if (lim2[j].id_ == Referencia2.Text)
                {
                    q2 = true;
                    break;
                }
            }
            if (q2 == false)
            {
                lim2.Add(new Products
                {
                    id_ = dataInve2[f2].id_,
                    name_ = dataInve2[f2].name_,
                    count_ = Cantidad2.Text,
                    price_ = dataInve2[f2].price_
                });
                TotalL2.Content = "0";
                PPP2.Children.Remove(content_2);
                PPP2.Children.Clear();
                content_2.RowDefinitions.Clear();
                content_2.Children.Clear();
                string d2;
                for (int i = 0; i < lim2.Count; i++)
                {
                    content_2.RowDefinitions.Add(new RowDefinition() { Height = ColumnReference2.Width });
                    d2 = lim2[i].id_ + "\t\t" + "\t\t" + Cantidad2.Text + "\t\t" + lim2[i].price_ + "\t\t\t" + lim2[i].name_ + "\r\n";
                    pin_2 = new Label { Content = d2, Name = "id_" + i };
                    pin_2.SetValue(Grid.RowProperty, i);
                    content_2.Children.Add(pin_2);
                    TotalL2.Content = "$" + (Int32.Parse(TotalL2.Content.ToString().Replace("$", "")) + Int32.Parse(lim2[i].price_));
                }
                PPP2.Children.Add(content_2);
                RetraRe.Visibility = Visibility.Visible;
            }
            else
            {
                MessageBox.Show(" Este articulo ya existe en la factura, porfavor verifique");
            }
        }
        private void NumInv2(object sender, TextChangedEventArgs e)
        {
            if (No_Factura2.Text == " ")
            {
                No_Factura2.Text = "";
            }
            if (No_Factura2.Text != String.Empty && No_Factura2.Text != "No_Factura")
            {
                for (int i = 0; i < dataInvo2.Count; i++)
                {
                    if (No_Factura2.Text == dataInvo2[i].number_)
                    {
                        Referencia2.Visibility = Visibility.Hidden;
                        Cantidad2.Visibility = Visibility.Hidden;
                        NewInvoOk2.Visibility = Visibility.Hidden;
                        lim2.Clear();
                        TotalL2.Content = "0";
                        PPP2.Children.Remove(content_2);
                        PPP2.Children.Clear();
                        content_2.RowDefinitions.Clear();
                        content_2.Children.Clear();
                        PPP2.Children.Add(content_2);
                        break;
                    }
                    else
                    {
                        Referencia2.Visibility = Visibility.Visible;
                    }
                }
            }
            else
            {
                if (Referencia2 != null)
                {
                    Referencia2.Visibility = Visibility.Hidden;
                    Cantidad2.Visibility = Visibility.Hidden;
                    NewInvoOk2.Visibility = Visibility.Hidden;
                    lim2.Clear();
                    TotalL2.Content = "0";
                    PPP2.Children.Remove(content_2);
                    PPP2.Children.Clear();
                    content_2.RowDefinitions.Clear();
                    content_2.Children.Clear();
                    PPP2.Children.Add(content_2);
                }
            }
        }
        private void RefProdT2(object sender, TextChangedEventArgs e)
        {
            if (Referencia2.Text == " ")
            {
                Referencia2.Text = "";
            }
            if (Referencia2.Text != String.Empty && Referencia2.Text != "Referencia")
            {
                for (int i = 0; i < dataInve2.Count; i++)
                {
                    if (Referencia2.Text == dataInve2[i].id_)
                    {
                        Cantidad2.Visibility = Visibility.Visible;
                        f2 = i;
                        RefCountT2(null, null);
                        break;
                    }
                    else
                    {
                        Cantidad2.Visibility = Visibility.Hidden;
                        NewInvoOk2.Visibility = Visibility.Hidden;
                    }
                }
            }
            else
            {
                if (Cantidad2 != null)
                {
                    Cantidad2.Visibility = Visibility.Hidden;
                    NewInvoOk2.Visibility = Visibility.Hidden;
                }
            }
        }
        private void RefCountT2(object sender, TextChangedEventArgs e)
        {
            if (Cantidad2.Text != String.Empty && Cantidad2.Text != "Cantidad")
            {

                if (Cantidad2.Text != "0")
                {
                    NewInvoOk2.Visibility = Visibility.Visible;
                }
                else
                {
                    NewInvoOk2.Visibility = Visibility.Hidden;
                }
            }
            else
            {
                if (NewInvoOk2 != null)
                {
                    NewInvoOk2.Visibility = Visibility.Hidden;
                }
            }
        }
        private void EresEnd2(object sender, MouseButtonEventArgs e)
        {
            if (lim2.Count == 0) {
                RetraRe.Visibility = Visibility.Hidden;
            }
            else
            {
                lim2.Remove(lim2.Last());
                TotalL2.Content = "0";
                PPP2.Children.Remove(content_2);
                PPP2.Children.Clear();
                content_2.RowDefinitions.Clear();
                content_2.Children.Clear();
                string d2;
                for (int i = 0; i < lim2.Count; i++)
                {
                    content_2.RowDefinitions.Add(new RowDefinition() { Height = ColumnReference2.Width });
                    d2 = lim2[i].id_ + "\t\t" + "\t\t" + Cantidad2.Text + "\t\t" + lim2[i].price_+ "\t\t\t" + lim2[i].name_ + "\r\n";
                    pin_2 = new Label { Content = d2, Name = "id_" + i };
                    pin_2.SetValue(Grid.RowProperty, i);
                    content_2.Children.Add(pin_2);
                    TotalL2.Content = "$" + (Int32.Parse(TotalL2.Content.ToString().Replace("$", "")) + Int32.Parse(lim2[i].price_));
                }
                PPP2.Children.Add(content_2);
                RetraRe.Visibility = Visibility.Visible;
            }
        }
        private void Acs2(object sender, MouseButtonEventArgs e)
        {
            if (No_Factura2.Text != "" && No_Factura2.Text != "No_Factura")
            {
                if (lim2.Count!=0)
                {
                    for (int i = 0; i < dataInve2.Count; i++)
                    {
                        for (int j = 0; j < lim2.Count; j++)
                        {
                            if (lim2[j].id_ == dataInve2[i].id_)
                            {
                                dataInve2[i].count_ = (Int32.Parse(dataInve2[i].count_) + Int32.Parse(lim2[j].count_)).ToString();
                            }
                        }
                    }
                    string dr2 = No_Factura2.Text + "\t" + DateL2.Content.ToString() + "\t" + "1";
                    nl2.writer(ol2.oneLine(ap2.Invo_()) + dr2, ap2.Invo_());
                    nl2.writer(ol2.oneLine(ap2.ProdInvo_()) + ol2.newPorsIvo_(lim2), ap2.ProdInvo_());
                    nl2.writer(ol2.newInven_(dataInve2), ap2.Inve_());
                    lim2.Clear();
                    TotalL2.Content = "0";
                    PPP2.Children.Remove(content_2);
                    PPP2.Children.Clear();
                    content_2.RowDefinitions.Clear();
                    content_2.Children.Clear();
                    PPP2.Children.Add(content_2);
                    No_Factura2.Text = "";
                    Referencia2.Text = "";
                }
                else
                {
                    MessageBox.Show("Na hay productos, añade algunos","Error");
                }
            }
        }
        private void Descart2(object sender, MouseButtonEventArgs e)
        {
            if (MessageBox.Show("¿Desea eliminar todos los productos ingresados a la factura actual", "Descartar productos", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                lim2.Clear();
                TotalL2.Content = "0";
                PPP2.Children.Remove(content_2);
                PPP2.Children.Clear();
                content_2.RowDefinitions.Clear();
                content_2.Children.Clear();
                PPP2.Children.Add(content_2);
            }
        }
    }
}