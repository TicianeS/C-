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
    class DepartamentoDAO
    {
        public static bool Incluir(Departamento Departamento)
        {
            CallEntities db = SingletonObjectContext.Instance.Context;

            try
            {
                db.Departamentos.Add(Departamento);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static IOrderedEnumerable<Departamento> ObterFuncionariosDepartamento()
        {
            CallEntities db = SingletonObjectContext.Instance.Context;
            try
            {
                return db.Departamentos.Include("Funcionario").Include("Supervisor").Include("Cargo").ToList().OrderBy(x => x.Supervisor.Nome);
            }
            catch
            {
                return null;
            }
        }

        public static IOrderedEnumerable<Departamento> ObterFuncionariosDptoCargo(string cargo)
        {
            CallEntities db = SingletonObjectContext.Instance.Context;
            try
            {
                return db.Departamentos.Include("Funcionario").Include("Supervisor").Include("Cargo").Where(x => x.Cargo.Nome.Equals(cargo)).ToList().OrderBy(x => x.Supervisor.Nome);
            }
            catch
            {
                return null;
            }
        }
        public static Departamento ObterDepartamentoId(int mat)
        {
            CallEntities db = SingletonObjectContext.Instance.Context;
            try
            {

                return db.Departamentos.Include("Funcionario").Include("Supervisor").Include("Cargo").FirstOrDefault(x => x.Funcionario.Id == mat);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static Departamento ObterDepartamentoIdDP(int id)
        {
            CallEntities db = SingletonObjectContext.Instance.Context;
            try
            {

                return db.Departamentos.Include("Funcionario").Include("Supervisor").Include("Cargo").FirstOrDefault(x => x.Id == id);
            }
            catch (Exception e)
            {
                return null;
            }
        }


        public static IOrderedEnumerable<Departamento> ObterSupervisores()
        {
            string tele = "TELEATENDENTE";
            CallEntities db = SingletonObjectContext.Instance.Context;
            IOrderedEnumerable<Departamento> Departamentos = db.Departamentos.Include("Funcionario").Include("Supervisor").Include("Cargo").Where(x => !x.Cargo.Nome.Equals(tele)).ToList().OrderBy(x => x.Funcionario.Nome);
            return Departamentos;
        }


        public static Departamento ObterDepartamentoFunc(Funcionario Funcionario)
        {
            CallEntities db = SingletonObjectContext.Instance.Context;
            try
            {

                return db.Departamentos.Include("Funcionario").Include("Supervisor").Include("Cargo").FirstOrDefault(x => x.Funcionario.Nome == Funcionario.Nome);
            }
            catch (Exception e)
            {
                return null;
            }
        }


        public static IOrderedEnumerable<Departamento> ObterFuncDptoHorario(DateTime horario)
        {
            CallEntities db = SingletonObjectContext.Instance.Context;
            try
            {
                return db.Departamentos.Include("Funcionario").Include("Supervisor").Include("Cargo").Where(x => x.Horario.Hour == horario.Hour && x.Horario.Minute == horario.Minute).ToList().OrderBy(x => x.Funcionario.Nome);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static IOrderedEnumerable<Departamento> ObterFuncionariosDptoID(int mat)
        {
            CallEntities db = SingletonObjectContext.Instance.Context;
            try
            {
                return db.Departamentos.Include("Funcionario").Include("Supervisor").Include("Cargo").Where(x => x.Funcionario.Id == mat).ToList().OrderBy(x => x.Funcionario.Nome);
            }
            catch
            {
                return null;
            }
        }

        public static IOrderedEnumerable<Departamento> ObterFuncionariosDptoSuperv(string supervisor)
        {
            CallEntities db = SingletonObjectContext.Instance.Context;
            try
            {
                return db.Departamentos.Include("Funcionario").Include("Supervisor").Include("Cargo").Where(x => x.Supervisor.Nome.Equals(supervisor)).ToList().OrderBy(x => x.Horario);
            }
            catch
            {
                return null;
            }
        }

        public static bool Alterar(Departamento Departamento)
        {
            CallEntities db = SingletonObjectContext.Instance.Context;
            var localdp = db.Set<Departamento>().Local.FirstOrDefault(x => x.Id == Departamento.Id);
            try
            {
                db.Entry(localdp).State = EntityState.Detached;
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
            CallEntities db = SingletonObjectContext.Instance.Context;
            try
            {
                db.Departamentos.Remove(Departamento);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
