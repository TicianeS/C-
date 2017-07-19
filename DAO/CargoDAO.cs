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
    class CargoDAO
    {
        public static bool Incluir(Cargo Cargo)
        {
            CallEntities db = SingletonObjectContext.Instance.Context;

            try
            {
                db.Cargos.Add(Cargo);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static Cargo ObterCargoNome(Cargo Cargo)
        {
            CallEntities db = SingletonObjectContext.Instance.Context;
            try
            {
                return db.Cargos.FirstOrDefault(x => x.Nome.Equals(Cargo.Nome));
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static IOrderedEnumerable<Cargo> ObterCargos()
        {
            CallEntities db = SingletonObjectContext.Instance.Context;
            try
            {
                return db.Cargos.ToList().OrderBy(x => x.Nome);
            }
            catch
            {
                return null;
            }
        }

        public static bool Alterar(Cargo Cargo)
        {
            CallEntities db = SingletonObjectContext.Instance.Context;
            try
            {
                db.Entry(Cargo).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public static bool Excluir(Cargo Cargo)
        {
            CallEntities db = SingletonObjectContext.Instance.Context;
            try
            {
                db.Cargos.Remove(Cargo);
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
