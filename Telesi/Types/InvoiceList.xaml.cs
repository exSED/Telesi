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
    /// Lógica de interacción para InvoiceList.xaml
    /// </summary>
    public partial class InvoiceList : UserControl
    {
        private InvoExtractor ie = new InvoExtractor();
        private DataLength dl = new DataLength();
        private AllPaths ap = new AllPaths();
        private OneLine ol = new OneLine();
        private string[] dataInvoic;
        private string value_;
        private NewLines nl = new NewLines();
        private Grid content_ = new Grid(), product_;
        private Image icons;
        private Label text;

        public InvoiceList()
        {
            InitializeComponent();
            dataInvoic = File.ReadAllLines(ap.Invo_());
            NewGrids(ie.Invoices(ap.Invo_(), ap.ProdInvo_()));
        }
        public void NewGrids(List<Invoice> invoices_)
        {
            if (invoices_ != null)
            {
                for (int i = 0; i < dataInvoic.Length; i++)
                {
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

                    text = new Label { Content = invoices_[i].total_, Name = "total_" + i, VerticalAlignment = Alli.VerticalAlignment };
                    product_.Children.Add(text);
                    text.SetValue(Grid.ColumnProperty, 2);

                    icons = new Image { Source = DelRef.Source, Name = "Prodss_" + i, VerticalAlignment = Alli.VerticalAlignment };
                    text = new Label { Content = invoices_[i].Product.Count(), Name = "Prodsss_" + i, HorizontalAlignment = Alli.HorizontalContentAlignment ,VerticalAlignment = Alli.VerticalAlignment };
                    product_.Children.Add(text);
                    product_.Children.Add(icons);
                    text.SetValue(Grid.ColumnProperty, 3);
                    icons.SetValue(Grid.ColumnProperty, 3);

                    icons = new Image { Source = EditRef.Source, Name = "Deletes_" + i, Cursor = EditRef.Cursor, Margin = ImageRef.Margin };
                    icons.MouseDown += new MouseButtonEventHandler(i_del);
                    product_.Children.Add(icons);
                    icons.SetValue(Grid.ColumnProperty, 4);

                    icons = new Image { Source = EditRef.Source, Name = "View_" + i, Cursor = EditRef.Cursor, Margin = ImageRef.Margin };
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
            MainWindow s1 = new MainWindow();
            Window1 s = new Window1();
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
            if (e.Key >= Key.D0 && e.Key <= Key.D9 || e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9){
                e.Handled = false;
            }else{
                e.Handled = true;
            }
        }
    }
}