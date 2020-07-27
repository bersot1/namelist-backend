using Flunt.Notifications;
using Flunt.Validations;
using nameInList_api.Domain.Commands.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace nameInList_api.Domain.Commands.UserListaCommand
{
    public class RemoveUserOfListCommand : Notifiable, ICommand
    {
        public RemoveUserOfListCommand(Guid listId, Guid userId)
        {
            ListId = listId;
            UserId = userId;
        }

        public Guid ListId { get; set; }
        public Guid UserId { get; set; }
        public void Validate()
        {
            AddNotifications(
                new Contract()
                .Requires()
                .IsNotNull(ListId, "Lista ID", "Campo inválido")
                .IsNotNull(UserId, "UserId", "Campo inválido")
                );
        }
    }

}
