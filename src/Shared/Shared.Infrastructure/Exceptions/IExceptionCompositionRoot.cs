namespace Shared.Infrastructure;

public interface IExceptionCompositionRoot
{
    ExceptionResponse Map(Exception exception);
}
