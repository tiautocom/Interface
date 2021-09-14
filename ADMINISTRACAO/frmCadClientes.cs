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
    public partial class frmCadClientes : Form
    {
        frmPrincipal frmPrincipal;

        public frmCadClientes(frmPrincipal fPrincipal)
        {
            InitializeComponent();

            this.frmPrincipal = fPrincipal;

            this.gdvCliente.AutoGenerateColumns = false;
        }

        #region CLASSES E OBJETOS

        ClienteRegraNegocios clienteRegraNegocios;
        FormatarInscEstadual formatarIE;
        ClienteC cliente;
        FILTRAR filtrar;
        ValidarRegraNegocios validarRegraNegocios;

        #endregion

        #region VARIAVEIS

        public int idCliente = 0;

        public string atividade = "";

        public string cnpj = "";

        public bool ret;

        #endregion

        private void frmCadClientes_Load(object sender, EventArgs e)
        {
            LoadTela();
        }

        public void ListarClientes()
        {
            try
            {
                DataTable dadosTabela = new DataTable();

                clienteRegraNegocios = new ClienteRegraNegocios();

                dadosTabela = clienteRegraNegocios.PesquisarCliente(txtPesquisar.Text.Trim());

                if (dadosTabela.Rows.Count > 0)
                {
                    gdvCliente.DataSource = null;
                    gdvCliente.DataSource = dadosTabela;
                }
                else
                {
                    gdvCliente.DataSource = null;
                }

                lblQtde.Text = gdvCliente.Rows.Count.ToString().PadLeft(5, '0').Trim();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void LoadTela()
        {
            lblDtCadastro.Text = DateTime.Now.ToString("dd/MM/yyyy");
            LimparCampos();
            LimparCamposDetalhado();
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

        private void btnNovo_Click(object sender, EventArgs e)
        {
            LimparCampos();

            LimparCamposDetalhado();
        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPage == tabPListar)
            {
                ListarClientes();
            }

            if (e.TabPage == tabPCad)
            {
                txtNome.Focus();
                txtNome.SelectAll();
            }

            if (e.TabPage == tabDetalhado)
            {

            }
        }

        private void gdvCliente_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (gdvCliente.Columns[e.ColumnIndex].Name.Trim().Equals("colSel"))
                {
                    idCliente = Convert.ToInt32(gdvCliente.Rows[e.RowIndex].Cells["colIdCliente"].Value.ToString());

                    frmAlterarCliente frmAlterarProduto = new frmAlterarCliente(idCliente, frmPrincipal);
                    frmAlterarProduto.ShowDialog();
                }

                if (gdvCliente.Columns[e.ColumnIndex].Name.Trim().Equals("colDet"))
                {
                    cnpj = gdvCliente.Rows[e.RowIndex].Cells["colCpfCnpj"].Value.ToString().Replace(".", "").Replace("-", "").Replace("/", "").Trim();

                    if (cnpj.Length == 14)
                    {
                        if (MessageBox.Show("Confirmação de Consulta do CNPJ da Empresa:\n" + gdvCliente.Rows[e.RowIndex].Cells["colNome"].Value.ToString().Trim() + "?.", "Conformação de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                        {
                            txtCpf_Cnpj.Mask = "00,000,000/0000-00";

                            txtCpf_Cnpj.Text = cnpj;

                            ConsultaCNPJDetalhado();

                            this.tabControl1.SelectedTab = tabDetalhado;

                            txtCpf_Cnpj.Text = "";
                            txtCpf_Cnpj.Mask = "000,000,000,000-00";
                        }
                    }
                    else
                    {
                        MessageBox.Show("Operação de Consulta está Disponivel Somente para Tipo de Pessoa Juridica.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Salvar();
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
                else if (ValidarDocumentos() == false)
                {

                }
                else if (txtRg_Ie.Text.Replace(",", "").Replace(".", "").Replace("/", "").Trim().Equals(""))
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

                        int idRet = Convert.ToInt32(clienteRegraNegocios.Salvar(cliente, 1));

                        MessageBox.Show("Novo Cliente Salvo com Sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        LimparCampos();

                        this.tabControl1.SelectedTab = tabPListar;
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

        private void txtNome_TextChanged(object sender, EventArgs e)
        {
            if (rbPessoaFisica.Checked == true)
            {
                txtApelido.Text = txtNome.Text.Trim();
            }
        }

        private void btnPesquisarCep_Click(object sender, EventArgs e)
        {
            BuscaCEP();
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

                        try
                        {
                            txtAtividades.Text = filtrar.RemoverAcentos(myObject.code.Trim());
                        }
                        catch
                        {
                            txtAtividades.Text = "";
                        }

                        txtMatrizFilial.Text = filtrar.RemoverAcentos(myObject.tipo.Trim());
                        txtDataSituacaoCadastral.Text = filtrar.RemoverAcentos(myObject.data_situacao.Trim());
                        txtDataAbertura.Text = txtDtNasc.Text = Convert.ToDateTime(myObject.abertura.Trim()).ToString("dd/MM/yyyy");
                        txtRazao.Text = txtNome.Text = filtrar.RemoverAcentos(myObject.nome.Trim());
                        txtEmail.Text = txtEmailDois.Text = myObject.email.Trim();
                        txtLogradourodois.Text = txtEndereco.Text = filtrar.RemoverAcentos(myObject.logradouro.Trim());
                        txtComplementoDois.Text = txtComplemento.Text = filtrar.RemoverAcentos(myObject.complemento.Trim());
                        txtCidadeDois.Text = txtCidade.Text = filtrar.RemoverAcentos(myObject.municipio.Trim());
                        txtBairroDois.Text = txtBairro.Text = filtrar.RemoverAcentos(myObject.bairro.Trim());
                        txtNumeroDois.Text = txtNumero.Text = filtrar.RemoverAcentos(myObject.numero.Trim());
                        txtCEPDois.Text = txtCep.Text = filtrar.RemoverAcentos(myObject.cep.Trim());
                        txtUFDois.Text = cbUF.Text = filtrar.RemoverAcentos(myObject.uf.Trim());
                        txtMotivoSituacaoCadastral.Text = filtrar.RemoverAcentos(myObject.motivo_situacao.Trim());
                        txtFantasia.Text = txtApelido.Text = filtrar.RemoverAcentos(myObject.fantasia.Trim());
                        txtTelefone.Text = txtTelefone1.Text = myObject.telefone.Trim();
                        txtPorte.Text = filtrar.RemoverAcentos(myObject.porte);
                        txtCapitalSocial.Text = myObject.capital_social.ToString();
                        lblStatus.Text = filtrar.RemoverAcentos(myObject.status);

                        txtSitacaoSimples.Text = filtrar.RemoverAcentos(myObject.situacao);
                        txtSituacao.Text = filtrar.RemoverAcentos(myObject.situacao_especial.Trim());
                        txtDataSituacaoEspecial.Text = filtrar.RemoverAcentos(myObject.data_situacao_especial.Trim());
                        txtNaturezaJuridica.Text = filtrar.RemoverAcentos(myObject.natureza_juridica.Trim());

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

        private void ConsultaCNPJDetalhado()
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

                        try
                        {
                            txtAtividades.Text = filtrar.RemoverAcentos(myObject.code.Trim());
                        }
                        catch
                        {
                            txtAtividades.Text = "";
                        }

                        txtMatrizFilial.Text = filtrar.RemoverAcentos(myObject.tipo.Trim());
                        txtDataSituacaoCadastral.Text = filtrar.RemoverAcentos(myObject.data_situacao.Trim());
                        txtDataAbertura.Text = Convert.ToDateTime(myObject.abertura.Trim()).ToString("dd/MM/yyyy");
                        txtRazao.Text = filtrar.RemoverAcentos(myObject.nome.Trim());
                        txtEmailDois.Text = myObject.email.Trim();
                        txtLogradourodois.Text = filtrar.RemoverAcentos(myObject.logradouro.Trim());
                        txtComplementoDois.Text = filtrar.RemoverAcentos(myObject.complemento.Trim());
                        txtCidadeDois.Text = filtrar.RemoverAcentos(myObject.municipio.Trim());
                        txtBairroDois.Text = filtrar.RemoverAcentos(myObject.bairro.Trim());
                        txtNumeroDois.Text = filtrar.RemoverAcentos(myObject.numero.Trim());
                        txtCEPDois.Text = filtrar.RemoverAcentos(myObject.cep.Trim());
                        txtUFDois.Text = filtrar.RemoverAcentos(myObject.uf.Trim());
                        txtMotivoSituacaoCadastral.Text = filtrar.RemoverAcentos(myObject.motivo_situacao.Trim());
                        txtFantasia.Text = filtrar.RemoverAcentos(myObject.fantasia.Trim());
                        txtTelefone.Text = myObject.telefone.Trim();
                        txtPorte.Text = filtrar.RemoverAcentos(myObject.porte);
                        txtCapitalSocial.Text = myObject.capital_social.ToString();
                        lblStatus.Text = filtrar.RemoverAcentos(myObject.status);

                        txtSitacaoSimples.Text = filtrar.RemoverAcentos(myObject.situacao);
                        txtSituacao.Text = filtrar.RemoverAcentos(myObject.situacao_especial.Trim());
                        txtDataSituacaoEspecial.Text = filtrar.RemoverAcentos(myObject.data_situacao_especial.Trim());
                        txtNaturezaJuridica.Text = filtrar.RemoverAcentos(myObject.natureza_juridica.Trim());
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

        public bool ValidarCnpj()
        {
            try
            {
                filtrar = new FILTRAR();

                string cnpj = filtrar.RemoverAcentos(txtCpf_Cnpj.Text);

                return TempRegraNegocios.IsCnpj(cnpj);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

                return false;
            }
        }

        public bool ValidarCpf()
        {
            try
            {
                filtrar = new FILTRAR();

                string cnpj = filtrar.RemoverAcentos(txtCpf_Cnpj.Text);

                return TempRegraNegocios.IsCpf(cnpj);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

                return false;
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

        private void txtCpf_Cnpj_KeyDown(object sender, KeyEventArgs e)
        {
            if (rbPessoaJuiridica.Checked == true)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnPesquisarPJ_Click(sender, e);
                }
            }
        }

        private void txtCapitalSocial_TextChanged(object sender, EventArgs e)
        {
            Moeda(ref txtCapitalSocial);
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

        private void txtPesquisar_TextChanged(object sender, EventArgs e)
        {
            ListarClientes();
        }

        public void LimparCamposDetalhado()
        {
            txtRazao.Text = "";
            txtFantasia.Text = "";
            txtLogradourodois.Text = "";
            txtComplementoDois.Text = "";
            txtCidadeDois.Text = "";
            txtBairroDois.Text = "";
            txtNumeroDois.Text = "";
            txtCapitalSocial.Text = "0,00";
            txtCEPDois.Text = "";
            lblStatus.Text = "...";
            txtUFDois.Text = "";
            txtSitacaoSimples.Text = "";
            txtTelefone.Text = "";
            txtAtividades.Text = "";
            txtMatrizFilial.Text = "";
            txtPorte.Text = "";
            txtDataSituacaoCadastral.Text = "";
            txtSituacao.Text = "";
            txtDataSituacaoEspecial.Text = "";
            txtEmailDois.Text = "";
            txtMotivoSituacaoCadastral.Text = "";
            txtNaturezaJuridica.Text = "";
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

        public bool ValidarDocumentos()
        {
            try
            {
                validarRegraNegocios = new ValidarRegraNegocios();

                string cpfCnpj = txtCpf_Cnpj.Text.Replace("-", "").Replace("/", "").Replace(",", "").Replace(".", "").Trim();

                if (rbPessoaFisica.Checked == true)
                {
                    if (validarRegraNegocios.IsCpf(cpfCnpj) == true)
                    {
                        ret = true;
                    }
                    else
                    {
                        ret = false;

                        MessageBox.Show("CPF Numero: " + txtCpf_Cnpj.Text.Trim() + ", é Invalido.\nPor Favir informe CPF Válido.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
                else
                {
                    if (validarRegraNegocios.IsCnpj(cpfCnpj) == true)
                    {
                        ret = true;
                    }
                    else
                    {
                        ret = false;

                        MessageBox.Show("CNPJ Numero: " + txtCpf_Cnpj.Text.Trim() + ", é Invalido.\nPor Favir informe CNPJ Válido.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }

                return ret;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

                return false;
            }
        }
    }
}
