using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebVendasMvc.Models;
using Microsoft.EntityFrameworkCore;

namespace WebVendasMvc.Services
{
    public class RegistroVendasService
    {
        private readonly WebVendasMvcContext _context;

        public RegistroVendasService(WebVendasMvcContext context)
        {
            _context = context;
        }

        public async Task<List<RegistroVendas>> FindByDateAsync(DateTime? minData, DateTime? maxData)
        {
            var resultado = from obj in _context.RegistroVendas select obj;

            if (minData.HasValue)
            {
                resultado = resultado.Where(x => x.Date >= minData.Value);
            }

            if (maxData.HasValue)
            {
                resultado = resultado.Where(x => x.Date <= maxData.Value);                    
            }

            return await resultado
                .Include(x => x.Vendedor)
                .Include(x => x.Vendedor.Departamento)
                .OrderByDescending(x => x.Date)
                .ToListAsync();
        }

        public async Task<List<IGrouping<Departamento, RegistroVendas>>> FindByDateGroupingAsync(DateTime? minData, DateTime? maxData)
        {
            var resultado = from obj in _context.RegistroVendas select obj;

            if (minData.HasValue)
            {
                resultado = resultado.Where(x => x.Date >= minData.Value);
            }

            if (maxData.HasValue)
            {
                resultado = resultado.Where(x => x.Date <= maxData.Value);
            }

            return await resultado
                .Include(x => x.Vendedor)
                .Include(x => x.Vendedor.Departamento)
                .OrderByDescending(x => x.Date)
                .GroupBy(x => x.Vendedor.Departamento) //quando utilizamos o GroupBy o retorno não é mais uma lista comum e sim do tipo IGrouping com o tipo do agrupamento mais o tipo de dado
                .ToListAsync();
        }
    }
}
