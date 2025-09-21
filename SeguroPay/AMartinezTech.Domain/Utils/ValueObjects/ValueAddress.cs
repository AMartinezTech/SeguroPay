using AMartinezTech.Domain.Utils.Exception;
using System.ComponentModel.DataAnnotations;

namespace AMartinezTech.Domain.Utils.ValueObjects;

public class ValueAddress
{
    private ValueAddress(Guid countryId, Guid regionId, Guid cityId, Guid postalCodeId, Guid streetId)
    {
        CountryId = countryId;
        RegionId = regionId;
        CityId = cityId;
        PostalCodeId = postalCodeId;
        StreetId = streetId;
    }

    public Guid CountryId { get; init; }
    public Guid RegionId { get; init; }
    public Guid CityId { get; init; }
    public Guid PostalCodeId { get; init; }
    public Guid StreetId { get; init; }

 

    public static ValueAddress Create(Guid countryId, Guid regionId, Guid cityId, Guid postalCodeId, Guid streetId)
    {
        if (countryId == Guid.Empty)
            throw new ValidationException($" {ErrorMessages.Get(ErrorType.RequiredField)} - país! ");  

        if (regionId == Guid.Empty)
            throw new ValidationException($" {ErrorMessages.Get(ErrorType.RequiredField)} - provincia! ");

        if (cityId == Guid.Empty)
            throw new ValidationException($" {ErrorMessages.Get(ErrorType.RequiredField)} - ciudad! ");

        if (postalCodeId == Guid.Empty)
            throw new ValidationException($" {ErrorMessages.Get(ErrorType.RequiredField)} - código postal! ");

        if (streetId == Guid.Empty)
            throw new ValidationException($" {ErrorMessages.Get(ErrorType.RequiredField)} - calle! ");


        return new ValueAddress(countryId, regionId, cityId, postalCodeId, streetId);
    }


}

