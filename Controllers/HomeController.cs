using ListOfPagination.Pages_Pagination;
using ListofTExample.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ListofTExample.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(int pageNo, int pageSize)
        {
            //example code 
            List<string> exampleCode = new();
            for (int i = 0; i < 10000; i++)
            {
                exampleCode.Add("Test " + i);
            }

            var ListOfPagination = new ListOfPagination<string>();

            ListOfPagination.Data = exampleCode;
            var ListofPaginationModel = ListOfPaginationPageHelper<string>.GetPaged(ListOfPagination, pageNo, pageSize);

            return View(ListofPaginationModel);

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