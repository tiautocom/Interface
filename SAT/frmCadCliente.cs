using OBJETO_TRANSFERENCIA;
using REGRA_NEGOCIOS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;


namespace SAT
{
    public partial class frmCadCliente : Form
    {
        frmCpfCnpj frmCpfCnpj;

        public frmCadCliente(string doc, int idCliente, int tipo, frmCpfCnpj fCpfCnpj)
        {
            InitializeComponent();

            this.idCliente = idCliente;
            this.cpfCnpj = doc;
            this.tipo = tipo;

            this.frmCpfCnpj = fCpfCnpj;
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

        public string cpfCnpj = "";

        public bool ret;

        public int tipo = 0;

        #endregion

        private void rbPessoaJuiridica_CheckedChanged(object sender, EventArgs e)
        {
            btnPesquisarPJ.Enabled = true;
            lblNome.Text = "*Razão Social";
            lblCpfCnpj.Text = "*CNPJ";
            lblApelidoFantasia.Text = "*Nome Fantasia";
            lblRgIe.Text = "I.E";
            lblDatas.Text = "Data Fundação";

            txtCpf_Cnpj.Mask = "00-000-000/0000-00";
            txtRg_Ie.Mask = "0000,0000,0000";

            btnIsento.Enabled = true;

            txtNome.Focus();
            txtNome.SelectAll();
        }

        private void rbPessoaFisica_CheckedChanged(object sender, EventArgs e)
        {
            btnPesquisarPJ.Enabled = false;
            lblNome.Text = "*Nome";
            lblApelidoFantasia.Text = "*Apelido";
            lblCpfCnpj.Text = "*CPF";
            lblRgIe.Text = "RG";
            lblDatas.Text = "Data Aniversário";

            txtCpf_Cnpj.Mask = "000-000-000-00";
            txtRg_Ie.Mask = "00,000,000-0";

            btnIsento.Enabled = false;

            txtNome.Focus();
            txtNome.SelectAll();

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

                        txtNome.Text = filtrar.RemoverAcentos(myObject.nome.Trim());
                        txtEmail.Text = myObject.email.Trim();
                        txtEndereco.Text = filtrar.RemoverAcentos(myObject.logradouro.Trim());
                        txtComplemento.Text = filtrar.RemoverAcentos(myObject.complemento.Trim());
                        txtCidade.Text = filtrar.RemoverAcentos(myObject.municipio.Trim());
                        txtBairro.Text = filtrar.RemoverAcentos(myObject.bairro.Trim());
                        txtNumero.Text = filtrar.RemoverAcentos(myObject.numero.Trim());
                        txtCep.Text = filtrar.RemoverAcentos(myObject.cep.Trim());
                        cbUF.Text = filtrar.RemoverAcentos(myObject.uf.Trim());
                        txtObs.Text = filtrar.RemoverAcentos(myObject.motivo_situacao.Trim());

                        txtTelefone1.Text = myObject.telefone.Trim();

                        if (myObject.fantasia.Trim() == "")
                        {
                            txtApelido.Text = filtrar.RemoverAcentos(myObject.nome.Trim());
                        }

                        txtRg_Ie.Focus();
                        txtRg_Ie.SelectAll();

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

        public void LoadTela()
        {
            if (tipo == 1)
            {
                txtCpf_Cnpj.Mask = "00-000-000/0000-00";

                rbPessoaJuiridica.Checked = true;

                txtCpf_Cnpj.Text = cpfCnpj;
            }
            else if (tipo == 2)
            {
                txtCpf_Cnpj.Mask = "000-000-000-00";

                rbPessoaFisica.Checked = true;

                txtCpf_Cnpj.Text = cpfCnpj;
            }
            else
            {
                txtTelefone1.Text = cpfCnpj;
            }

            lblDtCadastro.Text = DateTime.Now.ToString("dd/MM/yyyy");

            txtNome.Focus();
            txtNome.SelectAll();
        }

        private void frmCadCliente_Load(object sender, EventArgs e)
        {
            LoadTela();
        }

        private void btnPesquisarPJ_Click(object sender, EventArgs e)
        {
            ConsultaCNPJ();
        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {
            if (rbPessoaFisica.Checked == true)
            {
                txtApelido.Text = txtNome.Text.Trim();
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

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Salvar();
        }

        public void Salvar()
        {
            try
            {
                string valorCpf = txtCpf_Cnpj.Text;

                valorCpf = valorCpf.Replace(" ", "");
                valorCpf = valorCpf.Replace(",", "");
                valorCpf = valorCpf.Replace("-", "");
                valorCpf = valorCpf.Replace(".", "");
                valorCpf = valorCpf.Replace("/", "");

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
                else if (valorCpf.Trim().Replace("-", "").Replace(",", "").Replace(".", "").Replace("/", "").Trim().Equals(""))
                {
                    MessageBox.Show("CPF/CNPJ não Pode ser Nulo ou Vázio.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                    txtCpf_Cnpj.Focus();
                    txtCpf_Cnpj.SelectAll();
                }
                else if (txtCelular.Text.Replace(" ", "").Replace("(", "").Replace(")", "").Replace("-", "").Trim().Equals(""))
                {
                    MessageBox.Show("Campo Celular Um não Pode ser Nulo ou Zero.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                    txtCelular.Focus();
                    txtCelular.SelectAll();
                }
                else if (txtEmail.Text.Replace(" ", "").Replace("(", "").Replace(")", "").Replace("-", "").Trim().Equals(""))
                {
                    MessageBox.Show("Campo E-Mail Um não Pode ser Nulo ou Zero.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                    txtEmail.Focus();
                    txtEmail.SelectAll();
                }
                else
                {
                    cliente = new ClienteC();

                    cliente.idCliente = Convert.ToInt32(txtCodigo.Text);
                    cliente.nome = txtNome.Text.Trim();
                    cliente.dataCadastro = lblDtCadastro.Text.Trim();
                    cliente.apelidoFantasia = txtApelido.Text.Trim();
                    cliente.cpfCnpj = valorCpf.Trim();
                    cliente.rgIe = txtRg_Ie.Text.Replace("-", "").Replace(",", "").Replace(".", "").Replace("/", "").Trim();
                    cliente.datas = Convert.ToDateTime(txtDtNasc.Text);
                    cliente.limite = Convert.ToDecimal(txtLimite.Text);
                    cliente.gasto = Convert.ToDecimal(txtGastos.Text);
                    cliente.bloq = cbBloq.Text.Trim();
                    cliente.email = txtEmail.Text.Trim();
                    cliente.status = Convert.ToBoolean(cbStatus.Checked);
                    cliente.observacao = txtObs.Text.Trim();

                    cliente.Telefone = new Telefone();

                    cliente.Telefone.telefone1 = txtTelefone1.Text.Replace("-", "").Replace(",", "").Replace(".", "").Replace("/", "").Replace("0", "").Replace(")", "").Trim();
                    cliente.Telefone.telefone2 = txtTelefone2.Text.Replace("-", "").Replace(",", "").Replace(".", "").Replace("/", "").Replace("0", "").Replace(")", "").Trim();
                    cliente.Telefone.celular = txtCelular.Text.Replace("-", "").Replace(",", "").Replace(".", "").Replace("/", "").Replace("0", "").Replace(")", "").Trim();

                    cliente.Endereco = new Endereco();

                    cliente.Endereco.cep = txtCep.Text.Trim();
                    cliente.Endereco.idPessoa = Convert.ToInt32(txtCodigo.Text);
                    cliente.Endereco.logradouro = txtEndereco.Text.Trim();
                    cliente.Endereco.numero = txtNumero.Text.Trim();
                    cliente.Endereco.bairro = txtBairro.Text.Trim();
                    cliente.Endereco.cidade = txtCidade.Text.Trim();
                    cliente.Endereco.uf = cbUF.Text.Trim();
                    cliente.Endereco.complemento = txtComplemento.Text.Trim();

                    clienteRegraNegocios = new ClienteRegraNegocios();

                    int idRet = Convert.ToInt32(clienteRegraNegocios.Salvar(cliente, 1));

                    if (idRet > 0)
                    {
                        MessageBox.Show("Novo Cliente Salvo com Sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        frmCpfCnpj.PreencherCampos();

                        this.Close();
                    }
                    else
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
    }
}
