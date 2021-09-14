using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using REGRA_NEGOCIOS;
using OBJETO_TRANSFERENCIA;
using IMPRESSORA;

namespace SAT
{
    public partial class frmCpfCnpj : Form
    {
        frmVenda frmVenda;

        public frmCpfCnpj(frmVenda fVenda)
        {
            InitializeComponent();

            this.frmVenda = fVenda;
        }

        #region VARIAVEIS

        public string valorCpf = "";
        public int tipo = 0;
        public string nome, email = "";
        public int idCliente = 0;

        #endregion

        #region CLASSES E OBJETOS

        TempC tempC = new TempC();
        TempRegraNegocios tempRegraNegocios = new TempRegraNegocios();
        ClienteRegraNegocios clienteRegraNegocios;
        ValidarRegraNegocios validarRegraNegocios;

        #endregion

        private void frmCpfCnpj_Load(object sender, EventArgs e)
        {
            PesquisarTemp();
        }

        private void RBCnpj_CheckedChanged(object sender, EventArgs e)
        {
            if (RBCnpj.Checked == true)
            {
                txtCnpj.Mask = "00-000-000/0000-00";
                lblDescricao.Text = "CNPJ:";
                txtCnpj.Focus();

                tipo = 1;
            }
            else if (rbCpf.Checked == true)
            {
                txtCnpj.Mask = "000-000-000-00";
                lblDescricao.Text = "CPF:";
                txtCnpj.Focus();

                tipo = 2;
            }
            else
            {
                txtCnpj.Mask = "(00)0000-000-00";
                lblDescricao.Text = "TEL:";
                txtCnpj.Focus();

                tipo = 3;
            }
        }

        private void rbCpf_CheckedChanged(object sender, EventArgs e)
        {
            if (RBCnpj.Checked == true)
            {
                txtCnpj.Mask = "00-000-000/0000-00";
                lblDescricao.Text = "CNPJ:";
                txtCnpj.Focus();

                tipo = 1;
            }
            else if (rbCpf.Checked == true)
            {
                txtCnpj.Mask = "000-000-000-00";
                lblDescricao.Text = "CPF:";
                txtCnpj.Focus();

                tipo = 2;
            }
            else
            {
                txtCnpj.Mask = "(00)0000-000-00";
                lblDescricao.Text = "TEL:";
                txtCnpj.Focus();

                tipo = 3;
            }
        }

        private void txtCnpj_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Escape)
            {
                btnCancelarCpfCnpj_Click(sender, e);
            }

            if ((Keys)e.KeyChar == Keys.Enter)
            {
                if (idCliente > 0)
                {
                    if (MessageBox.Show("Realmente Deseja Selecionar o Cliente: " + txtNome.Text.Trim() + " a essa Venda.", "Confirmação de Venda Cliente", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult)
                    {
                        btnCpfCliente_Click(sender, e);
                    }
                }
                else
                {
                    btnCpfCliente_Click(sender, e);
                }
            }
        }

        private void btnCancelarCpfCnpj_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCpfCliente_Click(object sender, EventArgs e)
        {
            CadastrarCpfCnpjVenda();
        }

