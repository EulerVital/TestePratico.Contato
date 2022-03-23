using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace DAO.CoreSql
{
    public abstract class Core<TOpenConnection>
    {
        protected Scalar Scalar { get; set; }
        protected NonQuery NonQuery { get; set; }
        protected Reader Reader { get; set; }

        protected TOpenConnection OpenConnection { get; set; }

        public Core(string connectionString)
        {
            Scalar = new Scalar();
            NonQuery = new NonQuery();
            Reader = new Reader();
        }

        /// <summary>
        /// Monta os parâmetros para execução da Stored Procedure.
        /// </summary>
        /// <param name="item">Indice do parâmetro</param>
        /// <param name="parametros">array de parâmetro a ser montado</param>
        /// <param name="direction">Direção do parametro(input/output)</param>
        /// <param name="nome">Nome do parametro(@id)</param>
        /// <param name="valor">Valor do parametro</param>
        /// <param name="dbType">Tipo de dado do parametro</param>
        protected void MontarParametro
            (int item, DbParameter[] parametros, ParameterDirection direction,
                string nome, object valor, SqlDbType dbType)
        {
            parametros[item] = NewInstance();
            parametros[item].Direction = direction;
            parametros[item].ParameterName = nome;

            DefineValorTypeParameter(parametros[item], valor, dbType);
        }

        /// <summary>
        /// Retorna o valor do parâmetro ou DBNull caso o objeto seja nulo
        /// </summary>
        /// <typeparam name="T">Tipo para o caso de parâmetros NULLABLE</typeparam>
        /// <param name="n">O parâmetro NULLABLE</param>
        /// <returns>O valor do parâmetro ou DBNull </returns>
        protected static object ObterValorOuDBNull<T>(Nullable<T> n) where T : struct
        {
            if (n.HasValue)
                return n.Value;
            else
                return DBNull.Value;
        }

        /// <summary>
        /// Converte um DataReader para um DataSet
        /// </summary>
        /// <param name="reader">DataReader que será convertido</param>
        /// <returns>DataSet preenchido com o conteúdo do DataReader</returns>
        protected static DataSet ConverterDataReaderParaDataSet(IDataReader reader)
        {
            DataSet dataSet = new DataSet();

            do
            {
                ///Cria um novo data table
                DataTable schemaTable = reader.GetSchemaTable();
                DataTable dataTable = new DataTable();

                if (schemaTable != null)
                {
                    ///Varre os registos encontrados
                    for (int i = 0; i < schemaTable.Rows.Count; i++)
                    {
                        DataRow dataRow = schemaTable.Rows[i];
                        ///Cria o nome da coluna que é unico no data table
                        string columnName = (string)dataRow["ColumnName"]; //+ "<C" + i + "/>";
                        ///Adiciona a coluna para o data table
                        DataColumn column = new DataColumn(columnName, (Type)dataRow["DataType"]);
                        dataTable.Columns.Add(column);
                    }

                    dataSet.Tables.Add(dataTable);

                    ///Preenche o data table que foi criado
                    while (reader.Read())
                    {
                        DataRow dataRow = dataTable.NewRow();

                        for (int i = 0; i < reader.FieldCount; i++)
                            dataRow[i] = reader.GetValue(i);

                        dataTable.Rows.Add(dataRow);
                    }
                }
                else
                {
                    ///Nenhum registro encontrado
                    DataColumn column = new DataColumn("RowsAffected");
                    dataTable.Columns.Add(column);
                    dataSet.Tables.Add(dataTable);
                    DataRow dataRow = dataTable.NewRow();
                    dataRow[0] = reader.RecordsAffected;
                    dataTable.Rows.Add(dataRow);
                }
            }

            while (reader.NextResult());
            return dataSet;
        }

        protected abstract DbParameter NewInstance();

        protected abstract DbParameter DefineValorTypeParameter(DbParameter dbParameter, object valor, SqlDbType dbType);
    }
}
