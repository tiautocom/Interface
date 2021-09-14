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
using System.IO;
using System.Data.SqlClient;
using System.Configuration;
using System.Xml;
using System.Runtime.InteropServices;
using Vip.Printer;
using Vip.Printer.Enums;
using System.Globalization;
using System.Threading;
using System.Security.Cryptography.X509Certificates;

namespace SAT
{
    public partial class frmFechamentoVenda : Form
    {
        frmVenda frmVenda;
        frmPesquisarCliente frmCliente;

        public frmFechamentoVenda(frmVenda fVenda, frmPesquisarCliente fCliente)
        {
            InitializeComponent();

            this.frmVenda = fVenda;
            this.frmCliente = fCliente;
            this.numVenda = frmVenda.numVenda;
            this.cnpjDest = frmVenda.cpfCnpjCliente;
            this.cupomFiscal = frmVenda.cupomFiscal;
            this.pathXmlCupom = frmVenda.pathXmlCupom;

            this.gdvTipoPgto.RowTemplate.Height = 50;
            this.gdvTipoPgto.AutoGenerateColumns = false;
            this.gdvTipoPgto.ColumnHeadersVisible = false;

            lblData.Text = DateTime.Now.ToString("dd/MM/yyyy");

            this.cUf = frmVenda.cUF.ToString();
            this.condutor = frmVenda.condutor.Trim();
        }

        #region PATH

        string pathDadosVendaAutorizada = Path.GetDirectoryName(Application.ExecutablePath) + "\\Venda\\";
        string pathDadosVendaFormatado = Path.GetDirectoryName(Application.ExecutablePath) + "\\Venda\\VendaF.txt";
        string pathFormaPgto = Path.GetDirectoryName(Application.ExecutablePath) + "\\BANCO\\FORMA_PGTO_XML\\";
        string pathVendaXML = Path.GetDirectoryName(Application.ExecutablePath) + "\\BANCO\\VENDA_XML\\";
        string pathDadoSoftHouse = Path.GetDirectoryName(Application.ExecutablePath) + "\\BANCO\\SH.xml";
        string pathVendaCFe = Path.GetDirectoryName(Application.ExecutablePath);
        string pathCustodia = @"C:\CFe\Custodia\";
        string pathUltimaVendaCFe = Path.GetDirectoryName(Application.ExecutablePath);
        string pathVendaNFCe = Path.GetDirectoryName(Application.ExecutablePath);

        #endregion

        #region CLASSES E OBJETOS

        TipoPagamentoC tipoPagamentoC = new TipoPagamentoC();
        TipoPagamentoRegraNegocios tipoPagamentoRegraNegocios = new TipoPagamentoRegraNegocios();

        PlacaC placaC = new PlacaC();
        PlacaRegraNegocios placaRegraNegocios = new PlacaRegraNegocios();

        TempC tempC = new TempC();
        TempRegraNegocios tempRegraNegocios = new TempRegraNegocios();

        ParametroC parametroC = new ParametroC();
        ParametroRegraNegocios parametroRegraNegocios = new ParametroRegraNegocios();

        PagamentoVendaC pagamentoVendaC = new PagamentoVendaC();
        PagamentoVendaRegraNegocios pagamentoVendaRegraNegocios = new PagamentoVendaRegraNegocios();

        DataTable dadosTabelaVenda;

        VendaC venda;
        VendaRegraNegocios vendaRegraNegocios;
        CofinsRegraNegocios cofinsRegraNegocios;
        CsosnregraNegocios csosnregraNegocios;
        PisRegraNegocios pisRegraNegocios;
        ImpressoraC impressoraC;
        VendaChaveAcesso vendaChaveAcesso;
        XmlRegraNegocios xmlRegraNegocios;
        EnviarDocumentoSefazRegraNegocios enviarDocumentoSefazRegraNegocios;
        UrlRegraNegocios urlRegraNegocios;
        ValidarRegraNegocios validarRegraNegocios;
        GerarChaveRegraNegocios gerarChaveRegraNegocios;

        SoftwareHouse softwareHouse;
        SerealizarRegraNegocios serealizarRegraNegocios;

        AssinaturaDigital assinaturaDigital;

        FILTRAR filtra;

        BEMATECH bematechRegraNegocios;
        ESCPOS escPos;
        EPSON epsonRegraNegocios;
        CABECALHO cabecalhos;

        XmlDocument xmlAssinado;

        COFINS cofins;
        PIS pis;
        CSOSN csosn;

        Pessoa pessoa;

        #endregion

        #region VARIAVEIS

        public int sessao = 0;
        int idRet = 0;
        int numCaixa = 0;
        int numVenda, idUsuario = 0;
        decimal somaTotal = 0;
        string km, placa = "";

        public string dadosSat = "";
        public string pCofins = "";

        public bool baixar = false;

        //VENDA
        public string descProduto = "";
        public decimal qtdeProduto = 0;

        //PARAMETRO
        bool vendaXml, pagamentoVendaXml;

        //PLACA
        bool placaAut;

        //TIPO PAGAMENTO
        int tipoPagamento = 0;
        decimal valorPagamento = 0;


        //PAGAMENTO VENDA
        public int _idCliente = 0;
        public string nomeCliente = "";
        decimal valorVenda, troco = 0;
        string cnpj = "";

        //XML
        //string da pasta para exporta dados venda................. 
        private SqlConnection conn;
        private SqlDataAdapter daVenda;
        private const string tabela = "VENDA";

        //IMPRESSORA
        string nomeImpressora = "";

        public string chaveCupom = "";
        public string qrCod = "";
        public string stringRetSat = "";
        public bool fechCaixa;
        public string cstProduto, CRT, tipoCSOSN = "";
        public string cpfCnpjCliente, versao, ppis, msg = "";

        //EMITENTE
        public string cnpjEmitente, ieEmitente, ImEmitente, nomeEmitente, enderecoEmitente, numeroEmitente, bairroEmitente, cidadeEmitente, ufEmitente, cepEmitente = "";

        //DESTINATARIO
        public string cnpjDest = "";
        public bool cupomFiscal;

        public string nserieSAT, nCFe = "";
        public string esquerda, centrarlizar, direita = "";
        public decimal aliquotaDia = 0;

        public string pathXmlCupom = "";

        //CLIENTE
        public decimal valorDebitoCliente, valorCreditoCliente, limiteCliente, gastoCliente = 0;
        public string cnpjCliente = "";
        public int idCliente = 0;

        //XML VENDA
        public string xmlPis, xmlCofins, xmlIcms = "";

        //
        public string mes = DateTime.Now.Month.ToString();
        public string ano = DateTime.Now.Year.ToString();

        //NFCE
        public string action_ = "";
        public string url_ = "";
        public string qrCode_ = "";
        public string verAplic, chNFe, dhRecbto, nProt, digVal, cStat, qrCode = "";
        public string condutor = "";

        public string enderecoCustodia = "";

        #endregion

        #region CUPONS & IMPRESSORA

        public int itemVenda, cont = 0;
        public string codigoBarrasProduto, descricaoProduto, unid, descricaPagamento = "";
        public decimal qtdevenda, precoProd, totalVenda, valorAberto = 0;
        public string Cabecalho = "";
        public string CorpoVenda = "";
        public string Pagamentos = "";
        public string DadosFinais = "";
        public string DadosSat = "";
        public string CabecalhoSat = "";
        public string DadosCupomAberto = "";
        public string DadosChaveCupomAberto = "";
        public int idRetorno = 0;
        public string cupom = "";

        public int tipoVenda = 0;

        List<PagamentoVendaC> listaPagamento;

        //EPSON
        public string enderecoXmlCustodia = "";

        #endregion

        private void frmFechamentoVenda_Load(object sender, EventArgs e)
        {
            ListarVenda();
            ListarTXT();
            ListarTipoPagamento();
            PesquisarParametro();
            PesquisarSofwareHouse();

            if (frmVenda.cupomFiscal == true)
            {
                if (frmVenda.tipoVenda == 2)
                {
                    ChaveCupomNFCe = frmVenda.ChaveCupomNFCe;
                    digitoVefificador = frmVenda.digitoVefificador.ToString();
                    sessao = frmVenda.sessao;

                    lblChave.Text = ChaveCupomNFCe.Trim();

                    lblChave.Visible = true;
                }
                else
                {
                    lblChave.Visible = false;
                }
            }
        }

