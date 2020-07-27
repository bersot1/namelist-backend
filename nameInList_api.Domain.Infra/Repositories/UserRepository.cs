using Dapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using nameInList_api.Domain.Entities;
using nameInList_api.Domain.Infra.Context;
using nameInList_api.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nameInList_api.Domain.Infra.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;
        private readonly IConnectionFactory connection;


        public UserRepository(DataContext context, IConnectionFactory connection)
        {
            _context = context;
            this.connection = connection;
        }

        public void CreateUser(UserEntity user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<dynamic>> GetAllUsersOfListById(Guid id)
        {
            using (var connectionDb = connection.connection())
            {
                connectionDb.Open();

                var query = "SELECT U.Id as id,U.FristName as fristName , U.LastName as lastName, U.Email as email, U.Photo as photo, U.ExternalId as externalId FROM UserListas UL INNER JOIN Users U on U.Id = UL.UserId WHERE UL.ListaId ='" + id + "'";

                var result = await connectionDb.QueryAsync<dynamic>(query);

       

                return result;
            }
        }

        public UserEntity GetByEmail(string email)
        {
            return _context.Users.FirstOrDefault(x => x.Email == email);
        }

        public UserEntity GetById(Guid id)
        {
            return _context.Users.FirstOrDefault(x => x.Id == id);
        }

     
    }
}
