using Application.Models;
using Microsoft.EntityFrameworkCore;

namespace Application.Infrastructure;

public class AppointmentContext(DbContextOptions options) : DbContext(options)
{
    
    // --- DB Sets ---
    
    // TODO: Füge hier die DbSets ein.


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
        modelBuilder.Entity<Patient>().ToTable("Patients");
        
        // TODO: Füge hier die Modellkonfiguration ein.
    }
}