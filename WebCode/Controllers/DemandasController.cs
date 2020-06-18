using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebCode.Controllers
{
    public class DemandasController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
