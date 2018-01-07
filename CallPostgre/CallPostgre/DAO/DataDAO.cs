using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CallPostgre.Model;
using System.Data.Entity;

namespace CallPostgre.DAO
{
    class DataDAO
    {
        public static bool Incluir(Data Data)
        {
            CallcenterEntities db = SingletonObjectContext.Instance.Context;

            try
            {
                db.datas.Add(Data);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static bool Alterar(Data Data)
        {
            CallcenterEntities db = SingletonObjectContext.Instance.Context;
            try
            {
                db.Entry(Data).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public static bool Excluir(Data Data)
        {
            CallcenterEntities db = SingletonObjectContext.Instance.Context;
            try
            {
                db.datas.Remove(Data);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static IOrderedEnumerable<Data> ListarTodos()
        {
            CallcenterEntities db = SingletonObjectContext.Instance.Context;
            try
            {
                return db.datas.ToList().OrderBy(x => x.inicio);
            }
            catch
            {
                return null;
            }
        }

        public static IOrderedEnumerable<Data> ListarFeriados()
        {
            CallcenterEntities db = SingletonObjectContext.Instance.Context;
            try
            {
                return db.datas.Where(x => x.tipo.Contains("FERIADO")).ToList().OrderBy(x => x.inicio);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static IOrderedEnumerable<DateTime> PeriodoUmido(DateTime data)
        {
            CallcenterEntities db = SingletonObjectContext.Instance.Context;

            try
            {
                IOrderedEnumerable<Data> dt = db.datas.Where(x => x.tipo.Equals("ÚMIDO") && 
                    (x.inicio.Value.Month == data.Month &&
                     x.inicio.Value.Year == data.Year) ||
                    (x.fim.Value.Month == data.Month &&
                     x.fim.Value.Year == data.Year))
                        .ToList().OrderBy(x => x.inicio);

                if (dt != null)
                {
                    List<DateTime> datas = new List<DateTime>();
                    

                    foreach (Data x in dt)
                    {
                        if (x.inicio.Value.Month == data.Month)
                        {
                            datas.Add(x.inicio.Value.Date);
                           
                        }
                        if (x.fim.Value.Month == data.Month)
                        {
                            datas.Add(x.fim.Value.Date);

                        }

                    }

                    return datas.ToList().OrderBy(x => x.DayOfYear);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static IOrderedEnumerable<DateTime> PeriodoNobre(DateTime data)
        {
            CallcenterEntities db = SingletonObjectContext.Instance.Context;

            try
            {
                IOrderedEnumerable<Data> dt = db.datas.Where(x => x.tipo.Equals("NOBRE") &&
                    (x.inicio.Value.Month == data.Month &&
                     x.inicio.Value.Year == data.Year) ||
                    (x.fim.Value.Month == data.Month &&
                     x.fim.Value.Year == data.Year))
                        .ToList().OrderBy(x => x.inicio);

                if (dt != null)
                {
                    List<DateTime> datas = new List<DateTime>();
                    

                    foreach (Data x in dt)
                    {
                        if (x.inicio.Value.Month == data.Month)
                        {
                            datas.Add(x.inicio.Value.Date);
                            
                        }
                        if (x.fim.Value.Month == data.Month)
                        {
                            datas.Add(x.fim.Value.Date);

                        }

                    }

                    return datas.ToList().OrderBy(x => x.DayOfYear);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static Data PesquisarFeriado(DateTime data)
        {
            CallcenterEntities db = SingletonObjectContext.Instance.Context;
            try
            {
                return db.datas.FirstOrDefault(x => x.inicio == data && x.tipo.Contains("FERIADO"));
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
