using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data;

namespace CallPostgre.DAO
{
    class DivisaoDAO
    {
        public static Divisao ObterDivisaoId(int id)
        {
            CallcenterEntities db = SingletonObjectContext.Instance.Context;

            try
            {
                return db.divisoes.FirstOrDefault(x => x.id == id);
            }

            catch (Exception e)
            {
                return null;
            }
        }

    }
}
