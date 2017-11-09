using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CallPostgre.Model;
using System.Data.Entity;

namespace CallPostgre.DAO
{
    class FeriasDAO
    {

        public static Ferias ObterFeriasFuncAno(int reg, int ano)
        {
            CallcenterEntities db = SingletonObjectContext.Instance.Context;
            try
            {
                return db.ferias.Include("pretensoes").FirstOrDefault(x => x.pretensoes.ano == ano && x.pretensoes.divfuncionario.funcionarios.registro == reg);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static bool Incluir(Ferias Ferias)
        {
            CallcenterEntities db = SingletonObjectContext.Instance.Context;

            try
            {
                db.ferias.Add(Ferias);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static bool Alterar(Ferias Ferias)
        {
            CallcenterEntities db = SingletonObjectContext.Instance.Context;
            try
            {
                db.Entry(Ferias).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public static bool Excluir(Ferias Ferias)
        {
            CallcenterEntities db = SingletonObjectContext.Instance.Context;
            try
            {
                db.ferias.Remove(Ferias);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static IOrderedEnumerable<Ferias> ListarTodos()
        {
            CallcenterEntities db = SingletonObjectContext.Instance.Context;
            try
            {
                return db.ferias.ToList().OrderBy(x => x.id);
            }
            catch
            {
                return null;
            }
        }

    }
}
