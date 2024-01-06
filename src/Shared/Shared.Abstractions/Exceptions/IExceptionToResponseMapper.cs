namespace Shared.Abstractions;

public interface IExceptionToResponseMapper
{
    ExceptionResponse Map(Exception exception);
}
