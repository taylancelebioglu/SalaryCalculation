using System.Collections.Generic;
using SalaryCalculation.Data;

namespace SalaryCalculation.Business
{
    public class PaymentDateCalculator
    {
        private Dictionary<SalaryFrequency, IPaymentDateCalculator> calculators = new Dictionary<SalaryFrequency, IPaymentDateCalculator>() {
            { SalaryFrequency.SpecificDayofMonth, new SpecificDayofMonthCalculator()  },
            { SalaryFrequency.LastWorkingDayofMonth, new LastWorkingDayofMonthCalculator()  },
            { SalaryFrequency.DayBeforeLastWorkingDay, new DayBeforeLastWorkingDayCalculator()  },
            { SalaryFrequency.FirstWorkingdayofMonth, new FirstWorkingdayofMonthCalculator() },
            { SalaryFrequency.FirstXDay, new FirstXDayCalculator()  },
            { SalaryFrequency.LastXDay, new LastXDayCalculator()  },
            { SalaryFrequency.NthXDay, new NthXDayCalculator()  },
            { SalaryFrequency.NthWeeksXDay, new NthWeeksXDayCalculator()  }
        };
        public IPaymentDateCalculator GetCalculator(SalaryFrequency type)
        {
            return calculators[type];
        }
    }
}