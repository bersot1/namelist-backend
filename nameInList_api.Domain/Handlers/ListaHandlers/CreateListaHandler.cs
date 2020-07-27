using Flunt.Notifications;
using nameInList_api.Domain.Commands;
using nameInList_api.Domain.Commands.Contracts;
using nameInList_api.Domain.Commands.ListaCommand;
using nameInList_api.Domain.Entities;
using nameInList_api.Domain.Handlers.Contracts;
using nameInList_api.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace nameInList_api.Domain.Handlers.ListaHandlers
{
    public class CreateListaHandler : Notifiable, IHandler<CreateListaCommand> 
    {
        private readonly IListaRepository _listaRepository;
   

        public CreateListaHandler(IListaRepository listaRepository, IUserRepository userRepository)
        {
            _listaRepository = listaRepository;
           
        }

        public ICommandResult Handler(CreateListaCommand command)
        {
            command.Validate();
            if (command.Invalid) return new GenericCommandResult(false, "Alguma coisa deu errado", command.Notifications);


            var newLista = new ListaEntity(
                command.Name,
                command.Start,
                command.Description,
                Guid.NewGuid().ToString().Substring(0, 7),
                command.Pass,
                command.CriadorId
                );


            _listaRepository.CreateNewLista(newLista);

            return new GenericCommandResult(true, "Sucesso", newLista);
        }
    }
}
