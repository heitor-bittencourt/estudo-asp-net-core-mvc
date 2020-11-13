using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebVendasMvc.Controllers
{
    public class RegistroVendasController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult BuscaSimples()
        {
            return View();
        }

        public IActionResult BuscaGrupo()
        {
            return View();
        }
    }
}