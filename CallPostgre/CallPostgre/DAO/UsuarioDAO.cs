using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CallPostgre.Model;

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
    }
}
