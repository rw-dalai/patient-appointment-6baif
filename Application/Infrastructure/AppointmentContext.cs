using Application.Models;
using Microsoft.EntityFrameworkCore;

namespace Application.Infrastructure;

public class AppointmentContext(DbContextOptions options) : DbContext(options)
{
    
    // --- DB Sets ---
    
    public DbSet<Doctor> Doctors => Set<Doctor>();
    
    public DbSet<Patient> Patients => Set<Patient>();
    
    public DbSet<Appointment> Appointments => Set<Appointment>();
    
    public DbSet<AppointmentState> AppointmentStates => Set<AppointmentState>();


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // 1) Tabellen Namen
        modelBuilder.Entity<Doctor>().ToTable("Doctor");
        modelBuilder.Entity<Patient>().ToTable("Patient");
        modelBuilder.Entity<Appointment>().ToTable("Appointment");
        modelBuilder.Entity<AppointmentState>().ToTable("AppointmentState");
        
        // 2) Relations (1:1 bidirectional Appointment <-> AppointmentState)
        modelBuilder.Entity<Appointment>()
            .HasOne(u => u.CurrentState)
            .WithOne(p => p.Appointment)
            // .HasForeignKey<AppointmentState>("AppointmentId")
            .HasForeignKey<AppointmentState>(nameof(AppointmentState.AppointmentId))
            .OnDelete(DeleteBehavior.Cascade);
        
        // 3) Rich Types & Value Objects & Enums
        modelBuilder.Entity<ConfirmedAppointmentState>()
            .OwnsOne(c => c.PlannedSlot);
        
        modelBuilder.Entity<Patient>()
            .Property(p => p.PhoneNumber)
            .HasConversion(
                p => p.Value,                       // C# -> DB
                value => new PhoneNumber(value)     // DB -> C#
            );

        modelBuilder.Entity<Patient>()
            .Property(p => p.InsuranceNumber)
            .HasConversion(
                p => p.Value,                       // C# -> DB
                value => new InsuranceNumber(value) // DB -> C#
            );

            
        // 4) Indexes
        modelBuilder.Entity<Doctor>().HasIndex("Email").IsUnique();
        modelBuilder.Entity<Appointment>().HasIndex("Date", "PatientId").IsUnique();
        // modelBuilder.Entity<Appointment>().HasIndex(a => new { a.Date, a.PatientId }).IsUnique();

            
        // 5) Inheritance
        modelBuilder.Entity<AppointmentState>()
            .HasDiscriminator(a => a.Type)
            .HasValue<ConfirmedAppointmentState>("Confirmed")
            .HasValue<CancelledAppointmentState>("Cancelled");

    }
}