namespace Application.Models;


// Structural Equality (same values)
// Referential Equality (same object in memory)

// Rich Type
// - Immutable ✅
// - Equality by Value ✅
// - ToString ✅
// - HashCode ✅
public record InsuranceNumber
{
    public string Value { get; }
    
    // "      1  ".Trim() => "1"
    public InsuranceNumber(string value)
    {
        var trimmed = value.Trim();
        
        if (string.IsNullOrWhiteSpace(trimmed) || trimmed.Length != 10) 
            throw new AppointmentException("$Invalid InsuranceNumber: {value}");
        
        Value = trimmed;
    }
}