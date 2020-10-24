using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Multiservicios.Models;

namespace Multiservicios.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { 
        }

        public DbSet<Departamento> Departamento { get; set; }
        public DbSet<AreaTrabajo> AreaTrabajo { get; set; }
        public DbSet<Puesto> Puesto { get; set; }
        public DbSet<Marca> Marca { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Tickets> Tickets { get; set; }
        public DbSet<TipoSolicitud> TipoSolicitud { get; set; }

        public DbSet<Proveedor> Proveedor { get; set; }
        public DbSet<Activo> Activo { get; set; }
        public DbSet<Usuario> Usuario { get; set; } 
        public DbSet<SolicitudCompra> SolicitudCompra { get; set; }
    }
 
}
