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
            result = controller.GetNextSalary(dto, new DateTime(2017, 7, 20));
            Assert.AreEqual(result, new DateTime(2017, 8, 14));
        }
        [TestMethod]
        public void LastWorkingDayofMonth_Test() 
        {
            dto = new SalaryDateCalculationDTO() { Day = 0, Week = 0, PaymentFrequency = SalaryFrequency.LastWorkingDayofMonth };
            DateTime result = controller.GetNextSalary(dto, new DateTime(2017, 6 , 8));
            Assert.AreEqual(result, new DateTime(2017, 6, 30));

            dto = new SalaryDateCalculationDTO() { Day = 0, Week = 0, PaymentFrequency = SalaryFrequency.LastWorkingDayofMonth };
            result = controller.GetNextSalary(dto, new DateTime(2017, 9, 20));
            Assert.AreEqual(result, new DateTime(2017, 9, 29));
        }
        [TestMethod]
        public void DayBeforeLastWorkingDay_Test() 
        {
            dto = new SalaryDateCalculationDTO() { Day = 0, Week = 0, PaymentFrequency = SalaryFrequency.DayBeforeLastWorkingDay };
            DateTime result = controller.GetNextSalary(dto, new DateTime(2017, 6 , 8));
            Assert.AreEqual(result, new DateTime(2017, 6, 29));

            dto = new SalaryDateCalculationDTO() { Day = 0, Week = 0, PaymentFrequency = SalaryFrequency.DayBeforeLastWorkingDay };
            result = controller.GetNextSalary(dto, new DateTime(2017, 9, 20));
            Assert.AreEqual(result, new DateTime(2017, 9, 28));
        }
        [TestMethod]
        public void FirstWorkingdayofMonth_Test()
        {
            dto = new SalaryDateCalculationDTO() { Day = 0, Week = 0, PaymentFrequency = SalaryFrequency.FirstWorkingdayofMonth };
            DateTime result = controller.GetNextSalary(dto, new DateTime(2017, 6, 8));
            Assert.AreEqual(result, new DateTime(2017, 7, 3));

            dto = new SalaryDateCalculationDTO() { Day = 0, Week = 0, PaymentFrequency = SalaryFrequency.FirstWorkingdayofMonth };
            result = controller.GetNextSalary(dto, new DateTime(2017, 10, 1));
            Assert.AreEqual(result, new DateTime(2017, 10, 2));
        }
       [TestMethod]
        public void FirstXDay_Test()
        {
            dto = new SalaryDateCalculationDTO() { Day = 2, Week = 0, PaymentFrequency = SalaryFrequency.FirstXDay };
            DateTime result = controller.GetNextSalary(dto, new DateTime(2017, 7, 3));
            Assert.AreEqual(result, new DateTime(2017, 7, 4));

            dto = new SalaryDateCalculationDTO() { Day = 2, Week = 0, PaymentFrequency = SalaryFrequency.FirstXDay };
            result = controller.GetNextSalary(dto, new DateTime(2017, 7, 6));
            Assert.AreEqual(result, new DateTime(2017, 8, 1));

            dto = new SalaryDateCalculationDTO() { Day = 4, Week = 0, PaymentFrequency = SalaryFrequency.FirstXDay };
            result = controller.GetNextSalary(dto, new DateTime(2017, 7, 1));
            Assert.AreEqual(result, new DateTime(2017, 7, 6));
        }
        [TestMethod]
        public void LastXDay_Test()
        {
            dto = new SalaryDateCalculationDTO() { Day = 3, Week = 0, PaymentFrequency = SalaryFrequency.LastXDay };
            DateTime result = controller.GetNextSalary(dto, new DateTime(2017, 7, 14));
            Assert.AreEqual(result, new DateTime(2017, 7, 26));

            dto = new SalaryDateCalculationDTO() { Day = 1, Week = 0, PaymentFrequency = SalaryFrequency.LastXDay };
            result = controller.GetNextSalary(dto, new DateTime(2017, 8, 18));
            Assert.AreEqual(result, new DateTime(2017, 8, 28));

            dto = new SalaryDateCalculationDTO() { Day = 5, Week = 0, PaymentFrequency = SalaryFrequency.LastXDay };
            result = controller.GetNextSalary(dto, new DateTime(2017, 9, 21));
            Assert.AreEqual(result, new DateTime(2017, 9, 29));
        }
        [TestMethod]
        public void NthXDay_Test()
        {
            dto = new SalaryDateCalculationDTO() { Day = 1, Week = 1, PaymentFrequency = SalaryFrequency.NthXDay };
            DateTime result = controller.GetNextSalary(dto, new DateTime(2017, 6, 5));
            Assert.AreEqual(result, new DateTime(2017, 7, 3));

            dto = new SalaryDateCalculationDTO() { Day = 3, Week = 3, PaymentFrequency = SalaryFrequency.NthXDay };
            result = controller.GetNextSalary(dto, new DateTime(2017, 7, 8));
            Assert.AreEqual(result, new DateTime(2017, 7, 19));

            dto = new SalaryDateCalculationDTO() { Day = 5, Week = 5, PaymentFrequency = SalaryFrequency.NthXDay };
            result = controller.GetNextSalary(dto, new DateTime(2017, 6, 14));
            Assert.AreEqual(result, new DateTime(2017, 6, 30));
        }
        [TestMethod]
        public void NthWeeksXDay_Test()
        {
            dto = new SalaryDateCalculationDTO() { Day = 3, Week = 3, PaymentFrequency = SalaryFrequency.NthWeeksXDay };
            DateTime result = controller.GetNextSalary(dto, new DateTime(2017, 7, 8));
            Assert.AreEqual(result, new DateTime(2017, 7, 12));

            dto = new SalaryDateCalculationDTO() { Day = 5, Week = 5, PaymentFrequency = SalaryFrequency.NthWeeksXDay };
            result = controller.GetNextSalary(dto, new DateTime(2017, 6, 14));
            Assert.AreEqual(result, new DateTime(2017, 6, 30));
        }
        [TestMethod]
        public void NthWeeksXDay_Exception_Test()
        {
            dto = new SalaryDateCalculationDTO() { Day = 1, Week = 1, PaymentFrequency = SalaryFrequency.NthWeeksXDay };
            DateTime result = controller.GetNextSalary(dto, new DateTime(2017, 8, 10));
            Assert.AreEqual(result, new DateTime(2017, 1, 1));
        }
    }
}