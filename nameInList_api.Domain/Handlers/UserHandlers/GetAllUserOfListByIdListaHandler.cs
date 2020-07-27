using Flunt.Notifications;
using nameInList_api.Domain.Commands;
using nameInList_api.Domain.Commands.Contracts;
using nameInList_api.Domain.Commands.UserCommand;
using nameInList_api.Domain.Handlers.Contracts;
using nameInList_api.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace nameInList_api.Domain.Handlers.UserHandlers
{
    class GetAllUserOfListByIdListaHandler : Notifiable, IHandler<GetAllUserOfListByIdListaCommand>
    {
        private readonly IUserRepository _userRepository;

        public GetAllUserOfListByIdListaHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public ICommandResult Handler(GetAllUserOfListByIdListaCommand command)
        {
            command.Validate();
            if (command.Invalid) return new GenericCommandResult(false, "algo deu errado", command.Notifications);

            var result = _userRepository.GetAllUsersOfListById(command.Id);

            return new GenericCommandResult(true, "Sucess", result);
        }
    }
}
