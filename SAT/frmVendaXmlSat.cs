using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OBJETO_TRANSFERENCIA;
using System.IO;
using System.Runtime.InteropServices;
using REGRA_NEGOCIOS;
using IMPRESSORA;
using System.Xml;
using Vip.Printer.Enums;
using Vip.Printer;

namespace SAT
{
    public partial class frmVendaXmlSat : Form
    {
        frmVenda frmVenda;

        public frmVendaXmlSat(string[] arq, int nCaixa, bool cupom, string end, string endResp, frmVenda fVenda)
        {
            InitializeComponent();

            this.frmVenda = fVenda;

            this.arquivos = arq;
            this.numCaixa = nCaixa;

            this.tipoCupom = cupom;
            this.endereco = end;
            this.enderecoXmlCustodiaResp = endResp;
            this.dgvVendas.AutoGenerateColumns = false;
        }

        #region VARIAVEIS

        public string[] arquivos;
        public int numCaixa, numVenda = 0;
        public bool tipoCupom;
        public string endereco = "";
        public string dadosSat, chaveCupom, qrCod, stringRetSat = "";
        public int sessao = 0;

        public string DadosCabecalhoCupom = "";
        public string DadosCorpoCupom = "";
        public string DadosPagamentoCupom = "";
        public string DadosFinaisCupom = "";
        public string DadosSatCupom = "";
        public string DadosCupomAberto = "";

        public string descricaPagamento = "";
        public string nserieSAT, nCFe = "";

        public decimal totalVenda, valorAberto = 0;
        public int idCliente = 0;
        public bool placa;
        public string km, descPlaca, cupom, nomeCliente = "";
        public int idRetorno = 0;
        public string cpfCnpjCliente = "";

        public string esquerda, centrarlizar, direita = "";

        public string enderecoXmlCustodia = "";
        public string enderecoXmlCustodiaResp = "";
        public string numNome = "";
        public string end = "";

        #endregion

        #region CLASSES E OBJETOS

        SoftwareHouse softwareHouse;
        VendaC vendaC;
        VendaRegraNegocios vendaRegraNegocios;
        EscPosElgin escPosElgin;
        PagamentoVendaC pagamentoVendaC;
        PagamentoVendaRegraNegocios pagamentoVendaRegraNegocios;
        BEMATECH bematechRegraNegocios;
        ESCPOS escPos;
        ImpressoraC impressoraC;
        CABECALHO cabecalho;
        PlacaC placaC;
        PlacaRegraNegocios placaRegraNegocios;
        ClienteC clienteC;
        ClienteRegraNegocios clienteRegraNegocios;
        TempRegraNegocios tempRegraNegocios;

        public class Vendas
        {
            public string id { get; set; }
            public string endereco { get; set; }
            public string NumCaixa { get; set; }
        }

        #endregion

        private void frmVendaXmlSat_Load(object sender, EventArgs e)
        {
            Listar();
        }

        public void Listar()
        {
            List<Vendas> lista = new List<Vendas>();

            int cont = 0;

            txtNumCupom.Text = (frmVenda.numVenda - 1).ToString();

            foreach (var item in arquivos)
            {
                if (tipoCupom == false)
                {
                    lista.Add(new Vendas()
                    {
                        endereco = arquivos[cont].Replace(endereco, "").Replace(".xml", "").ToUpper().Trim(),
                        NumCaixa = arquivos[cont].Replace(endereco, "").Substring(0, 1).Replace(".XML", ""),

                        id = (cont + 1).ToString().PadLeft(3, '0')
                    });
                }
                else
                {
                    lista.Add(new Vendas()
                    {
                        endereco = arquivos[cont].Replace(endereco, "").Replace(".xml", "").Replace(".XML", "").Trim(),
                        NumCaixa = arquivos[cont].Replace(endereco, "").Substring(0, 1).Replace(".XML", ""),
                        id = (cont + 1).ToString().PadLeft(3, '0')
                    });
                }

                cont++;
            }

            this.dgvVendas.DataSource = null;
            this.dgvVendas.DataSource = lista;

            lblQtde.Text = dgvVendas.Rows.Count.ToString().PadLeft(3, '0');
            lblEndResp.Text = enderecoXmlCustodiaResp.Trim();
            lblEndPath.Text = endereco.Trim();

            PesquisarSofwareHouse();
        }

