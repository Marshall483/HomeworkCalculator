using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MvcMovie.Controllers
{
    public class HelloWorldController : Controller
    {
        //GET /HelloWorld/
        public IActionResult Index()
        {
            return View();
        }

        //GET /HelloWorld/Welcome
        public string Welcome(string name, int count = 1)
        {
            string mes = "Congratulation! You are reach Welcome() method!\n" +
                $"A-a-and we get the parameters: {name} {count} times!";
            return mes;
        }
    }
}
