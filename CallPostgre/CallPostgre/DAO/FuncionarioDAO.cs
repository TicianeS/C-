using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CallPostgre.Model;

namespace CallPostgre.DAO
{
    class FuncionarioDAO
    {
        public static Funcionario ObterFuncionarioId(int reg)
        {
            CallcenterEntities db = SingletonObjectContext.Instance.Context;
            try
            {
                return db.funcionarios.FirstOrDefault(x => x.registro == reg);
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
