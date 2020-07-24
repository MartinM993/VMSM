using System.Collections.Generic;
using VMSM.Contracts.Entities;
using VMSM.Contracts.Requests;

namespace VMSM.Contracts.Interfaces
{
    public interface IReportService
    {
        void IncomeReport(ReportRequest request);
        List<Defect> DefectReport(ReportRequest request);
    }
}
