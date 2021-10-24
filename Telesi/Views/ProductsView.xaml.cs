using Paragraph = iText.Layout.Element.Paragraph;
using Image = iText.Layout.Element.Image;
using iText.IO.Image;
using iText.Kernel.Pdf.Canvas.Draw;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using Table = iText.Layout.Element.Table;
using iText.Layout.Borders;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Controls;
using System.Windows.Data;
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
        private bool relax;

        public ProductsView()
        {
            InitializeComponent();
            react_ = false;
            relax = false;
            ListaP = new InventoryList();
            list = null;
            list = ie.Inventario(ap.Inve_());
        }
        public UIElement ListaP
        {
            get { return Pp_.Child; }
            set { Pp_.Child = value; }
        }        
        private void ClickButtonNew(object sender, MouseButtonEventArgs e)
        {
            if (Tls.Visibility != Visibility.Hidden)
            {
                ListaP = new NInvoiceP();
                Tls.Visibility = Visibility.Hidden;
                react_ = true;
                relax = true;
            }
            else
            {
                if (relax == true)
                {
                    ListaP = new InventoryList();
                    Tls.Visibility = Visibility.Visible;
                }
                relax = false;
                react_ = false;
            }
        }
        private void ClickButtonSave(object sender, MouseButtonEventArgs e)
        {
            var sfd = new Microsoft.Win32.SaveFileDialog();
            sfd.FileName = "Inventario";
            sfd.DefaultExt = ".pdf";
            sfd.Filter = "TelesiDoc (.pdf)|*.pdf";

            Nullable<bool> result = sfd.ShowDialog();

            if (result == true)
            {
                string path = sfd.FileName;
                PdfWriter writer = new PdfWriter(path);
                PdfDocument pdf = new PdfDocument(writer);
                Document document = new Document(pdf);

                document.SetMargins(20 ,60, 60, 100);

                float[] pointColumnWidthsH = { 350F, 350F };
                Table head_ = new Table(pointColumnWidthsH);

                Paragraph header = new Paragraph("Fascinante")
                    .SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT)
                    .SetFontSize(12);

                Paragraph stre_ = new Paragraph("NIT: " +
                    "\nCentro comercial Mundo del oro -Bogota DC-" +
                    "\nCalle 9 No. 20A -10 Local 126" +
                    "\nContactanos en: 3208655745" +
                    "\n"+ DateTime.Today.Day + "-" + DateTime.Today.Month + "-" + DateTime.Today.Year)
                    .SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT)
                    .SetFontSize(6);

                Image img = new Image(ImageDataFactory
                    .Create(ap.Img1()))
                    .SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.RIGHT)
                    .SetWidth(120)
                    .SetHeight(62);

                float[] pointColumnWidthsHt = { 350F };
                Table headT_ = new Table(pointColumnWidthsHt);

                head_.AddCell(new Cell()
                  .SetBorder(iText.Layout.Borders.Border.NO_BORDER)
                  .SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT)
                  .Add(headT_));

                    headT_.AddCell(new Cell()
                      .SetBorder(iText.Layout.Borders.Border.NO_BORDER)
                      .SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT)
                      .Add(header));
                    headT_.AddCell(new Cell()
                      .SetBorder(iText.Layout.Borders.Border.NO_BORDER)
                      .SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT)
                      .Add(stre_));


                head_.AddCell(new Cell()
                   .SetBorder(iText.Layout.Borders.Border.NO_BORDER)
                   .SetVerticalAlignment(iText.Layout.Properties.VerticalAlignment.MIDDLE)
                   .SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.RIGHT)
                   .Add(img));

                LineSeparator ls = new LineSeparator(new SolidLine());

                Paragraph title_ = new Paragraph("\nInventario.\n\n")
                    .SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT)
                    .SetFontSize(20);

                float[] pointColumnWidths = { 100F, 300F, 75F, 150F };
                Table table = new Table(pointColumnWidths);

                table.AddCell(new Cell()
                       .SetBorderLeft(iText.Layout.Borders.Border.NO_BORDER)
                       .SetBorderRight(iText.Layout.Borders.Border.NO_BORDER)
                       .SetBorderTop(new SolidBorder(iText.Kernel.Colors.ColorConstants.BLACK, 3))
                       .SetBorder(new SolidBorder(iText.Kernel.Colors.ColorConstants.BLACK, 3))
                   .SetBackgroundColor(iText.Kernel.Colors.ColorConstants.ORANGE)
                   .SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT)
                   .Add(new Paragraph("Ref.")));
                table.AddCell(new Cell()
                       .SetBorderLeft(iText.Layout.Borders.Border.NO_BORDER)
                       .SetBorderRight(iText.Layout.Borders.Border.NO_BORDER)
                       .SetBorderTop(new SolidBorder(iText.Kernel.Colors.ColorConstants.BLACK, 3))
                       .SetBorder(new SolidBorder(iText.Kernel.Colors.ColorConstants.BLACK, 3))
                   .SetBackgroundColor(iText.Kernel.Colors.ColorConstants.ORANGE)
                   .SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT)
                   .Add(new Paragraph("Nombre")));
                table.AddCell(new Cell()
                       .SetBorderLeft(iText.Layout.Borders.Border.NO_BORDER)
                       .SetBorderRight(iText.Layout.Borders.Border.NO_BORDER)
                       .SetBorderTop(new SolidBorder(iText.Kernel.Colors.ColorConstants.BLACK, 3))
                       .SetBorder(new SolidBorder(iText.Kernel.Colors.ColorConstants.BLACK, 3))
                   .SetBackgroundColor(iText.Kernel.Colors.ColorConstants.ORANGE)
                   .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                   .Add(new Paragraph("Cantidad")));
                table.AddCell(new Cell()
                       .SetBorderLeft(iText.Layout.Borders.Border.NO_BORDER)
                       .SetBorderRight(iText.Layout.Borders.Border.NO_BORDER)
                       .SetBorderTop(new SolidBorder(iText.Kernel.Colors.ColorConstants.BLACK, 3))
                       .SetBorder(new SolidBorder(iText.Kernel.Colors.ColorConstants.BLACK, 3))
                   .SetBackgroundColor(iText.Kernel.Colors.ColorConstants.ORANGE)
                   .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                   .Add(new Paragraph("Precio($)")));

                for (int i=0; i<list.Count;i++)
                {
                    table.AddCell(new Cell()
                       .SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT)
                       .SetBorderLeft(iText.Layout.Borders.Border.NO_BORDER)
                       .SetBorderRight(iText.Layout.Borders.Border.NO_BORDER)
                       .SetBorderTop(iText.Layout.Borders.Border.NO_BORDER)
                       .SetBorder(new SolidBorder(iText.Kernel.Colors.ColorConstants.BLACK, 1))
                       .Add(new Paragraph(list[i].id_)));
                    table.AddCell(new Cell()
                       .SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT)
                       .SetBorderLeft(iText.Layout.Borders.Border.NO_BORDER)
                       .SetBorderRight(iText.Layout.Borders.Border.NO_BORDER)
                       .SetBorderTop(iText.Layout.Borders.Border.NO_BORDER)
                       .SetBorder(new SolidBorder(iText.Kernel.Colors.ColorConstants.BLACK, 1))
                       .Add(new Paragraph(list[i].name_)));
                    table.AddCell(new Cell()
                       .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                       .SetBorderLeft(iText.Layout.Borders.Border.NO_BORDER)
                       .SetBorderRight(iText.Layout.Borders.Border.NO_BORDER)
                       .SetBorderTop(iText.Layout.Borders.Border.NO_BORDER)
                       .SetBorder(new SolidBorder(iText.Kernel.Colors.ColorConstants.BLACK, 1))
                       .Add(new Paragraph(list[i].count_)));
                    table.AddCell(new Cell()
                       .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                       .SetBorderLeft(iText.Layout.Borders.Border.NO_BORDER)
                       .SetBorderRight(iText.Layout.Borders.Border.NO_BORDER)
                       .SetBorderTop(iText.Layout.Borders.Border.NO_BORDER)
                       .SetBorder(new SolidBorder(iText.Kernel.Colors.ColorConstants.BLACK, 1))
                       .Add(new Paragraph("$"+list[i].price_)));
                }
                table.AddCell(new Cell()
                   .SetBorder(iText.Layout.Borders.Border.NO_BORDER)
                   .Add(new Paragraph("")));
                table.AddCell(new Cell()
                   .SetBackgroundColor(iText.Kernel.Colors.ColorConstants.YELLOW)
                   .SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT)
                   .SetBorderLeft(iText.Layout.Borders.Border.NO_BORDER)
                   .SetBorderRight(iText.Layout.Borders.Border.NO_BORDER)
                   .SetBorderTop(iText.Layout.Borders.Border.NO_BORDER)
                   .SetBorder(new SolidBorder(iText.Kernel.Colors.ColorConstants.BLACK, 1))
                   .Add(new Paragraph("Totales:")));

                int y = 0;

                for(int i = 0; i < list.Count; i++)
                {
                    y += Int32.Parse( list[i].count_);
                }
                table.AddCell(new Cell()
                   .SetBackgroundColor(iText.Kernel.Colors.ColorConstants.YELLOW)
                   .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                   .SetBorderLeft(iText.Layout.Borders.Border.NO_BORDER)
                   .SetBorderRight(iText.Layout.Borders.Border.NO_BORDER)
                   .SetBorderTop(iText.Layout.Borders.Border.NO_BORDER)
                   .SetBorder(new SolidBorder(iText.Kernel.Colors.ColorConstants.BLACK, 1))
                   .Add(new Paragraph(y+"")));
                int yx = 0;

                for (int i = 0; i < list.Count; i++)
                {
                    yx += Int32.Parse(list[i].price_);
                }
                table.AddCell(new Cell()
                   .SetBackgroundColor(iText.Kernel.Colors.ColorConstants.YELLOW)
                   .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                   .SetBorderLeft(iText.Layout.Borders.Border.NO_BORDER)
                   .SetBorderRight(iText.Layout.Borders.Border.NO_BORDER)
                   .SetBorderTop(iText.Layout.Borders.Border.NO_BORDER)
                   .SetBorder(new SolidBorder(iText.Kernel.Colors.ColorConstants.BLACK, 1))
                   .Add(new Paragraph("$"+ yx)));

                document.Add(head_);
                document.Add(ls);
                document.Add(title_);
                document.Add(table);


                document.Close();
            }
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
                ListaP = new InventoryList();
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
                ListaP = new SearchList(s);
                react_ = true;
            } else 
            {
                if (react_==true)
                {
                    ListaP = new InventoryList();
                }
                react_ = false;
            }
        }
    }
}