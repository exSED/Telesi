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
using Telesi.Views;

namespace Telesi.Types
{
    /// <summary>
    /// Lógica de interacción para NewInvoice.xaml
    /// </summary>
    public partial class NewInvoice : Window
    {
        public UIElement views
        {
            get { return Rec.Child; }
            set { Rec.Child = value; }
        }
        public NewInvoice()
        {
            InitializeComponent();
        }
    }
}
