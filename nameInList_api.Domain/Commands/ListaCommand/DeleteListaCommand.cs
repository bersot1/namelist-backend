using Flunt.Notifications;
using Flunt.Validations;
using nameInList_api.Domain.Commands.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace nameInList_api.Domain.Commands.ListaCommand
{
    public class DeleteListaCommand : Notifiable, ICommand
    {

        public DeleteListaCommand() { }
        public DeleteListaCommand(Guid idList)
        {
            IdList = idList;
        }

        public Guid IdList{ get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                .Requires()
                .IsNotEmpty(IdList, "idLista", "Compo idLista Inválido"));
        }
    }
}
