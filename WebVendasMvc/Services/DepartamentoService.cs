using System;
using WebVendasMvc.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace WebVendasMvc.Services
{
    public class DepartamentoService
    {

        private readonly WebVendasMvcContext _context;

        public DepartamentoService(WebVendasMvcContext context)
        {
            _context = context;
        }

        //Método de processamento síncrono
        /*public List<Departamento> FindAll()
        {
            return _context.Departamento.OrderBy(x => x.Nome).ToList();
        }*/
        public async Task<List<Departamento>> FindAllAsync()
        {
            return await _context.Departamento.OrderBy(x => x.Nome).ToListAsync();
        }
    }
}
