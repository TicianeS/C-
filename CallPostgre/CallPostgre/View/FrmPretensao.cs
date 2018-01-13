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
                //if (perfil.Equals("MONITOR") || perfil.Equals("APOIO MONITOR") && !f.cargos.nome.Contains("TELEATENDENTE"))
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
                        if (pre == null && ConsultarPrazo() == false)
                        {
                            HabilitarDatas();
                            
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
        }

        private void datePretCadPer1Inicio_ValueChanged(object sender, EventArgs e)
        {
            datePretCadPer1Inicio.CustomFormat = null;
            txtPretCadPer1Dias.Clear();

        }

        private void datePretCadPer1Fim_ValueChanged(object sender, EventArgs e)
        {
            datePretCadPer1Fim.CustomFormat = null;
            txtPretCadPer1Dias.Clear();
        }

        private void datePretCadPer2Inicio_ValueChanged(object sender, EventArgs e)
        {
            datePretCadPer2Inicio.CustomFormat = null;
            txtPretCadPer2Dias.Clear();
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
                                        
                                        // se os inicio e fim estiverem preenchidos calcula o total de dias
                                        if (CelulaVazia(datePretCadPer1Fim) == false)
                                        {
                                            txtPretCadPer1Dias.Text = CalcularDatas(datePretCadPer1Fim, data).ToString();
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
            if (CelulaVazia(datePretCadPer1Fim) == false)
            {

                //DATA ANTERIOR VAZIA
                if (CelulaAnteriorVazia(datePretCadPer1Inicio, 1) == false)
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
                                    if (CompararDatas(datePretCadPer1Inicio, data, 2) == false)

                                    {
                                        MessageBox.Show("A data informada foi validada.", "Data validada", MessageBoxButtons.OK, MessageBoxIcon.None);

                                        // se os inicio e fim estiverem preenchidos calcula o total de dias
                                        txtPretCadPer1Dias.Text = CalcularDatas(datePretCadPer1Inicio, data).ToString();
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
            if (CelulaVazia(datePretCadPer2Inicio) == false)
            {
                //DATA ANTERIOR VAZIA
                if (CelulaAnteriorVazia(datePretCadPer1Inicio, 1) == false && CelulaAnteriorVazia(datePretCadPer1Fim, 2) == false)
                {
                    DateTime data;
                    data = Convert.ToDateTime(datePretCadPer2Inicio.Text);

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
                                            if (InvadePeriodoUmido(data) == false)
                                            {

                                                //INVADE PERÍODO NOBRE
                                                if (InvadePeriodoNobre(data) == false)
                                                {
                                                    // segundo período anterior ao primeiro
                                                    if (CompararDatas(datePretCadPer1Inicio, data, 3) == false)

                                                    {
                                                        MessageBox.Show("A data informada foi validada.", "Data validada", MessageBoxButtons.OK, MessageBoxIcon.None);

                                                        // se os inicio e fim estiverem preenchidos calcula o total de dias
                                                        if (CelulaVazia(datePretCadPer2Fim) == false)
                                                        {
                                                            txtPretCadPer2Dias.Text = CalcularDatas(datePretCadPer2Fim, data).ToString();
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
            if (CelulaVazia(datePretCadPer2Fim) == false)
            {
                //DATA ANTERIOR VAZIA
                if (CelulaAnteriorVazia(datePretCadPer1Inicio, 1) == false && CelulaAnteriorVazia(datePretCadPer1Fim, 2) == false && CelulaAnteriorVazia(datePretCadPer2Inicio, 3) == false)
                {
                    DateTime data;
                    data = Convert.ToDateTime(datePretCadPer2Fim.Text);

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
                                if (InvadePeriodoUmido(data) == false)
                                {

                                    //INVADE PERÍODO NOBRE
                                    if (InvadePeriodoNobre(data) == false)
                                    {
                                        // OS DOIS PERÍODOS SÃO NOBRES
                                        if (TodosNobres(datePretCadPer1Inicio, datePretCadPer1Fim) == false && TodosNobres(datePretCadPer2Inicio, datePretCadPer2Fim) == false)
                                        {

                                            // OS DOIS PERÍODOS SÃO ÚMIDOS
                                            if (TodosUmidos(datePretCadPer1Inicio, datePretCadPer1Fim) == false && TodosUmidos(datePretCadPer2Inicio, datePretCadPer2Fim) == false)
                                            {

                                                MessageBox.Show("A data informada foi validada.", "Data validada", MessageBoxButtons.OK, MessageBoxIcon.None);

                                                // se os inicio e fim estiverem preenchidos calcula o total de dias
                                                txtPretCadPer2Dias.Text = CalcularDatas(datePretCadPer2Inicio, data).ToString();
                                            }
                                            else
                                            {
                                                MessageBox.Show("Os dois períodos escolhidos para férias são períodos úmidos.", "Data incorreta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                LimparData(3);
                                                LimparData(4);
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("Os dois períodos escolhidos para férias são períodos nobres.", "Data incorreta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            LimparData(3);
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
            else
            {
                LimparData(4);
            }
        }


        private void txtPretCadPer1Dias_TextChanged(object sender, EventArgs e)
        {
            if (Total(txtPretCadPer1Dias) == true)
            {
                LimparData(2);
                txtPretCadPer1Dias.Clear();             
            }

            AtualizarTotal();
            
        }

        private void txtPretCadPer2Dias_TextChanged(object sender, EventArgs e)
        {
            if (Total(txtPretCadPer2Dias) == true)
            {
                LimparData(4);
                txtPretCadPer2Dias.Clear();

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
                else
                {
                    MessageBox.Show("O total de dias permitido para férias é de exatamente 20 ou 30 dias.", "Períodos inválidos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LimparData(3);
                    LimparData(4);
                    txtPretCadPer2Dias.Clear();
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
            pre.divfuncionario = dep;
            pre.ano = ano;
            pre.ativo = true;
            pre.alterado = pri.lblFrmPrincipalNome.Text;
            pre.cadastro = DateTime.Now;

            int i, l, opcoes = 0;
            l = dtgPretCad.RowCount;
            

            for (i = dtgPretCad.FirstDisplayedScrollingRowIndex; i < l; i++)
            {
                opcoes = Tools.ConverterParaInt(dtgPretCad[0, i].Value.ToString());

                if (opcoes == 1)
                {
                    pre.per1_op1_inicio = ConverterPretensoes(dtgPretCad[1, i].Value.ToString());
                    pre.per1_op1_fim = ConverterPretensoes(dtgPretCad[3, i].Value.ToString());
                    pre.per2_op1_inicio = ConverterPretensoes(dtgPretCad[4, i].Value.ToString());
                    pre.per2_op1_fim = ConverterPretensoes(dtgPretCad[5, i].Value.ToString());
                }
                else
                {
                    if (opcoes == 2)
                    {
                        pre.per1_op2_inicio = ConverterPretensoes(dtgPretCad[1, i].Value.ToString());
                        pre.per1_op2_fim = ConverterPretensoes(dtgPretCad[3, i].Value.ToString());
                        pre.per2_op2_inicio = ConverterPretensoes(dtgPretCad[4, i].Value.ToString());
                        pre.per2_op2_fim = ConverterPretensoes(dtgPretCad[5, i].Value.ToString());
                    }
                    else
                    {
                        if (opcoes == 3)
                        {
                            pre.per1_op3_inicio = ConverterPretensoes(dtgPretCad[1, i].Value.ToString());
                            pre.per1_op3_fim = ConverterPretensoes(dtgPretCad[3, i].Value.ToString());
                            pre.per2_op3_inicio = ConverterPretensoes(dtgPretCad[4, i].Value.ToString());
                            pre.per2_op3_fim = ConverterPretensoes(dtgPretCad[5, i].Value.ToString());
                        }
                    }
                    
                } 
            }

            if (PretensaoDAO.Incluir(pre) == true)
            {
                MessageBox.Show("Pretensões de férias foram salvas com sucesso!", "Salvar pretensões", MessageBoxButtons.OK, MessageBoxIcon.None);
            }
            else
            {
                MessageBox.Show("Ocorreu um erro ao salvar as pretensões de férias.", "Salvar pretensões", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (data.Year < 2018 || data.Year >= 2020 )
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
            //i = 0;
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

            } while (i <= l);

            return false;
        }

        private Boolean InvadePeriodoUmido(DateTime data)
        {
            int dt = 0;
            IOrderedEnumerable<DateTime> datas = DataDAO.PeriodoUmido(data);

            if (datas != null)
            {
                
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
            IOrderedEnumerable<DateTime> datas = DataDAO.PeriodoNobre(data);

            if ( datas != null)
            {

                foreach (DateTime x in datas)
                {

                    if (x.DayOfYear < datas.First().DayOfYear || x.DayOfYear > datas.Last().DayOfYear)
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
            int dias;

            ini = dt1.Text.ToString();
            inicio = Convert.ToDateTime(ini);

            if ( dt2 > inicio)
            {
                dias = dt2.DayOfYear - inicio.DayOfYear + 1;
            }
            else
            {
                dias = 0;
            }
           
            return dias;
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

            if (data1 == null && data2 == null)
            {
                return false;
            }

            return true;
        }


        private Boolean TodosUmidos(Control x, Control y)
        {
            DateTime dt1, dt2;

            dt1 = Convert.ToDateTime(x.Text.ToString());
            dt2 = Convert.ToDateTime(y.Text.ToString());

            Data data1 = DataDAO.Umido(dt1);
            Data data2 = DataDAO.Umido(dt2);

            if (data1 == null && data2 == null)
            {
                return false;
            }

            return true;
        }

        private Boolean Total(Control x)
        {
            if (!x.Text.Equals(""))
            {
                int total = Tools.ConverterParaInt(txtPretCadPer1Dias.Text);

                if (total <= 5 || (total > 25 && total < 30))
                {
                    MessageBox.Show("O total permitido para o período deve ser 5 a 25 dias ou exatamente 30 dias.");
                    return true;
                }
                else
                {
                    return false;
                }
                
            }
            else
            {
                return false;
            }

        }

        private void AtualizarTotal()
        {
            int dias = 0;

            if (!txtPretCadPer1Dias.Text.Equals("") && !txtPretCadPer2Dias.Text.Equals(""))
            {
                dias = Tools.ConverterParaInt(txtPretCadPer1Dias.Text) + Tools.ConverterParaInt(txtPretCadPer2Dias.Text);
                txtPretCadTotal.Text = dias.ToString();
            }
            else
            {
                if (!txtPretCadPer1Dias.Text.Equals("") && txtPretCadPer2Dias.Text.Equals(""))
                {
                    dias = Tools.ConverterParaInt(txtPretCadPer1Dias.Text);
                }
                else
                {
                    if (txtPretCadPer1Dias.Text.Equals("") && txtPretCadPer2Dias.Text.Equals(""))
                    {
                        dias = 0;
                    }

                }
            }

            txtPretCadTotal.Text = dias.ToString();
        }

        // inclui as datas no dataGrid
        private void IncluirDatas()
        {
            int i, l, opcoes=0;
            l = dtgPretCad.RowCount;

            for (i = dtgPretCad.FirstDisplayedScrollingRowIndex; i < l; i++)
            {
                if (!dtgPretCad[0, i].Value.ToString().Equals(""))
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

            btnPretCadAlterar.Visible = true;
            btnPretCadAlterar.Enabled = true;

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

        private DateTime? ConverterPretensoes(string x)
        {
            if (x.Equals(null))
            {
                return null;
            }
            else
            {
                return Convert.ToDateTime(x);
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
    }
}
