using System.Data;

namespace nameInList_api.Domain.Infra.Repositories
{
    public interface IConnectionFactory
    {
        IDbConnection connection();
    }
}
