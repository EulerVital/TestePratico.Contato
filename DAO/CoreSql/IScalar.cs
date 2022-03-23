using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace DAO.CoreSql
{
    public interface IScalar
    {
        int ExecScalar(string cmdText, DbCommand cmd);
        int ExecScalar(string cmdText, DbCommand cmd, DbParameter[] parameters);
    }
}
