using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CallPostgre.DAO;
using CallPostgre.Model;

namespace CallPostgre.View
{
    public partial class FrmCargo : Form
    {

        FrmPrincipal pri;
        public FrmCargo(FrmPrincipal x)
        {
            pri = x;
            InitializeComponent();
        }

        private void rbtCargoPesquisar_CheckedChanged(object sender, EventArgs e)
        {
            dtgCargoPesq.Rows.Clear();
            txtCargoConsultarNome.Clear();
            txtCargoConsultarNome.Enabled = true;
        }

        private void btnCargoPesquisar_Click(object sender, EventArgs e)
        {
            dtgCargoPesq.Rows.Clear();
            Cargo c = new Cargo();

            if (rbtCargoListar.Checked)
            {
                foreach (Cargo x in CargoDAO.ListarTodos())
                {
                    dtgCargoPesq.Rows.Add(x.id, x.nome);

                }
            }
            else
            {
                string nome = txtCargoConsultarNome.Text;

                if (string.IsNullOrEmpty(nome))
                {
                    MessageBox.Show("Por favor, informe o cargo.", "Dados incorretos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    foreach (Cargo x in CargoDAO.ObterCargoNome(nome))
                    {
                        dtgCargoPesq.Rows.Add(x.id, x.nome);

                    }
                }
            }
        }

        private void rbtCargoListar_CheckedChanged(object sender, EventArgs e)
        {
            txtCargoConsultarNome.Clear();
            txtCargoConsultarNome.Enabled = false;
            dtgCargoPesq.Rows.Clear();
        }



        private void txtCargoCadastrarNome_Leave(object sender, EventArgs e)
        {
            btnCargoCadastrar.Visible = false;
            btnCargoAlterar.Visible = false;
            btnCargoExcluir.Visible = false;

            string nome = txtCargoCadastrarNome.Text;

            if (string.IsNullOrEmpty(nome))
            {
                MessageBox.Show("Por favor, informe o cargo.", "Dados incorretos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Cargo c = new Cargo();
                c = CargoDAO.PesquisarCargo(nome);

                if (c == null)
                {
                    btnCargoCadastrar.Visible = true;
                }
                else
                {
                    btnCargoAlterar.Visible = true;
                    btnCargoExcluir.Visible = true;
                }
            }
        }

        private void txtCargoCadastrarNome_Enter(object sender, EventArgs e)
        {
            btnCargoCadastrar.Visible = false;
            btnCargoAlterar.Visible = false;
            btnCargoExcluir.Visible = false;

            string nome = txtCargoCadastrarNome.Text;

            if (string.IsNullOrEmpty(nome))
            {
                MessageBox.Show("Por favor, informe o cargo.", "Dados incorretos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Cargo c = new Cargo();
                c = CargoDAO.PesquisarCargo(nome);

                if (c == null)
                {
                    btnCargoCadastrar.Visible = true;
                }
                else
                {
                    btnCargoAlterar.Visible = true;
                    btnCargoExcluir.Visible = true;
                }
            }
        }

        private void btnCargoCadastrar_Click(object sender, EventArgs e)
        {
            string nome = txtCargoCadastrarNome.Text;
            string usuario = pri.lblFrmPrincipalNome.Text;

            Cargo c = new Cargo();
            c.nome = nome;
            c.alterado = usuario;
            CargoDAO.Incluir(c);
        }


    }
}
