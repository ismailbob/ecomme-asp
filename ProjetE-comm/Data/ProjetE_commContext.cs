using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjetE_comm.Models;

namespace ProjetE_comm.Data
{
    public class ProjetE_commContext : DbContext
    {
        public ProjetE_commContext (DbContextOptions<ProjetE_commContext> options)
            : base(options)
        {
        }

        public DbSet<ProjetE_comm.Models.Panier> Panier { get; set; } = default!;

        public DbSet<ProjetE_comm.Models.Product> Product { get; set; }

        public DbSet<ProjetE_comm.Models.Commande> Commande { get; set; }

        public DbSet<ProjetE_comm.Models.Lignepanier> Lignepanier { get; set; }
    }
}
