using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebVendasMvc.Models
{
    public class Vendedor
    {
        public int Id { get; set; }

        [Display(Name ="Nome")]
        [Required(ErrorMessage ="Nome obrigatório")]
        [StringLength(60, MinimumLength = 3, ErrorMessage ="Tamanho do nome deve se entre {2} e {1} caracteres")]
        public string Name { get; set; }

        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Digite um email válido")]
        [Required(ErrorMessage = "{0} obrigatório")]
        public string Email { get; set; }

        [Display(Name ="Data de Nascimento")]
        [Required(ErrorMessage = "{0} obrigatório")]
        [DataType(DataType.Date)]
        /*Não é necessário utilizar esse display nesse formato, pois estamos utilizando a localização pt-BR
         * [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]*/         
        public DateTime DataAniversario { get; set; }

        [Required(ErrorMessage = "{0} obrigatório")]
        [Range(100.00, 50000.00, ErrorMessage ="{0} deve ser entre {1} e {2}")]
        [Display(Name ="Salário Base")]        
        [DisplayFormat(DataFormatString ="{0:F2}")]
        public double SalarioBase { get; set; }
        public Departamento Departamento { get; set; }
        public int DepartamentoId { get; set; }
        public ICollection<RegistroVendas> Vendas { get; set; } = new List<RegistroVendas>();

        public Vendedor()
        {

        }

        public Vendedor(int id, string name, string email, DateTime dataAniversario, double salarioBase, Departamento departamento)
        {
            Id = id;
            Name = name;
            Email = email;
            DataAniversario = dataAniversario;
            SalarioBase = salarioBase;
            Departamento = departamento;
        }

        public void AdicionarVendas(RegistroVendas rv)
        {
            Vendas.Add(rv);
        }

        public void ExcluirVendas(RegistroVendas rv)
        {
            Vendas.Remove(rv);
        }

        public double TotalVendas(DateTime inicial, DateTime final)
        {
            return Vendas.Where(rv => rv.Date >= inicial && rv.Date <= final).Sum(rv => rv.Montante);
        }
    }
}
