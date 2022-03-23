using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace DAO.CoreSql
{
    public interface INonQuery
    {
        /// <summary>
        /// Executa comando no Banco de dados e retorna quantidade de linhas alteradas.
        /// </summary>
        /// <param name="cmdText">Procedure/query a ser executada</param>
        /// <param name="cmd">Conexão com o banco de dados</param>
        /// <returns>Retorna as quantidades de linhas afetadas</returns>
        int ExecNonQuery(string cmdText, DbCommand cmd);

        /// <summary>
        /// Executa comando no Banco de dados e retorna as quantidades de linhas alteradas.
        /// </summary>
        /// <param name="cmdText">Procedure/query a ser executada</param>
        /// <param name="parameters">Parametros da procedures/query</param>
        /// <param name="cmd">Conexão com o banco de dados</param>
        /// <returns>Retorna as quantidades de linhas afetadas</returns>
        int ExecNonQuery(string cmdText, DbCommand cmd, DbParameter[] parameters);
    }
}
