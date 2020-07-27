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
    public class GetByIdHandler : Notifiable, IHandler<GetByIdCommand>
    {
        private readonly IListaRepository _listaRepository;


        public GetByIdHandler(IListaRepository listaRepository)
        {
            _listaRepository = listaRepository;
        }
        public ICommandResult Handler(GetByIdCommand command)
        {
            command.Validate();
            if (command.Invalid) return new GenericCommandResult(false, "Sem sucesso", command.Notifications);

            var item = _listaRepository.GetById(command.Id);

            return new GenericCommandResult(true, "sucesso", item);
        }
    }
}
