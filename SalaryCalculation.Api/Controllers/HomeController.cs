using SalaryCalculation.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Mvc;

namespace SalaryCalculation.Api.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
        [ResponseType(typeof(SalaryDateCalculationDTO))]
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
    }
}