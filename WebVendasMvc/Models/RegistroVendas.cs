using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebVendasMvc.Models.Enums;

namespace WebVendasMvc.Models
{
    public class RegistroVendas
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public double Montante { get; set; }
        public StatusVenda Status{ get; set; }
        public Vendedor Vendedor { get; set; }

        public RegistroVendas()
        {

        }

        public RegistroVendas(int id, DateTime date, double montante, StatusVenda status, Vendedor vendedor)
        {
            Id = id;
            Date = date;
            Montante = montante;
            Status = status;
            Vendedor = vendedor;
        }
    }
}
