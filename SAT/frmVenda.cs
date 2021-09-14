using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Threading;
using OBJETO_TRANSFERENCIA;
using REGRA_NEGOCIOS;
using System.IO.Ports;
using System.Collections;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using Vip.Printer.Enums;
using System.Drawing.Printing;
using Vip.Printer;
using IMPRESSORA;
using Microsoft.VisualBasic;
using System.Net;

namespace SAT
{
    public partial class frmVenda : Form
    {
        frmPesquisarCliente frmCliente;
        frmNFCeLogin frmNFCeLogin;

        public frmVenda(frmPesquisarCliente fCliente, string _versao, int _idTipoAmbiente, string _url, int _cUF, string _servico, string _uri, string _ibge, string _razaoEmitente, int _idTipoVenda, string _action)
        {
            InitializeComponent();

            this.frmCliente = fCliente;

            gdvVenda.AutoGenerateColumns = false;

            cupomFiscal = true;

            consultarSat = 0;

            this.versao = _versao;
            this.idTipoAmbiente = _idTipoAmbiente;
            this.url = _url;
            this.cUF = cUF.ToString();
            this.servico = _servico;
            this.url = _uri;
            this.ibge = _ibge;
            this.idTipoVenda = _idTipoVenda;
            this.action = _action;
        }

        #region PATH

        public string pathDadosVendaCanceladaAutorizada = Path.GetDirectoryName(Application.ExecutablePath) + "\\VD_CANC_TEXTO\\";
        public string pathDadosVendaAutorizada = Path.GetDirectoryName(Application.ExecutablePath) + "\\Venda\\";
        public string pathNumCaixa = Path.GetDirectoryName(Application.ExecutablePath) + "\\BANCO\\NUM_CAIXA.xml";
        public string pathStringConexao = Path.GetDirectoryName(Application.ExecutablePath) + "\\BANCO\\StringConexao.xml";
        public string pathImagemProibido = Path.GetDirectoryName(Application.ExecutablePath) + "\\Imagem\\pm.png";
        public string pathDadoSoftHouse = Path.GetDirectoryName(Application.ExecutablePath) + "\\BANCO\\SH.xml";
        public string pathBkp = Path.GetDirectoryName(Application.ExecutablePath) + "\\BANCO\\BKP.xml";
        public string pathVendaCFe = Path.GetDirectoryName(Application.ExecutablePath);
        public string pathUltimaVendaCFe = Path.GetDirectoryName(Application.ExecutablePath);
        public string pathCustodia = @"C:\CFe\Custodia\";
        public string pathXmlCupom = "";
        public string pathXmlCustodiaResp = "";

        #endregion

        #region CLASSES E OBJETOS

        StreamReader rdr = null;
        SerialPort _serialPort;

        NumCaixaC numCaixaC = new NumCaixaC();
        numCaixaRegraNegocios numCaixaRegraNegocios = new numCaixaRegraNegocios();

        UsuarioC usuarioC = new UsuarioC();
        UsuarioRegraNegocios usuarioRegraNegocios = new UsuarioRegraNegocios();

        ProdutoC produtoC = new ProdutoC();
        ProdutoRegraNegocios produtoRegraNegocios = new ProdutoRegraNegocios();

        VendaC vendaC = new VendaC();
        VendaRegraNegocios vendaRegraNegocios = new VendaRegraNegocios();

        ParametroC parametroC = new ParametroC();
        ParametroRegraNegocios parametroRegraNegocios = new ParametroRegraNegocios();

        TempC temC = new TempC();
        TempRegraNegocios tempRegraNegocios = new TempRegraNegocios();

        PagamentoVendaC pagamentoVendaC = new PagamentoVendaC();
        PagamentoVendaRegraNegocios pagamentoVendaRegraNegocios = new PagamentoVendaRegraNegocios();

        IMPRESSORA.ImpressoraC impressoraC = new IMPRESSORA.ImpressoraC();

        TipoPagamentoC tipoPagamentoC = new TipoPagamentoC();
        TipoPagamentoRegraNegocios tipoPagamentoRegraNegocios = new TipoPagamentoRegraNegocios();

        IMPRESSORA.BemasatImpressora confBemasat = new IMPRESSORA.BemasatImpressora();

        PlacaC placaC = new PlacaC();
        PlacaRegraNegocios placaRegraNegocios = new PlacaRegraNegocios();

        ClienteC clienteC = new ClienteC();
        ClienteRegraNegocios clienteRegraNegocios = new ClienteRegraNegocios();

        LogoRegraNegocios novaImagem = new LogoRegraNegocios();

        SoftwareHouse softwareHouse;

        BEMATECH bematechRegraNegocios;
        CABECALHO cabecalho;

        ESCPOS escPos;

        EscPosElgin escPosElgin;

        XmlRegraNegocios xmlRegraNegocios;

        FILTRAR filtrar;

        GerarChaveRegraNegocios gerarChaveRegraNegocios;

        #endregion

        #region VARIAVEIS

        //mouse
        public bool movimentou;

        //variaveis para balanaça
        public string portaBalanca = "";
        public int boudRonte = 0;
        public string peso = "";
        public long tempoTotal;
        public decimal qtdevenda = 0;
        public int milesegundos = 0;

        //SISTEMA
        public string versaoSistema = "";
        public int consultarSat = 0;
        public int tipoVenda;

        //VENDA SAT
        decimal valorVendaSat = 0;

        //TIPO DE CANCELAMENTO
        public int tipoCancelamento = 0;

        DateTime dataServidor;

        //LOAD TELA
        public bool statusCaixa;
        public int numCaixa, numCaixaUsuario = 0;
        public string numCaixaXml = "";
        public string numComBal = "";
        public string numComimp = "";
        public string bondRouteCom = "";
        public string nomeImpressora = "";
        public string dt = "";
        public int idUsuario = 0;
        public string nomeOperador = "";
        public string periodo = "";
        public string senhaUsuario;
        public bool ativado, permissaoAcesso;
        public int tipoUsuario = 1;
        public decimal somaTotal = 0;
        public decimal somaVenda = 0;

        //PRODUTO E VENDAS
        public string codigoBarrasProduto, granel, descricaoProduto, aliquota, valorPis, cstPis, valorCofins, cstCofins, cfop, ncm, origemProduto, icmsCst, cest, anp, unid = "";
        public string departam, reducao, tecla, atualiza, embal, lixo, validade, vencimento, indiceB, margemCom, dtCom, icms, qtdeCom, custoCaixa, margem = "";
        public int idProduto, idvenda = 0;

        //PRODUTO
        public int produtoId, vendaId, itemVenda, setor, numDeparatmento = 0;
        public decimal precoProd, qtdeProd, totalVenda, subTotal, custo, desc, estoqueMin, estoqueAtual, qtdeDesc = 0;
        public string estoque = "0,00";
        public DateTime datavenda, dtAjuste;
        public bool baixado, fech, descAutomatico;
        public int numVenda;
        public string precototal = "";

        //PARAMETRO
        public decimal limiteCompra = 0;
        public int qtdeCupom, timeDesc = 0;
        public bool vendaXml, PagamentoVendaXml, placa, imprimirCupom;
        public string descPlaca, km, endereco, crt = "";

        //XML
        public string stringConexaoXml = "";

        //DADOS ESTABELECIMENTO
        public string razaoSocial, nomeFantasia, numero, complemento, bairro, cep, cidade, uf, telefone, ie, cnpj, im = "";

        //IMPRESSORAS
        public int idRetorno = 0;
        public int parametroEtiqueta = 0;

        //CUPOM
        public string msg = "";
        public bool cupomFiscal = true;
        public string align = "";
        public int idCliente = 0;
        public string descricaPagamento = "";
        public decimal valorAberto = 0;

        //TEMPO
        private int time = -1;

        //AVISO PRODUTO
        public bool avisoProduto;

        //VENDA CANCELADA
        public bool autorizado, cancelarVenda;
        public int sessao;
        public string cpfCnpjCliente, nomeCliente, chaveCupom, protocolo = "";

        public string DadosCabecalhoCupom = "";
        public string DadosCorpoCupom = "";
        public string DadosPagamentoCupom = "";
        public string DadosPesquisaRelatorio = "";
        public string DadosFinaisCupom = "";
        public string DadosSatCupom = "";
        public string DadosCupomAberto = "";
        public string cupom = "";

        public string nomeImpressoraPadrao = "";
        public string enderecoChaveCancelada = "";
        public string enderecoXmlCustodia = "";

        public string condutor = "";

        public bool agruparVenda;

        public int linha = 0;
        public int idRet = 0;

        public int idParametro = 0;

        //SAT/NFCE
        public bool logarCaixa;
        public string ChaveCupomNFCe = "";
        public string statusNFCe = "";
        public int idTipoAmbiente, idTipoVenda, digitoVefificador = 0;
        public string url, servico, uri, ibge, versao, action, cUF = "";
        public string razaoEmitente, cnpjEmitente, ieEmitente = "";
        public string endCustodia = "";

        string dns = Dns.GetHostName();

        #endregion

        #region CONSTRUTOR

        private void frmVenda_Load(object sender, EventArgs e)
        {
            LoadTela();

            ObterTipo();
        }

