using System.Collections.Generic;
using System.Linq;
using VMSM.Contracts.Entities;
using VMSM.Contracts.Interfaces;
using VMSM.Contracts.Requests;

namespace VMSM.Services
{
    public class ReportService : IReportService
    {
        private readonly IRepository<VendingMachine> _vendingMachine;
        private readonly IRepository<Income> _income;
        private readonly IRepository<Defect> _defect;

        public ReportService(IRepository<VendingMachine> vendingMachine,
                             IRepository<Income> income,
                             IRepository<Defect> defect)
        {
            _vendingMachine = vendingMachine;
            _income = income;
            _defect = defect;
        }

        public void IncomeReport(ReportRequest request)
        {

        }

        public List<Defect> DefectReport(ReportRequest request)
        {
            var defects = _defect.GetAll();

            var filteredDefects = defects.Where(x => 
                                    x.VendingMachineId == request.VendingMachineId &&
                                    x.DateCreated.HasValue &&
                                    x.DateCreated?.ToString("MM/dd/yyyy").CompareTo(request.From.ToString("MM/dd/yyyy")) >= 0 &&
                                    x.DateCreated?.ToString("MM/dd/yyyy").CompareTo(request.To.ToString("MM/dd/yyyy")) <= 0
                                    ).ToList();

            return filteredDefects;
        }
    }
}
