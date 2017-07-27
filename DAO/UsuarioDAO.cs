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
    class UsuarioDAO
    {
        public static bool Incluir(Usuario Usuario)
        {
            CallEntities db = SingletonObjectContext.Instance.Context;

            try
            {
                db.Usuarios.Add(Usuario);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static Usuario ObterUsuarioLogin(string Login)
        {
            CallEntities db = SingletonObjectContext.Instance.Context;
            try
            {
                return db.Usuarios.Include("Funcionario").FirstOrDefault(x => x.Login.Equals(Login));
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static Usuario AutenticarUsuario(Usuario Usuario)
        {
            CallEntities db = SingletonObjectContext.Instance.Context;
            try
            {
                return db.Usuarios.FirstOrDefault(x => x.Login.Equals(Usuario.Login) && x.Senha.Equals(Usuario.Senha));
            }
            catch (Exception e)
            {
                return null;
            }
        }


        public static Usuario ObterUsuarioId(int mat)
        {
            CallEntities db = SingletonObjectContext.Instance.Context;
            try
            {
                return db.Usuarios.Include("Funcionario").FirstOrDefault(x => x.Funcionario.Id == mat);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static IOrderedEnumerable<Usuario> ObterUsuarios()
        {
            CallEntities db = SingletonObjectContext.Instance.Context;
            try
            {
                return db.Usuarios.Include("Funcionario").ToList().OrderBy(x => x.Id);
            }
            catch
            {
                return null;
            }
        }

        public static IOrderedEnumerable<Usuario> ObterUsuariosTipo(string tipo)
        {

            CallEntities db = SingletonObjectContext.Instance.Context;
            IOrderedEnumerable<Usuario> Usuarios = db.Usuarios.Include("Funcionario").Where(x => x.Tipo.Equals(tipo)).ToList().OrderBy(x => x.Tipo);
            return Usuarios;
        }

        public static bool Alterar(Usuario Usuario)
        {
            CallEntities db = SingletonObjectContext.Instance.Context;
            try
            {
                db.Entry(Usuario).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public static bool Excluir(Usuario Usuario)
        {
            CallEntities db = SingletonObjectContext.Instance.Context;
            try
            {
                db.Usuarios.Remove(Usuario);
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
