using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CallPostgre.Model;
using System.Data.Entity;

namespace CallPostgre.DAO
{
    class PretensaoDAO
    {
        public static Pretensao ObterPretFuncAno(int reg, int ano)
        {
            CallcenterEntities db = SingletonObjectContext.Instance.Context;
            try
            {
                return db.pretensoes.Include("divfuncionario").FirstOrDefault(x => x.ano == ano && x.divfuncionario.funcionarios.registro == reg && x.ativo == true);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static bool Incluir(Pretensao Pretensao)
        {
            CallcenterEntities db = SingletonObjectContext.Instance.Context;

            try
            {
                db.pretensoes.Add(Pretensao);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static bool Alterar(Pretensao Pretensao)
        {
            CallcenterEntities db = SingletonObjectContext.Instance.Context;
            try
            {
                db.Entry(Pretensao).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public static bool Excluir(Pretensao Pretensao)
        {
            CallcenterEntities db = SingletonObjectContext.Instance.Context;
            try
            {
                db.pretensoes.Remove(Pretensao);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static IOrderedEnumerable<Pretensao> ListarTodos()
        {
            CallcenterEntities db = SingletonObjectContext.Instance.Context;
            try
            {
                return db.pretensoes.ToList().OrderBy(x => x.ano);
            }
            catch
            {
                return null;
            }
        }
    }
}
