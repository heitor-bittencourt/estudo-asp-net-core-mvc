using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebVendasMvc.Models;
using Microsoft.EntityFrameworkCore;
using WebVendasMvc.Services.Exceptions;

namespace WebVendasMvc.Services
{
    public class VendedorService
    {
        private readonly WebVendasMvcContext _context;

        public VendedorService(WebVendasMvcContext context)
        {
            _context = context;
        }

        public List<Vendedor> FindAll()
        {
            return _context.Vendedor.ToList();
        }

        public void Inserir(Vendedor obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }

        public Vendedor FindById(int id)
        {
            return _context.Vendedor.Include(obj => obj.Departamento).FirstOrDefault(obj => obj.Id == id);
        }

        public void Remove(int id)
        {
            var obj = _context.Vendedor.Find(id);
            _context.Vendedor.Remove(obj);
            _context.SaveChanges(); 
        }

        public void Atualizar(Vendedor obj)
        {
            if (!_context.Vendedor.Any(x => x.Id == obj.Id))
            {
                throw new NotFoundException("Id não encontrada");
            }
            try
            {
                _context.Update(obj);
                _context.SaveChanges();
            }            

            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }

    }
}
