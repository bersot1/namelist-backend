using Flunt.Notifications;
using nameInList_api.Domain.Commands;
using nameInList_api.Domain.Commands.Contracts;
using nameInList_api.Domain.Commands.UserListaCommand;
using nameInList_api.Domain.Entities;
using nameInList_api.Domain.Handlers.Contracts;
using nameInList_api.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace nameInList_api.Domain.Handlers.UserListaHandler
{
    public class CreateUserListaHandler : Notifiable, IHandler<CreateUserListaCommand>
    {
        private readonly IUserListaRepository _userListaRepository;
        private readonly IUserRepository _userRepository;
        private readonly IListaRepository _listaRepository;

        public CreateUserListaHandler(
            IUserListaRepository userListaRepository,
            IUserRepository userRepository,
            IListaRepository listaRepository)
        {
            _userListaRepository = userListaRepository;
            _userRepository = userRepository;
            _listaRepository = listaRepository;
        }
        public ICommandResult Handler(CreateUserListaCommand command)
        {
            command.Validate();
            if (command.Invalid) return new GenericCommandResult(false, "sem sucesso", command.Notifications);

            var lista = _listaRepository.GetById(command.IdLista);

            var user = _userRepository.GetById(command.IdUser);

            var userList = new UserListaEntity(
                command.Register, command.IdUser, command.IdLista);

            //userList.ListaId = lista.Id;
            //userList.UserId = user.Id;
            //userList.Register = command.Register;
            //userList.Lista = lista;
            //userList.User = user;

            _userListaRepository.CreateUserList(userList);

            return new GenericCommandResult(true, "Sucesso", userList);

            
        }
    }
}
