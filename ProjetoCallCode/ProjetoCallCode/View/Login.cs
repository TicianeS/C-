using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjetoCallCode.Model;
using ProjetoCallCode.DAO;

namespace ProjetoCallCode.View
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            foreach (Cargo x in CargoDAO.ObterCargos())

            {

                dtg.Rows.Add(x.Id, x.Nome);

            }
        }
    }
}
