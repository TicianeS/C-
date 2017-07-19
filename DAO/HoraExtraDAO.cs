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
    class HoraExtraDAO
    {
        public static bool Incluir(HoraExtra HoraExtra)
        {
            CallEntities db = SingletonObjectContext.Instance.Context;

            try
            {
                db.HorasExtras.Add(HoraExtra);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static IOrderedEnumerable<HoraExtra> ObterHorasExtras()
        {
            CallEntities db = SingletonObjectContext.Instance.Context;
            try
            {
                return db.HorasExtras.Include("Funcionario").ToList().OrderBy(x => x.Data);
            }
            catch
            {
                return null;
            }
        }


        public static HoraExtra ObterHoraExtraData(int id, DateTime data)
        {
            CallEntities db = SingletonObjectContext.Instance.Context;
            try
            {
                return db.HorasExtras.Include("Funcionario").FirstOrDefault(x => x.Funcionario.Id == id && x.Data == data);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static HoraExtra ObterHoraExtraID(int id)
        {
            CallEntities db = SingletonObjectContext.Instance.Context;
            try
            {
                return db.HorasExtras.Include("Funcionario").FirstOrDefault(x => x.Id == id );
            }
            catch (Exception e)
            {
                return null;
            }
        }



        public static IOrderedEnumerable<HoraExtra> ObterHoraExtraDataIni_Fim(DateTime ini, DateTime fim)
        {

            CallEntities db = SingletonObjectContext.Instance.Context;
            IOrderedEnumerable<HoraExtra> HorasExtras = db.HorasExtras.Include("Funcionario").Where(x => x.Data >= ini && x.Data <= fim).ToList().OrderBy(x => x.Data);
            return HorasExtras;
        }

        public static IOrderedEnumerable<HoraExtra> ObterHoraExtrasFunc(int mat)
        {

            CallEntities db = SingletonObjectContext.Instance.Context;
            IOrderedEnumerable<HoraExtra> HorasExtras = db.HorasExtras.Include("Funcionario").Where(x => x.Funcionario.Id == mat).ToList().OrderBy(x => x.Data);
            return HorasExtras;

        }

        public static bool Alterar(HoraExtra HoraExtra)
        {
            CallEntities db = SingletonObjectContext.Instance.Context;
            var localHe = db.Set<HoraExtra>().Local.FirstOrDefault(x => x.Id == HoraExtra.Id);
            try
            {
                db.Entry(localHe).State = EntityState.Detached;
                db.Entry(HoraExtra).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public static bool Excluir(HoraExtra HoraExtra)
        {
            CallEntities db = SingletonObjectContext.Instance.Context;
            try
            {
                db.HorasExtras.Remove(HoraExtra);
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
