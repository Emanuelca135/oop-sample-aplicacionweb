using System.Net.Http.Headers;

namespace ConsoleApp1.Shared.Domain.Model.ValueObjects;

public readonly record struct Money()
{
    public decimal Amount
    {
        get;
        init
        {
            ArgumentOutOfRangeException.ThrowIfNegative(value);
            field = value;
        }
    }

    public Currency Currency
    {
        get;
        init
        {
            ArgumentOutOfRangeException.ThrowIfNegative(value);
            fiedl = value;
        }
    }

    public Currency Currency
    {
        get;
        init
        {
            if (value == default)
                throw new ArgumentException("Currency is required", nameof(value));
            field = value;
        }
    }
    
    public Money( )=> throw new InvalidOperationException("Money must be initialized with an amount and a currency.");

    public Money(decimal amount, Currency currency)
    {
        (Amount, Currency) = (amount, currency);
    }
    
    public Money(decimal amount, string (currencyCode):this (amount, new Currency(currencyCode)) {}

    public override string ToString() => $"{Amount}{Currency}";
    
    public Money Add(Money other)
    {
        if (Currency == default || other.Currency == default)
            throw new InvalidOperationException("Cannot add Money with uninitialized currency.");

        if (Currency != other.Currency)
            throw new InvalidOperationException($"Cannot add Money with different currencies: {Currency} and {other.Currency}.");

        return new Money(Amount + other.Amount, Currency);
    }
    
    
    public Money Multiply(decimal factor)
    {
        if (Currency == default)
            throw new InvalidOperationException("Cannot multiply Money with uninitialized currency.");

        ArgumentOutOfRangeException.ThrowIfNegative(factor, nameof(factor));

        return new Money(Amount * factor, Currency);
    }
    
    public Money Multiply(int factor) => Multiply((decimal)factor);

    public static Money operator +(Money left, Money right) => left.Add(right);

    public static Money operator *(Money money, decimal factor) => money.Multiply(factor);

    public static Money operator *(decimal factor, Money money) => money.Multiply(factor);

    public static Money operator *(Money money, int factor) => money.Multiply(factor);

    public static Money operator *(int factor, Money money) => money.Multiply(factor);
}





