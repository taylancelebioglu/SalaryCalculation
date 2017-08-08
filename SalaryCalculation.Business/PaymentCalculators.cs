using SalaryCalculation.Data;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SalaryCalculation.Business
{
    public class SpecificDayofMonthCalculator : CalculatorBase, IPaymentDateCalculator
    {
        public DateTime CurrentDate { get; set; }
        public DateTime CalculateNextSalaryDate(SalaryDateCalculationDTO date)
        {
            if (CurrentDate.Day >= date.Day)
            {
                DateTime expected = new DateTime(CurrentDate.AddMonths(1).Year, CurrentDate.AddMonths(1).Month, date.Day);
                return base.GetNextWorkingDay(expected, true);
            }
            else
            {
                return base.GetNextWorkingDay(new DateTime(CurrentDate.Year, CurrentDate.Month, date.Day), true);
            }
        }
    }
    public class LastWorkingDayofMonthCalculator : CalculatorBase, IPaymentDateCalculator
    {
        public DateTime CurrentDate { get; set; }
        public DateTime CalculateNextSalaryDate(SalaryDateCalculationDTO date)
        {
            int currentMonthLastDay = Thread.CurrentThread.CurrentCulture.Calendar.GetDaysInMonth(CurrentDate.Year, CurrentDate.Month);

            DateTime expected = new DateTime(CurrentDate.Year, CurrentDate.Month, currentMonthLastDay);
            DateTime foundDate = base.GetNextWorkingDay(expected, false);

            if (foundDate <= CurrentDate)
            {
                int nextMonthLastDay = Thread.CurrentThread.CurrentCulture.Calendar.GetDaysInMonth(CurrentDate.AddMonths(1).Year, CurrentDate.AddMonths(1).Month);

                expected = new DateTime(CurrentDate.AddMonths(1).Year, CurrentDate.AddMonths(1).Month, currentMonthLastDay);
                foundDate = base.GetNextWorkingDay(expected, false);
            }
            return foundDate;
        }
    }
    public class DayBeforeLastWorkingDayCalculator : CalculatorBase, IPaymentDateCalculator
    {
        public DateTime CurrentDate { get; set; }
        public DateTime CalculateNextSalaryDate(SalaryDateCalculationDTO date)
        {
            PaymentDateCalculator calculator = new PaymentDateCalculator();
            IPaymentDateCalculator lastWorkingDayCalculator = calculator.GetCalculator(SalaryFrequency.LastWorkingDayofMonth);
            lastWorkingDayCalculator.CurrentDate = this.CurrentDate;
            DateTime lastWorkingDay = lastWorkingDayCalculator.CalculateNextSalaryDate(date);
            DateTime expected = lastWorkingDay.AddDays(-1);
            return base.GetNextWorkingDay(expected, false);
        }
    }
    public class FirstWorkingdayofMonthCalculator : CalculatorBase, IPaymentDateCalculator
    {
        public DateTime CurrentDate { get; set; }
        public DateTime CalculateNextSalaryDate(SalaryDateCalculationDTO date)
        {
            DateTime expected = new DateTime(CurrentDate.Year, CurrentDate.Month, 1);
            DateTime firstWorkingDay = base.GetNextWorkingDay(expected, true);
            if (firstWorkingDay <= CurrentDate)
            {
                expected = new DateTime(CurrentDate.AddMonths(1).Year, CurrentDate.AddMonths(1).Month, 1);
                firstWorkingDay = base.GetNextWorkingDay(expected, true);
            }
            return firstWorkingDay;
        }
    }
    public class FirstXDayCalculator : CalculatorBase, IPaymentDateCalculator
    {
        public DateTime CurrentDate { get; set; }
        public DateTime CalculateNextSalaryDate(SalaryDateCalculationDTO date)
        {
            DateTime firstDay = new DateTime(CurrentDate.Year, CurrentDate.Month, 1);

            while ((int)firstDay.DayOfWeek != date.Day)
            {
                firstDay = firstDay.AddDays(1);
            }

            if (CurrentDate.Day >= firstDay.Day)
            {
                firstDay = new DateTime(CurrentDate.AddMonths(1).Year, CurrentDate.AddMonths(1).Month, 1);
            }

            while ((int)firstDay.DayOfWeek != date.Day)
            {
                firstDay = firstDay.AddDays(1);
            }
            return firstDay;
        }
    }
    public class LastXDayCalculator : IPaymentDateCalculator
    {
        public DateTime CurrentDate { get; set; }
        public DateTime CalculateNextSalaryDate(SalaryDateCalculationDTO date)
        {
            int lastMonthLastDay = Thread.CurrentThread.CurrentCulture.Calendar.GetDaysInMonth(CurrentDate.Year, CurrentDate.Month);
            DateTime lastDay = new DateTime(CurrentDate.Year, CurrentDate.Month, lastMonthLastDay);

            while ((int)lastDay.DayOfWeek != date.Day)
            {
                lastDay = lastDay.AddDays(-1);
            }

            if (CurrentDate.Day >= lastDay.Day)
            {
                lastDay = new DateTime(CurrentDate.AddMonths(1).Year, CurrentDate.AddMonths(1).Month, lastMonthLastDay);
            }

            while ((int)lastDay.DayOfWeek != date.Day)
            {
                lastDay = lastDay.AddDays(-1);
            }
            return lastDay;
        }
    }
    public class NthXDayCalculator : IPaymentDateCalculator
    {
        public DateTime CurrentDate { get; set; }
        public DateTime CalculateNextSalaryDate(SalaryDateCalculationDTO date)
        {
            DateTime firstDay = new DateTime(CurrentDate.Year, CurrentDate.Month, 1);

            while ((int)firstDay.DayOfWeek != date.Day)
            {
                firstDay = firstDay.AddDays(1);
            }

            DateTime firstExpected = firstDay.AddDays((date.Week - 1) * 7);

            if (CurrentDate >= firstExpected)
            {
                firstDay = new DateTime(CurrentDate.AddMonths(1).Year, CurrentDate.AddMonths(1).Month, 1);
            }
            while ((int)firstDay.DayOfWeek != date.Day)
            {
                firstDay = firstDay.AddDays(1);
            }
            firstExpected = firstDay.AddDays((date.Week - 1) * 7);
            return firstExpected;
        }
    }
    public class NthWeeksXDayCalculator : IPaymentDateCalculator
    {
        public DateTime CurrentDate { get; set; }
        public DateTime CalculateNextSalaryDate(SalaryDateCalculationDTO date)
        {
            DateTime result = GetNthDatOfWeek(date);

            if (result == DateTime.MinValue)
            {
                throw new NoSuchDateException(string.Format("Date could not be found with parameters day:'{0}', week:'{1}'", date.Day, date.Week));
            }

            if (CurrentDate >= result)
            {
                CurrentDate = CurrentDate.AddMonths(1);
                result = GetNthDatOfWeek(date);

                if (result == DateTime.MinValue)
                {
                    throw new NoSuchDateException(string.Format("Date could not be found with parameters day:'{0}', week:'{1}'", date.Day, date.Week));
                }
            }
            return result;
        }

        private DateTime GetNthDatOfWeek(SalaryDateCalculationDTO date)
        {
            int days = Thread.CurrentThread.CurrentCulture.Calendar.GetDaysInMonth(CurrentDate.Year, CurrentDate.Month);

            DateTime result = DateTime.MinValue;

            int weekOrder = 1;
            for (int day = 1; day < days + 1; day++)
            {
                DateTime current = new DateTime(CurrentDate.Year, CurrentDate.Month, day);

                if (weekOrder == date.Week && (int)current.DayOfWeek == date.Day)
                {
                    result = current;
                    break;
                }

                if ((int)current.DayOfWeek == 0)
                {
                    weekOrder++;
                }
            }

            return result;
        }
    }
}