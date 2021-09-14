using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OBJETO_TRANSFERENCIA;
using REGRA_NEGOCIOS;

namespace SAT
{
    public partial class frmConfiguracoes : Form
    {
        public frmConfiguracoes()
        {
            InitializeComponent();
        }

        #region CLASSES E OBJETOS

        ParametroC parametroC = new ParametroC();
        ParametroRegraNegocios parametroRegraNegocios = new ParametroRegraNegocios();

        #endregion

        private void btnPesquiarCep_Click(object sender, EventArgs e)
        {
            frmBuscarCep fBuscarCep = new frmBuscarCep();
            fBuscarCep.ShowDialog();
        }

        private void frmConfiguracoes_Load(object sender, EventArgs e)
        {
            Listar();
        }

        public void Listar()
        {
            try
            {
                parametroRegraNegocios = new ParametroRegraNegocios();
                DataTable dadosTabelaParametro = new DataTable();

                dadosTabelaParametro = parametroRegraNegocios.Listar();

                if (dadosTabelaParametro.Rows.Count > 0)
                {
                    btnManter.Text = "Alterar";

                    lblId.Text = dadosTabelaParametro.Rows[0]["ID_PARAMETRO"].ToString();
                    txtRazaoSocial.Text = dadosTabelaParametro.Rows[0]["RAZAO_SOCIAL"].ToString();
                    txtNomeFantasia.Text = dadosTabelaParametro.Rows[0]["NOME_FANTASIA"].ToString();
                    txtendereco.Text = dadosTabelaParametro.Rows[0]["ENDERECO_EMPRESA"].ToString();
                    txtCidade.Text = dadosTabelaParametro.Rows[0]["CIDADE"].ToString();
                    txtUf.Text = dadosTabelaParametro.Rows[0]["UF"].ToString();
                    txtBairro.Text = dadosTabelaParametro.Rows[0]["BAIRRO"].ToString();
                    txtNumero.Text = dadosTabelaParametro.Rows[0]["NUMERO"].ToString();
                    //txtComplemento.Text = dadosTabelaParametro.Rows[0][""].ToString();
                    txtCep.Text = dadosTabelaParametro.Rows[0]["CEP"].ToString();
                    txtCnpj.Text = dadosTabelaParametro.Rows[0]["CNPJ"].ToString();
                    txtIe.Text = dadosTabelaParametro.Rows[0]["IE"].ToString();
                    txtIm.Text = dadosTabelaParametro.Rows[0]["IM"].ToString();
                    txtTel.Text = dadosTabelaParametro.Rows[0]["TELEFONE"].ToString();
                    //txtemail.Text = dadosTabelaParametro.Rows[0][""].ToString();

                    if (dadosTabelaParametro.Rows[0]["CRT"].ToString().Trim().Equals("1"))
                    {
                        cbCrt.Text = "1 - SIMPLES NASCIONAL";
                    }
                    else if (dadosTabelaParametro.Rows[0]["CRT"].ToString().Trim().Equals("2"))
                    {
                        cbCrt.Text = "2 - SIMPLES NACIONAL, EXCESSO SUBLIMETE RECEITA BRUTA";
                    }
                    else
                    {
                        cbCrt.Text = "3 - REGIME SIMPLES";
                    }
                }
                else
                {
                    btnManter.Text = "Cadastrar";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção");
            }
        }

        private void btnManter_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Realmente Deseja Alterar Dados do Establecimento?", "Conformação de Alteração", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                Salvar();
            }
        }

