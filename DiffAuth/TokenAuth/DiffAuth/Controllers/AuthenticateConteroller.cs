using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiffAuth.Controllers
{
    public class AuthenticateConteroller : Controller
    {
        public AuthenticateConteroller()
        {
             
        }

        public IActionResult Jwt()
        {
            return View("JwtAuth");
        }
    }
}
