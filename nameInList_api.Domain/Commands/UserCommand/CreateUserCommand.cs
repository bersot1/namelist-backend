using Flunt.Notifications;
using Flunt.Validations;
using nameInList_api.Domain.Commands.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace nameInList_api.Domain.Commands.UserCommand
{
   public class CreateUserCommand : Notifiable, ICommand
    {
        public CreateUserCommand () { }
 

        public string FristName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Photo { get; set; }
        public string ExternalId { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .HasMinLen(FristName, 3, "First Name", "O item não pode ter menos de 3 caracteres")
                    .HasMinLen(LastName, 3, "LastName", "O item não pode ter menos de 3 caracteres")
                    .IsEmail(Email, "Email", "Email inválido")
                );
        }
    }
}
