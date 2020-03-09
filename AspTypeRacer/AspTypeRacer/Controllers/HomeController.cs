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

        private readonly SimpleDbContext _db;
        private readonly ILogger<HomeController> _logger;

        //private readonly CustomerDBContext _customerContext = new CustomerDBContext();

        public HomeController(ILogger<HomeController> logger, SimpleDbContext db)
        {
            _db = db;
            _logger = logger;

        }

        //https://medium.com/@rashmilan/web-api-with-net-and-sqlite-part-3-3680840acd61

        //https://ianvink.wordpress.com/2018/04/09/asp-net-core-2-using-sqlite-as-a-light-weight-database/
        public IActionResult Index()
        {
            /*
            for(int i = 0; i < 100; i++)
            {
                db.Customer.Add(new CustomerModel() { Name =  "Asuna " + i });
            }
            db.SaveChanges();
            */

            Customer cust = _db.Customer.FirstOrDefault();

            ViewBag.Name = "Guest";
           // Customer cust = _customerContext.Customers.FirstOrDefault();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult SqlLiteTest()
        {
            AddUser("Blah");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult AddUser(string userName)
        {
            var test = _db.Customer.Where(a => a.Name == userName);
            //See if the name already exists in our database
            if (!test.Any())
            {
                Console.WriteLine("Adding a user...");
                _db.Customer.Add(new Customer { Name = userName });
                _db.SaveChanges();
            }
            else
            {
                Console.WriteLine("Not adding a user...");
            }

            return View();
        }
    }
}
