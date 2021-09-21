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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Telesi.Views
{
    /// <summary>
    /// Lógica de interacción para MainView.xaml
    /// </summary>
    public partial class MainView : UserControl
    {
        private GridLength SizeOriginal;
        public MainView()
        {
            InitializeComponent();
            SizeOriginal = MenuColumn.Width;
        }
        public UIElement view
        {
            get { return Panel.Child; }
            set { Panel.Child = value; }
        }
        private void FocusIconMenu(object sender, RoutedEventArgs e)
        {
            if (MenuIconColorReference.Visibility == Visibility.Visible)
            {
                MenuItemsGrid.Visibility = Visibility.Hidden;
                MenuColumn.Width = SizeOriginal;
                IconMenu.Background = TransparentReference.Background;
                WhiteReference.Visibility = Visibility.Hidden;
                MenuIconColorReference.Visibility = Visibility.Hidden;
            }
            else
            {
                MenuColumn.Width = Size_1_Reference.Width;
                MenuItemsGrid.Visibility = Visibility.Visible;
                WhiteReference.Visibility = Visibility.Visible;
                MenuIconColorReference.Visibility = Visibility.Visible;
                IconMenu.Background = MenuIconColorReference.Background;
                MenuItemsGrid.Background = MenuIconColorReference.Background;
            }
        }
        private void ClickInventory(object sender, MouseButtonEventArgs e)
        {
            TemeSelected3.Background = TransparentReference.Background;
            TemeSelected2.Background = GradientSelectedReference.Background;
            view = new ProductsView();
        }
        private void ClickInvoice(object sender, MouseButtonEventArgs e)
        {
            TemeSelected2.Background = TransparentReference.Background;
            TemeSelected3.Background = GradientSelectedReference.Background;
            view = new InvoicesView();
        }
        //----------------------------------------------------------------------------------------------------------------------------------
        private void InventoryButtonFocus(object sender, MouseEventArgs e)
        {
            InventoryItemsGrid.Background = GradientFocusReference.Background;
        }
        private void InventoryButtonLeaveFocus(object sender, MouseEventArgs e)
        {
            InventoryItemsGrid.Background = TransparentReference.Background;
        }
        private void InvoiceButtonFocus(object sender, MouseEventArgs e)
        {
            InvoiceItemsGrid.Background = GradientFocusReference.Background;
        }
        private void InvoiceButtonLeaveFocus(object sender, MouseEventArgs e)
        {
            InvoiceItemsGrid.Background = TransparentReference.Background;
        }
    }
}