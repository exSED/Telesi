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
        private AllPaths ap = new AllPaths();
        List<Invoice> il = new List<Invoice>();
        private string[] dataInvoic, dataProInvo;
        private Grid content_ = new Grid(), product_;
        private Image icons;
        private Label text;

        public SearchList2(List<Invoice> s)
        {
            InitializeComponent();
            dataInvoic = File.ReadAllLines(ap.Invo_());
            dataProInvo = File.ReadAllLines(ap.ProdInvo_());
            il = s;
            NewGrids(s);
        }
        public void NewGrids(List<Invoice> invoices_)
        {
            if (invoices_ != null)
            {
                for (int i = 0; i < invoices_.Count; i++)
                {
                    int y = 0;
                    content_.RowDefinitions.Add(new RowDefinition() { Height = ColumnReference.Width });

                    product_ = new Grid { Name = "p" + i, Margin = MarginReference.Margin };
                    product_.ColumnDefinitions.Add(new ColumnDefinition() { Width = numRef.Width });
                    product_.ColumnDefinitions.Add(new ColumnDefinition() { Width = dateRef.Width });
                    product_.ColumnDefinitions.Add(new ColumnDefinition() { Width = totalRef.Width });
                    product_.ColumnDefinitions.Add(new ColumnDefinition() { Width = prRef.Width });
                    product_.ColumnDefinitions.Add(new ColumnDefinition() { Width = editIconRef.Width });

                    text = new Label { Content = invoices_[i].number_, Name = "num_" + i, VerticalAlignment = Alli.VerticalAlignment };
                    product_.Children.Add(text);
                    text.SetValue(Grid.ColumnProperty, 0);

                    text = new Label { Content = invoices_[i].date_, Name = "date_" + i, VerticalAlignment = Alli.VerticalAlignment };
                    product_.Children.Add(text);
                    text.SetValue(Grid.ColumnProperty, 1);

                    for (int ex = 0; ex < invoices_[i].Product.Count; ex++)
                    {
                        y += Int32.Parse(invoices_[i].Product[ex].price_);
                    }
                    text = new Label { Content = y, Name = "total_" + i, VerticalAlignment = Alli.VerticalAlignment };
                    product_.Children.Add(text);
                    text.SetValue(Grid.ColumnProperty, 2);

                    icons = new Image { Source = ImageRef.Source, Name = "Pro_" + i, VerticalAlignment = Alli.VerticalAlignment, HorizontalAlignment = Alli.HorizontalContentAlignment };
                    text = new Label { Content = invoices_[i].Product.Count(), Name = "xProd_" + i, HorizontalAlignment = Alli.HorizontalContentAlignment, VerticalAlignment = Alli.VerticalAlignment };
                    product_.Children.Add(text);
                    product_.Children.Add(icons);
                    text.SetValue(Grid.ColumnProperty, 3);
                    icons.SetValue(Grid.ColumnProperty, 3);

                    icons = new Image { Source = Ok.Source, Name = "View_" + i, Cursor = EditRef.Cursor, Margin = Ok.Margin };
                    icons.MouseDown += new MouseButtonEventHandler(i_view);
                    product_.Children.Add(icons);
                    icons.SetValue(Grid.ColumnProperty, 4);


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
            InvoicePreView2 s = new InvoicePreView2(il[oc]);
            s.Owner = s1.Owner;
            s.ShowDialog();
        }
    }
}
