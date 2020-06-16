using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebCode.Models;

namespace WebCode.Controllers
{
    public class OrigensController : Controller
    {
        public IActionResult Index()
        {

            List<Origem> list = new List<Origem>();
            list.Add(new Origem { Id = 1, Nome = "TCE" });
            list.Add(new Origem { Id = 2, Nome = "MP" });

            return View(list);
        }
    }
}
