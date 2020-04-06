using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NumberGuessingGame.Models;
using System;
using System.Diagnostics;

namespace NumberGuessingGame.Controllers
{
    public class HomeController : Controller
    {
        [ThreadStatic] private static Random _random;
        private static int _answer;

        public HomeController(ILogger<HomeController> logger)
        {
            
        }

        [HttpGet]
        public IActionResult Index()
        {
            return LoadPage();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public JsonResult GetAnswer(int guess)
        {
            if (_answer > guess)
                return Json("Your guess is too low.");
            if (_answer < guess)
                return Json("Your guess is too high.");
            if (_answer == guess)
                return Json("Congratulations!");

            return Json(_answer);
        }

        [HttpPost]
        public ActionResult PlayAgain()
        {
            return LoadPage();
        }

        public ActionResult LoadPage()
        {
            ModelState.Clear();
            _random = new Random();
            _answer = _random.Next(1, 100);
            return View(new RandomNumberModel());
        }
    }
}
