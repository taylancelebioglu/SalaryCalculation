using SalaryCalculation.Business;
using SalaryCalculation.Data;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace SalaryCalculation.Api.Controllers
{
    /// <summary>
    /// Base salary calculator controller
    /// </summary>
    public class SalaryController : ApiController
    {
        /// <summary>
        /// Api Test
        /// </summary>
        /// <returns></returns>
        public SalaryDateCalculationDTO Test()
        {
            SalaryDateCalculationDTO testDto = new SalaryDateCalculationDTO()
            {
                Day = 1,
                Week = 1,
                PaymentFrequency = SalaryFrequency.LastWorkingDayofMonth
            };
            return testDto;
        }
        /// <summary>
        /// Gets next salary date
        /// </summary>
        /// <returns></returns>
        public DateTime GetNextSalary(SalaryDateCalculationDTO calculationData, DateTime currentDate)
        {
            PaymentDateCalculator calculator = new PaymentDateCalculator();
            IPaymentDateCalculator relatedCalculator = calculator.GetCalculator(calculationData.PaymentFrequency);
            relatedCalculator.CurrentDate = currentDate;
            return relatedCalculator.CalculateNextSalaryDate(calculationData);
        }
    }
}