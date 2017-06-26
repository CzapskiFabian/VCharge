using Microsoft.AspNetCore.Mvc;
using VCharge.Services;

namespace VCharge.WebClient.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMeterReaderService _meterReader;

        public HomeController(IMeterReaderService meterReader)
        {
            _meterReader = meterReader;
        }
        public IActionResult Index()
        {
            var summaries = _meterReader.GetMonthlySummaries();

            return View(summaries.Value);
        }

    }
}
