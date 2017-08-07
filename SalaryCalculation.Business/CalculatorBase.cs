using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SalaryCalculation.Business
{
    public class CalculatorBase
    {
        public DateTime GetNextWorkingDay(DateTime expectedDate)
        {
            CultureInfo culture = Thread.CurrentThread.CurrentUICulture;
            Holidays holidays = new Business.Holidays();

            var dayOfTheWeek = culture.DateTimeFormat.Calendar.GetDayOfMonth(expectedDate);

            while (true)
            {
                if (WorkingDays.Contains((int)dayOfTheWeek) && holidays.FirstOrDefault(h => h.Date.Equals(expectedDate)) == null)
                {
                    break;
                }
                else
                {
                    return GetNextWorkingDay(expectedDate.AddDays(1));
                }
            }
            return expectedDate;
        }

        private List<int> _days;
        private List<int> WorkingDays
        {
            get
            {
                if (_days == null)
                {
                    _days = new List<int>();

                    CultureInfo culture = Thread.CurrentThread.CurrentUICulture;
                    int firstDay = (int)culture.DateTimeFormat.FirstDayOfWeek;

                    for (int i = firstDay; _days.Count < 5; i++)
                    {
                        if (i == 6) i = 0;
                        _days.Add(i);
                    }
                }
                return _days;
            }
        }
    }
}