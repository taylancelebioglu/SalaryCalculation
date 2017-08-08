using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SalaryCalculation.Api.Controllers;
using SalaryCalculation.Data;

namespace SalaryCalculation.Api.Tests
{
    [TestClass]
    public class SalaryTest
    {
        SalaryController controller;
        SalaryDateCalculationDTO dto;
        public SalaryTest()
        {
            controller = new SalaryController();
        }
        [TestMethod]
        public void SpecificDayofMonth_Test()
        {
            dto = new SalaryDateCalculationDTO() { Day = 12, Week = 0, PaymentFrequency = SalaryFrequency.SpecificDayofMonth };
            DateTime result = controller.GetNextSalary(dto, new DateTime(2017, 7, 8));
            Assert.AreEqual(result, new DateTime(2017, 7, 12));

            dto = new SalaryDateCalculationDTO() { Day = 14, Week = 0, PaymentFrequency = SalaryFrequency.SpecificDayofMonth };
            DateTime result2 = controller.GetNextSalary(dto, new DateTime(2017, 7, 20));
            Assert.AreEqual(result2, new DateTime(2017, 8, 14));
        }
        [TestMethod]
        public void LastWorkingDayofMonth_Test() 
        {
            dto = new SalaryDateCalculationDTO() { Day = 0, Week = 0, PaymentFrequency = SalaryFrequency.LastWorkingDayofMonth };
            DateTime result = controller.GetNextSalary(dto, new DateTime(2017, 6 , 8));
            Assert.AreEqual(result, new DateTime(2017, 6, 30));

            dto = new SalaryDateCalculationDTO() { Day = 0, Week = 0, PaymentFrequency = SalaryFrequency.LastWorkingDayofMonth };
            DateTime result2 = controller.GetNextSalary(dto, new DateTime(2017, 9, 20));
            Assert.AreEqual(result2, new DateTime(2017, 9, 29));
        }
    }
}
