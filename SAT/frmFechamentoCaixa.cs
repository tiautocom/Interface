using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using REGRA_NEGOCIOS;
using OBJETO_TRANSFERENCIA;
using System.Drawing.Printing;
using IMPRESSORA;
using Vip.Printer;
using System.IO;

namespace SAT
{
    public partial class frmFechamentoCaixa : Form
    {
        frmVenda frmVenda;

        public frmFechamentoCaixa(frmVenda fVenda)
        {
            InitializeComponent();

            this.frmVenda = fVenda;

            this.gdvPagamento.AutoGenerateColumns = false;
            this.gdvPagamento.RowTemplate.Height = 35;
            this.gdvDados.RowTemplate.Height = 25;
        }

        #region CLASSES E OBJETOS

        ParametroC parametroC;
        ParametroRegraNegocios parametroRegraNegocios;

        VendaFechamento vendaFechamento;

        VendaC vendaC = new VendaC();
        VendaRegraNegocios vendaRegraNegocios = new VendaRegraNegocios();

        PagamentoVendaC pagamentoVendaC = new PagamentoVendaC();
        PagamentoVendaRegraNegocios pagamentoVendaRegraNegocios = new PagamentoVendaRegraNegocios();

        NumCaixaC numCaixaC = new NumCaixaC();
        numCaixaRegraNegocios numCaixaRegraNegocios = new numCaixaRegraNegocios();

        UsuarioC usuarioC = new UsuarioC();
        UsuarioRegraNegocios usuarioRegraNegocios = new UsuarioRegraNegocios();

        DepartamentoC departamentoC = new DepartamentoC();
        DepartamentoRegraNegocios departamentoRegraNegocios = new DepartamentoRegraNegocios();

        SangriaC sangriaC = new SangriaC();
        SangriaRegraNegocios sangriaRegraNegocios = new SangriaRegraNegocios();

        IMPRESSORA.ImpressoraC impressoraC = new IMPRESSORA.ImpressoraC();

        BEMATECH bematechRegraNegocios;
        ESCPOS escPos;
        CABECALHO cabecalho;

        DataTable dadosTabelaVenda;
        DataTable dadosTabelaPagamentoVenda;

        DataTable dadosTabelaDepartamento;
        DataTable dadosTabelaSetor;
        DataTable dadosTabelaTributo;

        List<VENDAS> listaRelatorioVendas;

        #endregion

        #region VARIAVEIS

        public int numCaixa, reimpressao = 0;
        public int idUsuario = 0;
        public string nomeUsuario = "";
        public decimal somaTotal = 0;
        public int counter = 0;
        public int idRetorno = 0;
        public string esquerda = "";
        public string centrarlizar = "";
        public string direita = "";

        //DADOS FECHAMENTO DO CAIXA
        public decimal moeda, dinheiro, cheque, cartao, convenio, sangria, despesa, totalcaixa, resultado, diferencaCaixa = 0;
        public string tipoPagamento = "";

        public string cupom = "";
        public string relatorioFechamento = "";
        public string DadosCabecalhoCupom = "";
        public string DadosCorpoCupom = "";
        public string DadosPesquisaRelatorio = "";
        public string DadosFinaisCupom = "";

        public bool ret;

        public string nomeImpressoraPadrao = "";

        #endregion

        private void frmFechamentoCaixa_Load(object sender, EventArgs e)
        {
            LoadTela();
        }

        public void LoadTela()
        {
            somaTotal = 0;
            numCaixa = frmVenda.numCaixa;
            nomeUsuario = frmVenda.nomeOperador;
            idUsuario = frmVenda.idUsuario;
            reimpressao = Convert.ToInt32(frmVenda.qtdeCupom);

            lblOperador.Text = nomeUsuario.Trim();
            lblNumCaixa.Text = numCaixa.ToString().Trim().PadLeft(3, '0');

            ListarVendaAberto();
            ListarPagamentoVenda();
            CarreagarComboDepartamento();
            CarreagarComboSetor();
            PesquisarDadosFechamentoCaixa();
            PesquisarSangria();
            PesquisarParametro();
            SomaTotal();
        }

        public void SomaTotal()
        {
            somaTotal = (dinheiro + cartao + cheque + convenio);

            txtTotalVenda.Text = somaTotal.ToString("N2");
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
                    cabecalho.NomeRazao = dadosTabelaParametro.Rows[0]["RAZAO_SOCIAL"].ToString().Trim();
                    cabecalho.Endereco = dadosTabelaParametro.Rows[0]["ENDERECO_EMPRESA"].ToString().Trim();
                    cabecalho.Numero = dadosTabelaParametro.Rows[0]["NUMERO"].ToString().Trim();
                    cabecalho.Bairro = dadosTabelaParametro.Rows[0]["BAIRRO"].ToString().Trim();
                    cabecalho.Cep = dadosTabelaParametro.Rows[0]["CEP"].ToString().Trim();
                    cabecalho.Cidade = dadosTabelaParametro.Rows[0]["CIDADE"].ToString().Trim();
                    cabecalho.Uf = dadosTabelaParametro.Rows[0]["UF"].ToString().Trim();
                    cabecalho.Telefone = dadosTabelaParametro.Rows[0]["TELEFONE"].ToString().Trim();
                    cabecalho.CNPJ = dadosTabelaParametro.Rows[0]["CNPJ"].ToString().Trim();
                    cabecalho.IE = dadosTabelaParametro.Rows[0]["IE"].ToString().Trim();
                    cabecalho.IM = dadosTabelaParametro.Rows[0]["IM"].ToString().Trim();
                    cabecalho.CnpjCliente = "";
                    cabecalho.nCFe = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção");
            }
        }

