using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace DAO.CoreSql
{
    public interface IOpenConnection
    {
        /// <summary>
        /// Abre a conexão com o banco de dados
        /// </summary>
        OpenConnection Open();

        /// <summary>
        /// Fecha a conexão com o banco de dados
        /// </summary>
        OpenConnection Close();

        /// <summary>
        /// Abre a conexão ultilizando transação
        /// </summary>
        OpenConnection OpenTrans(DbCommand command = null);

        /// <summary>
        /// Responsavel por instanciar as classes de conexões, essa função é implementada pela classe do tipo, por exemplo (OpenConnectionSqlServer)
        /// </summary>
        /// <returns></returns>
        OpenConnection Creator();
    }
}
