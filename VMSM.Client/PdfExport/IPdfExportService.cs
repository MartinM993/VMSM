using System.Collections.Generic;
using VMSM.Contracts.Interfaces;
using VMSM.Contracts.Requests;

namespace VMSM.Client.PdfExport
{
    public interface IPdfExportService<T>
    {
        void ExportToPdf(List<T> entities, string reportTitle, ReportRequest reportRequest, List<string> columns);
    }
}
