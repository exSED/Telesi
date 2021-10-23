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
    /// Lógica de interacción para InvoicesView.xaml
    /// </summary>
    public partial class InvoicesView : UserControl
    {
        private string value_;
        private bool react_,relax_;
        private InvoExtractor ie = new InvoExtractor();
        private AllPaths ap = new AllPaths();
        private OneLine ol = new OneLine();
        private List<Invoice> list = new List<Invoice>();
        public InvoicesView()
        {
            InitializeComponent();
            ListaI = new InvoiceList();
            list = ie.Invoices(ap.Invo_(), ap.ProdInvo_());
        }
        public UIElement ListaI
        {
            get { return Pp.Child; }
            set { Pp.Child = value; }
        }
        private void ClickButtonNewA(object sender, MouseButtonEventArgs e)
        {
            if (Til.Visibility != Visibility.Hidden)
            {
                ListaI = new NInvoice();
                Til.Visibility = Visibility.Hidden;
                relax_ = true;
                react_ = true;
            }
            else
            {
                if (relax_ == true)
                {
                    ListaI = new InvoiceList();
                    Til.Visibility = Visibility.Visible;
                }
                relax_ = false;
                
            }
        }
        private void ClickButtonSaveA(object sender, MouseButtonEventArgs e)
        {

        }
        private void TBoxFA(object sender, RoutedEventArgs e)
        {
            var c = e.OriginalSource as FrameworkElement;
            value_ = c.Name;
            c.SetValue(TextBox.TextProperty, "");
        }
        private void TBoxLFA(object sender, RoutedEventArgs e)
        {
            var c = e.OriginalSource as FrameworkElement;
            c.SetValue(TextBox.TextProperty, value_);
        }
        private void UpdateListA(object sender, SizeChangedEventArgs e)
        {
            if (react_ == false)
            {
                ListaI = new InvoiceList();
            }
        }
        private void K(object sender, TextChangedEventArgs e)
        {
            List<Invoice> s = new List<Invoice>();
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].number_ == Buscar.Text)
                {
                    s.Add(list[i]);
                }
            }
            if (s.Count() != 0 && Buscar.Text != "")
            {
                ListaI = new SearchList2(s);
                react_ = true;
            }
            else
            {
                if (react_ == true)
                {

                    ListaI = new InvoiceList();
                    
                }
                react_ = false;
            }
        }
    }
}