        public void PesquisarParametro()
        {
            try
            {
                parametroRegraNegocios = new ParametroRegraNegocios();
                DataTable dadosTabelaParametro = new DataTable();
                dadosTabelaParametro = parametroRegraNegocios.Listar();

                if (dadosTabelaParametro.Rows.Count > 0)
                {
                    placaAut = Convert.ToBoolean(dadosTabelaParametro.Rows[0]["PLACA"].ToString());
                    CRT = dadosTabelaParametro.Rows[0]["CRT"].ToString().Trim();
                    cnpjEmitente = dadosTabelaParametro.Rows[0]["CNPJ"].ToString().Trim();
                    ieEmitente = dadosTabelaParametro.Rows[0]["IE"].ToString().Trim();
                    ImEmitente = dadosTabelaParametro.Rows[0]["IM"].ToString().Trim();
                    aliquotaDia = Convert.ToDecimal(dadosTabelaParametro.Rows[0]["ALIQUOTA_DIA"].ToString().Trim());
                    msg = dadosTabelaParametro.Rows[0]["MSG"].ToString().Trim();
                    cupomFiscal = Convert.ToBoolean(dadosTabelaParametro.Rows[0]["CUPOM_IMAGEM"].ToString().Trim());
                    nomeEmitente = dadosTabelaParametro.Rows[0]["NOME_FANTASIA"].ToString();
                    enderecoEmitente = dadosTabelaParametro.Rows[0]["ENDERECO_EMPRESA"].ToString();
                    numeroEmitente = dadosTabelaParametro.Rows[0]["NUMERO"].ToString();
                    bairroEmitente = dadosTabelaParametro.Rows[0]["BAIRRO"].ToString();
                    cidadeEmitente = dadosTabelaParametro.Rows[0]["CIDADE"].ToString();
                    ufEmitente = dadosTabelaParametro.Rows[0]["UF"].ToString();
                    cepEmitente = dadosTabelaParametro.Rows[0]["CEP"].ToString();

                    if (placaAut == true)
                    {
                        lblPlacaAutorizar.Visible = true;
                        lblKmAutorizar.Visible = true;
                        lblPlaca.Visible = true;
                        lblKm.Visible = true;
                        btnPlaca.Enabled = true;
                    }
                    else
                    {
                        lblPlacaAutorizar.Visible = false;
                        lblKmAutorizar.Visible = false;
                        lblPlaca.Visible = false;
                        lblKm.Visible = false;
                        btnPlaca.Enabled = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção");
            }
        }

        public void ListarTipoPagamento()
        {
            try
            {
                tipoPagamentoRegraNegocios = new TipoPagamentoRegraNegocios();
                DataTable dadosTabelaTipoPagamento = new DataTable();

                dadosTabelaTipoPagamento = tipoPagamentoRegraNegocios.ListarTipoPagamento();

                if (dadosTabelaTipoPagamento.Rows.Count > 0)
                {
                    //gdvTipoPagamentos.DataSource = null;
                    //gdvTipoPagamentos.DataSource = dadosTabelaTipoPagamento;
                }
                else
                {
                    //gdvTipoPagamentos.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção");
            }
        }

        public void ListarVenda()
        {
            try
            {
                numCaixa = frmVenda.numCaixa;
                numVenda = frmVenda.numVenda;

                lblNumeroCaixa.Text = numCaixa.ToString().Trim().PadLeft(3, '0');
                lblNumVenda.Text = numVenda.ToString().Trim().PadLeft(7, '0');
                lblOperador.Text = frmVenda.nomeOperador;
                somaTotal = frmVenda.somaVenda;
                idUsuario = frmVenda.idUsuario;

                vendaXml = frmVenda.vendaXml;
                pagamentoVendaXml = frmVenda.PagamentoVendaXml;

                nomeImpressora = frmVenda.nomeImpressora;

                //ALIMENTAR VARIAVEIS
                txtValor.Text = somaTotal.ToString("N2");
                lblValorTotal.Text = somaTotal.ToString("N2");

                frmVenda.PesquisarPlaca();
                frmVenda.PesquisarTemp();

                try
                {
                    lblKm.Text = frmVenda.km.Trim();
                    lblPlaca.Text = frmVenda.descPlaca.Trim();
                    lblCpf.Text = frmVenda.cpfCnpjCliente.Trim();
                }
                catch
                {
                    lblKm.Text = "";
                    lblPlaca.Text = "";
                    lblCpf.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção");
            }
        }

        List<VendaC> listaVenda = new List<VendaC>();

        public void ListarTXT()
        {
            try
            {
                StringBuilder sb = new StringBuilder();

                string caminhoArquivo = (pathDadosVendaAutorizada + "Venda" + numVenda + ".txt");

                var consulta = from linha in File.ReadAllLines(caminhoArquivo)
                               let clienteDados = linha.Split(';')
                               select new VendaC()
                               {
                                   item = Convert.ToInt32(clienteDados[0]),
                                   codBarra = clienteDados[1],
                                   descricao = clienteDados[2],
                                   unid = clienteDados[3],
                                   preco = Convert.ToDecimal(clienteDados[4]),
                                   qtde = Convert.ToDecimal(clienteDados[5]),
                                   subTotal = Convert.ToDecimal(clienteDados[6]),
                               };

                foreach (var item in consulta)
                {
                    listaVenda.Add(new VendaC
                    {
                        descricao = item.descricao.Trim(),
                        codBarra = item.codBarra.Trim(),
                        qtde = item.qtde,
                        preco = item.preco,
                        unid = item.unid
                    });

                    listBox1.Items.Add(item.item + ";" + item.codBarra + ";" + item.descricao.PadRight(30, ' ') + ";" + item.unid + ";" + item.preco + ";" + item.qtde + ";" + item.subTotal);

                    sb.AppendFormat("{0,-6}{1,-6}{2,-25}{3,-3}{4,-8}{5,-5}{6,-5}{7}",
                    item.item.ToString().PadLeft(3, '0'),
                    item.codBarra.PadLeft(13, ' ').ToString().Substring(8, 5),
                    item.descricao.Substring(0, 25),
                    item.unid.PadRight(3, ' '),
                    item.preco.ToString("N3").PadLeft(8, ' '),
                    item.qtde.ToString("N3").PadLeft(8, ' '),
                    item.subTotal.ToString("N3").PadLeft(8, ' '),
                    Environment.NewLine);
                }

                string x = sb.ToString();

                File.WriteAllText(pathDadosVendaFormatado, sb.ToString());

                using (StreamReader reader = new StreamReader(pathDadosVendaFormatado))
                {
                    string line;

                    while ((line = reader.ReadLine()) != null)
                    {
                        ltCupomFiscal.Items.Add(line); // Write to console.
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ltCupomFiscal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                txtValor.Focus();
            }
        }

        private void txtRecebimento_KeyPress(object sender, KeyPressEventArgs e)
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

            if ((Keys)e.KeyChar == Keys.Escape)
            {
                if (Convert.ToDecimal(txtTroco.Text) > 0)
                {
                    btnCancelarVenda_Click(sender, e);
                    btnCancelarVenda.ForeColor = Color.Red;
                }
            }
        }

        private void txtRecebimento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.PageDown)
            {
                PesquisarTipoPagamentoDinheiro();
            }

            if (e.KeyCode == Keys.Home)
            {
                PesquisarTipoPagamentoCartao();

                txtValor.Focus();
                txtValor.SelectAll();
                txtValor.Focus();
            }

            if (e.KeyCode == Keys.PageUp)
            {
                PesquisarTipoPagamentoCheque();
            }

            if (e.KeyCode == Keys.End)
            {
                valorAberto = Convert.ToDecimal(txtValor.Text);

                frmPesquisarCliente fPesquisarCliente = new frmPesquisarCliente(this);
                fPesquisarCliente.ShowDialog();

                if (_idCliente > 0)
                {
                    if (MessageBox.Show("Por Favor Confirmar Venda em Aberto para Cliente: " + nomeCliente + ". Código: " + _idCliente.ToString().PadLeft(3, '0') + ".", "Confirmação de Venda em Aberto", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        PesquidarTipoPagamentoAberto();
                    }
                    else
                    {
                        txtValor.Focus();
                        txtValor.SelectAll();
                    }
                }
                else
                {
                    txtValor.Focus();
                    txtValor.SelectAll();
                }
            }

            if (e.KeyCode == Keys.F2)
            {
                btnNotaPaulista_Click(sender, e);
            }

            if (e.KeyCode == Keys.F3)
            {
                btnPlaca_Click(sender, e);
            }

            if (e.KeyCode == Keys.F12)
            {
                PesquisarTipoPagamentoRedeCom();
            }

            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }

            if (e.KeyCode == Keys.F11)
            {
                btnLimpar_Click(sender, e);
            }

            if (e.KeyCode == Keys.Enter)
            {
                if (Convert.ToDecimal(txtValor.Text) == 0)
                {
                    btnFecharVenda_Click(sender, e);
                }
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

        public string enderecoVendaXml = "";

        public void btnFecharVenda_Click(object sender, EventArgs e)
        {
            FecharVendas();
        }

        public void FecharVendas()
        {
            try
            {
                bool retornoXml;

                if (frmVenda.tipoVenda == 1)
                {
                    #region VENDA CF-E

                    retornoXml = GerarXMLCFe();

                    getNumberRandom();

                    if (retornoXml == true)
                    {
                        enderecoVendaXml = (pathVendaCFe + "\\Venda\\" + numCaixa + numVenda.ToString().PadLeft(10, '0') + ".xml");

                        XmlDocument xmlDados = new XmlDocument();
                        xmlDados.LoadXml(dadosSat);
                        xmlDados.Save(enderecoVendaXml);

                        if (frmVenda.cupomFiscal == true)
                        {
                            EnviarDadosSat(retornoXml);
                        }
                        else
                        {
                            if (frmVenda.imprimirCupom == true)
                            {
                                ImprimirCupons();
                            }

                            CadastrarPagementoVenda();

                            fechCaixa = true;
                        }

                        if (baixar == true)
                        {
                            //FECHAR VENDA
                        }
                        else
                        {
                            if (fechCaixa == true)
                            {
                                frmVenda.FecharStatusPagamentoVennda();
                                // frmVenda.FecharStatusVenda();
                                frmVenda.FecharVendaAberto();
                                frmVenda.BaixaGastoCliente(limiteCliente, gastoCliente, totalVenda, _idCliente);
                                frmVenda.LimparCampos();
                                frmVenda.DeletarTemp();
                            }
                        }

                        if (vendaXml == true)
                        {
                            ExportarItemVendaXml();
                        }

                        if (pagamentoVendaXml == true)
                        {
                            ExportarPagamentoVendasXml();
                        }

                        LimparCampos();

                        if (fechCaixa == true)
                        {
                            if (frmVenda.imprimirCupom == false)
                            {
                                MessageBox.Show("Venda Numero: " + numVenda.ToString().PadLeft(6, '0') + " Foi realizado com Sucesso...\n\nPara Retirar segunda Via do Cupom Tecle [F7].", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            if (frmVenda.cupomFiscal == true)
                            {
                                MessageBox.Show("Erro ao Finalizar Venda S@T Numero: " + lblNumVenda.Text, "Erro na Venda", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                MessageBox.Show("Erro ao Enviar Venda Numero: " + lblNumVenda.Text, "Erro na Venda", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }

                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Erro ao Gerar XML da Venda CF-e", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    #endregion
                }
                else
                {
                    #region VENDA NFC-E

                    retornoXml = GerarXmlNFCe();

                    #endregion
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void EnviarDadosSat(bool retornoXml)
        {
            try
            {
                if (retornoXml == true)
                {
                    string ret, ano, mes = "";

                  //  Thread.Sleep(4000);

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

                            int mes_ = DateTime.Now.Month;

                            if (mes_ == 1)
                            {
                                mes_ = 12;
                            }
                            else
                            {
                                mes_ = (mes_ - 1);
                            }

                            MessageBox.Show("Por Favor Retirar Ralatório Gerencial Venda Total do Mês: " + (mes_) + " " + pathCustodia, "Relatório  Resumo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            ImprimirRelatorioMes();
                        }

                        enderecoXmlCustodia = (enderecoExitente + "\\" + chaveCupom + ".xml");

                        if (frmVenda.imprimirCupom == true)
                        {
                            ImprimirCupons();
                        }

                        CadastrarPagementoVenda();

                        fechCaixa = true;
                    }
                    else
                    {
                        if (MessageBox.Show("Retorno: " + ret_err_ + ". Possiveis Erros:\n\n1-CST do Produto.\n2 - Caracteres Especiais\n\nDeseja Continuar Processo Venda?\n\nRetorno XML S@T: " + ret, "Erro de Comunicação S@T", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                        {
                            fechCaixa = false;
                        }
                        else
                        {
                            fechCaixa = false;

                            if (fechCaixa == true)
                            {
                                CadastrarPagementoVenda();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção");
            }
        }

        #region RelatorioResumoMesAnterior

        string resumoTrib;

        public void ImprimirRelatorioMes()
        {
            int mes = DateTime.Now.Month;
            int ano = DateTime.Now.Year;

            if (mes == 1)
            {
                mes = 13;
                ano = ano - 1;
            }

            string dia, aliquotas = "";
            string vendas, totalAliquotas = "";
            string textoVendaRelatorioVenda = "";
            decimal vv = 0;
            decimal somaDia = 0;
            int numero = 0;

            string DadosCabecalhoCupom = "";
            string DadosCorpoCupom = "";
            string DadosPesquisaRelatorio = "";
            string DadosFinaisCupom = "";
            string ER = "";

            //dados da venda total
            vendaRegraNegocios = new VendaRegraNegocios();
            DataTable dadosTabelaVenda = new DataTable();

            dadosTabelaVenda = vendaRegraNegocios.PesquisarRelatorioTotalMesTotalAliquota(numCaixa, (mes - 1), ano);

            if (dadosTabelaVenda.Rows.Count > 0)
            {
                for (int i = 0; i < dadosTabelaVenda.Rows.Count; i++)
                {
                    dia = dadosTabelaVenda.Rows[i]["DIA"].ToString();
                    aliquotas = dadosTabelaVenda.Rows[i]["ALIQUOTA"].ToString();
                    vendas = dadosTabelaVenda.Rows[i]["VENDA"].ToString();
                    totalAliquotas = dadosTabelaVenda.Rows[i]["TOTAL"].ToString();

                    vv += Convert.ToDecimal(vendas);

                    numero = Convert.ToInt32(dia);

                    aliquotas = aliquotas.Trim();

                    if ((aliquotas == "") || (aliquotas == null))
                    {
                        aliquotas = "00";
                    }

                    textoVendaRelatorioVenda += ("*** " + dia.PadLeft(2, '0') + "     " + aliquotas.PadRight(8, ' ') + "           " + totalAliquotas.PadRight(20, ' ') + "\n").ToString();
                }

                int mes_ = DateTime.Now.Month;

                ER = "TOTAL..........................." + vv.ToString("C2") + "\n" + "CAIXA:" + numCaixa.ToString().PadLeft(2, '0') + "\n" + DateTime.Now.ToString();


                CarregaCabecalho();

                if (frmVenda.nomeImpressora.Trim().Equals("BEMATECH") || frmVenda.nomeImpressora.Trim().Equals("BEMASAT"))
                {
                    bematechRegraNegocios = new BEMATECH();

                    DadosCabecalhoCupom = (AR);
                    DadosCorpoCupom = (textoVendaRelatorioVenda.ToString());
                    DadosFinaisCupom = (ER);

                    //LOCALIZA IMPRESSORA E PORTA COM
                    idRetorno = IMPRESSORA.BemasatImpressora.ConfiguraModeloImpressora(7);
                    idRetorno = IMPRESSORA.BemasatImpressora.IniciaPorta(frmVenda.numComimp);

                    resumoTrib = (DadosCabecalhoCupom + DadosCorpoCupom + DadosFinaisCupom);

                    esquerda = "" + (char)27 + (char)97 + (char)0;
                    centrarlizar = "" + (char)27 + (char)97 + (char)1;
                    direita = "" + (char)27 + (char)97 + (char)2;

                    idRetorno = IMPRESSORA.BemasatImpressora.ComandoTX(esquerda, esquerda.Length);
                    idRetorno = IMPRESSORA.BemasatImpressora.FormataTX(resumoTrib + (char)10 + (char)13, 1, 0, 0, 0, 0);

                    idRetorno = IMPRESSORA.BemasatImpressora.AcionaGuilhotina(0);

                    idRetorno = IMPRESSORA.BemasatImpressora.FechaPorta();
                }
                else if (frmVenda.nomeImpressora.Trim().Equals("ESCPOS") || (frmVenda.nomeImpressora.Trim().Equals("EPSON")) || (frmVenda.nomeImpressora.Trim().Equals("ELGIN")))
                {
                    escPos = new ESCPOS();

                    //DadosCabecalhoCupom = escPos.CabecalhoCupomComum(cabecalho);
                    //  DadosCorpoCupom = escPos.CorpoRelatorioVendaCancelada(cabecalhos);
                    DadosPesquisaRelatorio = escPos.CorpoRelatorioVendaCancelada();
                    DadosFinaisCupom = escPos.DadosFinaisSetor(somaTotal, numCaixa, frmVenda.nomeOperador);

                    impressoraC.detalhes = (resumoTrib);

                    var printer = new Printer(frmVenda.nomeImpressoraPadrao, frmVenda.ObterTipo());

                    printer.Imprimirrelatorio(impressoraC.detalhes);
                    printer.PartialPaperCut();
                    printer.PrintDocument();

                    printer.InitializePrint();

                    idRetorno = 1;
                }

                if (idRetorno == 0)
                {
                    MessageBox.Show("Erro ao Imprimir do Venda(s)'.", "Erro de Impressão", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            GerarResumoTxt();
        }

        private void GerarResumoTxt()
        {
            try
            {
                string strPathFile = pathCustodia + "Resumo Tributos" + numCaixa.ToString() + ".txt";

                using (FileStream fs = File.Create(strPathFile))
                {
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        sw.Write(resumoTrib);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public string AR;
        private void CarregaCabecalho()
        {
            try
            {
                string espaco1 = " ";
                string espaco2 = "  ";
                string pularlinha1 = "\n";
                string pontoFinal = "\r";
                string data = DateTime.Now.ToShortDateString();
                int dataMes = DateTime.Now.Month;
                if (dataMes == 1)
                {
                    dataMes = 13;
                }


                AR = ("--------------------------------------------------\n" +
                          nomeEmitente + "\n" +
                          enderecoEmitente + espaco1 + numeroEmitente + espaco1 + "\n" +
                          bairroEmitente + "\n" +
                          cidadeEmitente + espaco1 + "-" + ufEmitente + " CEP:" + cepEmitente + "\n" +
                          "CNPJ:" + cnpjCliente + " - IE:" + ieEmitente + pontoFinal + "\n" +
                          "--------------------------------------------------\n" +
                          "          RELATORIO TOTAL VENDA MES:" + (dataMes - 1) + "\n" +
                          "--------------------------------------------------\n" +
                          "DATA: " + DateTime.Now + "                        \n" +
                          "--------------------------------------------------\n" +
                          "                CUPOM NAO FISCAL                  \n" +
                          "--------------------------------------------------\n" +
                          "DIA        ALIQUOTAS          TOTAL               \n");
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        public void SalvarUltimaChave()
        {
            XmlTextWriter writer = new XmlTextWriter(pathUltimaVendaCFe + "\\ULTIMA_CHAVE\\CHAVE.xml", null);

            try
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("CFe");
                writer.WriteElementString("NumCFe", "CFe" + chaveCupom.ToString().Trim());
                writer.WriteEndElement();
                writer.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                writer.Close();
            }
        }

        public void LerXmlRetCustodia()
        {
            try
            {
                string ano, mes = "";

                ano = DateTime.Now.Year.ToString();
                mes = DateTime.Now.Month.ToString().PadLeft(2, '0');

                if (frmVenda.idTipoVenda == 1)
                {
                    string endereco = (pathCustodia + ano + "\\" + mes + "\\" + "Cx" + numCaixa);

                    XmlTextReader x = new XmlTextReader(endereco + "\\" + chaveCupom + ".xml");

                    while (x.Read())
                    {
                        if (x.NodeType == XmlNodeType.Element && x.Name == "nserieSAT")
                            nserieSAT = (x.ReadString());

                        if (x.NodeType == XmlNodeType.Element && x.Name == "nCFe")
                            nCFe = (x.ReadString());
                    }

                    x.Close();
                }
                else
                {
                    string endereco = (pathCustodia + "NFCE\\" + frmVenda.cnpjEmitente.Replace(".", "").Replace("-", "").Replace("/", "").Trim() + "\\" + ano + "\\" + mes + "\\" + "Cx" + numCaixa);

                    XmlTextReader x = new XmlTextReader(endereco + "\\" + lblChave.Text.Trim() + "-Proc" + ".xml");

                    while (x.Read())
                    {
                        if (x.NodeType == XmlNodeType.Element && x.Name == "serie")
                            nserieSAT = (x.ReadString());

                        if (x.NodeType == XmlNodeType.Element && x.Name == "chNFe")
                            nCFe = (x.ReadString());

                        if (x.NodeType == XmlNodeType.Element && x.Name == "dhRecbto")
                            dhRecbto = (x.ReadString());

                        if (x.NodeType == XmlNodeType.Element && x.Name == "nProt")
                            nProt = (x.ReadString());

                        if (x.NodeType == XmlNodeType.Element && x.Name == "qrCode")
                            qrCode = (x.ReadString());
                    }

                    x.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção");
            }
        }

        public void MontarCupomFiscalBematech()
        {
            try
            {
                ImprimirCupons();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção");
            }
        }

        public CABECALHO GetCabecalhoCupom()
        {
            try
            {
                cabecalhos = new CABECALHO();

                cabecalhos.NomeRazao = frmVenda.razaoSocial;
                cabecalhos.Endereco = frmVenda.endereco;
                cabecalhos.Numero = frmVenda.numero;
                cabecalhos.Bairro = frmVenda.bairro;
                cabecalhos.Cep = frmVenda.cep;
                cabecalhos.Cidade = frmVenda.cidade;
                cabecalhos.Bairro = frmVenda.bairro;
                cabecalhos.Uf = frmVenda.uf;
                cabecalhos.CNPJ = frmVenda.cnpj;
                cabecalhos.IE = frmVenda.ie;
                cabecalhos.IM = frmVenda.im;
                cabecalhos.CnpjCliente = frmVenda.cpfCnpjCliente;
                cabecalhos.Telefone = frmVenda.telefone;
                cabecalhos.nCFe = nCFe.PadLeft(9, '0').Trim();

                return cabecalhos;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

                return null;
            }
        }

        public void ImprimirCupons()
        {
            try
            {
                #region OBJETOS DA CLASSE

                #region CABECALHO

                cabecalhos = GetCabecalhoCupom();

                impressoraC = new IMPRESSORA.ImpressoraC();

                if (frmVenda.cupomFiscal == true)
                {
                    LerXmlRetCustodia();
                }

                #endregion

                #region LISTA VENDAS

                List<VENDAS> listaVenda = new List<VENDAS>();

                #endregion

                #region FORMA DE PAGAMENTOS

                List<FORMA_PAGAMENTOS> listaFomaPagamentos = new List<FORMA_PAGAMENTOS>();

                #endregion

                #region DETALHES VENDA

                VENDA_DETALHES vendaDetalhes = new VENDA_DETALHES();

                venda = new VendaC();

                vendaRegraNegocios = new VendaRegraNegocios();

                venda.numCaixa = numCaixa;
                venda.numVenda = numVenda;

                #endregion

                #endregion

                DataTable dadosTabelaVenda = vendaRegraNegocios.PesquisarUltimaVenda(venda);

                if (dadosTabelaVenda.Rows.Count > 0)
                {
                    idRetorno = 0;
                    valorAberto = 0;

                    #region CORPO DE VENDA

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
                            subTotal = Convert.ToDecimal(dadosTabelaVenda.Rows[i]["TOTAL"].ToString().Trim()).ToString("N3"),
                        });
                    }

                    #endregion

                    #region FORMA DE PAGAMENTOS

                    for (int i = 0; i < gdvTipoPgto.Rows.Count; i++)
                    {
                        listaFomaPagamentos.Add(new FORMA_PAGAMENTOS()
                        {
                            Descricao = gdvTipoPgto.Rows[i].Cells["Descricao"].Value.ToString().Trim(),
                            Valor = gdvTipoPgto.Rows[i].Cells["Valor"].Value.ToString().Trim(),
                            Troco = Convert.ToDecimal(txtTroco.Text.Trim()).ToString(),
                        });

                        if (gdvTipoPgto.Rows[i].Cells["Descricao"].Value.ToString().Trim().Contains("ABERTO"))
                        {
                            valorAberto += Convert.ToDecimal(gdvTipoPgto.Rows[i].Cells["Valor"].Value.ToString().Trim());
                        }

                        descricaPagamento = gdvTipoPgto.Rows[i].Cells["Descricao"].Value.ToString().Trim();

                        totalVenda = Convert.ToDecimal(lblValorTotal.Text);
                    }

                    #endregion

                    #region DETALHES DO CUPOM

                    frmVenda.PesquisarPlaca();
                    frmVenda.PesquisarTemp();

                    if (frmVenda.placa == true)
                    {
                        vendaDetalhes.desPlaca = "PLACA:";
                        vendaDetalhes.desKm = "KM";
                        vendaDetalhes.km = frmVenda.km.Trim();
                        vendaDetalhes.placa = frmVenda.descPlaca.ToString();
                    }
                    else
                    {
                        vendaDetalhes.desPlaca = "";
                        vendaDetalhes.placa = "";
                        vendaDetalhes.km = "";
                        vendaDetalhes.desKm = "";
                    }

                    vendaDetalhes.nomeOperador = frmVenda.nomeOperador.Trim();
                    vendaDetalhes.periodo = frmVenda.periodo.Trim();
                    vendaDetalhes.numCaixa = frmVenda.numCaixa.ToString().PadLeft(3, '0').Trim();
                    vendaDetalhes.numVenda = numVenda.ToString().PadLeft(5, '0').Trim();
                    vendaDetalhes.msg = frmVenda.msg.Trim();
                    vendaDetalhes.versao = frmVenda.versaoSistema.Trim();
                    vendaDetalhes.valorAliquota = ((totalVenda * aliquotaDia) / 100);

                    if (frmVenda.idTipoVenda == 2)
                    {
                        //NFCE
                        vendaDetalhes.serie = nserieSAT;
                        vendaDetalhes.dhRecbto = dhRecbto.Trim();
                        vendaDetalhes.chNFe = chNFe.Trim();
                        vendaDetalhes.qrCode = qrCode;
                        vendaDetalhes.nProt = nProt;
                    }

                    if (nomeImpressora.Trim().Equals("BEMASAT") || (nomeImpressora.Trim().Equals("BEMATECH")))
                    {
                        bematechRegraNegocios = new BEMATECH();

                        string data = DateTime.Now.ToString();

                        Cabecalho = bematechRegraNegocios.CabecalhoCupom(cabecalhos, nCFe, frmVenda.cupomFiscal);
                        CorpoVenda = bematechRegraNegocios.CorpoCupom(listaVenda, venda);
                        Pagamentos = bematechRegraNegocios.FormaPagamento(listaFomaPagamentos, totalVenda);
                        DadosFinais = bematechRegraNegocios.DadosFinaisCupom(vendaDetalhes);

                        #endregion

                        #region DADOS S@T

                        if (frmVenda.cupomFiscal == true)
                        {
                            CabecalhoSat = bematechRegraNegocios.CabecalhoSat();

                            DadosSat = bematechRegraNegocios.DadosSat(nserieSAT, data);

                            cupom = (Cabecalho + CorpoVenda + Pagamentos + impressoraC.troco + DadosFinais + DadosSat);
                        }
                        else
                        {
                            cupom = (Cabecalho + CorpoVenda + Pagamentos + impressoraC.troco + DadosFinais);
                        }

                        #endregion

                        #region COMANDO IMPRESSORA

                        if (frmVenda.idTipoVenda == 1)
                        {
                            #region SAT

                            idRetorno = IMPRESSORA.BemasatImpressora.ConfiguraModeloImpressora(7);
                            idRetorno = IMPRESSORA.BemasatImpressora.IniciaPorta(frmVenda.numComimp);

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

                            #endregion
                        }
                        else
                        {
                            #region NFCE

                            idRetorno = IMPRESSORA.BemasatImpressora.ConfiguraModeloImpressora(7);
                            idRetorno = IMPRESSORA.BemasatImpressora.IniciaPorta(frmVenda.numComimp);

                            esquerda = "" + (char)27 + (char)97 + (char)0;
                            centrarlizar = "" + (char)27 + (char)97 + (char)1;
                            direita = "" + (char)27 + (char)97 + (char)2;

                            #endregion
                        }
                    }
                    else if (nomeImpressora.Trim().Equals("ESCPOS") || nomeImpressora.Trim().Equals("ELGIN"))
                    {
                        escPos = new ESCPOS();

                        string data = DateTime.Now.ToString();

                        Cabecalho = escPos.CabecalhoCupom(cabecalhos, nCFe, frmVenda.cupomFiscal, frmVenda.idTipoVenda);
                        CorpoVenda = escPos.CorpoCupom(listaVenda, venda);
                        Pagamentos = escPos.FormaPagamento(listaFomaPagamentos, totalVenda);
                        DadosFinais = escPos.DadosFinaisCupom(vendaDetalhes, frmVenda.cupomFiscal, frmVenda.idTipoVenda);

                        if (frmVenda.cupomFiscal == true)
                        {
                            if (frmVenda.idTipoVenda == 1)
                            {
                                DadosSat = escPos.DadosSat(nserieSAT ?? null ?? "", data);
                            }
                        }

                        cupom = (Cabecalho + CorpoVenda + Pagamentos + impressoraC.troco + DadosFinais + DadosSat);

                        var printer = new Printer(frmVenda.nomeImpressoraPadrao, frmVenda.ObterTipo());

                        printer.Imprimirrelatorio(cupom);

                        if (frmVenda.cupomFiscal == true)
                        {
                            printer.AlignCenter();

                            if (frmVenda.idTipoVenda == 1)
                            {
                                string chave1 = chaveCupom.Replace("CFe", "").Substring(0, 22).Trim() ?? null ?? "";
                                string chave2 = chaveCupom.Replace("CFe", "").Substring(22, 22).Trim() ?? null ?? "";

                                printer.CondensedMode(PrinterModeState.On);
                                printer.BoldMode(chaveCupom.Replace("CFe", "").Trim());
                                printer.CondensedMode(PrinterModeState.Off);

                                if (frmVenda.nomeImpressoraPadrao.Contains("ZJ-80"))
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

                                printer.QrCode(qrCodes, QrCodeSize.Size1);
                            }
                            else
                            {
                                printer.NewLines(1);

                                printer.QrCode(qrCode, QrCodeSize.Size1);
                            }

                            printer.NewLines(3);

                            printer.PartialPaperCut();

                            printer.PrintDocument();

                            printer.InitializePrint();

                            idRetorno = 1;
                        }
                        else
                        {
                            printer.NewLines(3);

                            printer.PartialPaperCut();

                            printer.PrintDocument();

                            printer.InitializePrint();

                            idRetorno = 1;
                        }
                    }
                    else if (nomeImpressora.Trim().Equals("MP 2500"))
                    {
                        escPos = new ESCPOS();

                        string data = DateTime.Now.ToString();

                        Cabecalho = escPos.CabecalhoCupomMp2500(cabecalhos, nCFe, frmVenda.cupomFiscal);
                        CorpoVenda = escPos.CorpoCupomMp2500(listaVenda, venda);
                        Pagamentos = escPos.FormaPagamentoMp2500(listaFomaPagamentos, totalVenda);
                        DadosFinais = escPos.DadosFinaisCupomMp2500(vendaDetalhes, frmVenda.cupomFiscal);

                        if (frmVenda.cupomFiscal == true)
                        {
                            DadosSat = escPos.DadosSatMp2500(nserieSAT, data);

                            cupom = (Cabecalho + CorpoVenda + Pagamentos + impressoraC.troco + DadosFinais + DadosSat);
                        }
                        else
                        {
                            cupom = (Cabecalho + CorpoVenda + Pagamentos + impressoraC.troco + DadosFinais);
                        }

                        var printer = new Printer(frmVenda.nomeImpressoraPadrao, frmVenda.ObterTipo());

                        printer.Imprimirrelatorio(cupom);

                        printer.AlignCenter();

                        if (frmVenda.cupomFiscal == true)
                        {
                            string chave1 = chaveCupom.Replace("CFe", "").Substring(0, 22).Trim();
                            string chave2 = chaveCupom.Replace("CFe", "").Substring(1, 22).Trim();

                            printer.CondensedMode(PrinterModeState.On);
                            printer.BoldMode(chaveCupom.Replace("CFe", "").Trim());
                            printer.CondensedMode(PrinterModeState.Off);

                            printer.NewLines(1);
                            printer.Code128(chave1);
                            printer.NewLines(2);
                            printer.Code128(chave2);

                            printer.NewLines(3);

                            string qrCodes = chaveCupom.Replace("CFe", "").Trim() + "|" + DateTime.Now.ToString("yyyyMMddHHMMss") + "|" + totalVenda + "|" + qrCod;

                            printer.QrCode(qrCodes, QrCodeSize.Size1);

                            printer.NewLines(3);
                        }

                        printer.PartialPaperCut();

                        printer.PrintDocument();

                        printer.InitializePrint();

                        idRetorno = 1;
                    }
                    else if (nomeImpressora.Trim().Equals("EPSON"))
                    {
                        idRetorno = IMPRESSORA.InterfaceEpsonNF.IniciaPorta("USB");

                        idRetorno = IMPRESSORA.InterfaceEpsonNF.EPSON_SAT_Imprimir(enderecoXmlCustodia, "C");

                        if (idRetorno != 0x01)

                            MessageBox.Show("Erro ao imprimir o Extrato do Sat.", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                        idRetorno = IMPRESSORA.InterfaceEpsonNF.FechaPorta();
                    }
                    else if (nomeCliente.Trim().Contains("DARUMA"))
                    {
                        idRetorno = IMPRESSORA.InterfaceEpsonNF.EPSON_SAT_Imprimir(enderecoXmlCustodia, "C");
                    }

                    #endregion

                    //MONTAR E IMPRIMIR CUPOM ABERTO 
                    if ((descricaPagamento.Contains("ABERTO") && (idRetorno > 0)))
                    {
                        MontarCupomAberto();

                        if (frmVenda.cupomFiscal == true)
                        {
                            CadastrarVendaChaveWeb();
                        }
                    }

                    if (idRetorno == 0)
                    {
                        MessageBox.Show("Erro na Impressão do CFe Cupom Fiscal Eletrônico, Verifique se Impressora está Instalada Corretamente.", "Venda Realizada com Sucesso!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    //ZERAR AS VARIAVEIS
                    impressoraC.detalhes = "";
                    impressoraC.dadosVenda = "";
                    idRetorno = 0;
                    cont = 0;

                    Cabecalho = "";
                    Pagamentos = "";
                    DadosFinais = "";
                    DadosSat = "";
                    CorpoVenda = "";

                    DadosCupomAberto = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void MontarCupomAberto()
        {
            try
            {
                BEMATECH cupomBematech = new BEMATECH();
                cabecalhos = new CABECALHO();

                cabecalhos = GetCabecalhoCupom();

                if (_idCliente > 0)
                {
                    if ((nomeImpressora.Trim().Equals("BEMATECH")) || (nomeImpressora.Trim().Equals("BEMASAT")))
                    {
                        Cabecalho = cupomBematech.CabecalhoCupomAberto(cabecalhos);

                        DadosCupomAberto = cupomBematech.CupomVendaAberto(valorAberto, nomeCliente, numCaixa, numVenda, frmVenda.nomeOperador);

                        idRetorno = IMPRESSORA.BemasatImpressora.ConfiguraModeloImpressora(7);
                        idRetorno = IMPRESSORA.BemasatImpressora.IniciaPorta(frmVenda.numComimp);

                        esquerda = "" + (char)27 + (char)97 + (char)0;
                        centrarlizar = "" + (char)27 + (char)97 + (char)1;
                        direita = "" + (char)27 + (char)97 + (char)2;

                        idRetorno = IMPRESSORA.BemasatImpressora.ComandoTX(esquerda, esquerda.Length);
                        idRetorno = IMPRESSORA.BemasatImpressora.FormataTX(Cabecalho + DadosCupomAberto + (char)10 + (char)13, 1, 0, 0, 0, 0);

                        idRetorno = IMPRESSORA.BemasatImpressora.AcionaGuilhotina(0);
                        idRetorno = IMPRESSORA.BemasatImpressora.FechaPorta();
                    }
                    else if (nomeImpressora.Trim().Equals("ESCPOS") || nomeImpressora.Trim().Equals("ELGIN") || (nomeImpressora.Trim().Equals("MP 2500")))
                    {
                        escPos = new ESCPOS();

                        string chave = chaveCupom.Replace("CFe", "").Trim();

                        Cabecalho = escPos.CabecalhoCupomVendaAberto(cabecalhos, chave, cupomFiscal);
                        DadosCupomAberto = escPos.CupomVendaAberto(valorAberto, nomeCliente, numCaixa, numVenda, frmVenda.nomeOperador);

                        var printer = new Printer(frmVenda.nomeImpressoraPadrao, frmVenda.ObterTipo());

                        printer.AlignCenter();

                        cupom = (Cabecalho + DadosCupomAberto);

                        printer.Imprimirrelatorio(cupom);

                        printer.PartialPaperCut();

                        printer.PrintDocument();

                        printer.InitializePrint();
                    }
                }
                else
                {
                    MessageBox.Show("Erro ao Selecionar Dados do Cliente, para Venda em Aberto.", " Erro Venda Aberto", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public string xmlEnvioSat = "";

        public bool GerarXMLCFe()
        {
            try
            {
                venda = new VendaC();
                vendaRegraNegocios = new VendaRegraNegocios();
                DataTable dadosTabelaVenda = new DataTable();

                venda.numCaixa = numCaixa;
                venda.numVenda = numVenda;
                venda.baixado = false;

                dadosTabelaVenda = vendaRegraNegocios.PesquisarVendaNaoAgrupada(numCaixa, numVenda);

                if (dadosTabelaVenda.Rows.Count > 0)
                {
                    string mes = DateTime.Now.Month.ToString();
                    string ano = DateTime.Now.Year.ToString();

                    string enderecoExitente = (pathCustodia + ano + "\\" + mes + "\\" + "Cx" + numCaixa);

                    StringBuilder vDadosEnvio = new StringBuilder();

                    vDadosEnvio.Append("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
                    vDadosEnvio.Append("<CFe>");
                    vDadosEnvio.Append("<infCFe versaoDadosEnt=\"0.07\">");

                    //IDE
                    vDadosEnvio.AppendFormat("<ide>");

                    vDadosEnvio.Append("<CNPJ>" + softwareHouse.cnpjSH.Replace("-", "").Replace("/", "").Replace(" ", "") + "</CNPJ>");
                    vDadosEnvio.Append("<signAC>" + softwareHouse.assinatuaDigital + "</signAC>");
                    vDadosEnvio.Append("<numeroCaixa>" + numCaixa.ToString().PadLeft(3, '0') + "</numeroCaixa>");

                    vDadosEnvio.Append("</ide>");

                    //EMIT
                    vDadosEnvio.AppendFormat("<emit>");

                    vDadosEnvio.Append("<CNPJ>" + cnpjEmitente.Replace("-", "").Replace("/", "").Replace(" ", "") + "</CNPJ>");
                    vDadosEnvio.Append("<IE>" + ieEmitente.Replace("-", "").Replace("/", "").Replace(" ", "") + "</IE>");
                    vDadosEnvio.Append("<IM>" + ImEmitente.Replace("-", "").Replace("/", "").Replace(" ", "") + "</IM>");

                    vDadosEnvio.Append("<indRatISSQN>" + "N" + "</indRatISSQN>");

                    vDadosEnvio.Append("</emit>");

                    //DEST
                    cnpjDest = lblCpf.Text.Trim();

                    if (cnpjDest != "")
                    {
                        if (cnpjDest.Length > 11)
                        {
                            vDadosEnvio.AppendFormat("<dest>");
                            vDadosEnvio.Append("<CNPJ>" + cnpjDest.Replace(".", "").Replace("/", "").Replace("-", "").Trim() + "</CNPJ>");
                            vDadosEnvio.Append("</dest>");
                        }
                        else
                        {
                            vDadosEnvio.AppendFormat("<dest>");
                            vDadosEnvio.Append("<CPF>" + cnpjDest.Replace(".", "").Replace("/", "").Replace("-", "").Trim() + "</CPF>");
                            vDadosEnvio.Append("</dest>");
                        }
                    }
                    else
                    {
                        vDadosEnvio.Append("<dest/>");
                    }

                    int contVenda = 0;

                    for (int i = 0; i < dadosTabelaVenda.Rows.Count; i++)
                    {
                        Thread.Sleep(100);

                        venda = new VendaC();

                        venda.item = Convert.ToInt32(dadosTabelaVenda.Rows[i]["ITEM"].ToString().Trim());
                        venda.codBarra = dadosTabelaVenda.Rows[i]["COD_BARRA"].ToString().Trim();
                        venda.descricao = dadosTabelaVenda.Rows[i]["DESCRICAO_PRODUTO"].ToString().Trim();
                        venda.ncm = dadosTabelaVenda.Rows[i]["NCM"].ToString().Trim();
                        venda.cfop = dadosTabelaVenda.Rows[i]["CFOP"].ToString().Trim();
                        venda.unid = dadosTabelaVenda.Rows[i]["UNID"].ToString().Trim();
                        venda.origemProduto = dadosTabelaVenda.Rows[i]["ORIGEM_PRODUTO"].ToString().Trim();
                        venda.cstPis = dadosTabelaVenda.Rows[i]["CST_PIS"].ToString().Trim();
                        venda.subTotal = Convert.ToDecimal(dadosTabelaVenda.Rows[i]["TOTAL"].ToString());
                        venda.aliquota = dadosTabelaVenda.Rows[i]["ALIQUOTA"].ToString().Trim();
                        venda.anp = dadosTabelaVenda.Rows[i]["ANP"].ToString().Trim() ?? null ?? "";
                        venda.cstCofins = cstProduto = dadosTabelaVenda.Rows[i]["CST_COFINS"].ToString().Trim().Trim();

                        string preco = double.Parse(dadosTabelaVenda.Rows[i]["PRECO"].ToString()).ToString("N3").Replace(".", "").Replace(",", ".").Trim();
                        string qtde = double.Parse(dadosTabelaVenda.Rows[i]["QUANT"].ToString()).ToString("N4").Replace(".", "").Replace(",", ".").Trim();

                        //CST PRODUTO
                        cstProduto = dadosTabelaVenda.Rows[i]["ICMS_CST"].ToString().Trim().Trim();

                        vDadosEnvio.Append("<det nItem=\"" + venda.item + "\">");

                        //PROD
                        vDadosEnvio.Append("<prod>");
                        vDadosEnvio.Append("<cProd>" + venda.codBarra + "</cProd>");
                        vDadosEnvio.Append("<xProd>" + venda.descricao + "</xProd>");
                        vDadosEnvio.Append("<NCM>" + venda.ncm + "</NCM>");
                        vDadosEnvio.Append("<CFOP>" + venda.cfop + "</CFOP>");
                        vDadosEnvio.Append("<uCom>" + venda.unid.Replace(",", ".") + "</uCom>");
                        vDadosEnvio.Append("<qCom>" + qtde + "</qCom>");
                        vDadosEnvio.Append("<vUnCom>" + preco + "</vUnCom>");

                        if (venda.unid.Trim().Equals("LT"))
                        {
                            vDadosEnvio.Append("<indRegra>T</indRegra>");

                            double qv = Convert.ToDouble(qtde.Replace(".", ",")) - 0.0001;

                            qtde = qv.ToString("N4");
                        }
                        else
                        {
                            vDadosEnvio.Append("<indRegra>A</indRegra>");
                        }

                        //OBSERVACAO
                        if (venda.cfop.Trim().Equals("5656"))
                        {
                            vDadosEnvio.Append("<obsFiscoDet xCampoDet=\"Cod.Produto ANP\">");
                            vDadosEnvio.Append("<xTextoDet>810101001</xTextoDet>");
                        }
                        else
                        {
                            vDadosEnvio.Append("<obsFiscoDet xCampoDet=\"Cod.CEST\">");
                            vDadosEnvio.Append("<xTextoDet>Texto1</xTextoDet>");
                        }

                        vDadosEnvio.Append("</obsFiscoDet>");

                        vDadosEnvio.Append("</prod>");

                        PesquisarCSOSN();

                        #region IMPOSTOS

                        csosnregraNegocios = new CsosnregraNegocios();

                        vDadosEnvio.Append("<imposto>");

                        #region ICMS

                        xmlIcms = CsosnregraNegocios.GerarXmlIcms(cstProduto, venda.origemProduto, CRT, tipoCSOSN, venda.aliquota, preco, qtde);

                        vDadosEnvio.Append(xmlIcms);

                        #endregion

                        #region PIS

                        pisRegraNegocios = new PisRegraNegocios();
                        xmlPis = pisRegraNegocios.GerarXmlPis(venda.cstPis, preco, qtde, ppis, CRT);

                        vDadosEnvio.Append(xmlPis);

                        #endregion

                        #region COFINS

                        cofinsRegraNegocios = new CofinsRegraNegocios();
                        xmlCofins = cofinsRegraNegocios.GerarXmlCofins(venda.cstCofins, preco, qtde, CRT);

                        vDadosEnvio.Append(xmlCofins);

                        #endregion

                        vDadosEnvio.Append("</imposto>");

                        #endregion

                        vDadosEnvio.Append("</det>");

                        contVenda++;
                    }

                    contVenda = 0;

                    //PAGAMENTO(S)
                    vDadosEnvio.Append("<total/>");

                    vDadosEnvio.Append("<pgto>");

                    if (gdvTipoPgto.Rows.Count > 0)
                    {
                        for (int i = 0; i < gdvTipoPgto.Rows.Count; i++)
                        {
                            int id = 0;
                            decimal valor = 0;
                            string descricao = "";

                            id = Convert.ToInt32(gdvTipoPgto.Rows[i].Cells["colId"].Value.ToString());
                            descricao = gdvTipoPgto.Rows[i].Cells["Descricao"].Value.ToString();
                            valor = Convert.ToDecimal(gdvTipoPgto.Rows[i].Cells["Valor"].Value.ToString());

                            string vv = decimal.Round(valor, 3).ToString("N4");

                            vDadosEnvio.Append("<MP>");
                            vDadosEnvio.Append("<cMP>" + id.ToString().PadLeft(2, '0') + "</cMP>");
                            vDadosEnvio.Append("<vMP>" + valor.ToString("0.00", new CultureInfo("en-US")) + "</vMP>");
                            vDadosEnvio.Append("</MP>");
                        }
                    }

                    vDadosEnvio.Append("</pgto>");

                    //INFORMACAO COMPLEMENTARES
                    vDadosEnvio.Append("<infAdic>");

                    if (CRT == "1")
                    {
                        vDadosEnvio.Append("<infCpl>" + "N CUPOM: " + numVenda.ToString() + " - " + "N CAIXA: " + numCaixa.ToString().PadLeft(3, '0') + " - " + "OPERADOR: " + frmVenda.nomeOperador + "  " + "\n" + "PERIODO: " + frmVenda.periodo + " - " + frmVenda.msg + "\n" +
                              " - " + "CFE: " + frmVenda.versaoSistema + " - " + "Todos Direitos TI-AutoCom" + "</infCpl>");
                    }
                    else
                    {
                        vDadosEnvio.Append("<infCpl>" + "N CUPOM: " + numVenda.ToString() + " - " + "N CAIXA: " + numCaixa.ToString().PadLeft(3, '0') + " - " + "OPERADOR: " + frmVenda.nomeOperador + "  " + "\n" + "PERIODO: " + frmVenda.periodo + " - " + "PLACA: " + frmVenda.descPlaca + " - KM: " + frmVenda.km + " - " + frmVenda.msg + "\n" +
                       " - " + "CFE: " + frmVenda.versaoSistema + " - " + "Todos Direitos TI-AutoCom" + "</infCpl>");
                    }

                    vDadosEnvio.Append("</infAdic>");

                    vDadosEnvio.Append("</infCFe>");
                    vDadosEnvio.Append("</CFe>");

                    dadosSat = "";
                    dadosSat = vDadosEnvio.ToString();

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção");

                return false;
            }
        }

        #region NFCE

        public string digitoVefificador = "";
        public string CodNumerico, cUf = "";
        public string ChaveAcesso, ChaveCupomNFCe = "";
        public int DigitoRetorno = 0;
        public string xmlEnvioNFCe = "";
        public int tipoPessoa = 0;
        public int contador = 1;
        public decimal soma_vICMS = 0;
        public decimal soma_vBC = 0;
        public decimal soma_vTotTrib = 0;
        public decimal somaTotal_IPI = 0;
        public decimal somaParcial = 0;
        public string xMotivo, cStatus = "";

        public string _xmlProduto = "";
        public string _xmlPagamentos = "";
        public string _xmlInfComplementar = "";
        public string _xmlPagamento = "";

        #endregion

        public bool GerarXmlNFCe()
        {
            try
            {
                #region XML NFCE

                filtra = new FILTRAR();

                #region IDE

                pessoa = new Pessoa();
                pessoa.Venda = new VendaC();
                pessoa.NFe = new NFe();

                pessoa.NFe = new NFe();

                pessoa.NFe.Id = "NFe" + lblChave.Text.Trim();
                pessoa.NFe.Versao = frmVenda.versao.Trim();
                pessoa.NFe.cUf = cUf;
                pessoa.NFe.cNF = Convert.ToInt32(sessao).ToString();
                pessoa.NFe.natOp = "VENDA DE MERCADORIA";
                pessoa.NFe.mod = 65;
                pessoa.NFe.serie = "1";
                pessoa.NFe.nNF = Convert.ToInt32(lblNumVenda.Text);
                pessoa.NFe.dhEmi = (DateTime.Now.ToString("s") + DateTime.Now.ToString("zzz"));
                pessoa.NFe.dhSaiEnt = (DateTime.Now.ToString("s") + DateTime.Now.ToString("zzz"));
                pessoa.NFe.tpNF = "1";
                pessoa.NFe.idDest = "1";
                pessoa.NFe.cMunFG = frmVenda.ibge.Trim();
                pessoa.NFe.tpImp = "5";
                pessoa.NFe.tpEmis = "1";
                pessoa.NFe.cDV = digitoVefificador;
                pessoa.NFe.tpAmb = frmVenda.idTipoAmbiente.ToString();
                pessoa.NFe.finNFe = "1";
                pessoa.NFe.indFinal = "1";
                pessoa.NFe.indPres = "1";
                pessoa.NFe.procEmi = "0";
                pessoa.NFe.verProc = filtra.RemoverAcentos(frmVenda.versaoSistema).Trim();

                #endregion

                #region EMITENTE

                #region DADOS EMITENTE

                pessoa.Emitente = new Emitente();

                pessoa.Emitente.CpfCnpj = filtra.RemoverCaracteres(frmVenda.cnpjEmitente.Trim());

                pessoa.Emitente.NomeRazaoSocial = filtra.RemoverAcentos(frmVenda.razaoEmitente.Trim());
                pessoa.Emitente.NomeFantasia = filtra.RemoverAcentos(frmVenda.razaoEmitente.Trim());
                pessoa.Emitente.CRT = frmVenda.crt.Trim().Substring(0, 1).Trim();
                pessoa.Emitente.IeRg = filtra.RemoverCaracteres(frmVenda.ieEmitente).Trim();

                #endregion

                #region ENDERECO EMITENTE

                pessoa.Emitente.Endereco = new Endereco();

                pessoa.Emitente.Endereco.logradouro = filtra.RemoverAcentos(frmVenda.endereco).Trim();
                pessoa.Emitente.Endereco.numero = frmVenda.numero.Trim();
                pessoa.Emitente.Endereco.complemento = filtra.RemoverCaracteres(frmVenda.complemento ?? null ?? " ").Trim();
                pessoa.Emitente.Endereco.bairro = filtra.RemoverCaracteres(frmVenda.bairro).Trim();
                pessoa.Emitente.Endereco.ibge = frmVenda.ibge.Trim();
                pessoa.Emitente.Endereco.cidade = filtra.RemoverCaracteres(frmVenda.cidade).Trim().ToUpper();
                pessoa.Emitente.Endereco.uf = frmVenda.uf.Trim();
                pessoa.Emitente.Endereco.cep = filtra.RemoverCaracteres(frmVenda.cep).Trim();
                pessoa.Emitente.Endereco.codPAis = "1058";
                pessoa.Emitente.Endereco.pais = "BRASIL";
                pessoa.Emitente.Telefone = filtra.RemoverCaracteres(frmVenda.telefone).Trim();

                #endregion

                #endregion

                #region DESTINATARIO

                #region DADOS DESTINATARIO

                pessoa.Destinatario = new Destinatario();

                #region TIPO PESSOA

                if (lblCpf.Text.Trim().Count() > 11)
                {
                    tipoPessoa = 1;
                }
                else
                {
                    tipoPessoa = 2;
                }

                pessoa.Destinatario.TipoPessoa = tipoPessoa;

                #endregion

                if (frmVenda.idTipoAmbiente == 1)
                {
                    pessoa.Destinatario.NomeRazaoSocial = filtra.RemoverAcentos(frmVenda.razaoEmitente.Trim());
                }
                else
                {
                    pessoa.Destinatario.NomeRazaoSocial = "NF-E EMITIDA EM AMBIENTE DE HOMOLOGACAO - SEM VALOR FISCAL";
                }

                pessoa.Destinatario.CpfCnpj = cnpjEmitente.Trim();
                pessoa.Destinatario.indIEDest = "9";
                pessoa.Destinatario.IeRg = frmVenda.ieEmitente.Trim();

                #endregion

                #region ENDERECO DESTINATARIO

                pessoa.Destinatario.Endereco = new Endereco();

                pessoa.Destinatario.Endereco.logradouro = filtra.RemoverCaracteres(frmVenda.endereco).Trim();
                pessoa.Destinatario.Endereco.numero = frmVenda.numero.Trim();
                pessoa.Destinatario.Endereco.complemento = filtra.RemoverCaracteres(frmVenda.complemento ?? null ?? " ").Trim();
                pessoa.Destinatario.Endereco.bairro = filtra.RemoverCaracteres(frmVenda.bairro).Trim();
                pessoa.Destinatario.Endereco.ibge = frmVenda.ibge.Trim();
                pessoa.Destinatario.Endereco.cidade = filtra.RemoverCaracteres(frmVenda.cidade).Trim().ToUpper();
                pessoa.Destinatario.Endereco.uf = frmVenda.uf.Trim();
                pessoa.Destinatario.Endereco.cep = filtra.RemoverCaracteres(frmVenda.cep).Trim();
                pessoa.Destinatario.Endereco.codPAis = "1058";
                pessoa.Destinatario.Endereco.pais = "BRASIL";
                pessoa.Destinatario.Telefone = filtra.RemoverCaracteres(frmVenda.telefone).Trim();

                #endregion

                #endregion

                #region PRODUTOS

                vendaRegraNegocios = new VendaRegraNegocios();

                dadosTabelaVenda = vendaRegraNegocios.PesquisarVendaNaoAgrupada(numCaixa, numVenda);

                if (dadosTabelaVenda.Rows.Count > 0)
                {
                    for (int i = 0; i < dadosTabelaVenda.Rows.Count; i++)
                    {
                        //VENDAS
                        pessoa.Venda = new VendaC();

                        pessoa.Venda.indTot = "1";
                        pessoa.Venda.Item = (i + 1);
                        pessoa.Venda.unid = dadosTabelaVenda.Rows[i]["UNID"].ToString().Trim();
                        pessoa.Venda.preco = Convert.ToDecimal(dadosTabelaVenda.Rows[i]["PRECO"].ToString().Trim());
                        pessoa.Venda.qtde = Convert.ToDecimal(dadosTabelaVenda.Rows[i]["QUANT"].ToString().Trim());
                        pessoa.Venda.total = Convert.ToDecimal(dadosTabelaVenda.Rows[i]["TOTAL"].ToString().Trim());
                        pessoa.Venda.vFrete = 0;

                        //PRODUTO
                        pessoa.Venda.Produto = new ProdutoC();
                        pessoa.Venda.Produto.codBarra = dadosTabelaVenda.Rows[i]["COD_BARRA"].ToString().Trim();
                        pessoa.Venda.Produto.descricao = dadosTabelaVenda.Rows[i]["DESCRICAO_PRODUTO"].ToString().Trim();

                        //TRIBUTO
                        pessoa.Venda.ProdutoTributos = new ProdutoTributos();
                        pessoa.Venda.ProdutoTributos.Ncm = dadosTabelaVenda.Rows[i]["NCM"].ToString().Trim();
                        pessoa.Venda.ProdutoTributos.Cfop = dadosTabelaVenda.Rows[i]["CFOP"].ToString().Trim();
                        pessoa.Venda.ProdutoTributos.Cest = dadosTabelaVenda.Rows[i]["CEST"].ToString().Trim();
                        pessoa.Venda.ProdutoTributos.Origem = dadosTabelaVenda.Rows[i]["ORIGEM"].ToString().Trim();
                        pessoa.Venda.ProdutoTributos.IcmsCst = dadosTabelaVenda.Rows[i]["ICMS_CST"].ToString().Trim();
                        pessoa.Venda.ProdutoTributos.Trib = dadosTabelaVenda.Rows[i]["TRIB"].ToString().Trim();
                        pessoa.Venda.ProdutoTributos.cstPis = dadosTabelaVenda.Rows[i]["CST_PIS"].ToString().Trim();
                        pessoa.Venda.ProdutoTributos.cstCofins = dadosTabelaVenda.Rows[i]["CST_COFINS"].ToString().Trim();
                        pessoa.Venda.ProdutoTributos.vTotaTrib = "0,00";

                        xmlRegraNegocios = new XmlRegraNegocios();

                        _xmlProduto += xmlRegraNegocios.GerarXmlProdutosNFCe(pessoa, pathVendaNFCe);

                        if (frmVenda.crt == "1")
                        {
                            decimal aliq = 0;
                            decimal vBC = 0;
                            decimal vICMS = 0;

                            try
                            {
                                aliq = Convert.ToDecimal(dadosTabelaVenda.Rows[i]["TRIB"].ToString().Trim());
                            }
                            catch
                            {
                                aliq = 0;
                            }

                            vBC = Convert.ToDecimal(dadosTabelaVenda.Rows[i]["QUANT"].ToString().Trim() ?? null ?? "0,00") * Convert.ToDecimal(dadosTabelaVenda.Rows[i]["PRECO"].ToString().Trim() ?? null ?? "0,00");

                            vICMS = (aliq * vBC);

                            // SOMATOTAL
                            soma_vICMS += vICMS;
                            soma_vBC += vBC;
                            soma_vTotTrib += Convert.ToDecimal(somaTotal);
                        }
                        else
                        {
                            decimal aliq = 0;
                            decimal vBC = 0;
                            decimal vICMS = 0;

                            try
                            {
                                aliq = Convert.ToDecimal(dadosTabelaVenda.Rows[i]["TRIB"].ToString().Trim());
                            }
                            catch
                            {
                                aliq = 0;
                            }

                            vICMS = (aliq * vBC);

                            vBC = Convert.ToDecimal(dadosTabelaVenda.Rows[i]["QUANT"].ToString().Trim() ?? null ?? "0,00") * Convert.ToDecimal(dadosTabelaVenda.Rows[i]["PRECO"].ToString().Trim() ?? null ?? "0,00");

                            // SOMATOTAL
                            soma_vICMS += vICMS;
                            soma_vBC += vBC;
                            soma_vTotTrib += Convert.ToDecimal("0,00");
                        }
                    }
                }

                #endregion

                #region OUTRO VALOR

                pessoa.Venda.ProdutoTributos.vOutro = "0,00";

                #endregion

                #region ICMS TOTAL

                pessoa.Venda.VendaIcms = new VendaIcms();

                //pessoa.Venda.VendaIcms.vBc = Convert.ToDecimal(0).ToString("N2").Replace(".", "").Replace(",", ".");
                pessoa.Venda.VendaIcms.vBc = "0.00";
                pessoa.Venda.VendaIcms.vIcms = Convert.ToDecimal(soma_vICMS).ToString("N2").Replace(".", "").Replace(",", ".");
                pessoa.Venda.VendaIcms.vIcmsDeson = "0.00";
                pessoa.Venda.VendaIcms.vFCPUFDest = "0.00";
                pessoa.Venda.VendaIcms.vICMSUFDest = "0.00";
                pessoa.Venda.VendaIcms.vICMSUFRemet = "0.00";
                pessoa.Venda.VendaIcms.vFcp = "0.00";
                pessoa.Venda.VendaIcms.vBcst = "0.00";
                pessoa.Venda.VendaIcms.vSt = "0.00";
                pessoa.Venda.VendaIcms.vFcpst = "0.00";
                pessoa.Venda.VendaIcms.vFcpstRet = "0.00";
                pessoa.Venda.VendaIcms.vProd = somaTotal;
                pessoa.Venda.VendaIcms.vFrete = "0.00";
                pessoa.Venda.VendaIcms.vSeg = "0.00";
                pessoa.Venda.VendaIcms.vDesc = "0.00";
                pessoa.Venda.VendaIcms.vII = "0.00";
                pessoa.Venda.VendaIcms.vIpi = somaTotal_IPI.ToString().Replace(".", "").Replace(",", ".");
                pessoa.Venda.VendaIcms.vIPIDevol = "0.00";
                pessoa.Venda.VendaIcms.vPis = "0.00";
                pessoa.Venda.VendaIcms.vCofins = "0.00";
                pessoa.Venda.VendaIcms.vOutro = "0.00";
                pessoa.Venda.VendaIcms.vNf = somaTotal;
                pessoa.Venda.VendaIcms.vTotTrib = "0.00";
                //pessoa.Venda.VendaIcms.vTotTrib = soma_vTotTrib.ToString("N2");

                #endregion

                #region TRANSPORTE

                pessoa.Venda.Transporte = new Transporte();

                pessoa.Venda.Transporte.modFrete = "9";
                pessoa.Venda.Transporte.pesoB = "0.00";
                pessoa.Venda.Transporte.pesoL = "0.00";
                pessoa.Venda.Transporte.qVol = "0.00";
                pessoa.Venda.Transporte.esp = "0.00";
                pessoa.Venda.Transporte.marca = "";
                pessoa.Venda.Transporte.remuneracao = "0.00";

                pessoa.Venda.Transporte.cnpjTranportadora = filtra.RemoverAcentos("");
                pessoa.Venda.Transporte.xNome = filtra.RemoverAcentos("");
                pessoa.Venda.Transporte.Ie = filtra.RemoverAcentos("");
                pessoa.Venda.Transporte.logradouro = filtra.RemoverAcentos("");
                pessoa.Venda.Transporte.xMun = filtra.RemoverAcentos("");
                pessoa.Venda.Transporte.UF = filtra.RemoverAcentos("");

                pessoa.Venda.Transporte.placa = filtra.RemoverAcentos("");
                pessoa.Venda.Transporte.Ufplaca = filtra.RemoverAcentos("");

                #endregion

                #region PAGAMENTO

                pessoa.Venda.PagamentoVendaC = new PagamentoVendaC();

                _xmlPagamentos = "";

                for (int i = 0; i < gdvTipoPgto.Rows.Count; i++)
                {
                    pessoa.Venda.PagamentoVendaC.indPag = gdvTipoPgto.Rows[i].Cells[0].Value.ToString().PadLeft(2, '0');
                    pessoa.Venda.PagamentoVendaC.tPag = filtra.RemoverAcentos(gdvTipoPgto.Rows[i].Cells["Descricao"].Value.ToString()).Trim();
                    pessoa.Venda.PagamentoVendaC.vPag = Convert.ToDouble(gdvTipoPgto.Rows[i].Cells["Valor"].Value.ToString().Trim());
                    pessoa.Venda.PagamentoVendaC.tpIntegra = "0";
                    pessoa.Venda.PagamentoVendaC.CNPJ = "";
                    pessoa.Venda.PagamentoVendaC.tBand = "";
                    pessoa.Venda.PagamentoVendaC.cAut = "";
                    pessoa.Venda.PagamentoVendaC.troco = Convert.ToDecimal(txtTroco.Text);

                    xmlRegraNegocios = new XmlRegraNegocios();

                    _xmlPagamentos += xmlRegraNegocios.GerarXmlPagamentos(pessoa);
                }

                #endregion

                #region INFORMACOES

                string informacao = "";

                if (CRT == "1")
                {
                    informacao = "N CUPOM: " + numVenda.ToString() + " - " + "N CAIXA: " + numCaixa.ToString().PadLeft(3, '0') + " - " + "OPERADOR: " + frmVenda.nomeOperador + "  " + "\n" + "PERIODO: " + frmVenda.periodo + " - " + frmVenda.msg + "\n" +
                        " - " + "CFE: " + frmVenda.versaoSistema + " - " + "Todos Direitos TI-AutoCom" + "</infCpl>";
                }
                else
                {
                    informacao = "N CUPOM: " + numVenda.ToString() + " - " + "N CAIXA: " + numCaixa.ToString().PadLeft(3, '0') + " - " + "OPERADOR: " + frmVenda.nomeOperador + "  " + "\n" + "PERIODO: " + frmVenda.periodo + " - PLACA: " + frmVenda.descPlaca + "KM: " + frmVenda.km + " - " + frmVenda.msg + "\n" +
                  " - " + "CFE: " + frmVenda.versaoSistema + " - " + "Todos Direitos TI-AutoCom" + "</infCpl>";
                }

                pessoa.Venda.InfComplementar = filtra.RemoverAcentos(informacao).Trim();

                #endregion

                #region GERA XML ENVIO

                #region PESQUSIAR URL QRCOCE

                urlRegraNegocios = new UrlRegraNegocios();

                DataTable dadosTabela = urlRegraNegocios.PesquisaUrl(frmVenda.idTipoAmbiente, "qrCode");

                if (dadosTabela.Rows.Count > 0)
                {
                    xmlRegraNegocios = new XmlRegraNegocios();

                    XmlDocument xmlEnvio = xmlRegraNegocios.GerarXmlVendaNFCe(pessoa, _xmlProduto, _xmlPagamentos, _xmlPagamento, dadosTabela.Rows[0]["URL"].ToString().Trim(), pathVendaCFe);

                    #region SEREALIZAR XML

                    if (xmlEnvio != null)
                    {
                        XmlDocument xmlLoteAssinadoEnvelopado = new XmlDocument();

                        if ((xmlLoteAssinadoEnvelopado = AssinarSerealizarXmlNFCe(xmlEnvio)) != null)
                        {
                            if (ValidarXml(xmlLoteAssinadoEnvelopado) == true)
                            {
                                string enderecoSalvar = (pathVendaCFe + "\\XMLs\\SERVICOS\\EMITIR\\EMITIR_ENVELOPE.xml");

                                XmlDocument XMLEncioVenda = new XmlDocument();
                                StreamReader strm = new StreamReader(enderecoSalvar);

                                XMLEncioVenda.Load(strm);

                                PesquisarUrlEnviarXMLSefaz(XMLEncioVenda, pathVendaNFCe);
                            }
                            else
                            {
                                MessageBox.Show("XML de Envio não Validado", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Erro ao Assinar e Serealizar XML de Envio NFC-e.", "Erro Nota Fiscal Consumnidor Eletronico", MessageBoxButtons.OK);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Erro ao Gerar XML de Envio NFC-e.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    #endregion 
                }

                #endregion

                #endregion

                #endregion

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

                return false;
            }
        }

        public bool ValidarXml(XmlDocument xmlEnvelopado)
        {
            try
            {
                validarRegraNegocios = new ValidarRegraNegocios();

                return validarRegraNegocios.ValidarEnvio(pathVendaCFe + "\\XMLs\\SERVICOS\\EMITIR\\EMITIR_ENVELOPE.xml", pathVendaCFe + "\\XMLs\\SCHEMAS\\" + "enviNFe_v4.00.xsd");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro Validador XML", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }
        }

        public void PesquisarUrlEnviarXMLSefaz(XmlDocument xmlLoteAssinadoEnvelopado, string pathNFCe)
        {
            try
            {
                DataTable dadosTabela = new DataTable();

                urlRegraNegocios = new UrlRegraNegocios();

                dadosTabela = urlRegraNegocios.PesquisaUrl(frmVenda.idTipoAmbiente, "nfeAutorizacaoLote");

                if (dadosTabela.Rows.Count > 0)
                {
                    string url = dadosTabela.Rows[0]["URL"].ToString().Trim();
                    string servico = dadosTabela.Rows[0]["SERVICO"].ToString().Trim();

                    url_ = url.Replace("?wsdl", "");
                    action_ = url.Replace("?wsdl", "") + "?op=" + servico;

                    enviarDocumentoSefazRegraNegocios = new EnviarDocumentoSefazRegraNegocios();

                    string pastaSalvar = (pathVendaNFCe + "\\XMLs\\SERVICOS\\EMITIR\\ENVIO_RETORNO.xml");

                    bool ret = enviarDocumentoSefazRegraNegocios.EnviarXmlSefaz(frmVenda.razaoEmitente.Trim().Trim(), url_, action_, xmlLoteAssinadoEnvelopado, pastaSalvar);

                    if (ret == true)
                    {
                        LerConfigXml(pastaSalvar);

                        if (cStatus.Trim().Equals("100"))
                        {
                            GerarXmlProcNFe();

                            if (baixar == true)
                            {
                                //FECHAR VENDA
                            }
                            else
                            {
                                if (fechCaixa == true)
                                {
                                    if (frmVenda.imprimirCupom == true)
                                    {
                                        ImprimirCupons();
                                    }

                                    frmVenda.FecharStatusPagamentoVennda();
                                    frmVenda.FecharStatusVenda();
                                    frmVenda.FecharVendaAberto();
                                    frmVenda.BaixaGastoCliente(limiteCliente, gastoCliente, totalVenda, _idCliente);
                                    frmVenda.LimparCampos();
                                    frmVenda.DeletarTemp();
                                }
                            }

                            if (vendaXml == true)
                            {
                                ExportarItemVendaXml();
                            }

                            if (pagamentoVendaXml == true)
                            {
                                ExportarPagamentoVendasXml();
                            }

                            LimparCampos();

                            if (fechCaixa == true)
                            {
                                if (frmVenda.imprimirCupom == false)
                                {
                                    MessageBox.Show("Venda Numero: " + numVenda.ToString().PadLeft(6, '0') + " Foi realizado com Sucesso...\n\nPara Retirar segunda Via do Cupom Tecle [F7].", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                            else
                            {
                                if (frmVenda.cupomFiscal == true)
                                {
                                    MessageBox.Show("Erro ao Finalizar Venda NFC-e Numero: " + lblNumVenda.Text, "Erro na Venda", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                else
                                {
                                    MessageBox.Show("Erro ao Enviar Venda Numero: " + lblNumVenda.Text, "Erro na Venda", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }

                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Retorno Numero : " + cStatus + ".\nMotivo: " + xMotivo, "Retorno SEFAZ", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Serviço [nfeAutorizacaoLote] da URL não foi Localizado na Base de Dados Banco.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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

                    if (x.NodeType == XmlNodeType.Element && x.Name == "verAplic")
                        verAplic = (x.ReadString());

                    if (x.NodeType == XmlNodeType.Element && x.Name == "dhRecbto")
                        dhRecbto = (x.ReadString());

                    if (x.NodeType == XmlNodeType.Element && x.Name == "nProt")
                        nProt = (x.ReadString());

                    if (x.NodeType == XmlNodeType.Element && x.Name == "digVal")
                        digVal = (x.ReadString());

                    if (x.NodeType == XmlNodeType.Element && x.Name == "chNFe")
                        chNFe = (x.ReadString());
                }

                x.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void GerarXmlProcNFe()
        {
            try
            {
                XmlDocument xmlAssinado = new XmlDocument();
                XmlDocument xmlProcNFe = new XmlDocument();

                //BUSCA XML ASSINADO
                xmlAssinado.Load(pathVendaNFCe + "\\XMLs\\SERVICOS\\EMITIR\\ENVIO_ASSINADO.xml");

                xmlRegraNegocios = new XmlRegraNegocios();

                xmlProcNFe = xmlRegraNegocios.GerarXmlProcNFe(frmVenda.versao, frmVenda.idTipoAmbiente, verAplic, chNFe, dhRecbto, nProt, digVal, cStatus, xMotivo);

                GerarSalvarArquivoCustodia();

                XmlDistNFe(xmlAssinado.OuterXml, xmlProcNFe.OuterXml);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void XmlDistNFe(string strArqNFe, string strProtNfe)
        {
            StreamWriter swProc = null;
            string end = "";
            string strXmlProcNfe = "";

            try
            {
                xmlRegraNegocios = new XmlRegraNegocios();

                strXmlProcNfe = xmlRegraNegocios.GerarXMLProcNFCe(frmVenda.versao, strArqNFe, strProtNfe);

                ano = DateTime.Now.Year.ToString();
                mes = DateTime.Now.Month.ToString().PadLeft(2, '0');

                if (strXmlProcNfe.Trim() != "")
                {
                    end = (enderecoCustodia + chNFe + "-proc.xml");

                    //SAlVAR XML EM FORMATO DE TEXTO
                    swProc = File.CreateText(end);
                    swProc.Write(strXmlProcNfe);

                    fechCaixa = true;
                }
                else
                {
                    fechCaixa = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (swProc != null)
                {
                    swProc.Close();
                }
            }
        }

        public void SalvarXmlCustodiaTemp(string xml, string end)
        {
            try
            {
                //SALVAR ARQUIVO TEMP
                XmlDocument xmlProc = new XmlDocument();
                xmlProc.LoadXml(xml.ToString());
                xmlProc.Save(end);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void GerarSalvarArquivoCustodia()
        {
            try
            {
                XmlDocument xmlCustodia = new XmlDocument();

                string ano, mes = "";

                ano = DateTime.Now.Year.ToString();
                mes = DateTime.Now.Month.ToString().PadLeft(2, '0').Trim();

                enderecoCustodia = (frmVenda.endCustodia + "\\NFCE\\" + frmVenda.cnpjEmitente.Replace(".", "").Replace("-", "").Replace("/", "").Trim() + "\\" + ano + "\\" + mes + "\\CX" + Convert.ToInt32(frmVenda.numCaixa) + "\\");

                if (!Directory.Exists(enderecoCustodia))
                {
                    Directory.CreateDirectory(enderecoCustodia);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private XmlDocument AssinarSerealizarXmlNFCe(XmlDocument xmlEnvio)
        {
            XmlDocument xmlEnvLote = new XmlDocument();

            string _uri = "infNFe";

            int idRet = 0;

            try
            {
                //TIPO DE DOCUMENTO PARA ASSINAR
                int tipoDoc = 1;

                //ASSINATURA DIGITAL
                var store = new X509Store(StoreName.My, StoreLocation.CurrentUser);

                store.Open(OpenFlags.ReadOnly);

                var cert = store.Certificates.Find(X509FindType.FindBySubjectName, frmVenda.razaoEmitente.Trim(), true)[0];

                assinaturaDigital = new AssinaturaDigital();

                idRet = assinaturaDigital.AssinarDocUmento(xmlEnvio.OuterXml, _uri, cert, tipoDoc, pathVendaCFe);

                if (idRet == 0)
                {
                    xmlAssinado = new XmlDocument();

                    string enderecoSalvar = (pathVendaCFe + "\\XMLs\\SERVICOS\\EMITIR\\ENVIO_ASSINADO.xml");

                    StreamReader strmAssinado = new StreamReader(enderecoSalvar);
                    xmlAssinado.Load(strmAssinado);

                    XmlDocument XMLfile = new XmlDocument();
                    StreamReader strm = new StreamReader(enderecoSalvar);
                    XMLfile.Load(strm);

                    REGRA_NEGOCIOS.enviNFe enviNFe = new REGRA_NEGOCIOS.enviNFe
                    {
                        versao = frmVenda.versao,
                        idLote = "000001",
                        indSinc = "1"
                    };

                    serealizarRegraNegocios = new SerealizarRegraNegocios();
                    xmlEnvLote = serealizarRegraNegocios.SerializarNFe(enviNFe);

                    XmlNode newNode = xmlEnvLote.ImportNode(XMLfile.DocumentElement, true);
                    xmlEnvLote.DocumentElement.AppendChild(newNode);

                    XMLfile = new XmlDocument();
                    XMLfile.LoadXml(xmlEnvLote.OuterXml);
                    XMLfile.Save(pathVendaCFe + "\\XMLs\\SERVICOS\\EMITIR\\ENVIO_SEREALIZADO.xml");

                    xmlRegraNegocios = new XmlRegraNegocios();

                    XmlDocument xmlAssinadoEnvelopado = xmlRegraNegocios.EnveloparXMLEnvioDocAssinado(XMLfile.OuterXml, pathVendaCFe);

                    return xmlEnvLote;
                }
                else
                {
                    xmlEnvLote = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return xmlEnvLote;
        }

        public void GerarEndercoCustodiaNFCe()
        {
            try
            {
                string folder = (pathCustodia + "\\NFCE\\" + ano + "\\" + mes + "\\" + "Cx" + numCaixa);

                //Se o diretório não existir...
                if (!Directory.Exists(folder))
                {
                    //Criamos um com o nome folder
                    Directory.CreateDirectory(folder);
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

                ChaveCupomNFCe = gerarChaveRegraNegocios.GerarChave(numVenda, frmVenda.cnpjEmitente, cUf, sessao);

                digitoVefificador = gerarChaveRegraNegocios.digitoRetorno.ToString();

                lblChave.Text = ChaveCupomNFCe.Trim();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static String lpadTo(String input, int width, char ch)
        {
            String strPad = "";

            StringBuilder sb = new StringBuilder();
            sb = new StringBuilder(input.Trim());

            while (sb.Length < width)
                sb.Insert(0, ch);
            strPad = sb.ToString();

            if (strPad.Length > width)
            {
                strPad = strPad.Substring(0, width);
            }

            return strPad;
        }

        public void PesquisarCstPis()
        {
            try
            {
                pis = new PIS();
                pisRegraNegocios = new PisRegraNegocios();
                DataTable dadostabelaPis = new DataTable();

                pis.descricao = venda.cstPis;
                dadostabelaPis = pisRegraNegocios.PesquisarAliquotaPis(pis);

                if (dadostabelaPis.Rows.Count > 0)
                {
                    ppis = dadostabelaPis.Rows[0]["ALIQ"].ToString().Trim().Replace(",", ".").Replace(" ", "");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção");
            }
        }

        private void frmFechamentoVenda_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmVenda.DeletarArquivoVendaTxt();
        }

        private void txtTotal_MouseMove(object sender, MouseEventArgs e)
        {
            txtValor.Focus();
            txtValor.SelectAll();
        }

        private void btnDinheiro_Click(object sender, EventArgs e)
        {
            try
            {
                tipoPagamento = 1;

                PesquisarTipoPagamentoDinheiro();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                tipoPagamento = 2;

                PesquisarTipoPagamentoCartao();

                txtValor.Focus();
                txtValor.SelectAll();
                txtValor.Select();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                tipoPagamento = 3;

                PesquisarTipoPagamentoCheque();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAberto_Click(object sender, EventArgs e)
        {
            try
            {
                frmPesquisarCliente fPesquisarCliente = new frmPesquisarCliente(this);
                fPesquisarCliente.ShowDialog();

                if (_idCliente > 0)
                {
                    PesquidarTipoPagamentoAberto();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnNotaPaulista_Click(object sender, EventArgs e)
        {
            frmCpfCnpj frmCpfCnpj = new frmCpfCnpj(frmVenda);
            frmCpfCnpj.ShowDialog();

            frmVenda.PesquisarTemp();

            lblCpf.Text = frmVenda.cpfCnpjCliente.Trim();
        }

        private void txtTroco_MouseMove(object sender, MouseEventArgs e)
        {
            txtValor.Focus();
            txtValor.SelectAll();
        }

        private void btnPlaca_Click(object sender, EventArgs e)
        {
            frmPlaca fPlaca = new frmPlaca(frmVenda);
            fPlaca.ShowDialog();

            frmVenda.PesquisarPlaca();

            if (placaAut == true)
            {
                lblPlacaAutorizar.Visible = true;
                lblKmAutorizar.Visible = true;
                lblPlaca.Visible = true;
                lblKm.Visible = true;
                btnPlaca.Enabled = true;

                lblKm.Text = frmVenda.km.Trim();
                lblPlaca.Text = frmVenda.descPlaca.Trim();
            }
            else
            {
                lblPlacaAutorizar.Visible = false;
                lblKmAutorizar.Visible = false;
                lblPlaca.Visible = false;
                lblKm.Visible = false;
                btnPlaca.Enabled = false;
            }
        }

        private void txtValor_Enter(object sender, EventArgs e)
        {
            txtValor.Focus();
            txtValor.SelectAll();
        }

        public void Pesquisarcofins()
        {
            try
            {
                cofins = new COFINS();
                cofinsRegraNegocios = new CofinsRegraNegocios();
                DataTable dadosTabelaCofins = new DataTable();

                cofins.descricao = venda.cstPis;
                dadosTabelaCofins = cofinsRegraNegocios.PesquisarAliquotaPis(cofins);

                if (dadosTabelaCofins.Rows.Count > 0)
                {
                    pCofins = dadosTabelaCofins.Rows[0]["ALIQ"].ToString().Trim().Replace(",", ".").Replace(" ", "");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção");
            }
        }

        public void PesquisarCSOSN()
        {
            try
            {
                DataTable dadosTabelaCSOSN = new DataTable();
                csosn = new CSOSN();
                csosnregraNegocios = new CsosnregraNegocios();

                csosn.cst = cstProduto;

                dadosTabelaCSOSN = csosnregraNegocios.PesquisarCSOSN(csosn);

                if (dadosTabelaCSOSN.Rows.Count > 0)
                {
                    tipoCSOSN = dadosTabelaCSOSN.Rows[0]["CSOSN"].ToString().Trim();
                }
                else
                {
                    cstProduto = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção");
            }
        }

        private void txtRecebimento_TextChanged(object sender, EventArgs e)
        {
            txtValor.Focus();
        }

        public int getNumberRandom()
        {
            Random number = new Random();

            int retorno = 0;

            if (frmVenda.tipoVenda == 1)
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

        private void LimparCampos()
        {
            _idCliente = 0;
        }

        public void PesquisarTipoPagamentoDinheiro()
        {
            try
            {
                string valor_ = Convert.ToDecimal(txtValor.Text).ToString("N2");
                decimal somma = 0;
                decimal troco = 0;
                decimal total = Convert.ToDecimal(lblValorTotal.Text);

                if (Convert.ToDecimal(txtValor.Text) > 0)
                {
                    gdvTipoPgto.Rows.Insert(0, 1, "DINHEIRO", valor_);
                }

                if (gdvTipoPgto.Rows.Count > 0)
                {
                    for (int i = 0; i < gdvTipoPgto.Rows.Count; i++)
                    {
                        somma += Convert.ToDecimal(gdvTipoPgto.Rows[i].Cells["Valor"].Value);
                    }

                    troco = (somma - total);

                    txtTroco.Text = troco.ToString("N2");

                    if (troco >= 0)
                    {
                        txtValor.Text = "0,00";

                        LiberarBotoesFecharCaixa();
                        btnFecharVenda.Focus();
                    }
                    else
                    {
                        troco = (troco * -1);
                        txtValor.Text = troco.ToString("N2");

                        txtValor.Focus();
                        txtValor.SelectAll();
                    }

                    txtValor.Focus();
                    txtValor.SelectAll();

                    txtRecebimento.Text = somma.ToString("N2");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção");
            }
        }

        public void PesquisarTipoPagamentoCartao()
        {
            try
            {
                decimal valor_ = Convert.ToDecimal(txtValor.Text);
                decimal somma = 0;
                decimal troco = 0;

                decimal total = Convert.ToDecimal(lblValorTotal.Text);

                if (Convert.ToDecimal(txtValor.Text) > 0)
                {
                    gdvTipoPgto.Rows.Insert(0, 2, "CARTÃO", decimal.Round(valor_, 5).ToString("N2"));
                }

                if (gdvTipoPgto.Rows.Count > 0)
                {
                    for (int i = 0; i < gdvTipoPgto.Rows.Count; i++)
                    {
                        somma += Convert.ToDecimal(gdvTipoPgto.Rows[i].Cells["valor"].Value);
                    }

                    troco = (somma - total);

                    if (troco >= 0)
                    {
                        txtValor.Text = "0,00";

                        LiberarBotoesFecharCaixa();

                        txtValor.Focus();
                        txtValor.SelectAll();
                    }
                    else
                    {
                        troco = (troco * -1);

                        txtValor.Text = troco.ToString("N2");

                        txtValor.Focus();
                        txtValor.SelectAll();
                    }

                    txtTroco.Text = troco.ToString("N2");

                    txtRecebimento.Text = somma.ToString("N2");

                    txtValor.Focus();
                    txtValor.SelectAll();
                    txtValor.Focus();

                    Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção");
            }
        }

        public void PesquisarTipoPagamentoCheque()
        {
            try
            {
                decimal valor_ = Convert.ToDecimal(txtValor.Text);
                decimal somma = 0;
                decimal troco = 0;
                decimal total = Convert.ToDecimal(lblValorTotal.Text);

                if (Convert.ToDecimal(txtValor.Text) > 0)
                {
                    gdvTipoPgto.Rows.Insert(0, 3, "CHEQUE", decimal.Round(valor_, 5).ToString("N2"));
                }

                if (gdvTipoPgto.Rows.Count > 0)
                {
                    for (int i = 0; i < gdvTipoPgto.Rows.Count; i++)
                    {
                        somma += Convert.ToDecimal(gdvTipoPgto.Rows[i].Cells["valor"].Value);
                    }

                    troco = (somma - total);

                    txtTroco.Text = troco.ToString("N2");

                    if (troco >= 0)
                    {
                        txtValor.Text = "0,00";
                        LiberarBotoesFecharCaixa();
                        btnFecharVenda.Focus();
                    }
                    else
                    {
                        troco = (troco * -1);
                        txtValor.Text = troco.ToString("N2");
                        txtValor.Focus();
                        txtValor.SelectAll();
                    }

                    txtRecebimento.Text = somma.ToString("N2");

                    txtValor.Focus();
                    txtValor.SelectAll();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção");
            }
        }

        public void PesquidarTipoPagamentoAberto()
        {
            try
            {
                decimal valor_ = Convert.ToDecimal(txtValor.Text);
                decimal somma = 0;
                decimal troco = 0;
                decimal total = Convert.ToDecimal(lblValorTotal.Text);

                if (Convert.ToDecimal(txtValor.Text) > 0)
                {
                    gdvTipoPgto.Rows.Insert(0, 4, "ABERTO", decimal.Round(valor_, 5).ToString("N2"));
                }

                if (gdvTipoPgto.Rows.Count > 0)
                {
                    for (int i = 0; i < gdvTipoPgto.Rows.Count; i++)
                    {
                        somma += Convert.ToDecimal(gdvTipoPgto.Rows[i].Cells["valor"].Value);
                    }

                    troco = (somma - total);

                    txtTroco.Text = troco.ToString("N2");

                    if (troco >= 0)
                    {
                        txtValor.Text = "0,00";
                        LiberarBotoesFecharCaixa();
                        btnFecharVenda.Focus();
                    }
                    else
                    {
                        troco = (troco * -1);
                        txtValor.Text = troco.ToString("N2");
                        txtValor.Focus();
                        txtValor.SelectAll();
                    }

                    txtRecebimento.Text = somma.ToString("N2");

                    txtValor.Focus();
                    txtValor.SelectAll();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção");
            }
        }

        public void PesquisarTipoPagamentoRedeCom()
        {
            try
            {
                decimal valor_ = Convert.ToDecimal(txtValor.Text);
                decimal somma = 0;
                decimal troco = 0;
                decimal total = Convert.ToDecimal(lblValorTotal.Text);

                if (Convert.ToDecimal(txtValor.Text) > 0)
                {
                    gdvTipoPgto.Rows.Insert(0, 5, "REDE", valor_.ToString("N2"));
                }

                if (gdvTipoPgto.Rows.Count > 0)
                {
                    for (int i = 0; i < gdvTipoPgto.Rows.Count; i++)
                    {
                        somma += Convert.ToDecimal(gdvTipoPgto.Rows[i].Cells["valor"].Value);
                    }

                    troco = (somma - total);
                    txtTroco.Text = troco.ToString("N2");

                    if (troco >= 0)
                    {
                        txtValor.Text = "0,00";
                        LiberarBotoesFecharCaixa();
                        btnFecharVenda.ForeColor = Color.Green;
                        btnFecharVenda.Focus();
                    }
                    else
                    {
                        troco = (troco * -1);
                        txtValor.Text = troco.ToString("N2");
                        txtValor.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção");
            }
        }

        public void ExportarItemVendaXml()
        {
            try
            {
                conn = new SqlConnection(ConfigurationManager.ConnectionStrings[frmVenda.stringConexaoXml].ToString());

                string numeroPastaVenda = numVenda.ToString();
                string pathVenda = (pathVendaXML + numeroPastaVenda + ".XML");

                DataSet dsVenda = new DataSet();

                daVenda = new SqlDataAdapter("select ID, ID_PROD, COD_BARRA, QUANT, PRECO, TOTAL, ITEM, DATA, NUM_VENDA from VENDA where VENDA.NUM_VENDA = " + numVenda, conn);
                daVenda.Fill(dsVenda, tabela);
                dsVenda.WriteXml(pathVenda);
            }
            catch (Exception)
            {
                MessageBox.Show("Error no Método Exportar Item de Venda XML.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public void ExportarPagamentoVendasXml()
        {
            try
            {
                conn = new SqlConnection(ConfigurationManager.ConnectionStrings[frmVenda.stringConexaoXml].ToString());

                string numeroPastaPgtoVenda = numVenda.ToString();
                string pathF_Pgto = (pathFormaPgto + numeroPastaPgtoVenda + ".XML");

                DataSet dsVenda = new DataSet();

                daVenda = new SqlDataAdapter("SELECT NUM_CUPOM, TIPO_PAGAMENTO, VALOR, DT, TROCO, CNPJ FROM PAGAMENTO_VENDA where PAGAMENTO_VENDA.NUM_CUPOM =" + numVenda, conn);
                daVenda.Fill(dsVenda, tabela);
                dsVenda.WriteXml(pathF_Pgto);
            }
            catch (Exception)
            {
                MessageBox.Show("Error no Método Exportar PagamentoVendas.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void LiberarBotoesFecharCaixa()
        {
            try
            {
                lblFecharVenda.Enabled = true;
                lblCancelarVenda.Enabled = true;

                btnFecharVenda.Enabled = true;
                btnCancelarVenda.Enabled = true;
                btnLimpar.Enabled = true;

                txtValor.Focus();
                txtValor.SelectAll();
            }
            catch (Exception)
            {
                MessageBox.Show("Error no Método LiberarBotoesFecharCaixa.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnFecharVenda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                txtValor.Focus();
                btnFecharVenda.ForeColor = Color.Black;
                gdvTipoPgto.DataSource = null;
            }

            if (e.KeyCode == Keys.F11)
            {
                LimparFormaPagto();
                txtValor.Focus();
            }
        }

        private void txtTotal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.PageUp)
            {
                PesquisarTipoPagamentoCheque();
            }
        }

        private void btnCancelarVenda_Click(object sender, EventArgs e)
        {
            LimparCampos();
            this.Close();
        }

        public int CadastrarPagementoVenda()
        {
            try
            {
                if (gdvTipoPgto.Rows.Count > 0)
                {
                    pagamentoVendaC = new PagamentoVendaC();
                    pagamentoVendaRegraNegocios = new PagamentoVendaRegraNegocios();

                    decimal mediaTroco = 0;

                    int cont = 0;

                    for (int i = 0; i < gdvTipoPgto.Rows.Count; i++)
                    {
                        tipoPagamento = Convert.ToInt32(gdvTipoPgto.Rows[i].Cells["colId"].Value.ToString());
                        valorVenda = Convert.ToDecimal(gdvTipoPgto.Rows[i].Cells["Valor"].Value.ToString());

                        //contar qtde de linha da grid
                        cont = Convert.ToInt32(gdvTipoPgto.Rows.Count);

                        mediaTroco = (mediaTroco + 1);
                        troco = Convert.ToDecimal(txtTroco.Text);

                        pagamentoVendaC.idCliente = idCliente;
                        pagamentoVendaC.idUsuario = idUsuario;
                        pagamentoVendaC.tipoPagamento = tipoPagamento;
                        pagamentoVendaC.valor = valorVenda;
                        pagamentoVendaC.cnpj = cnpjDest.Trim();
                        pagamentoVendaC.numVenda = numVenda;
                        pagamentoVendaC.baixado = false;
                        pagamentoVendaC.data = DateTime.Now.Date;
                        pagamentoVendaC.fechado = false;
                        pagamentoVendaC.numCaixa = numCaixa;
                        pagamentoVendaC.tag = frmVenda.cupomFiscal;

                        //pagameto tipo dinheiro
                        if (tipoPagamento == 1)
                        {
                            troco = Convert.ToDecimal(txtTroco.Text);

                            troco = (troco / mediaTroco);

                            pagamentoVendaC.troco = troco;
                        }
                        else
                        {
                            //pagamento difrente de dinheiro
                            if (cont == 1)
                            {
                                //garantir que nao realiza a venda com valor com troco do pagameto diferente de dinheiro
                                pagamentoVendaC.valor = (valorVenda - troco);

                                pagamentoVendaC.troco = 0;
                            }
                            else
                            {
                                pagamentoVendaC.valor = valorVenda;
                            }
                        }

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

                    //LIMPAR VARIAVEIS
                    valorVenda = 0;
                    tipoPagamento = 0;
                    pagamentoVendaC.troco = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção");
            }

            return idRet;
        }

        public void CadastrarVendaChaveWeb()
        {
            try
            {
                vendaChaveAcesso = new VendaChaveAcesso();

                vendaChaveAcesso.CnpjEmitente = cnpjEmitente.Replace(".", "").Replace("-", "").Replace("/", "").Trim();
                vendaChaveAcesso.CnpjDestinatario = cnpjCliente.Replace(".", "").Replace("-", "").Replace("/", "").Trim();
                vendaChaveAcesso.ChaveCFe = chaveCupom.Trim();
                vendaChaveAcesso.Valor = valorAberto;
                vendaChaveAcesso.Data = DateTime.Now;
                vendaChaveAcesso.Fechado = false;
                vendaChaveAcesso.NumVenda = numVenda;
                vendaChaveAcesso.Condutor = frmVenda.condutor.Trim();
                vendaChaveAcesso.Placa = lblPlaca.Text.Trim();

                int idRet = vendaRegraNegocios.CadastrarVendaChaveWeb(vendaChaveAcesso, listaVenda);

                if (idRet == 0)
                {
                    MessageBox.Show("Erro ao Cadastrar Venda CF-e Cupom.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void gdvTipoPagamentos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (tipoPagamento == 1)
                {
                    PesquisarTipoPagamentoDinheiro();
                }
                else if (tipoPagamento == 2)
                {
                    PesquisarTipoPagamentoCartao();
                }
                else if (tipoPagamento == 3)
                {
                    PesquisarTipoPagamentoCheque();
                }
                else if (tipoPagamento == 4)
                {
                    frmPesquisarCliente fPesquisarCliente = new frmPesquisarCliente(this);
                    fPesquisarCliente.ShowDialog();

                    if (_idCliente > 0)
                    {
                        PesquidarTipoPagamentoAberto();
                    }
                }
                else if (tipoPagamento == 5)
                {
                    PesquisarTipoPagamentoRedeCom();
                }

                txtValor.Focus();
                txtValor.SelectAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimparFormaPagto();
        }

        public void LimparFormaPagto()
        {
            btnFecharVenda.Enabled = true;
            txtValor.Text = "0,00";
            txtTroco.Text = "0,00";
            txtRecebimento.Text = "0,00";
            btnFecharVenda.Enabled = false;
            btnLimpar.Enabled = false;
            gdvTipoPgto.Rows.Clear();
            gdvTipoPgto.Refresh();

            ListarVenda();

            txtValor.Focus();
            txtValor.SelectAll();
        }

        private void gdvTipoPgto_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string tipo = "";
            decimal preco = 0;
            decimal total = 0;
            decimal soma = 0;
            decimal recedido = 0;

            tipo = gdvTipoPgto.Rows[e.RowIndex].Cells["Descricao"].Value.ToString();
            preco = Convert.ToDecimal(gdvTipoPgto.Rows[e.RowIndex].Cells["Valor"].Value.ToString());
            total = Convert.ToDecimal(lblValorTotal.Text);

            if (MessageBox.Show("Realmente Deseja Deletar Tipo Pagamento Valor de " + preco.ToString("C2") + " Especie: " + tipo + ".", "Deletar Tipo Pagamento", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                gdvTipoPgto.Rows.RemoveAt(e.RowIndex);
                gdvTipoPgto.Refresh();

                for (int i = 0; i < gdvTipoPgto.Rows.Count; i++)
                {
                    soma += Convert.ToDecimal(gdvTipoPgto.Rows[i].Cells["Valor"].Value.ToString());
                }

                recedido = (total - soma);
                troco = 0;
                txtTroco.Text = (recedido * -1).ToString("N2");
                txtValor.Text = recedido.ToString("N2");

                btnFecharVenda.Enabled = false;
                btnLimpar.Enabled = false;
                txtValor.Focus();

                if (soma > total)
                {
                    txtValor.Text = "0,00";
                    troco = (soma - total);
                    txtTroco.Text = troco.ToString("N2");

                    btnFecharVenda.Enabled = true;
                    btnLimpar.Enabled = true;
                    btnFecharVenda.Focus();
                }

                //LIMPAR VARIAVEIS
                tipo = "";
                preco = 0;
                total = 0;
                soma = 0;
                recedido = 0;

                txtRecebimento.Focus();
                txtRecebimento.SelectAll();
            }
        }
    }
}
