using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace DAO.CoreSql
{
    public interface IReader
    {
        /// <summary>
        /// Executa comando no banco de dados.
        /// </summary>
        /// <param name="cmdText">Procedure/query a ser executada</param>
        /// <param name="cmd">Conexão com o banco de dados</param>
        /// <returns>Retorna as informações selecionadas</returns>
        IDataReader ExecReader(string cmdText, DbCommand cmd);

        /// <summary>
        /// Executa comando no banco de dados.
        /// </summary>
        /// <param name="cmdText">Procedure/query a ser executada</param>
        /// <param name="parameters">Parametros da procedures/query</param>
        /// <param name="cmd">Conexão com o banco de dados</param>
        /// <returns>Retorna as informações selecionadas</returns>
        IDataReader ExecReader(string cmdText, DbCommand cmd, DbParameter[] parameters);

        /// <summary>
        /// Valida se a coluna existe no resultado da consulta SQL, evitando o erro quando adicionado nova coluna
        /// </summary>
        bool ColunaExiste(string nome, IDataReader dr);
    }
}
