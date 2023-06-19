using Azure;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PortfolioTracking.Data.EntityModel;
using PortfolioTracking.Data.IRepository;
using PortfolioTracking.Data.Repository;
using PortfolioTracking.Data.ViewModel;
using PortfolioTracking.UI.Models;
using System.Diagnostics;

namespace PortfolioTracking.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPortfolioRepository _portfolioRepository;
        private readonly string _alphavantageServiceUrl;
        private readonly string _token;
        private readonly string _techCompanyShortNames;
        public HomeController(ILogger<HomeController> logger, IConfiguration configuration, IPortfolioRepository portfolioRepository)
        {
            _logger = logger;
            _portfolioRepository = portfolioRepository;
            _alphavantageServiceUrl = configuration.GetValue<string>("AlphavantageServiceUrl");
            _token = configuration.GetValue<string>("AlphavantageToken");
            _techCompanyShortNames = configuration.GetValue<string>("TechCompanyShortNames");
        }

        public IActionResult Index()
        {
            DataVM dataVM = new DataVM();
            dataVM.PLReportList =  _portfolioRepository.GetProfitLossReport();
            dataVM.PortfolioList = _portfolioRepository.GetAllPortfolio();
            return View(dataVM);
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


        public IActionResult GetLiveStockUpdate()
        {
            string[] shortNames = _techCompanyShortNames.Split(',');
            string jsonResponse = String.Empty;

            foreach (var shortName in shortNames)
            {
                string url = _alphavantageServiceUrl + "function=TIME_SERIES_DAILY_ADJUSTED&symbol=" + shortName + "&apikey=" + _token;


                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = client.GetAsync(url).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        jsonResponse = response.Content.ReadAsStringAsync().Result;
                        JObject jsonData = JObject.Parse(jsonResponse);
                        JObject timeSeries = (JObject)jsonData["Time Series (Daily)"];

                        if (timeSeries != null)
                        {
                            foreach (JProperty timeSeriesData in timeSeries.Children<JProperty>())
                            {
                                DailyPrice dailyPrice = new DailyPrice();

                                string date = timeSeriesData.Name;
                                JObject priceData = (JObject)timeSeriesData.Value;

                                dailyPrice.Open = (string)priceData.GetValue("1. open");
                                dailyPrice.High = (string)priceData.GetValue("2. high");
                                dailyPrice.Low = (string)priceData.GetValue("3. low");
                                dailyPrice.Close = (string)priceData.GetValue("4. close");
                                dailyPrice.Volume = (string)priceData.GetValue("6. volume");
                                _portfolioRepository.AddStockUpdateDate(dailyPrice, shortName, date);
                            }
                        }

                    }
                    else
                    {
                        Console.WriteLine("Failed to retrieve data. Status code: " + response.StatusCode);
                        return Json("Failed to retrieve data. Status code: " + response.StatusCode);
                    }
                }
            }

            return RedirectPreserveMethod("Index");

        }
    }
}