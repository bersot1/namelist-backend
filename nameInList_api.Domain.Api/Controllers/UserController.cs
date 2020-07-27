using Microsoft.AspNetCore.Mvc;
using nameInList_api.Domain.Commands;
using nameInList_api.Domain.Commands.UserCommand;
using nameInList_api.Domain.Entities;
using nameInList_api.Domain.Handlers.UserHandlers;
using nameInList_api.Domain.Infra.Context;
using nameInList_api.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace nameInList_api.Domain.Api.Controllers
{
    [ApiController]
    [Route("v1/user")]
    public class UserController : ControllerBase
    {
    
        [HttpGet]
        [Route("getByEmail/{email}")]
        public dynamic getByEmail([FromServices]IUserRepository repository, string email)
        {
            //var user = repository.GetByIdFacebook(idFacebook);

            var result = repository.GetByEmail(email);
          
            return result;
        }

        [Route("")]
        [HttpPost]
        public GenericCommandResult Create(
             [FromBody]CreateUserCommand command,
             [FromServices]CreateUserHandler handler
         )
        {

            return (GenericCommandResult)handler.Handler(command);
        }

        [HttpGet]
        [Route("getAllUsersOfListById/{listaid}")]
        public Task<IEnumerable<dynamic>> GetAllUsersOfListById([FromServices]IUserRepository repository, Guid listaid)
        {


            var result = repository.GetAllUsersOfListById(listaid);
            return result;
        }
    }
}
