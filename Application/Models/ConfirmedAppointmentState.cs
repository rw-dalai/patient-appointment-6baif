namespace Application.Models;

public class ConfirmedAppointmentState : AppointmentState
{
    public Doctor Doctor { get; set; }
    
    public TimeSlot PlannedSlot { get; set; }
    
    public string? Infotext { get; set; }
    
    // --- EF Ctor ---
    protected ConfirmedAppointmentState() { }
    
    // --- Business Ctor ---
    public ConfirmedAppointmentState(
        Appointment appointment,
        DateTime created,
        Doctor doctor,
        TimeSlot plannedSlot,
        string? infotext) 
        : base(appointment, created)
    {
        Doctor = doctor;
        PlannedSlot = plannedSlot;
        Infotext = infotext;
    }
}