namespace MarketListener.Domain.Common;

using System.Collections.Generic;

public class Error
{
    public string Field { get; set; }

    public string Reason { get; set; }

    public List<object> Data { get; set; }
}

public static class ErrorExtension
{
    public static void AddError(this Dictionary<string, Error> invalidObjectDictionary, string reason, string field, object fieldValue)
    {
        invalidObjectDictionary.TryGetValue(reason, out Error error);
        if (error == null)
        {
            error = new Error() { Reason = reason, Field = field, Data = new List<object>() };
            invalidObjectDictionary.Add(reason, error);
        }
        error.Data.Add(fieldValue);
    }
}