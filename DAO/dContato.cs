using DAO.Interface;
using ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;

namespace DAO
{
    public class dContato : CoreSql.CoreSqlServer, IOperacoesDAO<eContato>
    {
        public dContato(string connectionString):base(connectionString)
        {

        }

        public IEnumerable<eContato> Get(eContato obj)
        {
            IDataReader dr = null;
            IList<eContato> lista = new List<eContato>();

            try
            {
                OpenConnection.Creator()
                              .Open();

                dr = Reader.ExecReader("usp_contato_get", OpenConnection.Command);

                if (dr != null)
                    while (dr.Read())
                        lista.Add(SetObject(dr));

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                OpenConnection.Close();
            }
        }

        public int Set(eContato obj)
        {
            SqlParameter[] param = null;
            try
            {
                OpenConnection.Creator()
                              .Open();

                param = new SqlParameter[4];

                MontarParametro(0, param, ParameterDirection.Input, "@Id", ObterValorOuDBNull<int>(obj.Id), SqlDbType.Int);
                MontarParametro(1, param, ParameterDirection.Input, "@Nome", obj.Nome, SqlDbType.VarChar);
                MontarParametro(2, param, ParameterDirection.Input, "@TelefoneResidencial", obj.TelefoneResidencial, SqlDbType.VarChar);
                MontarParametro(3, param, ParameterDirection.Input, "@Celular", obj.Celular, SqlDbType.VarChar);

                return Scalar.ExecScalar("usp_contato_set", OpenConnection.Command, param);
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { OpenConnection.Close(); }
        }

        public int Del(int id)
        {
            SqlParameter[] param = null;
            try
            {
                OpenConnection.Creator()
                              .Open();

                param = new SqlParameter[1];

                MontarParametro(0, param, ParameterDirection.Input, "@Id", id, SqlDbType.Int);

                return NonQuery.ExecNonQuery("usp_contato_del", OpenConnection.Command, param);
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { OpenConnection.Close(); }
        }

        public eContato SetObject(IDataReader dr)
        {
            eContato obj = null;

            try
            {
                obj = new eContato();
                obj.Id = Reader.GetInt32("Id", dr);
                obj.Nome = Reader.GetString("Nome", dr);
                obj.TelefoneResidencial = Reader.GetString("TelefoneResidencial", dr);
                obj.Celular = Reader.GetString("Celular", dr);
                obj.Excluido = Reader.GetBoolean("Excluido", dr);

                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
