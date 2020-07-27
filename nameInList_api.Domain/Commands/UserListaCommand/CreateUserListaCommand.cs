using Flunt.Notifications;
using Flunt.Validations;
using nameInList_api.Domain.Commands.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace nameInList_api.Domain.Commands.UserListaCommand
{
    public class CreateUserListaCommand : Notifiable, ICommand
    {
        public CreateUserListaCommand() { }
        public CreateUserListaCommand(DateTime register, Guid idLista, Guid idUser)
        {
            Register = register;
            IdLista = idLista;
            IdUser = idUser;
        }

        public DateTime Register { get; set; }
        public Guid IdLista { get; set; }
        public Guid IdUser { get; set; }


        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .IsNotEmpty(IdLista, "idLista","Campo inválido")
                    .IsNotEmpty(IdUser, "IdUser", "Campo inválido")
                );
        }
    }
}
