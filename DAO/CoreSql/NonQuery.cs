using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace DAO.CoreSql
{
    public class NonQuery : INonQuery
    {
        public int ExecNonQuery(string cmdText, DbCommand cmd)
        {
            return ExecNonQuery(cmdText, cmd, null);
        }

        public int ExecNonQuery(string cmdText, DbCommand cmd, DbParameter[] parameters)
        {
            try
            {
                if (cmd == null || string.IsNullOrEmpty(cmdText))
                    throw new ArgumentNullException("Os parâmetros cmdText e cmd são obrigatórios");

                cmd.Parameters.Clear();

                if (parameters != null)
                    cmd.Parameters.AddRange(parameters);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = cmdText;

                return cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                if (cmd.Transaction != null)
                    cmd.Transaction.Rollback();

                throw ex;
            }
        }
    }
}
