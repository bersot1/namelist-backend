using Flunt.Notifications;
using nameInList_api.Domain.Commands;
using nameInList_api.Domain.Commands.Contracts;
using nameInList_api.Domain.Commands.ListaCommand;
using nameInList_api.Domain.Handlers.Contracts;
using nameInList_api.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace nameInList_api.Domain.Handlers.ListaHandlers
{
    public class GetAllByIdCriatorHandler : Notifiable, IHandler<GetAllByIdCriatorCommand>
    {
        private readonly IListaRepository _listaRepository;
        

        public GetAllByIdCriatorHandler(IListaRepository listaRepository)
        {
            _listaRepository = listaRepository;
        }
        public ICommandResult Handler(GetAllByIdCriatorCommand command)
        {
            command.Validate();
            if (command.Invalid) return new GenericCommandResult(false, "Sem Sucesso", command.Notifications);

            var listas = _listaRepository.GetAllByIdCriator(command.IdCriator);

            return new GenericCommandResult(true, "Sucesso", listas);
        }
    }
}
