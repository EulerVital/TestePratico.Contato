using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;

namespace DAO.CoreSql
{
    public class OpenConnectionSqlServer : OpenConnection
    {
        public OpenConnectionSqlServer(string connectionString) : base(connectionString)
        {
        }

        public OpenConnectionSqlServer(string connectionString, DbTransaction transaction) : base(connectionString, transaction)
        {
            
        }

        public override OpenConnection Creator()
        {
            ValidarConnectionString();

            try
            {
                Connection = new SqlConnection(ConnectionString);
                Command = new SqlCommand();

                isExcutouCreator = true;

                return this;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
