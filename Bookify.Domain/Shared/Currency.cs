namespace Bookify.Domain.Shared;
public record Currency
{
    public string Code { get; init; }
    private Currency(string code) => Code = code;



    internal static readonly Currency None = new("");
    public static readonly Currency USD = new Currency("USD");
    public static readonly Currency EUR = new Currency("EUR");
    public static readonly IReadOnlyCollection<Currency> All = new Currency[] { USD, EUR };
    public static Currency FromCode(string code)
    {
        return All.FirstOrDefault(c => c.Code == code) ??
             throw new ApplicationException($"Currency with code {code} is invalid");
    }
}