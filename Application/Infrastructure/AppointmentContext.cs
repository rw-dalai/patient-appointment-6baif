using Application.Models;
using Microsoft.EntityFrameworkCore;

namespace Application.Infrastructure;

public class AppointmentContext(DbContextOptions options) : DbContext(options)
{
    
    // --- DB Sets ---

    // public DbSet<Patient> Patients => Set<Patient>();
    public DbSet<Doctor> Doctors => Set<Doctor>();
    
    // TODO: Füge hier die DbSets ein.


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // TODO: Füge hier die Modellkonfiguration ein.

        // 1) Tabellen Namen
        modelBuilder.Entity<Doctor>().ToTable("Doctor");
        
        // 2) Relations
        
        // 3) Rich Types & Value Objects & Enums
        
        // 4) Indexes
        
        // 5) Inheritance
        
    }
}