using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace DAO.CoreSql
{
    public class Reader : IReader
    {
        public bool ColunaExiste(string nome, IDataReader dr)
        {
            var columns = Enumerable.Range(0, dr.FieldCount).Select(dr.GetName).ToList();

            return (columns.Count(c => c.ToLower().Equals(nome.ToLower())) > 0);
        }

        public IDataReader ExecReader(string cmdText, DbCommand cmd)
        {
            return this.ExecReader(cmdText, cmd, null);
        }

        public IDataReader ExecReader(string cmdText, DbCommand cmd, DbParameter[] parameters)
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

                return cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                if (cmd.Transaction != null) cmd.Transaction.Rollback();
                throw ex;
            }
        }

        #region Converts Values IDataReader

        /// <summary>
        /// Converte o valor da coluna do DataReader para Byte 
        /// Usado para o tipo TinyInt do SQL
        /// </summary>
        /// <param name="nome">Nome da coluna</param>
        /// <param name="dr">DataReader carregado na Stored Procedure</param>
        /// <returns>Valor convertido para Byte ou null</returns>
        public byte? GetByteNullable(string nome, IDataReader dr)
        {
            byte? valor = null;

            if (ColunaExiste(nome, dr))
            {

                if (dr.IsDBNull(dr.GetOrdinal(nome)) == false)
                    valor = dr.GetByte(dr.GetOrdinal(nome));
            }

            return valor;
        }

        /// <summary>
        /// Converte o valor da coluna do DataReader para Int16
        /// Usado para o tipo SmallInt do SQL
        /// </summary>
        /// <param name="nome">Nome da coluna</param>
        /// <param name="dr">DataReader carregado na Stored Procedure</param>
        /// <returns>Valor convertido para Int16 ou null</returns>
        public int? GetInt16Nullable(string nome, IDataReader dr)
        {
            int? valor = null;

            if (ColunaExiste(nome, dr))
            {

                if (dr.IsDBNull(dr.GetOrdinal(nome)) == false)
                    valor = dr.GetInt16(dr.GetOrdinal(nome));
            }

            return valor;
        }

        public int? GetInt32Nullable(string nome, IDataReader dr)
        {
            int? valor = null;

            if (ColunaExiste(nome, dr))
            {

                if (dr.IsDBNull(dr.GetOrdinal(nome)) == false)
                    valor = dr.GetInt32(dr.GetOrdinal(nome));
            }

            return valor;
        }


        public int GetInt32(string nome, IDataReader dr)
        {
            int valor = 0;

            if (ColunaExiste(nome, dr))
            {

                if (dr.IsDBNull(dr.GetOrdinal(nome)) == false)
                    valor = dr.GetInt32(dr.GetOrdinal(nome));
            }

            return valor;
        }

        public long? GetInt64Nullable(string nome, IDataReader dr)
        {
            long? valor = null;

            if (ColunaExiste(nome, dr))
            {
                if (dr.IsDBNull(dr.GetOrdinal(nome)) == false)
                    valor = dr.GetInt64(dr.GetOrdinal(nome));
            }

            return valor;
        }

        public long GetInt64(string nome, IDataReader dr)
        {
            long valor = 0;

            if (ColunaExiste(nome, dr))
            {
                if (dr.IsDBNull(dr.GetOrdinal(nome)) == false)
                    valor = dr.GetInt64(dr.GetOrdinal(nome));
            }

            return valor;
        }

        public string GetString(string nome, IDataReader dr)
        {
            string valor = null;

            if (ColunaExiste(nome, dr))
            {
                if (dr[nome] != DBNull.Value)
                {
                    if (dr.IsDBNull(dr.GetOrdinal(nome)) == false)
                        valor = dr.GetString(dr.GetOrdinal(nome)).Trim();
                }
            }

            return valor;
        }

        public bool GetBoolean(string nome, IDataReader /*DataTableReader*/ dr)
        {
            bool valor = false;

            if (ColunaExiste(nome, dr))
            {

                if (dr.IsDBNull(dr.GetOrdinal(nome)) == false)
                    valor = Convert.ToBoolean(dr[nome]);
                //valor = dr.GetBoolean(dr.GetOrdinal(nome));
            }

            return valor;
        }

        public bool GetBooleanNullable(string nome, IDataReader /*DataTableReader*/ dr)
        {
            bool valor = false;

            if (ColunaExiste(nome, dr))
            {

                if (dr.IsDBNull(dr.GetOrdinal(nome)) == false)
                    valor = Convert.ToBoolean(dr[nome]);
                //valor = dr.GetBoolean(dr.GetOrdinal(nome));
            }

            return valor;
        }

        public bool? GetBooleanNullableV(string nome, IDataReader /*DataTableReader*/ dr)
        {
            bool? valor = null;

            if (ColunaExiste(nome, dr))
            {

                if (dr.IsDBNull(dr.GetOrdinal(nome)) == false)
                    valor = Convert.ToBoolean(dr[nome]);
                //valor = dr.GetBoolean(dr.GetOrdinal(nome));
            }

            return valor;
        }

        public DateTime GetDateTime(string nome, IDataReader dr)
        {
            DateTime valor = new DateTime();

            if (ColunaExiste(nome, dr))
            {

                if (dr.IsDBNull(dr.GetOrdinal(nome)) == false)
                    valor = dr.GetDateTime(dr.GetOrdinal(nome));
            }

            return valor;
        }

        public DateTime? GetDateTimeNullable(string nome, IDataReader dr)
        {
            DateTime? valor = null;

            if (ColunaExiste(nome, dr))
            {

                if (dr.IsDBNull(dr.GetOrdinal(nome)) == false)
                    valor = dr.GetDateTime(dr.GetOrdinal(nome));
            }

            return valor;
        }

        public decimal GetDecimal(string nome, IDataReader dr)
        {
            decimal valor = 0;

            if (ColunaExiste(nome, dr))
            {

                if (dr.IsDBNull(dr.GetOrdinal(nome)) == false)
                    valor = dr.GetDecimal(dr.GetOrdinal(nome));
            }

            return valor;
        }

        public decimal? GetDecimalNullable(string nome, IDataReader dr)
        {
            decimal? valor = null;

            if (ColunaExiste(nome, dr))
            {

                if (dr.IsDBNull(dr.GetOrdinal(nome)) == false)
                    valor = dr.GetDecimal(dr.GetOrdinal(nome));
            }

            return valor;
        }

        #endregion
    }
}
