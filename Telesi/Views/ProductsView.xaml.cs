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


namespace Telesi.Views
{
    /// <summary>
    /// Lógica de interacción para ProductsView.xaml
    /// </summary>
    public partial class ProductsView : UserControl{
        private InveExtractor ie = new InveExtractor();
        private DataLength dl = new DataLength();
        private AllPaths ap = new AllPaths();
        private OneLine ol = new OneLine();
        private int index_;
        private NewLines nl = new NewLines();
        private Grid content_ = new Grid(), product_, more_, form_;
        private Image icons;
        private Label text;
        private TextBox id__, name__, count__, price__;
        public ProductsView()
        {
            InitializeComponent();

            index_ = dl.dataLength(ap.Inve_());

            form_ = new Grid { Margin = MarginReference.Margin };
            form_.ColumnDefinitions.Add(new ColumnDefinition() { Width = idRef.Width });
            form_.ColumnDefinitions.Add(new ColumnDefinition() { Width = nameRef.Width });
            form_.ColumnDefinitions.Add(new ColumnDefinition() { Width = countRef.Width });
            form_.ColumnDefinitions.Add(new ColumnDefinition() { Width = priceRef.Width });
            form_.ColumnDefinitions.Add(new ColumnDefinition() { Width = editIconRef.Width });
            form_.ColumnDefinitions.Add(new ColumnDefinition() { Width = delIconRef.Width });

            id__ = new TextBox { Text = "Ref", Margin = TBoxRef.Margin, Background = TBoxRef.Background };
            form_.Children.Add(id__);
            id__.SetValue(Grid.ColumnProperty, 0);

            name__ = new TextBox { Text = "Nombre", Margin = TBoxRef.Margin, Background = TBoxRef.Background };
            form_.Children.Add(name__);
            name__.SetValue(Grid.ColumnProperty, 1);

            count__ = new TextBox { Text = "Cantidad", Margin = TBoxRef.Margin, Background = TBoxRef.Background };
            form_.Children.Add(count__);
            count__.SetValue(Grid.ColumnProperty, 2);

            price__ = new TextBox { Text = "Price", Margin = TBoxRef.Margin, Background = TBoxRef.Background };
            form_.Children.Add(price__);
            price__.SetValue(Grid.ColumnProperty, 3);

            icons = new Image { Source = MoreRef.Source, Name = "IconM", Cursor = EditRef.Cursor };
            icons.MouseDown += new MouseButtonEventHandler(moreP);
            form_.Children.Add(icons);
            icons.SetValue(Grid.ColumnProperty, 4);

            icons = new Image { Source = DelRef.Source, Name = "IconC", Cursor = EditRef.Cursor };
            icons.MouseDown += new MouseButtonEventHandler(cancel);
            form_.Children.Add(icons);
            icons.SetValue(Grid.ColumnProperty, 5);

            form_.Background = BlackReference.Background;

            more_ = new Grid { Margin = MarginReference.Margin };
            more_.ColumnDefinitions.Add(new ColumnDefinition() { Width = nameRef.Width });
            more_.ColumnDefinitions.Add(new ColumnDefinition() { Width = idRef.Width });
            more_.ColumnDefinitions.Add(new ColumnDefinition() { Width = nameRef.Width });
            icons = new Image { Source = MoreRef.Source, Cursor = EditRef.Cursor };
            icons.MouseDown += new MouseButtonEventHandler(moreProducts);
            more_.Children.Add(icons);
            icons.SetValue(Grid.ColumnProperty, 1);
            more_.Background = WhiteReference.Background;
            NewGrids(ie.Inventario(ap.Inve_()));
        }
        public void NewGrids(List<Products> inventory_)
        {
            if (inventory_ != null)
            {
                for (int i = 0; i < dl.dataLength(ap.Inve_()); i++)
                {
                    content_.RowDefinitions.Add(new RowDefinition() { Height = ColumnReference.Width });
                    product_ = new Grid { Name = "p" + i, Margin = MarginReference.Margin };
                    product_.ColumnDefinitions.Add(new ColumnDefinition() { Width = idRef.Width });
                    product_.ColumnDefinitions.Add(new ColumnDefinition() { Width = nameRef.Width });
                    product_.ColumnDefinitions.Add(new ColumnDefinition() { Width = countRef.Width });
                    product_.ColumnDefinitions.Add(new ColumnDefinition() { Width = priceRef.Width });
                    product_.ColumnDefinitions.Add(new ColumnDefinition() { Width = editIconRef.Width });
                    product_.ColumnDefinitions.Add(new ColumnDefinition() { Width = delIconRef.Width });

                    text = new Label { Content = inventory_[i].id_, Name = "l" + i+1, VerticalAlignment = Alli.VerticalAlignment };
                    product_.Children.Add(text);
                    text.SetValue(Grid.ColumnProperty, 0);

                    text = new Label { Content = inventory_[i].name_, Name = "l" + i+2, VerticalAlignment = Alli.VerticalAlignment };
                    product_.Children.Add(text);
                    text.SetValue(Grid.ColumnProperty, 1);

                    text = new Label { Content = inventory_[i].count_, Name = "l" + i+3, HorizontalAlignment = Alli.HorizontalAlignment, VerticalAlignment = Alli.VerticalAlignment };
                    product_.Children.Add(text);
                    text.SetValue(Grid.ColumnProperty, 2);

                    text = new Label { Content = inventory_[i].price_, Name = "l" + i+4, HorizontalAlignment = Alli.HorizontalAlignment, VerticalAlignment = Alli.VerticalAlignment };
                    product_.Children.Add(text);
                    text.SetValue(Grid.ColumnProperty, 3);

                    icons = new Image { Source = DelRef.Source, Name = "i" + i+5, Cursor = EditRef.Cursor };
                    icons.MouseDown += new MouseButtonEventHandler(p_del);
                    product_.Children.Add(icons);
                    icons.SetValue(Grid.ColumnProperty, 5);

                    icons = new Image { Source = EditRef.Source, Name = "i" + i+6, Cursor = EditRef.Cursor };
                    icons.MouseDown += new MouseButtonEventHandler(p_edit);
                    product_.Children.Add(icons);
                    icons.SetValue(Grid.ColumnProperty, 4);

                    product_.Background = BlackReference.Background;
                    product_.SetValue(Grid.RowProperty, i);
                    content_.Children.Add(product_);
                }
                content_.RowDefinitions.Add(new RowDefinition() { Height = ColumnReference.Width });
                more_.SetValue(Grid.RowProperty, inventory_.Count);
                content_.Children.Add(more_);
            }
            else
            {
                content_.RowDefinitions.Add(new RowDefinition() { Height = ColumnReference.Width });
                more_.SetValue(Grid.RowProperty, 0);
                content_.Children.Add(more_);
            }
            ProductsPanel.Children.Add(content_);
        }
        private void moreProducts(object sender, MouseButtonEventArgs e)
        {
            content_.Children.Remove(more_);
            content_.Children.Add(form_);
            form_.SetValue(Grid.RowProperty, ie.Inventario(ap.Inve_()).Count);
        }
        private void moreP(object sender, MouseButtonEventArgs e)
        {
            content_.Children.Remove(more_);
           
            product_ = new Grid { Name = "p" + index_, Margin = MarginReference.Margin };
            product_.ColumnDefinitions.Add(new ColumnDefinition() { Width = idRef.Width });
            product_.ColumnDefinitions.Add(new ColumnDefinition() { Width = nameRef.Width });
            product_.ColumnDefinitions.Add(new ColumnDefinition() { Width = countRef.Width });
            product_.ColumnDefinitions.Add(new ColumnDefinition() { Width = priceRef.Width });
            product_.ColumnDefinitions.Add(new ColumnDefinition() { Width = editIconRef.Width });
            product_.ColumnDefinitions.Add(new ColumnDefinition() { Width = delIconRef.Width });

            text = new Label { Content = id__.Text, Name = "l" + index_+1, VerticalAlignment = Alli.VerticalAlignment };
            product_.Children.Add(text);
            text.SetValue(Grid.ColumnProperty, 0);

            text = new Label { Content = name__.Text, Name = "l" + index_+2, VerticalAlignment = Alli.VerticalAlignment };
            product_.Children.Add(text);
            text.SetValue(Grid.ColumnProperty, 1);

            text = new Label { Content = count__.Text, Name = "l" + index_+3, HorizontalAlignment = Alli.HorizontalAlignment, VerticalAlignment = Alli.VerticalAlignment };
            product_.Children.Add(text);
            text.SetValue(Grid.ColumnProperty, 2);

            text = new Label { Content = price__.Text, Name = "l" + index_+4, HorizontalAlignment = Alli.HorizontalAlignment, VerticalAlignment = Alli.VerticalAlignment };
            product_.Children.Add(text);
            text.SetValue(Grid.ColumnProperty, 3);

            icons = new Image { Source = DelRef.Source, Name = "i" + index_+5, Cursor = EditRef.Cursor };
            icons.MouseDown += new MouseButtonEventHandler(p_del);
            product_.Children.Add(icons);
            icons.SetValue(Grid.ColumnProperty, 5);

            icons = new Image { Source = EditRef.Source, Name = "i" + index_+6, Cursor = EditRef.Cursor };
            icons.MouseDown += new MouseButtonEventHandler(p_edit);
            product_.Children.Add(icons);
            icons.SetValue(Grid.ColumnProperty, 4);

            product_.Background = BlackReference.Background;

            content_.Children.Remove(form_);
            content_.Children.Add(product_);
            product_.SetValue(Grid.RowProperty, index_);

            nl.writer(ol.oneLine(ap.Inve_()) +
            "0\tPrueba\t0\t0",
            ap.Inve_());
            index_++;
            content_.RowDefinitions.Add(new RowDefinition() { Height = ColumnReference.Width });
            content_.Children.Add(more_);
            more_.SetValue(Grid.RowProperty, ie.Inventario(ap.Inve_()).Count);
        }
        private void ClickButtonNew(object sender, MouseButtonEventArgs e)
        {

        }
        private void ClickButtonOpen(object sender, MouseButtonEventArgs e)
        {

        }
        private void ClickButtonSave(object sender, MouseButtonEventArgs e)
        {

        }
        private void p_edit(object sender, MouseButtonEventArgs e)
        {

        }
        private void p_del(object sender, MouseButtonEventArgs e)
        {

        }
        private void cancel(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
