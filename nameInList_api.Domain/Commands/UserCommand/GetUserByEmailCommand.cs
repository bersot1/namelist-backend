using Flunt.Notifications;
using Flunt.Validations;
using nameInList_api.Domain.Commands.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace nameInList_api.Domain.Commands.UserCommand
{
    public class GetUserByEmailCommand : Notifiable, ICommand
    {
        public GetUserByEmailCommand() { }

        public GetUserByEmailCommand(string email)
        {
            Email = email;
        }

        public string Email { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                .Requires()
                .IsEmail(Email, "Email", "Email não é válido"));
        }
    }
}
