using SpecspicationPattern.Api.Utilities;

namespace SpecspicationPattern.Api.Models.Employees;

public record FirstName
{
    public string Value { get; }
    public FirstName(string value)
    {
        Check.NotEmpty(value, nameof(value));
        Value = value;
    }
    public static implicit operator string(FirstName firstName) => firstName.Value;
}