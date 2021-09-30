﻿using System;
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
        private string[] dataInventor;
        private string value_;
        private NewLines nl = new NewLines();
        private Grid content_ = new Grid(), product_, more_, form_;
        private Image icons;
        private Label text;
        private TextBox id__, name__, count__, price__;

        public InvoiceList()
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

            NewGrids(ie.Invoices(ap.Invo_()));
        }
        public void NewGrids(List<Invoice> invoices_)
        {
            if (invoices_ != null)
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

                    text = new Label { Content = invoices_[i].number_, Name = "id_" + i, VerticalAlignment = Alli.VerticalAlignment };
                    product_.Children.Add(text);
                    text.SetValue(Grid.ColumnProperty, 0);

                    text = new Label { Content = invoices_[i].date_, Name = "name_" + i, VerticalAlignment = Alli.VerticalAlignment };
                    product_.Children.Add(text);
                    text.SetValue(Grid.ColumnProperty, 1);

                    text = new Label { Content = invoices_[i].total_, Name = "count_" + i, HorizontalAlignment = Alli.HorizontalAlignment, VerticalAlignment = Alli.VerticalAlignment };
                    product_.Children.Add(text);
                    text.SetValue(Grid.ColumnProperty, 2);

                    icons = new Image { Source = DelRef.Source, Name = "Delete_" + i, Cursor = EditRef.Cursor };
                    icons.MouseDown += new MouseButtonEventHandler(i_del);
                    product_.Children.Add(icons);
                    icons.SetValue(Grid.ColumnProperty, 5);

                    icons = new Image { Source = EditRef.Source, Name = "Edit_" + i, Cursor = EditRef.Cursor };
                    icons.MouseDown += new MouseButtonEventHandler(i_view);
                    product_.Children.Add(icons);
                    icons.SetValue(Grid.ColumnProperty, 4);

                    product_.Background = BlackReference.Background;
                    product_.SetValue(Grid.RowProperty, i);

                    content_.Children.Add(product_);
                }
                content_.RowDefinitions.Add(new RowDefinition() { Height = ColumnReference.Width });
                more_.SetValue(Grid.RowProperty, invoices_.Count);
                content_.Children.Add(more_);
            }
            else
            {
                content_.RowDefinitions.Add(new RowDefinition() { Height = ColumnReference.Width });
                more_.SetValue(Grid.RowProperty, 0);
                content_.Children.Add(more_);
            }
            InvoicesPanel.Children.Add(content_);
        }
        private void i_view(object sender, MouseButtonEventArgs e)
        {

        }
        private void i_del(object sender, MouseButtonEventArgs e)
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
            content_.Children.Remove(more_);
            content_.Children.Add(form_);
            form_.SetValue(Grid.RowProperty, dl.dataLength(ap.Inve_()));
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
                e.Handled = false;
            else
                e.Handled = true;
        }
    }
}