        public void PesquisarPortaSat()
        {
            try
            {
                getNumberRandom();

                string ret = (Marshal.PtrToStringAnsi(IMPRESSORA.BematechImpressora.ConsultarStatusOperacional(sessao, softwareHouse.codAtivacao)));

                string dataSAT = (Sep_Delimitador('|', 17, ret)).Substring(0, 8).ToString().Trim();
                string dataHj = DateTime.Now.ToString("yyyyMMdd").Trim();

                if (dataHj != dataSAT)
                {
                    frmMsgSat frmMsgSat = new frmMsgSat(ret);
                    frmMsgSat.ShowDialog();
                }

                consultarSat++;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region METODOS E FUNCOES

        public PrinterType ObterTipo()
        {
            string impressora = nomeImpressoraPadrao;

            if (nomeImpressoraPadrao.Contains("MP-4200 TH"))
            {
                impressora = "Epson";
            }
            else if (nomeImpressoraPadrao.Contains("EPSON TM-T20"))
            {
                impressora = "Epson";
            }
            else if (nomeImpressoraPadrao.Contains("Daruma"))
            {
                impressora = "Epson";
            }

            else if (nomeImpressoraPadrao.Contains("MP-2500 TH"))
            {
                impressora = "Epson";
            }

            return impressora == "Bematech" ? PrinterType.Bematech : impressora == "Daruma" ? PrinterType.Daruma : PrinterType.Epson;
        }

        public void LoadTela()
        {
            try
            {
                LimparCampos();

                nomeImpressoraPadrao = nomeImpressoraPadrao = (new PrinterSettings()).PrinterName;

                PesquisarNumCaixa_numBalanca_numPortaCom_Xml();
                PesquisarDadosEstabelecimento();
                PesquisarStringConexaoXml();
                PesquisarCaixaLogado();
                PesquisarNumVenda();
                PesquisarLogin();
                PesquisarParametro();
                ListarGrid();
                IlustraLogo();
                PesquisarEmitenteXML();

                if (cupomFiscal == true)
                {
                    if (consultarSat == 0)
                    {
                        if (tipoVenda == 1)
                        {
                            PesquisarSofwareHouse();

                            PesquisarPortaSat();

                            lblTipoVenda.Text = "VENDAS S@T.";
                        }
                        else
                        {
                            GerarChaveNFCe();

                            lblTipoVenda.Text = "VENDAS NFC-e.";
                        }
                    }

                    lblNomeImpressora.ForeColor = Color.Yellow;

                    btnBandVerde.Visible = false;
                    btnBandVermelha.Visible = true;
                    pbNotaPaulista.Visible = true;
                }
                else
                {
                    lblNomeImpressora.ForeColor = Color.White;

                    btnBandVerde.Visible = true;
                    btnBandVermelha.Visible = false;
                    pbNotaPaulista.Visible = false;
                }

                versaoSistema = lblVersaoSistem.Text.Trim();

                lblNomeImpressora.Text = nomeImpressora.Trim();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção");
            }
        }

        public void AbrirCaixas()
        {
            try
            {
                LimparCampos();

                nomeImpressoraPadrao = nomeImpressoraPadrao = (new PrinterSettings()).PrinterName;

                PesquisarNumCaixa_numBalanca_numPortaCom_Xml();
                PesquisarDadosEstabelecimento();
                PesquisarStringConexaoXml();
                PesquisarCaixaLogado();
                PesquisarNumVenda();
                PesquisarLogin();
                PesquisarParametro();
                ListarGrid();
                IlustraLogo();

                if (tipoVenda == 1)
                {
                    if (consultarSat == 0)
                    {
                        PesquisarPortaSat();
                    }
                }
                else
                {
                    GerarChaveNFCe();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void GerarChaveNFCe()
        {

            try
            {
                gerarChaveRegraNegocios = new GerarChaveRegraNegocios();

                getNumberRandom();

                ChaveCupomNFCe = gerarChaveRegraNegocios.GerarChave(numVenda, cnpjEmitente, cUF.Substring(0, 2), sessao);

                digitoVefificador = Convert.ToInt32(gerarChaveRegraNegocios.digitoRetorno.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void ConsultarStatusDesbloquearTela()
        {
            try
            {
                if (logarCaixa == true)
                {

                }
                else
                {
                    MessageBox.Show("Serviço NFC-e está Fora de Operação.\n\nCaso Problema Persistir Entre em Contato com Administrador.", "Erro ao Acessar PDV", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void FormatarItemVenda()
        {
            try
            {
                if (gdvVenda.Rows.Count > 0)
                {
                    List<VENDAS> lista = new List<VENDAS>();

                    for (int i = 0; i < gdvVenda.Rows.Count; i++)
                    {
                        lista.Add(new VENDAS
                        {
                            itemVenda = (i + 1).ToString(),
                            IdVenda = Convert.ToInt32(gdvVenda.Rows[i].Cells["colIdVenda"].Value)
                        });
                    }

                    int idRet = vendaRegraNegocios.FormatarItemVendas(lista);

                    if (idRet == 0)
                    {
                        MessageBox.Show("Erro");
                    }
                    else
                    {
                        ListarGrid();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void PesquisarTemp()
        {
            try
            {
                DataTable dadosTabela = new DataTable();
                tempRegraNegocios = new TempRegraNegocios();

                dadosTabela = tempRegraNegocios.PesquisarTemp();

                if (dadosTabela.Rows.Count > 0)
                {
                    cpfCnpjCliente = dadosTabela.Rows[0]["CPF_CNPJ"].ToString().Trim();
                    nomeCliente = dadosTabela.Rows[0]["NOME"].ToString().Trim();
                    idCliente = Convert.ToInt32(dadosTabela.Rows[0]["ID_CLIENTE"].ToString());
                }
                else
                {
                    cpfCnpjCliente = "";
                    nomeCliente = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void PesquisarSofwareHouse()
        {
            try
            {
                XmlTextReader x = new XmlTextReader(pathDadoSoftHouse);
                softwareHouse = new SoftwareHouse();

                while (x.Read())
                {
                    if (x.NodeType == XmlNodeType.Element && x.Name == "Assinatura")
                        softwareHouse.assinatuaDigital = (x.ReadString());

                    if (x.NodeType == XmlNodeType.Element && x.Name == "Cnpj")
                        softwareHouse.cnpjSH = (x.ReadString());

                    if (x.NodeType == XmlNodeType.Element && x.Name == "codAtivacao")
                        softwareHouse.codAtivacao = (x.ReadString());
                }

                x.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção");
            }
        }

        private void PictureBox10_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtCodBarras.Focus();
            }
        }

        public void IniciarTempo()
        {
            timer1.Interval = timeDesc;
            timer1.Enabled = true;
        }

        public void StoparTempo()
        {
            time = -1;
            pictureBox1.Visible = false;
        }

        private void btnMenu_ButtonClick(object sender, EventArgs e)
        {
            if (pnlMenu.Visible == false)
            {
                pnlMenu.Visible = true;

                btnCancelarVenda.Text = "Cancelar Venda: " + numVenda.ToString();
                btnCancelaUltimaVenda.Text = "Cancelar Ultima Venda: " + (numVenda - 1).ToString();
                btnSangria.Focus();
            }
            else if (pnlMenu.Visible == true)
            {
                pnlMenu.Visible = false;
                LimparCampos();
            }
        }

        public void SomaTotalVendaCaixa()
        {
            try
            {
                vendaC = new VendaC();
                vendaRegraNegocios = new VendaRegraNegocios();
                DataTable dadosTabelaVenda = new DataTable();

                vendaC.numCaixa = numCaixa;
                vendaC.baixado = false;
                somaTotal = 0;

                dadosTabelaVenda = vendaRegraNegocios.PesquisarVenda(vendaC);

                if (dadosTabelaVenda.Rows.Count > 0)
                {
                    for (int i = 0; i < dadosTabelaVenda.Rows.Count; i++)
                    {
                        somaTotal += Convert.ToDecimal(dadosTabelaVenda.Rows[i]["TOTAL"].ToString());
                    }
                }
                else
                {
                    somaTotal = 0;
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
                        numCaixaXml = (x.ReadString());

                    if (x.NodeType == XmlNodeType.Element && x.Name == "NumComBal")
                        numComBal = (x.ReadString());

                    if (x.NodeType == XmlNodeType.Element && x.Name == "NumComImp")
                        numComimp = (x.ReadString());

                    if (x.NodeType == XmlNodeType.Element && x.Name == "BoundRoute")
                        bondRouteCom = (x.ReadString());

                    if (x.NodeType == XmlNodeType.Element && x.Name == "Impressora")
                        nomeImpressora = (x.ReadString());

                    if (x.NodeType == XmlNodeType.Element && x.Name == "PathXmlCupom")
                        pathXmlCupom = (x.ReadString());

                    if (x.NodeType == XmlNodeType.Element && x.Name == "PathXmlCupomResp")
                        pathXmlCustodiaResp = (x.ReadString());
                }

                x.Close();

                numCaixa = Convert.ToInt32(numCaixaXml);
                lblNumCaixa.Text = numCaixa.ToString().PadLeft(3, '0');
                lblNomeImpressora.Text = nomeImpressora.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void PesquisarEmitenteXML()
        {
            try
            {
                XmlTextReader x = new XmlTextReader(pathVendaCFe + "\\BANCO\\EMITENTE.xml");

                while (x.Read())
                {
                    if (x.NodeType == XmlNodeType.Element && x.Name == "RAZAO")
                        razaoEmitente = (x.ReadString());

                    if (x.NodeType == XmlNodeType.Element && x.Name == "CNPJ")
                        cnpjEmitente = (x.ReadString());

                    if (x.NodeType == XmlNodeType.Element && x.Name == "IE")
                        ieEmitente = (x.ReadString());
                }

                x.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void PesquisarStringConexaoXml()
        {
            try
            {
                XmlTextReader x = new XmlTextReader(pathStringConexao);

                while (x.Read())
                {
                    if (x.NodeType == XmlNodeType.Element && x.Name == "name")
                        stringConexaoXml = (x.ReadString());
                }

                x.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            dataServidor = DateTime.Now;

            if (gdvVenda.Rows.Count == 0)
            {
                txtDescricaoProduto.Text = dataServidor.ToLongTimeString();
            }

            lblData.Text = "Data: " + dataServidor.ToLongDateString() + " - Hora: " + dataServidor.ToLongTimeString();
        }

        public void PrintarHora()
        {
            if (gdvVenda.Rows.Count == 0)
            {
                txtDescricaoProduto.Text = dt.ToString();
            }
        }

        public void PesquisarCaixaLogado()
        {
            try
            {
                if (numCaixa > 0)
                {
                    numCaixaC = new NumCaixaC();
                    numCaixaRegraNegocios = new numCaixaRegraNegocios();
                    DataTable dadosTabelaNumCaixa = new DataTable();

                    numCaixaC.numCaixa = numCaixa;

                    dadosTabelaNumCaixa = numCaixaRegraNegocios.PesquisarCaixaLogado(numCaixa);

                    if (dadosTabelaNumCaixa.Rows.Count > 0)
                    {
                        statusCaixa = Convert.ToBoolean(dadosTabelaNumCaixa.Rows[0]["STATUS_CAIXA"].ToString());

                        if (statusCaixa == true)
                        {
                            pnlVenda.Enabled = true;

                            AbrirCaixa();

                            lblStatusCaixa.Text = "ABERTO";

                            txtNumVenda.Text = dadosTabelaNumCaixa.Rows[0]["NUM_VENDA"].ToString().PadLeft(10, '0');
                            pnlVenda.Enabled = true;
                        }
                        else
                        {
                            lblStatusCaixa.Text = "FECHADO";

                            frmLogin fLogin = new frmLogin(this, 1);
                            fLogin.ShowDialog();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Verifique se Contém Caixa Cadastrado com Numero " + numCaixa.ToString().Trim().PadLeft(3, '0') + ".\nOu entre em Contato Administrador.", "Caixa não Encontrado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Não foi Cadastrado Numero do Caixa no Arquivo XML.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção");
            }
        }

        public void AbrirCaixa()
        {
            try
            {
                numCaixaC = new NumCaixaC();
                numCaixaRegraNegocios = new numCaixaRegraNegocios();

                numCaixaC.statusCaixa = true;
                numCaixaC.numCaixa = numCaixa;

                string idRetorno = numCaixaRegraNegocios.AbrirCaixa(numCaixaC);

                try
                {
                    int idRet = Convert.ToInt32(idRetorno);
                }
                catch
                {
                    MessageBox.Show("Erro ao Abrir Caixa Numero: " + numCaixa + ".", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção");
            }
        }

        public int Logar(int tipo)
        {
            usuarioC.senha = senhaUsuario;
            usuarioC.numCaixa = numCaixa;

            DataTable dadosTabelaUsuario = new DataTable();
            dadosTabelaUsuario = usuarioRegraNegocios.PesquisarLoginUsuario(usuarioC);

            if (dadosTabelaUsuario.Rows.Count > 0)
            {
                ativado = Convert.ToBoolean(dadosTabelaUsuario.Rows[0]["ATIVADO"].ToString());
                numCaixaUsuario = Convert.ToInt32(dadosTabelaUsuario.Rows[0]["NUM_CAIXA"].ToString());
                idUsuario = Convert.ToInt32(dadosTabelaUsuario.Rows[0]["ID_USUARIO"].ToString());

                if (ativado == true)
                {
                    nomeOperador = dadosTabelaUsuario.Rows[0]["NOME"].ToString().Trim();
                    periodo = dadosTabelaUsuario.Rows[0]["PERIODO"].ToString().Trim();

                    lblOperador.Text = nomeOperador.Trim();
                    lblPeriodo.Text = periodo.Trim();

                    if (tipo == 2)
                    {
                        FecharLogin();
                    }

                    AbrirLogin();
                    AbrirCaixa();

                    LoadTela();

                    return 1;
                }
                else
                {
                    MessageBox.Show("Atenção Usuário está Desativado, \nInforme seu Superior ou Entre em Contato com Administrador", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return 0;
                }
            }
            else
            {
                MessageBox.Show("Senha ou Login está Incorreto", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return 0;
            }
        }

        public void AbrirLogin()
        {
            try
            {
                usuarioC = new UsuarioC();
                usuarioRegraNegocios = new UsuarioRegraNegocios();

                usuarioC.idUsuario = idUsuario;
                usuarioC.statusUsuario = true;

                string idRetorno = usuarioRegraNegocios.AbrirLogin(usuarioC);

                try
                {
                    int idRet = Convert.ToInt32(idRetorno);
                }
                catch
                {
                    idRet = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção");
            }
        }

        public void FecharLogin()
        {
            try
            {
                usuarioC = new UsuarioC();
                usuarioRegraNegocios = new UsuarioRegraNegocios();

                usuarioC.idUsuario = idUsuario;
                usuarioC.statusUsuario = false;
                usuarioC.numCaixa = numCaixa;

                string idRetorno = usuarioRegraNegocios.FechaLogin(usuarioC);

                try
                {
                    int idRet = Convert.ToInt32(idRetorno);
                }
                catch
                {
                    idRet = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção");
            }
        }

        public void PesquisarLogin()
        {
            try
            {
                usuarioC = new UsuarioC();
                usuarioRegraNegocios = new UsuarioRegraNegocios();
                DataTable dadosTabelaUsuario = new DataTable();

                usuarioC.numCaixa = numCaixa;
                usuarioC.statusUsuario = true;

                dadosTabelaUsuario = usuarioRegraNegocios.PesquisarLogin(usuarioC, idUsuario);

                if (dadosTabelaUsuario.Rows.Count > 0)
                {
                    nomeOperador = dadosTabelaUsuario.Rows[0]["NOME"].ToString().Trim();
                    periodo = dadosTabelaUsuario.Rows[0]["PERIODO"].ToString().Trim();
                    idUsuario = Convert.ToInt32(dadosTabelaUsuario.Rows[0]["ID_USUARIO"].ToString());

                    //LIMPAR VARIAVEIS
                    nomeOperador = nomeOperador.Trim();
                    periodo = periodo.Trim();

                    lblOperador.Text = "[" + idUsuario.ToString().PadLeft(3, '0') + "] - " + nomeOperador;
                    lblPeriodo.Text = periodo;

                    lblCaixa.Text = " *** CAIXA LIVRE ***";
                }
                else
                {
                    lblCaixa.Text = " *** CAIXA FECHADO ***";

                    frmLogin login = new frmLogin(this, 2);
                    login.ShowDialog();

                    if (login.DialogResult == DialogResult.OK)
                    {
                        idUsuario = login.idUsuario;

                        LoadTela();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção");
            }
        }

        private void btnCancelaUltimaVenda_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Realmente Deseja Cancelar Venda Nº: " + (numVenda - 1) + ".", "Cancela Venda", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    frmCancelarUltimaVenda frmCancelarUltimaVenda = new frmCancelarUltimaVenda(this);
                    frmCancelarUltimaVenda.ShowDialog();

                    if (autorizado == true)
                    {
                        if (cupomFiscal == true)
                        {
                            if (idTipoVenda == 1)
                            {
                                GerarXmlCancelamentoCupomBematech();
                            }
                        }
                        else
                        {
                            CancelarItemNumVenda();
                            CancelarPagamentoVenda();
                        }
                    }
                    else
                    {
                        CancelarItemNumVenda();
                        CancelarPagamentoVenda();
                    }
                }

                LimparCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção");
            }
        }

        public void CancelarPagamentoVenda()
        {
            try
            {
                pagamentoVendaC = new PagamentoVendaC();
                pagamentoVendaRegraNegocios = new PagamentoVendaRegraNegocios();
                DataTable dadosTabelaPagamentoVenda = new DataTable();

                int ultimoNumVenda = (numVenda - 1);

                pagamentoVendaC.numVenda = ultimoNumVenda;
                pagamentoVendaC.numCaixa = numCaixa;

                dadosTabelaPagamentoVenda = pagamentoVendaRegraNegocios.PesquisarPagamentoVenda(pagamentoVendaC);

                if (dadosTabelaPagamentoVenda.Rows.Count > 0)
                {
                    for (int i = 0; i < dadosTabelaPagamentoVenda.Rows.Count; i++)
                    {
                        int tipoPagamento = Convert.ToInt32(dadosTabelaPagamentoVenda.Rows[i]["TIPO_PAGTO_ID"].ToString());
                        decimal valorVenda = Convert.ToDecimal(dadosTabelaPagamentoVenda.Rows[i]["VALOR"].ToString());
                        decimal troco = Convert.ToDecimal(dadosTabelaPagamentoVenda.Rows[i]["TROCO"].ToString());

                        idCliente = Convert.ToInt32(dadosTabelaPagamentoVenda.Rows[i]["ID_CLIENTE"].ToString());

                        pagamentoVendaC.idCliente = idCliente;
                        pagamentoVendaC.idUsuario = idUsuario;
                        pagamentoVendaC.tipoPagamento = tipoPagamento;
                        pagamentoVendaC.valor = (valorVenda * -1);
                        pagamentoVendaC.cnpj = cpfCnpjCliente ?? null ?? "";
                        pagamentoVendaC.baixado = false;
                        pagamentoVendaC.data = DateTime.Now.Date;
                        pagamentoVendaC.fechado = false;
                        pagamentoVendaC.numVenda = ultimoNumVenda;
                        pagamentoVendaC.numCaixa = numCaixa;
                        pagamentoVendaC.troco = (troco * -1);
                        pagamentoVendaC.tag = cupomFiscal;

                        string idRetorno = pagamentoVendaRegraNegocios.CadastrarPagamentoVenda(pagamentoVendaC);

                        try
                        {
                            idRet = Convert.ToInt32(idRetorno);
                        }
                        catch
                        {
                            idRet = Convert.ToInt32(idRetorno);
                        }

                        valorVenda = 0;
                        tipoPagamento = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção");
            }
        }

        public void CancelarItemNumVenda()
        {
            try
            {
                vendaC = new VendaC();
                vendaRegraNegocios = new VendaRegraNegocios();
                DataTable dadosTabelaVenda = new DataTable();

                vendaC.numCaixa = numCaixa;
                vendaC.numVenda = (numVenda - 1);

                dadosTabelaVenda = vendaRegraNegocios.PesquisarUltimaVenda(vendaC);

                if (dadosTabelaVenda.Rows.Count > 0)
                {
                    for (int i = 0; i < dadosTabelaVenda.Rows.Count; i++)
                    {
                        vendaC.codBarra = dadosTabelaVenda.Rows[i]["COD_BARRA"].ToString().Trim();
                        vendaC.descricao = dadosTabelaVenda.Rows[i]["DESCRICAO_PRODUTO"].ToString().Trim();
                        vendaC.qtde = (Convert.ToDecimal(dadosTabelaVenda.Rows[i]["QUANT"].ToString()) * -1);
                        vendaC.subTotal = (Convert.ToDecimal(dadosTabelaVenda.Rows[i]["TOTAL"].ToString()) * -1);
                        vendaC.item = Convert.ToInt32(dadosTabelaVenda.Rows[i]["ITEM"].ToString());
                        vendaC.dtVenda = DateTime.Now;
                        vendaC.idProduto = Convert.ToInt32(dadosTabelaVenda.Rows[i]["ID_PROD"].ToString());
                        vendaC.idUsuario = idUsuario;
                        vendaC.custo = (Convert.ToDecimal(dadosTabelaVenda.Rows[i]["CUSTO"].ToString()));
                        vendaC.baixado = false;
                        vendaC.numVenda = (numVenda - 1);
                        vendaC.aliquota = dadosTabelaVenda.Rows[i]["TRIB"].ToString().Trim();
                        vendaC.precoProduto = (Convert.ToDecimal(dadosTabelaVenda.Rows[i]["PRECO"].ToString()));
                        vendaC.valorPis = "";
                        vendaC.cstPis = "";
                        vendaC.valorCofins = "";
                        vendaC.cstCofins = "";
                        vendaC.cfop = dadosTabelaVenda.Rows[i]["CFOP"].ToString().Trim();
                        vendaC.ncm = dadosTabelaVenda.Rows[i]["NCM"].ToString().Trim();
                        vendaC.origemProduto = dadosTabelaVenda.Rows[i]["ORIGEM_PRODUTO"].ToString().Trim();
                        vendaC.icmsCst = "";
                        vendaC.fech = fech;
                        vendaC.cest = "";
                        vendaC.numCaixa = numCaixa;
                        vendaC.anp = dadosTabelaVenda.Rows[i]["ANP"].ToString().Trim();
                        vendaC.unid = dadosTabelaVenda.Rows[i]["UNID"].ToString().Trim();
                        vendaC.tag = cupomFiscal;


                        if ((vendaC.item == 0) || (vendaC.fech == false))
                        {
                            string idRetorno = vendaRegraNegocios.VenderItem(vendaC);

                            try
                            {
                                idRet = Convert.ToInt32(idRetorno);

                                vendaC = new VendaC();
                            }
                            catch
                            {
                                MessageBox.Show("Erro ao Cancelar Venda.\nProduto " + produtoC.descricao + ".", "Cancelamento de Venda", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    if (idRet > 0)
                    {
                        MessageBox.Show("Venda foi Cancelada com Sucesso.", "Cancelamento de Venda", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        txtCodBarras.Text = "";
                        txtCodBarras.Focus();
                        txtCodBarras.SelectAll();
                    }
                }
                else
                {
                    MessageBox.Show("Não Contém Venda com Numero: " + (numVenda - 1) + ".", "Dados da Venda", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LimparCampos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção");
            }
        }

        public void GerarXmlCancelamentoCupomBematech()
        {
            try
            {
                LerChaveXml();

                GerarXmlCancelamento();

                getNumberRandom();

                string ret = null;

                ret = Marshal.PtrToStringAnsi(IMPRESSORA.BematechImpressora.CancelarUltimaVenda(sessao, softwareHouse.codAtivacao, chaveCancel, dadosXmlCfeCancel.ToString()));

                string ret_sessao = (Sep_Delimitador('|', 0, ret));
                string ret_sat = (Sep_Delimitador('|', 1, ret));
                string ret_erro = (Sep_Delimitador('|', 2, ret));
                string ret_err_ = (Sep_Delimitador('|', 3, ret));
                string ret_0 = (Sep_Delimitador('|', 4, ret));
                string ret_1 = (Sep_Delimitador('|', 5, ret));
                string ret_desc = (Sep_Delimitador('|', 6, ret));
                string ret_3 = (Sep_Delimitador('|', 7, ret));
                string ret_id = (Sep_Delimitador('|', 8, ret));

                if (ret_sat == "07000")
                {
                    byte[] senhaBinaria = new byte[256];

                    //Descriptografa....................................................................................................
                    senhaBinaria = Convert.FromBase64String(ret_desc);

                    string senhaDescripto = ASCIIEncoding.ASCII.GetString(senhaBinaria);

                    //gera arquivo em txt aprovado......................................................................................
                    string strPathFile = pathDadosVendaCanceladaAutorizada + "000.txt";

                    using (FileStream fs = File.Create(strPathFile))
                    {
                        using (StreamWriter sw = new StreamWriter(fs))
                        {
                            sw.Write(senhaDescripto);
                        }
                    }

                    //Converte TXTpara XML e Salva em Arquivo XML............................................................................................

                    string mes = DateTime.Now.Month.ToString().PadLeft(2, '0');
                    string ano = DateTime.Now.Year.ToString();

                    string enderecoExitente = (pathCustodia + ano + "\\" + mes + "\\" + "Cx" + numCaixa + "\\");

                    FileStream sr = new FileStream(strPathFile, FileMode.Open, FileAccess.Read);
                    byte[] bytes = new byte[Convert.ToInt32(sr.Length)];
                    sr.Read(bytes, 0, Convert.ToInt32(sr.Length));
                    FileStream srXml = new FileStream(enderecoExitente + chaveCupom + "-Canc.xml", FileMode.Create, FileAccess.Write);
                    StreamWriter wr = new StreamWriter(srXml);
                    srXml.Write(bytes, 0, bytes.Length);
                    sr.Close();
                    srXml.Close();

                    enderecoChaveCancelada = enderecoExitente + chaveCupom + "-Canc.xml";

                    MontarCupomCancelamento();

                    CancelarItemNumVenda();
                    CancelarPagamentoVenda();
                }
                else
                {
                    MessageBox.Show(ret_err_ + ".", "Error S@T", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LimparCampos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção");
                LimparCampos();
            }
        }

        public void GerarXmlCancelamentoNFCe()
        {
            try
            {
                xmlRegraNegocios = new XmlRegraNegocios();

                LerRetornoNFCe();

                string xmlCancelamento = xmlRegraNegocios.GerarXmlCancelamentoNFCe(versao, chaveCancel, cUF, "1", idTipoAmbiente, cnpjEmitente, protocolo, pathCustodia);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void LerRetornoNFCe()
        {

        }

        public string esquerda, direita, centrarlizar, nCFe, nserieSAT, valorCancel, qrCod = "";

        public void MontarCupomCancelamento()
        {
            try
            {
                LerXmlRetCustodiaCancel();

                impressoraC = new IMPRESSORA.ImpressoraC();

                if (nomeImpressora.Trim().Equals("BEMATECH") || nomeImpressora.Trim().Equals("BEMASAT"))
                {
                    bematechRegraNegocios = new BEMATECH();

                    string cv = Convert.ToDecimal(valorCancel.Replace(",", "").Replace(".", ",")).ToString("N3");

                    DadosCabecalhoCupom = bematechRegraNegocios.CabecalhoDadosEmpresa(cabecalho);
                    DadosCorpoCupom = bematechRegraNegocios.CabecalhoCancelamentoSat(nserieSAT, nCFe);
                    DadosFinaisCupom = bematechRegraNegocios.DadosFinaisCancelamento(cv, (numVenda - 1).ToString(), numCaixa.ToString(), nomeOperador);

                    //LOCALIZA IMPRESSORA E PORTA COM
                    idRetorno = IMPRESSORA.BemasatImpressora.ConfiguraModeloImpressora(7);
                    idRetorno = IMPRESSORA.BemasatImpressora.IniciaPorta(numComimp);

                    esquerda = "" + (char)27 + (char)97 + (char)0;
                    centrarlizar = "" + (char)27 + (char)97 + (char)1;
                    direita = "" + (char)27 + (char)97 + (char)2;

                    idRetorno = IMPRESSORA.BemasatImpressora.ComandoTX(esquerda, esquerda.Length);

                    //IMPRESSORA
                    string cupomImprimir = (DadosCabecalhoCupom + DadosCorpoCupom + DadosFinaisCupom);

                    idRetorno = IMPRESSORA.BemasatImpressora.FormataTX(cupomImprimir + (char)10 + (char)13, 1, 0, 0, 0, 0);

                    idRetorno = IMPRESSORA.BemasatImpressora.ConfiguraCodigoBarras(70, 0, 1, 1, 0);

                    chaveCupom = chaveCupom.Replace("CFe", "").Replace(" ", "").Trim();
                    idRetorno = IMPRESSORA.BemasatImpressora.ComandoTX(centrarlizar, centrarlizar.Length);
                    IMPRESSORA.BemasatImpressora.ImprimeCodigoBarrasCODE128(chaveCupom);

                    string qrCodes = chaveCupom.Replace("CFe", "").Trim() + "|" + DateTime.Now.ToString("yyyyMMddHHMMss") + "|" + totalVenda + "|" + qrCod;

                    idRetorno = IMPRESSORA.BemasatImpressora.ComandoTX(centrarlizar, centrarlizar.Length);
                    idRetorno = IMPRESSORA.BemasatImpressora.ImprimeCodigoQRCODE(1, 5, 0, 6, 1, qrCodes);

                    idRetorno = IMPRESSORA.BemasatImpressora.AcionaGuilhotina(0);
                    idRetorno = IMPRESSORA.BemasatImpressora.FechaPorta();
                }
                else if ((nomeImpressora.Trim().Equals("ESCPOS")) || nomeImpressora.Trim().Equals("ELGIN"))
                {
                    escPos = new ESCPOS();

                    DadosCabecalhoCupom = escPos.CabecalhoDadosEmpresa(cabecalho);
                    DadosCorpoCupom = escPos.CabecalhoCancelamentoSat(nserieSAT, nCFe);
                    DadosFinaisCupom = escPos.DadosFinaisCancelamento(valorCancel, (numVenda - 1).ToString(), numCaixa.ToString(), nomeOperador);

                    cupom = (DadosCabecalhoCupom + DadosCorpoCupom + DadosFinaisCupom);

                    var printer = new Printer(nomeImpressoraPadrao, ObterTipo());

                    printer.Imprimirrelatorio(cupom);

                    printer.AlignCenter();

                    string chave1 = chaveCancel.Replace("CFe", "").Substring(0, 22).Trim();
                    string chave2 = chaveCancel.Replace("CFe", "").Substring(22, 22).Trim();

                    printer.CondensedMode(PrinterModeState.On);
                    printer.BoldMode(chaveCancel.Replace("CFe", "").Trim());
                    printer.CondensedMode(PrinterModeState.Off);

                    printer.NewLines(1);
                    printer.Code128(chave1);
                    printer.NewLines(2);
                    printer.Code128(chave2);

                    printer.NewLines(3);

                    string qrCodes = chaveCupom.Replace("CFe", "").Trim() + "|" + DateTime.Now.ToString("yyyyMMddHHMMss") + "|" + totalVenda + "|" + qrCod;

                    printer.QrCode(qrCodes, QrCodeSize.Size1);

                    printer.NewLines(3);

                    printer.PartialPaperCut();

                    printer.PrintDocument();

                    printer.InitializePrint();
                }
                if (nomeImpressora.Trim().Equals("EPSON"))
                {
                    idRetorno = IMPRESSORA.InterfaceEpsonNF.IniciaPorta("USB");

                    string qrCodes = chaveCupom.Replace("CFe", "").Trim() + "|" + DateTime.Now.ToString("yyyyMMddHHMMss") + "|" + totalVenda + "|" + qrCod;

                    idRetorno = IMPRESSORA.InterfaceEpsonNF.EPSON_SAT_Imprimir_Cancelamento(enderecoChaveCancelada, qrCodes, "N");

                    if (idRetorno != 0x01)

                        MessageBox.Show("Erro ao imprimir o Extrato do Sat.", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    idRetorno = IMPRESSORA.InterfaceEpsonNF.FechaPorta();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção");
            }
        }

        public void LerXmlRetCustodiaCancel()
        {
            try
            {
                string ano, mes = "";

                ano = DateTime.Now.Year.ToString();
                mes = DateTime.Now.Month.ToString().PadLeft(2, '0');

                endereco = (pathCustodia + ano + "\\" + mes + "\\" + "Cx" + numCaixa + "\\");

                XmlTextReader x = new XmlTextReader(endereco + "\\" + chaveCupom.Replace("CFe", "") + ".xml");

                while (x.Read())
                {

                    if (x.NodeType == XmlNodeType.Element && x.Name == "assinaturaQRCODE")
                        qrCod = (x.ReadString());

                    if (x.NodeType == XmlNodeType.Element && x.Name == "nCFe")
                        nCFe = (x.ReadString());

                    if (x.NodeType == XmlNodeType.Element && x.Name == "vCFe")
                        valorCancel = (x.ReadString());

                    if (x.NodeType == XmlNodeType.Element && x.Name == "nserieSAT")
                        nserieSAT = (x.ReadString());
                }

                x.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção");
            }
        }

        public void LerChaveXml()
        {
            try
            {
                string endereco = (pathVendaCFe + "\\ULTIMA_CHAVE\\CHAVE.xml");

                XmlTextReader x = new XmlTextReader(endereco);

                while (x.Read())
                {
                    if (x.NodeType == XmlNodeType.Element && x.Name == "NumCFe")
                        chaveCupom = (x.ReadString());
                }

                x.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção");
            }
        }

        public void BloquearTelaVenda()
        {
            try
            {
                pnlVenda.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void PesquisarUltimoItemVendido()
        {
            try
            {
                vendaC = new VendaC();
                vendaRegraNegocios = new VendaRegraNegocios();
                DataTable dadosTabelavenda = new DataTable();

                vendaC.numCaixa = numCaixa;
                vendaC.baixado = false;
                vendaC.numVenda = numVenda;

                dadosTabelavenda = vendaRegraNegocios.PesquisarUltimaItemVendido(vendaC);

                if (dadosTabelavenda.Rows.Count > 0)
                {
                    //PESQUISAR ULTIMO ITEM VENDIDO DO PRODUTO
                    PesquisarLimiteSat();

                    if (valorVendaSat <= limiteCompra)
                    {
                        vendaC = new VendaC();
                        vendaRegraNegocios = new VendaRegraNegocios();

                        vendaC.codBarra = dadosTabelavenda.Rows[0]["COD_BARRA"].ToString();
                        vendaC.descricao = dadosTabelavenda.Rows[0]["DESCRICAO_PRODUTO"].ToString();
                        vendaC.qtde = Convert.ToDecimal(dadosTabelavenda.Rows[0]["QUANT"].ToString());
                        vendaC.subTotal = Convert.ToDecimal(dadosTabelavenda.Rows[0]["TOTAL"].ToString());
                        vendaC.item = (Convert.ToInt32(gdvVenda.Rows.Count) + 1);
                        vendaC.dtVenda = DateTime.Now;
                        vendaC.idProduto = Convert.ToInt32(dadosTabelavenda.Rows[0]["ID_PROD"].ToString());
                        vendaC.idUsuario = Convert.ToInt32(dadosTabelavenda.Rows[0]["ID_USUARIO"].ToString());
                        vendaC.custo = Convert.ToDecimal(dadosTabelavenda.Rows[0]["CUSTO"].ToString());
                        vendaC.baixado = baixado;
                        vendaC.numVenda = numVenda;
                        vendaC.aliquota = dadosTabelavenda.Rows[0]["ALIQUOTA"].ToString().Trim();
                        vendaC.precoProduto = Convert.ToDecimal(dadosTabelavenda.Rows[0]["PRECO"].ToString());
                        vendaC.valorPis = dadosTabelavenda.Rows[0]["VALOR_PIS"].ToString().Trim();
                        vendaC.cstPis = dadosTabelavenda.Rows[0]["CST_PIS"].ToString().Trim();
                        vendaC.valorCofins = dadosTabelavenda.Rows[0]["VALOR_COFINS"].ToString().Trim();
                        vendaC.cstCofins = dadosTabelavenda.Rows[0]["CST_COFINS"].ToString().Trim();
                        vendaC.cfop = dadosTabelavenda.Rows[0]["CFOP"].ToString().Trim();
                        vendaC.ncm = dadosTabelavenda.Rows[0]["NCM"].ToString().Trim();
                        vendaC.origemProduto = dadosTabelavenda.Rows[0]["ORIGEM_PRODUTO"].ToString().Trim();
                        vendaC.icmsCst = dadosTabelavenda.Rows[0]["ICM_CST"].ToString().Trim();
                        vendaC.fech = fech;
                        vendaC.cest = dadosTabelavenda.Rows[0]["CEST"].ToString().Trim();
                        vendaC.numCaixa = numCaixa;
                        vendaC.anp = dadosTabelavenda.Rows[0]["ANP"].ToString().Trim();
                        vendaC.unid = dadosTabelavenda.Rows[0]["UNID"].ToString().Trim();
                        vendaC.tag = cupomFiscal;

                        string idRetornoVenda = vendaRegraNegocios.VenderItem(vendaC);

                        try
                        {
                            Convert.ToInt32(idRetornoVenda);

                            gdvVenda.Refresh();
                            gdvVenda.Update();

                            ListarGrid();

                            LimparCampos();
                        }
                        catch
                        {
                            MessageBox.Show("Erro ao Cadastrar Venda, Verifique se Exite(m) dados com valor(es) Obrigatório, ou entre em Contato com seu Administrador", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            LimparCampos();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Valor da Venda Acima do Permitido pela SEFAZ", "Limite de Venda S@T", MessageBoxButtons.OK, MessageBoxIcon.None);
                        LimparCampos();
                    }
                }
                else
                {
                    MessageBox.Show("Não Contém Item Vedido com Caixa Nº: " + numCaixa.ToString().PadLeft(3, '0'), "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimparCampos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção");
            }
        }

        private void txtCodigoBarras_KeyDown(object sender, KeyEventArgs e)
        {
            if (idUsuario > 0)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if ((txtCodBarras.Text != "") && (txtCodBarras.Text != null))
                    {
                        if ((gdvVenda.Rows.Count == 0) && (txtCodBarras.Text != ""))
                        {
                            if (cupomFiscal == true)
                            {
                                frmCpfCnpj frmCpfn = new frmCpfCnpj(this);
                                frmCpfn.ShowDialog();
                            }
                        }

                        codigoBarrasProduto = txtCodBarras.Text;
                        codigoBarrasProduto = codigoBarrasProduto.Trim().PadLeft(13, '0');
                        txtCodBarras.Text = codigoBarrasProduto;

                        PesquisarCodigoBarras();
                    }
                    else
                    {
                        LimparCampos();
                    }
                }

                if (e.KeyCode == Keys.Escape)
                {
                    LimparCampos();

                    //btnMinimizar_ButtonClick(sender, e);
                }

                if (e.KeyCode == Keys.Back)
                {
                    //e.Handled = false;
                    //txtCodigoBarras.SelectionStart = txtCodigoBarras.Text.Length -1;
                }

                if (Control.ModifierKeys == Keys.Alt && e.KeyCode == Keys.F1)
                {
                    if (gdvVenda.Rows.Count <= 0)
                    {
                        if (MessageBox.Show("Deseja Sair Do Sistema", "Sair", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                        {
                            this.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Para Sair do Sistema é Preciso Fechar Venda em Aberto.", "Fechar Venda", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                if (e.KeyCode == Keys.F8)
                {
                    btnMenu_ButtonClick(sender, e);

                    txtCodBarras.Clear();
                }

                if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.A)
                {
                    PesquisarUltimoItemVendido();

                    txtCodBarras.Clear();
                }

                if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.I)
                {
                    TrocarLogo();

                    txtCodBarras.Clear();
                }

                if (e.KeyCode == Keys.Add)
                {
                    PesquisarUltimoItemVendido();

                    txtCodBarras.Clear();
                }

                if (e.KeyCode == Keys.F2)
                {
                    btnNotaPaulista_Click(sender, e);
                }

                if (e.KeyCode == Keys.F5)
                {
                    frmListarProduto fListarProduto = new frmListarProduto(this);
                    fListarProduto.ShowDialog();

                    if ((codigoBarrasProduto != null) && (codigoBarrasProduto != ""))
                    {
                        if (gdvVenda.Rows.Count == 0)
                        {
                            frmCpfCnpj frmCpfn = new frmCpfCnpj(this);
                            frmCpfn.ShowDialog();
                        }

                        PesquisarCodigoBarras();
                    }
                }

                if (e.KeyCode == Keys.F3)
                {
                    try
                    {
                        btnInserirPlaca_Click(sender, e);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }

                if (e.KeyCode == Keys.F12)
                {
                    MessageBox.Show("F1-Fechar Caixa.\n" +
                                    "F5-Listar Produtos.\n" +
                                    "F4-\n" +
                                    "F3-Placa do Veiculo.\n" +
                                    "F10-Login Usuário.\n" +
                                    "(Alt+F1)-Sair Sistema.\n" +
                                    "(Crtl+A)-Vende Ultimo Item.\n" +
                                    "(Crtl+I)-Trocar Logo.\n" +
                                    "Duplo Click-Cancelar Item da Venda.\n" +
                                    "",
                                    "Instruções do Programa               ");
                }

                if (e.KeyCode == Keys.F1)
                {
                    btnFecharcaixa_Click(sender, e);
                }

                if (e.KeyCode == Keys.F10)
                {
                    btnLogin_Click(sender, e);
                }

                if ((e.KeyCode == Keys.F11) || (e.KeyCode == Keys.F7))
                {
                    PesquisarUltimaVenda();
                }

                if ((Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.F) || Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.F7)
                {
                    try
                    {
                        string[] arquivos = null;

                        string end = "";

                        if (cupomFiscal == false)
                        {
                            end = pathDadosVendaAutorizada;

                            arquivos = Directory.GetFiles(end, "*.xml", SearchOption.AllDirectories);

                            if (arquivos != null)
                            {
                                frmVendaXmlSat frmVendaXmlSat = new frmVendaXmlSat(arquivos, numCaixa, cupomFiscal, end, pathXmlCustodiaResp, this);
                                frmVendaXmlSat.ShowDialog();
                            }
                        }
                        else
                        {
                            end = pathXmlCupom;

                            arquivos = Directory.GetFiles(end, "*.xml", SearchOption.AllDirectories);

                            if (arquivos != null)
                            {
                                frmVendaXmlSat frmVendaXmlSat = new frmVendaXmlSat(arquivos, numCaixa, cupomFiscal, end, pathXmlCustodiaResp, this);
                                frmVendaXmlSat.ShowDialog();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Caso Problema Persistir Entre em Contato Com seu Administrador.", "Erro: " + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                if (MessageBox.Show("Deseja Inserir um Novo Operador(a) ?", "Caixa Aberto sem Operador Logado...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    frmLogin login = new frmLogin(this, 2);
                    login.ShowDialog();

                    if (login.DialogResult == DialogResult.OK)
                    {
                        idUsuario = login.idUsuario;

                        this.OnLoad(e);
                    }
                }

                LimparCampos();
            }
        }

        public void EnviarDadosSat(string dadosSat)
        {
            try
            {
                string ret, ano, mes = "";

                getNumberRandom();

                ret = Marshal.PtrToStringAnsi(IMPRESSORA.BematechImpressora.EnviarDadosVenda(sessao, softwareHouse.codAtivacao, dadosSat));

                //separa os retorno por pig (PIPE)
                string ret_sessao = (Sep_Delimitador('|', 0, ret));
                string ret_sat = (Sep_Delimitador('|', 1, ret));
                string ret_erro = (Sep_Delimitador('|', 2, ret));
                string ret_err_ = (Sep_Delimitador('|', 3, ret));
                string ret_nulo1_ = (Sep_Delimitador('|', 4, ret));
                string ret_nulo2 = (Sep_Delimitador('|', 5, ret));
                string ret_desc = (Sep_Delimitador('|', 6, ret));
                string ret_dataVenda = (Sep_Delimitador('|', 7, ret));
                string ret_id = (Sep_Delimitador('|', 8, ret));
                string ret_valorvenda = (Sep_Delimitador('|', 9, ret));
                string ret_nulo3 = (Sep_Delimitador('|', 10, ret));
                string ret_qrCod = (Sep_Delimitador('|', 11, ret));
                string ret_inf = (Sep_Delimitador('|', 12, ret));
                string ret_inf1 = (Sep_Delimitador('|', 13, ret));

                if (ret_sat == "06000")
                {
                    mes = DateTime.Now.Month.ToString().PadLeft(2, '0');
                    ano = DateTime.Now.Year.ToString();

                    chaveCupom = ret_id.Replace("CFe", "").Replace(" ", "").Trim();
                    qrCod = ret_qrCod.Trim();
                    stringRetSat = ret_desc.Trim();

                    SalvarUltimaChave();

                    byte[] senhaBinaria = new byte[256];

                    //Descriptografa....................................................................................................
                    senhaBinaria = Convert.FromBase64String(stringRetSat);

                    string senhaDescripto = ASCIIEncoding.ASCII.GetString(senhaBinaria);

                    //gera arquivo em txt aprovado......................................................................................
                    string strPathFile = (pathDadosVendaAutorizada + numCaixa.ToString().PadLeft(3, '0') + ".txt");

                    using (FileStream fs = File.Create(strPathFile))
                    {
                        using (StreamWriter sw = new StreamWriter(fs))
                        {
                            sw.Write(senhaDescripto);
                            sw.Close();
                        }
                    }

                    string enderecoExitente = (pathCustodia + ano + "\\" + mes + "\\" + "Cx" + numCaixa);

                    if (Directory.Exists(enderecoExitente))
                    {
                        //Converte TXT para XML e Salva em Arquivo XML............................................................................................
                        FileStream sr = new FileStream(strPathFile, FileMode.Open, FileAccess.Read);
                        byte[] bytes = new byte[Convert.ToInt32(sr.Length)];
                        sr.Read(bytes, 0, Convert.ToInt32(sr.Length));
                        FileStream srXml = new FileStream(enderecoExitente + "\\" + chaveCupom + ".xml", FileMode.Create, FileAccess.Write);
                        StreamWriter wr = new StreamWriter(srXml);
                        srXml.Write(bytes, 0, bytes.Length);
                        sr.Close();
                        srXml.Close();
                    }
                    else
                    {
                        Directory.CreateDirectory(enderecoExitente);
                        //Converte TXTpara XML e Salva em Arquivo XML............................................................................................

                        FileStream sr = new FileStream(strPathFile, FileMode.Open, FileAccess.Read);
                        byte[] bytes = new byte[Convert.ToInt32(sr.Length)];
                        sr.Read(bytes, 0, Convert.ToInt32(sr.Length));
                        FileStream srXml = new FileStream(enderecoExitente + "\\" + chaveCupom + ".xml", FileMode.Create, FileAccess.Write);
                        StreamWriter wr = new StreamWriter(srXml);
                        srXml.Write(bytes, 0, bytes.Length);
                        sr.Close();
                        srXml.Close();

                    }

                    ImprimirUltimoCupoFiscal();
                }
                else
                {
                    MessageBox.Show("Retorno: " + ret_err_ + ". Possiveis Erros:\n\n1-CST do Produto.\n2 - Caracteres Especiais\n\nDeseja Continuar Processo Venda?\n\nRetorno XML S@T: " + ret, "Erro de Comunicação S@T", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção");
            }
        }

        private string LerArqTxt(string NomeArq)
        {
            try
            {
                StreamReader arq = new StreamReader(NomeArq);

                NomeArq = arq.ReadToEnd();

                arq.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERRO: " + ex.ToString(), "Erro");

                return "";
            }

            return ConverterToUTF8(NomeArq);
        }

        private string ConverterToUTF8(string dados)  // sempre mandar os dados para o sat em UT8
        {
            byte[] utf16Bytes = Encoding.Unicode.GetBytes(dados);
            byte[] utf8Bytes = Encoding.Convert(Encoding.Unicode, Encoding.UTF8, utf16Bytes);

            return Encoding.Default.GetString(utf8Bytes);
        }

        private void txtTotal_MouseMove(object sender, MouseEventArgs e)
        {
            txtCodBarras.Focus();
            txtCodBarras.SelectAll();
        }

        private void txtNumVenda_MouseMove(object sender, MouseEventArgs e)
        {
            txtCodBarras.Focus();
            txtCodBarras.SelectAll();
        }

        private void txtQtde_MouseMove(object sender, MouseEventArgs e)
        {
            //txtQtde.Focus();
            //txtQtde.SelectAll();
        }

        private void txtPreco_MouseMove(object sender, MouseEventArgs e)
        {
            txtCodBarras.Focus();
            txtCodBarras.SelectAll();
        }

        private void txtSubTotal_MouseMove(object sender, MouseEventArgs e)
        {
            //txtSubTotal.Focus();
            //txtSubTotal.SelectAll();
        }

        private void gdvVenda_MouseMove(object sender, MouseEventArgs e)
        {
            txtCodBarras.Focus();
            txtCodBarras.SelectAll();
        }

        private void txtDescricaoProduto_MouseMove(object sender, MouseEventArgs e)
        {
            txtCodBarras.Focus();
            txtCodBarras.SelectAll();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Realmente Deseja Mudar o Login ???", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                frmLogin login = new frmLogin(this, 2);
                login.ShowDialog();

                if (login.DialogResult == DialogResult.OK)
                {
                    idUsuario = login.idUsuario;

                    this.OnLoad(e);
                }
            }

            LimparCampos();
        }

        public bool altBandeira;

        private void btnBandVerde_ButtonClick(object sender, EventArgs e)
        {
            frmBandeiras frmBandeiras = new frmBandeiras(this);
            frmBandeiras.ShowDialog();

            if (altBandeira == true)
            {
                AlterarCupom(true);
            }
            else
            {
                MessageBox.Show("Não Foi Possivel Altera Bandeira...", "verifique Senha de Alteração", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        public void AlterarCupom(bool status)
        {
            try
            {
                try
                {
                    parametroRegraNegocios = new ParametroRegraNegocios();

                    int idret = parametroRegraNegocios.AlterarCupom(status, numCaixa);

                    MessageBox.Show("Cupom Alterado com Sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadTela();
                }
                catch
                {
                    MessageBox.Show("Erro ao Alterar Cupom.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnBandVermelha_ButtonClick(object sender, EventArgs e)
        {
            frmBandeiras frmBandeiras = new frmBandeiras(this);
            frmBandeiras.ShowDialog();

            if (altBandeira == true)
            {
                AlterarCupom(false);
            }
            else
            {
                MessageBox.Show("Não Foi Possivel Altera Bandeira...", "verifique Senha de Alteração", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void btnMinimizar_ButtonClick(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

            LimparCampos();
        }

        private void btnLogOut_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                pnlMenu.Visible = false;
            }

            LimparCampos();
        }

        public static void Moeda3(ref TextBox txt)
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
                v = Convert.ToDecimal(n) / 1000;
                txt.Text = string.Format("{0:N3}", v);

                txt.SelectionStart = txt.Text.Length;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Registro do Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSangriaDespesa_Click(object sender, EventArgs e)
        {
            btnMenu_ButtonClick(sender, e);

            txtCodBarras.Clear();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (gdvVenda.RowCount == 0)
                {
                    if (MessageBox.Show("Realmente Deseja Mudar o Login ???", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        frmLogin login = new frmLogin(this, 2);
                        login.ShowDialog();

                        if (login.DialogResult == DialogResult.OK)
                        {
                            idUsuario = login.idUsuario;

                            this.OnLoad(e);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Não é Possivél Log-Out... Exite(m) Venda(s) Em Aberto.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }

                LimparCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnFecharcaixa_Click(object sender, EventArgs e)
        {
            try
            {
                if (gdvVenda.Rows.Count == 0)
                {
                    LimparCampos();

                    PesquisarTipoUsuario();

                    if (permissaoAcesso == true)
                    {
                        frmLoginConfiguracao fLoginConfiguracao = new frmLoginConfiguracao(this);
                        fLoginConfiguracao.ShowDialog();
                    }
                    else
                    {
                        try
                        {
                            //MessageBox.Show("Usuário " + nomeOperador + " não está Autorizado para Realizar essa Operação.", "Acesso Negado", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                            frmFechamentoCaixa fFechamentoCaixa = new frmFechamentoCaixa(this);
                            fFechamentoCaixa.ShowDialog();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Exite Venda em Aberto, éPreciso Fechar ou Cancelar a Venda Atual.", "Venda em Aberto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                LimparCampos();
            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
            }
        }

        private void txtSubTotal_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtQtde_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnPesquisarProduto_Click(object sender, EventArgs e)
        {
            try
            {
                txtCodBarras.Focus();

                frmListarProduto fListarProduto = new frmListarProduto(this);
                fListarProduto.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            LimparCampos();

        }

        private void btnMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

            txtCodBarras.Focus();
            txtCodBarras.SelectAll();
        }

        private void btnFecharVenda_Click(object sender, EventArgs e)
        {
            try
            {
                if ((gdvVenda.Rows.Count > 0) && (txtCodBarras.Text != ""))
                {
                    LimparCampos();

                    frmFechamentoVenda fFechamentoVenda = new frmFechamentoVenda(this, frmCliente);
                    fFechamentoVenda.ShowDialog();
                }
                else
                {
                    LimparCampos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            LimparCampos();
        }

        private void btnNotaPaulista_Click(object sender, EventArgs e)
        {
            try
            {
                frmCpfCnpj frmCpfn = new frmCpfCnpj(this);
                frmCpfn.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            LimparCampos();
        }

        private void btnInserirPlaca_Click(object sender, EventArgs e)
        {
            frmPlaca fPlaca = new frmPlaca(this);
            fPlaca.ShowDialog();

            LimparCampos();
        }

        private void txtNumVenda_MouseMove_1(object sender, MouseEventArgs e)
        {
            txtCodBarras.Focus();
            txtCodBarras.SelectAll();
        }

        private void txtTotal_MouseMove_1(object sender, MouseEventArgs e)
        {
            txtCodBarras.Focus();
            txtCodBarras.SelectAll();
        }

        private void txtCodBarras_KeyDown(object sender, KeyEventArgs e)
        {
            if (idUsuario > 0)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if ((txtCodBarras.Text != "") && (txtCodBarras.Text != null))
                    {
                        if ((gdvVenda.Rows.Count == 0) && (txtCodBarras.Text != ""))
                        {
                            if (cupomFiscal == true)
                            {
                                frmCpfCnpj frmCpfn = new frmCpfCnpj(this);
                                frmCpfn.ShowDialog();
                            }
                        }

                        codigoBarrasProduto = txtCodBarras.Text;
                        codigoBarrasProduto = codigoBarrasProduto.Trim().PadLeft(13, '0');
                        txtCodBarras.Text = codigoBarrasProduto;

                        if (txtCodBarras.Text.Substring(0, 1).Trim() == "2")
                        {
                            //adiciona seguintes 0 concatenando os mesmos.......................................
                            string codProd = txtCodBarras.Text.PadLeft(13, '0');
                            codigoBarrasProduto = txtCodBarras.Text.Substring(1, parametroEtiqueta).Trim();

                            //pesquisar peso do produto.........................................................
                            string codQtde = codProd.Substring(7, 5);

                            decimal qtde = (Convert.ToDecimal(codQtde) / 1000);
                            txtQtde.Text = qtde.ToString();

                            txtCodBarras.Text = codigoBarrasProduto.PadLeft(13, '0');
                        }

                        PesquisarCodigoBarras();
                    }
                    else
                    {
                        LimparCampos();
                    }
                }

                if (e.KeyCode == Keys.Escape)
                {
                    LimparCampos();

                    //btnMinimizar_ButtonClick(sender, e);
                }

                if (e.KeyCode == Keys.Back)
                {
                    //e.Handled = false;
                    //txtCodigoBarras.SelectionStart = txtCodigoBarras.Text.Length -1;
                }

                if (Control.ModifierKeys == Keys.Alt && e.KeyCode == Keys.F1)
                {
                    if (gdvVenda.Rows.Count <= 0)
                    {
                        if (MessageBox.Show("Deseja Sair Do Sistema", "Sair", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                        {
                            this.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Para Sair do Sistema é Preciso Fechar Venda em Aberto.", "Fechar Venda", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                if (e.KeyCode == Keys.F8)
                {
                    btnMenu_ButtonClick(sender, e);

                    txtCodBarras.Clear();
                }

                if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.A)
                {
                    PesquisarUltimoItemVendido();

                    txtCodBarras.Clear();
                }

                if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.I)
                {
                    TrocarLogo();

                    txtCodBarras.Clear();
                }

                if (e.KeyCode == Keys.Add)
                {
                    PesquisarUltimoItemVendido();

                    txtCodBarras.Clear();
                }

                if (e.KeyCode == Keys.F2)
                {
                    btnNotaPaulista_Click(sender, e);
                }

                if (e.KeyCode == Keys.F5)
                {
                    frmListarProduto fListarProduto = new frmListarProduto(this);
                    fListarProduto.ShowDialog();

                    if ((codigoBarrasProduto != null) && (codigoBarrasProduto != ""))
                    {
                        if (gdvVenda.Rows.Count == 0)
                        {
                            frmCpfCnpj frmCpfn = new frmCpfCnpj(this);
                            frmCpfn.ShowDialog();
                        }

                        PesquisarCodigoBarras();
                    }
                }

                if (e.KeyCode == Keys.F3)
                {
                    try
                    {
                        btnInserirPlaca_Click(sender, e);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }

                if (e.KeyCode == Keys.F12)
                {
                    MessageBox.Show("F1-Fechar Caixa.\n" +
                                    "F5-Listar Produtos.\n" +
                                    "F4-\n" +
                                    "F3-Placa do Veiculo.\n" +
                                    "F10-Login Usuário.\n" +
                                    "(Alt+F1)-Sair Sistema.\n" +
                                    "(Crtl+A)-Vende Ultimo Item.\n" +
                                    "(Crtl+I)-Trocar Logo.\n" +
                                    "Duplo Click-Cancelar Item da Venda.\n" +
                                    "",
                                    "Instruções do Programa               ");
                }

                if (e.KeyCode == Keys.F1)
                {
                    btnFecharcaixa_Click(sender, e);
                }

                if (e.KeyCode == Keys.F10)
                {
                    btnLogin_Click(sender, e);
                }

                if ((e.KeyCode == Keys.F11) || (e.KeyCode == Keys.F7))
                {
                    PesquisarUltimaVenda();
                }

                if ((Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.F) || Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.F7)
                {
                    try
                    {
                        string[] arquivos = null;

                        string end = "";

                        if (cupomFiscal == false)
                        {
                            end = pathDadosVendaAutorizada;

                            arquivos = Directory.GetFiles(end, "*.xml", SearchOption.AllDirectories);

                            if (arquivos != null)
                            {
                                frmVendaXmlSat frmVendaXmlSat = new frmVendaXmlSat(arquivos, numCaixa, cupomFiscal, end, pathXmlCustodiaResp, this);
                                frmVendaXmlSat.ShowDialog();
                            }
                        }
                        else
                        {
                            end = pathXmlCupom;

                            arquivos = Directory.GetFiles(end, "*.xml", SearchOption.AllDirectories);

                            if (arquivos != null)
                            {
                                frmVendaXmlSat frmVendaXmlSat = new frmVendaXmlSat(arquivos, numCaixa, cupomFiscal, end, pathXmlCustodiaResp, this);
                                frmVendaXmlSat.ShowDialog();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Caso Problema Persistir Entre em Contato Com seu Administrador.", "Erro: " + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                if (MessageBox.Show("Deseja Inserir um Novo Operador(a) ?", "Caixa Aberto sem Operador Logado...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    frmLogin login = new frmLogin(this, 2);
                    login.ShowDialog();

                    if (login.DialogResult == DialogResult.OK)
                    {
                        idUsuario = login.idUsuario;

                        this.OnLoad(e);
                    }
                }

                LimparCampos();
            }
        }

        private void txtCodBarras_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                if (idTipoVenda == 2 && cupomFiscal == false)
                {
                    MessageBox.Show("Não é Possivel Realizar Venda Não Fiscal com Ambiente NFC-e.", "Alterar Sistema para Ambiente S@T.", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                    txtCodBarras.Focus();
                    txtCodBarras.SelectAll();
                }
                else
                {
                    VenderItemTxt();

                    btnFecharVenda_Click(sender, e);
                }
            }

            if (txtCodBarras.Text.Trim() != "")
            {
            }

            if ((e.KeyCode == Keys.X) || (e.KeyCode == Keys.Multiply))
            {
                txtQtde.ReadOnly = false;
                txtQtde.Focus();
                txtQtde.SelectAll();

                this.txtCodBarras.Text = "";
            }

            if (e.KeyCode == Keys.Subtract)
            {
                CancelarItemVendaLogin();
            }
        }

        private void txtCodBarras_TextChanged(object sender, EventArgs e)
        {
            if (txtCodBarras.Text.Trim().Trim().Equals("/"))
            {
                txtCodBarras.Text = "";
                txtCodBarras.SelectAll();
            }
            else if (txtCodBarras.Text.Trim().Trim().Equals("*"))
            {
                txtCodBarras.Text = "";
                txtCodBarras.SelectAll();
            }
            else if (txtCodBarras.Text.Trim().Trim().Equals("-"))
            {
                txtCodBarras.Text = "";
                txtCodBarras.SelectAll();
            }
            else if (txtCodBarras.Text.Trim().Trim().Equals("."))
            {
                txtCodBarras.Text = "";
                txtCodBarras.SelectAll();
            }
            else if (txtCodBarras.Text.Trim().Trim().Equals("+"))
            {
                txtCodBarras.Text = "";
                txtCodBarras.SelectAll();
            }
            else if (txtCodBarras.Text.Trim().Trim().Equals("."))
            {
                txtCodBarras.Text = "";
                txtCodBarras.SelectAll();
            }
            else if (txtCodBarras.Text.Trim().Trim().Equals(","))
            {
                txtCodBarras.Text = "";
                txtCodBarras.SelectAll();
            }
            else if (txtCodBarras.Text.Trim().Trim().Equals("?"))
            {
                txtCodBarras.Text = "";
                txtCodBarras.SelectAll();
            }
            else if (txtCodBarras.Text.Trim().Trim().Equals("!"))
            {
                txtCodBarras.Text = "";
                txtCodBarras.SelectAll();
            }
            else if (txtCodBarras.Text.Trim().Trim().Equals("@"))
            {
                txtCodBarras.Text = "";
                txtCodBarras.SelectAll();
            }
            else if (txtCodBarras.Text.Trim().Trim().Equals("#"))
            {
                txtCodBarras.Text = "";
                txtCodBarras.SelectAll();
            }
            else if (txtCodBarras.Text.Trim().Trim().Equals("$"))
            {
                txtCodBarras.Text = "";
                txtCodBarras.SelectAll();
            }
            else if (txtCodBarras.Text.Trim().Trim().Equals("%"))
            {
                txtCodBarras.Text = "";
                txtCodBarras.SelectAll();
            }
            else if (txtCodBarras.Text.Trim().Trim().Equals("¨"))
            {
                txtCodBarras.Text = "";
                txtCodBarras.SelectAll();
            }
            else if (txtCodBarras.Text.Trim().Trim().Equals("&"))
            {
                txtCodBarras.Text = "";
                txtCodBarras.SelectAll();
            }
            else if (txtCodBarras.Text.Trim().Trim().Equals("("))
            {
                txtCodBarras.Text = "";
                txtCodBarras.SelectAll();
            }
            else if (txtCodBarras.Text.Trim().Trim().Equals(")"))
            {
                txtCodBarras.Text = "";
                txtCodBarras.SelectAll();
            }
            else if (txtCodBarras.Text.Trim().Trim().Equals("="))
            {
                txtCodBarras.Text = "";
                txtCodBarras.SelectAll();
            }
            else if (txtCodBarras.Text.Trim().Trim().Equals(":"))
            {
                txtCodBarras.Text = "";
                txtCodBarras.SelectAll();
            }
            else if (txtCodBarras.Text.Trim().Trim().Equals(";"))
            {
                txtCodBarras.Text = "";
                txtCodBarras.SelectAll();
            }
        }

        private void btnMin_MouseMove(object sender, MouseEventArgs e)
        {
            txtCodBarras.Focus();
            txtCodBarras.SelectAll();
        }

        private void btnCancelarItemVenda_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

            LimparCampos();
        }

        public void PesquisarCodigoBarras()
        {
            try
            {
                produtoRegraNegocios = new ProdutoRegraNegocios();
                produtoC = new ProdutoC();
                DataTable dadosTabelaProduto = new DataTable();

                filtrar = new FILTRAR();

                produtoC.codBarra = codigoBarrasProduto.PadLeft(13,'0').Trim();

                dadosTabelaProduto = produtoRegraNegocios.PesquisaProdutoCodigoBarras(produtoC);

                if (dadosTabelaProduto.Rows.Count > 0)
                {
                    //ATRIBUI VALORES AS VARIAVEIS DA DATATABLE
                    //DADOS TABELA PRODUTO
                    produtoId = Convert.ToInt32(dadosTabelaProduto.Rows[0]["COD_INT"].ToString());
                    numDeparatmento = Convert.ToInt32(dadosTabelaProduto.Rows[0]["NUM_DEPAR"].ToString());
                    codigoBarrasProduto = dadosTabelaProduto.Rows[0]["COD_BARRA"].ToString().Trim();
                    descricaoProduto = filtrar.RemoverAcentos(dadosTabelaProduto.Rows[0]["DESCRICAO"].ToString().Trim()).ToUpper();
                    precoProd = Convert.ToDecimal(dadosTabelaProduto.Rows[0]["PRECO"].ToString());
                    unid = dadosTabelaProduto.Rows[0]["UNID"].ToString().Trim();
                    aliquota = dadosTabelaProduto.Rows[0]["TRIB"].ToString().Trim();
                    estoque = Convert.ToDecimal(dadosTabelaProduto.Rows[0]["ESTOQUE"].ToString()).ToString("N2");
                    ncm = dadosTabelaProduto.Rows[0]["NCM"].ToString().Trim();
                    cfop = dadosTabelaProduto.Rows[0]["CFOP"].ToString().Trim();
                    granel = dadosTabelaProduto.Rows[0]["GRANEL"].ToString().Trim();
                    custo = Convert.ToDecimal(dadosTabelaProduto.Rows[0]["CUSTO"].ToString());
                    setor = Convert.ToInt32(dadosTabelaProduto.Rows[0]["SETOR"].ToString());
                    valorPis = dadosTabelaProduto.Rows[0]["VALOR_PIS"].ToString().Trim();
                    cstPis = dadosTabelaProduto.Rows[0]["CST_PIS"].ToString().Trim();
                    valorCofins = dadosTabelaProduto.Rows[0]["VALOR_CONFINS"].ToString().Trim();
                    cstCofins = dadosTabelaProduto.Rows[0]["CST_COFINS"].ToString().Trim();
                    origemProduto = dadosTabelaProduto.Rows[0]["ORIGEM_PRODUTO"].ToString().Trim();
                    icms = dadosTabelaProduto.Rows[0]["ICMS"].ToString().Trim();
                    icmsCst = dadosTabelaProduto.Rows[0]["ICMS_CST"].ToString().Trim();
                    cest = dadosTabelaProduto.Rows[0]["CEST"].ToString().Trim();
                    anp = dadosTabelaProduto.Rows[0]["ANP"].ToString().Trim() ?? null ?? "";
                    vendaC.unid = dadosTabelaProduto.Rows[0]["UNID"].ToString().Trim();

                    numVenda = Convert.ToInt32(txtNumVenda.Text);

                    if (gdvVenda.Rows.Count <= 0)
                    {
                        itemVenda = 1;
                    }
                    else
                    {
                        itemVenda = (gdvVenda.Rows.Count + 1);
                    }

                    //PREENCHER TEXBOX
                    txtDescricaoProduto.Text = descricaoProduto;
                    txtCodBarras.Text = codigoBarrasProduto.PadLeft(13, '0').Trim();
                    txtPreco.Text = precoProd.ToString("N3");

                    if (precototal.Trim().Equals("P"))
                    {
                        txtCodBarras.Text = codigoBarrasProduto;
                        txtPreco.ReadOnly = false;
                        txtPreco.Text = precoProd.ToString();
                        txtPreco.Focus();
                    }
                    else
                    {
                        if ((granel == "T") || (granel == "t"))
                        {
                            txtSubTotal.ReadOnly = false;
                            txtSubTotal.Focus();
                            txtSubTotal.SelectAll();
                        }

                        if ((granel == "P") || (granel == "p"))
                        {
                            txtCodBarras.Text = codigoBarrasProduto;
                            txtPreco.ReadOnly = false;
                            txtPreco.Text = precoProd.ToString();
                            txtPreco.Focus();
                        }

                        if ((granel == "C") || (granel == "c"))
                        {
                        }

                        if ((granel == "B") || (granel == "b"))
                        {
                            PesquisarSerialPorta();
                        }

                        if ((granel == "") || (granel == null))
                        {
                            //ATRIBUIR VALORES AS VARIAVEIS
                            qtdeProd = Convert.ToDecimal(txtQtde.Text);
                            precoProd = Convert.ToDecimal(txtPreco.Text);
                            subTotal = (qtdeProd * precoProd);

                            string qtdeF = String.Format("{0:N3}", qtdeProd);

                            VenderItem();
                        }

                        //PESQUISAR PRODUTO SE EH PRIBIDO PARA MENORES DE IDADE
                        PesquisarDeparatemntoProduto();

                        if (avisoProduto == true)
                        {
                            frmAvisoProibido fAvispProibido = new frmAvisoProibido(this);
                            fAvispProibido.ShowDialog();
                        }
                    }
                }
                else
                {
                    if (MessageBox.Show("Produto Código de Barras " + codigoBarrasProduto + " não foi Encontrado...", "Produto não Encontrado", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        txtCodBarras.Text = "";
                        txtCodBarras.Focus();
                    }
                    else
                    {
                        PesquisarCodigoBarras();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção");

                LimparCampos();
            }
        }

        public void PesquisarDeparatemntoProduto()
        {
            try
            {
                DepartamentoC depatamentoC = new DepartamentoC();
                DepartamentoRegraNegocios departamentoRegraNegocios = new DepartamentoRegraNegocios();
                DataTable dadosTabelaDepartamento = new DataTable();

                depatamentoC.idDepartamento = numDeparatmento.ToString();

                dadosTabelaDepartamento = departamentoRegraNegocios.PesquisarDeparatemntoProduto(depatamentoC);

                if (dadosTabelaDepartamento.Rows.Count > 0)
                {
                    try
                    {
                        avisoProduto = Convert.ToBoolean(dadosTabelaDepartamento.Rows[0]["AVISO"].ToString());
                    }
                    catch
                    {
                        avisoProduto = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public char Chr(int codigo)
        {
            return (char)codigo;
        }

        public string ExtractNumber(string original)
        {
            return new string(original.Where(c => Char.IsDigit(c)).ToArray());
        }

        public void PesquisarSerialPorta()
        {
            try
            {
                _serialPort = new SerialPort();

                _serialPort = new SerialPort("COM3", Convert.ToInt32(bondRouteCom), Parity.None, 8, StopBits.One);
                _serialPort.Handshake = Handshake.None;

                if (_serialPort.IsOpen)
                {
                    _serialPort.Close();
                }
                else
                {
                    _serialPort.Open();

                    //metodo Chr para buscar e converter na tabela Hexadecimal............................
                    _serialPort.WriteLine(Chr(5).ToString());

                    //  Espera();

                    // Aguarda dois segundos...
                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(0.4));

                    peso = _serialPort.ReadExisting().ToString();

                    //metodo ExtractNumber extrai os valores hexadecima e converte para string............
                    peso = ExtractNumber(peso);

                    if (peso != "00000")
                    {
                        if (peso != "")
                        {
                            decimal qtde = Convert.ToDecimal(peso);
                            decimal soma = 0;

                            soma = (qtde / 1000);
                            peso = soma.ToString("N3");

                            subTotal = (precoProd * Convert.ToDecimal(peso));

                            txtQtde.Text = peso;
                            qtdeProd = Convert.ToDecimal(peso);

                            try
                            {
                                if (tempoTotal < 2000)
                                {
                                    VenderItem();
                                }
                                else
                                {
                                    txtQtde.Enabled = true;
                                    txtQtde.ReadOnly = true;
                                    txtQtde.Focus();
                                }
                            }
                            catch
                            {
                                MessageBox.Show("Erro.");

                                if (_serialPort.IsOpen)
                                {
                                    _serialPort.Close();
                                }
                            }
                        }
                        else
                        {
                            txtQtde.Enabled = true;
                            txtQtde.ReadOnly = false;
                            txtQtde.Text = "0,00";
                            txtQtde.Focus();
                        }

                        _serialPort.Close();
                    }
                    else
                    {
                        _serialPort.Close();
                        txtCodBarras.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("PESAR NOVAMENTE.\n" + ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);

                if (_serialPort.IsOpen)
                {
                    _serialPort.Close();
                }
            }
        }

        public void VenderItem()
        {
            try
            {
                if (string.IsNullOrEmpty(codigoBarrasProduto))
                {
                    MessageBox.Show("Código de Barras não Pode ser Nulo ou Vázio", "Atenção");
                    txtCodBarras.Focus();
                }
                else if (string.IsNullOrEmpty(descricaoProduto))
                {
                    MessageBox.Show("Produto não Pode ser Nulo ou Vázio", "Atenção");
                    txtCodBarras.Focus();
                }

                else if (qtdeProd <= 0)
                {
                    MessageBox.Show("Quantidade de Venda não Pode ser Menor ou Igual a Zero", "Atenção");
                    txtCodBarras.Focus();
                }

                else if (subTotal <= 0)
                {
                    MessageBox.Show("Total de Venda não Pode ser Menor ou Igual a Zero", "Atenção");
                    txtCodBarras.Focus();
                }
                else if (itemVenda <= 0)
                {
                    MessageBox.Show("Item de Venda não Pode ser Menor ou Igual a Zero", "Atenção");
                    txtCodBarras.Focus();
                }

                else if (datavenda == null)
                {
                    MessageBox.Show("Data da Venda não Pode ser Menor ou Igual a Zero", "Atenção");
                    txtCodBarras.Focus();
                }

                else if (produtoId <= 0)
                {
                    MessageBox.Show("Codigo do Produto não Pode ser Menor ou Igual a Zero", "Atenção");
                    txtCodBarras.Focus();
                }

                else if (idUsuario <= 0)
                {
                    MessageBox.Show("Codigo do Usuário não Pode ser Menor ou Igual a Zero", "Atenção");
                    txtCodBarras.Focus();
                }

                else if (numVenda <= 0)
                {
                    MessageBox.Show("Numero de Venda não Pode ser Menor ou Igual a Zero", "Atenção");
                    txtCodBarras.Focus();
                }
                else if (numCaixa <= 0)
                {
                    MessageBox.Show("Numro do Caixa não Pode ser Menor ou Igual a Zero", "Atenção");
                    txtCodBarras.Focus();
                }
                else if (precoProd <= 0)
                {
                    MessageBox.Show("Preço do Produto não Pode ser Menor ou Igual a Zero", "Atenção");
                    txtCodBarras.Focus();
                }
                else
                {
                    PesquisarLimiteSat();

                    if (valorVendaSat <= limiteCompra)
                    {
                        vendaC = new VendaC();
                        vendaRegraNegocios = new VendaRegraNegocios();

                        decimal qtde = Math.Round(qtdeProd, 5);
                        decimal preco = Math.Round(precoProd, 3);
                        decimal somas = Math.Round((qtde * preco), 3);

                        vendaC.codBarra = codigoBarrasProduto.PadLeft(13, '0');
                        vendaC.descricao = descricaoProduto;
                        vendaC.qtde = qtde;
                        vendaC.subTotal = Convert.ToDecimal((Convert.ToDecimal(qtdeProd) * Convert.ToDecimal(precoProd)).ToString("N5"));
                        vendaC.item = (itemVenda);
                        vendaC.dtVenda = DateTime.Now;
                        vendaC.idProduto = produtoId;
                        vendaC.idUsuario = idUsuario;
                        vendaC.custo = custo;
                        vendaC.baixado = baixado;
                        vendaC.numVenda = numVenda;
                        vendaC.aliquota = aliquota;
                        vendaC.precoProduto = preco;
                        vendaC.valorPis = valorPis;
                        vendaC.cstPis = cstPis;
                        vendaC.valorCofins = valorCofins;
                        vendaC.cstCofins = cstCofins;
                        vendaC.cfop = cfop;
                        vendaC.ncm = ncm;
                        vendaC.origemProduto = origemProduto;
                        vendaC.icmsCst = icmsCst;
                        vendaC.fech = fech;
                        vendaC.cest = cest;
                        vendaC.numCaixa = numCaixa;
                        vendaC.anp = anp;
                        vendaC.unid = unid;
                        vendaC.tag = cupomFiscal;

                        string idRetornoVenda = vendaRegraNegocios.VenderItem(vendaC);

                        try
                        {
                            Convert.ToInt32(idRetornoVenda);

                            //VenderItemTxt();
                            gdvVenda.Refresh();
                            gdvVenda.Update();
                            LimparCampos();
                            ListarGrid();
                        }
                        catch
                        {
                            MessageBox.Show("Erro ao Cadastrar Venda, Verifique se Exite(m) dados com valor(es) Obrigatório, ou entre em Contato com seu Administrador", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            LimparCampos();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Valor da Venda Acima do Permitido pela SEFAZ", "Limite de Venda S@T", MessageBoxButtons.OK, MessageBoxIcon.None);

                        LimparCampos();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção");
            }
        }

        public void PesquisarLimiteSat()
        {
            try
            {
                //ARITIMETICA PARA COMPRAR VALOR DA VENDA
                string vv = txtTotal.Text;

                vv = vv.Replace("R$", "");

                valorVendaSat = Convert.ToDecimal(vv);
                valorVendaSat = (valorVendaSat + subTotal);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção");
            }
        }

        public void LimparCampos()
        {
            //limpa os campos
            txtCodBarras.Text = "";
            txtQtde.Text = "1,000";
            txtSubTotal.Text = "0,000";
            txtPreco.Text = "0,000";

            //bloqueia os texbox
            txtPreco.ReadOnly = true;
            txtQtde.ReadOnly = true;
            txtSubTotal.ReadOnly = true;

            txtCodBarras.Focus();
            txtCodBarras.Text = "";
            condutor = "";
            km = "";
            descPlaca = "";
            idCliente = 0;

            if (gdvVenda.Rows.Count <= 0)
            {
                PrintarHora();
            }

            if (gdvVenda.Rows.Count > 0)
            {
                try
                {
                    txtDescricaoProduto.Text = gdvVenda.Rows[gdvVenda.Rows.Count - 1].Cells[3].Value.ToString();
                }
                catch
                {
                    txtDescricaoProduto.Text = "";
                }
            }
            else
            {
                PrintarHora();
            }

            pnlMenu.Visible = false;
        }

        public List<VENDAS> listaVendas = new List<VENDAS>();

        public void ListarGrid()
        {
            try
            {
                somaVenda = 0;
                int linha = 0;

                vendaC = new VendaC();
                vendaRegraNegocios = new VendaRegraNegocios();
                DataTable dadosTabelaVenda = new DataTable();

                if (agruparVenda == true)
                {
                    dadosTabelaVenda = vendaRegraNegocios.PesquisarVendaAgrupada(numCaixa, numVenda);
                }
                else
                {
                    dadosTabelaVenda = vendaRegraNegocios.PesquisarVenda(numCaixa, numVenda);
                }

                if (dadosTabelaVenda.Rows.Count > 0)
                {
                    listaVendas = new List<VENDAS>();

                    for (int i = 0; i < dadosTabelaVenda.Rows.Count; i++)
                    {
                        linha = (i + 1);
                        listaVendas.Add(new VENDAS()
                        {
                            itemVenda = linha.ToString(),
                            idProd = Convert.ToInt32(dadosTabelaVenda.Rows[i]["ID_PROD"].ToString()),
                            qtde = Convert.ToDecimal(dadosTabelaVenda.Rows[i]["QUANT"].ToString()).ToString(),
                            IdVenda = Convert.ToInt32(dadosTabelaVenda.Rows[i]["ID"].ToString()),
                        });
                    }

                    //GetVenda(listaVendas);

                    gdvVenda.DataSource = null;
                    gdvVenda.DataSource = dadosTabelaVenda;

                    txtDescricaoProduto.Text = gdvVenda.Rows[gdvVenda.Rows.Count - 1].Cells["colDescricao"].Value.ToString();

                    pbxLogo.Visible = false;
                    panelLogo.Visible = false;

                    ApontarUltimaLinhaGrid();

                    itemVenda = gdvVenda.Rows.Count;

                    lblItem.Text = itemVenda.ToString().PadLeft(3, '0');
                }
                else
                {
                    gdvVenda.DataSource = null;
                    pbxLogo.Visible = true;
                    panelLogo.Visible = true;
                    lblItem.Text = "000";
                    txtTotal.Text = "0,00";
                }

                if (gdvVenda.Rows.Count > 0)
                {
                    decimal soma = 0;

                    for (int i = 0; i < gdvVenda.Rows.Count; i++)
                    {
                        string va = Convert.ToDecimal(gdvVenda.Rows[i].Cells["colTotal"].Value.ToString()).ToString("N2");

                        soma += Convert.ToDecimal(va);

                        gdvVenda.Rows[i].Cells["colItem"].Value = (i + 1).ToString().PadLeft(3, '0');
                    }

                    txtTotal.Text = (soma).ToString("N2");

                    somaVenda = Convert.ToDecimal(txtTotal.Text);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção");
            }
        }

        public void GetVenda(List<VENDAS> lista)
        {
            try
            {
                vendaRegraNegocios = new VendaRegraNegocios();

                int idRet = vendaRegraNegocios.AdicionarVendatemp(listaVendas);

                if (idRet == 0)
                {
                    MessageBox.Show("Erro ao Salvar Venda Tabela Temp.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void ApontarUltimaLinhaGrid()
        {
            try
            {
                if (gdvVenda.Rows.Count > 0)
                {
                    gdvVenda.FirstDisplayedScrollingRowIndex = gdvVenda.Rows.Count - 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtSubTotal_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    //ATRIBUIR VALORES AS VARIAVEIS
                    if (txtSubTotal.Text != "0,000")
                    {
                        precoProd = Convert.ToDecimal(txtPreco.Text);
                        subTotal = Convert.ToDecimal(txtSubTotal.Text);
                        qtdeProd = (subTotal / precoProd);

                        string qtdeF = String.Format("{0:N3}", qtdeProd);

                        if (subTotal > 0)
                        {
                            VenderItem();
                        }
                        else
                        {
                            txtSubTotal.Focus();
                        }
                    }
                }

                if (e.KeyCode == Keys.Escape)
                {
                    LimparCampos();
                }
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

                txtNumVenda.Text = nVenda.Rows[0]["NUM_VENDA"].ToString().PadLeft(10, '0');

                cupomFiscal = Convert.ToBoolean(nVenda.Rows[0]["BANDEIRA"].ToString());

                numVenda = Convert.ToInt32(nVenda.Rows[0]["NUM_VENDA"].ToString());

                precototal = nVenda.Rows[0]["PRECO_TOTAL"].ToString().Trim();

                imprimirCupom = Convert.ToBoolean(nVenda.Rows[0]["CUPOM"].ToString().Trim());

                tipoVenda = Convert.ToInt32(nVenda.Rows[0]["TIPO_VENDA"].ToString().Trim().Substring(0, 1));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atencao");
            }
        }

        private void gdvVenda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                LimparCampos();
            }
        }

        private void txtQtde_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F5)
                {
                    btnFecharcaixa_Click(sender, e);
                }

                if (e.KeyCode == Keys.Enter)
                {
                    if (txtCodBarras.Text.Trim().Equals(""))
                    {
                        txtCodBarras.Focus();
                        txtCodBarras.SelectAll();
                    }
                    else
                    {
                        //ATRIBUIR VALORES AS VARIAVEIS
                        qtdeProd = Convert.ToDecimal(txtQtde.Text);
                        precoProd = Convert.ToDecimal(txtPreco.Text);
                        subTotal = (qtdeProd * precoProd);

                        string qtdeF = String.Format("{0:N5}", qtdeProd);

                        VenderItem();
                    }
                }

                if (e.KeyCode == Keys.Escape)
                {
                    LimparCampos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtPreco_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    //ATRIBUIR VALORES AS VARIAVEIS
                    precoProd = Convert.ToDecimal(txtPreco.Text);
                    qtdeProd = Convert.ToDecimal(txtQtde.Text);
                    subTotal = Convert.ToDecimal(precoProd * qtdeProd);

                    string qtdeF = String.Format("{0:N3}", qtdeProd);

                    if (qtdeProd > 0)
                    {
                        VenderItem();
                    }
                    else
                    {
                        txtQtde.Focus();
                    }
                }

                if (e.KeyCode == Keys.Escape)
                {
                    txtCodBarras.Text = "";
                    txtPreco.Text = "0,000";
                    txtCodBarras.Focus();
                    txtCodBarras.SelectAll();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnConfiguracao_ButtonClick(object sender, EventArgs e)
        {
            try
            {
                LimparCampos();

                PesquisarTipoUsuario();

                if (permissaoAcesso == true)
                {
                    frmLoginConfiguracao fLoginConfiguracao = new frmLoginConfiguracao(this);
                    fLoginConfiguracao.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Usuário " + nomeOperador + " não está Autorizado para Realizar essa Operação", "Acesso Negado", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void gdvVenda_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                tipoCancelamento = 2;

                idvenda = Convert.ToInt32(gdvVenda.Rows[e.RowIndex].Cells["colIdVenda"].Value.ToString());
                produtoId = Convert.ToInt32(gdvVenda.Rows[e.RowIndex].Cells["colIdProd"].Value.ToString());
                itemVenda = linha = Convert.ToInt32(gdvVenda.Rows[e.RowIndex].Cells["colItem"].Value.ToString());
                qtdevenda = Convert.ToDecimal(gdvVenda.Rows[e.RowIndex].Cells["colQtde"].Value.ToString());
                precoProd = Convert.ToDecimal(gdvVenda.Rows[e.RowIndex].Cells["colPreco"].Value.ToString());
                totalVenda = Convert.ToDecimal(gdvVenda.Rows[e.RowIndex].Cells["colTotal"].Value.ToString());
                codigoBarrasProduto = gdvVenda.Rows[e.RowIndex].Cells["colCodBarras"].Value.ToString();
                descricaoProduto = gdvVenda.Rows[e.RowIndex].Cells["colDescricao"].Value.ToString();

                frmCancelarItemVenda fCancelaItemVenda = new frmCancelarItemVenda(this);
                fCancelaItemVenda.ShowDialog();

                LimparCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção");
            }
        }

        public void CancelarVenda()
        {
            try
            {
                if (gdvVenda.Rows.Count > 0)
                {
                    if (MessageBox.Show("Realmente Deseja Cancela Venda Nº: " + numVenda.ToString().Trim().PadLeft(3, '0'), "Cancelar Venda", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        for (int i = 0; i < gdvVenda.Rows.Count; i++)
                        {
                            codigoBarrasProduto = gdvVenda.Rows[i].Cells["colCodBarras"].Value.ToString();
                            descricaoProduto = gdvVenda.Rows[i].Cells["colDescricao"].Value.ToString();
                            qtdeProd = Convert.ToDecimal(gdvVenda.Rows[i].Cells["colQtde"].Value.ToString());
                            subTotal = Convert.ToDecimal(gdvVenda.Rows[i].Cells["colTotal"].Value.ToString());
                            vendaC.item = Convert.ToInt32(gdvVenda.Rows[i].Cells["colItem"].Value.ToString());
                            precoProd = Convert.ToDecimal(gdvVenda.Rows[i].Cells["colPreco"].Value.ToString());
                            //  idvenda = Convert.ToInt32(gdvVenda.Rows[i].Cells["colIdVenda"].Value.ToString());
                            unid = gdvVenda.Rows[i].Cells["colUnid"].Value.ToString().Trim();
                            cfop = gdvVenda.Rows[i].Cells["colCfop"].Value.ToString().Trim();
                            aliquota = gdvVenda.Rows[i].Cells["colTrib"].Value.ToString().Trim();

                            vendaC.dtVenda = DateTime.Now;
                            produtoId = Convert.ToInt32(gdvVenda.Rows[i].Cells["colIdProd"].Value.ToString());
                            vendaC.idUsuario = idUsuario;
                            vendaC.custo = 0;
                            vendaC.baixado = false;
                            vendaC.numVenda = numVenda;
                            vendaC.aliquota = aliquota;
                            vendaC.precoProduto = (precoProd * -1);
                            vendaC.valorPis = "";
                            vendaC.cstPis = "";
                            vendaC.valorCofins = "";
                            vendaC.cstCofins = "";
                            vendaC.cfop = cfop;
                            vendaC.ncm = "";
                            vendaC.origemProduto = "";
                            vendaC.icmsCst = "";
                            vendaC.fech = false;
                            vendaC.cest = "";
                            vendaC.numCaixa = numCaixa;
                            vendaC.anp = "";
                            vendaC.unid = unid;
                            vendaC.tag = cupomFiscal;

                            //NEGATIVAR OS VALORES DA(S) VENDA(S) CANCELADA(S)
                            vendaC.idProduto = produtoId;
                            vendaC.codBarra = codigoBarrasProduto;
                            vendaC.descricao = descricaoProduto;
                            vendaC.qtde = (qtdeProd * -1);
                            vendaC.preco = (precoProd * -1);
                            vendaC.subTotal = (subTotal * -1);

                            string idRetornoVenda = vendaRegraNegocios.VenderItem(vendaC);

                            try
                            {
                                Convert.ToInt32(idRetornoVenda);
                                gdvVenda.Refresh();
                                gdvVenda.Update();
                            }
                            catch
                            {
                                MessageBox.Show("Erro ao Cadastrar Venda, Verifique se Exite(m) dados com valor(es) Obrigatório, ou entre em Contato com seu Administrador", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                LimparCampos();
                            }

                            //ALTERAR STATUS FECH DA TABELA VENDA

                            vendaC.vendaId = idvenda;
                            vendaC.fech = true;

                            vendaRegraNegocios = new VendaRegraNegocios();

                            string idretorno = vendaRegraNegocios.FecharStatusVenda(vendaC);

                            try
                            {
                                Convert.ToInt32(idRetornoVenda);
                                gdvVenda.Refresh();
                                gdvVenda.Update();
                            }
                            catch
                            {
                                MessageBox.Show("Erro ao Alterar Status Fech da Venda, Verifique se Exite(m) dados com valor(es) Obrigatório, ou entre em Contato com seu Administrador", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                LimparCampos();
                            }
                        }

                        LimparCampos();
                        ListarGrid();
                        AlterarNumeroVenda();
                        DeletarTemp();
                    }
                    else
                    {
                        LimparCampos();
                    }
                }
                else
                {
                    MessageBox.Show("Não Contém Venda(s) para ser(em) Cancelada(s)", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimparCampos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção");
            }
        }

        public void CancelarItemVenda(int idProd)
        {
            try
            {
                if (gdvVenda.Rows.Count > 0)
                {
                    if (MessageBox.Show("Realmente Deseja Cancelar Item Nº " + itemVenda.ToString().Trim().PadLeft(3, '0'), "Cancelar Item", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        vendaC = new VendaC();
                        vendaRegraNegocios = new VendaRegraNegocios();

                        vendaC.vendaId = idProd;
                        vendaC.item = linha;
                        vendaC.idProduto = produtoId;
                        vendaC.qtde = (qtdevenda * -1);

                        string idRetornoVenda = vendaRegraNegocios.CancelarItemVenda(vendaC);

                        try
                        {
                            Convert.ToInt32(idRetornoVenda);

                            cancelarVenda = true;

                            gdvVenda.Refresh();
                            gdvVenda.Update();
                        }
                        catch
                        {
                            MessageBox.Show("Erro ao Cadastrar Venda, Verifique se Exite(m) dados com valor(es) Obrigatório, ou entre em Contato com seu Administrador", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            cancelarVenda = false;

                            LimparCampos();
                        }
                    }
                    else
                    {
                        cancelarVenda = false;

                        LimparCampos();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção");
            }
        }

        public void AtualizaItemGrid()
        {
            try
            {
                vendaC = new VendaC();
                vendaRegraNegocios = new VendaRegraNegocios();

                string endereco = (pathDadosVendaAutorizada + "Venda" + numVenda + ".txt");
                System.IO.File.Delete(endereco);

                GerarVendaTXT();

                for (int i = 0; i < gdvVenda.Rows.Count; i++)
                {
                    itemVenda = (i + 1);

                    vendaC.item = itemVenda;
                    vendaC.numCaixa = numCaixa;
                    vendaC.vendaId = Convert.ToInt32(gdvVenda.Rows[i].Cells["colIdVenda"].Value.ToString());

                    string idRetorno = vendaRegraNegocios.AtualizaItemGrid(vendaC);

                    try
                    {
                        int idRet = Convert.ToInt32(idRetorno);

                        vendaC.qtde = Convert.ToDecimal(gdvVenda.Rows[i].Cells["colQtde"].Value.ToString());
                        vendaC.precoProduto = Convert.ToDecimal(gdvVenda.Rows[i].Cells["colPreco"].Value.ToString());
                        vendaC.subTotal = Convert.ToDecimal(gdvVenda.Rows[i].Cells["colTotal"].Value.ToString());
                        vendaC.codBarra = gdvVenda.Rows[i].Cells["colCodBarras"].Value.ToString();
                        vendaC.descricao = gdvVenda.Rows[i].Cells["colDescricao"].Value.ToString();
                        vendaC.unid = gdvVenda.Rows[i].Cells["colUnid"].Value.ToString().Trim();

                        VenderItemTxt();

                        LoadTela();
                    }
                    catch
                    {
                        MessageBox.Show("Erro no Método Atualizar Item Grid.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        LimparCampos();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção");
            }
        }

        private void btnCancelarVenda_Click(object sender, EventArgs e)
        {
            // TIPO 1 CANCELA A VENDA TOTAL
            tipoCancelamento = 1;

            frmCancelarItemVenda fCancelaItemVenda = new frmCancelarItemVenda(this);
            fCancelaItemVenda.ShowDialog();

            LimparCampos();
        }

        public void AlterarNumeroVenda()
        {
            try
            {
                numCaixaC = new NumCaixaC();
                numCaixaRegraNegocios = new numCaixaRegraNegocios();

                numVenda = (numVenda + 1);
                numCaixaC.numVenda = numVenda;
                numCaixaC.numCaixa = numCaixa;

                try
                {
                    numVenda = Convert.ToInt32(numCaixaRegraNegocios.AlterarNumVenda(numCaixaC));

                    LoadTela();
                }
                catch
                {
                    MessageBox.Show("Erro ao nom Método de Alterar Numero da Venda", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    LimparCampos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção");
            }
        }

        public void PesquisarParametro()
        {
            try
            {
                parametroC = new ParametroC();
                parametroRegraNegocios = new ParametroRegraNegocios();
                DataTable dadosTabelaParametro = new DataTable();

                cabecalho = new CABECALHO();

                dadosTabelaParametro = parametroRegraNegocios.Listar();

                if (dadosTabelaParametro.Rows.Count > 0)
                {
                    idParametro = Convert.ToInt32(dadosTabelaParametro.Rows[0]["ID_PARAMETRO"].ToString());
                    limiteCompra = Convert.ToDecimal(dadosTabelaParametro.Rows[0]["LIMITE_VENDA"].ToString());
                    qtdeCupom = Convert.ToInt32(dadosTabelaParametro.Rows[0]["QTDE_CUPOM"].ToString());
                    agruparVenda = Convert.ToBoolean(dadosTabelaParametro.Rows[0]["AGRUPAR"].ToString());
                    PagamentoVendaXml = Convert.ToBoolean(dadosTabelaParametro.Rows[0]["PAGTO_VENDA_XML"].ToString());
                    placa = Convert.ToBoolean(dadosTabelaParametro.Rows[0]["PLACA"].ToString());
                    msg = dadosTabelaParametro.Rows[0]["MSG"].ToString().Trim();
                    parametroEtiqueta = Convert.ToInt32(dadosTabelaParametro.Rows[0]["COD_ETIQUETA"].ToString());
                    timeDesc = Convert.ToInt32(dadosTabelaParametro.Rows[0]["TIME_TELA_DESC"].ToString());
                    cabecalho.NomeRazao = razaoSocial = dadosTabelaParametro.Rows[0]["RAZAO_SOCIAL"].ToString().Trim();
                    cabecalho.Endereco = endereco = dadosTabelaParametro.Rows[0]["ENDERECO_EMPRESA"].ToString().Trim();
                    cabecalho.Numero = numero = dadosTabelaParametro.Rows[0]["NUMERO"].ToString().Trim();
                    cabecalho.Bairro = bairro = dadosTabelaParametro.Rows[0]["BAIRRO"].ToString().Trim();
                    cabecalho.Cep = cep = dadosTabelaParametro.Rows[0]["CEP"].ToString().Trim();
                    cabecalho.Cidade = cidade = dadosTabelaParametro.Rows[0]["CIDADE"].ToString().Trim();
                    cabecalho.Uf = uf = dadosTabelaParametro.Rows[0]["UF"].ToString().Trim();
                    cabecalho.Telefone = telefone = dadosTabelaParametro.Rows[0]["TELEFONE"].ToString().Trim();
                    cabecalho.CNPJ = cnpj = dadosTabelaParametro.Rows[0]["CNPJ"].ToString().Trim();
                    cabecalho.IE = ie = dadosTabelaParametro.Rows[0]["IE"].ToString().Trim();
                    cabecalho.IM = dadosTabelaParametro.Rows[0]["IM"].ToString().Trim();
                    cabecalho.nCFe = "";
                    cabecalho.CnpjCliente = "";
                    cUF = dadosTabelaParametro.Rows[0]["IBGE"].ToString().Trim();
                    crt = dadosTabelaParametro.Rows[0]["CRT"].ToString().Trim();
                    endCustodia = dadosTabelaParametro.Rows[0]["URL_CUSTODIA"].ToString().Trim();

                    if (placa == true)
                    {
                        btnInserirPlaca.Enabled = true;
                    }
                    else
                    {
                        btnInserirPlaca.Enabled = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção");
            }
        }

        private void btnSangria_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                pnlMenu.Visible = false;
            }

            LimparCampos();
        }

        private void btnCancelarVenda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                pnlMenu.Visible = false;
            }

            LimparCampos();
        }

        private void btnCancelaUltimaVenda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                pnlMenu.Visible = false;
            }

            LimparCampos();
        }

        private void btnCancelarItemVenda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                pnlMenu.Visible = false;
            }

            LimparCampos();
        }

        private void btnSangria_Click(object sender, EventArgs e)
        {
            frmSangriaDespesas fSangriaDespesa = new frmSangriaDespesas(this);
            fSangriaDespesa.ShowDialog();

            LimparCampos();
        }

        public void VenderItemTxt()
        {
            string nomeArquivo = (pathDadosVendaAutorizada + "Venda" + numVenda + ".txt");

            int itens = 0;

            string textoInserir = "";

            for (int i = 0; i < gdvVenda.Rows.Count; i++)
            {
                string item = gdvVenda.Rows[i].Cells["colItem"].Value.ToString();
                string codBarra = gdvVenda.Rows[i].Cells["colCodBarras"].Value.ToString();
                string descricaProduto = gdvVenda.Rows[i].Cells["colDescricao"].Value.ToString().PadRight(25, ' ');
                string un = gdvVenda.Rows[i].Cells["colUnid"].Value.ToString().Trim();
                string preco = Convert.ToDecimal(gdvVenda.Rows[i].Cells["colPreco"].Value.ToString()).ToString("N3").PadLeft(7, '0');
                string qtde = Convert.ToDecimal(gdvVenda.Rows[i].Cells["colQtde"].Value.ToString()).ToString("N3");
                string total = Convert.ToDecimal(gdvVenda.Rows[i].Cells["colTotal"].Value.ToString()).ToString("N6");

                textoInserir += (item + ";" + codBarra + ";" + descricaProduto + ";" + un + ";" + preco + ";" + qtde + ";" + total).ToString().Trim() + "\n";

                itens++;
            }

            int numeroLinha = Convert.ToInt32(itens);

            ArrayList linhas = new ArrayList();

            if (File.Exists(nomeArquivo))
            {
                try
                {
                    rdr = new StreamReader(nomeArquivo);

                    string linha;

                    while ((linha = rdr.ReadLine()) != null)
                    {
                        try
                        {
                            if (linha.Trim() != "")
                            {
                                linhas.Add(linha);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Erro ao acessar o arquivo : " + ex.Message);
                            return;
                        }
                    }

                    rdr.Close();

                    if (linhas.Count > numeroLinha)
                        linhas.Insert(numeroLinha, textoInserir.Trim());
                    else
                        linhas.Add(textoInserir);

                    StreamWriter wrtr = new StreamWriter(nomeArquivo);

                    foreach (string strNewLine in linhas)
                    {
                        wrtr.WriteLine(strNewLine.Trim());
                    }

                    wrtr.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao acessar o arquivo : " + ex.Message);
                    return;
                }
            }
            else
            {
                GerarVendaTXT();
                VenderItemTxt();
            }
        }

        public void GerarVendaTXT()
        {
            try
            {
                string strPathFile = pathDadosVendaAutorizada + "Venda" + numVenda.ToString() + ".txt";

                using (FileStream fs = File.Create(strPathFile))
                {
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        sw.Write("");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void DeletarArquivoVendaTxt()
        {
            try
            {
                string strPathFile = pathDadosVendaAutorizada + "Venda" + numVenda.ToString() + ".txt";

                File.Delete(strPathFile);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtQtde_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ','))
            {
                e.Handled = true;
                MessageBox.Show("Este Campo Aceita Somente Numero e Virgula", "Informação");
            }
            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
                MessageBox.Show("Este Campo Aceita Somente Numero e Virgula", "Informação");
            }
        }

        private void txtPreco_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ','))
            {
                e.Handled = true;
                MessageBox.Show("Este Campo Aceita Somente Numero e Virgula", "Informação");
            }
            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
                MessageBox.Show("Este Campo Aceita Somente Numero e Virgula", "Informação");
            }
        }

        private void txtSubTotal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ','))
            {
                e.Handled = true;
                MessageBox.Show("Este Campo Aceita Somente Numero e Virgula", "Informação");
            }
            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
                MessageBox.Show("Este Campo Aceita Somente Numero e Virgula", "Informação");
            }
        }

        public void DeletarTemp()
        {
            try
            {
                temC = new TempC();
                tempRegraNegocios = new TempRegraNegocios();

                string idRetorno = tempRegraNegocios.DeletarTemp();

                try
                {
                    int idRet = Convert.ToInt32(idRetorno);
                }
                catch
                {
                    MessageBox.Show("Erro ao Deletar Dados Tabela Temp.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCodBarras.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção");
            }
        }

        public void PesquisarTipoUsuario()
        {
            try
            {
                usuarioRegraNegocios = new UsuarioRegraNegocios();
                DataTable dadosTabelaUsuario = new DataTable();

                dadosTabelaUsuario = usuarioRegraNegocios.PesquisarUsuario(idUsuario);

                if (dadosTabelaUsuario.Rows.Count > 0)
                {
                    permissaoAcesso = Convert.ToBoolean(dadosTabelaUsuario.Rows[0]["PERMISSAO"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção");
            }
        }

        public void FecharVendaAberto()
        {
            try
            {
                AlterarNumeroVenda();

                GerarVendaTXT();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção");
            }
        }

        public void BaixaGastoCliente(decimal limite, decimal gasto, decimal total, int idCliente)
        {
            try
            {
                if (idCliente > 0)
                {
                    clienteRegraNegocios = new ClienteRegraNegocios();

                    int idret = clienteRegraNegocios.CreditarGastoCliente(total, gasto, idCliente);

                    if (idret == 0)
                    {
                        MessageBox.Show("Erro ao Creditar Gasto do Cliente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void BaixaEstoqueProduto()
        {
            try
            {
                produtoRegraNegocios = new ProdutoRegraNegocios();
                produtoC = new ProdutoC();

                List<VENDAS> lista = new List<VENDAS>();

                if (gdvVenda.Rows.Count > 0)
                {
                    for (int i = 0; i < listaVendas.Count; i++)
                    {
                        qtdevenda = Convert.ToDecimal(gdvVenda.Rows[i].Cells["colQtde"].Value.ToString());
                        idProduto = Convert.ToInt32(gdvVenda.Rows[i].Cells["colIdProd"].Value.ToString());
                        estoque = Convert.ToDecimal(gdvVenda.Rows[i].Cells["colEstoque"].Value.ToString()).ToString("N3") ?? "0,00";

                        lista.Add(new VENDAS()
                        {
                            qtde = qtdevenda.ToString("N3"),
                            idProd = idProduto,
                            estoque = estoque
                        });
                    }

                    string idRetorno = produtoRegraNegocios.AlterarBaixaEstoqueProduto(lista);

                    try
                    {
                        int idRet = Convert.ToInt32(idRetorno);
                    }
                    catch
                    {
                        MessageBox.Show("Erro no Método Baixa Estoquedo Produto.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção");
            }
        }

        public void FecharStatusVenda()
        {
            try
            {
                vendaC = new VendaC();
                vendaRegraNegocios = new VendaRegraNegocios();

                if (gdvVenda.Rows.Count > 0)
                {
                    DataTable listas = vendaRegraNegocios.PesquisarVendaNum(numVenda, numCaixa);

                    for (int i = 0; i < listas.Rows.Count; i++)
                    {
                        idvenda = Convert.ToInt32(listas.Rows[i]["ID"].ToString());

                        vendaC.vendaId = idvenda;
                        vendaC.fech = false;
                        vendaC.baixado = true;

                        string idRetorno = vendaRegraNegocios.FecharStatusVenda(vendaC);

                        try
                        {
                            int idRet = Convert.ToInt32(idRetorno);
                        }
                        catch
                        {
                            MessageBox.Show("Erro no Método Fechar Status Venda.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção");
            }
        }

        public void FecharStatusPagamentoVennda()
        {
            try
            {
                pagamentoVendaC = new PagamentoVendaC();
                pagamentoVendaRegraNegocios = new PagamentoVendaRegraNegocios();

                pagamentoVendaC.numVenda = numVenda;
                pagamentoVendaC.fechado = false;
                pagamentoVendaC.baixado = false;
                pagamentoVendaC.numCaixa = numCaixa;

                string idretorno = pagamentoVendaRegraNegocios.FecharStatusPagamentoVenda(pagamentoVendaC);

                try
                {
                    int idRet = Convert.ToInt32(idretorno);
                }
                catch
                {
                    MessageBox.Show("Erro no Método Fechar Status Pagamento Venda.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção");
            }
        }

        public void PesquisarPlaca()
        {
            try
            {
                placaC = new PlacaC();
                placaRegraNegocios = new PlacaRegraNegocios();
                DataTable dadosTabelaPlaca = new DataTable();

                dadosTabelaPlaca = placaRegraNegocios.PesquisarPlaca(numVenda);

                if (dadosTabelaPlaca.Rows.Count > 0)
                {
                    descPlaca = dadosTabelaPlaca.Rows[0]["PLACA"].ToString().Trim();
                    km = dadosTabelaPlaca.Rows[0]["KM"].ToString().Trim();
                }
                else
                {
                    descPlaca = "";
                    km = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção");
            }
        }

        public string cnpjDestinatario = "";

        public void PesquisarUltimaVenda()
        {
            try
            {
                if (gdvVenda.Rows.Count == 0)
                {
                    if (MessageBox.Show("Deseja Retirar 2ª Via do Cupom Nº " + (numVenda - 1).ToString().Trim().PadLeft(3, '0'), "2º Via Cupom", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        DadosCabecalhoCupom = "";
                        DadosCorpoCupom = "";
                        DadosPagamentoCupom = "";
                        DadosFinaisCupom = "";
                        DadosSatCupom = "";

                        vendaC = new VendaC();
                        vendaRegraNegocios = new VendaRegraNegocios();

                        DataTable dadosTabelaVenda = new DataTable();

                        List<VENDAS> listaVenda = new List<VENDAS>();
                        List<FORMA_PAGAMENTOS> listaFomaPagamentos = new List<FORMA_PAGAMENTOS>();
                        VENDA_DETALHES vendaDetalhe = new VENDA_DETALHES();

                        escPosElgin = new EscPosElgin();

                        if (gdvVenda.Rows.Count == 0)
                        {
                            if (numCaixa <= 0)
                            {
                                MessageBox.Show("Numero do Caixa não Pode ser Nulo ou menorque Zero.", "Campo Nulo ou Zero", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                LimparCampos();
                            }
                            else if (numVenda <= 0)
                            {
                                MessageBox.Show("Numero da Venda não Pode ser Nulo ou menor que Zero.", "Campo Nulo ou Zero", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                LimparCampos();
                            }
                            else
                            {
                                vendaC.numCaixa = numCaixa;
                                vendaC.numVenda = (numVenda - 1);

                                dadosTabelaVenda = vendaRegraNegocios.PesquisarUltimaVenda(vendaC);

                                if (dadosTabelaVenda.Rows.Count > 0)
                                {
                                    #region LISTA DE VENDAS

                                    for (int i = 0; i < dadosTabelaVenda.Rows.Count; i++)
                                    {
                                        listaVenda.Add(new VENDAS()
                                        {
                                            itemVenda = (i + 1).ToString().PadLeft(3, '0'),
                                            codoBarra = dadosTabelaVenda.Rows[i]["COD_BARRA"].ToString().Trim(),
                                            descricao = dadosTabelaVenda.Rows[i]["DESCRICAO_PRODUTO"].ToString().Trim(),
                                            unid = dadosTabelaVenda.Rows[i]["UNID"].ToString().Trim(),
                                            qtde = Convert.ToDecimal(dadosTabelaVenda.Rows[i]["QUANT"].ToString().Trim()).ToString("N3"),
                                            precoProd = Convert.ToDecimal(dadosTabelaVenda.Rows[i]["PRECO"].ToString().Trim()).ToString("N3"),
                                            subTotal = Convert.ToDecimal(dadosTabelaVenda.Rows[i]["TOTAL"].ToString().Trim()).ToString("N2"),
                                        });
                                    }

                                    #endregion

                                    #region TIPO PAGAMENTO

                                    //TIPO PAGAMENTO ULTIMA VENDA
                                    pagamentoVendaC = new PagamentoVendaC();
                                    pagamentoVendaRegraNegocios = new PagamentoVendaRegraNegocios();
                                    DataTable dadosTabelaPagamentoVenda = new DataTable();

                                    pagamentoVendaC.numCaixa = numCaixa;
                                    pagamentoVendaC.numVenda = (numVenda - 1);
                                    totalVenda = 0;
                                    valorAberto = 0;

                                    dadosTabelaPagamentoVenda = pagamentoVendaRegraNegocios.PesquisarPagamentoVenda(pagamentoVendaC);

                                    if (dadosTabelaPagamentoVenda.Rows.Count > 0)
                                    {
                                        for (int i = 0; i < dadosTabelaPagamentoVenda.Rows.Count; i++)
                                        {
                                            listaFomaPagamentos.Add(new FORMA_PAGAMENTOS()
                                            {
                                                Descricao = dadosTabelaPagamentoVenda.Rows[i]["TIPO_PAGTO"].ToString().Trim().ToUpper(),
                                                Valor = Convert.ToDecimal(dadosTabelaPagamentoVenda.Rows[i]["VALOR"].ToString().Trim()).ToString("N2"),
                                                Troco = Convert.ToDecimal(dadosTabelaPagamentoVenda.Rows[i]["TROCO"].ToString().Trim()).ToString(""),
                                            });

                                            if ((dadosTabelaPagamentoVenda.Rows[i]["TIPO_PAGTO"].ToString().Trim().Contains("ABERTO")) || (dadosTabelaPagamentoVenda.Rows[i]["TIPO_PAGTO"].ToString().Trim().Contains("Aberto")))
                                            {
                                                valorAberto += Convert.ToDecimal(dadosTabelaPagamentoVenda.Rows[i]["VALOR"].ToString().Trim());
                                            }

                                            descricaPagamento = dadosTabelaPagamentoVenda.Rows[i]["TIPO_PAGTO"].ToString().Trim();

                                            idCliente = Convert.ToInt32(dadosTabelaPagamentoVenda.Rows[i]["ID_CLIENTE"].ToString());

                                            cnpjDestinatario = dadosTabelaPagamentoVenda.Rows[0]["CNPJ"].ToString().Trim();

                                            if (dadosTabelaPagamentoVenda.Rows[i]["TIPO_PAGAMENTO"].ToString().Trim().Equals("4"))
                                            {

                                            }
                                        }

                                        totalVenda = (Convert.ToDecimal(dadosTabelaPagamentoVenda.Rows[0]["VALOR"].ToString().Trim()) - Convert.ToDecimal(dadosTabelaPagamentoVenda.Rows[0]["TROCO"].ToString()));
                                    }
                                    else
                                    {
                                        MessageBox.Show("Não Contém Dados na Tabela Pagamento Venda.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }

                                    #endregion

                                    #region DETALHES VENDA

                                    PesquisarPlaca();
                                    PesquisarTemp();

                                    vendaDetalhe = new VENDA_DETALHES();

                                    if (placa == true)
                                    {
                                        vendaDetalhe.desPlaca = "PLACA";
                                        vendaDetalhe.desKm = "KM";
                                        vendaDetalhe.km = km;
                                        vendaDetalhe.desPlaca = descPlaca;
                                    }
                                    else
                                    {
                                        vendaDetalhe.desPlaca = "";
                                        vendaDetalhe.desKm = "";
                                        vendaDetalhe.km = km;
                                        vendaDetalhe.desPlaca = descPlaca;
                                    }

                                    if (cupomFiscal == true)
                                    {
                                        LerChaveXml();

                                        LerXmlRetCustodia();

                                        cabecalho.nCFe = nCFe;
                                        cabecalho.CnpjCliente = cnpjDestinatario;
                                    }
                                    else
                                    {
                                        cabecalho.nCFe = "";
                                        cabecalho.CnpjCliente = cnpjDestinatario;
                                    }

                                    vendaDetalhe.versao = lblVersaoSistem.Text.Trim();
                                    vendaDetalhe.valorAliquota = Convert.ToDecimal(0);
                                    vendaDetalhe.nomeOperador = nomeOperador.Trim();
                                    vendaDetalhe.periodo = periodo.Trim();
                                    vendaDetalhe.numCaixa = numCaixa.ToString().PadLeft(3, '0').Trim();
                                    vendaDetalhe.numVenda = (numVenda - 1).ToString();

                                    #endregion

                                    if ((nomeImpressora.Trim().Equals("BEMATECH")) || nomeImpressora.Trim().Equals("BEMASAT"))
                                    {
                                        #region DADOS CUPOM

                                        bematechRegraNegocios = new BEMATECH();

                                        DadosCabecalhoCupom = bematechRegraNegocios.CabecalhoSegundaViaVenda(cabecalho, cupomFiscal);
                                        DadosCorpoCupom = bematechRegraNegocios.CorpoCupom(listaVenda, vendaC);
                                        DadosPagamentoCupom = bematechRegraNegocios.FormaPagamento(listaFomaPagamentos, totalVenda);
                                        DadosFinaisCupom = bematechRegraNegocios.DadosFinaisCupom(vendaDetalhe);

                                        if (cupomFiscal == true)
                                        {
                                            DadosSatCupom = bematechRegraNegocios.DadosSat(nserieSAT, DateTime.Now.ToString());

                                            cupom = (DadosCabecalhoCupom + DadosCorpoCupom + DadosPagamentoCupom + DadosFinaisCupom + DadosSatCupom);
                                        }
                                        else
                                        {
                                            cupom = (DadosCabecalhoCupom + DadosCorpoCupom + DadosPagamentoCupom + DadosFinaisCupom);
                                        }

                                        #endregion

                                        //LOCALIZA IMPRESSORA E PORTA COM
                                        idRetorno = IMPRESSORA.BemasatImpressora.ConfiguraModeloImpressora(7);
                                        idRetorno = IMPRESSORA.BemasatImpressora.IniciaPorta(numComimp);

                                        esquerda = "" + (char)27 + (char)97 + (char)0;
                                        centrarlizar = "" + (char)27 + (char)97 + (char)1;
                                        direita = "" + (char)27 + (char)97 + (char)2;

                                        idRetorno = IMPRESSORA.BemasatImpressora.ComandoTX(esquerda, esquerda.Length);

                                        idRetorno = IMPRESSORA.BemasatImpressora.FormataTX(cupom + (char)10 + (char)13, 1, 0, 0, 0, 0);

                                        if (cupomFiscal == true)
                                        {
                                            idRetorno = IMPRESSORA.BemasatImpressora.ConfiguraCodigoBarras(70, 0, 1, 1, 0);

                                            chaveCupom = chaveCupom.Replace("CFe", "").Replace(" ", "").Trim();
                                            idRetorno = IMPRESSORA.BemasatImpressora.ComandoTX(centrarlizar, centrarlizar.Length);
                                            IMPRESSORA.BemasatImpressora.ImprimeCodigoBarrasCODE128(chaveCupom);

                                            string qrCodes = chaveCupom.Replace("CFe", "").Trim() + "|" + DateTime.Now.ToString("yyyyMMddHHMMss") + "|" + totalVenda + "|" + qrCod;

                                            idRetorno = IMPRESSORA.BemasatImpressora.ComandoTX(centrarlizar, centrarlizar.Length);
                                            idRetorno = IMPRESSORA.BemasatImpressora.ImprimeCodigoQRCODE(1, 5, 0, 6, 1, qrCodes);
                                        }

                                        idRetorno = IMPRESSORA.BemasatImpressora.AcionaGuilhotina(0);

                                        idRetorno = IMPRESSORA.BemasatImpressora.FechaPorta();
                                    }
                                    else if (nomeImpressora.Trim().Equals("ESCPOS") || (nomeImpressora.Trim().Equals("ELGIN")))
                                    {
                                        escPos = new ESCPOS();

                                        DadosCabecalhoCupom = escPos.CabecalhoSegundaViaVenda(cabecalho, cupomFiscal);
                                        DadosCorpoCupom = escPos.CorpoCupom(listaVenda, vendaC);
                                        DadosPagamentoCupom = escPos.FormaPagamento(listaFomaPagamentos, totalVenda);
                                        DadosFinaisCupom = escPos.DadosFinaisCupom(vendaDetalhe, cupomFiscal, idTipoVenda);

                                        if (cupomFiscal == true)
                                        {
                                            DadosSatCupom = escPos.DadosSat(nserieSAT, DateTime.Now.ToString());

                                            cupom = (DadosCabecalhoCupom + DadosCorpoCupom + DadosPagamentoCupom + DadosFinaisCupom + DadosSatCupom);
                                        }
                                        else
                                        {
                                            cupom = (DadosCabecalhoCupom + DadosCorpoCupom + DadosPagamentoCupom + DadosFinaisCupom);
                                        }

                                        var printer = new Printer(nomeImpressoraPadrao, ObterTipo());

                                        printer.Imprimirrelatorio(cupom);

                                        if (cupomFiscal == true)
                                        {
                                            printer.AlignCenter();

                                            string chave1 = chaveCupom.Replace("CFe", "").Substring(0, 22).Trim();
                                            string chave2 = chaveCupom.Replace("CFe", "").Substring(22, 22).Trim();

                                            printer.CondensedMode(PrinterModeState.On);
                                            printer.BoldMode(chaveCupom.Replace("CFe", "").Trim());
                                            printer.CondensedMode(PrinterModeState.Off);

                                            if (nomeImpressoraPadrao.Contains("ZJ-80"))
                                            {
                                            }
                                            else
                                            {
                                                printer.NewLines(1);
                                                printer.Code128(chave1);
                                                printer.NewLines(2);
                                                printer.Code128(chave2);
                                            }

                                            printer.NewLines(3);

                                            string qrCodes = chaveCupom.Replace("CFe", "").Trim() + "|" + DateTime.Now.ToString("yyyyMMddHHMMss") + "|" + totalVenda + "|" + qrCod;

                                            printer.QrCode(qrCodes, QrCodeSize.Size2);

                                            printer.NewLines(3);
                                        }

                                        printer.PartialPaperCut();

                                        printer.PrintDocument();

                                        printer.InitializePrint();
                                    }
                                    else if (nomeImpressora.Trim().Equals("MP 2500"))
                                    {
                                        escPos = new ESCPOS();

                                        DadosCabecalhoCupom = escPos.CabecalhoSegundaViaVendaMp2500(cabecalho, cupomFiscal);
                                        DadosCorpoCupom = escPos.CorpoCupomMp2500(listaVenda, vendaC);
                                        DadosPagamentoCupom = escPos.FormaPagamentoMp2500(listaFomaPagamentos, totalVenda);
                                        DadosFinaisCupom = escPos.DadosFinaisCupomMp2500(vendaDetalhe, cupomFiscal);

                                        if (cupomFiscal == true)
                                        {
                                            DadosSatCupom = escPos.DadosSatMp2500(nserieSAT, DateTime.Now.ToString());

                                            cupom = (DadosCabecalhoCupom + DadosCorpoCupom + DadosPagamentoCupom + DadosFinaisCupom + DadosSatCupom);
                                        }
                                        else
                                        {
                                            cupom = (DadosCabecalhoCupom + DadosCorpoCupom + DadosPagamentoCupom + DadosFinaisCupom);
                                        }

                                        var printer = new Printer(nomeImpressoraPadrao, ObterTipo());

                                        printer.Imprimirrelatorio(cupom);

                                        printer.AlignCenter();

                                        if (cupomFiscal == true)
                                        {
                                            printer.Imprimirrelatorio(cupom);

                                            printer.AlignCenter();

                                            string chave1 = chaveCupom.Replace("CFe", "").Substring(0, 22).Trim();
                                            string chave2 = chaveCupom.Replace("CFe", "").Substring(22, 22).Trim();

                                            printer.CondensedMode(PrinterModeState.On);
                                            printer.BoldMode(chaveCupom.Replace("CFe", "").Trim());
                                            printer.CondensedMode(PrinterModeState.Off);

                                            printer.NewLines(1);
                                            printer.Code128(chave1);
                                            printer.NewLines(2);
                                            printer.Code128(chave2);

                                            printer.NewLines(3);

                                            string qrCodes = chaveCupom.Replace("CFe", "").Trim() + "|" + DateTime.Now.ToString("yyyyMMddHHMMss") + "|" + totalVenda + "|" + qrCod;

                                            printer.QrCode(qrCodes, QrCodeSize.Size2);

                                            printer.NewLines(3);

                                            printer.PartialPaperCut();
                                        }

                                        printer.PrintDocument();

                                        printer.InitializePrint();

                                        printer.NewLines(3);
                                    }
                                    else if (nomeImpressora.Trim().Equals("EPSON"))
                                    {
                                        string ano = DateTime.Now.ToString("yyyy").PadLeft(2, '0');
                                        string mes = DateTime.Now.ToString("MM").PadLeft(2, '0');

                                        enderecoXmlCustodia = (pathCustodia + ano + "\\" + mes + "\\" + "Cx" + numCaixa + "\\" + chaveCupom.Replace("CFe", "") + ".xml");

                                        idRetorno = IMPRESSORA.InterfaceEpsonNF.IniciaPorta("USB");

                                        idRetorno = IMPRESSORA.InterfaceEpsonNF.EPSON_SAT_Imprimir(enderecoXmlCustodia, "C");

                                        if (idRetorno != 0x01)
                                            MessageBox.Show("Erro ao imprimir o Extrato do Sat.", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                                        idRetorno = IMPRESSORA.InterfaceEpsonNF.FechaPorta();
                                    }

                                    //MONTAR E IMPRIMIR CUPOM ABERTO 
                                    if ((descricaPagamento.Contains("ABERTO")) || (descricaPagamento.Contains("Aberto")))
                                    {
                                        MontarCupomAberto();
                                    }

                                    //ZERAR AS VARIAVEIS
                                    impressoraC.detalhes = "";
                                    impressoraC.dadosVenda = "";
                                    idRetorno = 0;

                                    MessageBox.Show("2ª Via do Cupom Venda com Numero: " + (numVenda - 1).ToString().PadLeft(3, '0') + ".\n\nFoi Gerado com Sucesso...", "Cupom Segunda Via", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    LimparCampos();
                                }
                                else
                                {
                                    MessageBox.Show("Não Contém Informações do Cupom Nº: " + numVenda.ToString().Trim().PadLeft(3, '0') + ".", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    LimparCampos();
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Foi Inicializada uma Nova Venda, não Contém Informações dos dados Última Venda.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            LimparCampos();
                        }
                    }
                    else
                    {
                        LimparCampos();
                    }
                }
                else
                {
                    MessageBox.Show("Não é Possivel Realizar 2º Via Cupom, Foi Incializado um Nova Venda.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LimparCampos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção");
            }
        }

        private void MontarCupomAberto()
        {
            try
            {
                BEMATECH cupomBematech = new BEMATECH();

                PesquisarCliente();

                if (cupom.Trim() != "")
                {
                    if ((nomeImpressora.Trim().Equals("BEMATECH")) || (nomeImpressora.Trim().Equals("BEMASAT")))
                    {
                        cupomBematech = new BEMATECH();

                        DadosCabecalhoCupom = cupomBematech.CabecalhoCupomAberto(cabecalho);
                        DadosCupomAberto = cupomBematech.CupomVendaAberto(valorAberto, nomeCliente, numCaixa, (numVenda - 1), nomeOperador);

                        cupom = (DadosCabecalhoCupom + DadosCupomAberto);

                        idRetorno = IMPRESSORA.BemasatImpressora.ConfiguraModeloImpressora(7);
                        idRetorno = IMPRESSORA.BemasatImpressora.IniciaPorta(numComimp);

                        esquerda = "" + (char)27 + (char)97 + (char)0;
                        centrarlizar = "" + (char)27 + (char)97 + (char)1;
                        direita = "" + (char)27 + (char)97 + (char)2;

                        idRetorno = IMPRESSORA.BemasatImpressora.ComandoTX(esquerda, esquerda.Length);
                        idRetorno = IMPRESSORA.BemasatImpressora.FormataTX(cupom + (char)10 + (char)13, 1, 0, 0, 0, 0);

                        idRetorno = IMPRESSORA.BemasatImpressora.AcionaGuilhotina(0);
                        idRetorno = IMPRESSORA.BemasatImpressora.FechaPorta();
                    }
                    else if (nomeImpressora.Trim().Equals("ESCPOS"))
                    {
                        escPos = new ESCPOS();

                        DadosCabecalhoCupom = escPos.CabecalhoCupomVendaAberto(cabecalho, nCFe, cupomFiscal);
                        DadosCupomAberto = escPos.CupomVendaAberto(valorAberto, nomeCliente, numCaixa, (numVenda - 1), nomeOperador);

                        cupom = (DadosCabecalhoCupom + DadosCupomAberto);

                        string chave = chaveCupom.Replace("CFe", "").Trim();

                        var printer = new Printer(nomeImpressoraPadrao, ObterTipo());

                        printer.Imprimirrelatorio(cupom);

                        printer.PartialPaperCut();

                        printer.PrintDocument();

                        printer.InitializePrint();
                    }
                    else if (nomeImpressora.Trim().Equals("MP 2500"))
                    {
                        escPos = new ESCPOS();

                        DadosCabecalhoCupom = escPos.CabecalhoCupomVendaAbertoMp2500(cabecalho, nCFe, cupomFiscal);
                        DadosCupomAberto = escPos.CupomVendaAbertoMp2500(valorAberto, nomeCliente, numCaixa, (numVenda - 1), nomeOperador);

                        cupom = (DadosCabecalhoCupom + DadosCupomAberto);

                        if (cupomFiscal == true)
                        {
                            string chave = chaveCupom.Replace("CFe", "").Trim();
                        }

                        var printer = new Printer(nomeImpressoraPadrao, ObterTipo());

                        printer.Imprimirrelatorio(cupom);

                        printer.PartialPaperCut();

                        printer.PrintDocument();

                        printer.NewLines(3);

                        printer.InitializePrint();
                    }
                }
                else
                {
                    MessageBox.Show("Erro ao Gerar Cupom Aberto", "Erro", MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void LerXmlRetCustodia()
        {
            try
            {
                string ano, mes = "";

                ano = DateTime.Now.Year.ToString().PadLeft(2, '0');
                mes = DateTime.Now.Month.ToString().PadLeft(2, '0');

                string endereco = (pathCustodia + ano + "\\" + mes + "\\" + "Cx" + numCaixa);

                XmlTextReader x = new XmlTextReader(endereco + "\\" + chaveCupom.Replace("CFe", "") + ".xml");

                while (x.Read())
                {

                    if (x.NodeType == XmlNodeType.Element && x.Name == "nserieSAT")
                        nserieSAT = (x.ReadString());

                    if (x.NodeType == XmlNodeType.Element && x.Name == "nCFe")
                        nCFe = (x.ReadString());

                    if (x.NodeType == XmlNodeType.Element && x.Name == "assinaturaQRCODE")
                        qrCod = (x.ReadString());
                }

                x.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção");
            }
        }

        public void PesquisarDadosEstabelecimento()
        {
            try
            {
                parametroRegraNegocios = new ParametroRegraNegocios();
                DataTable dadosTabelaParametro = new DataTable();
                impressoraC = new IMPRESSORA.ImpressoraC();

                dadosTabelaParametro = parametroRegraNegocios.Listar();

                if (dadosTabelaParametro.Rows.Count > 0)
                {
                    impressoraC.razaoSocial = dadosTabelaParametro.Rows[0]["RAZAO_SOCIAL"].ToString().Trim();
                    impressoraC.nomeFantasia = dadosTabelaParametro.Rows[0]["NOME_FANTASIA"].ToString().Trim();
                    impressoraC.endereco = dadosTabelaParametro.Rows[0]["ENDERECO_EMPRESA"].ToString().Trim();
                    impressoraC.numero = dadosTabelaParametro.Rows[0]["NUMERO"].ToString().Trim();
                    impressoraC.bairro = dadosTabelaParametro.Rows[0]["BAIRRO"].ToString().Trim();
                    impressoraC.cep = dadosTabelaParametro.Rows[0]["CEP"].ToString().Trim();
                    impressoraC.cidade = dadosTabelaParametro.Rows[0]["CIDADE"].ToString().Trim();
                    impressoraC.uf = dadosTabelaParametro.Rows[0]["UF"].ToString().Trim();
                    impressoraC.telefone = dadosTabelaParametro.Rows[0]["TELEFONE"].ToString().Trim();
                    impressoraC.ie = dadosTabelaParametro.Rows[0]["IE"].ToString().Trim();
                    impressoraC.im = dadosTabelaParametro.Rows[0]["IM"].ToString().Trim();
                    impressoraC.cnpj = dadosTabelaParametro.Rows[0]["CNPJ"].ToString().Trim();
                    impressoraC.crt = dadosTabelaParametro.Rows[0]["CRT"].ToString().Trim();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção");
            }
        }

        public void PesquisarCliente()
        {
            try
            {
                clienteC = new ClienteC();
                clienteRegraNegocios = new ClienteRegraNegocios();

                DataTable dadosTabelaCliente = new DataTable();

                clienteC.idCliente = idCliente;

                dadosTabelaCliente = clienteRegraNegocios.PesquisarClienteId(clienteC);

                if (dadosTabelaCliente.Rows.Count > 0)
                {
                    clienteC.nome = nomeCliente = dadosTabelaCliente.Rows[0]["NOME"].ToString().Trim();
                }
                else
                {
                    MessageBox.Show("Não Contém Cliente Cadastrado com Codigo: " + idCliente.ToString().PadLeft(2, '0') + ".", "Cliente não Localizado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LimparCampos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção");
            }
        }

        public void PesquisarClienteId()
        {
            try
            {
                clienteC = new ClienteC();
                clienteRegraNegocios = new ClienteRegraNegocios();

                DataTable dadosTabelaCliente = new DataTable();

                clienteC.idCliente = idCliente;
                clienteC.NumCaixa = numCaixa;
                clienteC.NumVenda = (numVenda - 1);

                dadosTabelaCliente = clienteRegraNegocios.PesquisarClienteId(clienteC);

                if (dadosTabelaCliente.Rows.Count > 0)
                {
                    clienteC.nome = nomeCliente = dadosTabelaCliente.Rows[0]["NOME"].ToString().Trim();
                    valorAberto = Convert.ToDecimal(dadosTabelaCliente.Rows[0]["NOME"].ToString().Trim());
                }
                else
                {
                    MessageBox.Show("Não Contém Cliente Cadastrado com Codigo: " + idCliente.ToString().PadLeft(2, '0') + ".", "Cliente não Localizado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LimparCampos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção");
            }
        }

        private void txtCodigoBarras_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                btnFecharVenda_Click(sender, e);
            }

            if (txtCodBarras.Text.Trim() != "")
            {

            }

            if ((e.KeyCode == Keys.X) || (e.KeyCode == Keys.Multiply))
            {
                txtQtde.ReadOnly = false;
                txtQtde.Focus();
                txtQtde.SelectAll();

                this.txtCodBarras.Text = "";
            }

            if (e.KeyCode == Keys.Subtract)
            {
                CancelarItemVendaLogin();
            }
        }

        public bool retor;

        public void CancelarItemVendaLogin()
        {
            try
            {

                int idUsuariologado = 0;

                string senha = Interaction.InputBox("Informe o senha Login para Cancelamento Item da Venda", "Cancelar Item de Venda", "", 300, 300);

                if (senha.Trim().Equals(""))
                {
                    MessageBox.Show("Campo Senha não Pode ser Nulo ou Vazio", "Campos Vazio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    usuarioC = new UsuarioC();
                    usuarioRegraNegocios = new UsuarioRegraNegocios();
                    DataTable dadosTabelaUsuario = new DataTable();

                    usuarioC.senha = senha;
                    usuarioC.numCaixa = numCaixa;

                    dadosTabelaUsuario = usuarioRegraNegocios.PesquisarLoginUsuario(usuarioC);

                    if (dadosTabelaUsuario.Rows.Count > 0)
                    {
                        bool ativo = Convert.ToBoolean(dadosTabelaUsuario.Rows[0]["ATIVADO"].ToString());

                        if (ativo == true)
                        {
                            idUsuariologado = Convert.ToInt32(dadosTabelaUsuario.Rows[0]["ID_USUARIO"].ToString());

                            if (idUsuario == idUsuariologado)
                            {
                                try
                                {
                                    if (gdvVenda.Rows.Count > 0)
                                    {
                                        int item = 0;
                                        decimal qtde, qtdeProd = 0;

                                        try
                                        {
                                            item = Convert.ToInt32(Interaction.InputBox("Informe o Item para Cancelamento", "Cancelar Item de Venda", "0", 300, 300));

                                            if (item > 0)
                                            {
                                                int index = Convert.ToInt32(gdvVenda.Rows[item - 1].Cells["colIdVenda"].Value.ToString());

                                                var lista = vendaRegraNegocios.PesquisarNumVendas(numCaixa, numVenda, index);

                                                if (lista.Rows.Count > 0)
                                                {
                                                    qtdeProd = Convert.ToDecimal(lista.Rows[0]["QUANT"].ToString());
                                                    idvenda = Convert.ToInt32(lista.Rows[0]["ID"].ToString());

                                                    qtde = Convert.ToDecimal(Interaction.InputBox("Informe o Quantidade de Item de Venda Produto: " + lista.Rows[0]["DESCRICAO_PRODUTO"].ToString().Trim(), "Cancelar Item de Venda", qtdeProd.ToString(), 300, 300));

                                                    if (qtde < qtdeProd)
                                                    {
                                                        MessageBox.Show("Quantidade Informada não Pode ser Menor que a Venda.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                                    }
                                                    else if (qtde > qtdeProd)
                                                    {
                                                        MessageBox.Show("Quantidade Informada não Pode ser Maior que a Venda.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                                    }
                                                    else
                                                    {
                                                        if (qtde == qtdeProd)
                                                        {
                                                            if (MessageBox.Show("Realmente Deseja Cancelar Item [ " + item + " ]", "Confirmação de Cancelar Item", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                                                            {
                                                                int idRet = vendaRegraNegocios.CancelarItemVenda(numCaixa, idvenda);

                                                                MessageBox.Show("Item de Venda foi Cancelado com Sucesso.", "Cancelar Item de Venda", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                                                LoadTela();
                                                            }
                                                        }
                                                        else
                                                        {
                                                            // int idRet = vendaRegraNegocios.AlterarItemVenda(numCaixa, idvenda, qtde);
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    MessageBox.Show("Item de Venda não Foi Localizado na Venda.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                                }
                                            }
                                        }
                                        catch (Exception)
                                        {
                                            item = 0;
                                        }
                                    }
                                }
                                catch (Exception)
                                {
                                }
                            }
                            else
                            {
                                MessageBox.Show("Usuário Está ''Destivado'', Por favor Entre em Contato com seu Gerente ou Administrador do Sistema.", "Usário Desativado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                this.Close();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Usuário não está não Permitido para Realizar Cancelamento de Venda, Verifique sua Senha está Correta.", "Usuario Não logado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Senha ou Usuario Inválido", "Senha Incorreta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção");
            }
        }

        private void txtCodigoBarras_KeyPress(object sender, KeyPressEventArgs e)
        {
            string caracteresPermitidos = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";

            if (!(caracteresPermitidos.Contains(e.KeyChar.ToString().ToUpper())))
            {
                e.Handled = true;
            }

            if (e.KeyChar == (char)Keys.Space)
            {
                if ((gdvVenda.Rows.Count > 0))
                {
                    VenderItemTxt();

                    frmFechamentoVenda fFechamentoVenda = new frmFechamentoVenda(this, frmCliente);
                    fFechamentoVenda.ShowDialog();

                    LimparCampos();
                }
                else
                {
                    LimparCampos();
                }
            }
        }

        private void txtCodigoBarras_MouseMove(object sender, MouseEventArgs e)
        {
            //txtCodigoBarras.Focus();
            //txtCodigoBarras.SelectAll();
        }

        public void ImprimirUltimoCupoFiscal()
        {
            try
            {
                vendaC = new VendaC();
                vendaRegraNegocios = new VendaRegraNegocios();

                DataTable dadosTabelaVenda = new DataTable();

                List<VENDAS> listaVenda = new List<VENDAS>();
                List<FORMA_PAGAMENTOS> listaFomaPagamentos = new List<FORMA_PAGAMENTOS>();
                VENDA_DETALHES vendaDetalhe = new VENDA_DETALHES();

                escPosElgin = new EscPosElgin();

                if (gdvVenda.Rows.Count == 0)
                {
                    if (numCaixa <= 0)
                    {
                        MessageBox.Show("Numero do Caixa não Pode ser Nulo ou menorque Zero.", "Campo Nulo ou Zero", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        LimparCampos();
                    }
                    else if (numVenda <= 0)
                    {
                        MessageBox.Show("Numero da Venda não Pode ser Nulo ou menor que Zero.", "Campo Nulo ou Zero", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        LimparCampos();
                    }
                    else
                    {
                        DadosCabecalhoCupom = "";
                        DadosCorpoCupom = "";
                        DadosPagamentoCupom = "";
                        DadosFinaisCupom = "";
                        DadosSatCupom = "";

                        vendaC.numCaixa = numCaixa;
                        vendaC.numVenda = (numVenda - 1);

                        dadosTabelaVenda = vendaRegraNegocios.PesquisarUltimaVenda(vendaC);

                        if (dadosTabelaVenda.Rows.Count > 0)
                        {
                            #region LISTA DE VENDAS

                            for (int i = 0; i < dadosTabelaVenda.Rows.Count; i++)
                            {
                                listaVenda.Add(new VENDAS()
                                {
                                    itemVenda = (i + 1).ToString().PadLeft(3, '0'),
                                    codoBarra = dadosTabelaVenda.Rows[i]["COD_BARRA"].ToString().Trim(),
                                    descricao = dadosTabelaVenda.Rows[i]["DESCRICAO_PRODUTO"].ToString().Trim(),
                                    unid = dadosTabelaVenda.Rows[i]["UNID"].ToString().Trim(),
                                    qtde = Convert.ToDecimal(dadosTabelaVenda.Rows[i]["QUANT"].ToString().Trim()).ToString("N2"),
                                    precoProd = Convert.ToDecimal(dadosTabelaVenda.Rows[i]["PRECO"].ToString().Trim()).ToString("N2"),
                                    subTotal = Convert.ToDecimal(dadosTabelaVenda.Rows[i]["TOTAL"].ToString().Trim()).ToString("N2"),
                                });
                            }

                            #endregion

                            #region TIPO PAGAMENTO

                            //TIPO PAGAMENTO ULTIMA VENDA
                            pagamentoVendaC = new PagamentoVendaC();
                            pagamentoVendaRegraNegocios = new PagamentoVendaRegraNegocios();
                            DataTable dadosTabelaPagamentoVenda = new DataTable();

                            pagamentoVendaC.numCaixa = numCaixa;
                            pagamentoVendaC.numVenda = (numVenda - 1);
                            totalVenda = 0;
                            valorAberto = 0;

                            dadosTabelaPagamentoVenda = pagamentoVendaRegraNegocios.PesquisarPagamentoVenda(pagamentoVendaC);

                            if (dadosTabelaPagamentoVenda.Rows.Count > 0)
                            {
                                for (int i = 0; i < dadosTabelaPagamentoVenda.Rows.Count; i++)
                                {
                                    listaFomaPagamentos.Add(new FORMA_PAGAMENTOS()
                                    {
                                        Descricao = dadosTabelaPagamentoVenda.Rows[i]["TIPO_PAGTO"].ToString().Trim(),
                                        Valor = dadosTabelaPagamentoVenda.Rows[i]["VALOR"].ToString().Trim(),
                                        Troco = Convert.ToDecimal(dadosTabelaPagamentoVenda.Rows[i]["TROCO"]).ToString(),
                                    });

                                    if (dadosTabelaPagamentoVenda.Rows[i]["TIPO_PAGTO"].ToString().Trim().Contains("ABERTO"))
                                    {
                                        valorAberto += Convert.ToDecimal(dadosTabelaPagamentoVenda.Rows[i]["VALOR"].ToString().Trim());
                                    }

                                    descricaPagamento = dadosTabelaPagamentoVenda.Rows[i]["TIPO_PAGTO"].ToString().Trim();

                                    idCliente = Convert.ToInt32(dadosTabelaPagamentoVenda.Rows[i]["ID_CLIENTE"].ToString());
                                }

                                totalVenda = (Convert.ToDecimal(dadosTabelaPagamentoVenda.Rows[0]["VALOR"].ToString().Trim()) - Convert.ToDecimal(dadosTabelaPagamentoVenda.Rows[0]["TROCO"].ToString()));
                            }
                            else
                            {
                                MessageBox.Show("Não Contém Dados na Tabela Pagamento Venda.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }

                            #endregion

                            #region DETALHES VENDA

                            PesquisarPlaca();
                            PesquisarTemp();

                            vendaDetalhe = new VENDA_DETALHES();

                            if (placa == true)
                            {
                                vendaDetalhe.desPlaca = "PLACA";
                                vendaDetalhe.desKm = "KM";
                                vendaDetalhe.km = km;
                                vendaDetalhe.desPlaca = descPlaca;
                            }
                            else
                            {
                                vendaDetalhe.desPlaca = "";
                                vendaDetalhe.desKm = "";
                                vendaDetalhe.km = km;
                                vendaDetalhe.desPlaca = descPlaca;
                            }

                            LerChaveXml();

                            LerXmlRetCustodia();

                            vendaDetalhe.versao = lblVersaoSistem.Text.Trim();
                            vendaDetalhe.valorAliquota = Convert.ToDecimal(0);
                            vendaDetalhe.nomeOperador = nomeOperador.Trim();
                            vendaDetalhe.periodo = periodo.Trim();
                            vendaDetalhe.numCaixa = numCaixa.ToString().PadLeft(3, '0').Trim();
                            vendaDetalhe.numVenda = (numVenda - 1).ToString();

                            cabecalho.nCFe = nCFe;

                            #endregion

                            if ((nomeImpressora.Trim().Equals("BEMATECH")) || nomeImpressora.Trim().Equals("BEMASAT"))
                            {
                                #region DADOS CUPOM

                                bematechRegraNegocios = new BEMATECH();

                                DadosCabecalhoCupom = bematechRegraNegocios.CabecalhoCupom(cabecalho, nCFe, true);
                                DadosCorpoCupom = bematechRegraNegocios.CorpoCupom(listaVenda, vendaC);
                                DadosPagamentoCupom = bematechRegraNegocios.FormaPagamento(listaFomaPagamentos, totalVenda);
                                DadosFinaisCupom = bematechRegraNegocios.DadosFinaisCupom(vendaDetalhe);
                                DadosSatCupom = bematechRegraNegocios.DadosSat(nserieSAT, DateTime.Now.ToString());

                                cupom = (DadosCabecalhoCupom + DadosCorpoCupom + DadosPagamentoCupom + DadosFinaisCupom + DadosSatCupom);

                                #endregion

                                //LOCALIZA IMPRESSORA E PORTA COM
                                idRetorno = IMPRESSORA.BemasatImpressora.ConfiguraModeloImpressora(7);
                                idRetorno = IMPRESSORA.BemasatImpressora.IniciaPorta(numComimp);

                                esquerda = "" + (char)27 + (char)97 + (char)0;
                                centrarlizar = "" + (char)27 + (char)97 + (char)1;
                                direita = "" + (char)27 + (char)97 + (char)2;

                                idRetorno = IMPRESSORA.BemasatImpressora.ComandoTX(esquerda, esquerda.Length);

                                idRetorno = IMPRESSORA.BemasatImpressora.FormataTX(cupom + (char)10 + (char)13, 1, 0, 0, 0, 0);

                                idRetorno = IMPRESSORA.BemasatImpressora.ConfiguraCodigoBarras(70, 0, 1, 1, 0);

                                chaveCupom = chaveCupom.Replace("CFe", "").Replace(" ", "").Trim();
                                idRetorno = IMPRESSORA.BemasatImpressora.ComandoTX(centrarlizar, centrarlizar.Length);
                                IMPRESSORA.BemasatImpressora.ImprimeCodigoBarrasCODE128(chaveCupom);

                                string qrCodes = chaveCupom.Replace("CFe", "").Trim() + "|" + DateTime.Now.ToString("yyyyMMddHHMMss") + "|" + totalVenda + "|" + qrCod;

                                idRetorno = IMPRESSORA.BemasatImpressora.ComandoTX(centrarlizar, centrarlizar.Length);
                                idRetorno = IMPRESSORA.BemasatImpressora.ImprimeCodigoQRCODE(1, 5, 0, 6, 1, qrCodes);

                                idRetorno = IMPRESSORA.BemasatImpressora.AcionaGuilhotina(0);

                                idRetorno = IMPRESSORA.BemasatImpressora.FechaPorta();
                            }
                            else if (nomeImpressora.Trim().Equals("ESCPOS") || (nomeImpressora.Trim().Equals("ELGIN")))
                            {
                                escPos = new ESCPOS();

                                DadosCabecalhoCupom = escPos.CabecalhoSegundaViaVenda(cabecalho, cupomFiscal);
                                DadosCorpoCupom = escPos.CorpoCupom(listaVenda, vendaC);
                                DadosPagamentoCupom = escPos.FormaPagamento(listaFomaPagamentos, totalVenda);
                                DadosFinaisCupom = escPos.DadosFinaisCupom(vendaDetalhe, cupomFiscal, idTipoVenda);
                                DadosSatCupom = escPos.DadosSat(nserieSAT, DateTime.Now.ToString());

                                cupom = (DadosCabecalhoCupom + DadosCorpoCupom + DadosPagamentoCupom + DadosFinaisCupom + DadosSatCupom);

                                var printer = new Printer(nomeImpressoraPadrao, ObterTipo());

                                printer.Imprimirrelatorio(cupom);

                                printer.AlignCenter();

                                string chave1 = chaveCupom.Replace("CFe", "").Substring(0, 22).Trim();
                                string chave2 = chaveCupom.Replace("CFe", "").Substring(22, 22).Trim();

                                printer.CondensedMode(PrinterModeState.On);
                                printer.BoldMode(chaveCupom.Replace("CFe", "").Trim());
                                printer.CondensedMode(PrinterModeState.Off);

                                printer.NewLines(1);
                                printer.Code128(chave1);
                                printer.NewLines(2);
                                printer.Code128(chave2);

                                printer.NewLines(3);

                                string qrCodes = chaveCupom.Replace("CFe", "").Trim() + "|" + DateTime.Now.ToString("yyyyMMddHHMMss") + "|" + totalVenda + "|" + qrCod;

                                printer.QrCode(qrCodes, QrCodeSize.Size2);

                                printer.NewLines(3);

                                printer.PartialPaperCut();

                                printer.PrintDocument();

                                printer.InitializePrint();
                            }
                            else if (nomeImpressora.Trim().Equals("EPSON"))
                            {
                                string ano = DateTime.Now.ToString("yyyy").PadLeft(2, '0');
                                string mes = DateTime.Now.ToString("MM").PadLeft(2, '0');

                                enderecoXmlCustodia = (pathCustodia + ano + "\\" + mes + "\\" + "Cx" + numCaixa + "\\" + chaveCupom.Replace("CFe", "") + ".xml");

                                idRetorno = IMPRESSORA.InterfaceEpsonNF.IniciaPorta("USB");

                                idRetorno = IMPRESSORA.InterfaceEpsonNF.EPSON_SAT_Imprimir(enderecoXmlCustodia, "C");

                                if (idRetorno != 0x01)
                                    MessageBox.Show("Erro ao imprimir o Extrato do Sat.", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                                idRetorno = IMPRESSORA.InterfaceEpsonNF.FechaPorta();
                            }

                            //MONTAR E IMPRIMIR CUPOM ABERTO 
                            if (descricaPagamento.Contains("ABERTO"))
                            {
                                MontarCupomAberto();
                            }

                            //ZERAR AS VARIAVEIS
                            impressoraC.detalhes = "";
                            impressoraC.dadosVenda = "";
                            idRetorno = 0;

                            MessageBox.Show("Cupom Fiscal Venda Numero: " + (numVenda - 1).ToString().PadLeft(3, '0') + " foi Realizado com Sucesso...", "Cupom Fiscal", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            LimparCampos();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção");
            }
        }

        #endregion

        #region LOGO

        public void TrocarLogo()
        {
            try
            {
                // LimparImagemLogo();

                //se usuario digitar ok pq ele selecionou arquivo...........
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    //nome que usuario retornou..............................
                    string nomeArquivo = openFileDialog1.FileName;

                    ///exibir imgem dentro do picture box..................

                    Bitmap btm = new Bitmap(nomeArquivo);
                    pbxLogo.Image = btm;

                    //metodo para salvar no banco.........................

                    //MemoryStream herda da classe Stream.................
                    MemoryStream ms = new MemoryStream();
                    btm.Save(ms, ImageFormat.Bmp);

                    byte[] foto = ms.ToArray();

                    try
                    {
                        novaImagem = new LogoRegraNegocios();

                        string idRet = novaImagem.SalvarImagem(foto);
                    }
                    catch
                    {
                        LimparCampos();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção");
            }
        }

        public void IlustraLogo()
        {
            try
            {
                String strConn = ConfigurationManager.ConnectionStrings[stringConexaoXml].ToString();
                SqlConnection connection = new SqlConnection(strConn);

                SqlCommand comand = new SqlCommand("SELECT LOGO FROM LOGO", connection);

                connection.Open();

                SqlDataReader reader = comand.ExecuteReader();
                Image imagem = null;

                if (reader.Read())
                {
                    byte[] foto = (byte[])reader["LOGO"];

                    MemoryStream ms = new MemoryStream(foto);

                    imagem = Image.FromStream(ms);
                }

                pbxLogo.Image = imagem;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção");
            }
        }

        public void LimparImagemLogo()
        {
            try
            {
                novaImagem = new LogoRegraNegocios();
                string idret = novaImagem.LimparImagem();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção");
            }
        }

        #endregion

        #region XML

        public string dadosXmlCfeCancel = "";
        string chaveCancel = "";
        string arquivo = "";

        public void GerarXmlCancelamento()
        {
            xmlRegraNegocios = new XmlRegraNegocios();

            chaveCancel = chaveCupom.Trim();

            dadosXmlCfeCancel = xmlRegraNegocios.GerarXmlCancelamento(chaveCancel, softwareHouse, numCaixa.ToString());

            arquivo = (pathVendaCFe + "\\VENDA_CANCELADA\\");

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(dadosXmlCfeCancel);
            xmlDoc.Save(arquivo + chaveCancel + "-canc.xml");
        }

        public void SalvarUltimaChave()
        {
            XmlTextWriter writer = new XmlTextWriter(pathUltimaVendaCFe + "\\ULTIMA_CHAVE\\CHAVE.xml", null);

            try
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("CFe");
                writer.WriteElementString("NumCFe", chaveCupom.ToString().Trim());
                writer.WriteEndElement();
                writer.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                writer.Close();
            }

        }

        public void Espera()
        {
            long t = DateTime.Now.Millisecond;

            for (int i = 0; i < 500; i++)
            {
                Console.WriteLine(i);
                milesegundos = Convert.ToInt32(i);
            }

            tempoTotal = (DateTime.Now.Millisecond - t);
        }

        public int getNumberRandom()
        {
            int retorno = 0;

            Random number = new Random();

            if (tipoVenda == 1)
            {
                retorno = number.Next(999999);
            }
            else
            {
                retorno = number.Next(99999999);
            }

            sessao = retorno;
            return retorno;
        }

        public string stringRetSat = "";
        public string ret_sat = "";

        public void ConsultarSat()
        {
            getNumberRandom();

            string retConsularSat = Marshal.PtrToStringAnsi(IMPRESSORA.BematechImpressora.ConsultarSAT(sessao));

            string ret_sessao = (Sep_Delimitador('|', 1, retConsularSat));

            if (ret_sessao == "08000")
            {
                retConsularSat = "S@T em Operação.";
            }
        }

        // stackoverflow.com/a/3294698/162671
        static uint SwapEndianness(ulong x)
        {
            return (uint)(((x & 0x000000ff) << 24) +
                           ((x & 0x0000ff00) << 8) +
                           ((x & 0x00ff0000) >> 8) +
                           ((x & 0xff000000) >> 24));
        }

        private string Sep_Delimitador(char sep, int posicao, string dados)
        {
            try
            {
                string[] ret_dados = dados.Split(sep);
                return ret_dados[posicao];
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        #endregion
    }
}