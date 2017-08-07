using SalaryCalculation.Data;
using System;

namespace SalaryCalculation.Business
{
    public interface IPaymentDateCalculator
    {
        DateTime CalculateNextSalaryDate(SalaryDateCalculationDTO date);
        DateTime CurrentDate { get; set; }
    }
}