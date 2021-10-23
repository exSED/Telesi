using System;
using System.Collections.Generic;
using System.IO;
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
    /// Lógica de interacción para SearchList.xaml
    /// </summary>
    public partial class SearchList2 : UserControl
    {
        private InvoExtractor ie = new InvoExtractor();
        private DataLength dl = new DataLength();
        private AllPaths ap = new AllPaths();
        private OneLine ol = new OneLine();
        private List<Invoice> il = new List<Invoice>();
        private string[] dataInvoic;
        private string value_;
        private NewLines nl = new NewLines();
        private Grid content_ = new Grid(), product_;
        private Image icons;
        private Label text;

        public SearchList2()
        {
            InitializeComponent();
            dataInvoic = File.ReadAllLines(ap.Invo_());
            il = ie.Invoices(ap.Invo_(), ap.ProdInvo_());
            NewGrids(il);
        }
        public void NewGrids(List<Invoice> invoices_)
        {
            if (invoices_ != null)
            {
                for (int i = 0; i < il.Count; i++)
                {
                    int y = 0;
                    content_.RowDefinitions.Add(new RowDefinition() { Height = ColumnReference.Width });

                    product_ = new Grid { Name = "p" + i, Margin = MarginReference.Margin };
                    product_.ColumnDefinitions.Add(new ColumnDefinition() { Width = numRef.Width });
                    product_.ColumnDefinitions.Add(new ColumnDefinition() { Width = dateRef.Width });
                    product_.ColumnDefinitions.Add(new ColumnDefinition() { Width = totalRef.Width });
                    product_.ColumnDefinitions.Add(new ColumnDefinition() { Width = prRef.Width });
                    product_.ColumnDefinitions.Add(new ColumnDefinition() { Width = editIconRef.Width });
                    product_.ColumnDefinitions.Add(new ColumnDefinition() { Width = editIconRef.Width });

                    text = new Label { Content = invoices_[i].number_, Name = "num_" + i, VerticalAlignment = Alli.VerticalAlignment };
                    product_.Children.Add(text);
                    text.SetValue(Grid.ColumnProperty, 0);

                    text = new Label { Content = invoices_[i].date_, Name = "date_" + i, VerticalAlignment = Alli.VerticalAlignment };
                    product_.Children.Add(text);
                    text.SetValue(Grid.ColumnProperty, 1);

                    for (int ex = 0; ex < il[i].Product.Count; ex++)
                    {
                        y += Int32.Parse(il[i].Product[ex].price_);
                    }
                    text = new Label { Content = y, Name = "total_" + i, VerticalAlignment = Alli.VerticalAlignment };
                    product_.Children.Add(text);
                    text.SetValue(Grid.ColumnProperty, 2);

                    icons = new Image { Source = ImageRef.Source, Name = "Pro_" + i, VerticalAlignment = Alli.VerticalAlignment, HorizontalAlignment = Alli.HorizontalContentAlignment };
                    text = new Label { Content = il[i].Product.Count(), Name = "xProd_" + i, HorizontalAlignment = Alli.HorizontalContentAlignment, VerticalAlignment = Alli.VerticalAlignment };
                    product_.Children.Add(text);
                    product_.Children.Add(icons);
                    text.SetValue(Grid.ColumnProperty, 3);
                    icons.SetValue(Grid.ColumnProperty, 3);

                    icons = new Image { Source = DelRef.Source, Name = "Deletes_" + i, Cursor = EditRef.Cursor, Margin = ImageRef.Margin };
                    icons.MouseDown += new MouseButtonEventHandler(i_del);
                    product_.Children.Add(icons);
                    icons.SetValue(Grid.ColumnProperty, 4);

                    icons = new Image { Source = Ok.Source, Name = "View_" + i, Cursor = EditRef.Cursor, Margin = Ok.Margin };
                    icons.MouseDown += new MouseButtonEventHandler(i_view);
                    product_.Children.Add(icons);
                    icons.SetValue(Grid.ColumnProperty, 5);


                    product_.Background = BlackReference.Background;
                    product_.SetValue(Grid.RowProperty, i);

                    content_.Children.Add(product_);
                }
            }
            InvoicesPanel.Children.Add(content_);
        }
        private void i_view(object sender, MouseButtonEventArgs e)
        {
            var c = e.OriginalSource as FrameworkElement;
            string o = c.Name;
            o = o.Replace("View_", "");
            int oc = Int32.Parse(o);
            MainWindow s1 = new MainWindow();
            InvoicePreView s = new InvoicePreView(il[oc]);
            s.Owner = s1.Owner;
            s.ShowDialog();
        }
        private void i_del(object sender, MouseButtonEventArgs e)
        {
            var c = e.OriginalSource as FrameworkElement;
            string o = c.Name;
            o = o.Replace("Deletes_", "");
            int ocl = Int32.Parse(o);
            if (MessageBox.Show("¿Desea eliminar permanentemente la factura?", "Eliminar", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                nl.writer(ol.NewInv(ap.Invo_(), dataInvoic[ocl]),
                            ap.Invo_());

                content_.RowDefinitions.Clear();
            }
        }
        private void cancel(object sender, MouseButtonEventArgs e)
        {
            content_.RowDefinitions.Clear();
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
    }
}
