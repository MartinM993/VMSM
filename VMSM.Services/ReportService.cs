using System.Collections.Generic;
using System.Linq;
using VMSM.Contracts.Entities;
using VMSM.Contracts.Interfaces;
using VMSM.Contracts.Requests;

namespace VMSM.Services
{
    public class ReportService : IReportService
    {
        private readonly IVendingMachineProductService _vendingMachineProductService;
        private readonly IRepository<Income> _income;
        private readonly IRepository<Defect> _defect;

        public ReportService(IVendingMachineProductService vendingMachineProductService,
                             IRepository<Income> income,
                             IRepository<Defect> defect)
        {
            _vendingMachineProductService = vendingMachineProductService;
            _income = income;
            _defect = defect;
        }

        public List<Income> IncomeReport(ReportRequest request)
        {
            var incomes = _income.GetAll();
            var filteredincomes = incomes.Where(x =>
                                    x.VendingMachineId == request.VendingMachineId &&
                                    x.DateCreated.HasValue &&
                                    x.DateCreated?.ToString("MM/dd/yyyy").CompareTo(request.From.ToString("MM/dd/yyyy")) >= 0 &&
                                    x.DateCreated?.ToString("MM/dd/yyyy").CompareTo(request.To.ToString("MM/dd/yyyy")) <= 0
                                    );

            //var vendingMachineProducts = _vendingMachineProductService.GetAll().Where(x => 
            //                                x.VendingMachineId == request.VendingMachineId &&
            //                                x.DateCreated.HasValue &&
            //                                x.DateCreated?.ToString("MM/dd/yyyy").CompareTo(request.From.ToString("MM/dd/yyyy")) >= 0 &&
            //                                x.DateCreated?.ToString("MM/dd/yyyy").CompareTo(request.To.ToString("MM/dd/yyyy")) <= 0
            //                                );

            //foreach (var income in filteredincomes)
            //{
            //    int profit = 0;
            //    foreach (var product in vendingMachineProducts)
            //    {
            //        if (product.DateCreated?.ToString("MM/dd/yyyy").CompareTo(income.DateCreated?.ToString("MM/dd/yyyy")) <= 0)
            //        {
            //            profit += decimal.ToInt32((product.Product.PriceByPiece * (product.Product.Profit / 100)) * product.Quantity);
            //        }
            //    }

            //    income.Profit = profit;
            //}

            return filteredincomes.ToList();
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
