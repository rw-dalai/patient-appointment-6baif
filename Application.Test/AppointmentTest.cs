using System.Diagnostics;
using Application.Infrastructure;
using Application.Models;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Application.Test;

public class AppointmentTest
{
    private AppointmentContext GetDatabase()
    {
        // Create in-memory SQLite database
        var connection = new SqliteConnection("DataSource=:memory:");
        connection.Open();

        var options = new DbContextOptionsBuilder<AppointmentContext>()
            .UseSqlite(connection)
            .LogTo(message => Debug.WriteLine(message), LogLevel.Information)
            .EnableSensitiveDataLogging()
            .Options;

        var db = new AppointmentContext(options);
        Debug.WriteLine(db.Database.GenerateCreateScript());
        
        db.Database.EnsureDeleted();
        db.Database.EnsureCreated();
        
        return db;
    }
    
    [Fact]
    public void DatabaseSuccessTest()
    {
        using var db = GetDatabase();
        Assert.NotNull(db);
    }

    [Fact]
    public void AddPatientTest()
    {
        using var db = GetDatabase();
        
        // Given
        var patient = new Patient("Max", "Mustermann",
            new InsuranceNumber("1234567890"), new PhoneNumber("0123456789"));
        
        // When
        db.Patients.Add(patient);
        db.SaveChanges();
        db.ChangeTracker.Clear();

        // Then
        /**
         *  SELECT "p"."Id", "p"."FirstName", "p"."InsuranceNumber", "p"."LastName", "p"."PhoneNumber"
            FROM "Patient" AS "p"
            WHERE @patient_Id = "p"."Id"
            LIMIT 2
         */
        var retrievedPatient = db.Patients.SingleOrDefault(p => patient.Id == p.Id);
        // var retrievedPatient = db.Patients.FirstOrDefault(p => patient.Id == p.Id);
        var retrievedPatient2 = db.Patients.Find(patient.Id);
        Assert.NotNull(retrievedPatient);
    }
}