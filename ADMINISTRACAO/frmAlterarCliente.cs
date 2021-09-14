using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using REGRA_NEGOCIOS;
using OBJETO_TRANSFERENCIA;
using System.Net;
using Newtonsoft.Json;

namespace ADMINISTRACAO
{
    public partial class frmAlterarCliente : Form
    {
        frmPrincipal frmPrincipal;

        public frmAlterarCliente(int idCliente, frmPrincipal fPrincipal)
        {
            InitializeComponent();

            this.frmPrincipal = fPrincipal;

            this.idCliente = idCliente;
        }

        #region VARIAVEIS

        public int idCliente = 0;
        public bool status;
        public bool tipoPEssoa;
        public string cnpj = "";
        public string codBloq = "";

        #endregion

        ClienteRegraNegocios clienteRegraNegocios;
        FILTRAR filtrar;
        ClienteC cliente;
        FormatarInscEstadual formatarIE;

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAlterarProduto_Load(object sender, EventArgs e)
        {
            LoadTela();
        }

        public void PesquisarClienteId()
        {
            try
            {
                DataTable dadosTabela = new DataTable();
                clienteRegraNegocios = new ClienteRegraNegocios();

                dadosTabela = clienteRegraNegocios.PesquisarClienteId(idCliente);

                if (dadosTabela.Rows.Count > 0)
                {
                    lblDtCadastro.Text = dadosTabela.Rows[0]["DT_CADASTRO"].ToString().Trim();

                    cnpj = dadosTabela.Rows[0]["CPF_CNPJ"].ToString().Replace("-", "").Replace(",", "").Replace("/", "").Replace(".", "").Trim();

                    txtCodigo.Text = dadosTabela.Rows[0]["CLIENTE_ID"].ToString().Trim();
                    txtNome.Text = dadosTabela.Rows[0]["NOME"].ToString().Trim();
                    txtApelido.Text = dadosTabela.Rows[0]["APELIDO_FANTAZIA"].ToString().Trim();

                    txtDtNasc.Text = dadosTabela.Rows[0]["DT_NASC"].ToString().Trim();
                    lblDtCadastro.Text = Convert.ToDateTime(dadosTabela.Rows[0]["DT_CADASTRO"].ToString().Trim()).ToString("dd/MM/yyyy");

                    txtLimite.Text = dadosTabela.Rows[0]["LIMITE"].ToString().Trim();
                    txtGastos.Text = dadosTabela.Rows[0]["GASTO"].ToString().Trim();
                    cbBloq.Text = dadosTabela.Rows[0]["BLOQ"].ToString().Trim();

                    txtTelefone1.Text = dadosTabela.Rows[0]["TELEFONE"].ToString().Trim();
                    txtTelefone2.Text = dadosTabela.Rows[0]["TELEFONE2"].ToString().Trim();
                    txtCelular.Text = dadosTabela.Rows[0]["TELEFONE3"].ToString().Trim();
                    txtEmail.Text = dadosTabela.Rows[0]["EMAIL"].ToString().Trim();

                    txtCep.Text = dadosTabela.Rows[0]["CEP"].ToString().Trim();
                    txtEndereco.Text = dadosTabela.Rows[0]["LOGRADOURO"].ToString().Trim();
                    txtNumero.Text = dadosTabela.Rows[0]["NUM"].ToString().Trim();
                    txtBairro.Text = dadosTabela.Rows[0]["BAIRO"].ToString().Trim();
                    txtCidade.Text = dadosTabela.Rows[0]["CIDADE"].ToString().Trim();
                    cbUF.Text = dadosTabela.Rows[0]["UF"].ToString().Trim();
                    txtComplemento.Text = dadosTabela.Rows[0]["COMPLEMENTO"].ToString().Trim();
                    txtObs.Text = dadosTabela.Rows[0]["OBSERVACAO"].ToString().Trim();

                    status = Convert.ToBoolean(dadosTabela.Rows[0]["STATUS"].ToString().Trim());

                    if (cnpj.Length == 11)
                    {
                        rbPessoaFisica.Checked = true;

                        btnPesquisarPJ.Enabled = false;

                        lblNome.Text = "*Nome";
                        lblApelidoFantasia.Text = "*Apelido";
                        lblRgIe.Text = "*RG";
                        lblDatas.Text = "*Data Aniversário";

                        txtCpf_Cnpj.Mask = "000,000,000-00";
                        txtRg_Ie.Mask = "00,000,000-0";

                        btnIsento.Enabled = false;

                        rbPessoaFisica.Checked = true;
                    }
                    else
                    {
                        rbPessoaFisica.Checked = false;

                        btnPesquisarPJ.Enabled = true;

                        lblNome.Text = "*Razão Social";
                        lblApelidoFantasia.Text = "*Nome Fantasia";
                        lblRgIe.Text = "*I.E";
                        lblDatas.Text = "*Data Fundação";

                        txtCpf_Cnpj.Mask = "00,000,000/0000-00";

                        btnIsento.Enabled = true;

                        rbPessoaJuiridica.Checked = true;

                        FormatarInscricaoEstadual();
                    }

                    txtCpf_Cnpj.Text = cnpj;
                    txtRg_Ie.Text = dadosTabela.Rows[0]["RG_INSC_EST"].ToString().Trim();
                }
                else
                {
                    MessageBox.Show("Cliente Não Localizado na Base de Dados.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void TravarComboBox(ref ComboBox cb)
        {
            string data = codBloq;

            cb.DropDownStyle = ComboBoxStyle.DropDownList;
            cb.Items.Clear();
            cb.Items.Add(data);
            cb.SelectedIndex = 0;
        }

        public void FormatarInscricaoEstadual()
        {
            try
            {
                formatarIE = new FormatarInscEstadual();

                string format = formatarIE.FormatarIe(cbUF.Text.Trim());

                txtRg_Ie.Mask = format.Trim();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtCpf_Cnpj_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

            }
        }

        private void btnIsento_Click(object sender, EventArgs e)
        {
            if (txtRg_Ie.Text.Trim().Replace("-", "").Replace(",", "").Replace(".", "").Trim().Equals(""))
            {
                txtRg_Ie.Mask = "";
                txtRg_Ie.Text = "ISENTO";
            }
            else
            {
                txtRg_Ie.Mask = "0000,0000,0000";
            }
        }

        public void BuscaCEP()
        {
            try
            {
                filtrar = new FILTRAR();

                if (txtCep.Text.Trim().Replace("-", "").Replace(" ", "").Equals(""))
                {
                    MessageBox.Show("Informe CEP Desejado", "Buscar CEP", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCep.Focus();
                }
                else
                {
                    string xml = "http://cep.republicavirtual.com.br/web_cep.php?cep=@cep&formato=xml".Replace("@cep", txtCep.Text.Trim());

                    int resultado = 0;

                    DataSet ds = new DataSet();

                    ds.ReadXml(xml);
                    DataTable dataTabela = new DataTable();
                    dataTabela = ds.Tables[0];

                    resultado = Convert.ToInt32(dataTabela.Rows[0][0].ToString().Trim());

                    if (resultado > 0)
                    {
                        txtEndereco.Text = filtrar.RemoverAcentos((dataTabela.Rows[0][5].ToString().Trim() + ", " + dataTabela.Rows[0][6].ToString().Trim()));
                        txtBairro.Text = filtrar.RemoverAcentos(dataTabela.Rows[0][4].ToString().Trim());
                        txtCidade.Text = filtrar.RemoverAcentos(dataTabela.Rows[0][3].ToString().Trim().ToUpper());
                        cbUF.Text = filtrar.RemoverAcentos(dataTabela.Rows[0][2].ToString().Trim().ToUpper());

                        txtNumero.Focus();
                        txtNumero.SelectAll();
                    }
                    else
                    {
                        MessageBox.Show("CEP: " + txtCep.Text.Trim() + " não foi Encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Question);
                        txtCep.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro");
            }
        }

        private void btnPesquisarCep_Click(object sender, EventArgs e)
        {
            BuscaCEP();
        }

        private void rbPessoaFisica_CheckedChanged(object sender, EventArgs e)
        {
            btnPesquisarPJ.Enabled = false;
            lblNome.Text = "*Nome";
            lblApelidoFantasia.Text = "*Apelido";
            lblCpfCnpj.Text = "*CPF";
            lblRgIe.Text = "*RG";
            lblDatas.Text = "*Data Aniversário";

            txtCpf_Cnpj.Mask = "000,000,000-00";
            txtRg_Ie.Mask = "00,000,000-0";

            btnIsento.Enabled = false;

            txtNome.Focus();
            txtNome.SelectAll();
        }

        private void rbPessoaJuiridica_CheckedChanged(object sender, EventArgs e)
        {
            btnPesquisarPJ.Enabled = true;
            lblNome.Text = "*Razão Social";
            lblCpfCnpj.Text = "*CNPJ";
            lblApelidoFantasia.Text = "*Nome Fantasia";
            lblRgIe.Text = "*I.E";
            lblDatas.Text = "*Data Fundação";

            txtCpf_Cnpj.Mask = "00,000,000/0000-00";
            txtRg_Ie.Mask = "0000,0000,0000";

            btnIsento.Enabled = true;

            txtNome.Focus();
            txtNome.SelectAll();
        }

        public void LoadTela()
        {
            LimparCampos();

            PesquisarClienteId();

            rbPessoaFisica.Enabled = false;
            rbPessoaJuiridica.Enabled = false;
        }

        public void LimparCampos()
        {
            lblDtCadastro.Text = DateTime.Now.ToString("dd/MM/yyyy");

            btnPesquisarPJ.Enabled = false;
            rbPessoaFisica.Checked = true;

            txtCodigo.Text = "0";
            txtNome.Text = "";
            txtApelido.Text = "";
            txtCpf_Cnpj.Text = "";
            txtRg_Ie.Text = "";
            txtDtNasc.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtLimite.Text = "0,00";
            txtGastos.Text = "0,00";
            cbBloq.Text = null;
            txtTelefone1.Text = "";
            txtTelefone2.Text = "";
            txtCelular.Text = "";
            txtEmail.Text = "";

            txtCep.Text = "";
            txtEndereco.Text = "";
            txtNumero.Text = "";
            txtBairro.Text = "";
            txtCidade.Text = "";
            cbUF.Text = "";
            txtComplemento.Text = "";
            txtObs.Text = "";

            cbStatus.Checked = true;

            txtNome.Focus();
            txtNome.SelectAll();

            if (rbPessoaFisica.Checked == true)
            {
                btnPesquisarPJ.Enabled = false;
                lblNome.Text = "*Nome";
                lblCpfCnpj.Text = "*CPF";
                lblApelidoFantasia.Text = "*Apelido";
                lblRgIe.Text = "*RG";
                lblDatas.Text = "*Data Aniversário";

                btnIsento.Enabled = false;

                txtNome.Focus();
                txtNome.SelectAll();
            }
            else
            {
                btnPesquisarPJ.Enabled = true;
                lblNome.Text = "*Razão Social";
                lblCpfCnpj.Text = "*CNPJ";
                lblApelidoFantasia.Text = "*Nome Fantasia";
                lblRgIe.Text = "*I.E";
                lblDatas.Text = "*Data Fundação";

                txtCpf_Cnpj.Mask = "00,000,000/0000-00";
                txtRg_Ie.Mask = "0000,0000,0000";

                txtCpf_Cnpj.Mask = "000,000,000-00";
                txtRg_Ie.Mask = "00,000,000-0";

                btnIsento.Enabled = true;
            }
        }

        public void Salvar()
        {
            try
            {
                if (txtNome.Text.Trim().Equals(""))
                {
                    MessageBox.Show("Campo Nome não Pode ser Nulo ou Vázio.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                    txtNome.Focus();
                    txtNome.SelectAll();
                }
                else if (txtApelido.Text.Trim().Equals(""))
                {
                    MessageBox.Show("Apelido/Nome Fantasia Nome não Pode ser Nulo ou Vázio.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                    txtApelido.Focus();
                    txtApelido.SelectAll();
                }
                else if (txtCpf_Cnpj.Text.Replace("-", "").Replace(",", "").Replace(".", "").Replace("/", "").Trim().Equals(""))
                {
                    MessageBox.Show("CPF/CNPJ não Pode ser Nulo ou Vázio.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                    txtCpf_Cnpj.Focus();
                    txtCpf_Cnpj.SelectAll();
                }
                else if (txtRg_Ie.Text.Replace(",", "").Replace(".", "").Trim().Equals(""))
                {
                    MessageBox.Show("RG/I.E não Pode ser Nulo ou Vázio.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                    txtRg_Ie.Focus();
                    txtRg_Ie.SelectAll();
                }
                else if (Convert.ToDecimal(txtLimite.Text.Trim()) <= 0)
                {
                    MessageBox.Show("Campo Valor de Limite não Pode ser Nulo ou Zero.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                    txtLimite.Focus();
                    txtLimite.SelectAll();
                }
                else if (cbBloq.Text.Trim().Equals(""))
                {
                    MessageBox.Show("Campo Bloqueio não Pode ser Nulo ou Zero.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                    cbBloq.Focus();
                    cbBloq.SelectAll();
                }
                else if (txtTelefone1.Text.Trim().Equals(""))
                {
                    MessageBox.Show("Campo Tefefone Um não Pode ser Nulo ou Zero.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                    txtTelefone1.Focus();
                    txtTelefone1.SelectAll();
                }
                else if (txtCep.Text.Trim().Equals(""))
                {
                    MessageBox.Show("Campo CEP não Pode ser Nulo ou Zero.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                    txtCep.Focus();
                    txtCep.SelectAll();
                }
                else if (txtEndereco.Text.Trim().Equals(""))
                {
                    MessageBox.Show("Campo Logradouro não Pode ser Nulo ou Zero.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                    txtEndereco.Focus();
                    txtEndereco.SelectAll();
                }
                else if (txtNumero.Text.Trim().Equals(""))
                {
                    MessageBox.Show("Campo Numero não Pode ser Nulo ou Zero.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                    txtNumero.Focus();
                    txtNumero.SelectAll();
                }
                else if (txtBairro.Text.Trim().Equals(""))
                {
                    MessageBox.Show("Campo Bairro não Pode ser Nulo ou Zero.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                    txtBairro.Focus();
                    txtBairro.SelectAll();
                }
                else if (txtCidade.Text.Trim().Equals(""))
                {
                    MessageBox.Show("Campo Cidade não Pode ser Nulo ou Zero.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                    txtCidade.Focus();
                    txtCidade.SelectAll();
                }
                else if (cbUF.Text.Trim().Equals(""))
                {
                    MessageBox.Show("Campo U.F não Pode ser Nulo ou Zero.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                    cbUF.Focus();
                    cbUF.SelectAll();
                }
                else
                {
                    cliente = new ClienteC();

                    cliente.idCliente = Convert.ToInt32(txtCodigo.Text);
                    cliente.nome = txtNome.Text.Trim();
                    cliente.dataCadastro = lblDtCadastro.Text.Trim();
                    cliente.apelidoFantasia = txtApelido.Text.Trim();
                    cliente.cpfCnpj = txtCpf_Cnpj.Text.Trim();
                    cliente.rgIe = txtRg_Ie.Text.Trim();
                    cliente.datas = Convert.ToDateTime(txtDtNasc.Text);
                    cliente.limite = Convert.ToDecimal(txtLimite.Text);
                    cliente.gasto = Convert.ToDecimal(txtGastos.Text);
                    cliente.bloq = cbBloq.Text.Trim();
                    cliente.email = txtEmail.Text.Trim();
                    cliente.status = Convert.ToBoolean(cbStatus.Checked);
                    cliente.observacao = txtObs.Text.Trim();

                    cliente.Telefone = new Telefone();

                    cliente.Telefone.telefone1 = txtTelefone1.Text.Trim();
                    cliente.Telefone.telefone2 = txtTelefone2.Text.Trim();
                    cliente.Telefone.celular = txtCelular.Text.Trim();

                    cliente.Endereco = new Endereco();

                    cliente.Endereco.cep = txtCep.Text.Trim();
                    cliente.Endereco.idPessoa = Convert.ToInt32(txtCodigo.Text);
                    cliente.Endereco.logradouro = txtEndereco.Text.Trim();
                    cliente.Endereco.numero = txtNumero.Text.Trim();
                    cliente.Endereco.bairro = txtBairro.Text.Trim();
                    cliente.Endereco.cidade = txtCidade.Text.Trim();
                    cliente.Endereco.uf = cbUF.Text.Trim();
                    cliente.Endereco.complemento = txtComplemento.Text.Trim();

                    try
                    {
                        clienteRegraNegocios = new ClienteRegraNegocios();

                        int idRet = Convert.ToInt32(clienteRegraNegocios.Salvar(cliente, 2));

                        MessageBox.Show("Dados do Cliente foi Salvo com Sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch
                    {
                        MessageBox.Show("Erro ao Salvar um Novo Cliente", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void Moeda(ref TextBox txt)
        {
            string n = string.Empty;
            decimal v = 0;

            try
            {
                n = txt.Text.Replace(",", "").Replace(".", "");

                if (n.Equals(""))
                    n = "";
                n = n.PadLeft(5, '0');
                if (n.Length > 5 & n.Substring(0, 1) == "0")
                    n = n.Substring(1, n.Length - 1);
                v = Convert.ToDecimal(n) / 100;
                txt.Text = string.Format("{0:N2}", v);
                txt.SelectionStart = txt.Text.Length;
            }
            catch (Exception ex)
            {
                txt.Text = "";
                txt.Focus();
                MessageBox.Show(ex.Message + " Campo Aceita Somente Valores", "Registro do Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtLimite_TextChanged(object sender, EventArgs e)
        {
            Moeda(ref txtLimite);
        }

        private void cbStatus_CheckedChanged(object sender, EventArgs e)
        {
            if (cbStatus.Checked == true)
            {
                cbStatus.Text = "ATIVO";
            }
            else
            {
                cbStatus.Text = "INATIVO";
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Realmente Deseja Alterar Dados Cliente Selecionado?.", "Confirmação de Alteração", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                Salvar();
            }
        }

        private void btnPesquisarPJ_Click(object sender, EventArgs e)
        {
            ConsultaCNPJ();
        }

        private void ConsultaCNPJ()
        {
            try
            {
                if (txtCpf_Cnpj.Text.Trim().Equals(""))
                {
                    MessageBox.Show("Campo C.N.P.J nao Pode ser nulo ou Vazio.", "Atençao", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else
                {
                    filtrar = new FILTRAR();

                    string cnpj = filtrar.RemoverAcentos(txtCpf_Cnpj.Text.Trim().Replace(".", "").Replace("-", "").Replace("/", "")).Trim();

                    string jsonText = "https://www.receitaws.com.br/v1/cnpj/@cnpj".Replace("@cnpj", cnpj.Trim());

                    var json = SendRequest(jsonText);

                    if (json != null)
                    {
                        var myObject = JsonConvert.DeserializeObject<EMPRESA>(json);

                        txtDtNasc.Text = Convert.ToDateTime(myObject.abertura.Trim()).ToString("dd/MM/yyyy");
                        txtNome.Text = filtrar.RemoverAcentos(myObject.nome.Trim());
                        txtEmail.Text = myObject.email.Trim();
                        txtEndereco.Text = filtrar.RemoverAcentos(myObject.logradouro.Trim());
                        txtComplemento.Text = filtrar.RemoverAcentos(myObject.complemento.Trim());
                        txtCidade.Text = filtrar.RemoverAcentos(myObject.municipio.Trim());
                        txtBairro.Text = filtrar.RemoverAcentos(myObject.bairro.Trim());
                        txtNumero.Text = filtrar.RemoverAcentos(myObject.numero.Trim());
                        txtCep.Text = filtrar.RemoverAcentos(myObject.cep.Trim());
                        cbUF.Text = filtrar.RemoverAcentos(myObject.uf.Trim());

                        txtApelido.Text = filtrar.RemoverAcentos(myObject.fantasia.Trim());
                        txtTelefone1.Text = myObject.telefone.Trim();

                        FormatarInscricaoEstadual();
                    }
                    else
                    {
                        MessageBox.Show("PEsquisa CNPJ: " + txtCpf_Cnpj.Text.Trim() + ", não Foi Localizado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private string SendRequest(string url)
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    return client.DownloadString(new Uri(url));
                }
            }
            catch (WebException ex)
            {
                throw new Exception("Error while receiving data from the server:\n" + ex.Message);
            }
        }
    }
}
