using nameInList_api.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace nameInList_api.Domain.Repositories
{
    public interface IListaRepository
    {
        void CreateNewLista(ListaEntity lista);

        Task<IEnumerable<dynamic>> GetAllByIdCriator(Guid idCreator);
        ListaEntity GetById(Guid id);
        ListaEntity GetByCodigo(string codigo);

        ListaEntity GetByIdListAndIdUser(Guid idLista, Guid idUser);

        void DeleteLista(ListaEntity lista);

        Task<IEnumerable<dynamic>> GetAllMySubscriptions(Guid idUser);
    }
}

