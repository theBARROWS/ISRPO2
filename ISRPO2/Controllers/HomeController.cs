using ISRPO2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ISRPO2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult TaskFirst()
        {
            return View();
        }

        public IActionResult TaskSecond()
        {
            return View();
        }

        public IActionResult TaskThird()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult TaskFirst(int CoordX, int CoordY)
        {
                bool isInFirstOrThirdQuadrant = (CoordX > 0 && CoordY > 0) || (CoordX < 0 && CoordY < 0);

                if (isInFirstOrThirdQuadrant)
                {
                    ViewBag.FirstAnswer = "ДА!";
                }
                else
                {
                    ViewBag.FirstAnswer = "НЕТ!";
                }

                return View();
        }

        [HttpPost]
        public IActionResult TaskSecond(int Number)
        {
            if (Number < 100 || Number > 999)
            {
                ViewBag.SecondAnswer = "ЧИСЛО НЕ ТРЕХЗНАЧНОЕ!!!";
                return View();
            }

            int digit1 = Number / 100;
            int digit2 = (Number / 10) % 10;
            int digit3 = Number % 10; 

            bool isTheseThreeDigitsDifferent = (digit1 != digit2 && digit1 != digit3 && digit2 != digit3);

            if (isTheseThreeDigitsDifferent)
            {
                ViewBag.SecondAnswer = "ДА!";
            }
            else
            {
                ViewBag.SecondAnswer = "НЕТ!";
            }

            return View();
        }

        [HttpPost]
        public IActionResult TaskThird(int Number)
        {
            Random rand = new Random();

            int n = rand.Next(10, 20);

            int[] myArray = new int[n];

            for (int i = 0; i < myArray.Length; i++) myArray[i] = rand.Next(-20, 20);

            string myArr = string.Join(", ", myArray);
            ViewBag.myArr = myArr;

            for (int i = 0; i < myArray.Length; i++)
            {
                if (myArray[i] < 0)
                {
                    myArray[i] = myArray[i] * myArray[i];
                }

            }

            string myNewArr = string.Join(", ", myArray);
            ViewBag.myNewArr = myNewArr;

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}