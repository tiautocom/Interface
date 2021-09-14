using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using REGRA_NEGOCIOS;
using System.Security.Cryptography.X509Certificates;
using System.Xml;
using System.IO;
using OBJETO_TRANSFERENCIA;
using System.Xml.Linq;

namespace SAT
{
    public partial class frmNFCeLogin : Form
    {
        frmPesquisarCliente frmPesquisarCliente;
        frmVenda frmVenda;

        public frmNFCeLogin(frmVenda fVenda, string versao, int idTipoAmbiente, string url, int cUF, string servico, string uri, string ibge, string razaoScoailEmitente, int idTipoVenda)
        {
            InitializeComponent();

            this.grvEmpresa.AutoGenerateColumns = false;
            this.grvEmpresa.RowTemplate.Height = 30;
            this.frmVenda = fVenda;

            //ATRIBUIR O VALORES AOS OBJETOS
            this._versao = versao;
            this._idTipoAmbiente = idTipoAmbiente;
            this._url = url;
            this._cUF = cUF;
            this._metodo = "STATUS";
            this._servico = servico;
            this._uri = "http://www.portalfiscal.inf.br/nfe";
            this._ibge = ibge;
            this._razaoSocial = razaoScoailEmitente;
        }

        public string pathDadosVendaAutorizada = Path.GetDirectoryName(Application.ExecutablePath) + "\\Venda\\";
        public string pathNumCaixa = Path.GetDirectoryName(Application.ExecutablePath) + "\\BANCO\\NUM_CAIXA.xml";
        public string pathEndereco = Path.GetDirectoryName(Application.ExecutablePath);


        AssinaturaDigital assinaturaDigital;
        VendaRegraNegocios vendaRegraNegocios;
        UrlRegraNegocios urlRegraNegocios;
        XmlRegraNegocios xmlRegraNegocios;
        ValidarRegraNegocios validarRegraNegocios;
        EnviarDocumentoSefazRegraNegocios enviarSefaz;

        private X509Certificate2 certX509;

        Url url;

        public string _versao, _operador, _servico, _url, _metodo, _uri, _ibge, _razaoSocial = "";
        public int _idTipoAmbiente, _cUF = 0;
        public int numCaixa, _tipoVenda = 0;

        public string xmlStatus = "";
        public string url_ = "";
        public string action_ = "";

        public int tipoVenda = 0;
        public string xMotivo, cStatus = "";

        public XmlDocument soapXml;

        private void frmNFCeLogin_Load(object sender, EventArgs e)
        {
            LoadTela();
        }

        public void LoadTela()
        {
            assinaturaDigital = new AssinaturaDigital();

            grvEmpresa.DataSource = null;
            grvEmpresa.DataSource = assinaturaDigital.ListaCertificado();

            _razaoSocial = txtNomeEmpresa.Text.Trim();
        }

        private void grvEmpresa_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    int rowIndex = grvEmpresa.CurrentRow.Index;

                    string str = null;

                    string[] strArr = null;

                    str = grvEmpresa.Rows[rowIndex].Cells[0].Value.ToString().Trim();

                    char[] splitchar = { ':' };

                    strArr = str.Split(splitchar);

                    txtNomeEmpresa.Text = (strArr[0]).Replace("[Subject]", "").Replace("CN=", "").Trim();

                    txt_dadoscertificado.Text = grvEmpresa.Rows[rowIndex].Cells["Subject"].Value.ToString();

                    try
                    {
                        txtCNPJEmpresa.Text = (strArr[1]).Replace("[Subject]", "").Replace("CN=", "").Trim();
                    }
                    catch
                    {
                        txtCNPJEmpresa.Text = String.Join("", System.Text.RegularExpressions.Regex.Split(txtNomeEmpresa.Text, @"[^\d]"));
                    }

