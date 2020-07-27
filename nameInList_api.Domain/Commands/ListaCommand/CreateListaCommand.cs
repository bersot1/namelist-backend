using Flunt.Notifications;
using Flunt.Validations;
using nameInList_api.Domain.Commands.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace nameInList_api.Domain.Commands.ListaCommand
{
    public class CreateListaCommand : Notifiable, ICommand
    {
        public CreateListaCommand(string name, DateTime start, string description, Guid idCriador, string pass)
        {
            Name = name;
            Start = start;
            Description = description;
            CriadorId = idCriador;
            Pass = pass;
        }

        public string Name { get; set; }
        public DateTime Start { get; set; }
        public string Description { get; set; }
        public Guid CriadorId { get; set; }
        public string Pass { get; set; }


        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .HasMinLen(Name, 3, "First Name", "O item não pode ter menos de 3 caracteres")
                    .HasMinLen(Description, 10, "Description", "O item não pode ter menos de 10 caracteres")

                );
        }
    }
}
