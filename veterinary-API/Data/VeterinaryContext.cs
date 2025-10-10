using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using veterinary_API.Models;

public class VeterinaryContext : DbContext
{
    public VeterinaryContext(DbContextOptions<VeterinaryContext> options)
        : base(options) { }

    public DbSet<Veterinary> Veterinaries { get; set; }
    //public DbSet<Consultorio> Consultorios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // (opcional) configuraciones Fluent API
    }
}
