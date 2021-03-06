﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data;
using CallPostgre.Model;

namespace CallPostgre.DAO
{
    class DivisaoDAO
    {
        public static Divisao ObterDivisaoId(int id)
        {
            CallcenterEntities db = SingletonObjectContext.Instance.Context;

            try
            {
                return db.divisoes.FirstOrDefault(x => x.id == id);
            }

            catch (Exception e)
            {
                return null;
            }
        }

        public static bool Incluir(Divisao Divisao)
        {
            CallcenterEntities db = SingletonObjectContext.Instance.Context;

            try
            {
                db.divisoes.Add(Divisao);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static bool Alterar(Divisao Divisao)
        {
            CallcenterEntities db = SingletonObjectContext.Instance.Context;
            try
            {
                db.Entry(Divisao).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public static bool Excluir(Divisao Divisao)
        {
            CallcenterEntities db = SingletonObjectContext.Instance.Context;
            try
            {
                db.divisoes.Remove(Divisao);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static IOrderedEnumerable<Divisao> ListarTodos()
        {
            CallcenterEntities db = SingletonObjectContext.Instance.Context;
            try
            {
                return db.divisoes.ToList().OrderBy(x => x.nome);
            }
            catch
            {
                return null;
            }
        }


    }
}
