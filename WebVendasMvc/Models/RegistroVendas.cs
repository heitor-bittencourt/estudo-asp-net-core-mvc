using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebVendasMvc.Models.Enums;

namespace WebVendasMvc.Models
{
    public class RegistroVendas
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }

        [DisplayFormat(DataFormatString = "{0:F2}")]
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
