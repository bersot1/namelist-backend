using System;
using System.Collections.Generic;
using System.Text;

namespace nameInList_api.Domain.Entities
{
    public class UserEntity : Entity
    {
        public UserEntity(string fristName, string lastName, string email, string photo, string externalId)
        {
            FristName = fristName;
            LastName = lastName;
            Email = email;
            Photo = photo;
            ExternalId = externalId;
        }

        public string FristName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Photo { get; set; }
        public string ExternalId { get; set; }
        public ICollection<UserListaEntity> UserList { get; set; }

    }
}
