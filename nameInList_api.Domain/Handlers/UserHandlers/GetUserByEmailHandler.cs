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
    public class GetUserByEmailHandler : Notifiable, IHandler<GetUserByEmailCommand>
    {
        private readonly IUserRepository _userRepository;

        public GetUserByEmailHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public ICommandResult Handler(GetUserByEmailCommand command)
        {
            command.Validate();
            if (command.Invalid) return new GenericCommandResult(false, "alguma coisa deu errado", command.Notifications);

            var user = _userRepository.GetByEmail(command.Email);

            return new GenericCommandResult(
                true,
                "sucesso",
                user
                );
        }
    }
}
