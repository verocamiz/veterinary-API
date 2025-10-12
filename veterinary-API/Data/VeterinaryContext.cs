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
    public DbSet<MedicalRecord> MedicalRecord { get; set; }
    public DbSet<Patient> Patient { get; set; }
    public DbSet<Species> Species { get; set; }
    public DbSet<Clinic> Clinic { get; set; } 

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    { 
        modelBuilder.Entity<Veterinary>() // relacion uno a muchos
        .HasOne(v => v.Clinic)
        .WithMany(c => c.Veterinaries)
        .HasForeignKey(v => v.ClinicId)
        .OnDelete(DeleteBehavior.Restrict); 

        modelBuilder.Entity<Veterinary>() // relacion muchos a muchos
        .HasMany(p => p.Patients)
        .WithMany(d => d.Veterinaries);
         
        modelBuilder.Entity<Patient>() // uno a muchos
        .HasOne(v => v.Specie)
        .WithMany(c => c.Patients)
        .HasForeignKey(v => v.SpecieId)
        .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<MedicalRecord>() // uno a uno 
         .HasOne(v => v.Patient)
         .WithOne(c => c.MedicalRecord)
         .HasForeignKey<MedicalRecord>(mr => mr.PatientId)
         .OnDelete(DeleteBehavior.Cascade);
    }
}
