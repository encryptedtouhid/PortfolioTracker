using Microsoft.AspNetCore.Mvc;
using PortfolioTracking.Data.IRepository;
using PortfolioTracking.Data.Repository;
using PortfolioTracking.UI.Models;
using System.Diagnostics;

namespace PortfolioTracking.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPortfolioRepository _portfolioRepository;

        public HomeController(ILogger<HomeController> logger, IPortfolioRepository portfolioRepository)
        {
            _logger = logger;
            _portfolioRepository = portfolioRepository;
        }

        public IActionResult Index()
        {
           var data = _portfolioRepository.GetAllPortfoliobyTraderIdAsync("10001");
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}