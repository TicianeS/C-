using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CallPostgre.Model;
using System.Data.Entity;

namespace CallPostgre.DAO
{
    class UsuarioDAO
    {
        public static Usuario ObterUsuarioRegistro(int registro)
        {
            CallcenterEntities db = SingletonObjectContext.Instance.Context;
            try
            {
                return db.usuarios.Include("funcionarios").FirstOrDefault(x => x.funcionarios.registro == registro);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static Usuario Autenticar(Usuario usuario)
        {
            CallcenterEntities db = SingletonObjectContext.Instance.Context;
            try
            {
                return db.usuarios.Include("Funcionario").FirstOrDefault(x => x.funcionarios.registro.Equals(usuario.funcionarios.registro) && x.senha.Equals(usuario.senha));
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static bool Incluir(Usuario Usuario)
        {
            CallcenterEntities db = SingletonObjectContext.Instance.Context;

            try
            {
                db.usuarios.Add(Usuario);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static bool Alterar(Usuario Usuario)
        {
            CallcenterEntities db = SingletonObjectContext.Instance.Context;
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
            CallcenterEntities db = SingletonObjectContext.Instance.Context;
            try
            {
                db.usuarios.Remove(Usuario);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static IOrderedEnumerable<Usuario> ListarTodos()
        {
            CallcenterEntities db = SingletonObjectContext.Instance.Context;
            try
            {
                return db.usuarios.Include("funcionarios").ToList().OrderBy(x => x.id);
            }
            catch
            {
                return null;
            }
        }

    }
}
