using Flunt.Notifications;
using nameInList_api.Domain.Commands;
using nameInList_api.Domain.Commands.Contracts;
using nameInList_api.Domain.Commands.UserListaCommand;
using nameInList_api.Domain.Handlers.Contracts;
using nameInList_api.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace nameInList_api.Domain.Handlers.UserListaHandler
{
    public class DeleteUserListHandler : Notifiable, IHandler<RemoveUserOfListCommand>
    {
        private readonly IUserListaRepository _userListRepository;

        public DeleteUserListHandler(IUserListaRepository userListRepository)
        {
            _userListRepository = userListRepository;
        }
        public ICommandResult Handler(RemoveUserOfListCommand command)
        {
            command.Validate();
            if (command.Invalid) return new GenericCommandResult(false, "Alguma coisa deu errada", command.Notifications);

            _userListRepository.DeleteUserList(command.ListId, command.UserId);


            return new GenericCommandResult(true, "Sucesso", "excluido com sucesso");



        }
    }
}
