
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
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

        public async Task<IActionResult> Index()
        {
            var list = await _demandaService.FindAllAsync();
            return View(list);
        }

        public async Task<IActionResult> Create()
        {
            var origens = await _origemService.FindAllAsync();
            var viewModel = new DemandaFormViewModel { Origens = origens };
            return View(viewModel);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Demanda demanda)
        {
            if (!ModelState.IsValid)   //controller testa envio do formulário caso o javascript do usuario estiver desabilitado - evita cadastro null
            {
                var origens = await _origemService.FindAllAsync();
                var viewModel = new DemandaFormViewModel { Demanda = demanda, Origens = origens };
                return View(viewModel);
            }
            
            await _demandaService.InsertAsync(demanda);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido" });
            }
            var obj = await _demandaService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não localizado" });
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _demandaService.RemoveAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch(IntegrityException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido" });
            }
            var obj = await _demandaService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não localizado" });
            }
            return View(obj);
        }
        // Edit versão GET
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido" });
            }

            var obj = await _demandaService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não localizado" });
            }

            List<Origem> origens = await _origemService.FindAllAsync();
            DemandaFormViewModel viewModel = new DemandaFormViewModel { Demanda = obj, Origens = origens };
            return View(viewModel);
        }
        // Edit versão POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Demanda demanda)
        {
            if (!ModelState.IsValid)   //controller testa envio do formulário caso o javascript do usuario estiver desabilitado - evita cadastro null
            {
                var origens = await _origemService.FindAllAsync();
                var viewModel = new DemandaFormViewModel { Demanda = demanda, Origens = origens };
                return View(viewModel);
            }

            if (id != demanda.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não corresponde" });
            }
            try
            {
                await _demandaService.UpdateAsync(demanda);
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

        public IActionResult Error(string message)
        {
            var viewModel = new ErrorViewModel
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return View(viewModel);
        }
    }
}
