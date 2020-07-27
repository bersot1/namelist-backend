using Flunt.Notifications;
using Flunt.Validations;
using nameInList_api.Domain.Commands.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace nameInList_api.Domain.Commands.UserCommand
{
    public class GetAllUserOfListByIdListaCommand : Notifiable, ICommand
    {
        public Guid Id { get; set; }
        public void Validate()
        {
            AddNotifications(
               new Contract()
                   .Requires()
                   .IsEmpty(Id, "IdFacebook", "Campo inválido")
               );
        }
    }
}
