using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Callcenter.Model;
using Callcenter.DAO;
using Callcenter.BO;

namespace Callcenter.View
{
    public partial class frmRelatorios : Form
    {
        frmPrincipal pri;
        public frmRelatorios(frmPrincipal x)
        {
            pri = x;
            InitializeComponent();
        }

        private void rbtRelUMat_CheckedChanged(object sender, EventArgs e)
        {
            dtgridRelU.Rows.Clear();
            txtRelUMat.Enabled = true;
            txtRelULogin.Enabled = false;
            txtRelULogin.Clear();
            cboRelUTipo.Enabled = false;
            cboRelUTipo.Text = "";
          
        }

        private void rbtRelULogin_CheckedChanged(object sender, EventArgs e)
        {
            dtgridRelU.Rows.Clear();
            txtRelUMat.Enabled = false;
            txtRelUMat.Clear();
            txtRelULogin.Enabled = true;
            cboRelUTipo.Enabled = false;
            cboRelUTipo.Text = "";
        }

        private void rbtRelUTipo_CheckedChanged(object sender, EventArgs e)
        {
            dtgridRelU.Rows.Clear();
            txtRelUMat.Enabled = false;
            txtRelUMat.Clear();
            txtRelULogin.Enabled = false;
            txtRelULogin.Clear();
            cboRelUTipo.Enabled = true;
        }

        private void rbtRelUTodos_CheckedChanged(object sender, EventArgs e)
        {
            dtgridRelU.Rows.Clear();
            txtRelUMat.Enabled = false;
            txtRelUMat.Clear();
            txtRelULogin.Enabled = false;
            txtRelULogin.Clear();
            cboRelUTipo.Enabled = false;
            cboRelUTipo.Text = "";
        }

