namespace Application.Models;

// public class AppointmentException : Exception
// {
//     public AppointmentException(string message) : base(message)
//     {
//     }
// }

public class AppointmentException(string message) : Exception(message);