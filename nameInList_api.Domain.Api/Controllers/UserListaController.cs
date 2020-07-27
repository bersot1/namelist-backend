using Microsoft.AspNetCore.Mvc;
using nameInList_api.Domain.Commands;
using nameInList_api.Domain.Commands.UserListaCommand;
using nameInList_api.Domain.Handlers.UserListaHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace nameInList_api.Domain.Api.Controllers
{
    [ApiController]
    [Route("v1/userLista")]
    public class UserListaController : ControllerBase
    {

        [Route("")]
        [HttpPost]
        public GenericCommandResult Create(
           [FromBody]CreateUserListaCommand command,
           [FromServices]CreateUserListaHandler handler
       )
        {

            return (GenericCommandResult)handler.Handler(command);
        }

        [Route("")]
        [HttpDelete]
        public GenericCommandResult Delete([FromBody]RemoveUserOfListCommand command,[FromServices]DeleteUserListHandler handler)
        {
            return (GenericCommandResult)handler.Handler(command);
        }

    }
}
