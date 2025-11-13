namespace AMartinezTech.Domain.Utils.Exception;

public enum ErrorType
{
    RequiredField,
    InvalidFormat,
    InvalidType,
    MaxLength,
    MinLength,
    NoNegativeNum,
    PostiveNum,
    RangeValid,
    NullDetails,
    RecordDoesDotExist,
    RecordCreateError,
    RecordUpdateError,
    RecordDeleteError,
    DataBaseUnknownError,
    PasswordNotMatch,
    InvalidCredentials,
    HasMomevements,
    InvalidUser
}
