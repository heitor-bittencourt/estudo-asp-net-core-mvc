using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebVendasMvc.Services;

namespace WebVendasMvc.Controllers
{
    public class RegistroVendasController : Controller
    {
        private readonly RegistroVendasService _registroVendasService;

        public RegistroVendasController(RegistroVendasService registroVendasService)
        {
            _registroVendasService = registroVendasService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> BuscaSimples(DateTime? minData, DateTime? maxData)
        {
            if (!minData.HasValue)
            {
                minData = new DateTime(DateTime.Now.Year, 1, 1);
            }
            if (!maxData.HasValue)
            {
                maxData = DateTime.Now;
            }

            ViewData["minData"] = minData.Value.ToString("yyyy-MM-dd");
            ViewData["maxData"] = maxData.Value.ToString("yyyy-MM-dd");

            var resultado = await _registroVendasService.FindByDateAsync(minData, maxData);
            return View(resultado);
        }

        public IActionResult BuscaGrupo()
        {
            return View();
        }
    }
}