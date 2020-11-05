using System;
using System.Collections.Generic;

namespace WebVendasMvc.Models.ViewModels
{
    public class VendedorFormViewModel
    {
        public Vendedor Vendedor { get; set; }

        public ICollection<Departamento> Departamentos { get; set; }
    }
}
