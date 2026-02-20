namespace Application.Models;

public abstract class AppointmentState
{
    // PK
    public int Id { get; set; }
    
    public Appointment Appointment { get; set; }
    
    public DateTime Created { get; set; }
    
    // Discriminator
    public string Type { get; set; }
    
    // --- EF Ctor ---
    protected AppointmentState() { }
    
    // --- Business Ctor ---
    protected AppointmentState(
        Appointment appointment,
        DateTime created) 
    {
        Appointment = appointment;
        Created = created;
    }
        
}