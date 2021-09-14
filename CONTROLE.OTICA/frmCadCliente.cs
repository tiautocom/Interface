using Newtonsoft.Json;
using OBJETO_TRANSFERENCIA;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using REGRA_NEGOCIOS;

namespace CONTROLE.OTICA
{
    public partial class frmCadCliente : Form
    {
        frmPrincipal frmPrincipal;

        public frmCadCliente(frmPrincipal fPrincipal)
        {
            InitializeComponent();

            this.frmPrincipal = fPrincipal;
        }

        FILTRAR filtrar;
        ClienteC cliente;
        ClienteRegraNegocios clienteRegraNegocios;

        public int tipo = 0;
        public int idCliente = 0;

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
                    // string xml = "https://viacep.com.br/ws/@cep/xml/".Replace("@cep", txtCep.Text.Trim());

                    int resultado = 0;

                    DataSet ds = new DataSet();
                    ds.ReadXml(xml);
                    DataTable dataTabela = new DataTable();
                    dataTabela = ds.Tables[0];

                    resultado = Convert.ToInt32(dataTabela.Rows.Count);

                    if (resultado > 0)
                    {
                        try
                        {
                            txtEndereco.Text = filtrar.RemoverAcentos(dataTabela.Rows[0]["logradouro"].ToString().Trim());
                            txtBairro.Text = filtrar.RemoverAcentos(dataTabela.Rows[0]["bairro"].ToString().Trim());
                            try
                            {
                                txtCidade.Text = filtrar.RemoverAcentos(dataTabela.Rows[0]["localidade"].ToString().Trim().ToUpper());
                            }
                            catch
                            {
                                txtCidade.Text = filtrar.RemoverAcentos(dataTabela.Rows[0]["cidade"].ToString().Trim().ToUpper());
                            }

                            cbUF.Text = filtrar.RemoverAcentos(dataTabela.Rows[0]["uf"].ToString().Trim().ToUpper());
                            //txtCodMunicipioPessoa.Text = dataTabela.Rows[0]["ibge"].ToString().Trim().ToUpper();
                            try
                            {
                                txtTelefone1.Text = dataTabela.Rows[0]["ddd"].ToString().Trim().ToUpper();
                                txtTelefone2.Text = dataTabela.Rows[0]["ddd"].ToString().Trim().ToUpper();
                                txtCelular.Text = dataTabela.Rows[0]["ddd"].ToString().Trim().ToUpper();
                            }
                            catch
                            {
                                txtTelefone1.Text = "";
                                txtTelefone2.Text = "";
                                txtCelular.Text = "";
                            }

                            //PesquisarCodIbgeCliente();
                            txtNumero.Focus();
                        }
                        catch
                        {
                            MessageBox.Show("CEP: " + txtCep.Text.Trim() + " não foi Encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Question);

                            txtCep.Focus();
                        }
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

            tipo = 1;

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
            tipo = 2;

            txtCpf_Cnpj.Mask = "00,000,000/0000-00";
            txtRg_Ie.Mask = "0000,0000,0000";

            btnIsento.Enabled = true;

            txtNome.Focus();
            txtNome.SelectAll();
        }

        private void frmCadCliente_Load(object sender, EventArgs e)
        {
            LimparCampos(sender, e);
        }

        public void LimparCampos(object sender, EventArgs e)
        {
            lblDtCadastro.Text = DateTime.Now.ToString("dd/MM/yyyy");

            rbPessoaFisica_CheckedChanged(sender, e);

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
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            LimparCampos(sender, e);
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
                            txtObs.Text = filtrar.RemoverAcentos(myObject.code.Trim());
                        }
                        catch
                        {
                            txtObs.Text = "";
                        }

                        txtComplemento.Text = filtrar.RemoverAcentos(myObject.tipo.Trim());
                        txtDtNasc.Text = filtrar.RemoverAcentos(myObject.data_situacao.Trim());
                        txtDtNasc.Text = txtDtNasc.Text = Convert.ToDateTime(myObject.abertura.Trim()).ToString("dd/MM/yyyy");
                        txtNome.Text = txtNome.Text = filtrar.RemoverAcentos(myObject.nome.Trim());
                        txtEmail.Text = myObject.email.Trim();
                        txtEndereco.Text = txtEndereco.Text = filtrar.RemoverAcentos(myObject.logradouro.Trim());
                        txtComplemento.Text = txtComplemento.Text = filtrar.RemoverAcentos(myObject.complemento.Trim());
                        txtCidade.Text = filtrar.RemoverAcentos(myObject.municipio.Trim());
                        txtBairro.Text = filtrar.RemoverAcentos(myObject.bairro.Trim());
                        txtNumero.Text = filtrar.RemoverAcentos(myObject.numero.Trim());
                        txtCep.Text = filtrar.RemoverAcentos(myObject.cep.Trim());
                        cbUF.Text = filtrar.RemoverAcentos(myObject.uf.Trim());
                        //  txtMotivoSituacaoCadastral.Text = filtrar.RemoverAcentos(myObject.motivo_situacao.Trim());
                        txtApelido.Text = filtrar.RemoverAcentos(myObject.fantasia.Trim());
                        txtTelefone1.Text = myObject.telefone.Trim();
                        //txtPorte.Text = filtrar.RemoverAcentos(myObject.porte);
                        //txtCapitalSocial.Text = myObject.capital_social.ToString();
                        //lblStatus.Text = filtrar.RemoverAcentos(myObject.status);

                        //txtSitacaoSimples.Text = filtrar.RemoverAcentos(myObject.situacao);
                        //txtSituacao.Text = filtrar.RemoverAcentos(myObject.situacao_especial.Trim());
                        //txtDataSituacaoEspecial.Text = filtrar.RemoverAcentos(myObject.data_situacao_especial.Trim());
                        //txtNaturezaJuridica.Text = filtrar.RemoverAcentos(myObject.natureza_juridica.Trim());

                        //FormatarInscricaoEstadual();
                    }
                    else
                    {
                        MessageBox.Show("Pesquisa CNPJ: " + txtCpf_Cnpj.Text.Trim() + ", não Foi Localizado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Stop);
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

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            CadastrarCliente();
        }

        public void CadastrarCliente()
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
                //else if (ValidarDocumentos() == false)
                //{

                //}
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

                    cliente.nome = txtNome.Text.Trim();
                    cliente.apelidoFantasia = txtApelido.Text.Trim();
                    cliente.cpfCnpj = txtCpf_Cnpj.Text.Trim();
                    cliente.rgIe = txtRg_Ie.Text.Trim();
                    cliente.dataCadastro = DateTime.Now.ToString();
                    cliente.DtAniversario = Convert.ToDateTime(txtDtNasc.Text.Trim());
                    cliente.bloq = cbBloq.Text;
                    cliente.limite = Convert.ToDecimal(txtLimite.Text);
                    cliente.gasto = Convert.ToDecimal(txtGastos.Text);
                    cliente.observacao = txtObs.Text.Trim();
                    cliente.status = cbStatus.Checked;
                    cliente.email = txtEmail.Text.Trim();

                    cliente.Endereco = new Endereco();

                    cliente.Endereco.logradouro = txtEndereco.Text.Trim();
                    cliente.Endereco.numero = txtNumero.Text.Trim();
                    cliente.Endereco.bairro = txtBairro.Text.Trim();
                    cliente.Endereco.cidade = txtCidade.Text.Trim();
                    cliente.Endereco.uf = cbUF.Text.Trim();
                    cliente.Endereco.complemento = txtComplemento.Text.Trim();
                    cliente.Endereco.cep = txtCep.Text.Trim();

                    cliente.Telefone = new Telefone();

                    cliente.Telefone.telefone1 = txtTelefone1.Text.Trim();
                    cliente.Telefone.telefone2 = txtTelefone2.Text.Trim();
                    cliente.Telefone.celular = txtCelular.Text.Trim();

                    clienteRegraNegocios = new ClienteRegraNegocios();

                    try
                    {
                        idCliente = frmPrincipal.idCliente = Convert.ToInt32(clienteRegraNegocios.Salvar(cliente, 1));

                        frmPrincipal.nomeCliente = txtNome.Text.Trim();
                        frmPrincipal.emailCliente = txtEmail.Text.Trim();
                        frmPrincipal.Text = txtCelular.Text.Trim();

                        MessageBox.Show("Novo Cliente Salvo com Sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        LimparCampos();
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

        private void txtBairro_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {
            if (rbPessoaFisica.Checked == true)
            {
                txtApelido.Text = txtNome.Text.Trim();
            }
        }
    }
}
