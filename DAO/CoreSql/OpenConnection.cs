using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;

namespace DAO.CoreSql
{
    public abstract class OpenConnection : IOpenConnection
    {
        public DbCommand Command { get; set; }
        public bool IsTransaction { get; set; }
        public DbTransaction SqlTransaction { get; set; }
        public DbConnection Connection { get; set; }

        #region Atributos Regra

        protected bool isExcutouCreator = false;
        protected readonly string ConnectionString;

        #endregion

        public OpenConnection(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public OpenConnection(string connectionString, DbTransaction transaction)
        {
            ConnectionString = connectionString;

            if (transaction == null)
                throw new ArgumentNullException("O parâmetro transaction não deve ser nulo");
        }

        public OpenConnection Open()
        {
            try
            {
                VerificarExcucaoCreator();

                Connection.Open();
                Command.Connection = Connection;
                return this;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public OpenConnection Close()
        {
            try
            {
                VerificarExcucaoCreator();

                if (Connection != null)
                {
                    if (Connection.State == ConnectionState.Open && SqlTransaction == null)
                    {
                        Connection.Close();
                        Connection.Dispose();
                    }
                }
                if (Command != null) Command.Dispose();

                return this;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public OpenConnection OpenTrans(DbCommand command = null)
        {
            try
            {

                VerificarExcucaoCreator();

                if (command != null)
                    Command = command;

                if (SqlTransaction == null)
                {
                    Open();
                    Command.Transaction = Command.Connection.BeginTransaction();
                    SqlTransaction = Command.Transaction;
                }
                else
                {
                    Command.Connection = SqlTransaction.Connection;
                    Command.Transaction = SqlTransaction;
                }

                IsTransaction = true;

                return this;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public abstract OpenConnection Creator();

        #region Privates

        private void VerificarExcucaoCreator()
        {
            if (!isExcutouCreator)
                throw new InvalidOperationException("É necessário executar o metodo Creator antes de abrir a conexão.");
        }

        #endregion

        #region Protected

        protected void ValidarConnectionString()
        {
            if (string.IsNullOrEmpty(ConnectionString))
                throw new NullReferenceException("ConnectionString não fornecida");
        }

        #endregion
    }
}
