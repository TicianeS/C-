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
    class EscalaDAO
    {
        public static bool Incluir(Escala Escala)
        {
            CallEntities db = SingletonObjectContext.Instance.Context;

            try
            {
                db.Escalas.Add(Escala);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static Escala ObterEscalaData(int id, DateTime data)
        {
            CallEntities db = SingletonObjectContext.Instance.Context;
            try
            {
                return db.Escalas.Include("Funcionario").Include("Ausencia").FirstOrDefault(x => x.Funcionario.Id == id && x.Data == data);
            }
            catch (Exception e)
            {
                return null;
            }
        }


        public static Escala ObterEscalaID(int id)
        {
            CallEntities db = SingletonObjectContext.Instance.Context;
            try
            {
                return db.Escalas.Include("Funcionario").Include("Ausencia").FirstOrDefault(x => x.Id == id);
            }
            catch (Exception e)
            {
                return null;
            }
        }



        public static IOrderedEnumerable<Escala> ObterEscalaIDeData(int mat, DateTime inicio, DateTime fim)
        {
            CallEntities db = SingletonObjectContext.Instance.Context;
            IOrderedEnumerable<Escala> Escalas = db.Escalas.Include("Funcionario").Include("Ausencia").Where(x => x.Data >= inicio && x.Data <= fim && x.Funcionario.Id == mat).ToList().OrderBy(x => x.Data);
            return Escalas;
        }

        public static IOrderedEnumerable<Escala> ObterEscalaTipo(string tipo, DateTime inicio, DateTime fim)
        {
            CallEntities db = SingletonObjectContext.Instance.Context;
            IOrderedEnumerable<Escala> Escalas = db.Escalas.Include("Funcionario").Include("Ausencia").Where(x => x.Data >= inicio && x.Data <= fim && x.Ausencia.Nome.Equals(tipo)).ToList().OrderBy(x => x.Data);
            return Escalas;
        }

        public static bool Alterar(Escala Escala)
        {
            CallEntities db = SingletonObjectContext.Instance.Context;
            var localEsc = db.Set<Escala>().Local.FirstOrDefault(x => x.Id == Escala.Id);
            try
            {
                db.Entry(localEsc).State = EntityState.Detached;
                db.Entry(Escala).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public static bool Excluir(Escala Escala)
        {
            CallEntities db = SingletonObjectContext.Instance.Context;
            try
            {
                db.Escalas.Remove(Escala);
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
