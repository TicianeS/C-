using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Callcenter.Model;
using System.Data.Entity;
using System.Data;

namespace Callcenter.DAO
{
    class FuncionarioDAO
    {
        public static Funcionario ObterFuncionarioCpf(string cpf)
        {
            CallEntities db = SingletonObjectContext.Instance.Context;
            try
            {
                return db.Funcionarios.FirstOrDefault(x => x.Cpf.Equals(cpf));
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public static Funcionario ObterFuncionarioNome(Funcionario Funcionario)
        {
            CallEntities db = SingletonObjectContext.Instance.Context;
            try
            {
                return db.Funcionarios.FirstOrDefault(x => x.Nome.Equals(Funcionario.Nome));
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static Funcionario ObterFuncionarioId(int matricula)
        {
            CallEntities db = SingletonObjectContext.Instance.Context;
            try
            {
                return db.Funcionarios.FirstOrDefault(x => x.Id == matricula);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static bool Incluir(Funcionario Funcionario)
        {
            CallEntities db = SingletonObjectContext.Instance.Context;
            try
            {
                db.Funcionarios.Add(Funcionario);
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
            CallEntities db = SingletonObjectContext.Instance.Context;
            var local = db.Set<Funcionario>().Local.FirstOrDefault(x => x.Id == Funcionario.Id);
            try
            {
                db.Entry(local).State = EntityState.Detached;
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
            CallEntities db = SingletonObjectContext.Instance.Context;
            try
            {
                db.Funcionarios.Remove(Funcionario);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public static IOrderedEnumerable<Funcionario> ObterFuncionarios()
        {
            CallEntities db = SingletonObjectContext.Instance.Context;
            try
            {
                return db.Funcionarios.ToList().OrderBy(x => x.Nome);
            }
            catch (Exception e)
            {
                return null;
            }
        }




    }
}
