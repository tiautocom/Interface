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
using IMPRESSORA;
using System.Drawing.Printing;
using Vip.Printer;

namespace SAT
{
    public partial class frmSangriaDespesas : Form
    {
        frmVenda frmVenda;

        public frmSangriaDespesas(frmVenda fVenda)
        {
            InitializeComponent();
            this.frmVenda = fVenda;
        }

        #region VARIAVEIS

        //IMPRESSORA
        public int idRetorno = 0;

        DateTime data;

        public bool tipo;
        public int contador, idUsuario, numCaixa, qtdeCupom = 0;
        public decimal valorT = 0;
        public string descricao, nomeImpressora = "";

        public string cupomSangria = "";
        public bool placaAut;
        public string cstProduto, CRT, tipoCSOSN = "";
        public string cpfCnpjCliente, versao, ppis, msg = "";
        public string cnpjEmitente, ieEmitente = "";
        public string CabecalhoCupom = "";
        public string CorpoVendaCupom = "";
        public string esquerda, direita, centrarlizar = "";

        #endregion

        #region CLASSES E OBJETOS

        SangriaC sangriaC = new SangriaC();
        SangriaRegraNegocios sangriaRegraNegocios = new SangriaRegraNegocios();

        ElginImpressora ElginImpressora = new ElginImpressora();

        VendaRegraNegocios vendaRegraNegocios;

        BEMATECH bematechRegraNegocios;
        ParametroRegraNegocios parametroRegraNegocios;

        CABECALHO cabecalho;

        ESCPOS escPos;

        #endregion

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Sangria();
        }

