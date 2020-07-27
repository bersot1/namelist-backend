using Flunt.Notifications;
using Flunt.Validations;
using nameInList_api.Domain.Commands.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace nameInList_api.Domain.Commands.ListaCommand
{
    public class GetAllByIdCriatorCommand : Notifiable, ICommand
    {
        public GetAllByIdCriatorCommand() { }
        public GetAllByIdCriatorCommand(Guid idCriator)
        {
            IdCriator = idCriator;
        }

        public Guid IdCriator { get; set; }


        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .IsEmpty(IdCriator, "id", "Campo inválido")
                );
        }
    }
}
