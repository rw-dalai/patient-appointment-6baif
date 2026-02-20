namespace Application.Models;

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