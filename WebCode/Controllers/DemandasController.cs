using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Operations;
using WebCode.Models;
using WebCode.Models.ViewModels;
using WebCode.Services;
using WebCode.Services.Exceptions;

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

        public IActionResult Details(int? id)
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

        public IActionResult Edit(int? id)
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

            List<Origem> origens = _origemService.FindAll();
            DemandaFormViewModel viewModel = new DemandaFormViewModel { Demanda = obj, Origens = origens };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Demanda demanda)
        {
            if (id != demanda.Id)
            {
                return BadRequest();
            }
            try
            {
                _demandaService.Update(demanda);
                return RedirectToAction(nameof(Index));
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
            catch (DbConcurrencyException)
            {
                return BadRequest();
            }
        }
    }
}
