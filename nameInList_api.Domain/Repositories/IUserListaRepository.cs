using nameInList_api.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace nameInList_api.Domain.Repositories
{
    public interface IUserListaRepository
    {
        void CreateUserList(UserListaEntity userList);

        IEnumerable<UserListaEntity> GetAllUserByIdLista(Guid idLista);

        void DeleteUserList(Guid IdList, Guid IdUser);
    }
}
