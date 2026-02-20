namespace Application.Models;

public class CancelledAppointmentState : AppointmentState
{
    protected CancelledAppointmentState(): base() {}

    public CancelledAppointmentState(Appointment appointment, DateTime created) 
        : base(appointment, created)
    {
    }
}