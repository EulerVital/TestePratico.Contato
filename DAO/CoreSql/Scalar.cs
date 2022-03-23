using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace DAO.CoreSql
{
    public class Scalar : IScalar
    {
        public int ExecScalar(string cmdText, DbCommand cmd, DbParameter[] parameters)
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

                int i = int.Parse(cmd.ExecuteScalar().ToString());

                return i;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int ExecScalar(string cmdText, DbCommand cmd)
        {
            return ExecScalar(cmdText, cmd, null);
        }
    }
}
