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
    public class AtividadesController : Controller
    {
        private readonly AtividadeService _atividadeService;
        private readonly DemandaService _demandaService;
      

        public AtividadesController(AtividadeService atividadeService, DemandaService demandaService)
        {
            _atividadeService = atividadeService;
            _demandaService = demandaService;
            
        }

        public async Task<IActionResult> Index()
        {
            var list = await _atividadeService.FindAllAsync();
            return View(list);
        }

        public async Task<IActionResult> Create()
        {
            var demandas = await _demandaService.FindAllAsync();
            var viewModel = new AtividadeFormViewModel { Demandas = demandas };
            return View(viewModel);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Atividade atividade)
        {
            if (!ModelState.IsValid)   //controller testa envio do formulário caso o javascript do usuario estiver desabilitado - evita cadastro null
            {
                var demandas = await _demandaService.FindAllAsync();
                var viewModel = new AtividadeFormViewModel { Atividade = atividade , Demandas = demandas };
                return View(viewModel);
            }

            await _atividadeService.InsertAsync(atividade);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido" });
            }
            var obj = await _atividadeService.FindByIdAsync(id.Value);
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
                await _atividadeService.RemoveAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch (IntegrityException e)
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
            var obj = await _atividadeService.FindByIdAsync(id.Value);
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

            var obj = await _atividadeService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não localizado" });
            }

            List<Demanda> demandas = await _demandaService.FindAllAsync();
            AtividadeFormViewModel viewModel = new AtividadeFormViewModel { Atividade = obj, Demandas = demandas };
            return View(viewModel);
        }
        // Edit versão POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Atividade atividade)
        {
            if (!ModelState.IsValid)   //controller testa envio do formulário caso o javascript do usuario estiver desabilitado - evita cadastro null
            {
                var demandas = await _demandaService.FindAllAsync();
                var viewModel = new AtividadeFormViewModel { Atividade = atividade, Demandas = demandas };
                return View(viewModel);
            }

            if (id != atividade.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não corresponde" });
            }
            try
            {
                await _atividadeService.UpdateAsync(atividade);
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
