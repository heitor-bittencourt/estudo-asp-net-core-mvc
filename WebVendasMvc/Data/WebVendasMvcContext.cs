using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebVendasMvc.Models
{
    public class WebVendasMvcContext : DbContext
    {
        public WebVendasMvcContext (DbContextOptions<WebVendasMvcContext> options)
            : base(options)
        {
        }

        public DbSet<WebVendasMvc.Models.Departamento> Departamento { get; set; }
    }
}
