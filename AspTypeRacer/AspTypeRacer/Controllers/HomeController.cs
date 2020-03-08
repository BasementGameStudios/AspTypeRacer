using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AspTypeRacer.Models;


namespace AspTypeRacer.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        //private readonly CustomerDBContext _customerContext = new CustomerDBContext();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;

        }

        //https://medium.com/@rashmilan/web-api-with-net-and-sqlite-part-3-3680840acd61

        //https://ianvink.wordpress.com/2018/04/09/asp-net-core-2-using-sqlite-as-a-light-weight-database/
        public IActionResult Index(SimpleDbContext db)
        {
            /*
            for(int i = 0; i < 100; i++)
            {
                db.Customer.Add(new CustomerModel() { Name =  "Asuna " + i });
            }
            db.SaveChanges();
            */

            Customer cust = db.Customer.FirstOrDefault();

           // Customer cust = _customerContext.Customers.FirstOrDefault();
            return View(cust);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult SqlLiteTest()
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
