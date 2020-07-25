using Syncfusion.Pdf;
using Syncfusion.Pdf.Grid;
using Syncfusion.Drawing;
using Syncfusion.Pdf.Graphics;
using System.IO;
using Microsoft.JSInterop;
using System.Collections.Generic;
using System.Linq;
using VMSM.Contracts.Requests;
using System.Data;
using VMSM.Contracts.Entities;
using Microsoft.EntityFrameworkCore.Internal;

namespace VMSM.Client.PdfExport
{
    public class PdfExportService<T> : IPdfExportService<T>
    {
        private readonly IJSRuntime _jsRuntime;

        public PdfExportService(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public void ExportToPdf(List<T> entities, string reportTitle, ReportRequest reportRequest, List<string> columns)
        {
            int paragraphAfterSpacing = 8;
            int cellMargin = 8;
            PdfDocument pdfDocument = new PdfDocument();
            //Add Page to the PDF document.
            PdfPage page = pdfDocument.Pages.Add();

            //Create a new font.
            PdfStandardFont font = new PdfStandardFont(PdfFontFamily.TimesRoman, 16);

            //Create a text element to draw a text in PDF page.
            PdfTextElement title = new PdfTextElement(reportTitle, font, PdfBrushes.Black);
            PdfLayoutResult result = title.Draw(page, new PointF(0, 0));

            var contentInfo = CreateContentInfo(reportRequest, entities);

            PdfStandardFont contentFont = new PdfStandardFont(PdfFontFamily.TimesRoman, 12);
            PdfTextElement content = new PdfTextElement(contentInfo, contentFont, PdfBrushes.Black);
            PdfLayoutFormat format = new PdfLayoutFormat();
            format.Layout = PdfLayoutType.Paginate;

            //Draw a text to the PDF document.
            result = content.Draw(page, new RectangleF(0, result.Bounds.Bottom + paragraphAfterSpacing, page.GetClientSize().Width, page.GetClientSize().Height), format);

            //Create a PdfGrid.
            PdfGrid pdfGrid = new PdfGrid();
            pdfGrid.Style.CellPadding.Left = cellMargin;
            pdfGrid.Style.CellPadding.Right = cellMargin;

            //Applying built-in style to the PDF grid
            pdfGrid.ApplyBuiltinStyle(PdfGridBuiltinStyle.GridTable4Accent1);

            //Create data to populate table
            DataTable table = CreateDataSourceTable(entities, columns);

            //Assign data source.
            pdfGrid.DataSource = table;

            pdfGrid.Style.Font = contentFont;

            //Draw PDF grid into the PDF page.
            pdfGrid.Draw(page, new Syncfusion.Drawing.PointF(0, result.Bounds.Bottom + paragraphAfterSpacing));

            MemoryStream memoryStream = new MemoryStream();

            // Save the PDF document.
            pdfDocument.Save(memoryStream);

            // Download the PDF document
            _jsRuntime.SaveAs(reportTitle + ".pdf", memoryStream.ToArray());
        }

        private string CreateContentInfo(ReportRequest reportRequest, List<T> entities)
        {
            var info = "From date: " + reportRequest.From.ToString("MM/dd/yyyy") + "\n";
            info += "To date: " + reportRequest.To.ToString("MM/dd/yyyy") + "\n";

            if (typeof(Defect) == entities.FirstOrDefault().GetType())
            {
                info += "Total sum: " + entities.Cast<Defect>().Sum(x => x.Cost);
            }
            
            return info;
        }

        private DataTable CreateDataSourceTable(List<T> defects, List<string> columns)
        {
            DataTable table = new DataTable();

            foreach (var prop in defects.FirstOrDefault().GetType().GetProperties())
            {
                if (columns.Contains(prop.Name))
                {
                    table.Columns.Add(prop.Name);
                }
            }

            foreach (var defect in defects)
            {
                var row = new List<string>();

                foreach (var prop in defect.GetType().GetProperties())
                {
                    if (columns.Contains(prop.Name))
                    {
                        row.Add(prop.GetValue(defect).ToString());
                    }
                }

                table.Rows.Add(row.ToArray());
            }

            return table;
        }
    }
}
