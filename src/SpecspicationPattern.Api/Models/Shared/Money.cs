namespace SpecspicationPattern.Api.Models.Shared;

public record Money(decimal Amount, Currency Currency)
{
    public static Money Create(decimal amount, Currency currency)
    {
        return new Money(amount, currency);
    }
    public Money Add(Money money)
    {
        if (Currency != money.Currency)
        {
            throw new ArgumentException("Cannot add money with different currencies");
        }
        return this with { Amount = Amount + money.Amount };
    }
    public Money Subtract(Money money)
    {
        if (Currency != money.Currency)
        {
            throw new ArgumentException("Cannot subtract money with different currencies");
        }
        return this with { Amount = Amount - money.Amount };
    }
    public Money Multiply(decimal multiplier)
    {
        return this with { Amount = Amount * multiplier };
    }
    public Money Divide(decimal divisor)
    {
        return this with { Amount = Amount / divisor };
    }
}