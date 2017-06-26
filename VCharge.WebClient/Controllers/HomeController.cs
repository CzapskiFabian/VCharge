using Microsoft.AspNetCore.Mvc;
using VCharge.Services;

namespace VCharge.WebClient.Controllers
{
    public class HomeController : Controller
    {
        private IMeterReaderService _meterReader;
        public HomeController(IMeterReaderService meterReader)
        {
            _meterReader = meterReader;
        }
        public IActionResult Index()
        {
            var result = _meterReader.GetMonthlySummaries();
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
