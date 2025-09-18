namespace AMartinezTech.Core.ValueObjects;

public class ValueAddress
{
    public string Address { get; init; }
    public string City { get; init; }
    public string Region { get; init; }
    public string PostalCode { get; init; }
    public string Country { get; init; }

    private ValueAddress(string address, string city, string region, string postalCode, string country)
    {
        Address = address;
        City = city;
        Region = region;
        PostalCode = postalCode;
        Country = country;
    }

    public static ValueAddress Create(string address, string city, string region, string postalCode, string country)
    {
        return new ValueAddress(address, city, region, postalCode, country);
    }


}

