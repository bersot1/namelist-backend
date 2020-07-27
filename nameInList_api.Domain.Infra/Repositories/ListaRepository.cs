using Dapper;
using Microsoft.EntityFrameworkCore;
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
    public class ListaRepository : IListaRepository
    {
        private readonly DataContext _context;
        private readonly IConnectionFactory connection;

        public ListaRepository(DataContext context, IConnectionFactory connection)
        {
            _context = context;
            this.connection = connection;
        }
        public void CreateNewLista(ListaEntity lista)
        {
            _context.Listas.Add(lista);
            _context.SaveChanges();
        }

        public void DeleteLista(ListaEntity lista)
        {
        
            _context.Listas.Remove(lista);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<dynamic>> GetAllByIdCriator(Guid idCreator)
        {

            using (var connectionDb = connection.connection())
            {
                connectionDb.Open();
               
                var query = "SELECT L.Id as id, L.Name as name, L.Start as start, L.Description as description, L.CriatorId as criatorId, L.Codigo as codigo, L.Password as password FROM Listas L WHERE L.CriatorId = '" + idCreator + "'";

                var data = await connectionDb.QueryAsync<dynamic>(query);


                return data;
            }
        }

        public async Task<IEnumerable<dynamic>> GetAllMySubscriptions(Guid idUser)
        {
            using (var connectionDb = connection.connection())
            {
                connectionDb.Open();

                var query =

                "SELECT UL.ListaId, L.Name, L.Description, CONCAT(U.FristName, ' ', U.LastName) as Criador, L.Codigo, L.password " +

                "FROM UserListas UL " +

                "INNER JOIN Listas L ON L.id = UL.ListaId " +
                "INNER JOIN Users U ON U.id = L.CriatorId " +


                "where UserId = '" + idUser + "'";


                var data = await connectionDb.QueryAsync<dynamic>(query);


                return data;
            }
        }

        public ListaEntity GetByCodigo(string codigo)
        {
           var lista =  _context.Listas.FirstOrDefault(x => x.Codigo == codigo);

            if (lista == null)
            {
               return new ListaEntity("", DateTime.Now, "", "", "", Guid.NewGuid());
            }
            else
            {
                return lista;

            }
            
             
        }

        public ListaEntity GetById(Guid id)
        {
            return _context.Listas.FirstOrDefault(x => x.Id == id);

        }

        public ListaEntity GetByIdListAndIdUser(Guid idLista, Guid idUser)
        {
            throw new NotImplementedException();
        }
    }
}
