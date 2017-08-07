using System.Web.Mvc;

namespace SalaryCalculation.Api.Controllers
{
    /// <summary>
    /// Default Controller
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// Default
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();   
        }
    }
}