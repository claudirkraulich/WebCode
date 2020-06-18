using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebCode.Services;

namespace WebCode.Controllers
{
    public class DemandasController : Controller
    {
        private readonly DemandaService _demandaService;

        public DemandasController(DemandaService demandaService)
        {
            _demandaService = demandaService;
        }
        
        public IActionResult Index()
        {
            var list = _demandaService.FindAll();
            return View(list);
        }
    }
}
