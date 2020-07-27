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
    public class GetAllUsersByIdListaHandler : Notifiable, IHandler<GetAllUserByIdListaCommand>

    {
        private readonly IUserListaRepository _userListaRepository;

        public GetAllUsersByIdListaHandler(IUserListaRepository userListaRepository)
        {
            _userListaRepository = userListaRepository;
        }
        public ICommandResult Handler(GetAllUserByIdListaCommand command)
        {
            command.Validate();
            if (command.Invalid) return new GenericCommandResult(false, "Sem sucesso", command.Notifications);

            var data = _userListaRepository.GetAllUserByIdLista(command.IdLista);

            return new GenericCommandResult(true, "sucesso", data);
        }
    }
}
