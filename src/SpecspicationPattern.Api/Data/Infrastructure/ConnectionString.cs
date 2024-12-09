namespace SpecspicationPattern.Api.Data.Infrastructure;

public record ConnectionString(string Value)
{
    public const string DefaultConnection = "DefaultConnection";

    public static implicit operator string(ConnectionString connectionString) => connectionString.Value;
}