using nameInList_api.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace nameInList_api.Domain.Repositories
{
    public interface IUserRepository
    {
        void CreateUser(UserEntity user);
        UserEntity GetById(Guid id);
        UserEntity GetByEmail(string email);

        Task<IEnumerable<dynamic>> GetAllUsersOfListById(Guid id);

    }
}
