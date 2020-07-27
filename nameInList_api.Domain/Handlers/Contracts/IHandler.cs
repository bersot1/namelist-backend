using nameInList_api.Domain.Commands.Contracts;
namespace nameInList_api.Domain.Handlers.Contracts
{
    public interface IHandler<T> where T : ICommand
    {
        ICommandResult Handler(T command);
    }
}
