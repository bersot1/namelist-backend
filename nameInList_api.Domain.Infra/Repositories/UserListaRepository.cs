using Microsoft.EntityFrameworkCore;
using nameInList_api.Domain.Entities;
using nameInList_api.Domain.Infra.Context;
using nameInList_api.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nameInList_api.Domain.Infra.Repositories
{
    public class UserListaRepository : IUserListaRepository
    {
        private readonly DataContext _context;

        public UserListaRepository(DataContext context)
        {
            _context = context;
        }
        public void CreateUserList(UserListaEntity userList)
        {
            _context.UserListas.AddAsync(userList);
            _context.SaveChanges();
        }

        public void DeleteUserList(Guid IdList, Guid IdUser)
        {
            _context.Remove(_context.UserListas.Single(a => a.ListaId == IdList && a.UserId == IdUser));
            _context.SaveChanges();
        }

        public IEnumerable<UserListaEntity> GetAllUserByIdLista(Guid idLista)
        {
            return _context.UserListas.AsNoTracking().Where(x => x.ListaId == idLista);
        }
    }
}
