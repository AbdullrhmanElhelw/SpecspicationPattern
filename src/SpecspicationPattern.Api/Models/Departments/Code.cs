using SpecspicationPattern.Api.Utilities;

namespace SpecspicationPattern.Api.Models.Departments;

public record Code
{
    public string Value { get; }
    public Code(string value)
    {
        Check.NotEmpty(value, nameof(value));
        Value = value;
    }
    public static implicit operator string(Code code) => code.Value;
    public static implicit operator Code(string value) => new(value);
}