        public void PesquisarParametro()
        {
            try
            {
                parametroRegraNegocios = new ParametroRegraNegocios();
                DataTable dadosTabelaParametro = new DataTable();
                dadosTabelaParametro = parametroRegraNegocios.Listar();
                cabecalho = new CABECALHO();

                if (dadosTabelaParametro.Rows.Count > 0)
                {
                    //limiteCompra = Convert.ToDecimal(dadosTabelaParametro.Rows[0]["LIMITE_VENDA"].ToString());
                    qtdeCupom = Convert.ToInt32(dadosTabelaParametro.Rows[0]["QTDE_CUPOM"].ToString());
                    //  vendaXml = Convert.ToBoolean(dadosTabelaParametro.Rows[0]["VENDA_XML"].ToString());
                    //  PagamentoVendaXml = Convert.ToBoolean(dadosTabelaParametro.Rows[0]["PAGTO_VENDA_XML"].ToString());
                    //placa = Convert.ToBoolean(dadosTabelaParametro.Rows[0]["PLACA"].ToString());
                    msg = dadosTabelaParametro.Rows[0]["MSG"].ToString().Trim();
                    //cupomFiscal = Convert.ToBoolean(dadosTabelaParametro.Rows[0]["CUPOM_IMAGEM"].ToString());
                    //timeDesc = Convert.ToInt32(dadosTabelaParametro.Rows[0]["TIME_TELA_DESC"].ToString());
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
                    cabecalho.nCFe = "";
                    cabecalho.CnpjCliente = dadosTabelaParametro.Rows[0]["CNPJ"].ToString().Trim();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção");
            }
        }

        public void Sangria()
        {
            try
            {
                if (valorT > 0)
                {
                    tipo = Convert.ToBoolean(cbxSangria.Checked);

                    if (idUsuario <= 0)
                    {
                        MessageBox.Show("Usaurio não Pode ser Menor ou Igual a Zero", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtValorSangria.Focus();
                    }
                    else if (txtValorSangria.Text.Trim().Equals(""))
                    {
                        MessageBox.Show("Campo Valor não Pode ser Nulo ou Vázio", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtValorSangria.Focus();
                    }
                    else if (txtMotivoSangria.Text.Trim().Equals(""))
                    {
                        MessageBox.Show("Campo Descrição não Pode ser Nulo ou Vázio", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtMotivoSangria.Focus();
                    }
                    else if (numCaixa <= 0)
                    {
                        MessageBox.Show("Numero do Caixa não Pode ser Menor ou Igual a Zero", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtValorSangria.Focus();
                    }
                    else
                    {
                        sangriaC = new SangriaC();
                        sangriaRegraNegocios = new SangriaRegraNegocios();

                        sangriaC.idUsuario = idUsuario;
                        sangriaC.valor = Convert.ToDecimal(txtValorSangria.Text);
                        sangriaC.descricao = txtMotivoSangria.Text;
                        sangriaC.data = data;
                        sangriaC.numCaixa = numCaixa;
                        sangriaC.tipo = tipo;
                        sangriaC.fechado = false;

                        string idRetorno = sangriaRegraNegocios.CadastrarSangriaDespesas(sangriaC);

                        try
                        {
                            int idRet = Convert.ToInt32(idRetorno);

                            MontarCupomSangria();

                            if (tipo == true)
                            {
                                MessageBox.Show("Sangria foi Realizado com Sucesso.!!!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                LimparCampos();
                            }
                            else
                            {
                                MessageBox.Show("Despesa foi Realizado com Sucesso.!!!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LimparCampos();
                                this.Close();
                            }
                        }
                        catch
                        {
                            if (tipo == true)
                            {
                                MessageBox.Show("Erro ao Realizar Sangria", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                LimparCampos();
                            }
                            else
                            {
                                MessageBox.Show("Erro ao Realizar Despesa", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LimparCampos();
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Saldo no Caixa Insuficiente para Realizar uma Sangria.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LimparCampos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção");
            }
        }

        public void LimparCampos()
        {
            txtValorSangria.Text = "0,00";
            txtValorSangria.Focus();
            txtMotivoSangria.Text = "";
        }

        private void frmSangriaDespesas_Load(object sender, EventArgs e)
        {
            ContadorLinhaSangria();

            PesquisarParametro();

            PesquisarVendaDinheiro();

            idUsuario = frmVenda.idUsuario;
            numCaixa = frmVenda.numCaixa;
            nomeImpressora = frmVenda.nomeImpressora;
            qtdeCupom = frmVenda.qtdeCupom;
        }

        public void PesquisarVendaDinheiro()
        {
            DataTable dadosTabela = new DataTable();
            vendaRegraNegocios = new VendaRegraNegocios();

            dadosTabela = vendaRegraNegocios.PesquisarVendaDinheiro(frmVenda.numCaixa);

            if (dadosTabela.Rows.Count > 0)
            {
                valorT = Convert.ToDecimal(dadosTabela.Rows[0]["TOTAL"].ToString());
            }
        }

        public static void Moeda(ref TextBox txtValorSangria)
        {
            string n = string.Empty;

            decimal v = 0;

            try
            {
                n = txtValorSangria.Text.Replace(",", "").Replace(".", "");

                if (n.Equals(""))
                    n = "";
                n = n.PadLeft(3, '0');
                if (n.Length > 3 & n.Substring(0, 1) == "0")
                    n = n.Substring(1, n.Length - 1);
                v = Convert.ToDecimal(n) / 100;

                txtValorSangria.Text = string.Format("{0:N}", v);
                txtValorSangria.SelectionStart = txtValorSangria.Text.Length;
            }
            catch (Exception)
            {
                MessageBox.Show("Error no Método Moeda.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void txtValorSangria_TextChanged(object sender, EventArgs e)
        {
            Moeda(ref txtValorSangria);
        }

        private void txtValorSangria_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Escape)
            {
                btnSair_Click(sender, e);
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void ContadorLinhaSangria()
        {
            try
            {
                sangriaC = new SangriaC();
                sangriaRegraNegocios = new SangriaRegraNegocios();
                DataTable dadosTabela = new DataTable();

                data = DateTime.Now;

                if (cbxSangria.Checked == true)
                {
                    tipo = true;
                }
                else if (cbxSangria.Checked == false)
                {
                    tipo = false;
                }

                sangriaC.idUsuario = frmVenda.idUsuario;
                sangriaC.fechado = false;
                sangriaC.numCaixa = frmVenda.numCaixa;
                sangriaC.tipo = tipo;

                dadosTabela = sangriaRegraNegocios.PesquisarSomaTotalDia(sangriaC);

                if (dadosTabela.Rows.Count > 0)
                {
                    contador = (Convert.ToInt32(dadosTabela.Rows.Count) + 1);
                    lblQtde.Text = contador.ToString().Trim().PadLeft(2, '0');
                }
                else
                {
                    lblQtde.Text = "01";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção");
            }
        }

        private void txtMotivoSangria_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                btnSalvar_Click(sender, e);
            }
        }

        private void txtValorSangria_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtMotivoSangria.Focus();
            }
        }

        private void cbxSangria_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxSangria.Checked == true)
            {
                cbxSangria.Text = "Sangria";
                gpSangria.Text = "Motivo da Sangria";
                txtMotivoSangria.Focus();
                tipo = true;
                ContadorLinhaSangria();
                descricao = "Sangria";
                lblValor.Text = "Valor Sangria";
            }
            else
            {
                cbxSangria.Text = "Despesas";
                gpSangria.Text = "Motivo da Despesa";
                txtMotivoSangria.Focus();
                tipo = false;
                ContadorLinhaSangria();
                descricao = "Despesas";
                lblValor.Text = "Valor Despesa";
            }
        }

        public void MontarCupomSangria()
        {
            try
            {
                if (cbxSangria.Checked == true)
                {
                    descricao = "SANGRIA";
                }
                else
                {
                    descricao = "DESPESAS";
                }

                sangriaC = new SangriaC();

                sangriaC.descricao = descricao;
                sangriaC.Qtde = Convert.ToInt32(lblQtde.Text);
                sangriaC.valor = Convert.ToDecimal(txtValorSangria.Text.Trim());
                sangriaC.Motivo = txtMotivoSangria.Text.Trim();
                sangriaC.nomeUsuario = frmVenda.nomeOperador.Trim();
                sangriaC.numCaixa = numCaixa;

                for (int i = 0; i < qtdeCupom; i++)
                {
                    if (nomeImpressora.Trim().Equals("BEMASAT") || (nomeImpressora.Trim().Equals("BEMATECH")))
                    {
                        bematechRegraNegocios = new BEMATECH();

                        CabecalhoCupom = bematechRegraNegocios.CabecalhoDadosEmpresa(cabecalho);
                        CorpoVendaCupom = bematechRegraNegocios.DespesaSangria(sangriaC);

                        cupomSangria = (CabecalhoCupom + CorpoVendaCupom);

                        idRetorno = IMPRESSORA.BemasatImpressora.ConfiguraModeloImpressora(7);
                        idRetorno = IMPRESSORA.BemasatImpressora.IniciaPorta(frmVenda.numComimp);

                        esquerda = "" + (char)27 + (char)97 + (char)0;
                        centrarlizar = "" + (char)27 + (char)97 + (char)1;
                        direita = "" + (char)27 + (char)97 + (char)2;

                        idRetorno = IMPRESSORA.BemasatImpressora.ComandoTX(esquerda, esquerda.Length);
                        idRetorno = IMPRESSORA.BemasatImpressora.FormataTX(cupomSangria + (char)10 + (char)13, 1, 0, 0, 0, 0);

                        //FECHAR CUPOM
                        IMPRESSORA.BemasatImpressora.AcionaGuilhotina(0);
                        idRetorno = IMPRESSORA.BemasatImpressora.FechaPorta();
                    }
                    //else if (nomeImpressora == "ELGIN")
                    //{
                    //    string dadoSangriaElgin = "";

                    //    var configImpressora = new PrinterSettings();
                    //    string printerName = configImpressora.PrinterName;

                    //    //  frmVenda.AbreCupomSegViaBemasat();
                    //    string cabecalhoElgin = "";

                    //    ElginImpressora = new ElginImpressora();

                    //    this.ElginImpressora.normalModeText(printerName);
                    //    this.ElginImpressora.printText(printerName, cabecalhoElgin + "\n");

                    //    dadoSangriaElgin = (descricao.ToString() + ": " + lblQtde.Text + " ......................." + valorT.ToString("C2") + "\n" +
                    //                        "MOTIVO: " + txtMotivoSangria.Text + "\n" +
                    //                        "OPERADOR: " + frmVenda.nomeOperador.ToString() + "\n" +
                    //                        "Ass: ________________________________");

                    //    ElginImpressora = new ElginImpressora();
                    //    this.ElginImpressora.printText(printerName, dadoSangriaElgin);
                    //    //this.esc.printBarcodeB(printerName, "{A012345678901234567", 73);

                    //    this.ElginImpressora.lineFeed(printerName, 2);
                    //    feedAndCutter(printerName, 5);
                    //}
                    else if (nomeImpressora == "DARUMA")
                    {
                        idRetorno = IMPRESSORA.DarumaImpressora.iImprimirTexto_DUAL_DarumaFramework(data + "</c><sl>4</sl><gui></gui><l></l>", 0);
                    }
                    else if (nomeImpressora == "EPSON")
                    {
                        escPos = new ESCPOS();

                        CabecalhoCupom = escPos.CabecalhoDadosEmpresa(cabecalho);
                        CorpoVendaCupom = escPos.DespesaSangria(sangriaC);

                        cupomSangria = (CabecalhoCupom + CorpoVendaCupom);
                    }
                    else if (nomeImpressora.Trim().Equals("ESCPOS") || (frmVenda.nomeImpressora.Trim().Equals("ELGIN")))
                    {
                        escPos = new ESCPOS();

                        CabecalhoCupom = escPos.CabecalhoDadosEmpresa(cabecalho);
                        CorpoVendaCupom = escPos.DespesaSangria(sangriaC);

                        cupomSangria = (CabecalhoCupom + CorpoVendaCupom);

                        var printer = new Printer(frmVenda.nomeImpressoraPadrao, frmVenda.ObterTipo());

                        printer.Imprimirrelatorio(cupomSangria);

                        printer.NewLines(3);

                        printer.PartialPaperCut();

                        printer.PrintDocument();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção");
            }
        }

        //linefeed and paper cutter
        public void feedAndCutter(string printerName, int numLines)
        {
            System.Threading.Thread.Sleep(500);
            this.ElginImpressora.lineFeed(printerName, numLines);
            this.ElginImpressora.CutPaper(printerName);
        }
    }
}
