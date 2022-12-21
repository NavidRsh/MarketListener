namespace MarketListener.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public enum ApiStatus
{
    Ok = 200,
    BadRequest = 400,
    Unauthorized = 401,
    Forbidden = 403,
    NotFound = 404,
    PreconditionFailed = 412,
    UnsupportedMediaType = 415,
    Locked = 423,
    FailedDependency = 424,
    PreconditionRequired = 428,
    TooManyRequests = 429,
    UnavailableForLegalReasons = 451,
    InternalServerError = 500,
    NotImplemented = 501,
    StepPersonalInformation = 290,
    StepDocuments = 291,
    StepAddress = 292,
    StepWork = 293,
    StepBankAccount = 294,
    StepOtherInformation = 295,
    StepExam = 296
}
