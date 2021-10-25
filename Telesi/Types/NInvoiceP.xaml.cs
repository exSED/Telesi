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
        private InvoExtractor ieo = new InvoExtractor();
        private InveExtractor iee = new InveExtractor();
        private DataLength dl = new DataLength();
        private AllPaths ap = new AllPaths();
        private OneLine ol = new OneLine();
        private NewLines nl = new NewLines();
        private List<Products> dataInventor = new List<Products>();
        private Grid content_ = new Grid(), product_;
        private Image icons;
        private Label text;
        private List<Invoice> dataInvo;
        private List<Products> dataInve, lim;
        private Label pin_ = new Label();
        private string value_;
        private int f = 0;
        public NInvoiceP()
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
                    price_ = (Int32.Parse(dataInve[f].price_) * Int32.Parse(Cantidad.Text)).ToString()
                });
                TotalL.Content = "0";
                PPP.Children.Remove(content_);
                PPP.Children.Clear();
                content_.RowDefinitions.Clear();
                content_.Children.Clear();
                NewGrids(lim);
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
                        NewInvoOk.Visibility = Visibility.Hidden;
                    }
                }
            }
            else
            {
                if (Cantidad != null)
                {
                    Cantidad.Visibility = Visibility.Hidden;
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
                    NewInvoOk.Visibility = Visibility.Visible;
                }
                else
                {

                    NewInvoOk.Visibility = Visibility.Hidden;
                }
            }
            else
            {
                if (NewInvoOk != null)
                {
                    NewInvoOk.Visibility = Visibility.Hidden;
                }
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
                                dataInve[i].count_ = (Int32.Parse(dataInve[i].count_) + Int32.Parse(lim[j].count_)).ToString();
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
        public void NewGrids(List<Products> inventory_)
        {
            PPP.Children.Remove(content_);
            if (inventory_ != null)
            {
                for (int i = 0; i < inventory_.Count; i++)
                {
                    content_.RowDefinitions.Add(new RowDefinition() { Height = ColumnReferencee.Width });

                    product_ = new Grid { Name = "p" + i, Margin = MarginReference.Margin };
                    product_.ColumnDefinitions.Add(new ColumnDefinition() { Width = idRef.Width });
                    product_.ColumnDefinitions.Add(new ColumnDefinition() { Width = nameRef.Width });
                    product_.ColumnDefinitions.Add(new ColumnDefinition() { Width = countRef.Width });
                    product_.ColumnDefinitions.Add(new ColumnDefinition() { Width = priceRef.Width });
                    product_.ColumnDefinitions.Add(new ColumnDefinition() { Width = delIconRef.Width });

                    text = new Label { Content = inventory_[i].id_, Name = "id_" + i, VerticalAlignment = Alli.VerticalAlignment };
                    product_.Children.Add(text);
                    text.SetValue(Grid.ColumnProperty, 0);

                    text = new Label { Content = inventory_[i].name_, Name = "name_" + i, VerticalAlignment = Alli.VerticalAlignment };
                    product_.Children.Add(text);
                    text.SetValue(Grid.ColumnProperty, 1);

                    text = new Label { Content = inventory_[i].count_, Name = "count_" + i, HorizontalAlignment = Alli.HorizontalAlignment, VerticalAlignment = Alli.VerticalAlignment };
                    product_.Children.Add(text);
                    text.SetValue(Grid.ColumnProperty, 2);

                    text = new Label { Content = inventory_[i].price_, Name = "price_" + i, HorizontalAlignment = Alli.HorizontalAlignment, VerticalAlignment = Alli.VerticalAlignment };
                    product_.Children.Add(text);
                    text.SetValue(Grid.ColumnProperty, 3);

                    icons = new Image { Source = DelRef.Source, Name = "Delete_" + i, Cursor = EditRef.Cursor };
                    icons.MouseDown += new MouseButtonEventHandler(p_del);
                    product_.Children.Add(icons);
                    icons.SetValue(Grid.ColumnProperty, 4);

                    product_.Background = BlackReference.Background;
                    product_.SetValue(Grid.RowProperty, i);

                    content_.Children.Add(product_);
                }
            }
            PPP.Children.Add(content_);
        }
        private void p_del(object sender, MouseButtonEventArgs e)
        {
            var c = e.OriginalSource as FrameworkElement;
            string o = c.Name;
            o = o.Replace("Delete_", "");
            int ocl = Int32.Parse(o);
            if (MessageBox.Show("¿Desea eliminar permanentemente el producto?", "Eliminar", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                lim.RemoveAt(ocl);
                PPP.Children.Remove(content_);
                PPP.Children.Clear();
                content_.RowDefinitions.Clear();
                content_.Children.Clear();
                NewGrids(lim);
            }
        }
    }
}