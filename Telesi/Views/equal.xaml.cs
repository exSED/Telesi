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
    /// Lógica de interacción para equal.xaml
    /// </summary>
    public partial class equal : UserControl
    {
        private InveExtractor ie = new InveExtractor();
        private List<Products> list = new List<Products>();
        private AllPaths ap = new AllPaths();
        private DataLength dl = new DataLength();
        private OneLine ol = new OneLine();
        private NewLines nl = new NewLines();
        private Grid content_ = new Grid(), product_, ed;
        private TextBox id_E, name_E, count_E, price_E;
        private Image icons, acc;
        private Label text;
        private string value_;
        private string[] dataInventor;
        private int oc;
        public equal()
        {
            InitializeComponent();

            dataInventor = File.ReadAllLines(ap.Inve_());

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
            ed.Children.Add(count_E);
            count_E.SetValue(Grid.ColumnProperty, 2);

            price_E = new TextBox { Text = "Precio", Name = "Precio", Margin = TBoxRef.Margin, Background = TBoxRef.Background };
            price_E.GotFocus += new RoutedEventHandler(TBoxF);
            price_E.LostFocus += new RoutedEventHandler(TBoxLF);
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

                    text = new Label { Content = inventory_[i].count_, Name = "count_" + i, HorizontalAlignment = Alli.HorizontalAlignment, VerticalAlignment = Alli.VerticalAlignment, FontSize = Alli.FontSize };
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
            }
            else
            {
                content_.Children.Add(product_);
            }
            PanelS.Children.Add(content_);
        }
        private void p_edit(object sender, MouseButtonEventArgs e)
        {
            content_.Children.Remove(ed);
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
        private void cancel(object sender, MouseButtonEventArgs e)
        {
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
    }
}
