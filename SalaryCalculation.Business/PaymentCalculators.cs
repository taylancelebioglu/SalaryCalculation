using SalaryCalculation.Data;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryCalculation.Business
{
    public class SpecificDayofMonthCalculator : CalculatorBase, IPaymentDateCalculator
    {
        public DateTime CurrentDate { get; set; }

        public DateTime CalculateNextSalaryDate(SalaryDateCalculationDTO date)
        {
            if (CurrentDate.Day > date.Day)
            {
                CultureInfo info = System.Threading.Thread.CurrentThread.CurrentCulture;
                DateTime expected = new DateTime(CurrentDate.AddMonths(1).Year, CurrentDate.AddMonths(1).Month, date.Day);
                return base.GetNextWorkingDay(expected);
            }
            else
            {
                return base.GetNextWorkingDay(new DateTime(CurrentDate.Year, CurrentDate.Month, date.Day));
            }
        }
    }
    public class LastWorkingDayofMonthCalculator : IPaymentDateCalculator
    {
        public DateTime CurrentDate { get; set; }
        public DateTime CalculateNextSalaryDate(SalaryDateCalculationDTO date)
        {
            throw new NotImplementedException();
        }
    }
    public class DayBeforeLastWorkingDayCalculator : IPaymentDateCalculator
    {
        public DateTime CurrentDate { get; set; }
        public DateTime CalculateNextSalaryDate(SalaryDateCalculationDTO date)
        {
            throw new NotImplementedException();
        }
    }
    public class FirstWorkingdayofMonthCalculator : IPaymentDateCalculator
    {
        public DateTime CurrentDate { get; set; }
        public DateTime CalculateNextSalaryDate(SalaryDateCalculationDTO date)
        {
            throw new NotImplementedException();
        }
    }
    public class FirstXDayCalculator : IPaymentDateCalculator
    {
        public DateTime CurrentDate { get; set; }
        public DateTime CalculateNextSalaryDate(SalaryDateCalculationDTO date)
        {
            throw new NotImplementedException();
        }
    }
    public class LastXDayCalculator : IPaymentDateCalculator
    {
        public DateTime CurrentDate { get; set; }
        public DateTime CalculateNextSalaryDate(SalaryDateCalculationDTO date)
        {
            throw new NotImplementedException();
        }
    }
    public class NthXDayCalculator : IPaymentDateCalculator
    {
        public DateTime CurrentDate { get; set; }
        public DateTime CalculateNextSalaryDate(SalaryDateCalculationDTO date)
        {
            throw new NotImplementedException();
        }
    }
    public class NthWeeksXDayCalculator : IPaymentDateCalculator
    {
        public DateTime CurrentDate { get; set; }
        public DateTime CalculateNextSalaryDate(SalaryDateCalculationDTO date)
        {
            throw new NotImplementedException();
        }
    }
}
