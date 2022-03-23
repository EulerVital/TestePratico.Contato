using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DAO.Interface
{
    public interface IOperacoesDAO<T>
    {
        IEnumerable<T> Get(T obj);

        int Set(T obj);

        T SetObject(IDataReader dr);

        int Del(int id);
    }
}
