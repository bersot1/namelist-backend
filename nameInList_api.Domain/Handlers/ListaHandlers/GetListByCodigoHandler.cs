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
    class GetListByCodigoHandler : Notifiable, IHandler<GetListByCodigoCommand>
    {
        private readonly IListaRepository _listaRepository;


        public GetListByCodigoHandler(IListaRepository listaRepository)
        {
            _listaRepository = listaRepository;
        }

        public ICommandResult Handler(GetListByCodigoCommand command)
        {
            command.Validate();
            if (command.Invalid) return new GenericCommandResult(false, "alguma coisa deu errado", command.Notifications);

            var lista = _listaRepository.GetByCodigo(command.Codigo);

            return new GenericCommandResult(true, "Sucesso", lista);
        }
    }
}
