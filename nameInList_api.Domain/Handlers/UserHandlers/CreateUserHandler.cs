using Flunt.Notifications;
using nameInList_api.Domain.Commands;
using nameInList_api.Domain.Commands.Contracts;
using nameInList_api.Domain.Commands.UserCommand;
using nameInList_api.Domain.Entities;
using nameInList_api.Domain.Handlers.Contracts;
using nameInList_api.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace nameInList_api.Domain.Handlers.UserHandlers
{
    public class CreateUserHandler : Notifiable, IHandler<CreateUserCommand>
    {

        private readonly IUserRepository _userRepository;

        public CreateUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public ICommandResult Handler(CreateUserCommand command)
        {

            command.Validate();
            if (command.Invalid)
            {
                return new GenericCommandResult(
                    false,
                    "Alguma coisa deu errado",
                    command.Notifications
                    );
            }


            var existUser = _userRepository.GetByEmail(command.Email);

            if (existUser == null)
            {
                 var newUser = new UserEntity(
                   command.FristName,
                   command.LastName,
                   command.Email,
                   command.Photo,
                   command.ExternalId);

                _userRepository.CreateUser(newUser);

                return new GenericCommandResult(true, "sucesso", newUser);
            }else
            {
                return new GenericCommandResult(true, "email já cadastrado", existUser);
            }

          

          


            
        }
    }
}
