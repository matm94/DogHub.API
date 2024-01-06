namespace Shared.Abstractions;

public record ExceptionResponse(object Response, HttpStatusCode StatusCode);
