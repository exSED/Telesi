using Paragraph = iText.Layout.Element.Paragraph;
using ImageT = iText.Layout.Element.Image;
using Image = System.Windows.Controls.Image;
using iText.IO.Image;
using iText.Kernel.Pdf.Canvas.Draw;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using Table = iText.Layout.Element.Table;
using iText.Layout.Borders;
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
using System.Windows.Shapes;
using Telesi.Types;
using Telesi.Helpers;

namespace Telesi.Types
{
    /// <summary>
    /// Lógica de interacción para InvoicePreView.xaml
    /// </summary>
    public partial class InvoicePreView : Window
    {
        private Grid content_ = new Grid(), product_;
        private AllPaths ap = new AllPaths();
        private Invoice list = new Invoice();
        private Image icons;
        private Label text;
        public InvoicePreView(Invoice InvoiceList)
        {
            InitializeComponent();
            list = InvoiceList;
            No_F.Content = InvoiceList.number_;
            Date_F.Content = InvoiceList.date_;
            int t=0;
            for (int i=0;i<InvoiceList.Product.Count;i++)
            {
                t += Int32.Parse(InvoiceList.Product[i].price_);
            }
            InvoTotal.Content = "Total:\t$" + t;
            NewGrids(InvoiceList.Product);
        }
        public void NewGrids(List<Products> inventory_)
        {
            if (inventory_ != null)
            {
                for (int i = 0; i < inventory_.Count; i++)
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

                    product_.Background = BlackReference.Background;
                    product_.SetValue(Grid.RowProperty, i);

                    content_.Children.Add(product_);
                }
            }
            Vew_.Children.Add(content_);
        }
        private void SevaPDDI_(object sender, MouseButtonEventArgs e)
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

                document.SetMargins(20, 60, 60, 100);

                float[] pointColumnWidthsH = { 350F, 350F };
                Table head_ = new Table(pointColumnWidthsH);

