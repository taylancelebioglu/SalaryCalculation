using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SalaryCalculation.Api.Controllers;
using SalaryCalculation.Data;

namespace SalaryCalculation.Api.Tests
{
    [TestClass]
    public class SalaryTest
    {
        [TestMethod]
        public void SpecificDayofMonth_Test()
        {
            SalaryController controller = new SalaryController();
            SalaryDateCalculationDTO dto = new SalaryDateCalculationDTO() { Day = 12, Week = 0, PaymentFrequency = SalaryFrequency.SpecificDayofMonth };
            DateTime result = controller.GetNextSalary(dto, new DateTime(2017, 7, 8));
            Assert.AreEqual(result, new DateTime(2017, 7, 12));
        }
    }
}
