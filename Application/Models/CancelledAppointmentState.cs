namespace Application.Models;

public class CancelledAppointmentState(Appointment appointment, DateTime created) 
    : AppointmentState(appointment, created);