                Paragraph header = new Paragraph("Fascinante")
                    .SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT)
                    .SetFontSize(12);

                Paragraph stre_ = new Paragraph("NIT: " +
                    "\nCentro comercial Mundo del oro -Bogota DC-" +
                    "\nCalle 9 No. 20A -10 Local 126" +
                    "\nContactanos en: 3208655745" +
                    "\n" + DateTime.Today.Day + "-" + DateTime.Today.Month + "-" + DateTime.Today.Year)
                    .SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT)
                    .SetFontSize(6);

                ImageT img = new ImageT(ImageDataFactory
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

                Paragraph printLn = new Paragraph("\n")
                    .SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT)
                    .SetFontSize(20);

                float[] pointColumnWidthsDP = { 620F };
                Table dataPri_ = new Table(pointColumnWidthsDP);

                dataPri_.AddCell(new Cell()
                       .SetBorderLeft(iText.Layout.Borders.Border.NO_BORDER)
                       .SetBorderRight(iText.Layout.Borders.Border.NO_BORDER)
                       .SetBorderTop(new SolidBorder(iText.Kernel.Colors.ColorConstants.BLACK, 3))
                       .SetBorder(new SolidBorder(iText.Kernel.Colors.ColorConstants.BLACK, 3))
                   .SetBackgroundColor(iText.Kernel.Colors.ColorConstants.ORANGE)
                   .SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT)
                   .Add(new Paragraph("Factura No.:\t" + list.number_)
                   .SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT)
                    .SetFontSize(15)));

                int yx = 0;

                for (int i = 0; i < list.Product.Count; i++)
                {
                    yx += Int32.Parse(list.Product[i].price_);
                }

                dataPri_.AddCell(new Cell()
                       .SetBorderLeft(iText.Layout.Borders.Border.NO_BORDER)
                       .SetBorderRight(iText.Layout.Borders.Border.NO_BORDER)
                       .SetBorderTop(iText.Layout.Borders.Border.NO_BORDER)
                       .SetBorder(new SolidBorder(iText.Kernel.Colors.ColorConstants.BLACK, 3))
                   .SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT)
                   .Add(new Paragraph("Fecha de la factura:\t\t\t" + list.date_ +
                    "\nTotal de productos:\t\t\t" + list.Product.Count+
                    "\nPrecio total de la factura: \t\t $" + yx)
                    .SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT)
                    .SetFontSize(8)));

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

                for (int i = 0; i < list.Product.Count; i++)
                {
                    table.AddCell(new Cell()
                       .SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT)
                       .SetBorderLeft(iText.Layout.Borders.Border.NO_BORDER)
                       .SetBorderRight(iText.Layout.Borders.Border.NO_BORDER)
                       .SetBorderTop(iText.Layout.Borders.Border.NO_BORDER)
                       .SetBorder(new SolidBorder(iText.Kernel.Colors.ColorConstants.BLACK, 1))
                       .Add(new Paragraph(list.Product[i].id_)));
                    table.AddCell(new Cell()
                       .SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT)
                       .SetBorderLeft(iText.Layout.Borders.Border.NO_BORDER)
                       .SetBorderRight(iText.Layout.Borders.Border.NO_BORDER)
                       .SetBorderTop(iText.Layout.Borders.Border.NO_BORDER)
                       .SetBorder(new SolidBorder(iText.Kernel.Colors.ColorConstants.BLACK, 1))
                       .Add(new Paragraph(list.Product[i].name_)));
                    table.AddCell(new Cell()
                       .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                       .SetBorderLeft(iText.Layout.Borders.Border.NO_BORDER)
                       .SetBorderRight(iText.Layout.Borders.Border.NO_BORDER)
                       .SetBorderTop(iText.Layout.Borders.Border.NO_BORDER)
                       .SetBorder(new SolidBorder(iText.Kernel.Colors.ColorConstants.BLACK, 1))
                       .Add(new Paragraph(list.Product[i].count_)));
                    table.AddCell(new Cell()
                       .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                       .SetBorderLeft(iText.Layout.Borders.Border.NO_BORDER)
                       .SetBorderRight(iText.Layout.Borders.Border.NO_BORDER)
                       .SetBorderTop(iText.Layout.Borders.Border.NO_BORDER)
                       .SetBorder(new SolidBorder(iText.Kernel.Colors.ColorConstants.BLACK, 1))
                       .Add(new Paragraph("$" + list.Product[i].price_)));
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

                for (int i = 0; i < list.Product.Count; i++)
                {
                    y += Int32.Parse(list.Product[i].count_);
                }
                table.AddCell(new Cell()
                   .SetBackgroundColor(iText.Kernel.Colors.ColorConstants.YELLOW)
                   .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                   .SetBorderLeft(iText.Layout.Borders.Border.NO_BORDER)
                   .SetBorderRight(iText.Layout.Borders.Border.NO_BORDER)
                   .SetBorderTop(iText.Layout.Borders.Border.NO_BORDER)
                   .SetBorder(new SolidBorder(iText.Kernel.Colors.ColorConstants.BLACK, 1))
                   .Add(new Paragraph(y + "")));

                table.AddCell(new Cell()
                   .SetBackgroundColor(iText.Kernel.Colors.ColorConstants.YELLOW)
                   .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                   .SetBorderLeft(iText.Layout.Borders.Border.NO_BORDER)
                   .SetBorderRight(iText.Layout.Borders.Border.NO_BORDER)
                   .SetBorderTop(iText.Layout.Borders.Border.NO_BORDER)
                   .SetBorder(new SolidBorder(iText.Kernel.Colors.ColorConstants.BLACK, 1))
                   .Add(new Paragraph("$" + yx)));

                document.Add(head_);
                document.Add(ls);
                document.Add(printLn);
                document.Add(dataPri_);
                document.Add(printLn);
                document.Add(table);


                document.Close();
            }
        }
        private void p_del(object sender, MouseButtonEventArgs e)
        {
            
        }
    }
}
