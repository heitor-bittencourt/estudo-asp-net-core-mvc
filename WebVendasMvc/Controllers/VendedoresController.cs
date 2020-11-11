using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebVendasMvc.Models;
using WebVendasMvc.Models.ViewModels;
using WebVendasMvc.Services;
using WebVendasMvc.Services.Exceptions;

namespace WebVendasMvc.Controllers
{
    public class VendedoresController : Controller
    {
        //Dependências dos serviços
        private readonly VendedorService _vendedorService;
        private readonly DepartamentoService _departamentoService;

        //Construtor 
        public VendedoresController(VendedorService vendedorService, DepartamentoService departamentoService)
        {
            _vendedorService = vendedorService;
            _departamentoService = departamentoService;
        }
        public IActionResult Index()
        {
            var list = _vendedorService.FindAll();
            return View(list);
        }

        public IActionResult Create()
        {
            var departamentos = _departamentoService.FindAll();
            var viewModel = new VendedorFormViewModel { Departamentos = departamentos };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Vendedor vendedor)
        {
            if (!ModelState.IsValid)
            {
                var departamentos = _departamentoService.FindAll();
                var viewModel = new VendedorFormViewModel { Vendedor = vendedor, Departamentos = departamentos };
                return View(viewModel);
            }
            _vendedorService.Inserir(vendedor);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Erro), new { mensagem = "Id não fornecido" });
            }

            var obj = _vendedorService.FindById(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Erro), new { mensagem = "Id não encontrado" }); ;
            }

            return View(obj);           
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _vendedorService.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Detalhes(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Erro), new { mensagem = "Id não fornecido" }); ;
            }

            var obj = _vendedorService.FindById(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Erro), new { mensagem = "Id não encontrado" }); ;
            }

            return View(obj);
        }

        public IActionResult Editar(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Erro), new { mensagem = "Id não fornecido" }); ;
;           }

            var obj = _vendedorService.FindById(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Erro), new { mensagem = "Id não encontrado" }); ;
            }

            List<Departamento> departamentos = _departamentoService.FindAll();
            VendedorFormViewModel viewModel = new VendedorFormViewModel { Vendedor = obj, Departamentos = departamentos };

            return View(viewModel);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(int id, Vendedor vendedor)
        {
            if (!ModelState.IsValid)
            {
                var departamentos = _departamentoService.FindAll();
                var viewModel = new VendedorFormViewModel { Vendedor = vendedor, Departamentos = departamentos };
                return View(viewModel);
            }

            if (id != vendedor.Id)
            {
                return RedirectToAction(nameof(Erro), new { mensagem = "Id não correspondente" }); ;
            }
            try
            {
                _vendedorService.Atualizar(vendedor);
                return RedirectToAction(nameof(Index));
            }
            //Utilizando a superclasse para evitar a mesma mensagem de erro dos dois catchs abaixo comentado
            catch (ApplicationException e)
            {
                return RedirectToAction(nameof(Erro), new { mensagem = e.Message });
            }
            /*
            catch (NotFoundException e)
            {
                return RedirectToAction(nameof(Erro), new { mensagem = e.Message });
            }
            catch (DbConcurrencyException e)
            {
                return RedirectToAction(nameof(Erro), new { mensagem = e.Message }); ;
            }*/
        }

        public IActionResult Erro(string mensagem)
        {
            var viewModel = new ErrorViewModel
            {
                Message = mensagem,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };

            return View(viewModel);
        }
    }
}