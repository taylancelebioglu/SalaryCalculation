using SalaryCalculation.Api.Controllers;
using SalaryCalculation.Business;
using SalaryCalculation.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTestApp
{
    class Program
    {
        static void Main(string[] args)
        {
           
            SalaryDateCalculationDTO dto = new SalaryDateCalculationDTO() { Day = 12, Week = 0, PaymentFrequency = SalaryFrequency.SpecificDayofMonth };

            PaymentDateCalculator calculator = new PaymentDateCalculator();
            IPaymentDateCalculator relatedCalculator = calculator.GetCalculator(dto.PaymentFrequency);
            relatedCalculator.CurrentDate = new DateTime(2017, 7, 8);
            var rrrs = relatedCalculator.CalculateNextSalaryDate(dto);


            var rr = new DateTime(2017, 7, 12);
        }
    }
}
