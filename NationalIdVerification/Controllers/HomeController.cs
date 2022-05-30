using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NationalIdVerification.Models;
using NationalIdVerification.Services;

namespace NationalIdVerification.Controllers
{
    public class HomeController : Controller
    {
        INationalIdVerificationService _nationalIdVerificationService;
        public HomeController()
        {
            _nationalIdVerificationService = new NationalIdVerificationService();
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(long id, string firstName, string lastName, int yearOfBirth)
        {
            var verificationResult = false;
            if (string.IsNullOrEmpty(id.ToString()) == false && string.IsNullOrEmpty(firstName) == false && string.IsNullOrEmpty(lastName) == false && yearOfBirth > 0)
            {
                verificationResult = await _nationalIdVerificationService.IsNationalIdVerified(id, firstName, lastName, yearOfBirth);
            }

            ViewBag.IsNationalIdVerified = string.Format("Result is {0} for {1} {2}", verificationResult, firstName, lastName);

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
