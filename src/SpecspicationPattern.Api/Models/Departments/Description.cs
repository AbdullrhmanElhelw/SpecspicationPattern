using SpecspicationPattern.Api.Utilities;

namespace SpecspicationPattern.Api.Models.Departments;

public record Description
{
    public string Value { get; }
    public Description(string value)
    {
        Check.NotEmpty(value, nameof(value));
        Value = value;
    }
    public static implicit operator string(Description description) => description.Value;
    public static implicit operator Description(string value) => new(value);
}