namespace ConsoleApp1.Shared.Domain.Model.ValueObjects;

/// <summary>
/// Represents a currency value objects
/// </summary>

public readonly record struct Currency
{
    
    /// <summary>
    /// The ISO 4217 alphabetics code of the currency
    /// </summary>
    /// <exception cref="ArgumentException">Thrown when the currency code is null, empty, whitespace, not 3 characters long, of contains </exception>
    public string Code
    {
        get => field ?? string.Empty;
        init
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(value);
            if (value.Length != 3 || !value.All(char.IsAsciiLetter))
                throw new ArgumentException("Currency must be a valid ISO 4217 alphabetic code (3 letters).",nameof(value));
            field = value.ToUpperInvariant();
        }
    }
    
    /// <summary>
    /// Prevents paramerless inirialization of the <see cref="Currency"/> value object
    /// </summary>
    /// <exception cref="InvalidOperationException"></exception>
    public Currency() => throw new InvalidOperationException("Currency must be initialized with a valid ISO 4217 alphabetic code(3 letters) .");
    /// <summary>
    /// Initializes a new instance of the <see cref="Currency"/> value object with the specifed ISO 4217 alphabetic code
    /// </summary>
    /// <param name="code"></param>
    public Currency(string code) => Code = code;
    
    /// <summary>
    /// Returns a string representation of the currency code
    /// </summary>
    /// <returns> A string of the ISO 4217 alphabetic code of the currency</returns>
    
    public override string ToString() => Code;
}