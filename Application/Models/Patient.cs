namespace Application.Models;

public class Patient
{
    // PK
    public int Id { get; set; }
    
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public InsuranceNumber InsuranceNumber { get; set; }

    public PhoneNumber PhoneNumber { get; set; }
        
    // --- EF Ctor ---
    protected Patient() { }
    
    // --- Business Ctor ---
    public Patient(string firstName, string lastName,
        InsuranceNumber insuranceNumber, PhoneNumber phoneNumber)
    {
        
        FirstName = firstName;
        LastName = lastName;
        InsuranceNumber = insuranceNumber;
        PhoneNumber = phoneNumber;
    }
}