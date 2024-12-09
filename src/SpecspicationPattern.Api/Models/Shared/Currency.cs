namespace SpecspicationPattern.Api.Models.Shared;

public record Currency(string Code)
{
    public static readonly string Usd = "USD";

    public static readonly string Eur = "EUR";

    public static readonly string Gbp = "GBP";

    public static readonly string Jpy = "JPY";

    public static Currency GetByCode(string code)
    {
        return code switch
        {
            "USD" => new Currency(Usd),
            "EUR" => new Currency(Eur),
            "GBP" => new Currency(Gbp),
            "JPY" => new Currency(Jpy),
            _ => throw new ArgumentException("Invalid currency code")
        };
    }

    public static IEnumerable<Currency> All =>
    new List<Currency>
        {
            new (Usd),
            new (Eur),
            new (Gbp),
            new (Jpy)
        };
}