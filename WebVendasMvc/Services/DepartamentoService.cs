using System;
using System.Collections.Generic;
using System.Linq;
using WebVendasMvc.Models;

namespace WebVendasMvc.Services
{
    public class DepartamentoService
    {

        private readonly WebVendasMvcContext _context;

        public DepartamentoService(WebVendasMvcContext context)
        {
            _context = context;
        }

        public List<Departamento> FindAll()
        {
            return _context.Departamento.OrderBy(x => x.Nome).ToList();
        }
    }
}
