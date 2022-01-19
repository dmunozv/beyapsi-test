using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SistemaSocios.Modelo;

namespace SistemaSocios.Data
{
    public class SistemaSociosContext : DbContext
    {
        public SistemaSociosContext (DbContextOptions<SistemaSociosContext> options)
            : base(options)
        {
        }

        public DbSet<SistemaSocios.Modelo.Socio> Socio { get; set; }

        public DbSet<SistemaSocios.Modelo.Movimiento> Movimiento { get; set; }
    }
}
