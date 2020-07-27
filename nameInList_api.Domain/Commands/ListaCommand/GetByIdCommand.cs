using Flunt.Notifications;
using Flunt.Validations;
using nameInList_api.Domain.Commands.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace nameInList_api.Domain.Commands.ListaCommand
{
    public class GetByIdCommand : Notifiable, ICommand
    {
        public GetByIdCommand() { }
        public GetByIdCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }


        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .IsEmpty(Id, "id", "Campo inválido")
                );
        }
    }
}