        private void txtRelUMat_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void btnRelUPesquisar_Click(object sender, EventArgs e)
        {
            if (rbtRelUMat.Checked)
            {
                if (!txtRelUMat.Text.Equals(""))
                {
                    int mat;
                    bool conv;

                    conv = Int32.TryParse(txtRelUMat.Text, out mat);
                    if (conv == false)
                    {
                        mat = 0;
                    }
                    else
                    {
                        Int32.TryParse(txtRelUMat.Text, out mat);
                    }

                    Funcionario Funcionario = new Funcionario();
                    Usuario Usuario = new Usuario();
                    Funcionario = FuncionarioDAO.ObterFuncionarioId(mat);

                    if (Funcionario == null)
                    {
                        MessageBox.Show("A matrícula informada não existe.");
                        txtRelUMat.Clear();
                    }
                    else
                    {
                        Usuario = UsuarioDAO.ObterUsuarioId(mat);
                        if (Usuario != null)
                        {
                            dtgridRelU.Rows.Add(Usuario.Id, Usuario.Login, Usuario.Tipo, Usuario.Funcionario.Nome, Usuario.Funcionario.Id);

                        }
                        else
                        {
                            MessageBox.Show("O funcionário informado não possui um usuário cadastrado.");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Por favor informe a matrícula");
                }
            }

            else
            {
                if (rbtRelUTodos.Checked)
                {
                 
                    foreach (Usuario x in UsuarioDAO.ObterUsuarios())

                    {
                        dtgridRelU.Rows.Add(x.Id, x.Login, x.Tipo, x.Funcionario.Nome, x.Funcionario.Id);

                    }
                }
                else
                {
                    if (rbtRelULogin.Checked)
                    {
                        if (!txtRelULogin.Text.Equals(""))
                        {
                            string login = txtRelULogin.Text;

                            Usuario Usuario = new Usuario();
                            Usuario = UsuarioDAO.ObterUsuarioLogin(login);

                            if (Usuario != null)
                            {
                                dtgridRelU.Rows.Add(Usuario.Id, Usuario.Login, Usuario.Tipo, Usuario.Funcionario.Nome, Usuario.Funcionario.Id);

                            }
                            else
                            {
                                MessageBox.Show("Login não cadastrado");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Informe o login para pesquisa.");
                        }
                    
                    }
                    else
                    {
                        if (rbtRelUTipo.Checked)
                        {
                            if (!cboRelUTipo.Text.Equals(""))
                            {
                                
                                string tipo = cboRelUTipo.SelectedItem.ToString();
                                Usuario Usuario = new Usuario();

                                foreach (Usuario x in UsuarioDAO.ObterUsuariosTipo(tipo))
                                {
                                    dtgridRelU.Rows.Add(x.Id, x.Login, x.Tipo, x.Funcionario.Nome, x.Funcionario.Id);
                          
                                }
                            }
                            else
                            {
                                MessageBox.Show("Selecione o tipo a ser pesquisado.");
                                dtgridRelU.Rows.Clear();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Selecione uma opção de pesquisa.");
                        }
                    }
                }
            }
        }

        private void btnRelCargos_Click(object sender, EventArgs e)
        {
           
            foreach (Cargo x in CargoDAO.ObterCargos())
            {
                dtgridRelCargos.Rows.Add(x.Id, x.Nome);
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void btnRelHePesquisar_Click(object sender, EventArgs e)
        {
            if (rbtRelHeMat.Checked)
            {
                mskRelHeIni.Enabled = false;
                mskRelHeFim.Enabled = false;
                txtRelHeMat.Enabled = true;

                if (!txtRelHeMat.Text.Equals(""))
                {
                    int mat;
                    bool conv;

                    conv = Int32.TryParse(txtRelHeMat.Text, out mat);
                    if (conv == false)
                    {
                        mat = 0;
                    }

                    Funcionario Funcionario = new Funcionario();
                    Funcionario = FuncionarioDAO.ObterFuncionarioId(mat);

                    if (Funcionario == null)
                    {
                        MessageBox.Show("A matrícula informada não existe.");
                        txtRelHeMat.Clear();
                    }
                    else
                    {
                        DateTime horas = new DateTime();
                        DateTime total = new DateTime();
                        int i = 0;
                        
                        foreach (HoraExtra x in HoraExtraDAO.ObterHoraExtrasFunc(mat))
                        {
                            dtgridRelHe.Rows.Add(x.Id, x.Funcionario.Nome, x.Data, x.Horas, x.Inicio, x.Fim);

                            horas = Convert.ToDateTime(x.Horas);
                            total = total + horas.TimeOfDay;
                            i++;
                        }
                        txtRelHeHoras.Text = total.TimeOfDay.ToString();
                        txtRelHeTotal.Text = i.ToString();
                    }
                }
                else
                {
                    MessageBox.Show("Por favor informe a matrícula");
                }
            }
            else
            {
                DateTime horas = new DateTime();
                DateTime total = new DateTime();
                int i = 0;
                DateTime ini = Convert.ToDateTime(mskRelHeIni.Text);
                DateTime fim = Convert.ToDateTime(mskRelHeFim.Text);

                foreach (HoraExtra x in HoraExtraDAO.ObterHoraExtraDataIni_Fim(ini, fim))
                {
                    dtgridRelHe.Rows.Add(x.Id, x.Funcionario.Nome, x.Data, x.Horas, x.Inicio, x.Fim);
                    horas = Convert.ToDateTime(x.Horas);
                    total = total + horas.TimeOfDay;
                    i++;
                }
                txtRelHeHoras.Text = total.TimeOfDay.ToString();
                txtRelHeTotal.Text = i.ToString();
            }
        }

        private void rbtRelHeData_CheckedChanged(object sender, EventArgs e)
        {
            txtRelHeMat.Enabled = false;
            mskRelHeIni.Enabled = true;
            mskRelHeFim.Enabled = true;
            txtRelHeMat.Clear();
            dtgridRelHe.Rows.Clear();
        
        }

        private void rbtRelHeMat_CheckedChanged(object sender, EventArgs e)
        {
            txtRelHeMat.Enabled = true;
            mskRelHeIni.Enabled = false;
            mskRelHeFim.Enabled = false;
            mskRelHeFim.Clear();
            mskRelHeIni.Clear();
            dtgridRelHe.Rows.Clear();
        }

        private void mskRelHeIni_Leave(object sender, EventArgs e)
        {
            if (mskRelHeIni.Text.Contains(" ") && rbtRelHeData.Checked)
            {
                MessageBox.Show("A data informada é inválida");
                btnRelHePesquisar.Enabled = false;
            }
            else
            {
                btnRelHePesquisar.Enabled = true;
            }

        }


        private static void ConvertToDateTime(string value)
        {
            DateTime convertedDate;
            try
            {
                convertedDate = Convert.ToDateTime(value);
                //  falta limpar o campo  se a data tiver errado
            }
            catch (FormatException)
            {
                MessageBox.Show("A data informada é inválida");
            }
        }

        private void mskRelHeFim_Leave(object sender, EventArgs e)
        {
            if (mskRelHeFim.Text.Contains(" ")  && rbtRelHeData.Checked )
            {
                MessageBox.Show("A data informada é inválida");
                btnRelHePesquisar.Enabled = false;
            }
            else
            {
                btnRelHePesquisar.Enabled = true;
            }
        }

        private void txtRelHeMat_Leave(object sender, EventArgs e)
        {
            if (txtRelHeMat.Text.Equals("") && rbtRelHeMat.Checked)
            {
                MessageBox.Show("Por favor, informe a matrícula");
                btnRelHePesquisar.Enabled = false;
            }
            else
            {
                btnRelHePesquisar.Enabled = true;
            }
        }

        private void cboRelEscEscala_Click(object sender, EventArgs e)
        {
            foreach (Ausencia x in AusenciaDAO.ObterAusencias())
            {
                if (!cboRelEscEscala.Items.Contains(x.Nome))
                {
                    cboRelEscEscala.Items.Add(x.Nome);
                }
            }
        }

        private void rbtRelEscMat_CheckedChanged(object sender, EventArgs e)
        {
            txtRelEscMat.Enabled = true;
            cboRelEscEscala.Enabled = false;
            cboRelEscEscala.Text.Equals("");
        }

        private void rbtRelEscEscala_CheckedChanged(object sender, EventArgs e)
        {
            txtRelEscMat.Enabled = false;
            txtRelEscMat.Clear();
            cboRelEscEscala.Enabled = true;

        }

        private void txtRelEscMat_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void txtRelEscMat_Leave(object sender, EventArgs e)
        {
            if (txtRelEscMat.Text.Equals(""))
            {
                MessageBox.Show("Por favor, informe a matrícula");
                btnRelEscPesq.Enabled = false;
            }

        }

        private void mskRelEscDtIni_Leave(object sender, EventArgs e)
        {
            if (mskRelEscDtIni.Text.Contains(" "))
            {
                MessageBox.Show("Por favor, informe a data.");
                mskRelEscDtIni.Clear();
            }
            else
            {
                DateTime dataE;
                string dt = mskRelEscDtIni.Text;

                try
                {
                    dataE = Convert.ToDateTime(dt);

                }
                catch
                {
                    MessageBox.Show("A data informada é inválida.");
                    mskRelEscDtIni.Clear();

                }
            }
        }

        private void mskRelEscFim_Leave(object sender, EventArgs e)
        {
            if (mskRelEscFim.Text.Contains(" "))
            {
                MessageBox.Show("A data informada é inválida");
                btnRelEscPesq.Enabled = false;
            }
            else
            {
                if (rbtRelEscEscala.Checked)
                {
                    if (cboRelEscEscala.Text.Equals("") && mskRelEscDtIni.Text.Contains(" "))
                    {
                        MessageBox.Show("Por favor, informe o tipo de escala, data inicial e data final.");
                        btnRelEscPesq.Enabled = false;
                    }
                    else
                    {
                        btnRelEscPesq.Enabled = true;
                    }

                }
                else
                {
                    if (txtRelEscMat.Text.Equals("") && mskRelEscDtIni.Text.Contains(" "))
                    {
                        MessageBox.Show("Por favor, informe a matrícula, data inicial e data final.");
                        btnRelEscPesq.Enabled = false;
                    }
                    else
                    {
                        btnRelEscPesq.Enabled = true;
                    }
                }
            }
            
        }

        private void btnRelEscPesq_Click(object sender, EventArgs e)
        {
            dtgridRelEsc.Rows.Clear();
            
            int total = 0;
            int i = 0;

            foreach (Funcionario x in FuncionarioDAO.ObterFuncionarios())
            {
                total++;
            }
            txtRelEscTotalFunc.Text = total.ToString();

            DateTime ini = Convert.ToDateTime(mskRelEscDtIni.Text);
            DateTime fim = Convert.ToDateTime(mskRelEscFim.Text);

            if (rbtRelEscMat.Checked)
            {
                int mat;
                bool conv;
                mskRelEscPercent.Clear();

                conv = Int32.TryParse(txtRelEscMat.Text, out mat);
                if (conv == false)
                {
                    mat = 0;
                }

                Funcionario Funcionario = new Funcionario();
                Funcionario = FuncionarioDAO.ObterFuncionarioId(mat);

                if (Funcionario == null)
                {
                    MessageBox.Show("A matrícula informada não existe.");
                    txtRelEscMat.Clear();
                }
                else
                {
                    foreach (Escala x in EscalaDAO.ObterEscalaIDeData(mat, ini, fim))
                    {
                        dtgridRelEsc.Rows.Add(x.Funcionario.Id, x.Funcionario.Nome, x.Data, x.Ausencia.Nome);
                        i++;
                    }
                    txtRelEscTotalEsc.Text = i.ToString();
                }
            }
            else
            {
                if (cboRelEscEscala.Text.Equals(""))
                {
                    MessageBox.Show("Por favor, infome o tipo de escala");
                }
                else
                {
                    string tipo = cboRelEscEscala.SelectedItem.ToString();

                    foreach (Escala x in EscalaDAO.ObterEscalaTipo(tipo, ini, fim))
                    {
                        dtgridRelEsc.Rows.Add(x.Funcionario.Id, x.Funcionario.Nome, x.Data, x.Ausencia.Nome);
                        i++;
                    }
                    txtRelEscTotalEsc.Text = i.ToString();
                    mskRelEscPercent.Text = EscalaBO.CalcularPercentualEscala(total, i);
                }

            }

        }

        private void btnRelAusencias_Click(object sender, EventArgs e)
        {
            dtgridRelAusencias.Rows.Clear();
            foreach (Ausencia x in AusenciaDAO.ObterAusencias())
            {
                dtgridRelAusencias.Rows.Add(x.Id, x.Nome, x.Sigla);
            }
        }
 
        private void btnRelFuncPesquisar_Click(object sender, EventArgs e)
        {
            dtgridRelFuncionarios.Rows.Clear();
            foreach (Funcionario x in FuncionarioDAO.ObterFuncionarios())
            {
                dtgridRelFuncionarios.Rows.Add(x.Id, x.Nome, x.Nascimento, x.Endereco, x.Cidade, x.Telefone, x.Rg, x.Cpf, x.Admissao);
            }
        }

        private void rbtRelDptoTodos_CheckedChanged(object sender, EventArgs e)
        {
            btnRelDptoPesquisar.Enabled = true;
            dtgridRelDpto.Rows.Clear();
            cboRelDptoCargo.Text = "";
            cboRelDptoCargo.Enabled = false;
            mskRelDptoHorario.Clear();
            mskRelDptoHorario.Enabled = false;
            txtRelDptoMatricula.Clear();
            txtRelDptoMatricula.Enabled = false;
            cboRelDptoSupervisor.Text = ("");
            cboRelDptoSupervisor.Enabled = false;

        }

        private void btnRelDptoPesquisar_Click(object sender, EventArgs e)
        {
            txtRelDptoTotal.Clear();
            dtgridRelDpto.Rows.Clear();

            int i = 0;

            if (rbtRelDptoTodos.Checked)
            {
                foreach (Departamento x in DepartamentoDAO.ObterFuncionariosDepartamento())
                {
                    dtgridRelDpto.Rows.Add(x.Funcionario.Id, x.Funcionario.Nome, x.Horario, x.Supervisor.Nome, x.Cargo.Nome);
                    i++;
                }
                txtRelDptoTotal.Text = i.ToString();
            }
            else
            {
                if (rbtRelDptoCargo.Checked)
                {
                    string cargo = cboRelDptoCargo.SelectedItem.ToString();
                    foreach (Departamento x in DepartamentoDAO.ObterFuncionariosDptoCargo(cargo))
                    {
                        dtgridRelDpto.Rows.Add(x.Funcionario.Id, x.Funcionario.Nome, x.Horario, x.Supervisor.Nome, x.Cargo.Nome);
                        i++;
                    }
                    txtRelDptoTotal.Text = i.ToString();
                }
                else
                {
                    if (rbtRelDptoHorario.Checked)
                    {
                        DateTime horario;
                        string hrs = mskRelDptoHorario.Text;
                        horario = Convert.ToDateTime(hrs);

                        foreach(Departamento x in DepartamentoDAO.ObterFuncDptoHorario(horario))
                        {
                            dtgridRelDpto.Rows.Add(x.Funcionario.Id, x.Funcionario.Nome, x.Horario, x.Supervisor.Nome, x.Cargo.Nome);
                            i++;
                        }
                        txtRelDptoTotal.Text = i.ToString();
                    }
                    else
                    {
                        if (rbtRelDptoMatricula.Checked)
                        {
                            int mat = int.Parse(txtRelDptoMatricula.Text);
                            foreach (Departamento x in DepartamentoDAO.ObterFuncionariosDptoID(mat))
                            {
                                dtgridRelDpto.Rows.Add(x.Funcionario.Id, x.Funcionario.Nome, x.Horario, x.Supervisor.Nome, x.Cargo.Nome);
                                i++;
                            }
                            txtRelDptoTotal.Text = i.ToString();
                        }
                        else
                        {
                            string super = cboRelDptoSupervisor.Text;

                            foreach (Departamento x in DepartamentoDAO.ObterFuncionariosDptoSuperv(super))
                            {
                                dtgridRelDpto.Rows.Add(x.Funcionario.Id, x.Funcionario.Nome, x.Horario, x.Supervisor.Nome, x.Cargo.Nome);
                                i++;
                            }
                            txtRelDptoTotal.Text = i.ToString();
                        }
                    }

                }
                //////////////////////////////////////////////////
            }
        }

        private void cboRelDptoCargo_Click(object sender, EventArgs e)
        {
            foreach (Cargo x in CargoDAO.ObterCargos())
            {
                if (!cboRelDptoCargo.Items.Contains(x.Nome))
                {
                    cboRelDptoCargo.Items.Add(x.Nome);
                }
            }
        }

        private void cboRelDptoCargo_Leave(object sender, EventArgs e)
        {
            if (rbtRelDptoCargo.Checked && cboRelDptoCargo.Text.Equals(""))
            {
                MessageBox.Show("Por favor, selecione um cargo.");
                btnRelDptoPesquisar.Enabled = false;
            }
            else
            {
                btnRelDptoPesquisar.Enabled = true;
            }
        }

        private void rbtRelDptoCargo_Click(object sender, EventArgs e)
        {
            dtgridRelDpto.Rows.Clear();
            cboRelDptoCargo.Text = "";
            cboRelDptoCargo.Enabled = true;
            mskRelDptoHorario.Clear();
            mskRelDptoHorario.Enabled = false;
            txtRelDptoMatricula.Clear();
            txtRelDptoMatricula.Enabled = false;
            cboRelDptoSupervisor.Text = ("");
            cboRelDptoSupervisor.Enabled = false;
            txtRelDptoTotal.Clear();
        }

        private void rbtRelDptoHorario_CheckedChanged(object sender, EventArgs e)
        {
            dtgridRelDpto.Rows.Clear();
            cboRelDptoCargo.Text = "";
            cboRelDptoCargo.Enabled = false;
            mskRelDptoHorario.Clear();
            mskRelDptoHorario.Enabled = true;
            txtRelDptoMatricula.Clear();
            txtRelDptoMatricula.Enabled = false;
            cboRelDptoSupervisor.Text = ("");
            cboRelDptoSupervisor.Enabled = false;
            txtRelDptoTotal.Clear();
        }

        private void mskRelDptoHorario_Leave(object sender, EventArgs e)
        {
            
            if (mskRelDptoHorario.Text.Contains(" "))
            {
                MessageBox.Show("Por favor, informe o horário corretamente.");
                btnRelDptoPesquisar.Enabled = false;
            }
            else
            {
                DateTime convertedDate;
                string hrs = mskRelDptoHorario.Text;
                bool ok;
                try
                {
                    convertedDate = Convert.ToDateTime(hrs);
                    ok = true;
                    btnRelDptoPesquisar.Enabled = true;
                }
                catch (FormatException)
                {
                    ok = false;
                    MessageBox.Show("O horário informado é inválido");
                    btnRelDptoPesquisar.Enabled = false;
                }
                         
            }
        }

        private void rbtRelDptoMatricula_CheckedChanged(object sender, EventArgs e)
        {
            dtgridRelDpto.Rows.Clear();
            cboRelDptoCargo.Text = "";
            cboRelDptoCargo.Enabled = false;
            mskRelDptoHorario.Clear();
            mskRelDptoHorario.Enabled = false;
            txtRelDptoMatricula.Clear();
            txtRelDptoMatricula.Enabled = true;
            cboRelDptoSupervisor.Text = ("");
            cboRelDptoSupervisor.Enabled = false;
            txtRelDptoTotal.Clear();
        }

        private void txtRelDptoMatricula_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void txtRelDptoMatricula_Leave(object sender, EventArgs e)
        {
            if (txtRelDptoMatricula.Text.Equals(""))
            {
                MessageBox.Show("Por favor, informe a matrícula.");
                btnRelDptoPesquisar.Enabled = false;
            }
            else
            {
                btnRelDptoPesquisar.Enabled = true;
            }
        }

        private void rbtRelDptoSupervisor_CheckedChanged(object sender, EventArgs e)
        {
            dtgridRelDpto.Rows.Clear();
            cboRelDptoCargo.Text = "";
            cboRelDptoCargo.Enabled = false;
            mskRelDptoHorario.Clear();
            mskRelDptoHorario.Enabled = false;
            txtRelDptoMatricula.Clear();
            txtRelDptoMatricula.Enabled = false;
            cboRelDptoSupervisor.Text = ("");
            cboRelDptoSupervisor.Enabled = true;
            txtRelDptoTotal.Clear();
        }

        private void cboRelDptoSupervisor_Click(object sender, EventArgs e)
        {
            foreach (Departamento x in DepartamentoDAO.ObterSupervisores())
            {
                if (!cboRelDptoSupervisor.Items.Contains(x.Supervisor.Nome))
                {
                    cboRelDptoSupervisor.Items.Add(x.Supervisor.Nome);
                }
            }
        }

        private void cboRelDptoSupervisor_Leave(object sender, EventArgs e)
        {
            if (cboRelDptoSupervisor.Text.Equals(""))
            {
                MessageBox.Show("Por favor, informe o nome do supervisor.");
                btnRelDptoPesquisar.Enabled = false;
            }
            else
            {
                btnRelDptoPesquisar.Enabled = true;
            }
        }

        private void frmRelatorios_Load(object sender, EventArgs e)
        {
            if (pri.lblTipoUsu.Text.Equals("USUÁRIO"))
            {
                btnRelFuncPesquisar.Enabled = false;
                groupBox3.Enabled = false;
                btnRelAusencias.Enabled = true;
                txtRelEscMat.Text = pri.lblFuncID.Text;
                txtRelEscMat.Enabled = false;
                txtRelHeMat.Text = pri.lblFuncID.Text;
                txtRelHeMat.Enabled = false;
                btnRelCargos.Enabled = true;
                grpRelU.Enabled = false;
            }
        }

        private void tabCadCadastro_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabCadCadastro_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (pri.lblTipoUsu.Text.Equals("USUÁRIO"))
            {
                btnRelFuncPesquisar.Enabled = false;
                groupBox3.Enabled = false;
                btnRelAusencias.Enabled = true;
                rbtRelEscMat.Checked = true;
                txtRelEscMat.Text = pri.lblFuncID.Text;
                txtRelEscMat.Enabled = false;
                rbtRelHeMat.Checked = true;
                txtRelHeMat.Text = pri.lblFuncID.Text;
                txtRelHeMat.Enabled = false;
                btnRelCargos.Enabled = true;
                grpRelU.Enabled = false;
                groupBox2.Enabled = false;
                groupBox1.Enabled = false;

            }
        }



        // fim **********************************
    }
}