        private void dgvVendas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            VendaFiscal(e);
        }

        public void VendaFiscal(DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvVendas.Columns[e.ColumnIndex].Name.Trim().Equals("colSel"))
                {
                    if (MessageBox.Show("Realmente Deseja Imprimir Cupom Fiscal da Venda Numero", "Confirmação de Impressão de Cupom", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        if (dgvVendas.Rows.Count > 0)
                        {
                            int index = dgvVendas.CurrentRow.Index;

                            EnviarSefaz(index);
                        }
                        else
                        {
                            MessageBox.Show("Não Contém Dados de Cupom(ns) para Ser(em) Impressos.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvVendas_KeyDown(object sender, KeyEventArgs e, DataGridViewCellEventArgs ee)
        {
            if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.I)
            {

            }

            if (e.KeyCode == Keys.Enter)
            {
                VendaFiscal(ee);
            }
        }

        public void PesquisarSofwareHouse()
        {
            try
            {
                XmlTextReader x = new XmlTextReader(frmVenda.pathDadoSoftHouse);
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

        public void VendaCupom(EventArgs e)
        {
            try
            {
                if (dgvVendas.Rows.Count > 0)
                {
                    PesquisarSofwareHouse();

                    for (int i = 0; i < dgvVendas.Rows.Count; i++)
                    {
                        EnviarSefaz(i);
                    }

                    this.OnLoad(e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void EnviarSefaz(int linha)
        {
            try
            {
                numVenda = Convert.ToInt32(dgvVendas.Rows[linha].Cells["colEmdereco"].Value.ToString().Substring(1, 10).Trim());

                end = endereco + dgvVendas.Rows[linha].Cells["colEmdereco"].Value.ToString() + ".xml";

                numNome = dgvVendas.Rows[linha].Cells["colEmdereco"].Value.ToString().Trim();

                dadosSat = LerArqTxt(end);

                EnviarDadosSat(dadosSat);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                    string strPathFile = (frmVenda.pathDadosVendaAutorizada + numCaixa.ToString().PadLeft(3, '0') + ".txt");

                    using (FileStream fs = File.Create(strPathFile))
                    {
                        using (StreamWriter sw = new StreamWriter(fs))
                        {
                            sw.Write(senhaDescripto);
                            sw.Close();
                        }
                    }

                    string enderecoExitente = (frmVenda.pathCustodia + ano + "\\" + mes + "\\" + "Cx" + numCaixa);

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

                    try
                    {
                        //EXPORTAR ORCAMENTO DE NAO FISCAL PARA FISCAL
                        File.Move(end, frmVenda.pathXmlCustodiaResp + "\\" + numNome + ".xml");
                    }
                    catch (Exception)
                    {

                        throw;
                    }

                    AlterarVendaFiscal();
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

        public void AlterarVendaFiscal()
        {
            try
            {
                vendaRegraNegocios = new VendaRegraNegocios();

                try
                {
                    string idRet = vendaRegraNegocios.AlterarVendaFiscal(numCaixa, numVenda, true);
                }
                catch
                {
                    MessageBox.Show("Erro ao Alterar Venda Fiscal.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void SalvarUltimaChave()
        {
            XmlTextWriter writer = new XmlTextWriter(frmVenda.pathUltimaVendaCFe + "\\ULTIMA_CHAVE\\CHAVE.xml", null);

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

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (frmVenda.cupomFiscal == true)
            {
                VendaCupom(e);
            }
            else
            {
                if (MessageBox.Show("Para Relaizar Venda Fiscal é necessário S@T está Acionado na Maquilna Local.\n\nAinda Deseja Enviar Venda Fiscal??", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    try
                    {
                        string enderecoVendaXml = (frmVenda.pathVendaCFe + "\\Venda\\" + numCaixa + (txtNumCupom.Text).ToString().PadLeft(10, '0') + ".xml");

                        end = endereco + dgvVendas.Rows[0].Cells["colEmdereco"].Value.ToString() + ".xml";

                        File.Copy(end, frmVenda.pathXmlCupom + numCaixa + (txtNumCupom.Text).ToString().PadLeft(10, '0') + ".xml");

                        numVenda = Convert.ToInt32(txtNumCupom.Text);

                        VendaCupom(e);
                    }
                    catch
                    {
                    }
                }
                else
                {
                    MessageBox.Show("Dados Cupom Realizado com Sucesso", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.OnLoad(e);
                }
            }
        }

        public int getNumberRandom()
        {
            Random number = new Random();
            int retorno = number.Next(999999);
            sessao = retorno;
            return retorno;
        }

        private void btnExportarVenda_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvVendas.Rows.Count > 0)
                {
                    for (int i = 0; i < dgvVendas.Rows.Count; i++)
                    {
                        try
                        {
                            string enderecoVendaXml = (frmVenda.pathVendaCFe + "\\Venda\\" + numCaixa + (txtNumCupom.Text).ToString().PadLeft(10, '0') + ".xml");

                            end = endereco + dgvVendas.Rows[i].Cells["colEmdereco"].Value.ToString() + ".xml";

                            File.Copy(end, frmVenda.pathXmlCupom + (dgvVendas.Rows[i].Cells["colEmdereco"].Value.ToString()).ToString().PadLeft(10, '0') + ".xml");
                        }
                        catch
                        {
                        }
                    }

                    MessageBox.Show("Todos os Dados de Venda Foram Exportados com Sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Não Contém Dados de Venda(s) para ser(em) Exportado(s).", "Etenção", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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

        public void ImprimirUltimoCupoFiscal()
        {
            try
            {
                vendaC = new VendaC();
                vendaRegraNegocios = new VendaRegraNegocios();
                impressoraC = new ImpressoraC();

                DataTable dadosTabelaVenda = new DataTable();

                List<VENDAS> listaVenda = new List<VENDAS>();
                List<FORMA_PAGAMENTOS> listaFomaPagamentos = new List<FORMA_PAGAMENTOS>();
                VENDA_DETALHES vendaDetalhe = new VENDA_DETALHES();

                escPosElgin = new EscPosElgin();

                if (dgvVendas.Rows.Count > 0)
                {
                    if (numCaixa <= 0)
                    {
                        MessageBox.Show("Numero do Caixa não Pode ser Nulo ou menor que Zero.", "Campo Nulo ou Zero", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else if (numVenda <= 0)
                    {
                        MessageBox.Show("Numero da Venda não Pode ser Nulo ou menor que Zero.", "Campo Nulo ou Zero", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        DadosCabecalhoCupom = "";
                        DadosCorpoCupom = "";
                        DadosPagamentoCupom = "";
                        DadosFinaisCupom = "";
                        DadosSatCupom = "";

                        vendaC.numCaixa = numCaixa;
                        vendaC.numVenda = (numVenda);

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
                            pagamentoVendaC.numVenda = (numVenda);
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

                                    if (dadosTabelaPagamentoVenda.Rows[i]["TIPO_PAGTO"].ToString().Trim().Contains("ABERTO") || dadosTabelaPagamentoVenda.Rows[i]["TIPO_PAGTO"].ToString().Trim().Contains("Aberto"))
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

                            vendaDetalhe.versao = frmVenda.versaoSistema.Trim();
                            vendaDetalhe.valorAliquota = Convert.ToDecimal(0);
                            vendaDetalhe.nomeOperador = frmVenda.nomeOperador.Trim();
                            vendaDetalhe.periodo = frmVenda.periodo.Trim();
                            vendaDetalhe.numCaixa = numCaixa.ToString().PadLeft(3, '0').Trim();
                            vendaDetalhe.numVenda = (numVenda).ToString();

                            cabecalho = new CABECALHO();
                            cabecalho.nCFe = nCFe;

                            #endregion

                            if ((frmVenda.nomeImpressora.Trim().Equals("BEMATECH")) || frmVenda.nomeImpressora.Trim().Equals("BEMASAT"))
                            {
                                #region DADOS CUPOM

                                GetCabecalhoCupom();

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

                                string qrCodes = chaveCupom.Replace("CFe", "").Trim() + "|" + DateTime.Now.ToString("ddMMyyyyHHMMss") + "|" + totalVenda + "|" + "|" + numVenda + "|" + qrCod;

                                idRetorno = IMPRESSORA.BemasatImpressora.ComandoTX(centrarlizar, centrarlizar.Length);
                                idRetorno = IMPRESSORA.BemasatImpressora.ImprimeCodigoQRCODE(1, 5, 0, 6, 1, qrCodes);

                                idRetorno = IMPRESSORA.BemasatImpressora.AcionaGuilhotina(0);

                                idRetorno = IMPRESSORA.BemasatImpressora.FechaPorta();
                            }
                            else if (frmVenda.nomeImpressora.Trim().Equals("ESCPOS") || (frmVenda.nomeImpressora.Trim().Equals("ELGIN")))
                            {
                                escPos = new ESCPOS();

                                DadosCabecalhoCupom = escPos.CabecalhoSegundaViaVenda(cabecalho, frmVenda.cupomFiscal);
                                DadosCorpoCupom = escPos.CorpoCupom(listaVenda, vendaC);
                                DadosPagamentoCupom = escPos.FormaPagamento(listaFomaPagamentos, totalVenda);
                                DadosFinaisCupom = escPos.DadosFinaisCupom(vendaDetalhe, frmVenda.cupomFiscal, frmVenda.idTipoVenda);
                                DadosSatCupom = escPos.DadosSat(nserieSAT, DateTime.Now.ToString());

                                cupom = (DadosCabecalhoCupom + DadosCorpoCupom + DadosPagamentoCupom + DadosFinaisCupom + DadosSatCupom);

                                var printer = new Printer(frmVenda.nomeImpressoraPadrao, frmVenda.ObterTipo());

                                printer.Imprimirrelatorio(cupom);

                                printer.AlignCenter();

                                if (frmVenda.idTipoVenda == 1)
                                {
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
                                }
                                else
                                {
                                    printer.NewLines(3);

                                    printer.QrCode(qrCod, QrCodeSize.Size2);
                                }

                                printer.NewLines(3);

                                printer.PartialPaperCut();

                                printer.PrintDocument();

                                printer.InitializePrint();
                            }
                            else if (frmVenda.nomeImpressora.Trim().Equals("EPSON"))
                            {
                                string ano = DateTime.Now.ToString("yyyy").PadLeft(2, '0');
                                string mes = DateTime.Now.ToString("MM").PadLeft(2, '0');

                                enderecoXmlCustodia = (frmVenda.pathCustodia + ano + "\\" + mes + "\\" + "Cx" + numCaixa + "\\" + chaveCupom.Replace("CFe", "") + ".xml");

                                idRetorno = IMPRESSORA.InterfaceEpsonNF.IniciaPorta("USB");

                                idRetorno = IMPRESSORA.InterfaceEpsonNF.EPSON_SAT_Imprimir(enderecoXmlCustodia, "C");

                                if (idRetorno != 0x01)
                                    MessageBox.Show("Erro ao imprimir o Extrato do Sat.", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                                idRetorno = IMPRESSORA.InterfaceEpsonNF.FechaPorta();
                            }

                            //MONTAR E IMPRIMIR CUPOM ABERTO 
                            if (descricaPagamento.Contains("ABERTO") || descricaPagamento.Contains("Aberto"))
                            {
                                MontarCupomAberto();
                            }

                            //ZERAR AS VARIAVEIS
                            impressoraC.detalhes = "";
                            impressoraC.dadosVenda = "";
                            idRetorno = 0;
                        }
                    }
                }
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
                cabecalho = new CABECALHO();

                cabecalho.NomeRazao = frmVenda.razaoSocial;
                cabecalho.Endereco = frmVenda.endereco;
                cabecalho.Numero = frmVenda.numero;
                cabecalho.Bairro = frmVenda.bairro;
                cabecalho.Cep = frmVenda.cep;
                cabecalho.Cidade = frmVenda.cidade;
                cabecalho.Bairro = frmVenda.bairro;
                cabecalho.Uf = frmVenda.uf;
                cabecalho.CNPJ = frmVenda.cnpj;
                cabecalho.IE = frmVenda.ie;
                cabecalho.IM = frmVenda.im;
                cabecalho.CnpjCliente = frmVenda.cpfCnpjCliente;
                cabecalho.Telefone = frmVenda.telefone;
                cabecalho.nCFe = nCFe.PadLeft(9, '0').Trim();

                return cabecalho;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

                return null;
            }
        }

        public void LerChaveXml()
        {
            try
            {
                string endereco = (frmVenda.pathVendaCFe + "\\ULTIMA_CHAVE\\CHAVE.xml");

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

        public void LerXmlRetCustodia()
        {
            try
            {
                string ano, mes = "";

                ano = DateTime.Now.Year.ToString();
                mes = DateTime.Now.Month.ToString().PadLeft(2, '0');

                string endereco = (frmVenda.pathCustodia + ano + "\\" + mes + "\\" + "Cx" + numCaixa);

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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção");
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

        private void MontarCupomAberto()
        {
            try
            {
                BEMATECH cupomBematech = new BEMATECH();

                PesquisarCliente();

                if (cupom.Trim() != "")
                {
                    if ((frmVenda.nomeImpressora.Trim().Equals("BEMATECH")) || (frmVenda.nomeImpressora.Trim().Equals("BEMASAT")))
                    {
                        cupomBematech = new BEMATECH();

                        DadosCabecalhoCupom = cupomBematech.CabecalhoCupom(cabecalho, nCFe, frmVenda.cupomFiscal);
                        DadosCupomAberto = cupomBematech.CupomVendaAberto(valorAberto, nomeCliente, numCaixa, (numVenda - 1), frmVenda.nomeOperador);

                        cupom = (DadosCabecalhoCupom + DadosCupomAberto);

                        idRetorno = IMPRESSORA.BemasatImpressora.ConfiguraModeloImpressora(7);
                        idRetorno = IMPRESSORA.BemasatImpressora.IniciaPorta(frmVenda.numComimp);

                        esquerda = "" + (char)27 + (char)97 + (char)0;
                        centrarlizar = "" + (char)27 + (char)97 + (char)1;
                        direita = "" + (char)27 + (char)97 + (char)2;

                        idRetorno = IMPRESSORA.BemasatImpressora.ComandoTX(esquerda, esquerda.Length);
                        idRetorno = IMPRESSORA.BemasatImpressora.FormataTX(cupom + (char)10 + (char)13, 1, 0, 0, 0, 0);

                        idRetorno = IMPRESSORA.BemasatImpressora.AcionaGuilhotina(0);
                        idRetorno = IMPRESSORA.BemasatImpressora.FechaPorta();
                    }
                    else if (frmVenda.nomeImpressora.Trim().Equals("ESCPOS"))
                    {
                        escPos = new ESCPOS();

                        cupom = (DadosCabecalhoCupom + DadosCupomAberto);

                        DadosCabecalhoCupom = escPos.CabecalhoCupomVendaAberto(cabecalho, nCFe, frmVenda.cupomFiscal);
                        DadosCupomAberto = escPos.CupomVendaAberto(valorAberto, nomeCliente, numCaixa, (numVenda - 1), frmVenda.nomeOperador);

                        string chave = chaveCupom.Replace("CFe", "").Trim();

                        var printer = new Printer(frmVenda.nomeImpressoraPadrao, frmVenda.ObterTipo());

                        printer.Imprimirrelatorio(cupom);

                        printer.PartialPaperCut();

                        printer.PrintDocument();

                        printer.InitializePrint();

                        escPos = new ESCPOS();
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
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção");
            }
        }
    }
}
