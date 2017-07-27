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
    class AusenciaDAO
    {
        public static bool Incluir(Ausencia Ausencia)
        {
            CallEntities db = SingletonObjectContext.Instance.Context;

            try
            {
                db.Ausencias.Add(Ausencia);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static Ausencia ObterAusenciaNome(Ausencia Ausencia)
        {
            CallEntities db = SingletonObjectContext.Instance.Context;
            try
            {
                return db.Ausencias.FirstOrDefault(x => x.Nome.Equals(Ausencia.Nome));
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static Ausencia ObterAusenciaSigla(Ausencia Ausencia)
        {
            CallEntities db = SingletonObjectContext.Instance.Context;
            try
            {
                return db.Ausencias.FirstOrDefault(x => x.Sigla.Equals(Ausencia.Sigla));
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static IOrderedEnumerable<Ausencia> ObterAusencias()
        {
            CallEntities db = SingletonObjectContext.Instance.Context;
            try
            {
                return db.Ausencias.ToList().OrderBy(x => x.Nome);
            }
            catch
            {
                return null;
            }
        }

        public static bool Alterar(Ausencia Ausencia)
        {
            CallEntities db = SingletonObjectContext.Instance.Context;
            var localAus = db.Set<Ausencia>().Local.FirstOrDefault(x => x.Id == Ausencia.Id);
            try
            {
                db.Entry(localAus).State = EntityState.Detached;
                db.Entry(Ausencia).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public static bool Excluir(Ausencia Ausencia)
        {
            CallEntities db = SingletonObjectContext.Instance.Context;
            try
            {
                db.Ausencias.Remove(Ausencia);
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
