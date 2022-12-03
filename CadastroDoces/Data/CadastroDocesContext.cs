using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CadastroDoces.Models;

namespace CadastroDoces.Data
{
    public class CadastroDocesContext : DbContext
    {
        public CadastroDocesContext (DbContextOptions<CadastroDocesContext> options)
            : base(options)
        {
        }

        public DbSet<CadastroDoces.Models.Cliente> Clientes { get; set; } = default!;

        public DbSet<CadastroDoces.Models.Doce> Doce { get; set; }
    }
}
