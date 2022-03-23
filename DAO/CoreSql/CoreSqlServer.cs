using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;

namespace DAO.CoreSql
{
    public class CoreSqlServer : Core<OpenConnectionSqlServer>
    {
        public CoreSqlServer(string connectionString):base(connectionString)
        {
            OpenConnection = new OpenConnectionSqlServer(connectionString);
        }

        protected override DbParameter NewInstance()
        {
            return new SqlParameter();
        }

        protected override DbParameter DefineValorTypeParameter(DbParameter dbParameter, object valor, SqlDbType dbType)
        {
            if (dbParameter == null)
                throw new Exception("dbParameter não pode ser nulo");

            var param = (SqlParameter)dbParameter;
            param.SqlDbType = dbType;
            param.SqlValue = valor ?? DBNull.Value;

            return param;
        }
    }
}
