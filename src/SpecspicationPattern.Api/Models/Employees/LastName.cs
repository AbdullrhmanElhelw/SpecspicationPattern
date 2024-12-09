using SpecspicationPattern.Api.Utilities;

namespace SpecspicationPattern.Api.Models.Employees;

public record LastName
{
    public string Value { get; }
    public LastName(string value)
    {
        Check.NotEmpty(value, nameof(value));
        Value = value;
    }
    public static implicit operator string(LastName lastName) => lastName.Value;
}