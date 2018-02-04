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
            LimparCampos();

            Funcionario f = new Funcionario();
            f = FuncionarioDAO.ObterFuncionarioId(reg);

            if (f == null)
            {
                MessageBox.Show("Funcionário não cadastrado.");
                LimparCampos();
                cboPretCadAno.Enabled = false;
            }
            else
            {
                if (perfil.Equals("TELEATENDENTE"))
                {
                    MessageBox.Show("Acesso negado.");
                }
                else
                {
                    cboPretCadAno.Enabled = true;
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
            LimparData(1);
            LimparData(2);
            LimparData(3);
            LimparData(4);
            txtPretCadPer1Dias.Clear();
            txtPretCadPer2Dias.Clear();
            txtPretCadTotal.Clear();
            dtgPretCad.Rows.Clear();
            btnPretCadIncluir.Visible = false;
            btnPretCadIncluir.Enabled = false;
            btnPretCadAlterar.Visible = false;
            btnPretCadAlterar.Enabled = false;
            btnPretCadSalvar.Enabled = false;
            btnPretCadSalvar.Visible = false;

            if (cboPretCadAno.Text.Equals(""))
            {
                MessageBox.Show("Por favor, informe o ano.", "Dados incorretos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int ano = Tools.ConverterParaInt(cboPretCadAno.Text);
                int reg = Tools.ConverterParaInt(txtPretCadRegistro.Text);

                Funcionario f = new Funcionario();
                f = FuncionarioDAO.ObterFuncionarioId(reg);

                DateTime inicio = new DateTime(ano, f.per_aquisitivo.Value.Month, f.per_aquisitivo.Value.Day);
                DateTime fim = new DateTime(ano + 1, f.per_aquisitivo.Value.Month, f.per_aquisitivo.Value.Day);
                fim = fim.AddDays(-1);

                txtPretCadPaqInicio.Text = inicio.ToString("dd/MM/yyyy");
                txtPretCadPaqFim.Text = fim.ToString("dd/MM/yyyy");

                Ferias fe = new Ferias();
                fe = FeriasDAO.ObterFeriasFuncAno(reg, ano);

                if (fe == null)
                {
                    Pretensao pre = new Pretensao();
                    pre = PretensaoDAO.ObterPretFuncAno(reg, ano);

                    if (pre != null)
                    {
                        MessageBox.Show("Você já possui pretensões cadastradas para este período aquisitivo.");

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
                                // pre.per1_op1_inicio.Value.ToString("dd/MM/yyyy"),
                                PreencherDatas(pre.per1_op1_inicio),
                                // pre.per1_op1_fim.Value.ToString("dd/MM/yyyy"),
                                PreencherDatas(pre.per1_op1_fim),
                                CalcularPeriodo(p1),     
                               // pre.per2_op1_inicio.Value.ToString("dd/MM/yyyy"),
                                PreencherDatas(pre.per2_op1_inicio),
                               // pre.per2_op1_fim.Value.ToString("dd/MM/yyyy"),
                               PreencherDatas(pre.per2_op1_fim),
                                CalcularPeriodo(p2),
                                CalcularPeriodo(p1) + CalcularPeriodo(p2));


                            dtgPretCad.Rows.Add(
                                2,
                                //pre.per1_op2_inicio.Value.ToString("dd/MM/yyyy"),
                                PreencherDatas(pre.per1_op2_inicio),
                                //pre.per1_op2_fim.Value.ToString("dd/MM/yyyy"),
                                PreencherDatas(pre.per1_op2_fim),
                                CalcularPeriodo(p3),
                               // pre.per2_op2_inicio.Value.ToString("dd/MM/yyyy"),
                                PreencherDatas(pre.per2_op2_inicio),
                               // pre.per2_op2_fim.Value.ToString("dd/MM/yyyy"),
                               PreencherDatas(pre.per2_op2_fim),
                                CalcularPeriodo(p4),
                                CalcularPeriodo(p3) + CalcularPeriodo(p4));


                            dtgPretCad.Rows.Add(
                                3,
                                //pre.per1_op3_inicio.Value.ToString("dd/MM/yyyy"),
                                PreencherDatas(pre.per1_op3_inicio),
                                //pre.per1_op3_fim.Value.ToString("dd/MM/yyyy"),
                                PreencherDatas(pre.per1_op3_fim),
                                //p5.Value.Days + 1,
                                CalcularPeriodo(p5),
                                //pre.per2_op3_inicio.Value.ToString("dd/MM/yyyy"),
                                PreencherDatas(pre.per2_op3_inicio),
                                //pre.per2_op3_fim.Value.ToString("dd/MM/yyyy"),
                                PreencherDatas(pre.per2_op3_fim),
                                //p6.Value.Days + 1,
                                CalcularPeriodo(p6),
                                CalcularPeriodo(p5) + CalcularPeriodo(p6));

                            if (ConsultarPrazo() == false)
                            {
                                btnPretCadAlterar.Enabled = true;
                                btnPretCadAlterar.Visible = true;
                            }
                        }
                        
                    }
                    else
                    {
                        if (pre == null)
                        {
                            HabilitarDatas();
                           // datePretCadPer1Inicio.Value = inicio;
                            
                        }
                    }

                    

                }
                else
                {
                    string p1ini, p1fim;
                    TimeSpan? p1dias;

                    p1ini = fe.per1_inicio.Value.Date.ToString("dd/MM/yyyy");
                    p1fim = fe.per1_fim.Value.Date.ToString("dd/MM/yyyy");
                    p1dias = fe.per1_fim - fe.per1_inicio;
                    
                   
                    if (fe.per2_inicio == null)
                    {
                        MessageBox.Show("Você já possui férias autorizadas para o período aquisitivo selecionado." + "\n" + "\n" +
                           "Início: " + p1ini + "         Fim: " + p1fim + " - " + (p1dias.Value.Days + 1) + " dias.", 
                           "Cadastrar pretensões", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                     
                    else
                    {
                        string p2ini, p2fim;
                        TimeSpan? p2dias;
                        int feDias;

                        p2ini = fe.per2_inicio.Value.Date.ToString("dd/MM/yyyy");
                        p2fim = fe.per2_fim.Value.Date.ToString("dd/MM/yyyy");
                        p2dias = fe.per2_fim - fe.per2_inicio;
                        feDias = (p1dias.Value.Days + 1) + (p2dias.Value.Days + 1);

                        MessageBox.Show("Você já possui férias autorizadas para o período aquisitivo selecionado." + "\n" + "\n" +
                        "Primeiro período " + "\n" + "\n" +
                         "Início: " + p1ini + "         Fim: " + p1fim + " - " + (p1dias.Value.Days + 1) + " dias" + "\n" + "\n" +
                         "Segundo período " + "\n" + "\n" +
                         "Início: " + p2ini + "         Fim: " + p2fim + " - " + (p2dias.Value.Days + 1) + " dias" + "\n" + "\n" +
                         "Total: " + feDias + " dias.",
                         "Cadastrar pretensões", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }  
                    
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
            txtPretCadPer2Dias.Clear();
            btnPretCadIncluir.Enabled = false;
            btnPretCadIncluir.Visible = false;
        }

        private void datePretCadPer1Inicio_ValueChanged(object sender, EventArgs e)
        {
            datePretCadPer1Inicio.CustomFormat = null;
            txtPretCadPer1Dias.Clear();
            btnPretCadIncluir.Enabled = false;
            btnPretCadIncluir.Visible = false;

        }

        private void datePretCadPer1Fim_ValueChanged(object sender, EventArgs e)
        {
            datePretCadPer1Fim.CustomFormat = null;
            txtPretCadPer1Dias.Clear();
            btnPretCadIncluir.Enabled = false;
            btnPretCadIncluir.Visible = false;
        }

        private void datePretCadPer2Inicio_ValueChanged(object sender, EventArgs e)
        {
            datePretCadPer2Inicio.CustomFormat = null;
            txtPretCadPer2Dias.Clear();
            btnPretCadIncluir.Enabled = false;
            btnPretCadIncluir.Visible = false;
        }


        private void datePretCadPer1Inicio_Leave(object sender, EventArgs e)
        {
            //CÉLULA VAZIA
            if (CelulaAnteriorVazia(datePretCadPer1Inicio, 1) == false)
            {
                DateTime data;
                DateTime? dataFim;
                data = Convert.ToDateTime(datePretCadPer1Inicio.Text);
                dataFim = ConverterData(datePretCadPer1Fim);

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
                                if (InvadePeriodoUmido(data, dataFim) == false)
                                {

                                    //INVADE PERÍODO NOBRE
                                    if (InvadePeriodoNobre(data, dataFim) == false)
                                    {
                                        //  MessageBox.Show("A data informada foi validada.", "Data validada", MessageBoxButtons.OK, MessageBoxIcon.None);
                                        datePretCadPer1Fim.Enabled = true;
                                        // se os inicio e fim estiverem preenchidos calcula o total de dias
                                        if (CelulaVazia(datePretCadPer1Fim) == false)
                                        {
                                            int totalPer1 = CalcularDatas(datePretCadPer1Fim, data);

                                            int idade;
                                            idade = CalcularIdade(dataFim);

                                            if (Total(totalPer1, idade) == true)
                                            {
                                                LimparData(2);
                                                txtPretCadPer1Dias.Clear();
                                                datePretCadPer1Fim.Enabled = false;
                                            }
                                            else
                                            {
                                                txtPretCadPer1Dias.Text = totalPer1.ToString();
                                                AtualizarTotal();
                                                //datePretCadPer1Fim.Value = data;
                                                datePretCadPer1Fim.Enabled = true;
                                                
                                            }                                            
                                        }
                                        else
                                        {
                                            txtPretCadTotal.Clear();
                                        }
                                    }
                                    else
                                    {
                                        LimparData(1);
                                    }
                                }
                                else
                                {
                                    LimparData(1);
                                }
                            }
                            else
                            {
                                LimparData(1);
                            }
                        }
                        else
                        {
                            LimparData(1);
                        }
                    }
                    else
                    {
                        LimparData(1);
                    }
                }
                else
                {
                    LimparData(1);
                }
            }
            else
            {
                LimparData(1);
            }

        }





        private void datePretCadPer1Fim_Leave(object sender, EventArgs e)
        {
            //CÉLULA VAZIA
            if (CelulaAnteriorVazia(datePretCadPer1Fim, 2) == false)
            {

                //DATA ANTERIOR VAZIA
                if (CelulaAnteriorVazia(datePretCadPer1Inicio, 1) == false)
                {
                    DateTime data;
                    DateTime? dataIni;
                    data = Convert.ToDateTime(datePretCadPer1Fim.Text);
                    dataIni = ConverterData(datePretCadPer1Inicio);

                    // PERÍODO AQUISITIVO
                    if (VerifPeriodoAquisitivo(data) == false)
                    {
                        // MAIOR QUE O ANO LIMITE
                        if (AnoLimite(data) == false)
                        {

                            //INVADE PERÍODO ÚMIDO
                            if (InvadePeriodoUmido(dataIni, data) == false)
                            {

                                //INVADE PERÍODO NOBRE
                                if (InvadePeriodoNobre(dataIni, data) == false)
                                {

                                    // DATA FINAL MENOR QUE INICIAL
                                    if (CompararDatas(datePretCadPer1Inicio, data, 2) == false)

                                    {
                                    //    MessageBox.Show("A data informada foi validada.", "Data validada", MessageBoxButtons.OK, MessageBoxIcon.None);


                                            txtPretCadTotal.Clear();
                                        
                                        // se o inicio e fim estiverem preenchidos calcula o total de dias
                                        int per1Dias = CalcularDatas(datePretCadPer1Inicio, data);

                                        int idade;
                                        idade = CalcularIdade(data);

                                        if (Total(per1Dias, idade) == true)
                                        {
                                            LimparData(2);
                                            txtPretCadPer1Dias.Clear();
                                            datePretCadPer2Inicio.Enabled = false;

                                        }
                                        else
                                        {
                                            txtPretCadPer1Dias.Text = per1Dias.ToString();
                                            AtualizarTotal();
                                           // datePretCadPer2Inicio.Value = data;
                                            datePretCadPer2Inicio.Enabled = true;
                                            
                                        }


                                    }
                                    else
                                    {
                                        LimparData(2);
                                    }

                                }
                                else
                                {
                                    LimparData(2);
                                }
                            }
                            else
                            {
                                LimparData(2);
                            }

                        }
                        else
                        {

                            LimparData(2);
                        }
                    }
                    else
                    {
                        LimparData(2);
                    }
                }
                else
                {
                    LimparData(1);
                    LimparData(2);
                }

            }
            else
            {
                LimparData(1);
            }
        }

        private void datePretCadPer2Inicio_Leave(object sender, EventArgs e)
        {
            //CÉLULA VAZIA
            if (CelulaAnteriorVazia(datePretCadPer2Inicio, 3) == false)
            {
                //DATA ANTERIOR VAZIA
                if (CelulaAnteriorVazia(datePretCadPer1Inicio, 1) == false && CelulaAnteriorVazia(datePretCadPer1Fim, 2) == false)
                {
                    DateTime data;
                    DateTime? dataFim;
                    data = Convert.ToDateTime(datePretCadPer2Inicio.Text);
                    dataFim = ConverterData(datePretCadPer2Fim);

                    // PERÍODO AQUISITIVO
                    if (VerifPeriodoAquisitivo(data) == false)
                    {
                        // MAIOR QUE O ANO LIMITE
                        if (AnoLimite(data) == false)
                        {
                            // COMEÇA EM DIA ÚTIL
                            if (ConsultarDiaUtil(data) == false)
                            {

                                // primeiro período termina em dia útil
                                if (ConsultarDiaUtilFim(datePretCadPer1Fim) == false)
                                {
                                    //1 SEMANA DE INTERVALO ENTRE AS OPÇÕES
                                    if (IntervaloOpcoes(data) == false)
                                    {

                                        // 1 SEMANA DE INTERVALO ENTRE OS PERÍODOS
                                        if (CalcularDatas(datePretCadPer1Inicio, data) >= 7 && CalcularDatas(datePretCadPer1Fim, data) >= 7)
                                        {
                                            //INVADE PERÍODO ÚMIDO
                                            if (InvadePeriodoUmido(data, dataFim) == false)
                                            {

                                                //INVADE PERÍODO NOBRE
                                                if (InvadePeriodoNobre(data, dataFim) == false)
                                                {
                                                    // segundo período anterior ao primeiro
                                                    if (CompararDatas(datePretCadPer1Inicio, data, 3) == false)

                                                    {
                                                        // MessageBox.Show("A data informada foi validada.", "Data validada", MessageBoxButtons.OK, MessageBoxIcon.None);
                                                        datePretCadPer2Fim.Enabled = true;

                                                        // se os inicio e fim estiverem preenchidos calcula o total de dias
                                                        if (CelulaVazia(datePretCadPer2Fim) == false)
                                                        {
                                                            int per2Dias = CalcularDatas(datePretCadPer2Fim, data);

                                                            int idade;
                                                            idade = CalcularIdade(dataFim);

                                                            if (Total(per2Dias, idade) == true)
                                                            {
                                                                LimparData(3);
                                                                txtPretCadPer2Dias.Clear();
                                                                datePretCadPer2Fim.Enabled = false;
                                                            }
                                                            else
                                                            {
                                                                txtPretCadPer2Dias.Text = per2Dias.ToString();
                                                                AtualizarTotal();
                                                               // datePretCadPer2Fim.Value = data;
                                                                datePretCadPer2Fim.Enabled = true;
                                                                
                                                            }

                                                        }
                                                        else
                                                        {
                                                            txtPretCadTotal.Clear();
                                                        }
                                                    }
                                                    else
                                                    {
                                                        LimparData(3);
                                                    }
                                                }
                                                else
                                                {
                                                    LimparData(3);
                                                }
                                            }
                                            else
                                            {
                                                LimparData(3);
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("As datas de início e fim dos periodos de férias devem ter um intervalo mínimo de uma semana.", "Data inválida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            LimparData(3);
                                        }
                                    }
                                    else
                                    {
                                        LimparData(3);
                                    }
                                }
                                else
                                {
                                    LimparData(2);
                                    LimparData(3);
                                }
                            }
                            else
                            {
                                LimparData(3);
                            }
                        }
                        else
                        {
                            LimparData(3);
                        }
                    }
                    else
                    {
                        LimparData(3);
                    }
                }
                else
                {
                    LimparData(3);
                }
            }
            else
            {
                LimparData(3);
            }
        }

        

        private void datePretCadPer2Fim_Leave(object sender, EventArgs e)
        {
            //CÉLULA VAZIA
            if (CelulaAnteriorVazia(datePretCadPer2Fim, 4) == false)
            {
                //DATA ANTERIOR VAZIA
                if (CelulaAnteriorVazia(datePretCadPer1Inicio, 1) == false && CelulaAnteriorVazia(datePretCadPer1Fim, 2) == false && CelulaAnteriorVazia(datePretCadPer2Inicio, 3) == false)
                {
                    DateTime data;
                    DateTime? dataIni;
                    data = Convert.ToDateTime(datePretCadPer2Fim.Text);
                    dataIni = ConverterData(datePretCadPer2Inicio);

                    // PERÍODO AQUISITIVO
                    if (VerifPeriodoAquisitivo(data) == false)
                    {
                        // MAIOR QUE O ANO LIMITE
                        if (AnoLimite(data) == false)
                        {

                            // DATA INICIAL MEIOR QUE A DATA FINAL
                            if (CompararDatas(datePretCadPer2Inicio, data, 4) == false)
                            {

                                //INVADE PERÍODO ÚMIDO
                                if (InvadePeriodoUmido(dataIni, data) == false)
                                {

                                    //INVADE PERÍODO NOBRE
                                    if (InvadePeriodoNobre(dataIni, data) == false)
                                    {
                                        // OS DOIS PERÍODOS SÃO NOBRES
                                        if (TodosNobres(datePretCadPer1Inicio, datePretCadPer1Fim) == true && TodosNobres(datePretCadPer2Inicio, datePretCadPer2Fim) == true)
                                        {
                                            MessageBox.Show("Os dois períodos escolhidos para férias são períodos nobres.", "Data incorreta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            LimparData(3);
                                           // LimparData(4);

                                            
                                        }
                                        else
                                        {
                                            // OS DOIS PERÍODOS SÃO ÚMIDOS
                                           // if (TodosUmidos(datePretCadPer1Inicio, datePretCadPer1Fim) == true && TodosUmidos(datePretCadPer2Inicio, datePretCadPer2Fim) == true)
                                            //{

                                              //  MessageBox.Show("Os dois períodos escolhidos para férias são períodos úmidos.", "Data incorreta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                //LimparData(3);
                                                //LimparData(4);

                                            //}
                                            //else
                                            //{
                                            //    MessageBox.Show("A data informada foi validada.", "Data validada", MessageBoxButtons.OK, MessageBoxIcon.None);

                                                   txtPretCadTotal.Clear();

                                                // se os inicio e fim estiverem preenchidos calcula o total de dias
                                                int per2Dias = CalcularDatas(datePretCadPer2Inicio, data);

                                            int idade;
                                            idade = CalcularIdade(data);

                                            if (Total(per2Dias, idade) == true)
                                                {
                                                    LimparData(4);
                                                    txtPretCadPer2Dias.Clear();
                                                }
                                                else
                                                {
                                                    txtPretCadPer2Dias.Text = per2Dias.ToString();
                                                    AtualizarTotal();
                                                    
                                                }
                                           // }
                                        }


                                    }
                                    else
                                    {
                                        LimparData(4);
                                    }
                                }
                                else
                                {
                                    LimparData(4);
                                }
                            }
                            else
                            {
                                LimparData(4);
                            }

                        }
                        else
                        {
                            LimparData(4);
                        }
                    }
                    else
                    {
                        LimparData(4);
                    }
                }
                else
                {
                    LimparData(4);
                }
            }
            else
            {
                LimparData(4);
            }
        }


        private void txtPretCadPer1Dias_TextChanged(object sender, EventArgs e)
        {
            int dias = 0;
            dias = Tools.ConverterParaInt(txtPretCadPer1Dias.Text);

            if (dias > 0 && (dias != 20 && dias != 30))
            {
                MessageBox.Show("Para esta solicitação de pretensão é necessário preencher as datas para o segundo período de férias.", "Cadastrar pretensões", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtPretCadPer2Dias_TextChanged(object sender, EventArgs e)
        {
            int total = Tools.ConverterParaInt(txtPretCadPer2Dias.Text);

            if (total > 0)
            {
                int idade;
                DateTime? data = Convert.ToDateTime(datePretCadPer2Fim.Text);
                idade = CalcularIdade(data);
                if (Total(total, idade) == true)
                {
                    LimparData(4);
                    txtPretCadPer2Dias.Clear();
                }
            }

            AtualizarTotal();
        }

        private void txtPretCadTotal_TextChanged(object sender, EventArgs e)
        {
            int dias = 0;
            dias = Tools.ConverterParaInt(txtPretCadTotal.Text);

            if (dias > 0 )
            {
                if (dias == 20 || dias == 30)
                {
                    btnPretCadIncluir.Visible = true;
                    btnPretCadIncluir.Enabled = true;

                }
            }

        }



        private void btnPretCadIncluir_Click(object sender, EventArgs e)
        {
            //Incluir Datas no dataGrid
            IncluirDatas();
        }

        private void btnPretCadSalvar_Click(object sender, EventArgs e)
        {
            int ano = Tools.ConverterParaInt(cboPretCadAno.Text);
            int reg = Tools.ConverterParaInt(txtPretCadRegistro.Text);

            Departamento dep = new Departamento();
            dep = DepartamentoDAO.PesquisarFuncRegMes(reg);

            Pretensao pre = new Pretensao();
            pre = PretensaoDAO.ObterPretFuncAno(reg, ano);

            if (pre != null)
            {
                pre.ativo = false;

               if (PretensaoDAO.Alterar(pre) == true)
               {
                    Pretensao pret = new Pretensao();
                    pret = PreencherPretensoes(dep, ano);

                    if (PretensaoDAO.Incluir(pret) == true)
                    {
                        MessageBox.Show("Pretensões de férias alteradas com sucesso!", "Alterar pretensões", MessageBoxButtons.OK, MessageBoxIcon.None);

                        btnPretCadSalvar.Enabled = false;
                        btnPretCadSalvar.Visible = false;
                        btnPretCadIncluir.Enabled = false;
                        btnPretCadIncluir.Visible = false;
                        btnPretCadAlterar.Enabled = false;
                        btnPretCadAlterar.Visible = false;

                        DesabilitarDatas();
                        dtgPretCad.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("Não foi posssível alterar as pretensões cadastradas.", "Alterar pretensões", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
               else
               {
                    MessageBox.Show("Não foi posssível alterar as pretensões cadastradas.", "Alterar pretensões", MessageBoxButtons.OK, MessageBoxIcon.Error);
               }
            }
            else
            {
                pre = PreencherPretensoes(dep, ano);

                if (PretensaoDAO.Incluir(pre) == true)
                {
                    MessageBox.Show("Pretensões de férias salvas com sucesso!", "Salvar pretensões", MessageBoxButtons.OK, MessageBoxIcon.None);
                    btnPretCadSalvar.Enabled = false;
                    btnPretCadSalvar.Visible = false;
                    btnPretCadIncluir.Enabled = false;
                    btnPretCadIncluir.Visible = false;
                    btnPretCadAlterar.Enabled = false;
                    btnPretCadAlterar.Visible = false;

                    DesabilitarDatas();
                    dtgPretCad.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Ocorreu um erro ao salvar as pretensões de férias.", "Salvar pretensões", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }



        // MÉTODOS DE VALIDAÇÃO @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@


        private Pretensao PreencherPretensoes(Departamento dep, int ano)
        {
            Pretensao pre = new Pretensao();
            pre.divfuncionario = dep;
            pre.ano = ano;
            pre.ativo = true;
            pre.alterado = pri.lblFrmPrincipalNome.Text;
            pre.cadastro = DateTime.Now;

            int i, l, opcoes = 0;
            l = dtgPretCad.RowCount;


            for (i = dtgPretCad.FirstDisplayedScrollingRowIndex; i < l; i++)
            {
                if (dtgPretCad[0, i].Value != null)
                {
                    opcoes = Tools.ConverterParaInt(dtgPretCad[0, i].Value.ToString());
                }
                else
                {
                    opcoes = 0;
                }

                if (opcoes == 1)
                {
                    pre.per1_op1_inicio = ConverterPretensoes(1, i);
                    pre.per1_op1_fim = ConverterPretensoes(2, i);
                    pre.per2_op1_inicio = ConverterPretensoes(4, i);
                    pre.per2_op1_fim = ConverterPretensoes(5, i);
                }
                else
                {
                    if (opcoes == 2)
                    {
                        pre.per1_op2_inicio = ConverterPretensoes(1, i);
                        pre.per1_op2_fim = ConverterPretensoes(2, i);
                        pre.per2_op2_inicio = ConverterPretensoes(4, i);
                        pre.per2_op2_fim = ConverterPretensoes(5, i);
                    }
                    else
                    {
                        if (opcoes == 3)
                        {
                            pre.per1_op3_inicio = ConverterPretensoes(1, i);
                            pre.per1_op3_fim = ConverterPretensoes(2, i);
                            pre.per2_op3_inicio = ConverterPretensoes(4, i);
                            pre.per2_op3_fim = ConverterPretensoes(5, i);
                        }
                    }

                }
            }

            return pre;
        }

        private void LimparCampos()
        {
            txtPretCadNome.Clear();
            txtPretCadTurno.Clear();
            cboPretCadAno.SelectedText = "";
            txtPretCadPaqInicio.Clear();
            txtPretCadPaqFim.Clear();
            txtPretCadTotal.Clear();

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
                return true;
            }
            else
            {
                return false;
            }
        }

        private DateTime? ConverterData(Control x)
        {
            if (((DateTimePicker)x).Text.Equals(" "))
            {
                return null;
            }
            else
            {
                return Convert.ToDateTime(x.Text);
            }
        }

        private Boolean CelulaAnteriorVazia(Control x, int campo)
        {
            if (((DateTimePicker)x).Text.Equals(" "))
            {
                if (campo == 1)
                {
                    MessageBox.Show("Por favor, informe uma data para o início do primeiro período.", "Data incorreta", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                if (campo == 2)
                {
                    MessageBox.Show("Por favor, informe uma data para o término do primeiro período.", "Data incorreta", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                if (campo == 3)
                {
                    MessageBox.Show("Por favor, informe uma data para o início do segundo período.", "Data incorreta", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

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
            if (data < DateTime.Now || data.Year >= 2020 )
            {
                MessageBox.Show("Data não liberada para cadastro de pretensões.", "Data incorreta", MessageBoxButtons.OK, MessageBoxIcon.Error);

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

        private Boolean ConsultarDiaUtilFim(Control x)
        {
            DateTime data = Convert.ToDateTime(x.Text);

            if (data.DayOfWeek.ToString().Equals("Sunday") || data.DayOfWeek.ToString().Equals("Saturday"))
            {
                MessageBox.Show("As datas informadas para o primeiro período devem começar e terminar em dias úteis.", "Data incorreta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            else
            {
                Data dt = DataDAO.PesquisarFeriado(data);

                if (dt != null)
                {
                    MessageBox.Show("A data de término do primeiro período não pode ser em um feriado.", "Data incorreta", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    if (op >= data)
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
                        MessageBox.Show("As datas das opções informadas devem ter um intervalo mínimo de uma semana entre elas. ", "Data incorreta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return true;
                    }

                }
               else
                {
                    i = l;
                }
            

            } while (i < l);

            i = dtgPretCad.FirstDisplayedScrollingRowIndex;
            l = dtgPretCad.RowCount;

            do
            {
                if (dtgPretCad[4, i].Value != null )
                {
                    opcao = dtgPretCad[4, i].Value.ToString();
                    op = Convert.ToDateTime(opcao);
                    if (op >= data)
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
                        MessageBox.Show("As datas das opções informadas devem ter um intervalo mínimo de uma semana entre elas. ", "Data incorreta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return true;
                    }

                }
                else
                {
                    i = l;
                }

            } while (i < l);

            return false;
        }

        private Boolean InvadePeriodoUmido(DateTime? dataIni, DateTime? dataFim)
        {


            int i = 0;
            IOrderedEnumerable<Data> datasUmidas = DataDAO.PeriodoUmido();
            List<Data> datas = new List<Data>();

            if (datasUmidas != null)
            {
                if (dataFim == null)
                {
                    foreach (Data x in datasUmidas)
                    {
                        if (x.inicio.Value.Month == dataIni.Value.Month && x.inicio.Value.Year == dataIni.Value.Year)
                        {
                            datas.Add(x);
                            i++;
                        }
                    }

                    if (i > 0)
                    {
                        datas.ToList().OrderBy(x => x.inicio.Value.Date);


                        if (dataIni.Value.Month == 9 && dataIni.Value.Date < datas.First().inicio.Value.Date)
                        {
                            return false;
                        }
                        else
                        {
                            foreach (Data x in datas)
                            {
                                if (x.inicio == dataIni)
                                {
                                    return false;
                                }
                            }
                        }

                        MessageBox.Show("A data informada não pode ser diferente das datas predefinidas para o período úmido. ", "Data incorreta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                } // data fim possui valor
                else
                {
                    foreach (Data x in datasUmidas)
                    {
                        if ((x.inicio.Value.Month == dataIni.Value.Month && x.inicio.Value.Year == dataIni.Value.Year) || (x.fim.Value.Month == dataFim.Value.Month && x.fim.Value.Year == dataFim.Value.Year))
                        {
                            datas.Add(x);
                            i++;
                        }
                    }

                    if (i > 0)
                    {
                        datas.ToList().OrderBy(x => x.fim.Value.Date);

                        if (dataFim.Value.Month == 9 && dataFim.Value.Date < datas.First().inicio.Value.Date)
                        {
                            return false;
                        }
                        else
                        {
                            foreach (Data x in datas)
                            {
                                if (x.inicio == dataIni && x.fim == dataFim)
                                {
                                    return false;
                                }
                            }
                        }

                        MessageBox.Show("A data informada não pode ser diferente das datas predefinidas para o período úmido. ", "Data incorreta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            else
            {
                return false;
            }


            //int dt = 0;
            //IOrderedEnumerable<DateTime> datas = DataDAO.PeriodoUmido(data);

            //if (datas != null)
            //{
            //    if (data.DayOfYear < datas.First().DayOfYear)
            //    {
            //        return false;
            //    }
            //    else
            //    {
            //        foreach (DateTime x in datas)
            //        {
            //            if (x.DayOfYear == data.DayOfYear)
            //            {
            //                dt = 1;
            //            }
            //        }

            //        if (dt == 0)
            //        {
            //            MessageBox.Show("A data informada não pode ser diferente das datas predefinidas para o período úmido. ", "Data incorreta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //            return true;
            //        }

            //    }     
            //}

            //return false;
        }

        private Boolean InvadePeriodoNobre(DateTime? dataIni, DateTime? dataFim)
        {
            int i = 0;
            IOrderedEnumerable<Data> datasNobres = DataDAO.PeriodoNobre();
            List<Data> datas = new List<Data>();

           if (datasNobres != null)
            {
                if (dataFim == null)
                {
                    foreach (Data x in datasNobres)
                    {
                        if ((x.inicio.Value.Month == dataIni.Value.Month && x.inicio.Value.Year == dataIni.Value.Year) || (x.fim.Value.Month == dataIni.Value.Month && x.fim.Value.Year == dataIni.Value.Year))
                        {
                            datas.Add(x);
                            i++;
                        }
                    }

                    if (i > 0)
                    {
                        datas.ToList().OrderBy(x => x.inicio.Value.Date);


                        if (((dataIni.Value.Month == 2 || dataIni.Value.Month == 3) && (dataIni.Value.Date > datas.Last().fim.Value.Date)) || (dataIni.Value.Month == 7 && dataIni.Value.Date < datas.First().inicio.Value.Date) || (dataIni.Value.Month == 7 && dataIni.Value.Date > datas.Last().fim.Value.Date))
                        {
                            return false;
                        }
                        else
                        {
                            foreach (Data x in datas)
                            {
                                if (x.inicio == dataIni)
                                {
                                    return false;
                                }
                            }                         
                        }

                        MessageBox.Show("A data informada não pode ser diferente das datas predefinidas para o período nobre. ", "Data incorreta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                } // data fim possui valor
                else
                {
                    foreach (Data x in datasNobres)
                    {
                        if ((x.inicio.Value.Month == dataIni.Value.Month && x.inicio.Value.Year == dataIni.Value.Year) || (x.fim.Value.Month == dataFim.Value.Month && x.fim.Value.Year == dataFim.Value.Year))
                        {
                            datas.Add(x);
                            i++;
                        }
                    }

                    if (i > 0)
                    {
                        datas.ToList().OrderBy(x => x.fim.Value.Date);


                        if ((dataIni.Value.Month == 2 || dataIni.Value.Month == 3 || dataIni.Value.Month == 7) && dataFim.Value.Date > datas.Last().fim.Value.Date)
                        {
                            return false;
                        }
                        else
                        {
                            if (dataFim.Value.Month == 7 && dataIni.Value.Date < datas.First().inicio.Value.Date)
                            {
                                return false;
                            }       
                            else
                            {
                                foreach (Data x in datas)
                                {
                                    if (x.inicio == dataIni && x.fim == dataFim)
                                    {
                                        return false;
                                    }
                                }
                            }
                            
                        }

                        MessageBox.Show("A data informada não pode ser diferente das datas predefinidas para o período nobre. ", "Data incorreta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            else
            {
                return false;
            }    
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

        }

        private Boolean CompararDatas(Control dt1, DateTime dt2, int campo)
        {
            string ini;
            DateTime inicio;

            ini = dt1.Text.ToString();
            inicio = Convert.ToDateTime(ini);

            if (dt2 < inicio)
            {
                if (campo == 2)
                {
                    MessageBox.Show("A data final do primeiro período deve ser posterior à data inicial.", "Data incorreta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (campo == 3)
                    {
                        MessageBox.Show("A data de início do segundo período deve ser posterior à data de início do primeiro período.", "Data incorreta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("A data final do segundo período deve ser posterior à data inicial.", "Data incorreta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                return true;
            }


            return false;

        }

        private int CalcularDatas (Control dt1 , DateTime dt2)
        {
           
            string ini;
            DateTime inicio;
            TimeSpan dias;
            int total;

            ini = dt1.Text.ToString();
            inicio = Convert.ToDateTime(ini);

            if ( dt2 > inicio)
            {
                dias = dt2.Date - inicio.Date;
                total = dias.Days + 1;
            }
            else
            {
                total = 0;
            }
           
            return total;
        }

        private void LimparData(int campo)
        {
            switch (campo)
            {
                case 1:
                    datePretCadPer1Inicio.CustomFormat = " ";
                    datePretCadPer1Inicio.Format = DateTimePickerFormat.Custom;
                    break;

                case 2:
                    datePretCadPer1Fim.CustomFormat = " ";
                    datePretCadPer1Fim.Format = DateTimePickerFormat.Custom;
                    break;

                case 3:
                    datePretCadPer2Inicio.CustomFormat = " ";
                    datePretCadPer2Inicio.Format = DateTimePickerFormat.Custom;
                    break;

                case 4:
                    datePretCadPer2Fim.CustomFormat = " ";
                    datePretCadPer2Fim.Format = DateTimePickerFormat.Custom;
                    break;
                    
            }
        }



        private Boolean TodosNobres(Control x, Control y)
        {          
            DateTime dt1, dt2;

            dt1 = Convert.ToDateTime(x.Text.ToString());
            dt2 = Convert.ToDateTime(y.Text.ToString());

            Data data1 = DataDAO.Nobre(dt1);
            Data data2 = DataDAO.Nobre(dt2);

            if (data1 != null || data2 != null)
            {
                return true;
            }

            return false;
        }


        private Boolean TodosUmidos(Control x, Control y)
        {
            DateTime dt1, dt2;

            dt1 = Convert.ToDateTime(x.Text.ToString());
            dt2 = Convert.ToDateTime(y.Text.ToString());

            Data data1 = DataDAO.Umido(dt1);
            Data data2 = DataDAO.Umido(dt2);

            if (data1 != null || data2 != null)
            {
                return true;
            }

            return false;
        }

        private Boolean Total(int total, int idade)
        {

            if (idade < 50 && (total < 5 || (total > 25 && total < 30) || total > 30))
            {
                MessageBox.Show("O total permitido para o período deve ser de 5 a 25 dias ou exatamente 30 dias.", "Data inválida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    
                return true;
            }
            else
            {
                if (idade >= 50 && (total < 10 || (total > 20 && total < 30) || total > 30))
                {
                    MessageBox.Show("O total permitido para o período deve ser de 10 a 20 dias ou exatamente 30 dias.", "Data inválida", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return true;
                }
                else
                {
                    AtualizarTotal();
                    return false;
                }
            }
        }

        private void AtualizarTotal()
        {
            int dias = 0, per1=0, per2=0;

            int idade;
            DateTime? data;

            if (!txtPretCadPer1Dias.Text.Equals("") && !txtPretCadPer2Dias.Text.Equals(""))
            {
                per1 = Tools.ConverterParaInt(txtPretCadPer1Dias.Text);
                per2 = Tools.ConverterParaInt(txtPretCadPer2Dias.Text);
                dias = per1 + per2;

                data = Convert.ToDateTime(datePretCadPer1Inicio.Text);
                idade = CalcularIdade(data);
                
                if (idade < 50)
                {
                    if ((dias == 20 || dias == 30))
                    {
                        txtPretCadTotal.Text = dias.ToString();
                    }
                    else
                    {
                        MessageBox.Show("O total de dias permitido para férias é de exatamente 20 ou 30 dias.", "Períodos inválidos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        LimparData(4);
                        txtPretCadPer2Dias.Clear();
                    }
                    
                }
                else
                {
                    if (dias != 30 && per2 > 0)
                    {
                        MessageBox.Show("Não é possível parcelar as férias se o total for inferior a 30 dias.", "Períodos inválidos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        LimparData(4);
                        txtPretCadPer2Dias.Clear();
                        txtPretCadTotal.Clear();
                    }
                    else
                    {
                        txtPretCadTotal.Text = dias.ToString();
                    }
                }
            }
            else
            {
                if (!txtPretCadPer1Dias.Text.Equals("") && txtPretCadPer2Dias.Text.Equals(""))
                {
                    dias = Tools.ConverterParaInt(txtPretCadPer1Dias.Text);
                    txtPretCadTotal.Text = dias.ToString();

                }
                else
                {
                    if (txtPretCadPer1Dias.Text.Equals("") && txtPretCadPer2Dias.Text.Equals(""))
                    {
                        dias = 0;
                        txtPretCadTotal.Text = dias.ToString();
                    }

                }
            }

            

        }

        // inclui as datas no dataGrid
        private void IncluirDatas()
        {
            int i, l, opcoes=0;
            l = dtgPretCad.RowCount;

            for (i = dtgPretCad.FirstDisplayedScrollingRowIndex; i < l; i++)
            {
                if (dtgPretCad[0, i].Value != null)
                {
                    opcoes++;
                }
            }

            opcoes++;


            dtgPretCad.Rows.Add(
                                opcoes,
                                PreencherDataGrid(datePretCadPer1Inicio),
                                PreencherDataGrid(datePretCadPer1Fim),
                                Tools.ConverterParaInt(txtPretCadPer1Dias.Text),
                                PreencherDataGrid(datePretCadPer2Inicio),
                                PreencherDataGrid(datePretCadPer2Fim),
                                Tools.ConverterParaInt(txtPretCadPer2Dias.Text),
                                Tools.ConverterParaInt(txtPretCadTotal.Text));

            // btnPretCadAlterar.Visible = true;
            // btnPretCadAlterar.Enabled = true;

            btnPretCadAlterar.Enabled = false;
            btnPretCadAlterar.Visible = false;

            btnPretCadIncluir.Enabled = false;
            btnPretCadIncluir.Visible = false;
            LimparData(1);
            LimparData(2);
            LimparData(3);
            LimparData(4);
            txtPretCadPer1Dias.Clear();
            txtPretCadPer2Dias.Clear();
            txtPretCadTotal.Clear();
            HabilitarDatas();

            if (opcoes == 3)
            {
                btnPretCadIncluir.Enabled = false;
                btnPretCadIncluir.Visible = false;
                btnPretCadSalvar.Visible = true;
                btnPretCadSalvar.Enabled = true;
            }
        }

        private string PreencherDataGrid(Control x)
        {
            if (((DateTimePicker)x).Text.Equals(" "))
            {
                return null;
            }

            return ((DateTimePicker)x).Text;
        }

        private DateTime? ConverterPretensoes(int col, int lin)
        {
            string data;

            if (dtgPretCad[col, lin].Value == null)
            {
                return null;
            }
            else
            {
                data = dtgPretCad[col, lin].Value.ToString();
                return Convert.ToDateTime(data);
            }

        }

        private Boolean ConsultarPrazo()
        {
            string sData = DateTime.Now.ToString("dd/MM/yyyy");
            DateTime data = Convert.ToDateTime(sData);
            Data dt = DataDAO.ConsultarPrazo(data);
            if (dt == null)
            {
                MessageBox.Show("Não é permitido cadastrar pretensões fora do prazo estabelecido.", "Cadastrar pretensões", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            else
            {
                return false;
            }
        }

        private void cboPretCadAno_SelectedValueChanged(object sender, EventArgs e)
        {
            txtPretCadPaqInicio.Clear();
            txtPretCadPaqFim.Clear();
        }

        private string PreencherDatas(DateTime? data)
        {
            if (data == null)
            {
                return null;
            }
            else
            {
                return data.Value.ToString("dd/MM/yyyy");
            }
        }

     private int CalcularPeriodo(TimeSpan? x)
        {
            if (x == null)
            {
                return 0;
            }
            else
            {
                return x.Value.Days + 1;
            }
        }



        private void datePretCadPer2Inicio_Enter(object sender, EventArgs e)
        {
            if (CelulaAnteriorVazia(datePretCadPer1Inicio, 1) == false && CelulaAnteriorVazia(datePretCadPer1Fim, 2) == false)
            {
                // primeiro período NÃO termina em dia útil
                if (ConsultarDiaUtilFim(datePretCadPer1Fim) == true)
                {
                    LimparData(2);
                    txtPretCadPer1Dias.Clear();
                }
            }
        }

        private void dtgPretCad_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int i, l;
            i = dtgPretCad.CurrentCell.RowIndex;
            l = dtgPretCad.RowCount;

            if (i >= 0)
            {
                if (dtgPretCad[0, i].Value != null)
                {
                    if (l - i == 2)
                    {
                        if (MessageBox.Show("Deseja excluir a pretensão selecionada?", "Excluir pretensão", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            dtgPretCad.Rows.Remove(this.dtgPretCad.CurrentRow);
                            dtgPretCad.Update();
                            HabilitarDatas();
                            btnPretCadSalvar.Enabled = false;
                            btnPretCadSalvar.Visible = false;
                        }
                    }
                }
            }

        }

        private void btnPretCadAlterar_Click(object sender, EventArgs e)
        {
            dtgPretCad.Enabled = true;

            MessageBox.Show("Para alterar as pretensões já cadastradas é necessário dar um duplo clique sobre elas para excluí-las, começando da última pretensão para a primeira.", "Alterar pretensões", MessageBoxButtons.OK, MessageBoxIcon.Information);

            btnPretCadAlterar.Enabled = false;
            btnPretCadAlterar.Visible = false;
        }

        private int CalcularIdade(DateTime? data)
        {
            int reg = Tools.ConverterParaInt(txtPretCadRegistro.Text);

            Funcionario f = new Funcionario();
            f = FuncionarioDAO.ObterFuncionarioId(reg);

            if (f == null)
            {
                return 0;
            }
            else
            {
                if (f.nascimento == null)
                {
                    return 0;
                }
                else
                {
                    DateTime? nasc = f.nascimento;

                    int idade = data.Value.Year - nasc.Value.Year;
                    if (data.Value.Month < nasc.Value.Month || (data.Value.Month == nasc.Value.Month && data.Value.Day < nasc.Value.Day))
                        idade--;

                    return idade;
                }
            }
        }
    }
}
