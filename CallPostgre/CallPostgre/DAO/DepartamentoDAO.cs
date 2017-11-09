using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CallPostgre.Model;
using System.Data.Entity;

namespace CallPostgre.DAO
{
    class DepartamentoDAO
    {
        public static bool Incluir(Departamento Departamento)
        {
            CallcenterEntities db = SingletonObjectContext.Instance.Context;

            try
            {
                db.divfuncionario.Add(Departamento);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static bool Alterar(Departamento Departamento)
        {
            CallcenterEntities db = SingletonObjectContext.Instance.Context;
            try
            {
                db.Entry(Departamento).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public static bool Excluir(Departamento Departamento)
        {
            CallcenterEntities db = SingletonObjectContext.Instance.Context;
            try
            {
                db.divfuncionario.Remove(Departamento);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static IOrderedEnumerable<Departamento> ListarTodos()
        {
            CallcenterEntities db = SingletonObjectContext.Instance.Context;
            try
            {
                return db.divfuncionario.ToList().OrderBy(x => x.cidade);
            }
            catch
            {
                return null;
            }
        }

        public static Departamento PesquisarFuncReg(int reg)
        {
            CallcenterEntities db = SingletonObjectContext.Instance.Context;
            try
            {
                return db.divfuncionario.Include("funcionarios").FirstOrDefault(x => x.funcionarios.registro == reg);
            }
            catch
            {
                return null;
            }
        }

        public static Departamento PesquisarFuncRegMes(int reg)
        {
            CallcenterEntities db = SingletonObjectContext.Instance.Context;
            DateTime hoje = DateTime.Now;
            try
            {
                return db.divfuncionario.Include("funcionarios").FirstOrDefault(x => x.funcionarios.registro == reg);
               // return db.divfuncionario.Include("funcionarios").FirstOrDefault(x => x.funcionarios.registro == reg && x.cadastro.Month == hoje.Month && x.cadastro.Year == hoje.Year);
            }
            catch
            {
                return null;
            }
        }
    }
}
