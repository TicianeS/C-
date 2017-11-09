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
using CallPostgre.Util;

namespace CallPostgre.View
{
    public partial class FrmPretensao : Form
    {
        FrmPrincipal pri;
        public FrmPretensao(FrmPrincipal x)
        {
            pri = x;
            InitializeComponent();
        }

        private void FrmPretensao_Load(object sender, EventArgs e)
        {
            LimparCampos();

            string perfil = pri.lblFrmPrincipalPerfil.Text;

            if (perfil.Equals("TELEATENDENTE"))
            {
                txtPretCadRegistro.Text = pri.lblFrmPrincipalRegistro.Text;
                txtPretCadRegistro.Enabled = false;
                txtPretCadNome.Text = pri.lblFrmPrincipalNome.Text;

                int reg = Tools.ConverterParaInt(pri.lblFrmPrincipalRegistro.Text);

                Departamento dep = new Departamento();
                dep = DepartamentoDAO.PesquisarFuncRegMes(reg);

                string turno = Tools.VerificarTurno(dep.horario);
                txtPretCadTurno.Text = turno;
            }
            else
            {
                txtPretCadRegistro.Enabled = true;
            }
        }

        private void txtPretCadRegistro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void txtPretCadRegistro_Leave(object sender, EventArgs e)
        {
            string perfil = pri.lblFrmPrincipalPerfil.Text;
            int reg = Tools.ConverterParaInt(txtPretCadRegistro.Text);

            Funcionario f = new Funcionario();
            f = FuncionarioDAO.ObterFuncionarioId(reg);

            if (f == null)
            {
                MessageBox.Show("Funcionário não cadastrado.");
                LimparCampos();
            }
            else
            {
                if (perfil.Equals("MONITOR") || perfil.Equals("APOIO MONITOR") && !f.cargos.nome.Contains("TELEATENDENTE"))
                {
                    MessageBox.Show("Acesso negado.");
                }
                else
                {
                    txtPretCadNome.Text = f.nome;
                    Departamento dep = new Departamento();
                    dep = DepartamentoDAO.PesquisarFuncRegMes(reg);

                    string turno = Tools.VerificarTurno(dep.horario);
                    txtPretCadTurno.Text = turno;
                }
            }
        }

        public void LimparCampos()
        {
            txtPretCadNome.Clear();
            txtPretCadTurno.Clear();
            cboPretCadAno.SelectedItem = "";
            txtPretCadPaqInicio.Clear();
            txtPretCadPaqFim.Clear();

            datePretCadPer1Inicio.CustomFormat = " ";
            datePretCadPer1Inicio.Format = DateTimePickerFormat.Custom;

            datePretCadPer1Fim.CustomFormat = " ";
            datePretCadPer1Fim.Format = DateTimePickerFormat.Custom;

            datePretCadPer2Inicio.CustomFormat = " ";
            datePretCadPer2Inicio.Format = DateTimePickerFormat.Custom;

            datePretCadPer2Fim.CustomFormat = " ";
            datePretCadPer2Fim.Format = DateTimePickerFormat.Custom;

            txtPretCadPer1Dias.Clear();
            txtPretCadPer2Dias.Clear();

        }

