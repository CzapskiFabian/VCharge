using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VCharge.Services;

namespace VCharge.Web.Controllers
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
