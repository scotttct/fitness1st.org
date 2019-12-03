using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Fitness1stMVCWeb.Models
{
    public class CompendiumDbContext : DbContext
    {
        public CompendiumDbContext (DbContextOptions<CompendiumDbContext> options)
            : base(options)
        {
        }

        public DbSet<Fitness1stMVCWeb.Models.Compendium> Compendium { get; set; }
    }
}
