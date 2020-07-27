using System;
using System.Collections.Generic;
using System.Text;

namespace nameInList_api.Domain.Entities
{
    public class UserListaEntity : Entity
    {
        public UserListaEntity(DateTime register, Guid userId, Guid listaId)
        {
            Register = register;
            UserId = userId;
            ListaId = listaId;
  
        }

        public DateTime Register { get; set; }
        public Guid UserId { get; set; }
        public UserEntity User { get; set; }
        public Guid ListaId { get; set; }
        public ListaEntity Lista { get; set; }
        

    }
}
