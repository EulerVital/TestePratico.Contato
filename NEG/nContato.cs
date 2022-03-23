using DAO;
using ENT;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;

namespace NEG
{
    public class nContato
    {
        public static IEnumerable<eContato> Get()
        {
            try
            {
                dContato db = new dContato(StringConnection());
                return db.Get(null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int Set(eContato obj)
        {
            try
            {
                if (!ValidarInsercao(obj))
                    return 0;

                dContato db = new dContato(StringConnection());
                return db.Set(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int Del(int id)
        {
            try
            {
                if (id <= 0)
                    return 0;

                dContato db = new dContato(StringConnection());
                return db.Del(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static bool ValidarInsercao(eContato obj)
        {
            if (obj == null)
                throw new ArgumentException("Parâmetro obj não pode ser nulo.");

            if (string.IsNullOrEmpty(obj.Nome))
                return false;

            if (string.IsNullOrEmpty(obj.TelefoneResidencial))
                return false;

            return true;
        }

        private static string StringConnection()
        {
            return ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
        }
    }
}