        public void CadastrarCpfCnpjVenda()
        {
            try
            {
                if (rbCpf.Checked == true)
                {
                    valorCpf = txtCnpj.Text;
                    tipo = 1;

                    valorCpf = valorCpf.Replace(" ", "");
                    valorCpf = valorCpf.Replace(",", "");
                    valorCpf = valorCpf.Replace("-", "");
                    valorCpf = valorCpf.Replace(".", "");

                    if (valorCpf != "")
                    {
                        if (valorCpf == "00000000000")
                        {
                            MessageBox.Show("Atenção CPF " + valorCpf + " é Inválido.\nPor Favor Informe outro CPF Válido.", "Informação do CPF", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtCnpj.Focus();
                        }
                        else if (valorCpf == "11111111111")
                        {
                            MessageBox.Show("Atenção CPF " + valorCpf + " é Inválido.\nPor Favor Informe outro CPF Válido.", "Informação do CPF", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtCnpj.Focus();
                        }
                        else if (valorCpf == "22222222222")
                        {
                            MessageBox.Show("Atenção CPF " + valorCpf + " é Inválido.\nPor Favor Informe outro CPF Válido.", "Informação do CPF", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtCnpj.Focus();
                        }
                        else if (valorCpf == "33333333333")
                        {
                            MessageBox.Show("Atenção CPF " + valorCpf + " é Inválido.\nPor Favor Informe outro CPF Válido.", "Informação do CPF", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtCnpj.Focus();
                        }
                        else if (valorCpf == "44444444444")
                        {
                            MessageBox.Show("Atenção CPF " + valorCpf + " é Inválido.\nPor Favor Informe outro CPF Válido.", "Informação do CPF", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtCnpj.Focus();
                        }
                        else if (valorCpf == "55555555555")
                        {
                            MessageBox.Show("Atenção CPF " + valorCpf + " é Inválido.\nPor Favor Informe outro CPF Válido.", "Informação do CPF", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtCnpj.Focus();
                        }
                        else if (valorCpf == "66666666666")
                        {
                            MessageBox.Show("Atenção CPF " + valorCpf + " é Inválido.\nPor Favor Informe outro CPF Válido.", "Informação do CPF", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtCnpj.Focus();
                        }
                        else if (valorCpf == "77777777777")
                        {
                            MessageBox.Show("Atenção CPF " + valorCpf + " é Inválido.\nPor Favor Informe outro CPF Válido.", "Informação do CPF", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtCnpj.Focus();
                        }
                        else if (valorCpf == "88888888888")
                        {
                            MessageBox.Show("Atenção CPF " + valorCpf + " é Inválido.\nPor Favor Informe outro CPF Válido.", "Informação do CPF", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtCnpj.Focus();
                        }
                        else if (valorCpf == "99999999999")
                        {
                            MessageBox.Show("Atenção CPF " + valorCpf + " é Inválido.\nPor Favor Informe outro CPF Válido.", "Informação do CPF", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtCnpj.Focus();
                        }
                        else
                        {
                            if (REGRA_NEGOCIOS.TempRegraNegocios.IsCpf(valorCpf))
                            {
                                tempC = new TempC();
                                tempRegraNegocios = new TempRegraNegocios();

                                tempC.cpf = valorCpf;
                                tempC.tipo = tipo;
                                tempC.nome = nome;
                                tempC.idCliente = idCliente;

                                string idRetorno = tempRegraNegocios.CadastrarCpfCnpj(tempC);

                                try
                                {
                                    int idRet = Convert.ToInt32(idRetorno);

                                    this.Close();
                                }
                                catch
                                {
                                    MessageBox.Show("Erro ao Cadastrar CPF.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    txtCnpj.Focus();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Atenção CPF " + valorCpf + " é Inválido.\nPor Favor Informe outro CPF Válido.", "Informação do CPF", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                txtCnpj.Focus();
                            }
                        }
                    }
                    else
                    {
                        this.Close();
                    }
                }
                else if (RBCnpj.Checked == true)
                {
                    valorCpf = txtCnpj.Text;
                    tipo = 1;

                    valorCpf = valorCpf.Replace(" ", "");
                    valorCpf = valorCpf.Replace(",", "");
                    valorCpf = valorCpf.Replace("-", "");
                    valorCpf = valorCpf.Replace(".", "");

                    if (valorCpf != "")
                    {
                        if (valorCpf == "00000000000")
                        {
                            MessageBox.Show("Atenção CPF " + valorCpf + " é Inválido.\nPor Favor Informe outro CPF Válido.", "Informação do CPF", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtCnpj.Focus();
                        }
                        else if (valorCpf == "11111111111")
                        {
                            MessageBox.Show("Atenção CPF " + valorCpf + " é Inválido.\nPor Favor Informe outro CPF Válido.", "Informação do CPF", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtCnpj.Focus();
                        }
                        else if (valorCpf == "22222222222")
                        {
                            MessageBox.Show("Atenção CPF " + valorCpf + " é Inválido.\nPor Favor Informe outro CPF Válido.", "Informação do CPF", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtCnpj.Focus();
                        }
                        else if (valorCpf == "33333333333")
                        {
                            MessageBox.Show("Atenção CPF " + valorCpf + " é Inválido.\nPor Favor Informe outro CPF Válido.", "Informação do CPF", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtCnpj.Focus();
                        }
                        else if (valorCpf == "44444444444")
                        {
                            MessageBox.Show("Atenção CPF " + valorCpf + " é Inválido.\nPor Favor Informe outro CPF Válido.", "Informação do CPF", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtCnpj.Focus();
                        }
                        else if (valorCpf == "55555555555")
                        {
                            MessageBox.Show("Atenção CPF " + valorCpf + " é Inválido.\nPor Favor Informe outro CPF Válido.", "Informação do CPF", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtCnpj.Focus();
                        }
                        else if (valorCpf == "66666666666")
                        {
                            MessageBox.Show("Atenção CPF " + valorCpf + " é Inválido.\nPor Favor Informe outro CPF Válido.", "Informação do CPF", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtCnpj.Focus();
                        }
                        else if (valorCpf == "77777777777")
                        {
                            MessageBox.Show("Atenção CPF " + valorCpf + " é Inválido.\nPor Favor Informe outro CPF Válido.", "Informação do CPF", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtCnpj.Focus();
                        }
                        else if (valorCpf == "88888888888")
                        {
                            MessageBox.Show("Atenção CPF " + valorCpf + " é Inválido.\nPor Favor Informe outro CPF Válido.", "Informação do CPF", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtCnpj.Focus();
                        }
                        else if (valorCpf == "99999999999")
                        {
                            MessageBox.Show("Atenção CPF " + valorCpf + " é Inválido.\nPor Favor Informe outro CPF Válido.", "Informação do CPF", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtCnpj.Focus();
                        }
                        else
                        {
                            if (REGRA_NEGOCIOS.TempRegraNegocios.IsCnpj(valorCpf))
                            {
                                tempC = new TempC();
                                tempRegraNegocios = new TempRegraNegocios();

                                tempC.cpf = valorCpf;
                                tempC.tipo = tipo;
                                tempC.nome = nome;
                                tempC.idCliente = idCliente;

                                string idRetorno = tempRegraNegocios.CadastrarCpfCnpj(tempC);

                                try
                                {
                                    int idRet = Convert.ToInt32(idRetorno);

                                    this.Close();
                                }
                                catch
                                {
                                    MessageBox.Show("Erro ao Cadastrar CPF.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    txtCnpj.Focus();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Atenção CPF " + valorCpf + " é Inválido.\nPor Favor Informe outro CPF Válido.", "Informação do CPF", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                txtCnpj.Focus();
                            }
                        }
                    }
                    else
                    {
                        this.Close();
                    }

                    frmVenda.idCliente = idCliente;
                }
                else if (rbTelefone.Checked == true)
                {
                    tempC = new TempC();
                    tempRegraNegocios = new TempRegraNegocios();

                    tempC.cpf = valorCpf;
                    tempC.tipo = tipo;
                    tempC.nome = nome;
                    tempC.idCliente = idCliente;

                    string idRetorno = tempRegraNegocios.CadastrarCpfCnpj(tempC);

                    try
                    {
                        int idRet = Convert.ToInt32(idRetorno);

                        frmVenda.idCliente = idCliente;

                        this.Close();
                    }
                    catch
                    {
                        MessageBox.Show("Erro ao Cadastrar CPF.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtCnpj.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção");
            }
        }

        public void PesquisarTemp()
        {
            try
            {
                tempRegraNegocios = new TempRegraNegocios();
                DataTable dadosTabelaTemp = new DataTable();

                dadosTabelaTemp = tempRegraNegocios.PesquisarTemp();

                if (dadosTabelaTemp.Rows.Count > 0)
                {
                    if (RBCnpj.Checked == true)
                    {
                        txtCnpj.Mask = "00-000-000/0000-00";
                        lblDescricao.Text = "CNPJ:";
                        txtCnpj.Focus();

                        tipo = 1;
                    }
                    else if (rbCpf.Checked == true)
                    {
                        txtCnpj.Mask = "000-000-000-00";
                        lblDescricao.Text = "CPF:";
                        txtCnpj.Focus();

                        tipo = 2;
                    }
                    else
                    {
                        txtCnpj.Mask = "(00)0000-000-00";
                        lblDescricao.Text = "TEL:";
                        txtCnpj.Focus();

                        tipo = 3;
                    }

                    txtCnpj.Text = dadosTabelaTemp.Rows[0]["CPF_CNPJ"].ToString();
                }
                else
                {
                    if (RBCnpj.Checked == true)
                    {
                        txtCnpj.Mask = "00-000-000/0000-00";
                        lblDescricao.Text = "CNPJ:";
                        txtCnpj.Focus();

                        tipo = 1;
                    }
                    else if (rbCpf.Checked == true)
                    {
                        txtCnpj.Mask = "000-000-000-00";
                        lblDescricao.Text = "CPF:";
                        txtCnpj.Focus();

                        tipo = 2;
                    }
                    else
                    {
                        txtCnpj.Mask = "(00)0000-000-00";
                        lblDescricao.Text = "TEL:";
                        txtCnpj.Focus();

                        tipo = 3;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void LimparCampo()
        {
            txtCnpj.Text = "";

            if (rbCpf.Checked == true)
            {
                txtCnpj.Mask = "000-000-000-00";
            }
            else
            {
                txtCnpj.Mask = "00-000-000/0000-00";
            }
        }

        private void txtCnpj_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                btnCancelarCpfCnpj_Click(sender, e);
            }
        }

        private void rbTelefone_CheckedChanged(object sender, EventArgs e)
        {
            if (RBCnpj.Checked == true)
            {
                txtCnpj.Mask = "00-000-000/0000-00";
                lblDescricao.Text = "CNPJ:";
                txtCnpj.Focus();

                tipo = 1;
            }
            else if (rbCpf.Checked == true)
            {
                txtCnpj.Mask = "000-000-000-00";
                lblDescricao.Text = "CPF:";
                txtCnpj.Focus();

                tipo = 2;
            }
            else
            {
                txtCnpj.Mask = "(00)0000-000-00";
                lblDescricao.Text = "TEL:";
                txtCnpj.Focus();

                tipo = 3;
            }
        }

        private void btnPesquisarCliente_Click(object sender, EventArgs e)
        {
            PesquisarCliente();
        }

        public bool ValidarDocumento()
        {
            if (tipo == 3)
            {
                return true;
            }
            else
            {
                validarRegraNegocios = new ValidarRegraNegocios();

                if (rbCpf.Checked == true)
                {
                    return validarRegraNegocios.IsCpf(txtCnpj.Text);
                }
                else
                {
                    return validarRegraNegocios.IsCnpj(txtCnpj.Text);
                }
            }
        }

        DataTable dadosTabela;

        public void PesquisarCliente()
        {
            try
            {
                if (RBCnpj.Checked == true)
                {
                    txtCnpj.Mask = "00-000-000/0000-00";
                    lblDescricao.Text = "CNPJ:";
                    txtCnpj.Focus();

                    tipo = 1;
                }
                else if (rbCpf.Checked == true)
                {
                    txtCnpj.Mask = "000-000-000-00";
                    lblDescricao.Text = "CPF:";
                    txtCnpj.Focus();

                    tipo = 2;
                }
                else
                {
                    txtCnpj.Mask = "(00)0000-000-00";
                    lblDescricao.Text = "TEL:";
                    txtCnpj.Focus();

                    tipo = 3;
                }

                valorCpf = txtCnpj.Text;

                valorCpf = valorCpf.Replace(" ", "");
                valorCpf = valorCpf.Replace(",", "");
                valorCpf = valorCpf.Replace("-", "");
                valorCpf = valorCpf.Replace(".", "");
                valorCpf = valorCpf.Replace("/", "");

                if (ValidarDocumento() == false)
                {
                    MessageBox.Show("Por Favor Informe um Numero de Documento Válido.", "Documento Informado é Inválido", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                    txtCnpj.Focus();
                    txtCnpj.SelectAll();
                }
                else if (valorCpf.Trim().Equals(""))
                {
                    if (tipo == 1)
                    {
                        MessageBox.Show("Por Favor Informe um Numero de Documento CNPJ Válido ", "Campo CNPJ não Pode ser Nulo ou Vázio.", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    else if (tipo == 2)
                    {
                        MessageBox.Show("Por Favor Informe um Numero de Documento CPF Válido ", "Campo CPF não Pode ser Nulo ou Vázio.", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    else
                    {
                        MessageBox.Show("Por Favor Informe um Numero de Telefone Desejado ", "Campo Telefone não Pode ser Nulo ou Vázio.", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }

                    txtCnpj.Focus();
                    txtCnpj.SelectAll();
                }
                else
                {
                    dadosTabela = new DataTable();

                    clienteRegraNegocios = new ClienteRegraNegocios();

                    if ((tipo == 1) || (tipo == 2))
                    {
                        dadosTabela = clienteRegraNegocios.PesquisarCpjCnpj(valorCpf.Trim());
                    }
                    else
                    {
                        dadosTabela = clienteRegraNegocios.PesquisarClienteTelefone(valorCpf.Replace("(", "").Replace(")", "").Replace(" ", "").Trim());
                    }

                    if (dadosTabela.Rows.Count > 0)
                    {
                        idCliente = Convert.ToInt32(dadosTabela.Rows[0]["CLIENTE_ID"].ToString().Trim());

                        if (tipo == 3)
                        {
                            txtCnpj.Text = dadosTabela.Rows[0]["TELEFONE3"].ToString().Trim();
                        }
                        else
                        {
                            txtCnpj.Text = dadosTabela.Rows[0]["CPF_CNPJ"].ToString().Trim();
                        }

                        txtEmail.Text = dadosTabela.Rows[0]["EMAIL"].ToString().Trim();
                        txtNome.Text = dadosTabela.Rows[0]["NOME"].ToString().Trim();

                        btnCpfCliente.Focus();
                    }
                    else
                    {
                        if (MessageBox.Show("Cliente não Cadastrado!!!\n\nDeseja Realizar um Novo Cadastro de cliente???", "Cliente não Localizado na Base de Dados", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                        {
                            frmCadCliente frmCadCliente = new frmCadCliente(valorCpf, idCliente, tipo, this);
                            frmCadCliente.ShowDialog();
                        }
                        else
                        {
                            this.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void SalvarCliente()
        {
            try
            {
                valorCpf = txtCnpj.Text;

                valorCpf = valorCpf.Replace(" ", "");
                valorCpf = valorCpf.Replace(",", "");
                valorCpf = valorCpf.Replace("-", "");
                valorCpf = valorCpf.Replace(".", "");

                if (ValidarDocumento() == false)
                {
                    MessageBox.Show("Por Favor Informe um Numero de Documento Válido.", "Documento Informado é Inválido", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                    txtCnpj.Focus();
                    txtCnpj.SelectAll();
                }
                else if (valorCpf.Trim().Equals(""))
                {
                    if (tipo == 1)
                    {
                        MessageBox.Show("Por Favor Informe um Numero de Documento CNPJ Válido ", "Campo CNPJ não Pode ser Nulo ou Vázio.", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    else if (tipo == 2)
                    {
                        MessageBox.Show("Por Favor Informe um Numero de Documento CPF Válido ", "Campo CPF não Pode ser Nulo ou Vázio.", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    else
                    {
                        MessageBox.Show("Por Favor Informe um Numero de Telefone Desejado ", "Campo Telefone não Pode ser Nulo ou Vázio.", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }

                    txtCnpj.Focus();
                    txtCnpj.SelectAll();
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void PreencherCampos()
        {
            if (RBCnpj.Checked == true)
            {
                txtCnpj.Mask = "00-000-000/0000-00";
                lblDescricao.Text = "CNPJ:";
                txtCnpj.Focus();

                tipo = 1;
            }
            else if (rbCpf.Checked == true)
            {
                txtCnpj.Mask = "000-000-000-00";
                lblDescricao.Text = "CPF:";
                txtCnpj.Focus();

                tipo = 2;
            }
            else
            {
                txtCnpj.Mask = "(00)0000-000-00";
                lblDescricao.Text = "TEL:";
                txtCnpj.Focus();

                tipo = 3;
            }

            txtCnpj.Text = valorCpf;
            txtNome.Text = nome;
            txtEmail.Text = email;

            PesquisarCliente();
        }
    }
}
