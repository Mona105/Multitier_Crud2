using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Multilayer_Crud.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DataLayer;
using BussinessAccessLayer;
using CommanLayer.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Data;

namespace Multilayer_Crud.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private BLEmployeeBussiness bussiness = new BLEmployeeBussiness();
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var emp = bussiness.GetEmployees();
            return View(emp);
        }
        
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employees employees)
        {
            var result=bussiness.CreateEmployees(employees);
            if(result)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("error","Error in create employee !");
                return View(employees);
            }
            
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
