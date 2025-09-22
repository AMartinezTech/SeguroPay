using AMartinezTech.Domain.Utils.Exception;
using System.ComponentModel.DataAnnotations;

namespace AMartinezTech.Domain.Utils.ValueObjects;

public class ValueAddress
{
    
    public Guid CountryId { get; init; }
    public Guid RegionId { get; init; }
    public Guid CityId { get; init; }
    public Guid StreetId { get; init; }

    private ValueAddress(Guid countryId, Guid regionId, Guid cityId, Guid streetId)
    {
        CountryId = countryId;
        RegionId = regionId;
        CityId = cityId;
        StreetId = streetId;
    }

    public static ValueAddress Create(Guid countryId, Guid regionId, Guid cityId, Guid streetId)
    {
        if (countryId == Guid.Empty)
            throw new ValidationException($" {ErrorMessages.Get(ErrorType.RequiredField)} - país! ");

        if (regionId == Guid.Empty)
            throw new ValidationException($" {ErrorMessages.Get(ErrorType.RequiredField)} - provincia! ");

        if (cityId == Guid.Empty)
            throw new ValidationException($" {ErrorMessages.Get(ErrorType.RequiredField)} - ciudad! ");



        if (streetId == Guid.Empty)
            throw new ValidationException($" {ErrorMessages.Get(ErrorType.RequiredField)} - calle! ");


        return new ValueAddress(countryId, regionId, cityId, streetId);
    }


}

