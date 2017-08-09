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
        public DateTime GetNextWorkingDay(DateTime expectedDate, bool next)
        {
            CultureInfo culture = Thread.CurrentThread.CurrentUICulture;
            Holidays holidays = new Business.Holidays();

            var dayOfTheWeek = culture.DateTimeFormat.Calendar.GetDayOfWeek(expectedDate);

            while (true)
            {
                if (WorkingDays.Contains((int)dayOfTheWeek) && holidays.FirstOrDefault(h => h.Date.Equals(expectedDate)) == null)
                {
                    break;
                }
                else
                {
                    int additionalDay = (next) ? 1 : -1;

                    return GetNextWorkingDay(expectedDate.AddDays(additionalDay), next);
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
                    int firstDay = (int)DayOfWeek.Monday;

                    for (int i = firstDay; i < 6; i++)
                    {
                        _days.Add(i);
                    }
                }
                return _days;
            }
        }
    }
}