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

namespace Callcenter.View
{
    public partial class frmCadastro : Form
    {
        frmPrincipal pri;
        public frmCadastro(frmPrincipal x)
        {
            pri = x;
            InitializeComponent();
        }



        private void btnCadSalvarFunc_Click(object sender, EventArgs e)
        {
            Funcionario Funcionario = new Funcionario();

            if (txtCadNome.Text.Equals("") || mskCadCPF.Text.Contains(" ") || mskCadDtNasc.Text.Contains(" ") || txtCadRG.Text.Equals("") || txtCadEndereco.Text.Equals("") || mskCadTelefone.Text.Equals("") || mskCadDtAdmi.Text.Contains(" "))
            {
                MessageBox.Show("Favor preencher todos os campos do formulário.", "Cadastrar funcionário", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string dtN = mskCadDtNasc.Text;
                string dtA = mskCadDtAdmi.Text;
                DateTime dtNasc;
                DateTime dtAdmi;
                dtNasc = Convert.ToDateTime(dtN);
                dtAdmi = Convert.ToDateTime(dtA);
                Funcionario.Nome = txtCadNome.Text;
                Funcionario.Nascimento = dtNasc;
                Funcionario.Endereco = txtCadEndereco.Text;
                Funcionario.Telefone = mskCadTelefone.Text;
                Funcionario.Rg = txtCadRG.Text;
                Funcionario.Cidade = txtCadCidade.Text;
                Funcionario.Cpf = mskCadCPF.Text;
                Funcionario.Admissao = dtAdmi;
                if (FuncionarioDAO.Incluir(Funcionario))
                {
                    MessageBox.Show("Funcionário cadastrado com sucesso.");
                    LimparCamposCadFunc();
                }
                else
                {
                    MessageBox.Show("Ocorreu um erro ao salvar os dados.");
                }


            }
        }


        private void LimparCamposDpto()
        {
            txtCadDpMat.Clear();
            txtCadDpMat.Enabled = true;
            txtCadDpNome.Clear();
            txtCadDpNome.Enabled = false;
            mskCadDpHorario.Clear();
            mskCadDpHorario.Enabled = false;
            cboCadDpSup.Text = "";
            cboCadDpSup.Enabled = false;
            cboCadDpCargo.Text = "";
            cboCadDpCargo.Enabled = false;

            btnCadDpSalvar.Enabled = false;
            btnCadDpAlterar.Enabled = false;
            btnCadDpExcluir.Enabled = false;
        }


        private void mskCadCPF_Leave(object sender, EventArgs e)
        {
            if (mskCadCPF.Text.Contains(" "))
            {
                MessageBox.Show("O CPF informado está incompleto.");
                mskCadCPF.Clear();
            }
            else
            {

                Funcionario Funcionario = new Funcionario();
                string cpf = mskCadCPF.Text;
                Funcionario = FuncionarioDAO.ObterFuncionarioCpf(cpf);
                if (Funcionario != null)
                {
                    if (MessageBox.Show("O CPF informado já possui cadastro. Deseja alterar o cadastro deste funcionário?",
                        "Alterar funcionário", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        txtCadFuncID.Text = Funcionario.Id.ToString();
                        mskCadDtNasc.Text = Funcionario.Nascimento.ToString();
                        txtCadNome.Text = Funcionario.Nome;
                        txtCadRG.Text = Funcionario.Rg;
                        mskCadTelefone.Text = Funcionario.Telefone;
                        txtCadEndereco.Text = Funcionario.Endereco;
                        txtCadCidade.Text = Funcionario.Cidade;
                        mskCadDtAdmi.Text = Funcionario.Admissao.ToString();

                        btnCadExcluir.Enabled = false;
                        btnCadSalvarFunc.Enabled = false;
                        btnCadAlterar.Enabled = true;
                        mskCadDtNasc.Enabled = true;
                        txtCadNome.Enabled = true;
                        txtCadRG.Enabled = true;
                        mskCadTelefone.Enabled = true;
                        txtCadEndereco.Enabled = true;
                        txtCadCidade.Enabled = true;
                        mskCadDtAdmi.Enabled = true;

                    }
                    else
                    {
                        if (MessageBox.Show("Deseja excluir o cadastro deste funcionário?",
                            "Excluir funcionário", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            mskCadDtNasc.Text = Funcionario.Nascimento.ToString();
                            txtCadNome.Text = Funcionario.Nome;
                            txtCadRG.Text = Funcionario.Rg;
                            mskCadTelefone.Text = Funcionario.Telefone;
                            txtCadEndereco.Text = Funcionario.Endereco;
                            txtCadCidade.Text = Funcionario.Cidade;
                            mskCadDtAdmi.Text = Funcionario.Admissao.ToString();

                            btnCadExcluir.Enabled = true;
                            btnCadSalvarFunc.Enabled = false;
                            btnCadAlterar.Enabled = false;

                            mskCadDtNasc.Enabled = false;
                            txtCadNome.Enabled = false;
                            txtCadRG.Enabled = false;
                            mskCadTelefone.Enabled = false;
                            txtCadEndereco.Enabled = false;
                            txtCadCidade.Enabled = false;
                            mskCadDtAdmi.Enabled = false;
                            btnCadExcluir.TabIndex = 0;
                        }
                        else
                        {
                            MessageBox.Show("Operação Cancelada");
                        }
                    }


                }
                else
                {
                    btnCadExcluir.Enabled = false;
                    btnCadSalvarFunc.Enabled = true;
                    btnCadAlterar.Enabled = false;

                    mskCadDtNasc.Enabled = true;
                    txtCadNome.Enabled = true;
                    txtCadRG.Enabled = true;
                    mskCadTelefone.Enabled = true;
                    txtCadEndereco.Enabled = true;
                    txtCadCidade.Enabled = true;
                    mskCadDtAdmi.Enabled = true;
                }
            }
        }

        private void btnCadSalvarCargo_Click(object sender, EventArgs e)
        {
            Cargo Cargo = new Cargo();
            Cargo.Nome = txtCadCargo.Text;

            if (txtCadCargo.Text.Equals(""))
            {
                MessageBox.Show("Favor preencher todos os campos do formulário.", "Cadastrar funcionário", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (CargoDAO.Incluir(Cargo) == true)
                {
                    MessageBox.Show("Cargo cadastrado com sucesso.");
                    txtCadCargo.Clear();

                }
                else
                {
                    MessageBox.Show("Ocorreu um erro ao salvar os dados.");
                }
            }
        }

        private void trnCadSalvarAus_Click(object sender, EventArgs e)
        {
            if (txtCadAus.Text.Equals("") || txtCadSigla.Text.Equals(""))
            {
                MessageBox.Show("Favor preencher todos os campos do formulário.", "Cadastrar ausências", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Ausencia Ausencia = new Ausencia();
                Ausencia.Nome = txtCadAus.Text;
                Ausencia.Sigla = txtCadSigla.Text;
                if (AusenciaDAO.Incluir(Ausencia) == true)
                {
                    MessageBox.Show("Ausência cadastrada com sucesso.");
                    LimparCamposAus();
                }
                else
                {
                    MessageBox.Show("Ocorreu um erro ao salvar os dados.");
                }
            }
        }

        public void LimparCamposAus()
        {
            txtCadAus.Clear();
            txtCadSigla.Clear();
            txtCadSigla.Enabled = false;
            txtCadAus.Enabled = true;
            btnCadAusExcluir.Enabled = false;
            btnCadAusSalvar.Enabled = false;
            btnCadAlterar.Enabled = false;
        }

        private void txtCadAus_Leave(object sender, EventArgs e)
        {
            Ausencia Ausencia = new Ausencia();
            if (!txtCadAus.Text.Equals(""))
            {
                Ausencia.Nome = txtCadAus.Text;
                Ausencia = AusenciaDAO.ObterAusenciaNome(Ausencia);
                if (Ausencia != null)
                {
                    if (MessageBox.Show("A ausência informada já existe. Deseja alterar os dados desta ausência?",
                            "Alterar ausência", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        txtCadAus.Text = Ausencia.Nome;
                        txtCadSigla.Text = Ausencia.Sigla;
                        txtCadSigla.Enabled = true;
                        lblCadAusID.Text = Ausencia.Id.ToString();

                        btnCadAusAlterar.Enabled = true;
                        btnCadAusSalvar.Enabled = false;
                        btnCadAusExcluir.Enabled = false;
                    }
                    else
                    {
                        if (MessageBox.Show("Deseja excluir esta ausência?",
                            "Excluir ausência", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            txtCadAus.Text = Ausencia.Nome;
                            txtCadSigla.Text = Ausencia.Sigla;
                            txtCadSigla.Enabled = false;
                            txtCadAus.Enabled = false;
                            lblCadAusID.Text = Ausencia.Id.ToString();

                            btnCadAusAlterar.Enabled = false;
                            btnCadAusSalvar.Enabled = false;
                            btnCadAusExcluir.Enabled = true;
                            btnCadAusExcluir.TabIndex = 0; ;
                        }
                        else
                        {
                            MessageBox.Show("Operação cancelada.");
                            LimparCamposAus();
                        }
                    }
                }
                else
                {
                    txtCadSigla.Enabled = true;
                    btnCadAusSalvar.Enabled = true;
                    btnCadAusExcluir.Enabled = false;
                    btnCadAusExcluir.Enabled = false;
                }
            }
            else
            {
                MessageBox.Show("Informe a ausência.");
            }
            
            
        }

        private void txtCadSigla_Leave(object sender, EventArgs e)
        {
            Ausencia Ausencia = new Ausencia();
            Ausencia.Sigla = txtCadSigla.Text;
            Ausencia = AusenciaDAO.ObterAusenciaSigla(Ausencia);
            if (Ausencia != null)
            {
                MessageBox.Show("A sigla informada já existe no cadastro", "Cadastrar ausência", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCadSigla.Clear();
            }
        }


        private void txtCadCargo_Leave(object sender, EventArgs e)
        {
            Cargo Cargo = new Cargo();
            Cargo.Nome = txtCadCargo.Text;
            if (CargoDAO.ObterCargoNome(Cargo) != null)
            {
                MessageBox.Show("O cargo informado já existe no cadastro", "Cadastrar cargo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCadCargo.Clear();
            }
        }

        private void mskCadDtNasc_Leave(object sender, EventArgs e)
        {
            if (mskCadDtNasc.Text.Contains(" "))
            {
                MessageBox.Show("Por favor, a data de nascimento");
                mskCadDtNasc.Clear();
            }
            else
            {
                DateTime convertedDate;
                string dt = mskCadDtNasc.Text;

                try
                {
                    convertedDate = Convert.ToDateTime(dt);
                }
                catch (FormatException)
                {
                    MessageBox.Show("A data informada é inválida");
                    mskCadDtNasc.Clear();
                }

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

        private void LimparCamposCadFunc()
        {
            txtCadFuncID.Clear();
            mskCadCPF.Clear();
            mskCadCPF.Enabled = true;
            mskCadDtNasc.Clear();
            mskCadDtNasc.Enabled = false;
            txtCadNome.Clear();
            txtCadNome.Enabled = false;
            txtCadRG.Clear();
            txtCadRG.Enabled = false;
            mskCadTelefone.Clear();
            mskCadTelefone.Enabled = false;
            txtCadEndereco.Clear();
            txtCadEndereco.Enabled = false;
            txtCadCidade.Clear();
            txtCadCidade.Enabled = false;
            mskCadDtAdmi.Clear();
            mskCadDtAdmi.Enabled = false;
            btnCadSalvarFunc.Enabled = false;
            btnCadAlterar.Enabled = false;
            btnCadExcluir.Enabled = false;
            

        }

        private void mskCadDtAdmi_Leave(object sender, EventArgs e)
        {
            if (mskCadDtAdmi.Text.Contains(" "))
            {
                MessageBox.Show("Por favor, a data de admissão");
                mskCadDtAdmi.Clear();
            }
            else
            {
                DateTime convertedDate;
                string dt = mskCadDtAdmi.Text;

                try
                {
                    convertedDate = Convert.ToDateTime(dt);
                }
                catch (FormatException)
                {
                    MessageBox.Show("A data informada é inválida");
                    mskCadDtAdmi.Clear();
                }

            }
        }

        private void btnCadUSalvar_Click(object sender, EventArgs e)
        {
            if (txtCadUMat.Text.Equals("") || cboCadUTipo.Text.Equals("") || txtCadULogin.Text.Equals("") || mskCadUSenha.Text.Equals("") || mskCadUConf.Text.Equals("") || txtCadUNome.Text.Equals(""))
            {
                MessageBox.Show("Favor preencher todos os campos do formulário.", "Cadastrar funcionário", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Funcionario Funcionario = new Funcionario();
                Usuario Usuario = new Usuario();
                int mat;
                bool conv;

                conv = Int32.TryParse(txtCadUMat.Text, out mat);
                if (conv == false)
                {
                    mat = 0;
                }
                else
                {
                    Int32.TryParse(txtCadUMat.Text, out mat);
                }

                Funcionario = FuncionarioDAO.ObterFuncionarioId(mat);
                if (Funcionario != null)
                {
                    Usuario.Funcionario = Funcionario;

                    Usuario.Tipo = cboCadUTipo.SelectedItem.ToString();
                    Usuario.Login = txtCadULogin.Text;
                    Usuario.Senha = mskCadUSenha.Text;

                    if (UsuarioDAO.Incluir(Usuario) == true)
                    {
                        MessageBox.Show("Usuário cadastrado com sucesso.");
                        txtCadUMat.Clear();
                        txtCadUNome.Clear();
                        txtCadULogin.Clear();
                        mskCadUSenha.Clear();
                        mskCadUConf.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Ocorreu um erro ao salvar os dados.");
                    }

                }
                else
                {
                    MessageBox.Show("A matrícula informada não existe");
                }
            }
        }



        private void txtCadULogin_Leave(object sender, EventArgs e)
        {
            Usuario Usuario = new Usuario();
            if (UsuarioDAO.ObterUsuarioLogin(txtCadULogin.Text) != null)
            {
                MessageBox.Show("O login informado já existe.");
                txtCadULogin.Clear();
            }
        }



        private void txtCadUMat_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void txtCadUMat_Leave(object sender, EventArgs e)
        {
            int mat;
            bool conv;

            conv = Int32.TryParse(txtCadUMat.Text, out mat);
            if (conv == false) {
                mat = 0;
            }
            else
            {
                Int32.TryParse(txtCadUMat.Text, out mat);
            }

            Funcionario Funcionario = new Funcionario();
            Usuario Usuario = new Usuario();
            Funcionario = FuncionarioDAO.ObterFuncionarioId(mat);

            if (Funcionario == null)
            {
                MessageBox.Show("A matrícula informada não existe.");
                txtCadUMat.Clear();
            }
            else
            {
                Usuario = UsuarioDAO.ObterUsuarioId(mat);
                if (Usuario != null)
                {
                    MessageBox.Show("O funcionário informado já possui um usuário cadastrado.");
                    txtCadUMat.Clear();
                    txtCadUNome.Clear();
                }
                else
                {
                    txtCadUNome.Text = Funcionario.Nome;
                }
            }

        }

        private void mskCadUConf_Leave(object sender, EventArgs e)
        {
            if (!mskCadUSenha.Text.Equals(mskCadUConf.Text))
            {
                MessageBox.Show("A senha e a confirmação de senha informadas devem ser iguais.");
                mskCadUConf.Clear();
            }
        }

        private void txtCadEMat_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void txtCadEMat_Leave(object sender, EventArgs e)
        {
            int mat;
            bool conv;

            conv = Int32.TryParse(txtCadEMat.Text, out mat);
            if (conv == false)
            {
                mat = 0;
            }

            Funcionario Funcionario = new Funcionario();
            Funcionario = FuncionarioDAO.ObterFuncionarioId(mat);

            if (Funcionario == null)
            {
                MessageBox.Show("A matrícula informada não existe.");
                txtCadEMat.Clear();
            }
            else
            {
                txtCadENome.Text = Funcionario.Nome;
                mskCadEData.Enabled = true;
            }
        }

        private void mskCadEData_Leave(object sender, EventArgs e)
        {
            int mat;
            bool conv;

            conv = Int32.TryParse(txtCadEMat.Text, out mat);
            if (conv == false)
            {
                mat = 0;
            }


            if (mskCadEData.Text.Contains(" "))
            {
                MessageBox.Show("Por favor, informe a data.");
                mskCadEData.Clear();
            }
            else
            {
                DateTime dataE;
                string dt = mskCadEData.Text;

                try
                {
                    dataE = Convert.ToDateTime(dt);
                    if (dataE.Year == DateTime.Now.Year)
                    {
                        Escala Escala = new Escala();
                        Escala = EscalaDAO.ObterEscalaData(mat, dataE);
                        if (Escala != null)
                        {
                            if (MessageBox.Show("O funcionário informado já possui uma escala para esta data. Deseja alterar a escala deste funcionário?",
                        "Alterar escala", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                lblCadEscID.Text = Escala.Id.ToString();
                                mskCadEData.Text = Escala.Data.ToString();
                                txtCadENome.Text = Escala.Funcionario.Nome;
                                mskCadEData.Text = Escala.Data.ToString();
                                cboCadEscala.Text = Escala.Ausencia.Nome;


                                txtCadEMat.Enabled = false;
                                txtCadENome.Enabled = false;
                                mskCadEData.Enabled = false;
                                cboCadEscala.Enabled = true;
                                btnCadESalvar.Enabled = false;
                                btnCadEAlterar.Enabled = true;
                                btnCadEExcluir.Enabled = false;
                            }
                            else
                            {
                                if (MessageBox.Show("Deseja excluir a escala deste funcionário?",
                                                            "Excluir escala", MessageBoxButtons.YesNo) == DialogResult.Yes)
                                {
                                    lblCadEscID.Text = Escala.Id.ToString();
                                    mskCadEData.Text = Escala.Data.ToString();
                                    txtCadENome.Text = Escala.Funcionario.Nome;
                                    mskCadEData.Text = Escala.Data.ToString();
                                    cboCadEscala.Text = Escala.Ausencia.Nome;


                                    txtCadEMat.Enabled = false;
                                    txtCadENome.Enabled = false;
                                    mskCadEData.Enabled = false;
                                    cboCadEscala.Enabled = false;
                                    btnCadESalvar.Enabled = false;
                                    btnCadEAlterar.Enabled = false;
                                    btnCadEExcluir.Enabled = true;
                                    btnCadExcluir.TabIndex = 0;

                                }
                                else
                                {
                                    MessageBox.Show("Operação Cancelada");
                                    LimparCamposEscala();
                                }
                            }

                        }
                        else
                        {
                            cboCadEscala.Enabled = true;
                            btnCadESalvar.Enabled = true;
                        }
                    }
                    else
                    {
                        MessageBox.Show("É permitido cadastrar escalas somente para o ano vigente");
                        mskCadEData.Clear();
                    }
                }
                catch (FormatException)
                {
                    MessageBox.Show("A data informada é inválida");
                    mskCadEData.Clear();
                }

            }



        }

        private void txdCadDpMat_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void txtCadDpMat_Leave(object sender, EventArgs e)
        {
            if (txtCadDpMat.Text.Contains(" ") || txtCadDpMat.Text.Equals("") || txtCadDpMat.Text == null)
            {
                MessageBox.Show("Por favor, informe a matrícula.");
                txtCadDpMat.Clear();
            }
            else
            {
                string m = txtCadDpMat.Text;
                int mat = int.Parse(m);
                Funcionario Funcionario = new Funcionario();
                Departamento Departamento = new Departamento();
                Funcionario = FuncionarioDAO.ObterFuncionarioId(mat);

                if (Funcionario == null)
                {
                    MessageBox.Show("A matrícula informada não existe.");
                    txtCadDpMat.Clear();
                }
                else
                {
                    Departamento = DepartamentoDAO.ObterDepartamentoId(mat);
                    if (Departamento != null)
                    {
                        if (MessageBox.Show("O funcionário informado já possui um departamento cadastrado. Deseja alterar os dados deste funcionário?",
                        "Alterar departamento", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            lblCadDptoID.Text = Departamento.Id.ToString();
                            txtCadDpMat.Text = Departamento.Funcionario.Id.ToString();
                            txtCadDpMat.Enabled = false;
                            txtCadDpNome.Text = Departamento.Funcionario.Nome;
                            mskCadDpHorario.Text = Departamento.Horario.TimeOfDay.ToString();
                            mskCadDpHorario.Enabled = true;
                            cboCadDpSup.Text = Departamento.Supervisor.Nome;
                            cboCadDpSup.Enabled = true;
                            cboCadDpCargo.Text = Departamento.Cargo.Nome;
                            cboCadDpCargo.Enabled = true;

                            btnCadDpAlterar.Enabled = true;
                            btnCadDpSalvar.Enabled = false;
                            btnCadDpExcluir.Enabled = false;
                        }
                        else
                        {
                            if (MessageBox.Show("Deseja excluir este funcionário do departamento?",
                        "Excluir departamento", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                lblCadDptoID.Text = Departamento.Id.ToString();
                                txtCadDpMat.Text = Departamento.Funcionario.Id.ToString();
                                txtCadDpMat.Enabled = false;
                                txtCadDpNome.Text = Departamento.Funcionario.Nome;
                                mskCadDpHorario.Text = Departamento.Horario.TimeOfDay.ToString();
                                mskCadDpHorario.Enabled = false;
                                cboCadDpSup.Text = Departamento.Supervisor.Nome;
                                cboCadDpSup.Enabled = false;
                                cboCadDpCargo.Text = Departamento.Cargo.Nome;
                                cboCadDpCargo.Enabled = false;

                                btnCadDpAlterar.Enabled = false;
                                btnCadDpSalvar.Enabled = false;
                                btnCadDpExcluir.Enabled = true;
                                btnCadDpExcluir.TabIndex = 0;
                            }
                            else
                            {
                                MessageBox.Show("Operação cancelada.");
                                LimparCamposDpto();
                            }
                        }
                    }
                    else
                    {
                        txtCadDpNome.Text = Funcionario.Nome;
                        mskCadDpHorario.Enabled = true;
                        cboCadDpSup.Enabled = true;
                        cboCadDpCargo.Enabled = true;
                        btnCadDpSalvar.Enabled = true;
                    }
                }
            }


        }

        private void mskCadDpHorario_Leave(object sender, EventArgs e)
        {
            if (mskCadDpHorario.Text.Contains(" "))
            {
                MessageBox.Show("Por favor, informe o horário");
                mskCadDpHorario.Clear();
            }
            else
            {
                DateTime convertedDate;
                string hr = mskCadDpHorario.Text;

                try
                {
                    convertedDate = Convert.ToDateTime(hr);
                }
                catch (FormatException)
                {
                    MessageBox.Show("O horário informado é inválido.");
                    mskCadDpHorario.Clear();
                }

            }
        }

        private void cboCadDpSup_Click(object sender, EventArgs e)
        {
            cboCadDpSup.Items.Clear();

            foreach (Departamento x in DepartamentoDAO.ObterSupervisores())
            {
                if (!cboCadDpSup.Items.Contains(x.Supervisor.Nome))
                {
                    cboCadDpSup.Items.Add(x.Funcionario.Nome);
                }
            }

        }

        private void cboCadDpCargo_Click(object sender, EventArgs e)
        {
            foreach (Cargo x in CargoDAO.ObterCargos())
            {
                if (!cboCadDpCargo.Items.Contains(x.Nome))
                {
                    cboCadDpCargo.Items.Add(x.Nome);
                }
            }
        }

        private void btnCadDpSalvar_Click(object sender, EventArgs e)
        {
            if (txtCadDpMat.Text.Equals("") || txtCadDpNome.Text.Equals("") || mskCadDpHorario.Text.Contains(" ") || cboCadDpSup.Text.Equals("") || cboCadDpCargo.Text.Equals(""))
            {
                MessageBox.Show("Favor preencher todos os campos do formulário.", "Cadastrar departamento", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Funcionario Funcionario = new Funcionario();
                Departamento Departamento = new Departamento();
                Funcionario Supervisor = new Funcionario();
                Cargo Cargo = new Cargo();
                int mat;
                bool conv;
                Supervisor.Nome = cboCadDpSup.Text;
                Cargo.Nome = cboCadDpCargo.Text;

                conv = Int32.TryParse(txtCadDpMat.Text, out mat);
                if (conv == false)
                {
                    mat = 0;
                }


                Funcionario = FuncionarioDAO.ObterFuncionarioId(mat);
                if (Funcionario != null)
                {
                    Departamento.Funcionario = Funcionario;
                    Departamento.Supervisor = FuncionarioDAO.ObterFuncionarioNome(Supervisor);
                    Departamento.Cargo = CargoDAO.ObterCargoNome(Cargo);
                    string hora = mskCadDpHorario.Text;
                    DateTime horario;
                    horario = Convert.ToDateTime(hora);
                    Departamento.Horario = horario;

                    if (DepartamentoDAO.Incluir(Departamento) == true)
                    {
                        MessageBox.Show("Funcionário cadastrado no departamento com sucesso.");
                        LimparCamposDpto();
                    }
                    else
                    {
                        MessageBox.Show("Ocorreu um erro ao salvar os dados.");
                    }

                }
                else
                {
                    MessageBox.Show("A matrícula informada não existe");
                }
            }
        }

        private void cboCadEscala_Click(object sender, EventArgs e)
        {
            foreach (Ausencia x in AusenciaDAO.ObterAusencias())
            {
                if (!cboCadEscala.Items.Contains(x.Nome))
                {
                    cboCadEscala.Items.Add(x.Nome);
                }
            }
        }

        private void btnCadESalvar_Click(object sender, EventArgs e)
        {
            if (txtCadEMat.Text.Equals("") || txtCadENome.Text.Equals("") || mskCadEData.Text.Contains(" ") || cboCadEscala.Text.Equals(""))
            {
                MessageBox.Show("Favor preencher todos os campos do formulário.", "Cadastrar escala", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Funcionario Funcionario = new Funcionario();
                Escala Escala = new Escala();
                Ausencia Ausencia = new Ausencia();

                int mat;
                bool conv;

                conv = Int32.TryParse(txtCadEMat.Text, out mat);
                if (conv == false)
                {
                    mat = 0;
                }

                Funcionario = FuncionarioDAO.ObterFuncionarioId(mat);
                if (Funcionario != null)
                {
                    Escala.Funcionario = Funcionario;
                    Ausencia.Nome = cboCadEscala.SelectedItem.ToString();
                    Escala.Ausencia = AusenciaDAO.ObterAusenciaNome(Ausencia);

                    string dia = mskCadEData.Text;
                    DateTime data;
                    data = Convert.ToDateTime(dia);
                    Escala.Data = data;

                    if (EscalaDAO.Incluir(Escala) == true)
                    {
                        MessageBox.Show("Escala cadastrada com sucesso.");
                        LimparCamposEscala();
                    }
                    else
                    {
                        MessageBox.Show("Ocorreu um erro ao salvar os dados.");
                    }

                }
                else
                {
                    MessageBox.Show("A matrícula informada não existe");
                }
            }
        }

        private void txtCadHeMat_Leave(object sender, EventArgs e)
        {
            int mat;
            bool conv;

            conv = Int32.TryParse(txtCadHeMat.Text, out mat);
            if (conv == false)
            {
                mat = 0;
            }

            Funcionario Funcionario = new Funcionario();
            Funcionario = FuncionarioDAO.ObterFuncionarioId(mat);

            if (Funcionario == null)
            {
                MessageBox.Show("A matrícula informada não existe.");
                txtCadHeMat.Clear();
                txtCadHeNome.Clear();
            }
            else
            {
                txtCadHeNome.Text = Funcionario.Nome;
            }
        }

        private void mskCadHeData_Leave(object sender, EventArgs e)
        {

            if (mskCadHeData.Text.Contains(" "))
            {
                MessageBox.Show("Por favor, a data.");
                mskCadHeData.Clear();
            }
            else
            {
                DateTime dataHE;
                string dt = mskCadHeData.Text;

                try
                {
                    dataHE = Convert.ToDateTime(dt);
                    int mat;
                    bool conv;

                    conv = Int32.TryParse(txtCadHeMat.Text, out mat);
                    if (conv == false)
                    {
                        mat = 0;
                    }

                    if (dataHE.Date >= DateTime.Now.Date)
                    {
                        HoraExtra HoraExtra = new HoraExtra();
                        HoraExtra = HoraExtraDAO.ObterHoraExtraData(mat, dataHE);
                        if (HoraExtra != null)
                        {
                            if (MessageBox.Show("O funcionário informado já possui hora extra cadastrada para esta data. Deseja alterar a hora extra deste funcionário?",
                        "Alterar hora extra", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                lblCadHeID.Text = HoraExtra.Id.ToString();
                                txtCadHeNome.Text = HoraExtra.Funcionario.Nome;
                                txtCadHeMat.Text = HoraExtra.Funcionario.Id.ToString();
                                mskCadHeFim.Text = HoraExtra.Fim.TimeOfDay.ToString();
                                mskCadHeInicio.Text = HoraExtra.Inicio.TimeOfDay.ToString();
                                mskCadEData.Text = HoraExtra.Data.ToString();

                                btnCadHeAlterar.Enabled = true;
                                btnCadHeSalvar.Enabled = false;
                                btnCadHeExcluir.Enabled = false;
                                txtCadHeNome.Enabled = false;
                                txtCadHeMat.Enabled = false;
                                mskCadHeFim.Enabled = true;
                                mskCadHeInicio.Enabled = true;
                                mskCadEData.Enabled = false;

                            }
                            else
                            {
                                if (MessageBox.Show("Deseja excluir a hora extra deste funcionário?",
                                    "Excluir hora extra", MessageBoxButtons.YesNo) == DialogResult.Yes)
                                {
                                    lblCadHeID.Text = HoraExtra.Id.ToString();
                                    txtCadHeNome.Text = HoraExtra.Funcionario.Nome;
                                    txtCadHeMat.Text = HoraExtra.Funcionario.Id.ToString();
                                    mskCadHeFim.Text = HoraExtra.Fim.TimeOfDay.ToString();
                                    mskCadHeInicio.Text = HoraExtra.Inicio.TimeOfDay.ToString();
                                    mskCadEData.Text = HoraExtra.Data.ToString();

                                    btnCadHeAlterar.Enabled = false;
                                    btnCadHeSalvar.Enabled = false;
                                    btnCadHeExcluir.Enabled = true;
                                    txtCadHeNome.Enabled = false;
                                    txtCadHeMat.Enabled = false;
                                    mskCadHeFim.Enabled = true;
                                    mskCadHeInicio.Enabled = true;
                                    mskCadEData.Enabled = false;
                                    btnCadHeExcluir.TabIndex = 0;
                                }
                                else
                                {
                                    MessageBox.Show("Operação Cancelada");
                                    LimparCamposHE();
                                }
                            }
                        }
                        else
                        {
                            btnCadHeAlterar.Enabled = false;
                            btnCadHeSalvar.Enabled = true;
                            btnCadHeExcluir.Enabled = false;
                            txtCadHeNome.Enabled = false;
                            txtCadHeMat.Enabled = false;
                            mskCadHeFim.Enabled = true;
                            mskCadHeInicio.Enabled = true;
                            mskCadEData.Enabled = false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("É permitido cadastrar horas extras somente para a data atual ou futura.");
                        mskCadHeData.Clear();
                    }
                }
                catch (FormatException)
                {
                    MessageBox.Show("A data informada é inválida");
                    mskCadHeData.Clear();
                }
            }
        }

        public void LimparCamposHE()
        {
            btnCadHeAlterar.Enabled = false;
            btnCadHeSalvar.Enabled = false;
            btnCadHeExcluir.Enabled = false;
            txtCadHeNome.Enabled = false;
            txtCadHeMat.Enabled = true;
            mskCadHeFim.Enabled = false;
            mskCadHeInicio.Enabled = false;
            mskCadEData.Enabled = true;

            txtCadHeNome.Clear();
            txtCadHeMat.Clear();
            mskCadHeFim.Clear();
            mskCadHeInicio.Clear();
            mskCadHeData.Clear();
            mskCadHeHora.Clear();
        }
    

        private void mskCadHeInicio_Leave(object sender, EventArgs e)
        {
            if (mskCadHeInicio.Text.Contains(" "))
            {
                MessageBox.Show("Por favor, informe o horário");
                mskCadHeInicio.Clear();
            }
            else
            {
                DateTime convertedDate;
                string hr = mskCadHeInicio.Text;

                try
                {
                    convertedDate = Convert.ToDateTime(hr);
                }
                catch (FormatException)
                {
                    MessageBox.Show("O horário informado é inválido.");
                    mskCadHeInicio.Clear();
                }

            }

        }

        private void mskCadHeFim_Leave(object sender, EventArgs e)
        {

            if (mskCadHeFim.Text.Contains(" "))
            {
                MessageBox.Show("Por favor, informe o horário");
                mskCadHeFim.Clear();
            }
            else
            {
                DateTime fim;
                string hr = mskCadHeFim.Text;

                try
                {
                    fim = Convert.ToDateTime(hr);
                    string ini = mskCadHeInicio.Text;
                    DateTime inicio;
                    inicio = Convert.ToDateTime(ini);

                    if (fim < inicio)
                    {
                        MessageBox.Show("A hora final deve ser maior que a hora inicial.");
                    }
                    else
                    {
                        mskCadHeHora.Text = (fim - inicio).ToString();
                    }
                }
                catch (FormatException)
                {
                    MessageBox.Show("O horário informado é inválido.");
                    mskCadHeFim.Clear();
                }
            }
        }
            

        private void btnCadHeSalvar_Click(object sender, EventArgs e)
        {
            if (txtCadHeMat.Text.Equals("") || txtCadHeNome.Text.Equals("") || mskCadHeData.Text.Contains(" ") || mskCadHeInicio.Text.Contains(" ") || mskCadHeFim.Text.Contains(" ") )
            {
                MessageBox.Show("Favor preencher todos os campos do formulário.", "Cadastrar funcionário", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Funcionario Funcionario = new Funcionario();
                HoraExtra HoraExtra = new HoraExtra();
                int mat;
                bool conv;

                conv = Int32.TryParse(txtCadHeMat.Text, out mat);
                if (conv == false)
                {
                    mat = 0;
                }
                else
                {
                    Int32.TryParse(txtCadHeMat.Text, out mat);
                }

                Funcionario = FuncionarioDAO.ObterFuncionarioId(mat);
                if (Funcionario != null)
                {
                    HoraExtra.Funcionario = Funcionario;

                    string dt = mskCadHeData.Text;
                    string hr = mskCadHeHora.Text;
                    string ini = mskCadHeInicio.Text;
                    string f = mskCadHeFim.Text;

                    DateTime data;
                    DateTime horas;
                    DateTime inicio;
                    DateTime fim;

                    data = Convert.ToDateTime(dt);
                    horas = Convert.ToDateTime(hr);
                    inicio = Convert.ToDateTime(ini);
                    fim = Convert.ToDateTime(f);

                    HoraExtra.Data = data;
                    HoraExtra.Horas = horas;
                    HoraExtra.Inicio = inicio;
                    HoraExtra.Fim = fim;

                    if (HoraExtraDAO.Incluir(HoraExtra) == true)
                    {
                        MessageBox.Show("Hora extra cadastrada com sucesso.");
                        LimparCamposHE();
                    }
                    else
                    {
                        MessageBox.Show("Ocorreu um erro ao salvar os dados.");
                    }

                }
                else
                {
                    MessageBox.Show("A matrícula informada não existe");
                }
            }
        }

        private void btnCadExcluir_Click(object sender, EventArgs e)
        {
            Funcionario Funcionario = new Funcionario();
            string cpf = mskCadCPF.Text;

            Funcionario = FuncionarioDAO.ObterFuncionarioCpf(cpf);
            
            if (Funcionario != null)
            {
                if (FuncionarioDAO.Excluir(Funcionario))
                {
                    MessageBox.Show("Funcionário excluído com sucesso");
                    LimparCamposCadFunc();
                }
            }
        }

        private void btnCadAlterar_Click(object sender, EventArgs e)
        {
            Funcionario Funcionario = new Funcionario();

            if (txtCadNome.Text.Equals("") || mskCadCPF.Text.Contains(" ") || mskCadDtNasc.Text.Contains(" ") || txtCadRG.Text.Equals("") || txtCadEndereco.Text.Equals("") || mskCadTelefone.Text.Equals("") || mskCadDtAdmi.Text.Contains(" "))
            {
                MessageBox.Show("Favor preencher todos os campos do formulário.", "Cadastrar funcionário", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string dtN = mskCadDtNasc.Text;
                string dtA = mskCadDtAdmi.Text;
                DateTime dtNasc;
                DateTime dtAdmi;
                dtNasc = Convert.ToDateTime(dtN);
                dtAdmi = Convert.ToDateTime(dtA);
                Funcionario.Nome = txtCadNome.Text;
                Funcionario.Nascimento = dtNasc;
                Funcionario.Endereco = txtCadEndereco.Text;
                Funcionario.Telefone = mskCadTelefone.Text;
                Funcionario.Rg = txtCadRG.Text;
                Funcionario.Cidade = txtCadCidade.Text;
                Funcionario.Cpf = mskCadCPF.Text;
                Funcionario.Admissao = dtAdmi;
                Funcionario.Id = int.Parse(txtCadFuncID.Text);
                if (FuncionarioDAO.Alterar(Funcionario))
                {
                    MessageBox.Show("Cadastro do funcionário alterado com sucesso.");
                    LimparCamposCadFunc();
                }
                else
                {
                    MessageBox.Show("Ocorreu um erro ao salvar os dados.");
                }

            }
        }

        private void tabCadCadastro_Selecting(object sender, TabControlCancelEventArgs e)
        {
            LimparCamposCadFunc();
            LimparCamposDpto();
            LimparCamposAus();
            LimparCamposEscala();
            LimparCamposHE();

            if (lblTipoUsu.Text.Equals("USUÁRIO"))
            {
                mskCadCPF.Enabled = false;
                txtCadDpMat.Enabled = false;
                txtCadAus.Enabled = false;
                txtCadEMat.Enabled = false;
                txtCadHeMat.Text = lblUsuID.Text;
                txtCadHeMat.Enabled = false;
                txtCadCargo.Enabled = false;
                txtCadUMat.Text = lblUsuID.Text;
                txtCadUMat.Enabled = false;
            }
        }

        private void btnCadDpAlterar_Click(object sender, EventArgs e)
        {
            if (txtCadDpMat.Text.Equals("") || txtCadDpNome.Text.Equals("") || mskCadDpHorario.Text.Contains(" ") || cboCadDpSup.Text.Equals("") || cboCadDpCargo.Text.Equals(""))
            {
                MessageBox.Show("Favor preencher todos os campos do formulário.", "Cadastrar departamento", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Funcionario Funcionario = new Funcionario();
                Departamento Departamento = new Departamento();
                Funcionario Supervisor = new Funcionario();
                Cargo Cargo = new Cargo();
                int mat;
                bool conv;
                Supervisor.Nome = cboCadDpSup.Text;
                Cargo.Nome = cboCadDpCargo.Text;

                conv = Int32.TryParse(txtCadDpMat.Text, out mat);
                if (conv == false)
                {
                    mat = 0;
                }


                Funcionario = FuncionarioDAO.ObterFuncionarioId(mat);
                if (Funcionario != null)
                {
                    int id = 0;
                    id = int.Parse(lblCadDptoID.Text);
                    Departamento.Funcionario = Funcionario;
                    Departamento.Supervisor = FuncionarioDAO.ObterFuncionarioNome(Supervisor);
                    Departamento.Cargo = CargoDAO.ObterCargoNome(Cargo);
                    string hora = mskCadDpHorario.Text;
                    DateTime horario;
                    horario = Convert.ToDateTime(hora);
                    Departamento.Horario = horario;
                    Departamento.Id = id;

                    if (DepartamentoDAO.Alterar(Departamento) == true)
                    {
                        MessageBox.Show("Dados do departamento alterados com sucesso.");
                        LimparCamposDpto();
                    }
                    else
                    {
                        MessageBox.Show("Ocorreu um erro ao alterar os dados.");
                    }

                }
                else
                {
                    MessageBox.Show("A matrícula informada não existe");
                }
            }
        }

        private void btnCadDpExcluir_Click(object sender, EventArgs e)
        {
            Departamento Departamento = new Model.Departamento();
            int id = int.Parse(lblCadDptoID.Text);

            Departamento = DepartamentoDAO.ObterDepartamentoIdDP(id);

            if (Departamento != null)
            {
                if (DepartamentoDAO.Excluir(Departamento))
                {
                    MessageBox.Show("Funcionário excluído do departamento com sucesso.");
                    LimparCamposDpto();
                }
            }
        }

        private void btnCadAusAlterar_Click(object sender, EventArgs e)
        {
            if (txtCadAus.Text.Equals("") || txtCadSigla.Text.Equals(""))
            {
                MessageBox.Show("Favor preencher todos os campos do formulário.", "Alterar ausências", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                
                Ausencia Ausencia = new Ausencia();
                Ausencia.Nome = txtCadAus.Text;
                Ausencia.Sigla = txtCadSigla.Text;
                Ausencia.Id = int.Parse(lblCadAusID.Text);

                if (AusenciaDAO.Alterar(Ausencia) == true)
                {
                    MessageBox.Show("Ausência alterada com sucesso.");
                    LimparCamposAus();
                }
                else
                {
                    MessageBox.Show("Ocorreu um erro ao alterar os dados.");
                }
            }
        }

        private void btnCadAusExcluir_Click(object sender, EventArgs e)
        {
            Ausencia Ausencia = new Ausencia();
            Ausencia.Nome = txtCadAus.Text;

            Ausencia = AusenciaDAO.ObterAusenciaNome(Ausencia);

            if (Ausencia != null)
            {
                if (AusenciaDAO.Excluir(Ausencia) == true)
                {
                    MessageBox.Show("Ausência excluída com sucesso.");
                    LimparCamposAus();
                }
                else
                {
                    MessageBox.Show("Ocorreu um erro ao excluir os dados.");
                }
            }
            else
            {
                MessageBox.Show("Ausência não localizada.");
            }
        }

    public void LimparCamposEscala()
        {
            txtCadEMat.Clear();
            txtCadEMat.Enabled = true;
            txtCadENome.Clear();
            txtCadENome.Enabled = false;
            mskCadEData.Clear();
            mskCadEData.Enabled = false;
            cboCadEscala.Text = "";
            cboCadEscala.Enabled = false;
            btnCadESalvar.Enabled = false;
            btnCadEAlterar.Enabled = false;
            btnCadEExcluir.Enabled = false;
        }

        private void btnCadEAlterar_Click(object sender, EventArgs e)
        {
            if (txtCadEMat.Text.Equals("") || txtCadENome.Text.Equals("") || mskCadEData.Text.Contains(" ") || cboCadEscala.Text.Equals(""))
            {
                MessageBox.Show("Favor preencher todos os campos do formulário.", "Cadastrar escala", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Funcionario Funcionario = new Funcionario();
                Escala Escala = new Escala();
                Ausencia Ausencia = new Ausencia();

                int mat;
                bool conv;

                conv = Int32.TryParse(txtCadEMat.Text, out mat);
                if (conv == false)
                {
                    mat = 0;
                }

                Funcionario = FuncionarioDAO.ObterFuncionarioId(mat);
                if (Funcionario != null)
                {
                    Escala.Funcionario = Funcionario;
                    Ausencia.Nome = cboCadEscala.Text;
                    Escala.Ausencia = AusenciaDAO.ObterAusenciaNome(Ausencia);

                    string dia = mskCadEData.Text;
                    DateTime data;
                    data = Convert.ToDateTime(dia);
                    Escala.Data = data;

                    Escala.Id = int.Parse(lblCadEscID.Text);

                    if (EscalaDAO.Alterar(Escala) == true)
                    {
                        MessageBox.Show("Escala alterada com sucesso.");
                        LimparCamposEscala();
                    }
                    else
                    {
                        MessageBox.Show("Ocorreu um erro ao salvar os dados.");
                    }

                }
                else
                {
                    MessageBox.Show("A matrícula informada não existe");
                }
            }
        }

        private void btnCadEExcluir_Click(object sender, EventArgs e)
        {
            Escala Escala = new Escala();
            int id = 0;
            id = int.Parse(lblCadEscID.Text);

            Escala = EscalaDAO.ObterEscalaID(id);

            if (Escala != null)
            {
                if (EscalaDAO.Excluir(Escala))
                {
                    MessageBox.Show("Escala excluída com sucesso");
                    LimparCamposEscala();
                }
            }

        }

        private void btnCadHeAlterar_Click(object sender, EventArgs e)
        {
            if (txtCadHeMat.Text.Equals("") || txtCadHeNome.Text.Equals("") || mskCadHeData.Text.Contains(" ") || mskCadHeInicio.Text.Contains(" ") || mskCadHeFim.Text.Contains(" "))
            {
                MessageBox.Show("Favor preencher todos os campos do formulário.", "Cadastrar hora extra", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Funcionario Funcionario = new Funcionario();
                HoraExtra HoraExtra = new HoraExtra();

                int mat;
                bool conv;

                conv = Int32.TryParse(txtCadHeMat.Text, out mat);
                if (conv == false)
                {
                    mat = 0;
                }

                Funcionario = FuncionarioDAO.ObterFuncionarioId(mat);
                if (Funcionario != null)
                {
                    HoraExtra.Funcionario = Funcionario;
                    string dt = mskCadHeData.Text;
                    string hr = mskCadHeHora.Text;
                    string ini = mskCadHeInicio.Text;
                    string f = mskCadHeFim.Text;

                    DateTime data;
                    DateTime horas;
                    DateTime inicio;
                    DateTime fim;

                    data = Convert.ToDateTime(dt);
                    horas = Convert.ToDateTime(hr);
                    inicio = Convert.ToDateTime(ini);
                    fim = Convert.ToDateTime(f);

                    HoraExtra.Data = data;
                    HoraExtra.Horas = horas;
                    HoraExtra.Inicio = inicio;
                    HoraExtra.Fim = fim;
                    HoraExtra.Id = int.Parse(lblCadHeID.Text);

                    if (HoraExtraDAO.Alterar(HoraExtra) == true)
                    {
                        MessageBox.Show("Hora extra alterada com sucesso.");
                        LimparCamposHE();
                    }
                    else
                    {
                        MessageBox.Show("Ocorreu um erro ao salvar os dados.");
                    }

                }
                else
                {
                    MessageBox.Show("A matrícula informada não existe");
                }
            }
        }

        private void btnCadHeExcluir_Click(object sender, EventArgs e)
        {
            HoraExtra HoraExtra = new HoraExtra();
            int id = 0;
            id = int.Parse(lblCadHeID.Text);

            HoraExtra = HoraExtraDAO.ObterHoraExtraID(id);

            if (HoraExtra != null)
            {
                if (HoraExtraDAO.Excluir(HoraExtra))
                {
                    MessageBox.Show("Hora extra excluída com sucesso");
                    LimparCamposHE();
                }
            }

        }

        private void frmCadastro_Load(object sender, EventArgs e)
        {
            lblUsuID.Text = pri.lblFuncID.Text;
            lblTipoUsu.Text = pri.lblTipoUsu.Text;
        }




















        //fim -----------------------------
    }
}
