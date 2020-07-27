using Flunt.Notifications;
using Flunt.Validations;
using nameInList_api.Domain.Commands.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace nameInList_api.Domain.Commands.ListaCommand
{
    class GetListByCodigoCommand : Notifiable, ICommand
    {
        public string Codigo { get; set; }
        public void Validate()
        {
            AddNotifications(
                new Contract()
                .Requires()
                .IsNotNull(Codigo, "Codigo", "Não pode ser nulo"));
        }
    }
}
