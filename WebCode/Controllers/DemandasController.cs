
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
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
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido" });
            }
            var obj = _demandaService.FindById(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não localizado" });
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
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido" });
            }
            var obj = _demandaService.FindById(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não localizado" });
            }
            return View(obj);
        }
        // Edit versão GET
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido" });
            }

            var obj = _demandaService.FindById(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não localizado" });
            }

            List<Origem> origens = _origemService.FindAll();
            DemandaFormViewModel viewModel = new DemandaFormViewModel { Demanda = obj, Origens = origens };
            return View(viewModel);
        }
        // Edit versão POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Demanda demanda)
        {
            if (id != demanda.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não corresponde" });
            }
            try
            {
                _demandaService.Update(demanda);
                return RedirectToAction(nameof(Index));
            }
            catch (NotFoundException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
            catch (DbConcurrencyException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
        }

        public IActionResult Error(string Message)
        {
            var viewModel = new ErrorViewModel
            {
                Message = Message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return View(viewModel);
        }
    }
}
