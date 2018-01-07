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

                ((Control)this.tabPretConsultar).Enabled = false;
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
            LimparCampos();

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



        private void cboPretCadAno_Leave(object sender, EventArgs e)
        {
            DesabilitarDatas();

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

                    HabilitarDatas();
                    if (pre == null)
                    {
                        //
                    }
                    else
                    {
                        MessageBox.Show("Você já possui pretensões para este período aquisitivo.");

                        if (pre.per1_op1_inicio != null)
                        {
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
                        else
                        {
                            HabilitarDatas();
                        }
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


        private void datePretCadPer1Inicio_Leave(object sender, EventArgs e)
        {
            //CÉLULA VAZIA
            if (CelulaVazia(datePretCadPer1Inicio) == false)
            {
                DateTime data;
                data = Convert.ToDateTime(datePretCadPer1Inicio.Text);

                // PERÍODO AQUISITIVO
                if (VerifPeriodoAquisitivo(data) == false)
                {
                    // MAIOR QUE O ANO LIMITE
                    if (AnoLimite(data) == false)
                    {
                        // COMEÇA EM DIA ÚTIL
                        if (ConsultarDiaUtil(data) == false)
                        {

                            //1 SEMANA DE INTERVALO ENTRE AS OPÇÕES
                            if (IntervaloOpcoes(data) == false)
                            {

                                //INVADE PERÍODO ÚMIDO
                                if (InvadePeriodoUmido(data) == false)
                                {

                                    //INVADE PERÍODO NOBRE
                                    if (InvadePeriodoNobre(data) == false)
                                    {
                                        MessageBox.Show("A data informada foi validada.", "Data validada", MessageBoxButtons.OK, MessageBoxIcon.None);
                                    }
                                    else
                                    {
                                        LimparData1();
                                    }
                                }
                                else
                                {
                                    LimparData1();
                                }
                            }
                            else
                            {
                                LimparData1();
                            }
                        }
                        else
                        {
                            LimparData1();
                        }
                    }
                    else
                    {
                        LimparData1();
                    }
                }
                else
                {
                    LimparData1();
                }
            }
            else
            {
                LimparData1();
            }

        }





        private void datePretCadPer1Fim_Leave(object sender, EventArgs e)
        {
            //CÉLULA VAZIA
            if (CelulaVazia(datePretCadPer1Fim) == false)
            {

                //DATA INICIAL VAZIA
                if (CelulaVazia(datePretCadPer1Inicio) == false)
                {
                    DateTime data;
                    data = Convert.ToDateTime(datePretCadPer1Fim.Text);

                    // PERÍODO AQUISITIVO
                    if (VerifPeriodoAquisitivo(data) == false)
                    {
                        // MAIOR QUE O ANO LIMITE
                        if (AnoLimite(data) == false)
                        {

                            //INVADE PERÍODO ÚMIDO
                            if (InvadePeriodoUmido(data) == false)
                            {

                                //INVADE PERÍODO NOBRE
                                if (InvadePeriodoNobre(data) == false)
                                {

                                    // DATA FINAL MENOR QUE INICIAL
                                    if (CompararDatas(datePretCadPer1Inicio, data) == false)

                                    {
                                        MessageBox.Show("A data informada foi validada.", "Data validada", MessageBoxButtons.OK, MessageBoxIcon.None);
                                        txtPretCadPer1Dias.Text = CalcularDatas(datePretCadPer1Inicio, data);
                                    }
                                    else
                                    {
                                        LimparData2();
                                    }

                                }
                                else
                                {
                                    LimparData2();
                                }
                            }
                            else
                            {
                                LimparData2();
                            }




                        }
                        else
                        {

                            LimparData2();
                        }
                    }
                    else
                    {
                        LimparData2();
                    }
                }
                else
                {
                    LimparData1();
                    LimparData2();
                }

            }
            else
            {
                LimparData1();
            }
        }

        private void datePretCadPer2Inicio_Leave(object sender, EventArgs e)
        {
            if (!datePretCadPer2Inicio.Text.Equals(" "))
            {
                DateTime data;

                data = Convert.ToDateTime(datePretCadPer2Inicio.Text);
                if (VerifPeriodoAquisitivo(data) != true)
                {

                }
                else
                {
                    LimparData3();
                }
            }
            else
            {
                MessageBox.Show("Por favor, informe uma data.", "Data incorreta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimparData1()
        {
            datePretCadPer1Inicio.CustomFormat = " ";
            datePretCadPer1Inicio.Format = DateTimePickerFormat.Custom;
        }

        private void LimparData2()
        {
            datePretCadPer1Fim.CustomFormat = " ";
            datePretCadPer1Fim.Format = DateTimePickerFormat.Custom;
        }

        private void LimparData3()
        {
            datePretCadPer2Inicio.CustomFormat = " ";
            datePretCadPer2Inicio.Format = DateTimePickerFormat.Custom;
        }

        private void datePretCadPer2Fim_Leave(object sender, EventArgs e)
        {
            // DATA FINAL VAZIA
            if (!datePretCadPer2Fim.Text.Equals(" "))
            {   // DATA INICIAL VAZIA
                if (!datePretCadPer2Inicio.Text.Equals(" "))
                {
                    DateTime ini, fim;

                    fim = Convert.ToDateTime(datePretCadPer2Fim.Text);
                    // VERIFICA SE A DATA ESTÁ DENTRO DO PERÍODO AQUISITIVO
                    if (VerifPeriodoAquisitivo(fim) == true)
                    {
                        ini = Convert.ToDateTime(datePretCadPer2Inicio.Text);

                        //VERIFICA SE A DATA FINAL É MAIOR DO QUE A INICIAL
                        if (ini < fim)
                        {
                            TimeSpan dias;
                            dias = fim.Subtract(ini);
                            int total = dias.Days + 1;

                            //VERIFICA O TOTAL DE DIAS
                            if (total <= 30)
                            {
                                if (total >= 5)
                                {
                                    txtPretCadPer2Dias.Text = total.ToString();
                                }
                                else
                                {
                                    MessageBox.Show("O período de férias não pode ser inferior a 5 dias.", "Data incorreta", MessageBoxButtons.OK, MessageBoxIcon.Error);

                                }
                            }
                            else
                            {
                                MessageBox.Show("O período de férias não pode ultrapassar 30 dias.", "Data incorreta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                        }
                        else
                        {
                            MessageBox.Show("A data final deve ser maior do que a data inicial.", "Data incorreta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }
                    else
                    {
                        datePretCadPer2Fim.CustomFormat = " ";
                        datePretCadPer2Fim.Format = DateTimePickerFormat.Custom;
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, informe uma data para o início do primeiro período.", "Data não informada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Por favor, informe uma data.", "Data incorreta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // MÉTODOS DE VALIDAÇÃO @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@


        public void LimparCampos()
        {
            txtPretCadNome.Clear();
            txtPretCadTurno.Clear();
            cboPretCadAno.Text = "";
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
            dtgPretCad.Rows.Clear();

        }

        private Boolean CelulaVazia(Control x)
        {
            if (((DateTimePicker)x).Text.Equals(" "))
            {

                MessageBox.Show("Por favor, informe uma data.", "Data incorreta", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return true;
            }
            else
            {
                return false;
            }
        }


        private Boolean VerifPeriodoAquisitivo(DateTime data)
        {
            DateTime pAqIni, pAqFim;
            pAqIni = Convert.ToDateTime(txtPretCadPaqInicio.Text);
            pAqFim = Convert.ToDateTime(txtPretCadPaqFim.Text);

            if (data < pAqIni || data > pAqFim)
            {
                MessageBox.Show("A data informada está fora do período aquisitivo.", "Data incorreta", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return true;
            }
            else
            {
                return false;
            }
        }


        private Boolean AnoLimite(DateTime data)
        {
            if (data.Year >= 2020)
            {
                MessageBox.Show("Ano não liberado para cadastro de pretensões.", "Data incorreta", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return true;
            }
            else
            {
                return false;
            }
        }

        private Boolean ConsultarDiaUtil(DateTime data)
        {
            if (data.DayOfWeek.ToString().Equals("Sunday") || data.DayOfWeek.ToString().Equals("Saturday"))
            {
                MessageBox.Show("A data informada deve ser um dia útil.", "Data incorreta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            else
            {
                Data dt = DataDAO.PesquisarFeriado(data);

                if (dt != null)
                {
                    MessageBox.Show("A data informada não pode ser um feriado.", "Data incorreta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }


        private Boolean IntervaloOpcoes(DateTime data)
        {
            int i, l;
            i = dtgPretCad.FirstDisplayedScrollingRowIndex;
            l = dtgPretCad.RowCount;

            TimeSpan dias;
            string opcao;
            DateTime op;

            do
            {
                if (dtgPretCad[1, i].Value != null)
                {
                    opcao = dtgPretCad[1, i].Value.ToString();
                    op = Convert.ToDateTime(opcao);
                    if (op.DayOfYear >= data.DayOfYear)
                    {
                        dias = op - data;
                    }
                    else
                    {
                        dias = data - op;
                    }

                    i++;

                    if (dias.Days < 7)
                    {
                        MessageBox.Show("As datas de início das opções informadas devem ter um intervalo mínimo de uma semana entre elas. ", "Data incorreta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return true;
                    }

                }
                else
                {
                    return false;
                }

            } while (i <= l - 1);

            return false;
        }

        private Boolean InvadePeriodoUmido(DateTime data)
        {
            int dt = 0;
            List<DateTime> datas = new List<DateTime>();



            if (DataDAO.PeriodoUmido(data) != null)
            {
                datas = DataDAO.PeriodoUmido(data).ToList();

                foreach (DateTime x in datas)
                {

                    if (x.DayOfYear < datas.First().DayOfYear)
                    {
                        return false;
                    }
                    else
                    {
                        if (x.DayOfYear == data.DayOfYear)
                        {
                            dt = 1;
                        }
                    }

                }

                if (dt == 0)
                {
                    MessageBox.Show("A data informada não pode ser diferente das datas predefinidas para o período úmido. ", "Data incorreta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return true;
                }
            }

            return false;


        }

        private Boolean InvadePeriodoNobre(DateTime data)
        {
            int dt = 0;
            List<DateTime> datas = new List<DateTime>();

            if (DataDAO.PeriodoNobre(data) != null)
            {
                datas = DataDAO.PeriodoNobre(data).ToList();

                foreach (DateTime x in datas)
                {

                    if (x.DayOfYear > datas.Last().DayOfYear)
                    {
                        return false;
                    }
                    else
                    {
                        if (x.DayOfYear == data.DayOfYear)
                        {
                            dt = 1;
                        }
                    }

                }

                if (dt == 0)
                {
                    MessageBox.Show("A data informada não pode ser diferente das datas predefinidas para o período nobre. ", "Data incorreta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return true;
                }
            }

            return false;


        }

        private void DesabilitarDatas()
        {
            dtgPretCad.Rows.Clear();
            datePretCadPer1Inicio.Enabled = false;
            datePretCadPer1Fim.Enabled = false;
            datePretCadPer2Inicio.Enabled = false;
            datePretCadPer2Fim.Enabled = false;

        }

        private void HabilitarDatas()
        {
            datePretCadPer1Inicio.Enabled = true;
            datePretCadPer1Fim.Enabled = true;
            datePretCadPer2Inicio.Enabled = true;
            datePretCadPer2Fim.Enabled = true;

        }

        private Boolean CompararDatas(Control x, DateTime fim)
        {
            string ini;
            DateTime inicio;

            ini = x.Text.ToString();
            inicio = Convert.ToDateTime(ini);

            if (fim < inicio)
            {
                MessageBox.Show("A data final deve ser maior do que a data inicial.", "Data incorreta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }

            return false;

        }

        private string CalcularDatas (Control x , DateTime fim)
        {
           
            string ini;
            DateTime inicio;
            int dias;

            ini = x.Text.ToString();
            inicio = Convert.ToDateTime(ini);

            dias = fim.DayOfYear - inicio.DayOfYear + 1;

            return dias.ToString();
        }

        private void ControleAcesso()
        {

        }

        //private Boolean TudoNobre(Control x, DateTime fim)
        //{
        //    string ini;
        //    DateTime inicio;
        //    TimeSpan dias;

        //    ini = x.Text.ToString();
        //    inicio = Convert.ToDateTime(ini);
        //}

    }
}
