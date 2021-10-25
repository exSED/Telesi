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

namespace Telesi
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public UIElement views
        {
            get { return mainContainer.Child; }
            set { mainContainer.Child = value; }
        }
        public MainWindow()
        {
            InitializeComponent();
            views = new MainView();
        }
        private void R(object sender, System.ComponentModel.CancelEventArgs e)
        {
            
        }
    }
}
