namespace Account.Core;


internal class UserNotFoundException : CustomException
{
    public Guid Id { get;}

    public UserNotFoundException(Guid id) : base($"User with id: {id} not found") => Id = id;

}
