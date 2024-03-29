﻿namespace MarketListener.Domain.Enums.Error;

public enum Status
{
    Duplicate = 7,
    Ok = 200,
    BadRequest = 400,
    Unauthorized = 401,
    Forbidden = 403,
    NotFound = 404,
    InternalServerError = 500,
    ExternalServerError = 999,
    NotImplemented = 501,
}