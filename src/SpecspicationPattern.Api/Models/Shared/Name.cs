using SpecspicationPattern.Api.Utilities;

namespace SpecspicationPattern.Api.Models.Shared;

public record Name
{
    public string Value { get; }

    public Name(string value)
    {
        Check.NotEmpty(value, nameof(value));
        Value = value;
    }

    public static implicit operator string(Name name) => name.Value;
    public static implicit operator Name(string value) => new(value);
}