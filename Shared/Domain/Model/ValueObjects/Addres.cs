namespace ConsoleApp1.Shared.Domain.Model.ValueObjects;

public readonly record struct Addres
{
    public string Street
    {
        get => field ?? string.Empty;
        init
        {
            ArgumentException.ThrowIfNullOrEmptyWithSpace(value);
            if(value.Length > 100)
                throw new ArgumentException("Street address must not be longer than 100 characters.",nameof(value));
            field = value;
        }
    }

    public string City
    {
        get => field ?? string.Empty;
        init
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(value);
            if(value.Length > 100)
                throw new ArgumentException("City address must not be longer than 100 characters.", nameof(value));
            field = value;
        }
    }
    
    public string Country
    {
        get => field ?? string.Empty;
        init
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(value);
            if (value.Length > 100)
                throw new ArgumentException("Country addres not be longer than 100 characters", nameof(value));
            field = value;
        }
    }
    
    public Address() => throw new InvalidOperationException("Address must be initialized with street, number, city, postal code, and country.");

    public Address(string street, string number, string city, string? stateOrRegion, string postalCode, string country)
    {
        Street = street;
        Number = number;
        City = city;
        StateOrRegion = stateOrRegion;
        PostalCode = postalCode;
        Country = country;
    }
    
    public override string ToString() => string.IsNullOrWhiteSpace(StateOrRegion)
        ? $"{Street} {Number}, {City}, {PostalCode}, {Country}"
        : $"{Street} {Number}, {City}, {StateOrRegion}, {PostalCode}, {Country}";
    
    
}