namespace Application.Models;

/**
 *       CREATE TABLE "Doctor" (
          "Id" INTEGER NOT NULL CONSTRAINT "PK_Doctor" PRIMARY KEY AUTOINCREMENT,
          "FirstName" TEXT NOT NULL,
          "LastName" TEXT NOT NULL,
          "Email" TEXT NOT NULL
      );
 */
public class Doctor
{
    // PK
    public int Id { get; set; }
    
    public string FirstName { get; set; }
    
    public string LastName { get; set; }
    
    public string Email { get; set; }
    
    // --- EF Ctor ---
    protected Doctor() { }
    
    // --- Business Ctor ---
    public Doctor(string firstName, string lastName, string email)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
    }
}