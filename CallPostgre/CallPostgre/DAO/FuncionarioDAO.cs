using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CallPostgre.Model;
using System.Data.Entity;

namespace CallPostgre.DAO
{
    class FuncionarioDAO
    {
        public static Funcionario ObterFuncionarioId(int reg)
        {
            CallcenterEntities db = SingletonObjectContext.Instance.Context;
            try
            {
                return db.funcionarios.Include("cargos").FirstOrDefault(x => x.registro == reg);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static bool Incluir(Funcionario Funcionario)
        {
            CallcenterEntities db = SingletonObjectContext.Instance.Context;

            try
            {
                db.funcionarios.Add(Funcionario);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static bool Alterar(Funcionario Funcionario)
        {
            CallcenterEntities db = SingletonObjectContext.Instance.Context;
            try
            {
                db.Entry(Funcionario).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public static bool Excluir(Funcionario Funcionario)
        {
            CallcenterEntities db = SingletonObjectContext.Instance.Context;
            try
            {
                db.funcionarios.Remove(Funcionario);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static IOrderedEnumerable<Funcionario> ListarTodos()
        {
            CallcenterEntities db = SingletonObjectContext.Instance.Context;
            try
            {
                return db.funcionarios.ToList().OrderBy(x => x.nome);
            }
            catch
            {
                return null;
            }
        }

    }
}