        private void cboPretCadAno_Leave(object sender, EventArgs e)
        {
            if (cboPretCadAno.Text.Equals(""))
            {
                MessageBox.Show("Por favor, informe o ano.", "Dados incorretos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int ano = int.Parse(cboPretCadAno.Text);
                int reg = int.Parse(txtPretCadRegistro.Text);

                Funcionario f = new Funcionario();
                f = FuncionarioDAO.ObterFuncionarioId(reg);

                DateTime inicio = new DateTime(ano, f.per_aquisitivo.Value.Month, f.per_aquisitivo.Value.Day);
                DateTime fim;
                fim = inicio.AddDays(364);

                txtPretCadPaqInicio.Text = inicio.ToString("dd/MM/yyyy");
                txtPretCadPaqFim.Text = fim.ToString("dd/MM/yyyy");

                Ferias fe = new Ferias();
                fe = FeriasDAO.ObterFeriasFuncAno(reg, ano);

                if (fe == null)
                {
                    Pretensao pre = new Pretensao();
                    pre = PretensaoDAO.ObterPretFuncAno(reg, ano);
                    
                    if (pre == null)
                    {
                        datePretCadPer1Inicio.Enabled = true;
                        datePretCadPer1Fim.Enabled = true;
                        datePretCadPer2Inicio.Enabled = true;
                        datePretCadPer2Fim.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("Você já possui pretensões para este período aquisitivo.");

                        TimeSpan? p1, p2, p3, p4, p5, p6;
                        p1 = pre.per1_op1_fim - pre.per1_op1_inicio;
                        p2 = pre.per2_op1_fim - pre.per2_op1_inicio;
                        p3 = pre.per1_op2_fim - pre.per1_op2_inicio;
                        p4 = pre.per2_op2_fim - pre.per2_op2_inicio;
                        p5 = pre.per1_op3_fim - pre.per1_op3_inicio;
                        p6 = pre.per2_op3_fim - pre.per2_op3_inicio;

                        dtgPretCad.Rows.Add(
                            1,
                            pre.per1_op1_inicio.Value.ToString("dd/MM/yyyy"),
                            pre.per1_op1_fim.Value.ToString("dd/MM/yyyy"),
                            p1.Value.Days + 1,
                            pre.per2_op1_inicio.Value.ToString("dd/MM/yyyy"),
                            pre.per2_op1_fim.Value.ToString("dd/MM/yyyy"),
                            p2.Value.Days + 1,
                            (p1.Value.Days + 1) + (p2.Value.Days + 1));
                        

                        dtgPretCad.Rows.Add(
                            2,
                            pre.per1_op2_inicio.Value.ToString("dd/MM/yyyy"),
                            pre.per1_op2_fim.Value.ToString("dd/MM/yyyy"),
                            p3.Value.Days + 1,
                            pre.per2_op2_inicio.Value.ToString("dd/MM/yyyy"),
                            pre.per2_op2_fim.Value.ToString("dd/MM/yyyy"),
                            p4.Value.Days + 1,
                            (p3.Value.Days + 1) + (p4.Value.Days + 1));


                        dtgPretCad.Rows.Add(
                            3,
                            pre.per1_op3_inicio.Value.ToString("dd/MM/yyyy"),
                            pre.per1_op3_fim.Value.ToString("dd/MM/yyyy"),
                            p5.Value.Days + 1,
                            pre.per2_op3_inicio.Value.ToString("dd/MM/yyyy"),
                            pre.per2_op3_fim.Value.ToString("dd/MM/yyyy"),
                            p6.Value.Days + 1,
                            (p5.Value.Days + 1) + (p6.Value.Days + 1));
                    }
                }
                else
                {
                    MessageBox.Show("Você já possui férias autorizadas para o período aquisitivo selecionado. Para consultá-la acesse o meu Opções - Férias - Consultar férias autorizadas.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void tabPretensao_Selected(object sender, TabControlEventArgs e)
        {
            LimparCampos();
        }

        private void datePretCadPer2Fim_ValueChanged(object sender, EventArgs e)
        {
            datePretCadPer2Fim.CustomFormat = null;
        }

        private void datePretCadPer1Inicio_ValueChanged(object sender, EventArgs e)
        {
            datePretCadPer1Inicio.CustomFormat = null;
        }

        private void datePretCadPer1Fim_ValueChanged(object sender, EventArgs e)
        {
            datePretCadPer1Fim.CustomFormat = null;
        }

        private void datePretCadPer2Inicio_ValueChanged(object sender, EventArgs e)
        {
            datePretCadPer2Inicio.CustomFormat = null;
        }
    }
}