        public void CarreagarComboDepartamento()
        {
            try
            {
                departamentoC = new DepartamentoC();
                departamentoRegraNegocios = new DepartamentoRegraNegocios();
                DataTable dadosTabelaDepartamento = new DataTable();

                dadosTabelaDepartamento = departamentoRegraNegocios.CarreagarComboDepartamento();

                if (dadosTabelaDepartamento.Rows.Count > 0)
                {
                    for (int i = 0; i < dadosTabelaDepartamento.Rows.Count; i++)
                    {
                        cbDepartamento.DataSource = null;
                        cbDepartamento.DataSource = dadosTabelaDepartamento;
                        cbDepartamento.ValueMember = "ID";
                        cbDepartamento.DisplayMember = "DESCRICAO";
                    }
                }
                else
                {
                    MessageBox.Show("Não Contém Registro de Dados no Departamento.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção");
            }
        }

        public void CarreagarComboSetor()
        {
            try
            {
                int setor = 0;

                departamentoC = new DepartamentoC();
                departamentoRegraNegocios = new DepartamentoRegraNegocios();
                DataTable dadosTabela = new DataTable();

                dadosTabela = departamentoRegraNegocios.CarreagarComboSetor(setor);

                if (dadosTabela.Rows.Count > 0)
                {
                    for (int i = 0; i < dadosTabela.Rows.Count; i++)
                    {
                        cbSetor.DataSource = null;
                        cbSetor.DataSource = dadosTabelaDepartamento;
                        cbSetor.ValueMember = "ID";
                        cbSetor.DisplayMember = "DESCRICAO";
                    }
                }
                else
                {
                    MessageBox.Show("Não Contém Registro de Dados no Departamento.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção");
            }
        }

        public void ListarVendaAberto()
        {
            try
            {
                vendaC = new VendaC();
                vendaRegraNegocios = new VendaRegraNegocios();
                dadosTabelaVenda = new DataTable();

                if (numCaixa <= 0)
                {
                    MessageBox.Show("Numero do Caixa não Pode ser Menor ou Igual a Zero.", "Informação");
                }
                else
                {
                    vendaC.numCaixa = numCaixa;
                    vendaC.baixado = true;
                    vendaC.idUsuario = idUsuario;

                    dadosTabelaVenda = vendaRegraNegocios.PesquisarVendaTotal(vendaC);


                    if (dadosTabelaVenda.Rows.Count > 0)
                    {
                        gdvDados.DataSource = null;
                        gdvDados.DataSource = dadosTabelaVenda;

                        gdvDados.Columns[0].Width = 120;
                        gdvDados.Columns[1].Width = 150;
                        gdvDados.Columns[2].Width = 50;
                        gdvDados.Columns[3].Width = 60;
                        gdvDados.Columns[4].Width = 70;
                        gdvDados.Columns[5].Width = 60;

                        lblQtdeVenda.Text = gdvDados.Rows.Count.ToString().PadLeft(3, '0');

                        for (int i = 0; i < gdvDados.Rows.Count; i++)
                        {
                            somaTotal += Convert.ToDecimal(dadosTabelaVenda.Rows[i]["TOTAL"].ToString());
                        }
                    }
                    else
                    {
                        gdvDados.DataSource = null;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção");
            }
        }

        public void ListarPagamentoVenda()
        {
            try
            {
                pagamentoVendaC = new PagamentoVendaC();
                pagamentoVendaRegraNegocios = new PagamentoVendaRegraNegocios();

                dadosTabelaPagamentoVenda = new DataTable();

                if (numCaixa <= 0)
                {
                    MessageBox.Show("Numero do Caixa não Pode ser Menor ou Igual a Zero.", "Informação");
                }
                else
                {
                    pagamentoVendaC.numCaixa = numCaixa;
                    pagamentoVendaC.baixado = false;

                    dadosTabelaPagamentoVenda = pagamentoVendaRegraNegocios.ListarPagamentoVenda(pagamentoVendaC);

                    if (dadosTabelaPagamentoVenda.Rows.Count > 0)
                    {
                        gdvPagamento.DataSource = null;
                        gdvPagamento.DataSource = dadosTabelaPagamentoVenda;
                    }
                    else
                    {
                        gdvPagamento.DataSource = null;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção");
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void FecharNumCaixa()
        {
            try
            {
                numCaixaC = new NumCaixaC();
                numCaixaRegraNegocios = new numCaixaRegraNegocios();

                numCaixaC.numCaixa = numCaixa;
                numCaixaC.statusCaixa = false;

                string idRetorno = numCaixaRegraNegocios.AbrirCaixa(numCaixaC);

                try
                {
                    int idRet = Convert.ToInt32(idRetorno);
                }
                catch
                {
                    MessageBox.Show("Erro ao Fechar Caixa Numero: " + numCaixa.ToString().PadLeft(3, '0'), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção");
            }
        }

        public void FecharUsuario()
        {
            try
            {
                usuarioC = new UsuarioC();
                usuarioRegraNegocios = new UsuarioRegraNegocios();

                usuarioC.idUsuario = idUsuario;
                usuarioC.statusUsuario = false;
                usuarioC.numCaixa = numCaixa;

                string idRetorno = usuarioRegraNegocios.AlterarStatusUsuario(usuarioC);

                try
                {
                    int idRet = Convert.ToInt32(idRetorno);
                }
                catch
                {
                    MessageBox.Show("Erro ao Alterar Status do Usuario " + nomeUsuario + ".", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção");
            }
        }

        public void FecharVendasBaixada()
        {
            try
            {
                vendaC = new VendaC();
                vendaRegraNegocios = new VendaRegraNegocios();

                vendaC.numCaixa = numCaixa;
                vendaC.baixado = true;
                vendaC.fech = true;

                string idRetorno = vendaRegraNegocios.BaixarVenda(vendaC);

                try
                {
                    int idRet = Convert.ToInt32(idRetorno);
                }
                catch
                {
                    MessageBox.Show("Erro ao Fechar Venda Baixado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção");
            }
        }

        public void FecharPagamentoVendaBaixado()
        {
            try
            {
                pagamentoVendaC = new PagamentoVendaC();
                pagamentoVendaRegraNegocios = new PagamentoVendaRegraNegocios();

                if (numCaixa <= 0)
                {
                    MessageBox.Show("Numero do Caixa nãoPode ser Menor ou Igual a Zero.", "Numero Caixa Zero", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    pagamentoVendaC.numCaixa = numCaixa;
                    pagamentoVendaC.baixado = true;

                    string idRetonro = pagamentoVendaRegraNegocios.FecharPagamentoVendaBaixado(pagamentoVendaC);


                    try
                    {
                        int idRet = Convert.ToInt32(idRetonro);
                    }
                    catch
                    {
                        MessageBox.Show("Erro ao Fechar Pagamneto Venda Baixado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção");
            }
        }

        private void InitializeTimer()
        {
            counter = 0;
            timer1.Interval = 600;
            timer1.Enabled = true;

            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
        }

        private void btnFecharCaixa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Realmente Deseja Fechar Caixa Numero " + numCaixa.ToString().PadLeft(3, '0'), "Fechar Caixa", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                if (FecharCaixa() == true)
                {
                    SalvarFechamentoWeb();

                    frmVenda.Close();

                    this.Close();

                    Application.Exit();
                }
            }
        }

        public void SalvarFechamentoWeb()
        {
            try
            {
                vendaFechamento = new VendaFechamento();

                vendaFechamento.Cnpj = frmVenda.cnpj.Replace(".", "").Replace("-", "").Replace("/", "").Trim();
                vendaFechamento.NumCaixa = numCaixa;
                vendaFechamento.IdUsuario = idUsuario;
                vendaFechamento.Data = DateTime.Now.Date;

                int idRet = vendaRegraNegocios.CadastrarVendaFechamento(vendaFechamento, dadosTabelaVenda);

                if (idRet == 0)
                {
                    MessageBox.Show("Erro ao Cadastrar Fechamento Venda CF-e Cupom Web.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void MontarReducaoZ()
        {
            try
            {
                #region VENDA TOTAL

                string cupomVenda = "";

                impressoraC = new IMPRESSORA.ImpressoraC();

                listaRelatorioVendas = new List<VENDAS>();

                impressoraC = new IMPRESSORA.ImpressoraC();

                decimal tt = 0;
                somaTotal = 0;
                LimparDados();

                dadosTabelaVendaTotal = new DataTable();
                vendaRegraNegocios = new VendaRegraNegocios();

                dadosTabelaVendaTotal = vendaRegraNegocios.PesquisarVendaTotalRZ(numCaixa);

                listaRelatorioVendas = new List<VENDAS>();

                if (dadosTabelaVendaTotal.Rows.Count > 0)
                {
                    for (int i = 0; i < dadosTabelaVendaTotal.Rows.Count; i++)
                    {
                        listaRelatorioVendas.Add(new VENDAS()
                        {
                            codoBarra = dadosTabelaVendaTotal.Rows[i]["COD"].ToString().Trim(),
                            descricao = dadosTabelaVendaTotal.Rows[i]["DESCRICAO"].ToString().Trim(),
                            qtde = dadosTabelaVendaTotal.Rows[i]["QTDE"].ToString().Trim(),
                            subTotal = dadosTabelaVendaTotal.Rows[i]["TOTAL"].ToString(),
                        });

                        int cont = dadosTabelaVendaTotal.Rows.Count;

                        tt = 0;

                        tt = Convert.ToDecimal(dadosTabelaVendaTotal.Rows[i]["TOTAL"].ToString());

                        somaTotal += Convert.ToDecimal(dadosTabelaVendaTotal.Rows[i]["TOTAL"].ToString());

                        cont = (i + 1);
                    }

                    if (frmVenda.nomeImpressora.Trim().Equals("BEMATECH") || frmVenda.nomeImpressora.Trim().Equals("BEMASAT"))
                    {
                        bematechRegraNegocios = new BEMATECH();

                        DadosCabecalhoCupom = bematechRegraNegocios.CabecalhoCupomComum(cabecalho);
                        DadosCorpoCupom = bematechRegraNegocios.CorpoRelatorioVendasRZ(1);
                        DadosPesquisaRelatorio = bematechRegraNegocios.CorpoRelatorioVendaRZ(listaRelatorioVendas);
                        DadosFinaisCupom = bematechRegraNegocios.DadosFinaisSetor(somaTotal, numCaixa, nomeUsuario);

                        //LOCALIZA IMPRESSORA E PORTA COM
                        idRetorno = IMPRESSORA.BemasatImpressora.ConfiguraModeloImpressora(7);
                        idRetorno = IMPRESSORA.BemasatImpressora.IniciaPorta(frmVenda.numComimp);

                        impressoraC.detalhes = (DadosCabecalhoCupom + DadosCorpoCupom + DadosPesquisaRelatorio + DadosFinaisCupom);

                        esquerda = "" + (char)27 + (char)97 + (char)0;
                        centrarlizar = "" + (char)27 + (char)97 + (char)1;
                        direita = "" + (char)27 + (char)97 + (char)2;

                        idRetorno = IMPRESSORA.BemasatImpressora.ComandoTX(esquerda, esquerda.Length);
                        idRetorno = IMPRESSORA.BemasatImpressora.FormataTX(impressoraC.detalhes + (char)10 + (char)13, 1, 0, 0, 0, 0);

                        //  idRetorno = IMPRESSORA.BemasatImpressora.AcionaGuilhotina(0);

                        idRetorno = IMPRESSORA.BemasatImpressora.FechaPorta();
                    }
                    else if (frmVenda.nomeImpressora.Trim().Equals("ESCPOS") || (frmVenda.nomeImpressora.Trim().Equals("EPSON")) || (frmVenda.nomeImpressora.Trim().Equals("ELGIN")))
                    {
                        escPos = new ESCPOS();

                        DadosCabecalhoCupom = escPos.CabecalhoCupomComum(cabecalho);
                        DadosCorpoCupom = escPos.CorpoRelatorioVenda();
                        DadosPesquisaRelatorio = escPos.CorpoRelatorioVenda(listaRelatorioVendas);
                        DadosFinaisCupom = escPos.DadosFinaisSetor(somaTotal, numCaixa, nomeUsuario);

                        cupomVenda = (DadosCabecalhoCupom + DadosCorpoCupom + DadosPesquisaRelatorio + DadosFinaisCupom);

                        var printer = new Printer(frmVenda.nomeImpressoraPadrao, frmVenda.ObterTipo());

                        printer.Imprimirrelatorio(cupomVenda);
                        // printer.PartialPaperCut();
                        printer.PrintDocument();

                        printer.InitializePrint();

                        idRetorno = 1;
                    }

                    if (idRetorno == 0)
                    {
                        MessageBox.Show("Erro ao Imprimir do Venda(s)'.", "Erro de Impressão", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    relatorioFechamento += cupomVenda;
                }

                #endregion

                #region FORMA DE PAGAMENTO

                List<PAGAMENTO_VENDA> listaRelatorioFormaPagamento = new List<PAGAMENTO_VENDA>();

                dadosTabelaPagamentoVenda = new DataTable();
                pagamentoVendaRegraNegocios = new PagamentoVendaRegraNegocios();

                string cupomFormaPagamento = "";

                tt = 0;
                somaTotal = 0;
                LimparDados();

                dadosTabelaPagamentoVenda = pagamentoVendaRegraNegocios.ListarPagamentoVendaRZ(numCaixa);

                if (dadosTabelaPagamentoVenda.Rows.Count > 0)
                {
                    for (int i = 0; i < dadosTabelaPagamentoVenda.Rows.Count; i++)
                    {
                        listaRelatorioFormaPagamento.Add(new PAGAMENTO_VENDA()
                        {
                            Id = Convert.ToInt32(dadosTabelaPagamentoVenda.Rows[i]["TIPO_PAGTO_ID"].ToString()),
                            Descricao = dadosTabelaPagamentoVenda.Rows[i]["TIPO_PAGTO"].ToString().ToUpper().Trim(),
                            Valor = dadosTabelaPagamentoVenda.Rows[i]["VALOR"].ToString()
                        });

                        tt = 0;

                        tt = Convert.ToDecimal(dadosTabelaPagamentoVenda.Rows[i]["VALOR"].ToString());

                        somaTotal += Convert.ToDecimal(dadosTabelaPagamentoVenda.Rows[i]["VALOR"].ToString());

                        int cont = dadosTabelaPagamentoVenda.Rows.Count;

                        cont = (i + 1);
                    }

                    if (frmVenda.nomeImpressora.Trim().Equals("BEMATECH") || (frmVenda.nomeImpressora.Trim().Equals("BEMASAT")))
                    {
                        bematechRegraNegocios = new BEMATECH();

                        //   DadosCabecalhoCupom = bematechRegraNegocios.CabecalhoCupomComum(cabecalho);
                        DadosCorpoCupom = bematechRegraNegocios.CorpoRelatorioFormaPagamento();
                        DadosPesquisaRelatorio = bematechRegraNegocios.CorpoRelatorioFormaPagamento(listaRelatorioFormaPagamento);
                        DadosFinaisCupom = bematechRegraNegocios.DadosFinaisSetor(somaTotal, numCaixa, nomeUsuario);

                        cupomFormaPagamento = (DadosCabecalhoCupom + DadosCorpoCupom + DadosPesquisaRelatorio + DadosFinaisCupom);

                        idRetorno = IMPRESSORA.BemasatImpressora.ConfiguraModeloImpressora(7);
                        idRetorno = IMPRESSORA.BemasatImpressora.IniciaPorta(frmVenda.numComimp);

                        esquerda = "" + (char)27 + (char)97 + (char)0;
                        centrarlizar = "" + (char)27 + (char)97 + (char)1;
                        direita = "" + (char)27 + (char)97 + (char)2;

                        idRetorno = IMPRESSORA.BemasatImpressora.ComandoTX(esquerda, esquerda.Length);
                        idRetorno = IMPRESSORA.BemasatImpressora.FormataTX(cupomFormaPagamento + (char)10 + (char)13, 1, 0, 0, 0, 0);

                        // idRetorno = IMPRESSORA.BemasatImpressora.AcionaGuilhotina(0);
                        idRetorno = IMPRESSORA.BemasatImpressora.FechaPorta();
                    }
                    else if ((frmVenda.nomeImpressora.Trim().Equals("ESCPOS")) || (frmVenda.nomeImpressora.Trim().Equals("EPSON")) || (frmVenda.nomeImpressora.Trim().Equals("ELGIN")))
                    {
                        escPos = new ESCPOS();

                        //    DadosCabecalhoCupom = escPos.CabecalhoCupomComum(cabecalho);
                        DadosCorpoCupom = escPos.CorpoRelatorioSetor();
                        DadosPesquisaRelatorio = escPos.CorpoRelatorioFormaPagamento(listaRelatorioFormaPagamento);
                        DadosFinaisCupom = escPos.DadosFinaisSetor(somaTotal, numCaixa, nomeUsuario);

                        cupomFormaPagamento = (DadosCabecalhoCupom + DadosPesquisaRelatorio + DadosFinaisCupom);

                        var printer = new Printer(frmVenda.nomeImpressoraPadrao, frmVenda.ObterTipo());

                        printer.Imprimirrelatorio(cupomFormaPagamento);
                        // printer.PartialPaperCut();
                        printer.PrintDocument();

                        printer.InitializePrint();

                        idRetorno = 1;
                    }

                    //LIMPAR VARIAVEIS
                    somaTotal = 0;

                    LimparDados();

                    if (idRetorno == 0)
                    {
                        MessageBox.Show("Erro ao Imprimir do Relatório do Setor.", "Erro de Impressão", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    relatorioFechamento += cupomFormaPagamento;
                }

                #endregion

                #region FECHAMENTO CAIXA

                string cupomFechamentoCaixa = "";

                if (frmVenda.nomeImpressora.Trim().Equals("BEMATECH") || (frmVenda.nomeImpressora.Trim().Equals("BEMASAT")))
                {
                    bematechRegraNegocios = new BEMATECH();

                    //   DadosCabecalhoCupom = bematechRegraNegocios.CabecalhoCupomComum(cabecalho);
                    DadosCorpoCupom = bematechRegraNegocios.CorpoRelatorioFechamentoCaixa();
                    DadosPesquisaRelatorio = bematechRegraNegocios.CorpoRelatorioFechamentoCaixa(txtDescMoeda.Text, txtDescDinheiro.Text, txtDescCartao.Text, txtDescCheque.Text, txtDescAberto.Text, txtDescRedeSete.Text, txtDesSangria.Text, txtDescDespesas.Text, txtValorLavaRapido.Text, txtTotalVenda.Text, txtDescDiferencaCaixa.Text);
                    //  DadosFinaisCupom = bematechRegraNegocios.DadosFinaisSetor(somaTotal, numCaixa, nomeUsuario);

                    cupomFechamentoCaixa = (DadosCorpoCupom + DadosPesquisaRelatorio);

                    idRetorno = IMPRESSORA.BemasatImpressora.ConfiguraModeloImpressora(7);
                    idRetorno = IMPRESSORA.BemasatImpressora.IniciaPorta(frmVenda.numComimp);

                    esquerda = "" + (char)27 + (char)97 + (char)0;
                    centrarlizar = "" + (char)27 + (char)97 + (char)1;
                    direita = "" + (char)27 + (char)97 + (char)2;

                    idRetorno = IMPRESSORA.BemasatImpressora.ComandoTX(esquerda, esquerda.Length);
                    idRetorno = IMPRESSORA.BemasatImpressora.FormataTX(cupomFechamentoCaixa + (char)10 + (char)13, 1, 0, 0, 0, 0);

                    // idRetorno = IMPRESSORA.BemasatImpressora.AcionaGuilhotina(0);
                    idRetorno = IMPRESSORA.BemasatImpressora.FechaPorta();
                }
                else if ((frmVenda.nomeImpressora.Trim().Equals("ESCPOS")) || (frmVenda.nomeImpressora.Trim().Equals("EPSON")) || (frmVenda.nomeImpressora.Trim().Equals("ELGIN")))
                {
                    escPos = new ESCPOS();

                    DadosCorpoCupom = bematechRegraNegocios.CorpoRelatorioFechamentoCaixa();
                    DadosPesquisaRelatorio = bematechRegraNegocios.CorpoRelatorioFechamentoCaixa(txtDescMoeda.Text, txtDescDinheiro.Text, txtDescCartao.Text, txtDescCheque.Text, txtDescAberto.Text, txtDescRedeSete.Text, txtDesSangria.Text, txtDescDespesas.Text, txtValorLavaRapido.Text, txtTotalVenda.Text, txtDescDiferencaCaixa.Text);
                    //  DadosFinaisCupom = bematechRegraNegocios.DadosFinaisSetor(somaTotal, numCaixa, nomeUsuario);

                    cupomFechamentoCaixa = (DadosCorpoCupom + DadosPesquisaRelatorio);

                    var printer = new Printer(frmVenda.nomeImpressoraPadrao, frmVenda.ObterTipo());

                    printer.Imprimirrelatorio(cupomFechamentoCaixa);
                    // printer.PartialPaperCut();
                    printer.PrintDocument();

                    printer.InitializePrint();

                    idRetorno = 1;
                }

                //LIMPAR VARIAVEIS
                somaTotal = 0;

                LimparDados();

                if (idRetorno == 0)
                {
                    MessageBox.Show("Erro ao Imprimir do Relatório do Fechamento do Caixa.", "Erro de Impressão", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                relatorioFechamento += cupomFechamentoCaixa;

                #endregion

                #region VENDA ESTOQUES

                string cupomVendaEstoque = "";

                impressoraC = new IMPRESSORA.ImpressoraC();

                listaRelatorioVendas = new List<VENDAS>();

                impressoraC = new IMPRESSORA.ImpressoraC();

                tt = 0;
                somaTotal = 0;
                LimparDados();

                dadosTabelaVendaTotal = new DataTable();
                vendaRegraNegocios = new VendaRegraNegocios();

                dadosTabelaVendaTotal = vendaRegraNegocios.PesquisarVendaEstoqueTotalRZ(numCaixa);

                listaRelatorioVendas = new List<VENDAS>();

                if (dadosTabelaVendaTotal.Rows.Count > 0)
                {
                    for (int i = 0; i < dadosTabelaVendaTotal.Rows.Count; i++)
                    {
                        listaRelatorioVendas.Add(new VENDAS()
                        {
                            codoBarra = dadosTabelaVendaTotal.Rows[i]["COD"].ToString().Trim(),
                            descricao = dadosTabelaVendaTotal.Rows[i]["DESCRICAO"].ToString().Trim(),
                            qtde = dadosTabelaVendaTotal.Rows[i]["ESTOQUE"].ToString().Trim(),
                            subTotal = dadosTabelaVendaTotal.Rows[i]["QTDE"].ToString(),
                        });

                        int cont = dadosTabelaVendaTotal.Rows.Count;

                        tt = 0;

                        //tt = Convert.ToDecimal(dadosTabelaVendaTotal.Rows[i]["TOTAL"].ToString());

                        //somaTotal += Convert.ToDecimal(dadosTabelaVendaTotal.Rows[i]["TOTAL"].ToString());

                        cont = (i + 1);
                    }

                    if (frmVenda.nomeImpressora.Trim().Equals("BEMATECH") || frmVenda.nomeImpressora.Trim().Equals("BEMASAT"))
                    {
                        bematechRegraNegocios = new BEMATECH();

                        DadosCabecalhoCupom = bematechRegraNegocios.CabecalhoCupomComum(cabecalho);
                        DadosCorpoCupom = bematechRegraNegocios.CorpoRelatorioVendasRZ(2);
                        DadosPesquisaRelatorio = bematechRegraNegocios.CorpoRelatorioVendaRZ(listaRelatorioVendas);
                        DadosFinaisCupom = bematechRegraNegocios.DadosFinaisSetor(somaTotal, numCaixa, nomeUsuario);

                        //LOCALIZA IMPRESSORA E PORTA COM
                        idRetorno = IMPRESSORA.BemasatImpressora.ConfiguraModeloImpressora(7);
                        idRetorno = IMPRESSORA.BemasatImpressora.IniciaPorta(frmVenda.numComimp);

                        impressoraC.detalhes = (DadosCorpoCupom + DadosPesquisaRelatorio + DadosFinaisCupom);

                        esquerda = "" + (char)27 + (char)97 + (char)0;
                        centrarlizar = "" + (char)27 + (char)97 + (char)1;
                        direita = "" + (char)27 + (char)97 + (char)2;

                        idRetorno = IMPRESSORA.BemasatImpressora.ComandoTX(esquerda, esquerda.Length);
                        idRetorno = IMPRESSORA.BemasatImpressora.FormataTX(impressoraC.detalhes + (char)10 + (char)13, 1, 0, 0, 0, 0);

                        //  idRetorno = IMPRESSORA.BemasatImpressora.AcionaGuilhotina(0);

                        idRetorno = IMPRESSORA.BemasatImpressora.FechaPorta();
                    }
                    else if (frmVenda.nomeImpressora.Trim().Equals("ESCPOS") || (frmVenda.nomeImpressora.Trim().Equals("EPSON")) || (frmVenda.nomeImpressora.Trim().Equals("ELGIN")))
                    {
                        escPos = new ESCPOS();

                        DadosCabecalhoCupom = escPos.CabecalhoCupomComum(cabecalho);
                        DadosCorpoCupom = escPos.CorpoRelatorioVenda();
                        DadosPesquisaRelatorio = escPos.CorpoRelatorioVenda(listaRelatorioVendas);
                        DadosFinaisCupom = escPos.DadosFinaisSetor(somaTotal, numCaixa, nomeUsuario);

                        cupomVenda = (DadosCabecalhoCupom + DadosCorpoCupom + DadosPesquisaRelatorio + DadosFinaisCupom);

                        var printer = new Printer(frmVenda.nomeImpressoraPadrao, frmVenda.ObterTipo());

                        printer.Imprimirrelatorio(cupomVenda);
                        // printer.PartialPaperCut();
                        printer.PrintDocument();

                        printer.InitializePrint();

                        idRetorno = 1;
                    }

                    if (idRetorno == 0)
                    {
                        MessageBox.Show("Erro ao Imprimir do Venda(s)'.", "Erro de Impressão", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    relatorioFechamento += cupomVendaEstoque;
                }
                #endregion

                #region ALIQUOTAS

                List<TRIBUTOS> listaRelatorioTributos = new List<TRIBUTOS>();

                dadosTabelaTributo = new DataTable();
                vendaRegraNegocios = new VendaRegraNegocios();

                string cupomTributos = "";
                string data = DateTime.Now.ToString("dd-MM-yyyy 00:00:00");

                somaTotal = 0;

                tt = 0;

                LimparDados();

                dadosTabelaTributo = vendaRegraNegocios.ListarVendaTributosRZ(numCaixa, data);

                if (dadosTabelaTributo.Rows.Count > 0)
                {
                    for (int i = 0; i < dadosTabelaTributo.Rows.Count; i++)
                    {
                        listaRelatorioTributos.Add(new TRIBUTOS()
                        {
                            Trib = dadosTabelaTributo.Rows[i]["TRIB"].ToString().Trim(),
                            Valor = Convert.ToDecimal(dadosTabelaTributo.Rows[i]["TOTAL"].ToString()).ToString("N2")
                        });

                        tt = 0;

                        tt = Convert.ToDecimal(dadosTabelaTributo.Rows[i]["TOTAL"].ToString());

                        somaTotal += Convert.ToDecimal(dadosTabelaTributo.Rows[i]["TOTAL"].ToString());

                        int cont = dadosTabelaTributo.Rows.Count;

                        cont = (i + 1);
                    }

                    if (frmVenda.nomeImpressora.Trim().Equals("BEMATECH") || (frmVenda.nomeImpressora.Trim().Equals("BEMASAT")))
                    {
                        bematechRegraNegocios = new BEMATECH();

                        DadosCorpoCupom = bematechRegraNegocios.CorpoRelatorioTributos();
                        DadosPesquisaRelatorio = bematechRegraNegocios.CorpoRelatorioTributos(listaRelatorioTributos);
                        DadosFinaisCupom = bematechRegraNegocios.DadosFinaisSetor(somaTotal, numCaixa, nomeUsuario);

                        cupomTributos = (DadosCabecalhoCupom + DadosCorpoCupom + DadosPesquisaRelatorio + DadosFinaisCupom);

                        idRetorno = IMPRESSORA.BemasatImpressora.ConfiguraModeloImpressora(7);
                        idRetorno = IMPRESSORA.BemasatImpressora.IniciaPorta(frmVenda.numComimp);

                        esquerda = "" + (char)27 + (char)97 + (char)0;
                        centrarlizar = "" + (char)27 + (char)97 + (char)1;
                        direita = "" + (char)27 + (char)97 + (char)2;

                        idRetorno = IMPRESSORA.BemasatImpressora.ComandoTX(esquerda, esquerda.Length);
                        idRetorno = IMPRESSORA.BemasatImpressora.FormataTX(cupomTributos + (char)10 + (char)13, 1, 0, 0, 0, 0);

                        // idRetorno = IMPRESSORA.BemasatImpressora.AcionaGuilhotina(0);
                        idRetorno = IMPRESSORA.BemasatImpressora.FechaPorta();
                    }
                    else if ((frmVenda.nomeImpressora.Trim().Equals("ESCPOS")) || (frmVenda.nomeImpressora.Trim().Equals("EPSON")) || (frmVenda.nomeImpressora.Trim().Equals("ELGIN")))
                    {
                        escPos = new ESCPOS();

                        //    DadosCabecalhoCupom = escPos.CabecalhoCupomComum(cabecalho);
                        DadosCorpoCupom = escPos.CorpoRelatorioTributos();
                        DadosPesquisaRelatorio = escPos.CorpoRelatorioTributos(listaRelatorioTributos);
                        DadosFinaisCupom = escPos.DadosFinaisSetor(somaTotal, numCaixa, nomeUsuario);

                        cupomTributos = (DadosCabecalhoCupom + DadosCorpoCupom + DadosPesquisaRelatorio + DadosFinaisCupom);

                        var printer = new Printer(frmVenda.nomeImpressoraPadrao, frmVenda.ObterTipo());

                        printer.Imprimirrelatorio(cupomTributos);
                        // printer.PartialPaperCut();
                        printer.PrintDocument();

                        printer.InitializePrint();

                        idRetorno = 1;
                    }

                    if (idRetorno == 0)
                    {
                        MessageBox.Show("Erro ao Imprimir do Relatório do Setor.", "Erro de Impressão", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    relatorioFechamento += cupomTributos;
                }

                #endregion

                #region DEPARTAMENTO

                impressoraC = new IMPRESSORA.ImpressoraC();

                string cupomDep = "";
                somaTotal = 0;

                List<DepartamentoC> listaRelatorioDeparatmento = new List<DepartamentoC>();

                impressoraC = new IMPRESSORA.ImpressoraC();

                tt = 0;

                dadosTabelaDepartamento = new DataTable();

                dadosTabelaVendaTotal = vendaRegraNegocios.PesquisarVendaDepartamentosRZ(numCaixa);

                if (gdvDados.Rows.Count > 0)
                {
                    for (int i = 0; i < dadosTabelaVendaTotal.Rows.Count; i++)
                    {
                        listaRelatorioDeparatmento.Add(new DepartamentoC()
                        {
                            idDepartamento = dadosTabelaVendaTotal.Rows[i]["DEP"].ToString().Trim().PadLeft(3, '0'),
                            descricaoDep = dadosTabelaVendaTotal.Rows[i]["DEPARTAMENTO"].ToString().Trim(),
                            Valor = Convert.ToDecimal(dadosTabelaVendaTotal.Rows[i]["TOTAL"].ToString())
                        });

                        int cont = gdvDados.Rows.Count;

                        tt = 0;
                        tt = Convert.ToDecimal(dadosTabelaVendaTotal.Rows[i]["TOTAL"].ToString());

                        somaTotal += Convert.ToDecimal(dadosTabelaVendaTotal.Rows[i]["TOTAL"].ToString());

                        cont = (i + 1);
                    }

                    if (frmVenda.nomeImpressora.Trim().Equals("BEMATECH") || frmVenda.nomeImpressora.Trim().Equals("BEMASAT"))
                    {
                        bematechRegraNegocios = new BEMATECH();

                        // DadosCabecalhoCupom = bematechRegraNegocios.CabecalhoCupomComum(cabecalho);
                        DadosCorpoCupom = bematechRegraNegocios.CorpoRelatorioDepartamento();
                        DadosPesquisaRelatorio = bematechRegraNegocios.CorpoRelatorioDepartamento(listaRelatorioDeparatmento);
                        DadosFinaisCupom = bematechRegraNegocios.DadosFinaisSetor(somaTotal, numCaixa, nomeUsuario);

                        //LOCALIZA IMPRESSORA E PORTA COM
                        idRetorno = IMPRESSORA.BemasatImpressora.ConfiguraModeloImpressora(7);
                        idRetorno = IMPRESSORA.BemasatImpressora.IniciaPorta(frmVenda.numComimp);

                        esquerda = "" + (char)27 + (char)97 + (char)0;
                        centrarlizar = "" + (char)27 + (char)97 + (char)1;
                        direita = "" + (char)27 + (char)97 + (char)2;

                        cupomDep = (DadosCabecalhoCupom + DadosCorpoCupom + DadosPesquisaRelatorio + DadosFinaisCupom);

                        impressoraC.detalhes = (cupomDep);

                        idRetorno = IMPRESSORA.BemasatImpressora.ComandoTX(esquerda, esquerda.Length);
                        idRetorno = IMPRESSORA.BemasatImpressora.FormataTX(impressoraC.detalhes + (char)10 + (char)13, 1, 0, 0, 0, 0);

                        // idRetorno = IMPRESSORA.BemasatImpressora.AcionaGuilhotina(0);
                        idRetorno = IMPRESSORA.BemasatImpressora.FechaPorta();
                    }
                    else if (frmVenda.nomeImpressora.Trim().Equals("ESCPOS") || (frmVenda.nomeImpressora.Trim().Equals("EPSON")) || (frmVenda.nomeImpressora.Trim().Equals("ELGIN")))
                    {
                        escPos = new ESCPOS();

                        //   DadosCabecalhoCupom = escPos.CabecalhoCupomComum(cabecalho);
                        DadosCorpoCupom = escPos.CorpoRelatorioDepartamento();
                        DadosPesquisaRelatorio = escPos.CorpoRelatorioDepartamento(listaRelatorioDeparatmento);
                        DadosFinaisCupom = escPos.DadosFinaisSetor(somaTotal, numCaixa, nomeUsuario);

                        cupomDep = (DadosCabecalhoCupom + DadosCorpoCupom + DadosPesquisaRelatorio + DadosFinaisCupom);

                        var printer = new Printer(frmVenda.nomeImpressoraPadrao, frmVenda.ObterTipo());

                        printer.Imprimirrelatorio(cupomDep);
                        // printer.PartialPaperCut();
                        printer.PrintDocument();

                        printer.InitializePrint();

                        idRetorno = 1;
                    }

                    if (idRetorno == 0)
                    {
                        MessageBox.Show("Erro ao Imprimir do Relatório do Setor.", "Erro de Impressão", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    relatorioFechamento += cupomDep;
                }

                #endregion

                #region VENDA CANCEL

                string cupomVendaCanc = "";

                impressoraC = new IMPRESSORA.ImpressoraC();

                List<VENDAS> listaRelatorioVendaCancel = new List<VENDAS>();

                impressoraC = new IMPRESSORA.ImpressoraC();

                PesquisaVendaCancelRZ();

                decimal ttC = 0;

                somaTotal = 0;

                LimparDados();

                if (dadosTabelaVendaTotal.Rows.Count > 0)
                {
                    for (int i = 0; i < dadosTabelaVendaTotal.Rows.Count; i++)
                    {
                        listaRelatorioVendaCancel.Add(new VENDAS()
                        {
                            codoBarra = dadosTabelaVendaTotal.Rows[i]["COD"].ToString().Trim(),
                            descricao = dadosTabelaVendaTotal.Rows[i]["DESCRICAO"].ToString().Trim(),
                            qtde = dadosTabelaVendaTotal.Rows[i]["QTDE"].ToString().Trim(),
                            subTotal = dadosTabelaVendaTotal.Rows[i]["TOTAL"].ToString(),
                            unid = dadosTabelaVendaTotal.Rows[i]["UNID"].ToString(),
                            precoProd = dadosTabelaVendaTotal.Rows[i]["TOTAL"].ToString(),
                        });

                        int cont = dadosTabelaVendaTotal.Rows.Count;

                        tt = 0;

                        tt = Convert.ToDecimal(dadosTabelaVendaTotal.Rows[i]["TOTAL"].ToString());

                        somaTotal += Convert.ToDecimal(dadosTabelaVendaTotal.Rows[i]["TOTAL"].ToString());

                        cont = (i + 1);
                    }

                    if (frmVenda.nomeImpressora.Trim().Equals("BEMATECH") || frmVenda.nomeImpressora.Trim().Equals("BEMASAT"))
                    {
                        bematechRegraNegocios = new BEMATECH();

                        DadosCabecalhoCupom = bematechRegraNegocios.CabecalhoCupomComum(cabecalho);
                        DadosCorpoCupom = bematechRegraNegocios.CorpoRelatorioVendaCancelada();
                        DadosPesquisaRelatorio = bematechRegraNegocios.CorpoRelatorioVendaCancelada(listaRelatorioVendaCancel);
                        DadosFinaisCupom = bematechRegraNegocios.DadosFinaisSetor(somaTotal, numCaixa, nomeUsuario);

                        //LOCALIZA IMPRESSORA E PORTA COM
                        idRetorno = IMPRESSORA.BemasatImpressora.ConfiguraModeloImpressora(7);
                        idRetorno = IMPRESSORA.BemasatImpressora.IniciaPorta(frmVenda.numComimp);

                        impressoraC.detalhes = (DadosCorpoCupom + DadosPesquisaRelatorio + DadosFinaisCupom);

                        esquerda = "" + (char)27 + (char)97 + (char)0;
                        centrarlizar = "" + (char)27 + (char)97 + (char)1;
                        direita = "" + (char)27 + (char)97 + (char)2;

                        idRetorno = IMPRESSORA.BemasatImpressora.ComandoTX(esquerda, esquerda.Length);
                        idRetorno = IMPRESSORA.BemasatImpressora.FormataTX(impressoraC.detalhes + (char)10 + (char)13, 1, 0, 0, 0, 0);

                        // idRetorno = IMPRESSORA.BemasatImpressora.AcionaGuilhotina(0);
                        idRetorno = IMPRESSORA.BemasatImpressora.FechaPorta();
                    }
                    else if (frmVenda.nomeImpressora.Trim().Equals("ESCPOS") || (frmVenda.nomeImpressora.Trim().Equals("EPSON")) || (frmVenda.nomeImpressora.Trim().Equals("ELGIN")))
                    {
                        escPos = new ESCPOS();

                        //DadosCabecalhoCupom = escPos.CabecalhoCupomComum(cabecalho);
                        DadosCorpoCupom = escPos.CorpoRelatorioVendaCancelada();
                        DadosPesquisaRelatorio = escPos.CorpoRelatorioVendaCancelada(listaRelatorioVendaCancel);
                        DadosFinaisCupom = escPos.DadosFinaisSetor(somaTotal, numCaixa, nomeUsuario);

                        cupomVenda = (DadosCabecalhoCupom + DadosCorpoCupom + DadosPesquisaRelatorio + DadosFinaisCupom + DateTime.Now);

                        var printer = new Printer(frmVenda.nomeImpressoraPadrao, frmVenda.ObterTipo());

                        printer.Imprimirrelatorio(cupomVenda);
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

                #endregion

                #region SETOR

                List<Setor> ListaRelatorioStor = new List<Setor>();

                impressoraC = new IMPRESSORA.ImpressoraC();

                string cupomSetor = "";

                somaTotal = 0;
                tt = 0;
                LimparDados();

                dadosTabelaSetor = new DataTable();
                vendaRegraNegocios = new VendaRegraNegocios();

                dadosTabelaSetor = vendaRegraNegocios.PesquisarVendaSetorRZ(numCaixa);

                if (dadosTabelaSetor.Rows.Count > 0)
                {
                    for (int i = 0; i < dadosTabelaSetor.Rows.Count; i++)
                    {
                        ListaRelatorioStor.Add(new Setor()
                        {
                            DesSetor = dadosTabelaSetor.Rows[i]["COD"].ToString().Trim().PadLeft(3, '0'),
                            Descricao = dadosTabelaSetor.Rows[i]["DESCRICAO"].ToString(),
                            Valor = Convert.ToDecimal(dadosTabelaSetor.Rows[i]["TOTAL"].ToString()).ToString("N2")
                        });

                        int cont = dadosTabelaSetor.Rows.Count;

                        tt = 0;

                        tt = Convert.ToDecimal(dadosTabelaSetor.Rows[i]["TOTAL"].ToString());

                        somaTotal += Convert.ToDecimal(dadosTabelaSetor.Rows[i]["TOTAL"].ToString());

                        cont = (i + 1);
                    }

                    if (frmVenda.nomeImpressora.Trim().Equals("BEMATECH") || (frmVenda.nomeImpressora.Trim().Equals("BEMASAT")))
                    {
                        bematechRegraNegocios = new BEMATECH();

                        //   DadosCabecalhoCupom = bematechRegraNegocios.CabecalhoCupomComum(cabecalho);
                        DadosCorpoCupom = bematechRegraNegocios.CorpoRelatorioSetor();
                        DadosPesquisaRelatorio = bematechRegraNegocios.CorpoRelatorioSetor(ListaRelatorioStor);
                        DadosFinaisCupom = bematechRegraNegocios.DadosFinaisSetor(somaTotal, numCaixa, nomeUsuario);

                        cupomSetor = (DadosCabecalhoCupom + DadosCorpoCupom + DadosPesquisaRelatorio + DadosFinaisCupom);

                        idRetorno = IMPRESSORA.BemasatImpressora.ConfiguraModeloImpressora(7);
                        idRetorno = IMPRESSORA.BemasatImpressora.IniciaPorta(frmVenda.numComimp);

                        esquerda = "" + (char)27 + (char)97 + (char)0;
                        centrarlizar = "" + (char)27 + (char)97 + (char)1;
                        direita = "" + (char)27 + (char)97 + (char)2;

                        idRetorno = IMPRESSORA.BemasatImpressora.ComandoTX(esquerda, esquerda.Length);
                        idRetorno = IMPRESSORA.BemasatImpressora.FormataTX(cupomSetor + (char)10 + (char)13, 1, 0, 0, 0, 0);

                        idRetorno = IMPRESSORA.BemasatImpressora.AcionaGuilhotina(0);
                        idRetorno = IMPRESSORA.BemasatImpressora.FechaPorta();
                    }
                    else if ((frmVenda.nomeImpressora.Trim().Equals("ESCPOS")) || (frmVenda.nomeImpressora.Trim().Equals("EPSON")) || (frmVenda.nomeImpressora.Trim().Equals("ELGIN")))
                    {
                        escPos = new ESCPOS();

                        //    DadosCabecalhoCupom = escPos.CabecalhoCupomComum(cabecalho);
                        DadosCorpoCupom = escPos.CorpoRelatorioSetor();
                        DadosPesquisaRelatorio = escPos.CorpoRelatorioSetor(ListaRelatorioStor);
                        DadosFinaisCupom = escPos.DadosFinaisSetor(somaTotal, numCaixa, nomeUsuario);

                        cupomSetor = (DadosCabecalhoCupom + DadosCorpoCupom + DadosPesquisaRelatorio + DadosFinaisCupom);

                        var printer = new Printer(frmVenda.nomeImpressoraPadrao, frmVenda.ObterTipo());

                        printer.Imprimirrelatorio(cupomSetor);
                        // printer.PartialPaperCut();
                        printer.PrintDocument();

                        printer.InitializePrint();

                        idRetorno = 1;
                    }

                    if (idRetorno == 0)
                    {
                        MessageBox.Show("Erro ao Imprimir do Relatório do Setor.", "Erro de Impressão", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    relatorioFechamento += cupomSetor;
                }

                #endregion

                relatorioFechamento += cupomVenda;

                if (reimpressao == 2)
                {
                    var printer = new Printer(frmVenda.nomeImpressoraPadrao, frmVenda.ObterTipo());

                    printer.Imprimirrelatorio(relatorioFechamento);
                    printer.PartialPaperCut();
                    printer.PrintDocument();

                    printer.InitializePrint();
                }

                GeraRelatorioTxt();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public string pathDadosVendaAutorizada = Path.GetDirectoryName(Application.ExecutablePath) + "\\Venda\\";

        private void GeraRelatorioTxt()
        {

            try
            {
                string strPathFile = Path.GetDirectoryName(Application.ExecutablePath) + "\\Venda\\" + "Relatorio De Venda" + vendaC.numCaixa.ToString() + ".txt";

                using (FileStream fs = File.Create(strPathFile))
                {
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        sw.Write(relatorioFechamento);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void PesquisaVendaCancelRZ()
        {
            try
            {
                VENDAS vendasC = new VENDAS();
                vendaC.numCaixa = numCaixa;

                dadosTabelaVendaTotal = new DataTable();
                vendaRegraNegocios = new VendaRegraNegocios();

                dadosTabelaVendaTotal = vendaRegraNegocios.PesquisarVendasCanceladas(vendaC);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void PesquisaVendaTotalRZ()
        {
            try
            {
                dadosTabelaVendaTotal = new DataTable();
                vendaRegraNegocios = new VendaRegraNegocios();

                dadosTabelaVendaTotal = vendaRegraNegocios.PesquisarVendaTotalRZ(numCaixa);

                listaRelatorioVendas = new List<VENDAS>();

                if (dadosTabelaVendaTotal.Rows.Count > 0)
                {
                    for (int i = 0; i < dadosTabelaVendaTotal.Rows.Count; i++)
                    {
                        listaRelatorioVendas.Add(new VENDAS()
                        {
                            codoBarra = dadosTabelaVendaTotal.Rows[i]["COD"].ToString().Trim(),
                            descricao = dadosTabelaVendaTotal.Rows[i]["DESCRICAO"].ToString().Trim(),
                            qtde = dadosTabelaVendaTotal.Rows[i]["QTDE"].ToString().Trim(),
                            subTotal = dadosTabelaVendaTotal.Rows[i]["TOTAL"].ToString().Trim(),
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public bool FecharCaixa()
        {
            if (MessageBox.Show("Confirmar Fechamento do Caixa.", "Confirmação Fechamento", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                try
                {
                    if (frmVenda.imprimirCupom == true)
                    {
                        for (int i = 0; i < frmVenda.qtdeCupom; i++)
                        {
                            MontarReducaoZ();
                        }
                    }
                    else
                    {
                        if (MessageBox.Show("Deseja Imprimir Relatório das Venda?", "Conformação", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                        {
                            MontarReducaoZ();
                        }
                    }

                    FecharNumCaixa();
                    FecharUsuario();
                    FecharVendasBaixada();
                    FecharPagamentoVendaBaixado();
                    FecharSangria();
                    ZeraArquivoVenda();

                    MessageBox.Show("Caixa Numero: " + numCaixa.ToString().PadLeft(3, '0') + " foi Fechado com Sucesso", "Caixa Fechado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    ret = true;
                }
                catch
                {
                    ret = false;
                }
            }

            return ret;
        }

        private void ZeraArquivoVenda()
        {
            string sourceDir = pathDadosVendaAutorizada;

            string backupDir = @"c:\archives\2008";

            try
            {
                string[] picList = Directory.GetFiles(sourceDir, "*.*");
                string[] txtList = Directory.GetFiles(sourceDir, "*.*");

                // Copy picture files.
                foreach (string f in picList)
                {
                    // Remove path from the file name.
                    string fName = f.Substring(sourceDir.Length + 1);

                    // Use the Path.Combine method to safely append the file name to the path.
                    // Will overwrite if the destination file already exists.
                    // File.Copy(Path.Combine(sourceDir, fName), Path.Combine(backupDir, fName), true);
                }

                // Copy text files.
                //foreach (string f in txtList)
                //{

                //    // Remove path from the file name.
                //    string fName = f.Substring(sourceDir.Length + 1);

                //    try
                //    {
                //        // Will not overwrite if the destination file already exists.
                //        File.Copy(Path.Combine(sourceDir, fName), Path.Combine(backupDir, fName));
                //    }

                //    // Catch exception if the file was already copied.
                //    catch (IOException copyError)
                //    {
                //        Console.WriteLine(copyError.Message);
                //    }
                //}

                // Delete source files that were copied.

                foreach (string f in txtList)
                {
                    File.Delete(f);
                }
                //foreach (string f in picList)
                //{
                //    File.Delete(f);
                //}
            }

            catch (DirectoryNotFoundException dirNotFound)
            {
                Console.WriteLine(dirNotFound.Message);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (counter >= 1000)
            {
                // Exit loop code.
                timer1.Enabled = false;
                counter = 0;
            }
            else
            {
                // Run your procedure here.
                // Increment counter.
                counter = counter + 1;
                label1.Text = "Procedures Run: " + counter.ToString();
            }
        }

        public void PesquisarSetor()
        {
            try
            {
                vendaC = new VendaC();
                vendaRegraNegocios = new VendaRegraNegocios();
                DataTable dadosTabelaVenda = new DataTable();

                vendaC.numCaixa = numCaixa;
                vendaC.fech = false;

                dadosTabelaVenda = vendaRegraNegocios.PesquisarVendaSetor(vendaC);

                if (dadosTabelaVenda.Rows.Count > 0)
                {
                    gdvDados.DataSource = null;
                    gdvDados.DataSource = dadosTabelaVenda;

                    lblQtdeVenda.Text = gdvDados.Rows.Count.ToString().PadLeft(3, '0');

                    gdvDados.Columns[0].Width = 50;
                    gdvDados.Columns[1].Width = 400;
                    //gdvDados.Columns[2].Width = 100;

                    somaTotal = 0;

                    for (int i = 0; i < dadosTabelaVenda.Rows.Count; i++)
                    {
                        somaTotal += Convert.ToDecimal(dadosTabelaVenda.Rows[i]["TOTAL"].ToString());
                    }

                    txtTotalVenda.Text = somaTotal.ToString("C2");
                    txtTotalVenda.BackColor = Color.Orange;
                }
                else
                {
                    gdvDados.DataSource = null;
                    lblQtdeVenda.Text = "000";
                }

                somaTotal = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção");
            }
        }

        public void PesquisarVendaDepartamentos()
        {
            try
            {
                vendaC = new VendaC();
                vendaRegraNegocios = new VendaRegraNegocios();
                DataTable dadosTabelaVenda = new DataTable();

                vendaC.idUsuario = frmVenda.idUsuario;
                vendaC.numCaixa = frmVenda.numCaixa;

                dadosTabelaVenda = vendaRegraNegocios.PesquisarVendaDepartamentos(vendaC);

                if (dadosTabelaVenda.Rows.Count > 0)
                {
                    gdvDados.DataSource = null;
                    gdvDados.DataSource = dadosTabelaVenda;

                    somaTotal = 0;

                    for (int i = 0; i < dadosTabelaVenda.Rows.Count; i++)
                    {
                        somaTotal += Convert.ToDecimal(dadosTabelaVenda.Rows[i]["TOTAL"].ToString());
                    }

                    txtTotalVenda.Text = somaTotal.ToString("C2");
                    txtTotalVenda.BackColor = Color.LawnGreen;

                    lblQtdeVenda.Text = gdvDados.Rows.Count.ToString().PadLeft(3, '0');

                    gdvDados.Columns[0].Width = 50;
                    gdvDados.Columns[1].Width = 400;
                    gdvDados.Columns[2].Width = 100;
                }
                else
                {
                    gdvDados.DataSource = null;
                    lblQtdeVenda.Text = "000";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção");
            }
        }

        public void PesquisarVendasCanceladasDetalhada()
        {
            string dt = cbSetor.Text;

            if (dt == "") dt = DateTime.Now.ToShortDateString();

            try
            {
                vendaC = new VendaC();
                vendaRegraNegocios = new VendaRegraNegocios();
                DataTable dadosTabelaVenda = new DataTable();

                if (numCaixa <= 0)
                {
                    MessageBox.Show("Numero do Caixa não Pode ser Menor ou Igual a Zero.", "Informação");
                }
                else
                {
                    vendaC.numCaixa = numCaixa;
                    vendaC.fech = false;

                    if (dt == DateTime.Now.ToShortDateString())
                    {
                        dadosTabelaVenda = vendaRegraNegocios.PesquisarVendasCanceladas(vendaC);
                    }
                    else
                    {
                        dadosTabelaVenda = vendaRegraNegocios.PesquisarVendasCanceladas(vendaC, dt);
                    }

                    somaTotal = 0;

                    if (dadosTabelaVenda.Rows.Count > 0)
                    {
                        gdvDados.DataSource = null;
                        gdvDados.DataSource = dadosTabelaVenda;

                        gdvDados.Columns[0].Width = 120; //CODIGO BARRAS
                        gdvDados.Columns[1].Width = 150; //DESCRICAO
                        gdvDados.Columns[2].Width = 50;  //UNIDADE
                        gdvDados.Columns[3].Width = 60;  //PRECO
                        gdvDados.Columns[4].Width = 70;  //QTDE
                        gdvDados.Columns[5].Width = 60;  //TOTAL
                        gdvDados.Columns[6].Width = 80;  //ESTOQUE

                        lblQtdeVenda.Text = gdvDados.Rows.Count.ToString().PadLeft(3, '0');

                        for (int i = 0; i < gdvDados.Rows.Count; i++)
                        {
                            somaTotal += Convert.ToDecimal(dadosTabelaVenda.Rows[i]["TOTAL"].ToString());
                        }

                        txtTotalVenda.Text = somaTotal.ToString("C2");
                        txtTotalVenda.BackColor = Color.MediumOrchid;
                    }
                    else
                    {
                        gdvDados.DataSource = null;
                        somaTotal = 0;
                        txtTotalVenda.Text = somaTotal.ToString("C2");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção");
            }
        }

        public void PesquisaVendaTotalEstoque()
        {
            try
            {
                vendaC = new VendaC();
                vendaRegraNegocios = new VendaRegraNegocios();
                DataTable dadosTabelaVenda = new DataTable();

                if (numCaixa <= 0)
                {
                    MessageBox.Show("Numero do Caixa não Pode ser Menor ou Igual a Zero.", "Informação");
                }
                else
                {
                    vendaC.numCaixa = numCaixa;
                    vendaC.idUsuario = idUsuario;

                    dadosTabelaVenda = vendaRegraNegocios.PesquisarVendaTotalEstoque(vendaC);

                    if (dadosTabelaVenda.Rows.Count > 0)
                    {
                        gdvDados.DataSource = null;
                        gdvDados.DataSource = dadosTabelaVenda;

                        gdvDados.Columns[0].Width = 120;
                        gdvDados.Columns[1].Width = 150;
                        gdvDados.Columns[2].Width = 50;
                        gdvDados.Columns[3].Width = 60;
                        gdvDados.Columns[4].Width = 70;
                        gdvDados.Columns[5].Width = 60;
                        gdvDados.Columns[6].Width = 80;

                        lblQtdeVenda.Text = gdvDados.Rows.Count.ToString().PadLeft(3, '0');

                        for (int i = 0; i < gdvDados.Rows.Count; i++)
                        {
                            somaTotal += Convert.ToDecimal(dadosTabelaVenda.Rows[i]["TOTAL"].ToString());
                        }

                        txtTotalVenda.Text = somaTotal.ToString("C2");
                        txtTotalVenda.BackColor = Color.Yellow;
                    }
                    else
                    {
                        gdvDados.DataSource = null;
                    }

                    somaTotal = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção");
            }
        }

        public void PesquisaTotalEstoque()
        {
            try
            {
                vendaC = new VendaC();
                vendaRegraNegocios = new VendaRegraNegocios();
                DataTable dadosTabelaVenda = new DataTable();

                if (numCaixa <= 0)
                {
                    MessageBox.Show("Numero do Caixa não Pode ser Menor ou Igual a Zero.", "Informação");
                }
                else
                {
                    vendaC.numCaixa = numCaixa;
                    vendaC.idUsuario = idUsuario;

                    dadosTabelaVenda = vendaRegraNegocios.PesquisarTotalEstoque(vendaC);

                    if (dadosTabelaVenda.Rows.Count > 0)
                    {
                        gdvDados.DataSource = null;
                        gdvDados.DataSource = dadosTabelaVenda;

                        gdvDados.Columns[0].Width = 120;
                        gdvDados.Columns[1].Width = 350;
                        gdvDados.Columns[2].Width = 50;

                        lblQtdeVenda.Text = gdvDados.Rows.Count.ToString().PadLeft(3, '0');

                        for (int i = 0; i < gdvDados.Rows.Count; i++)
                        {
                            somaTotal += Convert.ToDecimal(dadosTabelaVenda.Rows[i]["TOTAL"].ToString());
                        }

                        txtTotalVenda.Text = somaTotal.ToString("C2");
                    }
                    else
                    {
                        gdvDados.DataSource = null;
                    }

                    somaTotal = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção");
            }
        }

        public void PesquisaVendaTotalDetalhes()
        {
            try
            {
                vendaC = new VendaC();
                vendaRegraNegocios = new VendaRegraNegocios();
                DataTable dadosTabelaVenda = new DataTable();

                if (numCaixa <= 0)
                {
                    MessageBox.Show("Numero do Caixa não Pode ser Menor ou Igual a Zero.", "Informação");
                }
                else
                {
                    vendaC.numCaixa = numCaixa;
                    vendaC.idUsuario = idUsuario;

                    dadosTabelaVenda = vendaRegraNegocios.PesquisarVendaDetalhes(vendaC);

                    if (dadosTabelaVenda.Rows.Count > 0)
                    {
                        gdvDados.DataSource = null;
                        gdvDados.DataSource = dadosTabelaVenda;

                        gdvDados.Columns[0].Width = 120;
                        gdvDados.Columns[1].Width = 170;
                        gdvDados.Columns[2].Width = 70;

                        lblQtdeVenda.Text = gdvDados.Rows.Count.ToString().PadLeft(3, '0');

                        for (int i = 0; i < gdvDados.Rows.Count; i++)
                        {
                            somaTotal += Convert.ToDecimal(dadosTabelaVenda.Rows[i]["TOTAL"].ToString());
                        }

                        txtTotalVenda.Text = somaTotal.ToString("C2");
                        txtTotalVenda.BackColor = Color.Orange;
                    }
                    else
                    {
                        gdvDados.DataSource = null;
                    }

                    somaTotal = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção");
            }
        }

        DataTable dadosTabelaVendaTotal;

        public void PesquisaVendaTotal()
        {
            try
            {
                vendaC = new VendaC();
                vendaRegraNegocios = new VendaRegraNegocios();
                dadosTabelaVendaTotal = new DataTable();

                if (numCaixa <= 0)
                {
                    MessageBox.Show("Numero do Caixa não Pode ser Menor ou Igual a Zero.", "Informação");
                }
                else
                {
                    vendaC.numCaixa = numCaixa;
                    vendaC.idUsuario = idUsuario;

                    dadosTabelaVendaTotal = vendaRegraNegocios.PesquisarVendas(vendaC);

                    if (dadosTabelaVendaTotal.Rows.Count > 0)
                    {
                        gdvDados.DataSource = null;
                        gdvDados.DataSource = dadosTabelaVendaTotal;

                        gdvDados.Columns[0].Width = 120;
                        gdvDados.Columns[1].Width = 270;
                        gdvDados.Columns[2].Width = 80;
                        gdvDados.Columns[3].Width = 80;

                        lblQtdeVenda.Text = gdvDados.Rows.Count.ToString().PadLeft(3, '0');

                        for (int i = 0; i < gdvDados.Rows.Count; i++)
                        {
                            somaTotal += Convert.ToDecimal(dadosTabelaVendaTotal.Rows[i]["TOTAL"].ToString());
                        }

                        txtTotalVenda.Text = somaTotal.ToString("C2");
                        txtTotalVenda.BackColor = Color.Turquoise;
                    }
                    else
                    {
                        gdvDados.DataSource = null;
                    }

                    somaTotal = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção");
            }
        }

        private void btnSetor_Click(object sender, EventArgs e)
        {
            somaTotal = 0;
            PesquisarSetor();
            BloquearBotoesImprimir();
            btnImprimirSetor.Enabled = true;
            ColorTexboxSomaTotal();
        }

        private void btnVendaTotal_Click(object sender, EventArgs e)
        {
            somaTotal = 0;
            PesquisaVendaTotalEstoque();
            BloquearBotoesImprimir();
            btnImprimirVendaTotalEstoque.Enabled = true;
            ColorTexboxSomaTotal();
        }

        private void btnEstoqueDepartamento_Click(object sender, EventArgs e)
        {
            somaTotal = 0;
            PesquisarEstoqueDepartamento();
            BloquearBotoesImprimir();
            btnImpimirEstoqueDepartamento.Enabled = true;
            ColorTexboxSomaTotal();
        }

        public void PesquisarEstoqueDepartamento()
        {
            try
            {
                string numDepartamento = cbDepartamento.SelectedValue.ToString();
                txtNumeroDep.Text = numDepartamento.Trim();

                departamentoC = new DepartamentoC();
                departamentoRegraNegocios = new DepartamentoRegraNegocios();
                DataTable dadosTabelaDepartamento = new DataTable();

                if (Convert.ToInt32(numDepartamento) <= 0)
                {
                    MessageBox.Show("Informe Numero do Departamento Desejado para Concluír Pesquisa.", "Numero de Deparatmento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    departamentoC.numDepartamento = Convert.ToInt32(numDepartamento);
                    dadosTabelaDepartamento = departamentoRegraNegocios.PesquisarEstoqueDepartamento(departamentoC);

                    if (dadosTabelaDepartamento.Rows.Count > 0)
                    {
                        gdvDados.DataSource = null;
                        gdvDados.DataSource = dadosTabelaDepartamento;

                        gdvDados.Columns[0].Width = 120;
                        gdvDados.Columns[1].Width = 210;
                        gdvDados.Columns[2].Width = 70;
                        gdvDados.Columns[3].Width = 70;
                        gdvDados.Columns[4].Width = 70;

                        lblQtdeVenda.Text = gdvDados.Rows.Count.ToString().PadLeft(3, '0');

                        for (int i = 0; i < dadosTabelaDepartamento.Rows.Count; i++)
                        {
                            somaTotal += Convert.ToDecimal(dadosTabelaDepartamento.Rows[i]["Total"].ToString());
                        }

                        txtTotalVenda.Text = somaTotal.ToString("C2");
                    }
                    else
                    {
                        gdvDados.DataSource = null;
                        lblQtdeVenda.Text = "000";
                    }

                    somaTotal = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção");
            }
        }

        public void PesquisarEstoqueDepartamentos()
        {
            try
            {
                string numDepartamento = cbDepartamento.SelectedValue.ToString();
                txtNumeroDep.Text = numDepartamento.Trim();

                departamentoC = new DepartamentoC();
                departamentoRegraNegocios = new DepartamentoRegraNegocios();
                DataTable dadosTabelaDepartamento = new DataTable();

                if (Convert.ToInt32(numDepartamento) <= 0)
                {
                    MessageBox.Show("Informe Numero do Departamento Desejado para Concluír Pesquisa.", "Numero de Deparatmento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    departamentoC.numDepartamento = Convert.ToInt32(numDepartamento);

                    dadosTabelaDepartamento = departamentoRegraNegocios.PesquisarEstoqueDepartamentos(departamentoC);

                    if (dadosTabelaDepartamento.Rows.Count > 0)
                    {
                        gdvDados.DataSource = null;
                        gdvDados.DataSource = dadosTabelaDepartamento;

                        gdvDados.Columns[0].Width = 120;
                        gdvDados.Columns[1].Width = 330;
                        gdvDados.Columns[2].Width = 90;

                        lblQtdeVenda.Text = gdvDados.Rows.Count.ToString().PadLeft(3, '0');

                        dadosTabelaDepartamento = departamentoRegraNegocios.PesquisarEstoqueDepartamentosTotal(departamentoC);

                        somaTotal = Convert.ToDecimal(dadosTabelaDepartamento.Rows[0]["TOTAL"].ToString());

                        txtTotalVenda.Text = somaTotal.ToString("C2");
                    }
                    else
                    {
                        gdvDados.DataSource = null;
                        lblQtdeVenda.Text = "000";
                    }

                    somaTotal = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção");
            }
        }

        private void txtDescMoeda_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Escape)
            {
                btnSair_Click(sender, e);
            }
        }

        private void txtDescDinheiro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Escape)
            {
                btnSair_Click(sender, e);
            }
        }

        private void txtDescCartao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Escape)
            {
                btnSair_Click(sender, e);
            }
        }

        private void txtCheque_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Escape)
            {
                btnSair_Click(sender, e);
            }
        }

        private void txtDescAberto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Escape)
            {
                btnSair_Click(sender, e);
            }
        }

        private void txtDescRedeSete_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Escape)
            {
                btnSair_Click(sender, e);
            }
        }

        private void txtDesSangria_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Escape)
            {
                btnSair_Click(sender, e);
            }
        }

        private void txtDescDespesas_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Escape)
            {
                btnSair_Click(sender, e);
            }
        }

        private void txtDescTotalCaixa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Escape)
            {
                btnSair_Click(sender, e);
            }
        }

        private void txtDescDiferencaCaixa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Escape)
            {
                btnSair_Click(sender, e);
            }
        }

        private void cbDepartamento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Escape)
            {
                btnSair_Click(sender, e);
            }
        }

        private void gdvDados_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Escape)
            {
                btnSair_Click(sender, e);
            }
        }

        private void gdvPagamento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Escape)
            {
                btnSair_Click(sender, e);
            }
        }

        private void button10_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void btnSetor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void btnDepartamento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void btnVendaCancelada_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void btnVendaTotal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void btnEstoqueDepartamento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void btnImprimirSetor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void btnImprimirDepartamento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void btnImprimirVendaCancelada_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void btnImprimirVendaTotal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void btnImpimirEstoqueDepartamento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        public void BloquearBotoesImprimir()
        {
            btnImpimirEstoqueDepartamento.Enabled = false;
            btnImprimirDepartamento.Enabled = false;
            btnImprimirSetor.Enabled = false;
            btnImprimirVendaCanceladaDetalhes.Enabled = false;
            btnImprimirVendaTotalEstoque.Enabled = false;
            btnImprimirVendaTotal.Enabled = false;
            btnImprimirVendaTotalDetalhes.Enabled = false;
            btnImprimirVendaCancelada.Enabled = false;
            btnImprimirTotalEstoque.Enabled = false;
        }

        private void btnDepartamento_Click(object sender, EventArgs e)
        {
            somaTotal = 0;
            BloquearBotoesImprimir();
            btnImprimirDepartamento.Enabled = true;
            PesquisarVendaDepartamentos();
            ColorTexboxSomaTotal();
        }

        private void btnVendaCancelada_Click(object sender, EventArgs e)
        {
            somaTotal = 0;
            BloquearBotoesImprimir();
            btnImprimirVendaCanceladaDetalhes.Enabled = true;
            PesquisarVendasCanceladasDetalhada();
            ColorTexboxSomaTotal();
        }

        public void PesquisarDadosFechamentoCaixa()
        {
            try
            {
                for (int i = 0; i < gdvPagamento.Rows.Count; i++)
                {
                    tipoPagamento = gdvPagamento.Rows[i].Cells["colDescricao"].Value.ToString();

                    if ((tipoPagamento == "DINHEIRO") || (tipoPagamento == "Dinheiro"))
                    {
                        dinheiro = Convert.ToDecimal(gdvPagamento.Rows[i].Cells["colTotal"].Value.ToString());

                        txtDescDinheiro.Text = dinheiro.ToString();
                    }

                    if ((tipoPagamento == "CARTAO") || (tipoPagamento == "Cartao"))
                    {
                        cartao = Convert.ToDecimal(gdvPagamento.Rows[i].Cells["colTotal"].Value.ToString());

                        txtDescCartao.Text = cartao.ToString();
                    }

                    if ((tipoPagamento == "CHEQUE") || (tipoPagamento == "Cheque"))
                    {
                        cheque = Convert.ToDecimal(gdvPagamento.Rows[i].Cells["colTotal"].Value.ToString());

                        txtDescCheque.Text = cheque.ToString();
                    }

                    if ((tipoPagamento == "ABERTO") || (tipoPagamento == "Aberto"))
                    {
                        convenio = Convert.ToDecimal(gdvPagamento.Rows[i].Cells["colTotal"].Value.ToString());

                        txtDescAberto.Text = convenio.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void PesquisarSangria()
        {
            try
            {
                //DADOS TABELA SANGRIA
                string dataDia = DateTime.Now.Date.ToShortDateString();

                sangriaC = new SangriaC();
                sangriaRegraNegocios = new SangriaRegraNegocios();
                DataTable dadosTabelaSangria = new DataTable();

                dadosTabelaSangria = sangriaRegraNegocios.PesquisarSangriaCaixa(frmVenda.idUsuario, frmVenda.numCaixa);

                if (dadosTabelaSangria.Rows.Count > 0)
                {
                    for (int i = 0; i < dadosTabelaSangria.Rows.Count; i++)
                    {
                        bool tipo = Convert.ToBoolean(dadosTabelaSangria.Rows[i]["TIPO"].ToString());

                        if (tipo == true)
                        {
                            sangria += Convert.ToDecimal(dadosTabelaSangria.Rows[i]["VALOR"].ToString());
                        }
                        else if (tipo == false)
                        {
                            despesa += Convert.ToDecimal(dadosTabelaSangria.Rows[i]["VALOR"].ToString());
                        }
                    }

                    txtDesSangria.Text = sangria.ToString();
                    txtDescDespesas.Text = despesa.ToString();
                }
                else
                {
                    txtDesSangria.Text = "0,00";
                    txtDescDespesas.Text = "0,00";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void FecharSangria()
        {
            try
            {
                sangriaC = new SangriaC();
                sangriaRegraNegocios = new SangriaRegraNegocios();

                sangriaC.numCaixa = frmVenda.numCaixa;
                sangriaC.idUsuario = frmVenda.idUsuario;
                sangriaC.fechado = true;

                string idRetorno = sangriaRegraNegocios.FecharSangria(sangriaC);

                try
                {
                    int idRet = Convert.ToInt32(idRetorno);
                }
                catch
                {
                    MessageBox.Show("Erro ao Fechar Sangria Desepesas.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção");
            }
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            if (btnCalcular.Text.Equals("Fechar Caixa"))
            {
                btnCalcular.Text = "Calcular Venda";

                DesbloquearCampos();

                CalcularValores();

                btnFecharCaixa.Enabled = false;

                txtDescMoeda.Focus();
            }
            else
            {
                btnCalcular.Text = "Calcular Venda";

                CalcularValores();

                btnFecharCaixa.Enabled = true;
            }
        }

        public void CalcularValores()
        {
            moeda = 0;
            dinheiro = 0;
            cartao = 0;
            cheque = 0;
            convenio = 0;
            sangria = 0;
            despesa = 0;

            moeda = Convert.ToDecimal(txtDescMoeda.Text);
            dinheiro = Convert.ToDecimal(txtDescDinheiro.Text);
            cartao = Convert.ToDecimal(txtDescCartao.Text);
            cheque = Convert.ToDecimal(txtDescCheque.Text);
            convenio = Convert.ToDecimal(txtDescAberto.Text);
            sangria = Convert.ToDecimal(txtDesSangria.Text);
            despesa = Convert.ToDecimal(txtDescDespesas.Text);

            string st = txtTotalVenda.Text.Replace("R$", "");

            somaTotal = Convert.ToDecimal(st);
            resultado = (moeda + dinheiro + cartao + cheque + convenio + sangria + despesa);
            //  txtSomaTotal.Text = resultado.ToString("N2");
            diferencaCaixa = (resultado - somaTotal);
            txtDescDiferencaCaixa.Text = diferencaCaixa.ToString();
            diferencaCaixa = 0;

            btnFecharCaixa.Enabled = true;
        }

        public void DesbloquearCampos()
        {
            txtNumMoeda.Enabled = true;
            txtMoeda.Enabled = true;
            txtDescMoeda.Enabled = true;

            txtNumDinheiro.Enabled = true;
            txtDinheiro.Enabled = true;
            txtDescDinheiro.Enabled = true;

            txtNumCartao.Enabled = true;
            txtCartao.Enabled = true;
            txtDescCartao.Enabled = true;

            txtNumCheque.Enabled = true;
            txtCheque.Enabled = true;
            txtDescCheque.Enabled = true;

            txtNumConvenio.Enabled = true;
            txtConvenio.Enabled = true;
            txtDescAberto.Enabled = true;

            txtNumRede.Enabled = true;
            txtRede.Enabled = true;
            txtDescRedeSete.Enabled = true;

            txtNumSangria.Enabled = true;
            txtSsangria.Enabled = true;
            txtDesSangria.Enabled = true;

            txtValorLavaRapido.Enabled = true;
            txtValorLavaRapido.Enabled = true;
            txtNumLavaRapido.Enabled = true;

            txtNumDespesa.Enabled = true;
            txtDespesa.Enabled = true;
            txtDescDespesas.Enabled = true;

            txtTotalCaixa.Enabled = true;
            txtDescTotalCaixa.Enabled = true;

            txtDiferencaCaixa.Enabled = true;
            txtDescDiferencaCaixa.Enabled = true;
        }

        public void ImprimirVendaSetor()
        {
            try
            {
                List<Setor> ListaRelatorioStor = new List<Setor>();

                impressoraC = new IMPRESSORA.ImpressoraC();

                decimal tt = 0;
                string cupom = "";

                PesquisarSetor();

                if (gdvDados.Rows.Count > 0)
                {
                    for (int i = 0; i < gdvDados.Rows.Count; i++)
                    {
                        ListaRelatorioStor.Add(new Setor()
                        {
                            DesSetor = gdvDados.Rows[i].Cells[0].Value.ToString().Trim().PadLeft(3, '0'),
                            Descricao = gdvDados.Rows[i].Cells[1].Value.ToString().Trim(),
                            Valor = Convert.ToDecimal(gdvDados.Rows[i].Cells[2].Value.ToString()).ToString("N2")
                        });

                        int cont = gdvDados.Rows.Count;

                        tt = 0;

                        tt = Convert.ToDecimal(gdvDados.Rows[i].Cells[2].Value.ToString());

                        somaTotal += Convert.ToDecimal(gdvDados.Rows[i].Cells[2].Value.ToString());

                        cont = (i + 1);
                    }

                    if (frmVenda.nomeImpressora.Trim().Equals("BEMATECH") || (frmVenda.nomeImpressora.Trim().Equals("BEMASAT")))
                    {
                        bematechRegraNegocios = new BEMATECH();

                        DadosCabecalhoCupom = bematechRegraNegocios.CabecalhoCupomComum(cabecalho);
                        DadosCorpoCupom = bematechRegraNegocios.CorpoRelatorioSetor();
                        DadosPesquisaRelatorio = bematechRegraNegocios.CorpoRelatorioSetor(ListaRelatorioStor);
                        DadosFinaisCupom = bematechRegraNegocios.DadosFinaisSetor(somaTotal, numCaixa, nomeUsuario);

                        cupom = (DadosCabecalhoCupom + DadosCorpoCupom + DadosPesquisaRelatorio + DadosFinaisCupom);

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
                    else if ((frmVenda.nomeImpressora.Trim().Equals("ESCPOS")) || (frmVenda.nomeImpressora.Trim().Equals("EPSON")) || (frmVenda.nomeImpressora.Trim().Equals("ELGIN")))
                    {
                        escPos = new ESCPOS();

                        DadosCabecalhoCupom = escPos.CabecalhoCupomComum(cabecalho);
                        DadosCorpoCupom = escPos.CorpoRelatorioSetor();
                        DadosPesquisaRelatorio = escPos.CorpoRelatorioSetor(ListaRelatorioStor);
                        DadosFinaisCupom = escPos.DadosFinaisSetor(somaTotal, numCaixa, nomeUsuario);

                        cupom = (DadosCabecalhoCupom + DadosCorpoCupom + DadosPesquisaRelatorio + DadosFinaisCupom);

                        var printer = new Printer(frmVenda.nomeImpressoraPadrao, frmVenda.ObterTipo());

                        printer.Imprimirrelatorio(cupom);
                        printer.PartialPaperCut();
                        printer.PrintDocument();

                        printer.InitializePrint();

                        idRetorno = 1;
                    }

                    //LIMPAR VARIAVEIS
                    somaTotal = 0;

                    if (idRetorno > 0)
                    {
                        MessageBox.Show("Relatório de Impressão do Setor foi Realizado com Sucesso.", "Impressão com Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Erro ao Imprimir do Relatório do Setor.", "Erro de Impressão", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                LimparDados();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção");
            }
        }

        public void ImprimirDepartamento()
        {
            try
            {
                impressoraC = new IMPRESSORA.ImpressoraC();

                List<DepartamentoC> listaRelatorioDeparatmento = new List<DepartamentoC>();

                impressoraC = new IMPRESSORA.ImpressoraC();

                decimal tt = 0;
                somaTotal = 0;

                LimparDados();

                if (gdvDados.Rows.Count > 0)
                {
                    for (int i = 0; i < gdvDados.Rows.Count; i++)
                    {
                        listaRelatorioDeparatmento.Add(new DepartamentoC()
                        {
                            idDepartamento = gdvDados.Rows[i].Cells[0].Value.ToString().Trim().PadLeft(3, '0'),
                            descricaoDep = gdvDados.Rows[i].Cells[1].Value.ToString().Trim(),
                            Valor = Convert.ToDecimal(gdvDados.Rows[i].Cells[2].Value.ToString())
                        });

                        int cont = gdvDados.Rows.Count;

                        tt = 0;

                        tt = Convert.ToDecimal(gdvDados.Rows[i].Cells[2].Value.ToString());

                        somaTotal += tt;

                        cont = (i + 1);
                    }

                    if (frmVenda.nomeImpressora.Trim().Equals("BEMATECH") || frmVenda.nomeImpressora.Trim().Equals("BEMASAT"))
                    {
                        bematechRegraNegocios = new BEMATECH();

                        DadosCabecalhoCupom = bematechRegraNegocios.CabecalhoCupomComum(cabecalho);
                        DadosCorpoCupom = bematechRegraNegocios.CorpoRelatorioDepartamento();
                        DadosPesquisaRelatorio = bematechRegraNegocios.CorpoRelatorioDepartamento(listaRelatorioDeparatmento);
                        DadosFinaisCupom = bematechRegraNegocios.DadosFinaisSetor(somaTotal, numCaixa, nomeUsuario);

                        //LOCALIZA IMPRESSORA E PORTA COM
                        idRetorno = IMPRESSORA.BemasatImpressora.ConfiguraModeloImpressora(7);
                        idRetorno = IMPRESSORA.BemasatImpressora.IniciaPorta(frmVenda.numComimp);

                        esquerda = "" + (char)27 + (char)97 + (char)0;
                        centrarlizar = "" + (char)27 + (char)97 + (char)1;
                        direita = "" + (char)27 + (char)97 + (char)2;

                        string cupom = (DadosCabecalhoCupom + DadosCorpoCupom + DadosPesquisaRelatorio + DadosFinaisCupom);

                        impressoraC.detalhes = (cupom);

                        idRetorno = IMPRESSORA.BemasatImpressora.ComandoTX(esquerda, esquerda.Length);
                        idRetorno = IMPRESSORA.BemasatImpressora.FormataTX(impressoraC.detalhes + (char)10 + (char)13, 1, 0, 0, 0, 0);

                        idRetorno = IMPRESSORA.BemasatImpressora.AcionaGuilhotina(0);
                        idRetorno = IMPRESSORA.BemasatImpressora.FechaPorta();

                    }
                    else if (frmVenda.nomeImpressora.Trim().Equals("ESCPOS") || (frmVenda.nomeImpressora.Trim().Equals("ELGIN")))
                    {
                        escPos = new ESCPOS();

                        DadosCabecalhoCupom = escPos.CabecalhoCupomComum(cabecalho);
                        DadosCorpoCupom = escPos.CorpoRelatorioDepartamento();
                        DadosPesquisaRelatorio = escPos.CorpoRelatorioDepartamento(listaRelatorioDeparatmento);
                        DadosFinaisCupom = escPos.DadosFinaisSetor(somaTotal, numCaixa, nomeUsuario);

                        cupom = (DadosCabecalhoCupom + DadosCorpoCupom + DadosPesquisaRelatorio + DadosFinaisCupom);

                        var printer = new Printer(frmVenda.nomeImpressoraPadrao, frmVenda.ObterTipo());

                        printer.Imprimirrelatorio(cupom);
                        printer.PartialPaperCut();
                        printer.PrintDocument();

                        printer.InitializePrint();

                        idRetorno = 1;
                    }

                    //LIMPAR VARIAVEIS
                    somaTotal = 0;

                    if (idRetorno > 0)
                    {
                        MessageBox.Show("Relatório de Impressão do Departamento foi Realizado com Sucesso.", "Impressão com Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Erro ao Imprimir do Relatório do Setor.", "Erro de Impressão", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção");
            }
        }

        public void ImprimirVendaCancelada()
        {
            try
            {
                impressoraC = new IMPRESSORA.ImpressoraC();

                List<VENDAS> listaRelatorioVendaCancelada = new List<VENDAS>();

                impressoraC = new IMPRESSORA.ImpressoraC();

                decimal tt = 0;

                LimparDados();

                if (gdvDados.Rows.Count > 0)
                {
                    for (int i = 0; i < gdvDados.Rows.Count; i++)
                    {
                        listaRelatorioVendaCancelada.Add(new VENDAS()
                        {
                            codoBarra = gdvDados.Rows[i].Cells[0].Value.ToString().Trim(),
                            descricao = gdvDados.Rows[i].Cells[1].Value.ToString().Trim(),
                            unid = gdvDados.Rows[i].Cells[2].Value.ToString().Trim(),
                            precoProd = gdvDados.Rows[i].Cells[3].Value.ToString().Trim(),
                            qtde = gdvDados.Rows[i].Cells[4].Value.ToString().Trim(),
                            subTotal = gdvDados.Rows[i].Cells[5].Value.ToString(),
                            estoque = gdvDados.Rows[i].Cells[6].Value.ToString().Trim(),
                        });

                        int cont = gdvDados.Rows.Count;

                        tt = 0;

                        tt = Convert.ToDecimal(gdvDados.Rows[i].Cells[4].Value.ToString());

                        somaTotal += Convert.ToDecimal(gdvDados.Rows[i].Cells[4].Value.ToString());

                        cont = (i + 1);
                    }

                    if (frmVenda.nomeImpressora.Trim().Equals("BEMATECH") || frmVenda.nomeImpressora.Trim().Equals("BEMASAT"))
                    {
                        bematechRegraNegocios = new BEMATECH();

                        DadosCabecalhoCupom = bematechRegraNegocios.CabecalhoCupomComum(cabecalho);
                        DadosCorpoCupom = bematechRegraNegocios.CorpoRelatorioVendaCancelada();
                        DadosPesquisaRelatorio = bematechRegraNegocios.CorpoRelatorioVendaCancelada(listaRelatorioVendaCancelada);
                        DadosFinaisCupom = bematechRegraNegocios.DadosFinaisSetor(somaTotal, numCaixa, nomeUsuario);

                        //LOCALIZA IMPRESSORA E PORTA COM
                        idRetorno = IMPRESSORA.BemasatImpressora.ConfiguraModeloImpressora(7);
                        idRetorno = IMPRESSORA.BemasatImpressora.IniciaPorta(frmVenda.numComimp);

                        //IMPRIMIR CUPOM NAO FISCAL
                        impressoraC.detalhes = (DadosCabecalhoCupom + DadosCorpoCupom + DadosPesquisaRelatorio + DadosFinaisCupom);

                        esquerda = "" + (char)27 + (char)97 + (char)0;
                        centrarlizar = "" + (char)27 + (char)97 + (char)1;
                        direita = "" + (char)27 + (char)97 + (char)2;

                        idRetorno = IMPRESSORA.BemasatImpressora.ComandoTX(esquerda, esquerda.Length);
                        idRetorno = IMPRESSORA.BemasatImpressora.FormataTX(impressoraC.detalhes + (char)10 + (char)13, 1, 0, 0, 0, 0);

                        idRetorno = IMPRESSORA.BemasatImpressora.AcionaGuilhotina(0);

                        idRetorno = IMPRESSORA.BemasatImpressora.FechaPorta();
                    }
                    else if (frmVenda.nomeImpressora.Trim().Equals("ESCPOS") || frmVenda.nomeImpressora.Trim().Equals("ELGIN"))
                    {
                        escPos = new ESCPOS();

                        DadosCabecalhoCupom = escPos.CabecalhoCupomComum(cabecalho);
                        DadosCorpoCupom = escPos.CorpoRelatorioVendaCancelada();
                        DadosPesquisaRelatorio = escPos.CorpoRelatorioVendaCancelada(listaRelatorioVendaCancelada);
                        DadosFinaisCupom = escPos.DadosFinaisSetor(somaTotal, numCaixa, nomeUsuario);

                        cupom = (DadosCabecalhoCupom + DadosCorpoCupom + DadosPesquisaRelatorio + DadosFinaisCupom);

                        var printer = new Printer(frmVenda.nomeImpressoraPadrao, frmVenda.ObterTipo());

                        printer.Imprimirrelatorio(cupom);
                        printer.PartialPaperCut();
                        printer.PrintDocument();

                        printer.InitializePrint();

                        idRetorno = 1;
                    }

                    //LIMPAR VARIAVEIS
                    somaTotal = 0;

                    if (idRetorno > 0)
                    {
                        MessageBox.Show("Relatório de Impressão da Venda(s) Cancelada(s) foi Realizado com Sucesso.", "Impressão com Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Erro ao Imprimir do Venda(s) Cancelada(s).", "Erro de Impressão", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção");
            }
        }

        public void ImprimirVendaTotalEstoque()
        {
            try
            {
                impressoraC = new IMPRESSORA.ImpressoraC();

                List<VENDAS> listaRelatorioVendas = new List<VENDAS>();

                impressoraC = new IMPRESSORA.ImpressoraC();

                decimal tt = 0;

                LimparDados();

                if (gdvDados.Rows.Count > 0)
                {
                    for (int i = 0; i < gdvDados.Rows.Count; i++)
                    {
                        listaRelatorioVendas.Add(new VENDAS()
                        {
                            codoBarra = gdvDados.Rows[i].Cells[0].Value.ToString().Trim(),
                            descricao = gdvDados.Rows[i].Cells[1].Value.ToString().Trim(),
                            unid = gdvDados.Rows[i].Cells[2].Value.ToString().Trim(),
                            precoProd = Convert.ToDecimal(gdvDados.Rows[i].Cells[3].Value).ToString("N3").Trim(),
                            qtde = Convert.ToDecimal(gdvDados.Rows[i].Cells[4].Value).ToString("N3").Trim(),
                            subTotal = Convert.ToDecimal(gdvDados.Rows[i].Cells[5].Value).ToString("N3").Trim(),
                            estoque = Convert.ToDecimal(gdvDados.Rows[i].Cells[6].Value).ToString("N3").Trim(),
                        });

                        int cont = gdvDados.Rows.Count;

                        tt = 0;

                        tt = Convert.ToDecimal(gdvDados.Rows[i].Cells[4].Value.ToString());

                        somaTotal += Convert.ToDecimal(gdvDados.Rows[i].Cells[5].Value.ToString());

                        cont = (i + 1);
                    }

                    if (frmVenda.nomeImpressora.Trim().Equals("BEMATECH") || frmVenda.nomeImpressora.Trim().Equals("BEMASAT"))
                    {
                        bematechRegraNegocios = new BEMATECH();

                        DadosCabecalhoCupom = bematechRegraNegocios.CabecalhoCupomComum(cabecalho);
                        DadosCorpoCupom = bematechRegraNegocios.CorpoRelatorioVendas();
                        DadosPesquisaRelatorio = bematechRegraNegocios.CorpoRelatorioVendaCancelada(listaRelatorioVendas);
                        DadosFinaisCupom = bematechRegraNegocios.DadosFinaisSetor(somaTotal, numCaixa, nomeUsuario);

                        //LOCALIZA IMPRESSORA E PORTA COM
                        idRetorno = IMPRESSORA.BemasatImpressora.ConfiguraModeloImpressora(7);
                        idRetorno = IMPRESSORA.BemasatImpressora.IniciaPorta(frmVenda.numComimp);

                        impressoraC.detalhes = (DadosCabecalhoCupom + DadosCorpoCupom + DadosPesquisaRelatorio + DadosFinaisCupom);

                        idRetorno = IMPRESSORA.BemasatImpressora.FormataTX(impressoraC.detalhes + (char)10 + (char)13, 1, 0, 0, 0, 0);

                        idRetorno = IMPRESSORA.BemasatImpressora.AcionaGuilhotina(0);

                        idRetorno = IMPRESSORA.BemasatImpressora.FechaPorta();
                    }
                    else if (frmVenda.nomeImpressora.Trim().Equals("ESCPOS") || (frmVenda.nomeImpressora.Trim().Equals("EPSON")) || (frmVenda.nomeImpressora.Trim().Equals("ELGIN")))
                    {
                        escPos = new ESCPOS();

                        DadosCabecalhoCupom = escPos.CabecalhoCupomComum(cabecalho);
                        DadosCorpoCupom = escPos.CorpoRelatorioVendas();
                        DadosPesquisaRelatorio = escPos.CorpoRelatorioVendaCancelada(listaRelatorioVendas);
                        DadosFinaisCupom = escPos.DadosFinaisSetor(somaTotal, numCaixa, nomeUsuario);

                        cupom = (DadosCabecalhoCupom + DadosCorpoCupom + DadosPesquisaRelatorio + DadosFinaisCupom);

                        var printer = new Printer(frmVenda.nomeImpressoraPadrao, frmVenda.ObterTipo());

                        printer.Imprimirrelatorio(cupom);
                        printer.PartialPaperCut();
                        printer.PrintDocument();

                        printer.InitializePrint();

                        idRetorno = 1;
                    }

                    //LIMPAR VARIAVEIS
                    somaTotal = 0;

                    if (idRetorno > 0)
                    {
                        MessageBox.Show("Relatório de Impressão da Venda(s) foi Realizado com Sucesso.", "Impressão com Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Erro ao Imprimir do Venda(s)'.", "Erro de Impressão", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção");
            }
        }

        public void ImprimirVendaTotal()
        {
            try
            {
                impressoraC = new IMPRESSORA.ImpressoraC();

                List<VENDAS> listaRelatorioVendas = new List<VENDAS>();

                impressoraC = new IMPRESSORA.ImpressoraC();

                decimal tt = 0;

                if (gdvDados.Rows.Count > 0)
                {
                    for (int i = 0; i < gdvDados.Rows.Count; i++)
                    {
                        listaRelatorioVendas.Add(new VENDAS()
                        {
                            codoBarra = gdvDados.Rows[i].Cells[0].Value.ToString().Trim(),
                            descricao = gdvDados.Rows[i].Cells[1].Value.ToString().Trim(),
                            qtde = gdvDados.Rows[i].Cells[2].Value.ToString().Trim(),
                            subTotal = gdvDados.Rows[i].Cells[3].Value.ToString(),

                        });

                        int cont = gdvDados.Rows.Count;

                        tt = 0;

                        tt = Convert.ToDecimal(gdvDados.Rows[i].Cells[3].Value.ToString());

                        somaTotal += Convert.ToDecimal(gdvDados.Rows[i].Cells[3].Value.ToString());

                        cont = (i + 1);
                    }

                    if (frmVenda.nomeImpressora.Trim().Equals("BEMATECH") || frmVenda.nomeImpressora.Trim().Equals("BEMASAT"))
                    {
                        bematechRegraNegocios = new BEMATECH();

                        DadosCabecalhoCupom = bematechRegraNegocios.CabecalhoCupomComum(cabecalho);
                        DadosCorpoCupom = bematechRegraNegocios.CorpoRelatorioVendas();
                        DadosPesquisaRelatorio = bematechRegraNegocios.CorpoRelatorioVendaRZ(listaRelatorioVendas);
                        DadosFinaisCupom = bematechRegraNegocios.DadosFinaisSetor(somaTotal, numCaixa, nomeUsuario);

                        //LOCALIZA IMPRESSORA E PORTA COM
                        idRetorno = IMPRESSORA.BemasatImpressora.ConfiguraModeloImpressora(7);
                        idRetorno = IMPRESSORA.BemasatImpressora.IniciaPorta(frmVenda.numComimp);

                        impressoraC.detalhes = (DadosCabecalhoCupom + DadosCorpoCupom + DadosPesquisaRelatorio + DadosFinaisCupom + DateTime.Now);

                        idRetorno = IMPRESSORA.BemasatImpressora.FormataTX(impressoraC.detalhes + (char)10 + (char)13, 1, 0, 0, 0, 0);

                        idRetorno = IMPRESSORA.BemasatImpressora.AcionaGuilhotina(0);

                        idRetorno = IMPRESSORA.BemasatImpressora.FechaPorta();
                    }
                    else if (frmVenda.nomeImpressora.Trim().Equals("ESCPOS") || (frmVenda.nomeImpressora.Trim().Equals("EPSON")) || (frmVenda.nomeImpressora.Trim().Equals("ELGIN")))
                    {
                        escPos = new ESCPOS();

                        DadosCabecalhoCupom = escPos.CabecalhoCupomComum(cabecalho);
                        DadosCorpoCupom = escPos.CorpoRelatorioVenda();
                        DadosPesquisaRelatorio = escPos.CorpoRelatorioVenda(listaRelatorioVendas);
                        DadosFinaisCupom = escPos.DadosFinaisSetor(somaTotal, numCaixa, nomeUsuario);

                        cupom = (DadosCabecalhoCupom + DadosCorpoCupom + DadosPesquisaRelatorio + DadosFinaisCupom + DateTime.Now);

                        var printer = new Printer(frmVenda.nomeImpressoraPadrao, frmVenda.ObterTipo());

                        printer.Imprimirrelatorio(cupom);
                        printer.PartialPaperCut();
                        printer.PrintDocument();

                        printer.InitializePrint();

                        idRetorno = 1;
                    }

                    //LIMPAR VARIAVEIS
                    somaTotal = 0;

                    if (idRetorno > 0)
                    {
                        MessageBox.Show("Relatório de Impressão da Venda(s) foi Realizado com Sucesso.", "Impressão com Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Erro ao Imprimir do Venda(s)'.", "Erro de Impressão", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                LimparDados();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção");
            }
        }

        public void ImprimirVendaTotalDetalhes()
        {
            try
            {
                impressoraC = new IMPRESSORA.ImpressoraC();

                List<VENDAS> listaRelatorioVendas = new List<VENDAS>();

                impressoraC = new IMPRESSORA.ImpressoraC();

                decimal tt = 0;

                LimparDados();

                if (gdvDados.Rows.Count > 0)
                {
                    for (int i = 0; i < gdvDados.Rows.Count; i++)
                    {
                        listaRelatorioVendas.Add(new VENDAS()
                        {
                            codoBarra = gdvDados.Rows[i].Cells[0].Value.ToString().Trim(),
                            descricao = gdvDados.Rows[i].Cells[1].Value.ToString().Trim(),
                            unid = gdvDados.Rows[i].Cells[2].Value.ToString().Trim(),
                            precoProd = gdvDados.Rows[i].Cells[4].Value.ToString().Trim(),
                            qtde = gdvDados.Rows[i].Cells[3].Value.ToString().Trim(),
                            subTotal = gdvDados.Rows[i].Cells[5].Value.ToString().Trim(),
                            estoque = gdvDados.Rows[i].Cells[6].Value.ToString().Trim(),
                        });

                        int cont = gdvDados.Rows.Count;

                        tt = 0;

                        tt = Convert.ToDecimal(gdvDados.Rows[i].Cells[4].Value.ToString());

                        somaTotal += Convert.ToDecimal(gdvDados.Rows[i].Cells[5].Value.ToString());

                        cont = (i + 1);
                    }

                    if (frmVenda.nomeImpressora.Trim().Equals("BEMATECH") || frmVenda.nomeImpressora.Trim().Equals("BEMASAT"))
                    {
                        bematechRegraNegocios = new BEMATECH();

                        DadosCabecalhoCupom = bematechRegraNegocios.CabecalhoCupomComum(cabecalho);
                        DadosCorpoCupom = bematechRegraNegocios.CorpoRelatorioVendas();
                        DadosPesquisaRelatorio = bematechRegraNegocios.CorpoRelatorioVendaCancelada(listaRelatorioVendas);
                        DadosFinaisCupom = bematechRegraNegocios.DadosFinaisSetor(somaTotal, numCaixa, nomeUsuario);

                        //LOCALIZA IMPRESSORA E PORTA COM
                        idRetorno = IMPRESSORA.BemasatImpressora.ConfiguraModeloImpressora(7);
                        idRetorno = IMPRESSORA.BemasatImpressora.IniciaPorta(frmVenda.numComimp);

                        impressoraC.detalhes = (DadosCabecalhoCupom + DadosCorpoCupom + DadosPesquisaRelatorio + DadosFinaisCupom);

                        idRetorno = IMPRESSORA.BemasatImpressora.FormataTX(impressoraC.detalhes + (char)10 + (char)13, 1, 0, 0, 0, 0);

                        idRetorno = IMPRESSORA.BemasatImpressora.AcionaGuilhotina(0);

                        idRetorno = IMPRESSORA.BemasatImpressora.FechaPorta();
                    }
                    else if (frmVenda.nomeImpressora.Trim().Equals("ESCPOS") || (frmVenda.nomeImpressora.Trim().Equals("EPSON")) || (frmVenda.nomeImpressora.Trim().Equals("ELGIN")))
                    {
                        escPos = new ESCPOS();

                        DadosCabecalhoCupom = escPos.CabecalhoCupomComum(cabecalho);
                        DadosCorpoCupom = escPos.CorpoRelatorioVendaDetalhes();
                        DadosPesquisaRelatorio = escPos.CorpoRelatorioVendaCancelada(listaRelatorioVendas);
                        DadosFinaisCupom = escPos.DadosFinaisSetor(somaTotal, numCaixa, nomeUsuario);

                        cupom = (DadosCabecalhoCupom + DadosCorpoCupom + DadosPesquisaRelatorio + DadosFinaisCupom);

                        var printer = new Printer(frmVenda.nomeImpressoraPadrao, frmVenda.ObterTipo());

                        printer.Imprimirrelatorio(cupom);
                        printer.PartialPaperCut();
                        printer.PrintDocument();

                        printer.InitializePrint();

                        idRetorno = 1;
                    }

                    //LIMPAR VARIAVEIS
                    somaTotal = 0;

                    if (idRetorno > 0)
                    {
                        MessageBox.Show("Relatório de Impressão da Venda(s) foi Realizado com Sucesso.", "Impressão com Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Erro ao Imprimir do Venda(s)'.", "Erro de Impressão", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção");
            }
        }

        public void ImprimirRelatorioEstoque()
        {
            try
            {
                impressoraC = new IMPRESSORA.ImpressoraC();

                List<VENDAS> listaRelatorioVendas = new List<VENDAS>();

                impressoraC = new IMPRESSORA.ImpressoraC();

                decimal tt = 0;

                LimparDados();

                if (gdvDados.Rows.Count > 0)
                {
                    for (int i = 0; i < gdvDados.Rows.Count; i++)
                    {
                        listaRelatorioVendas.Add(new VENDAS()
                        {
                            codoBarra = gdvDados.Rows[i].Cells[0].Value.ToString().Trim(),
                            descricao = gdvDados.Rows[i].Cells[1].Value.ToString().Trim(),
                            precoProd = gdvDados.Rows[i].Cells[3].Value.ToString().Trim(),
                            qtde = gdvDados.Rows[i].Cells[2].Value.ToString().Trim(),
                            subTotal = Convert.ToDecimal(gdvDados.Rows[i].Cells[4].Value.ToString()).ToString("N3"),
                        });

                        int cont = gdvDados.Rows.Count;

                        tt = 0;

                        tt = Convert.ToDecimal(gdvDados.Rows[i].Cells[4].Value.ToString());

                        somaTotal += Convert.ToDecimal(gdvDados.Rows[i].Cells[4].Value.ToString());

                        cont = (i + 1);
                    }

                    if (frmVenda.nomeImpressora.Trim().Equals("BEMATECH") || frmVenda.nomeImpressora.Trim().Equals("BEMASAT"))
                    {
                        bematechRegraNegocios = new BEMATECH();

                        DadosCabecalhoCupom = bematechRegraNegocios.CabecalhoCupomComum(cabecalho);
                        DadosCorpoCupom = bematechRegraNegocios.CorpoRelatorioEstoqueTotal();
                        DadosPesquisaRelatorio = bematechRegraNegocios.CorpoRelatorioEstoqueTotal(listaRelatorioVendas);
                        DadosFinaisCupom = bematechRegraNegocios.DadosFinaisSetor(somaTotal, numCaixa, nomeUsuario);

                        cupom = (DadosCabecalhoCupom + DadosCorpoCupom + DadosPesquisaRelatorio + DadosFinaisCupom);

                        //LOCALIZA IMPRESSORA E PORTA COM
                        idRetorno = IMPRESSORA.BemasatImpressora.ConfiguraModeloImpressora(7);
                        idRetorno = IMPRESSORA.BemasatImpressora.IniciaPorta(frmVenda.numComimp);

                        idRetorno = IMPRESSORA.BemasatImpressora.FormataTX(cupom + (char)10 + (char)13, 1, 0, 0, 0, 0);

                        idRetorno = IMPRESSORA.BemasatImpressora.AcionaGuilhotina(0);

                        idRetorno = IMPRESSORA.BemasatImpressora.FechaPorta();
                    }
                    else if (frmVenda.nomeImpressora.Trim().Equals("ESCPOS"))
                    {
                        escPos = new ESCPOS();

                        DadosCabecalhoCupom = escPos.CabecalhoCupomComum(cabecalho);
                        DadosCorpoCupom = escPos.CorpoRelatorioEstoque();
                        DadosPesquisaRelatorio = escPos.CorpoRelatorioEstoqueTotal(listaRelatorioVendas);
                        DadosFinaisCupom = escPos.DadosFinaisSetor(somaTotal, numCaixa, nomeUsuario);

                        cupom = (DadosCabecalhoCupom + DadosCorpoCupom + DadosPesquisaRelatorio + DadosFinaisCupom);

                        var printer = new Printer(frmVenda.nomeImpressoraPadrao, frmVenda.ObterTipo());

                        printer.Imprimirrelatorio(cupom);
                        printer.PartialPaperCut();
                        printer.PrintDocument();

                        printer.InitializePrint();

                        idRetorno = 1;
                    }

                    somaTotal = 0;

                    if (idRetorno > 0)
                    {
                        MessageBox.Show("Relatório de Impressão da Venda(s) foi Realizado com Sucesso.", "Impressão com Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Erro ao Imprimir do Venda(s)'.", "Erro de Impressão", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção");
            }
        }

        public void ImprimirRelatorioEstoques()
        {
            try
            {
                impressoraC = new IMPRESSORA.ImpressoraC();

                List<VENDAS> listaRelatorioVendas = new List<VENDAS>();

                impressoraC = new IMPRESSORA.ImpressoraC();

                decimal tt = 0;

                LimparDados();

                if (gdvDados.Rows.Count > 0)
                {
                    for (int i = 0; i < gdvDados.Rows.Count; i++)
                    {
                        listaRelatorioVendas.Add(new VENDAS()
                        {
                            codoBarra = gdvDados.Rows[i].Cells[0].Value.ToString().Trim(),
                            descricao = gdvDados.Rows[i].Cells[1].Value.ToString().Trim(),
                            estoque = Convert.ToDecimal(gdvDados.Rows[i].Cells[2].Value.ToString().Trim()).ToString("N3")
                            //precoProd = Convert.ToDecimal(gdvDados.Rows[i].Cells[3].Value.ToString().Trim()).ToString("N3"),
                            //qtde = Convert.ToDecimal(gdvDados.Rows[i].Cells[4].Value.ToString().Trim()).ToString("N3"),
                            //subTotal = Convert.ToDecimal(gdvDados.Rows[i].Cells[5].Value.ToString().Trim()).ToString("N3"),
                        });

                        int cont = gdvDados.Rows.Count;

                        tt = 0;

                        tt = Convert.ToDecimal(gdvDados.Rows[i].Cells[2].Value.ToString());

                        cont = (i + 1);
                    }

                    somaTotal = Convert.ToDecimal(txtTotalVenda.Text.Replace("R$", "").Replace("-", ""));

                    if (frmVenda.nomeImpressora.Trim().Equals("BEMATECH") || frmVenda.nomeImpressora.Trim().Equals("BEMASAT"))
                    {
                        bematechRegraNegocios = new BEMATECH();

                        DadosCabecalhoCupom = bematechRegraNegocios.CabecalhoCupomComum(cabecalho);
                        DadosCorpoCupom = bematechRegraNegocios.CorpoRelatorioEstoque();
                        DadosPesquisaRelatorio = bematechRegraNegocios.CorpoRelatorioEstoqueTotal(listaRelatorioVendas);
                        DadosFinaisCupom = bematechRegraNegocios.DadosFinaisSetor(somaTotal, numCaixa, nomeUsuario);

                        cupom = (DadosCabecalhoCupom + DadosCorpoCupom + DadosPesquisaRelatorio + DadosFinaisCupom);

                        //LOCALIZA IMPRESSORA E PORTA COM
                        idRetorno = IMPRESSORA.BemasatImpressora.ConfiguraModeloImpressora(7);
                        idRetorno = IMPRESSORA.BemasatImpressora.IniciaPorta(frmVenda.numComimp);

                        idRetorno = IMPRESSORA.BemasatImpressora.FormataTX(cupom + (char)10 + (char)13, 1, 0, 0, 0, 0);

                        idRetorno = IMPRESSORA.BemasatImpressora.AcionaGuilhotina(0);

                        idRetorno = IMPRESSORA.BemasatImpressora.FechaPorta();
                    }
                    else if (frmVenda.nomeImpressora.Trim().Equals("ESCPOS"))
                    {
                        escPos = new ESCPOS();

                        DadosCabecalhoCupom = escPos.CabecalhoCupomComum(cabecalho);
                        DadosCorpoCupom = escPos.CorpoRelatorioEstoques();
                        DadosPesquisaRelatorio = escPos.CorpoRelatorioEstoquesTotal(listaRelatorioVendas);
                        DadosFinaisCupom = escPos.DadosFinaisSetor(somaTotal, numCaixa, nomeUsuario);

                        cupom = (DadosCabecalhoCupom + DadosCorpoCupom + DadosPesquisaRelatorio + DadosFinaisCupom);

                        var printer = new Printer(frmVenda.nomeImpressoraPadrao, frmVenda.ObterTipo());

                        printer.Imprimirrelatorio(cupom);
                        printer.PartialPaperCut();
                        printer.PrintDocument();

                        printer.InitializePrint();

                        idRetorno = 1;
                    }

                    //LIMPAR VARIAVEIS
                    somaTotal = 0;

                    if (idRetorno > 0)
                    {
                        MessageBox.Show("Relatório de Impressão da Venda(s) foi Realizado com Sucesso.", "Impressão com Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Erro ao Imprimir do Venda(s)'.", "Erro de Impressão", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção");
            }
        }

        public void LimparDados()
        {
            DadosCabecalhoCupom = "";
            DadosCorpoCupom = "";
            DadosPesquisaRelatorio = "";
            DadosFinaisCupom = "";
        }

        private void btnImprimirSetor_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirmação para Gerar Relatório de Venda do Setor", "Gerar Relatório Setor", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                ImprimirVendaSetor();

                ColorTexboxSomaTotal();
            }
        }

        private void btnSair_Click_1(object sender, EventArgs e)
        {
            this.Close();

            this.frmVenda.LimparCampos();
        }

        private void txtSomaTotal_TextChanged(object sender, EventArgs e)
        {
            ColorTexboxSomaTotal();
        }

        public void ColorTexboxSomaTotal()
        {
            string t = txtTotalVenda.Text;

            t = t.Replace("R", "").Replace("$", "").Replace(" ", "");

            if (Convert.ToDecimal(t) > 0)
            {
                txtTotalVenda.ForeColor = Color.Blue;
            }
            else if (Convert.ToDecimal(t) == 0)
            {
                txtTotalVenda.ForeColor = Color.Green;
            }
            else if ((Convert.ToDecimal(t) < 0) || (t == "0,00"))
            {
                txtTotalVenda.ForeColor = Color.Red;
            }
        }

        private void btnImprimirDepartamento_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirmação para Gerar Relatório de Venda por Departamento", "Gerar Relatório Departamento", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                if (gdvDados.Rows.Count > 0)
                {
                    ImprimirDepartamento();

                    ColorTexboxSomaTotal();
                }
                else
                {
                    MessageBox.Show("Não Comtém Dados de Venda por Departamento para Tirar Relatório.", "Gerar Relatório Venda Canceladas", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }

        private void btnImprimirVendaCancelada_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirmação para Gerar Relatório de Venda Canceladas", "Gerar Relatório Venda Canceladas", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                if (gdvDados.Rows.Count > 0)
                {
                    ImprimirVendaCancelada();

                    ColorTexboxSomaTotal();
                }
                else
                {
                    MessageBox.Show("Não Comtém Dados de Venda Cancelada para Tirar Relatório.", "Gerar Relatório Venda Canceladas", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }

        private void btnImpimirEstoqueDepartamento_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirmação para Gerar Relatório de Estoque", "Gerar Relatório Venda Estoque", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                if (gdvDados.Rows.Count > 0)
                {
                    ImprimirRelatorioEstoque();

                    ColorTexboxSomaTotal();
                }
                else
                {
                    MessageBox.Show("Não Comtém Dados de Vendas de Estoque por Departamento para Tirar Relatório.", "Gerar Relatório Venda Canceladas", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
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
                n = n.PadLeft(3, '0');
                if (n.Length > 3 & n.Substring(0, 1) == "0")
                    n = n.Substring(1, n.Length - 1);
                v = Convert.ToDecimal(n) / 100;
                txt.Text = string.Format("{0:N}", v);
                txt.SelectionStart = txt.Text.Length;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Registro do Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtDescMoeda_TextChanged(object sender, EventArgs e)
        {
            Moeda(ref txtDescMoeda);
        }

        private void frmFechamentoCaixa_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmVenda.LimparCampos();
        }

        private void btnVendaTotal_Click_1(object sender, EventArgs e)
        {
            somaTotal = 0;
            PesquisaVendaTotal();
            BloquearBotoesImprimir();
            btnImprimirVendaTotal.Enabled = true;
            ColorTexboxSomaTotal();
        }

        private void btnImprimirVendaTotalEstoque_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirmação para Gerar Relatório de Venda Total com Estoque", "Gerar Relatório Venda Total com Estoque", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                if (gdvDados.Rows.Count > 0)
                {
                    ImprimirVendaTotalEstoque();

                    ColorTexboxSomaTotal();
                }
                else
                {
                    MessageBox.Show("Não Comtém Dados de Vendas para Tirar Relatório.", "Gerar Relatório Venda Canceladas", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }

        private void btnImprimirVendaTotal_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirmação para Gerar Relatório de Venda Total", "Gerar Relatório Venda Total", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                if (gdvDados.Rows.Count > 0)
                {
                    ImprimirVendaTotal();

                    ColorTexboxSomaTotal();
                }
                else
                {
                    MessageBox.Show("Não Comtém Dados de Vendas para Tirar Relatório.", "Gerar Relatório Venda Canceladas", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }

        private void btnImprimirVendaTotalDetalhes_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirmação para Gerar Relatório de Venda Total", "Gerar Relatório Venda Total", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                if (gdvDados.Rows.Count > 0)
                {
                    ImprimirVendaTotalDetalhes();

                    ColorTexboxSomaTotal();
                }
                else
                {
                    MessageBox.Show("Não Comtém Dados de Vendas para Tirar Relatório.", "Gerar Relatório Venda Canceladas", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }

        private void btnVendaTotalDetalhe_Click(object sender, EventArgs e)
        {
            somaTotal = 0;
            PesquisaVendaTotalDetalhes();
            BloquearBotoesImprimir();
            btnImprimirVendaTotalDetalhes.Enabled = true;
            ColorTexboxSomaTotal();
        }

        private void btnVendaCancelada_Click_1(object sender, EventArgs e)
        {
            somaTotal = 0;
            BloquearBotoesImprimir();
            btnImprimirVendaCancelada.Enabled = true;
            PesquisarVendasSetor();
            ColorTexboxSomaTotal();
        }

        private void PesquisarVendasSetor()
        {
            try
            {
                string setor = "";

                vendaC = new VendaC();
                vendaRegraNegocios = new VendaRegraNegocios();
                dadosTabelaVendaTotal = new DataTable();

                if (numCaixa <= 0)
                {
                    MessageBox.Show("Numero do Caixa não Pode ser Menor ou Igual a Zero.", "Informação");
                }
                else
                {
                    vendaC.numCaixa = numCaixa;
                    vendaC.idUsuario = idUsuario;
                    try
                    {
                        setor = (cbSetor.Text.Substring(0, 1).Trim());
                    }
                    catch
                    {
                        setor = "1";
                    }


                    dadosTabelaVendaTotal = vendaRegraNegocios.PesquisarVendas(vendaC, setor);

                    if (dadosTabelaVendaTotal.Rows.Count > 0)
                    {
                        gdvDados.DataSource = null;
                        gdvDados.DataSource = dadosTabelaVendaTotal;

                        gdvDados.Columns[0].Width = 120;
                        gdvDados.Columns[1].Width = 270;
                        gdvDados.Columns[2].Width = 80;
                        gdvDados.Columns[3].Width = 80;

                        lblQtdeVenda.Text = gdvDados.Rows.Count.ToString().PadLeft(3, '0');

                        for (int i = 0; i < gdvDados.Rows.Count; i++)
                        {
                            somaTotal += Convert.ToDecimal(dadosTabelaVendaTotal.Rows[i]["TOTAL"].ToString());
                        }

                        txtTotalVenda.Text = somaTotal.ToString("C2");
                        txtTotalVenda.BackColor = Color.Turquoise;
                    }
                    else
                    {
                        gdvDados.DataSource = null;
                    }

                    somaTotal = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção");
            }
        }

        private void btnTotalEstoque_Click(object sender, EventArgs e)
        {
            somaTotal = 0;
            PesquisarEstoqueDepartamentos();
            BloquearBotoesImprimir();
            btnImprimirTotalEstoque.Enabled = true;
            ColorTexboxSomaTotal();
        }

        private void btnImprimirTotalEstoque_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirmação para Gerar Relatório de Estoque", "Gerar Relatório Venda Estoque", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                if (gdvDados.Rows.Count > 0)
                {
                    ImprimirRelatorioEstoques();

                    ColorTexboxSomaTotal();
                }
                else
                {
                    MessageBox.Show("Não Comtém Dados de Vendas de Estoque por Departamento para Tirar Relatório.", "Gerar Relatório Venda Canceladas", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }

        private void btnImprimirVendaCancelada_Click_1(object sender, EventArgs e)
        {
            btnImprimirVendaTotal_Click(sender, e);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MontarReducaoZ();
        }

        private void txtDescDinheiro_TextChanged(object sender, EventArgs e)
        {
            Moeda(ref txtDescDinheiro);
        }

        private void txtDescCartao_TextChanged(object sender, EventArgs e)
        {
            Moeda(ref txtDescCartao);
        }

        private void txtDescCheque_TextChanged(object sender, EventArgs e)
        {
            Moeda(ref txtDescCheque);
        }

        private void txtDescAberto_TextChanged(object sender, EventArgs e)
        {
            Moeda(ref txtDescAberto);
        }

        private void txtDescRedeSete_TextChanged(object sender, EventArgs e)
        {
            Moeda(ref txtDescRedeSete);
        }

        private void txtDesSangria_TextChanged(object sender, EventArgs e)
        {
            Moeda(ref txtDesSangria);
        }

        private void txtDescDespesas_TextChanged(object sender, EventArgs e)
        {
            Moeda(ref txtDescDespesas);
        }

        private void txtDescTotalCaixa_TextChanged(object sender, EventArgs e)
        {
            Moeda(ref txtDescTotalCaixa);
        }

        private void txtDescDiferencaCaixa_TextChanged(object sender, EventArgs e)
        {
            Moeda(ref txtDescDiferencaCaixa);
        }
    }
}
