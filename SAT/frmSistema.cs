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

namespace SAT
{
    public partial class frmSistema : Form
    {
        frmVenda frmVenda;

        public frmSistema(frmVenda frmVenda)
        {
            InitializeComponent();

            this.frmVenda = frmVenda;
            this.numCaixa = frmVenda.numCaixa;
        }

        #region CLASSES E OBJETOS

        ParametroC parametroC = new ParametroC();
        ParametroRegraNegocios parametroRegraNegocios = new ParametroRegraNegocios();

        #endregion

        #region VARIAVEIS

        bool placa, homologacao, imagem, vendaXml, PgtoVenda, imprimirCupom;
        decimal qtdeCupom = 0;
        int timeTela = 0;
        public int numCaixa = 0;

        #endregion

        private void frmSistema_Load(object sender, EventArgs e)
        {
            PesquisarParametro();
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
                    placa = Convert.ToBoolean(dadosTabelaParametro.Rows[0]["PLACA"].ToString());
                    homologacao = Convert.ToBoolean(dadosTabelaParametro.Rows[0]["HOMOLOGACAO_TESTE"].ToString());
                    imagem = Convert.ToBoolean(dadosTabelaParametro.Rows[0]["CUPOM_IMAGEM"].ToString());
                    qtdeCupom = Convert.ToDecimal(dadosTabelaParametro.Rows[0]["QTDE_CUPOM"].ToString());
                    vendaXml = Convert.ToBoolean(dadosTabelaParametro.Rows[0]["VENDA_XML"].ToString());
                    PgtoVenda = Convert.ToBoolean(dadosTabelaParametro.Rows[0]["PAGTO_VENDA_XML"].ToString());
                    timeTela = Convert.ToInt32(dadosTabelaParametro.Rows[0]["TIME_TELA_DESC"].ToString());

                    //PLACA
                    if (placa == true)
                    {
                        cbxPlaca.Checked = true;
                    }
                    else
                    {
                        cbxPlaca.Checked = false;
                    }

                    //HOMOLOGAÇAO
                    if (homologacao == true)
                    {
                        cbxHomologacao.Checked = true;
                    }
                    else
                    {
                        cbxHomologacao.Checked = false;
                    }

                    //CUPOM IMAGEM
                    if (imagem == true)
                    {
                        cbxCupomImagem.Checked = true;
                    }
                    else
                    {
                        cbxCupomImagem.Checked = false;
                    }

                    //VENDA XML
                    if (vendaXml == true)
                    {
                        cbxSalvarVendaXml.Checked = true;
                    }
                    else
                    {
                        cbxSalvarVendaXml.Checked = false;
                    }

                    //PAGAMENTO VENDA XML
                    if (PgtoVenda == true)
                    {
                        cbxPgtoVendaXml.Checked = true;
                    }
                    else
                    {
                        cbxPgtoVendaXml.Checked = false;
                    }

                    txtMilsegundos.Text = timeTela.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção");
            }
        }

        private void btnManter_Click(object sender, EventArgs e)
        {
            AlterarServicos();
        }

        private void cbxPgtoVendaXml_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxPgtoVendaXml.Checked == true)
            {
                cbxPgtoVendaXml.Text = "Sim";
            }
            else
            {
                cbxPgtoVendaXml.Text = "Não";
            }
        }

        private void cbxSalvarVendaXml_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxPlaca.Checked == true)
            {
                cbxSalvarVendaXml.Text = "Sim";
            }
            else
            {
                cbxSalvarVendaXml.Text = "Não";
            }
        }

        public void AlterarServicos()
        {
            try
            {
                if (MessageBox.Show("Realmente Deseja Alterar Configurações do Serviço.", "Alterar Serviço", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    parametroC = new ParametroC();
                    parametroRegraNegocios = new ParametroRegraNegocios();

                    //PLACA
                    if (cbxPlaca.Checked == true)
                    {
                        placa = true;
                    }
                    else
                    {
                        placa = false;
                    }

                    //HOMOLOGAÇAO
                    if (cbxHomologacao.Checked == true)
                    {
                        homologacao = true;
                    }
                    else
                    {
                        homologacao = false;
                    }

                    //CUPOM IMAGEM
                    if (cbxCupomImagem.Checked == true)
                    {
                        imagem = true;
                    }
                    else
                    {
                        imagem = false;
                    }

                    //VENDA XML
                    if (cbxSalvarVendaXml.Checked == true)
                    {
                        vendaXml = true;
                    }
                    else
                    {
                        vendaXml = false;
                    }

                    //PAGEMNTO VENDA XML

                    if (cbxPgtoVendaXml.Checked == true)
                    {
                        PgtoVenda = true;
                    }
                    else
                    {
                        PgtoVenda = false;
                    }

                    parametroC.cupomImagem = imagem;
                    parametroC.homologacaoTeste = homologacao;
                    parametroC.placa = placa;
                    parametroC.idParametro = 1;
                    parametroC.vendaXml = vendaXml;
                    parametroC.pgtoVendaXml = PgtoVenda;
                    parametroC.timeTelaDesc = Convert.ToInt32(txtMilsegundos.Text);
                    parametroC.Numcaixa = numCaixa;

                    string idRetorno = parametroRegraNegocios.AlterarServicos(parametroC);

                    try
                    {
                        int idRet = Convert.ToInt32(idRetorno);
                        MessageBox.Show("Serviço Desejado foi Alterado com Sucesso.", "Alteração com Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        PesquisarParametro();
                    }
                    catch
                    {
                        MessageBox.Show("Erro ao Alterar Serviço", "Erro na Alteração", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void cbxPlaca_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxPlaca.Checked == true)
            {
                cbxPlaca.Text = "Sim";
            }
            else
            {
                cbxPlaca.Text = "Não";
            }
        }

        private void cbxHomologacao_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxHomologacao.Checked == true)
            {
                cbxHomologacao.Text = "Sim";
            }
            else
            {
                cbxHomologacao.Text = "Não";
            }
        }

        private void cbxCupomImagem_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxCupomImagem.Checked == true)
            {
                cbxCupomImagem.Text = "Sim";
            }
            else
            {
                cbxCupomImagem.Text = "Não";
            }
        }
    }
}

