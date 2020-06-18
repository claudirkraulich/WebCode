using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebCode.Models;
using WebCode.Models.ViewModels;
using WebCode.Services;

namespace WebCode.Controllers
{
    public class DemandasController : Controller
    {
        private readonly DemandaService _demandaService;
        private readonly OrigemService _origemService;

        public DemandasController(DemandaService demandaService, OrigemService origemService)
        {
            _demandaService = demandaService;
            _origemService = origemService;
        }
        
        public IActionResult Index()
        {
            var list = _demandaService.FindAll();
            return View(list);
        }

        public IActionResult Create()
        {
            var origens = _origemService.FindAll();
            var viewModel = new DemandaFormViewModel { Origens = origens };
            return View(viewModel);              
                
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Demanda demanda)
        {
            _demandaService.Insert(demanda);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var obj = _demandaService.FindById(id.Value);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _demandaService.Remove(id);
            return RedirectToAction(nameof(Index));
        }


    }
}
