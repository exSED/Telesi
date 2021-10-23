using System;
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
using System.Windows.Shapes;

namespace Telesi.Types
{
    /// <summary>
    /// Lógica de interacción para InvoicePreView2.xaml
    /// </summary>
    public partial class InvoicePreView2 : Window
    {
        private Grid content_ = new Grid(), product_;
        private Image icons;
        private Label text;
        public InvoicePreView2(Invoice InvoiceList)
        {
            InitializeComponent();
            No_F.Content = InvoiceList.number_;
            Date_F.Content = InvoiceList.date_;
            int t = 0;
            for (int i = 0; i < InvoiceList.Product.Count; i++)
            {
                t += Int32.Parse(InvoiceList.Product[i].price_);
            }
            InvoTotal.Content = t.ToString();
            NewGrids(InvoiceList.Product);
        }
        public void NewGrids(List<Products> inventory_)
        {
            if (inventory_ != null)
            {
                for (int i = 0; i < inventory_.Count; i++)
                {
                    content_.RowDefinitions.Add(new RowDefinition() { Height = ColumnReference.Width });

                    product_ = new Grid { Name = "p" + i, Margin = MarginReference.Margin };
                    product_.ColumnDefinitions.Add(new ColumnDefinition() { Width = idRef.Width });
                    product_.ColumnDefinitions.Add(new ColumnDefinition() { Width = nameRef.Width });
                    product_.ColumnDefinitions.Add(new ColumnDefinition() { Width = countRef.Width });
                    product_.ColumnDefinitions.Add(new ColumnDefinition() { Width = priceRef.Width });

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

                    product_.Background = BlackReference.Background;
                    product_.SetValue(Grid.RowProperty, i);

                    content_.Children.Add(product_);
                }
            }
            Vew_.Children.Add(content_);
        }
    }
}
