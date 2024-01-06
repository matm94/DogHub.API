﻿namespace Shared.Infrastructure;

public class ExceptionToResponseMapper : IExceptionToResponseMapper
{
    private static readonly ConcurrentDictionary<Type, string> Codes = new();
    public ExceptionResponse Map(Exception exception)
        => exception switch 
        {
            CustomException ex => new ExceptionResponse(
                new ErrorsResponse(new Error(GetErrorCode(ex), ex.Message)), HttpStatusCode.BadRequest),

            _ => new ExceptionResponse(
                 new ErrorsResponse(new Error("error", "There was an error")), HttpStatusCode.InternalServerError
            )
        };
    
    private record Error(string Code, string Message);

    private record ErrorsResponse(params Error[] Errors);

    private static string GetErrorCode(object exception)
    {
        var type = exception.GetType();
        var code = type.Name.Underscore().Replace("_exception", string.Empty);
        return Codes.GetOrAdd(type, code);
    }
}
