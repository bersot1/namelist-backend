using Microsoft.AspNetCore.Mvc;
using nameInList_api.Domain.Commands;
using nameInList_api.Domain.Commands.ListaCommand;
using nameInList_api.Domain.Entities;
using nameInList_api.Domain.Handlers.ListaHandlers;
using nameInList_api.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace nameInList_api.Domain.Api.Controllers
{
    [ApiController]
    [Route("v1/lista")]
    public class ListaController : ControllerBase
    {
        [Route("")]
        [HttpPost]
        public GenericCommandResult Create(
            [FromBody]CreateListaCommand command,
            [FromServices]CreateListaHandler handler
        )
        {

            return (GenericCommandResult)handler.Handler(command);
        }

        [HttpGet]
        [Route("GetAllByIdCriator/{idCriator}")]
        public Task<IEnumerable<dynamic>> GetAllByIdCriator([FromServices]IListaRepository repository, Guid idCriator)
        {
            //var user = repository.GetByIdFacebook(idFacebook);

            var result = repository.GetAllByIdCriator(idCriator);
            return result;
        }

        [HttpGet]
        [Route("GetAllMySubscription/{idUser}")]
        public Task<IEnumerable<dynamic>> GetAllMySubscription([FromServices]IListaRepository repository, Guid idUser)
        {

            var result = repository.GetAllMySubscriptions(idUser);
            return result;

        }



        [HttpGet]
        [Route("GetByCodigo/{codigo}")]
        public ListaEntity GetByCodigo([FromServices]IListaRepository repository, string codigo)
        {
            //var user = repository.GetByIdFacebook(idFacebook);

            var result = repository.GetByCodigo(codigo);
            return result;
        }

        [HttpGet]
        [Route("GetAllById/{id}")]
        public ListaEntity GetAllById([FromServices]IListaRepository repository, Guid id)
        {
            //var user = repository.GetByIdFacebook(idFacebook);

            var result = repository.GetById(id);
            return result;

        }



        [HttpDelete]
        [Route("")]
        public GenericCommandResult DeleteLista(
            [FromBody]DeleteListaCommand command,
            [FromServices]DeleteItemHandler handler)
        {
            return (GenericCommandResult)handler.Handler(command);


        }
    }
}
