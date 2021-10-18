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
    /// Lógica de interacción para InventoryList.xaml
    /// </summary>
    public partial class InventoryList : UserControl
    {
        private InveExtractor ie = new InveExtractor();
        private DataLength dl = new DataLength();
        private AllPaths ap = new AllPaths();
        private OneLine ol = new OneLine();
        private string[] dataInventor;
        private string value_;
        private int oc;
        private NewLines nl = new NewLines();
        private Grid content_ = new Grid(), product_, more_, form_, ed;
        private Image icons, acc;
        private Label text;
        private TextBox id__, name__, count__, price__;
        private TextBox id_E, name_E, count_E, price_E;

        public InventoryList()
        {
            InitializeComponent();
            dataInventor = File.ReadAllLines(ap.Inve_());

            form_ = new Grid { Margin = MarginReference.Margin };
            form_.ColumnDefinitions.Add(new ColumnDefinition() { Width = idRef.Width });
            form_.ColumnDefinitions.Add(new ColumnDefinition() { Width = nameRef.Width });
            form_.ColumnDefinitions.Add(new ColumnDefinition() { Width = countRef.Width });
            form_.ColumnDefinitions.Add(new ColumnDefinition() { Width = priceRef.Width });
            form_.ColumnDefinitions.Add(new ColumnDefinition() { Width = editIconRef.Width });
            form_.ColumnDefinitions.Add(new ColumnDefinition() { Width = delIconRef.Width });

            id__ = new TextBox { Text = "Ref", Name = "Ref", Margin = TBoxRef.Margin, Background = TBoxRef.Background };
            id__.GotFocus += new RoutedEventHandler(TBoxF);
            id__.LostFocus += new RoutedEventHandler(TBoxLF);
            id__.KeyDown += new KeyEventHandler(NumberLim);
            form_.Children.Add(id__);
            id__.SetValue(Grid.ColumnProperty, 0);

            name__ = new TextBox { Text = "Nombre", Name = "Nombre", Margin = TBoxRef.Margin, Background = TBoxRef.Background };
            name__.GotFocus += new RoutedEventHandler(TBoxF);
            name__.LostFocus += new RoutedEventHandler(TBoxLF);
            form_.Children.Add(name__);
            name__.SetValue(Grid.ColumnProperty, 1);

            count__ = new TextBox { Text = "Cantidad", Name = "Cantidad", Margin = TBoxRef.Margin, Background = TBoxRef.Background };
            count__.GotFocus += new RoutedEventHandler(TBoxF);
            count__.LostFocus += new RoutedEventHandler(TBoxLF);
            count__.KeyDown += new KeyEventHandler(NumberLim);
            form_.Children.Add(count__);
            count__.SetValue(Grid.ColumnProperty, 2);

            price__ = new TextBox { Text = "Precio", Name = "Precio", Margin = TBoxRef.Margin, Background = TBoxRef.Background };
            price__.GotFocus += new RoutedEventHandler(TBoxF);
            price__.LostFocus += new RoutedEventHandler(TBoxLF);
            price__.KeyDown += new KeyEventHandler(NumberLim);
            form_.Children.Add(price__);
            price__.SetValue(Grid.ColumnProperty, 3);

            icons = new Image { Source = MoreRef.Source, Name = "IM", Cursor = EditRef.Cursor };

            icons.MouseDown += new MouseButtonEventHandler(accept);
            icons.KeyDown += new KeyEventHandler(KD2);
            form_.Children.Add(icons);
            icons.SetValue(Grid.ColumnProperty, 4);

            icons = new Image { Source = DelRef.Source, Name = "IC", Cursor = EditRef.Cursor };
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

            ed = new Grid { Margin = MarginReference.Margin };
            ed.ColumnDefinitions.Add(new ColumnDefinition() { Width = idRef.Width });
            ed.ColumnDefinitions.Add(new ColumnDefinition() { Width = nameRef.Width });
            ed.ColumnDefinitions.Add(new ColumnDefinition() { Width = countRef.Width });
            ed.ColumnDefinitions.Add(new ColumnDefinition() { Width = priceRef.Width });
            ed.ColumnDefinitions.Add(new ColumnDefinition() { Width = editIconRef.Width });
            ed.ColumnDefinitions.Add(new ColumnDefinition() { Width = delIconRef.Width });

            ed.KeyDown += new KeyEventHandler(KD);

            id_E = new TextBox { Text = "Ref", Name = "Ref", Margin = TBoxRef.Margin, Background = TBoxRef.Background };
            id_E.GotFocus += new RoutedEventHandler(TBoxF);
            id_E.LostFocus += new RoutedEventHandler(TBoxLF);
            id_E.KeyDown += new KeyEventHandler(NumberLim);
            ed.Children.Add(id_E);
            id_E.SetValue(Grid.ColumnProperty, 0);

            name_E = new TextBox { Text = "Nombre", Name = "Nombre", Margin = TBoxRef.Margin, Background = TBoxRef.Background };
            name_E.GotFocus += new RoutedEventHandler(TBoxF);
            name_E.LostFocus += new RoutedEventHandler(TBoxLF);
            ed.Children.Add(name_E);
            name_E.SetValue(Grid.ColumnProperty, 1);

            count_E = new TextBox { Text = "Cantidad", Name = "Cantidad", Margin = TBoxRef.Margin, Background = TBoxRef.Background };
            count_E.GotFocus += new RoutedEventHandler(TBoxF);
            count_E.LostFocus += new RoutedEventHandler(TBoxLF);
            count_E.KeyDown += new KeyEventHandler(NumberLim);
            ed.Children.Add(count_E);
            count_E.SetValue(Grid.ColumnProperty, 2);

            price_E = new TextBox { Text = "Precio", Name = "Precio", Margin = TBoxRef.Margin, Background = TBoxRef.Background };
            price_E.GotFocus += new RoutedEventHandler(TBoxF);
            price_E.LostFocus += new RoutedEventHandler(TBoxLF);
            price_E.KeyDown += new KeyEventHandler(NumberLim);
            ed.Children.Add(price_E);
            price_E.SetValue(Grid.ColumnProperty, 3);

            acc = new Image { Source = MoreRef.Source, Name = "IM", Cursor = EditRef.Cursor };
            acc.MouseDown += new MouseButtonEventHandler(cam);
            acc.KeyDown += new KeyEventHandler(KD);
            ed.Children.Add(acc);
            acc.SetValue(Grid.ColumnProperty, 4);

            icons = new Image { Source = DelRef.Source, Name = "ICE", Cursor = EditRef.Cursor };
            icons.MouseDown += new MouseButtonEventHandler(cancel);
            ed.Children.Add(icons);
            icons.SetValue(Grid.ColumnProperty, 5);

            ed.Background = BRef.Background;

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
                    icons.SetValue(Grid.ColumnProperty, 5);

                    icons = new Image { Source = EditRef.Source, Name = "Edit_" + i, Cursor = EditRef.Cursor };
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
        private void p_edit(object sender, MouseButtonEventArgs e)
        {
            content_.Children.Remove(form_);
            content_.Children.Remove(more_);
            content_.Children.Remove(ed);
            content_.Children.Add(more_);
            var c = e.OriginalSource as FrameworkElement;
            string o = c.Name;
            o = o.Replace("Edit_", "");
            oc = Int32.Parse(o);
            string[] oo = dataInventor[oc].Split("\t");
            id_E.Text = oo[0];
            name_E.Text = oo[1];
            count_E.Text = oo[2];
            price_E.Text = oo[3];
            content_.Children.Add(ed);
            ed.SetValue(Grid.RowProperty, oc);
        }
        private void p_del(object sender, MouseButtonEventArgs e)
        {
            var c = e.OriginalSource as FrameworkElement;
            string o = c.Name;
            o = o.Replace("Delete_", "");
            int ocl = Int32.Parse(o);
            if (MessageBox.Show("¿Desea eliminar permanentemente el producto?", "Eliminar", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                nl.writer(ol.NewInv(ap.Inve_(), dataInventor[ocl]),
                            ap.Inve_());

                content_.RowDefinitions.Clear();
            }
        }
        private void moreProducts(object sender, MouseButtonEventArgs e)
        {
            content_.Children.Remove(ed);
            content_.Children.Remove(more_);
            content_.Children.Add(form_);
            form_.SetValue(Grid.RowProperty, dl.dataLength(ap.Inve_()));
        }
        private void cancel(object sender, MouseButtonEventArgs e)
        {
            content_.RowDefinitions.Clear();
        }
        private void accept(object sender, MouseButtonEventArgs e)
        {
            nl.writer(ol.oneLine(ap.Inve_()) +
                        id__.Text + "\t" +
                        name__.Text + "\t" +
                        count__.Text + "\t" +
                        price__.Text,
                        ap.Inve_());
            content_.RowDefinitions.Clear();
        }
        private void cam(object sender, MouseButtonEventArgs e)
        {
            string o = id_E.Text + "\t" +
                name_E.Text + "\t" +
                count_E.Text + "\t" +
                price_E.Text;
            nl.writer(ol.NewPro(ap.Inve_(), dataInventor[oc], o, (oc + 1)),
                      ap.Inve_());
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
        private void KD(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                cam(null, null);
            }
        }
        private void KD2(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter){
                accept(null, null);
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
