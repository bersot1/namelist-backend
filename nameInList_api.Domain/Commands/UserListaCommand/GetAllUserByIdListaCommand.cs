using Flunt.Notifications;
using Flunt.Validations;
using nameInList_api.Domain.Commands.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace nameInList_api.Domain.Commands.UserListaCommand
{
    public class GetAllUserByIdListaCommand : Notifiable, ICommand
    {

        public GetAllUserByIdListaCommand() { }
        public GetAllUserByIdListaCommand(Guid idLista)
        {
            IdLista = idLista;
        }

        public Guid IdLista { get; set; }


        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .IsEmpty(IdLista, "id", "Campo inválido")
                );
        }
    }
}
