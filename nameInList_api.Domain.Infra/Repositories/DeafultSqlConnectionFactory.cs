using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace nameInList_api.Domain.Infra.Repositories
{
    public class DeafultSqlConnectionFactory : IConnectionFactory
    {
        public IDbConnection connection()
        {
            return new SqlConnection("Server=123;Database=123;User Id=123;Password=123;");
        }
    }
}