        public void Salvar()
        {
            try
            {
                if (Convert.ToInt32(lblId.Text) <= 0)
                {
                    MessageBox.Show("Código do Parametro do Estabelecimento não Pode ser Zero ou Nulo.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else if (txtRazaoSocial.Text.Trim().Equals(""))
                {
                    MessageBox.Show("Razão Social do Estabelecimento não Pode ser Zero ou Nulo.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                    txtRazaoSocial.Focus();
                    txtRazaoSocial.SelectAll();
                }
                else if (txtendereco.Text.Trim().Equals(""))
                {
                    MessageBox.Show("Endereço do Estabelecimento não Pode ser Zero ou Nulo.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                    txtendereco.Focus();
                    txtendereco.SelectAll();
                }
                else if (txtCidade.Text.Trim().Equals(""))
                {
                    MessageBox.Show("Cidade do Estabelecimento não Pode ser Zero ou Nulo.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                    txtCidade.Focus();
                    txtCidade.SelectAll();
                }
                else if (txtUf.Text.Trim().Equals(""))
                {
                    MessageBox.Show("U.F do Estabelecimento não Pode ser Zero ou Nulo.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                    txtUf.Focus();
                    txtUf.SelectAll();
                }
                else if (txtBairro.Text.Trim().Equals(""))
                {
                    MessageBox.Show("Bairro do Estabelecimento não Pode ser Zero ou Nulo.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                    txtBairro.Focus();
                    txtBairro.SelectAll();
                }
                else if (txtNumero.Text.Trim().Equals(""))
                {
                    MessageBox.Show("Numero do Estabelecimento não Pode ser Zero ou Nulo.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                    txtNumero.Focus();
                    txtNumero.SelectAll();
                }
                else if (txtCep.Text.Trim().Equals(""))
                {
                    MessageBox.Show("CEP do Estabelecimento não Pode ser Zero ou Nulo.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                    txtCep.Focus();
                    txtCep.SelectAll();
                }
                else if (txtCnpj.Text.Trim().Equals(""))
                {
                    MessageBox.Show("CNPJ do Estabelecimento não Pode ser Zero ou Nulo.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                    txtCnpj.Focus();
                    txtCnpj.SelectAll();
                }
                else if (txtIe.Text.Trim().Equals(""))
                {
                    MessageBox.Show("I.E do Estabelecimento não Pode ser Zero ou Nulo.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                    txtIe.Focus();
                    txtIe.SelectAll();
                }
                else if (cbCrt.Text.Trim().Equals(""))
                {
                    MessageBox.Show("CRT - Código de Regime Tributário do Estabelecimento não Pode ser Zero ou Nulo.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                    cbCrt.Focus();
                    cbCrt.SelectAll();
                }
                else if (txtTel.Text.Trim().Equals(""))
                {
                    MessageBox.Show("Telefone do Estabelecimento não Pode ser Zero ou Nulo.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                    txtTel.Focus();
                    txtTel.SelectAll();
                }
                else
                {
                    parametroRegraNegocios = new ParametroRegraNegocios();

                    parametroC.idParametro = Convert.ToInt32(lblId.Text);
                    parametroC.razaoSocial = txtRazaoSocial.Text.Trim();
                    parametroC.nomeFantasia = txtNomeFantasia.Text.Trim();
                    parametroC.endereco = txtendereco.Text.Trim();
                    parametroC.numero = txtNumero.Text.Trim();
                    parametroC.bairro = txtBairro.Text.Trim();
                    parametroC.cep = txtCep.Text.Trim();
                    parametroC.cidade = txtCidade.Text.Trim();
                    parametroC.uf = txtUf.Text.Trim();
                    parametroC.telefone = txtTel.Text.Trim();
                    parametroC.ie = txtIe.Text.Trim();
                    parametroC.cnpj = txtCnpj.Text.Trim();
                    parametroC.crt = cbCrt.Text.Substring(0, 1).Trim();
                    parametroC.im = txtIm.Text.Trim();

                    try
                    {
                        int idRet = parametroRegraNegocios.SalvarServicosEndereco(parametroC);

                        MessageBox.Show("Dados Cliente foi Salvo com Sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch
                    {
                        MessageBox.Show("Erro ao CAdastrar Dados Cliente..", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
