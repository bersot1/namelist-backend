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
    public class DeleteItemHandler : Notifiable, IHandler<DeleteListaCommand>
    {
        private readonly IListaRepository _listaRepository;


        public DeleteItemHandler(IListaRepository listaRepository)
        {
            _listaRepository = listaRepository;

        }
        public ICommandResult Handler(DeleteListaCommand command)
        {
            command.Validate();
            if (command.Invalid) return new GenericCommandResult(false, "Alguma coisa deu errado", command.Notifications);

            var lista = _listaRepository.GetById(command.IdList);

            _listaRepository.DeleteLista(lista);

            return new GenericCommandResult(true, "sucesso", "");
        }
    }
}
