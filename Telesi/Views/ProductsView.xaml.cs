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
        private string value_;
        private bool react_;
        private InveExtractor ie = new InveExtractor();
        private AllPaths ap = new AllPaths();
        private OneLine ol = new OneLine();
        private List<Products> list = new List<Products>();

        public ProductsView()
        {
            InitializeComponent();
            react_ = false;
            ListaP = new Lista();
            list = null;
            list = ie.Inventario(ap.Inve_());
        }
        public UIElement ListaP
        {
            get { return Pp.Child; }
            set { Pp.Child = value; }
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
        private void TBoxF(object sender, RoutedEventArgs e)
        {
            var c = e.OriginalSource as FrameworkElement;
            value_ = c.Name;
            c.SetValue( TextBox.TextProperty, "");
        }
        private void TBoxLF(object sender, RoutedEventArgs e)
        {
            var c = e.OriginalSource as FrameworkElement;
            c.SetValue(TextBox.TextProperty, value_);
        }
        private void UpdateList(object sender, SizeChangedEventArgs e)
        {
            if (react_ == false)
            {
                ListaP = new Lista();
            }
        }
        private void K(object sender, TextChangedEventArgs e)
        {
            List<Products> s = new List<Products>();
            for (int i = 0; i < list.Count(); i++)
            {
                if (list[i].id_ == Buscar.Text)
                {
                    s.Add(list[i]);
                }
            }
            if (s.Count() != 0 && Buscar.Text != "")
            {
                ListaP = new equal(s);
                react_ = true;
            } else
            {
                react_ = false;
            }
        }
    }
}