                    btnLogin.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void PesquisarNumCaixa_numBalanca_numPortaCom_Xml()
        {
            try
            {
                XmlTextReader x = new XmlTextReader(pathNumCaixa);

                while (x.Read())
                {
                    if (x.NodeType == XmlNodeType.Element && x.Name == "Num")
                        numCaixa = Convert.ToInt32(x.ReadString());
                }

                x.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void PesquisarNumVenda()
        {
            try
            {
                vendaRegraNegocios = new VendaRegraNegocios();

                var nVenda = vendaRegraNegocios.PesquisarNumVenda(numCaixa);

                _tipoVenda = Convert.ToInt32(nVenda.Rows[0]["TIPO_VENDA"].ToString().Trim().Substring(0, 1));
                _idTipoAmbiente = Convert.ToInt32(nVenda.Rows[0]["NFCE_AMBIENTE"].ToString().Trim().Substring(0, 1));

                if (_tipoVenda == 1)
                {
                    PesquisarDados();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atencao");
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtNomeEmpresa.Text.Trim().Equals(""))
            {
                MessageBox.Show("Selecione um Certificado Digital Desejado para Logar PDV - NFC-e.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                GerarXmlStatusServico();
            }
        }

        public void PesquisarDados()
        {
            try
            {
                #region PESQUISAR URL

                urlRegraNegocios = new UrlRegraNegocios();

                DataTable dadosTablelaUrl = new DataTable();

                url = new Url();

                url.IdAmbiente = _idTipoAmbiente;
                url.Servico = "NFeStatusServico4";
                url.CodNumerico = 1;

                dadosTablelaUrl = urlRegraNegocios.PesquisaUrl(url);

                if (dadosTablelaUrl.Rows.Count > 0)
                {
                    #region GERAR XML DE STATUS

                    //ATRIBUIR O VALORES AOS OBJETOS
                    _versao = dadosTablelaUrl.Rows[0]["VERSAO"].ToString().Trim();
                    _idTipoAmbiente = Convert.ToInt32(dadosTablelaUrl.Rows[0]["ID_AMBIENTE"].ToString());
                    _url = dadosTablelaUrl.Rows[0]["URL"].ToString().Trim();
                    _cUF = Convert.ToInt32(dadosTablelaUrl.Rows[0]["COD_UF"].ToString().Trim().Substring(0, 2));
                    _metodo = "STATUS";
                    _servico = dadosTablelaUrl.Rows[0]["SERVICO"].ToString().Trim();
                    _uri = "http://www.portalfiscal.inf.br/nfe";
                    _ibge = dadosTablelaUrl.Rows[0]["COD_UF"].ToString().Trim();
                }
                else
                {
                    MessageBox.Show("Endereço de URL de Serviço não foi Localizado..", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }

                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void GerarXmlStatusServico()
        {
            //GERAR XML
            xmlRegraNegocios = new XmlRegraNegocios();

            xmlStatus = xmlRegraNegocios.GerarXmlStatusServicoNFe(_versao, _idTipoAmbiente, _url, _cUF, _metodo, _servico, _uri, pathEndereco);

            if (xmlStatus.Trim().Equals(""))
            {
                MessageBox.Show("Erro ao Gerar XML Status de Serviço...\n\nCaso Problema Persistir Entre em Contato com Seu Administardor.", "Erro XML Status Serviço", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                #region SOAP

                EnveloparXML(_url, _servico, xmlStatus);

                #endregion
            }

            #endregion
        }

        private void grvEmpresa_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string str = null;

                string[] strArr = null;

                str = grvEmpresa.Rows[e.RowIndex].Cells[0].Value.ToString().Trim();

                char[] splitchar = { ':' };

                strArr = str.Split(splitchar);

                txtNomeEmpresa.Text = (strArr[0]).Replace("[Subject]", "").Replace("CN=", "").Trim();

                txt_dadoscertificado.Text = grvEmpresa.Rows[e.RowIndex].Cells["Subject"].Value.ToString();

                try
                {
                    txtCNPJEmpresa.Text = (strArr[1]).Replace("[Subject]", "").Replace("CN=", "").Trim();
                }
                catch
                {
                    txtCNPJEmpresa.Text = String.Join("", System.Text.RegularExpressions.Regex.Split(txtNomeEmpresa.Text, @"[^\d]"));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public bool EnveloparXML(string servico, string operador, string xmlStatus)
        {
            try
            {
                soapXml = new XmlDocument();

                xmlRegraNegocios = new XmlRegraNegocios();

                url_ = servico.Replace("?wsdl", "");
                action_ = servico.Replace("?wsdl", "") + "?op=" + operador;

                soapXml = new XmlDocument();

                soapXml = xmlRegraNegocios.CreateSoap(xmlStatus, url_, action_, pathEndereco);

                if (soapXml.OuterXml.Trim().Equals(""))
                {
                    MessageBox.Show("Erro ao Envelopar XML de Envio NFC-e", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return false;
                }
                else
                {
                    //VALIDAR
                    validarRegraNegocios = new ValidarRegraNegocios();

                    bool ret = validarRegraNegocios.ValidarEnvio(pathEndereco + "\\XMLs\\SERVICOS\\STATUS\\ENVELOPE.xml", pathEndereco + "\\XMLs\\SCHEMAS\\" + "consSitNFe_v4.00.xsd");

                    if (ret == true)
                    {
                        //ENVIA XML PARA SEFAZ
                        EnviarSefaz();
                    }
                    else
                    {
                        MessageBox.Show("Erro ao Validar XML de Envio NFC-e", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

                return false;
            }
        }

        public void EnviarSefaz()
        {
            try
            {
                enviarSefaz = new EnviarDocumentoSefazRegraNegocios();

                string enderecoSalvar = (pathEndereco + "\\XMLs\\SERVICOS\\STATUS\\RETORNO.xml");

                bool ret = enviarSefaz.EnviarXmlSefaz(txtNomeEmpresa.Text.Trim().Trim(), url_, action_, soapXml, enderecoSalvar);

                if (ret == true)
                {
                    LerConfigXml(enderecoSalvar);
                }
                else
                {
                    MessageBox.Show("Erro ao Acessar Sistema NF-e, Verifique se: \n1-Cartão de Assinatura Digital está Conectado Corretamente.\n2-Conexão com Internet.\n3-Validade do Cartão.\n4-Canal Seguro SSL\\TLS.\n5-Certificado é Correspodente o do Cliente: \n" + txtNomeEmpresa.Text.Trim() + "\n6-Site SEFAZ https://www.fazenda.sp.gov.br está Fora do Ar.\nCaso problema Persistir, Entre em Contato com seu Adminitrador.\n\n\nDetalhes do Retorno: Status: " + cStatus + ".\nMotixo: " + xMotivo + ".", "Retorno SEFAZ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao Acessar Sistema NF-e, Verifique se: \n1-Cartão de Assinatura Digital está Conectado Corretamente.\n2-Conexão com Internet.\n3-Validade do Cartão.\n4-Canal Seguro SSL\\TLS.\n5-Certificado é Correspodente o do Cliente: \n" + txtNomeEmpresa.Text.Trim() + "\n6-Site SEFAZ https://www.fazenda.sp.gov.br está Fora do Ar.\nCaso problema Persistir, Entre em Contato com seu Adminitrador.\n\n\nDetalhes do Retorno: " + ex.Message, "Retorno SEFAZ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void LerConfigXml(string end)
        {
            try
            {
                XmlTextReader x = new XmlTextReader(end);

                while (x.Read())
                {
                    if (x.NodeType == XmlNodeType.Element && x.Name == "xMotivo")
                        xMotivo = (x.ReadString());

                    if (x.NodeType == XmlNodeType.Element && x.Name == "cStat")
                        cStatus = (x.ReadString());
                }

                x.Close();

                if (cStatus.Trim().Equals("107"))
                {
                    this.DialogResult = DialogResult.OK;

                    SalvarArquivoEmitente();

                    this.Close();
                }
                else
                {
                    MessageBox.Show("Erro ao Acessar Sistema NFC-e, Verifique se: \n1-Cartão de Assinatura Digital está Conectado Corretamente.\n2-Conexão com Internet.\n3-Validade do Cartão.\n4-Canal Seguro SSL\\TLS.\n5-Certificado é Correspodente o do Cliente: \n" + txtNomeEmpresa.Text.Trim() + "\n6-Site SEFAZ https://www.fazenda.sp.gov.br está Fora do Ar.\nCaso problema Persistir, Entre em Contato com seu Adminitrador.\n\n\nDetalhes do Erro: Motivo: " + xMotivo.Trim() + ".\nStatus: " + cStatus.Trim(), "Retorno SEFAZ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void SalvarArquivoEmitente()
        {

            try
            {
                XElement xml = XElement.Load(pathEndereco + "\\BANCO\\EMITENTE.xml");

                XElement x = xml.Elements().Where(pXml => pXml.Element("ID_COD").Value.Equals("1")).FirstOrDefault();

                if (x != null)
                {
                    x.Element("RAZAO").SetValue(txtNomeEmpresa.Text.Trim());
                }

                if (x != null)
                {
                    x.Element("CNPJ").SetValue(txtCNPJEmpresa.Text.Trim());
                }

                xml.Save(pathEndereco + "\\BANCO\\EMITENTE.xml");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção");
            }
        }
    }
}
