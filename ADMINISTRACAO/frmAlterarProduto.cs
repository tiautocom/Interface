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

namespace ADMINISTRACAO
{
    public partial class frmAlterarProduto : Form
    {
        frmPrincipal frmPrincipal;

        public frmAlterarProduto(frmPrincipal fPrincipal, int idProduto)
        {
            InitializeComponent();

            this.frmPrincipal = fPrincipal;
            this.idProduto = idProduto;
        }

        ProdutoRegraNegocios produtoRegraNegocios;
        UnidadeRegraNegocios unidadeRegraNegocios;
        DepartamentoRegraNegocios departamentoRegraNegocios;
        SetorRegraNegocios setorRegraNegocios;
        ProdutoC produto;
        FILTRAR filtrar;

        public int idProduto = 0;

        private void frmAlterarProduto_Load(object sender, EventArgs e)
        {
            LoadTela();
        }

        public void PesquisarProdutoId()
        {
            try
            {
                produtoRegraNegocios = new ProdutoRegraNegocios();
                DataTable dadosTabela = new DataTable();

                dadosTabela = produtoRegraNegocios.PesquisarProdutoId(idProduto);

                if (dadosTabela.Rows.Count > 0)
                {
                    txtId.Text = dadosTabela.Rows[0]["COD_INT"].ToString().PadLeft(5, '0').Trim();
                    txtCodBarra.Text = dadosTabela.Rows[0]["COD_BARRA"].ToString().Trim();
                    txtGtin.Text = dadosTabela.Rows[0]["GTIN"].ToString().Trim();
                    txtDescricao.Text = dadosTabela.Rows[0]["DESCRICAO"].ToString().Trim();
                    cbxDescAutomatico.Checked = Convert.ToBoolean(dadosTabela.Rows[0]["DESC_AUTO"].ToString().Trim());
                    cbGranel.Text = dadosTabela.Rows[0]["GRANEL"].ToString().Trim();
                    cbSetor.Text = dadosTabela.Rows[0]["SETOR"].ToString().Trim();
                    cbUnidade.Text = dadosTabela.Rows[0]["UNID"].ToString().Trim();
                    cbTrib.Text = dadosTabela.Rows[0]["TRIB"].ToString().Trim();
                    cbDepartamento.Text = dadosTabela.Rows[0]["DEPARTAM"].ToString().Trim();
                    txtNumDep.Text = dadosTabela.Rows[0]["NUM_DEPAR"].ToString().Trim();
                    txtValidade.Text = dadosTabela.Rows[0]["VALIDADE"].ToString().Trim();
                    // txtQtdeAutomatico.Text = dadosTabela.Rows[0][""].ToString().Trim();
                    txtCusto.Text = dadosTabela.Rows[0]["CUSTO"].ToString().Trim();

                    txtPreco.Text = dadosTabela.Rows[0]["PRECO"].ToString().Trim();
                    txtQtde.Text = dadosTabela.Rows[0]["QTDE_DESC"].ToString().Trim();
                    //  txtEstoqueMin.Text = dadosTabela.Rows[0]["ESTOQUE_MIN"].ToString().Trim();
                    txtEstoque.Text = dadosTabela.Rows[0]["ESTOQUE"].ToString().Trim();
                    // txtPrecoPromocao.Text = dadosTabela.Rows[0]["PRECO_PROMOCAO"].ToString().Trim();

                    try
                    {
                        txtPercentagem.Text = dadosTabela.Rows[0]["PORCENTEGEM"].ToString().Trim();
                    }
                    catch
                    {
                        txtPercentagem.Text = "0,00";
                    }

                    ListarOrigem(dadosTabela.Rows[0]["ORIGEM_PRODUTO"].ToString().Trim());
                    ListarCstIcmsProduto(dadosTabela.Rows[0]["ICMS_CST"].ToString().Trim());
                    ListarCstCofinsProduto(dadosTabela.Rows[0]["CST_COFINS"].ToString().Trim());
                    ListarCstPisProduto(dadosTabela.Rows[0]["CST_PIS"].ToString().Trim());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ListarCstPisProduto(string cstPis)
        {
            if (cstPis.Trim().Equals(""))
            {

            }
        }

        public void ListarOrigem(string origem)
        {
            if (origem.Trim().Equals("0"))
            {
                cbOrigem.Text = "0 - Nacional: exceto as indicadas nos códigos 3, 4, 5 e 8.";
            }
            else if (origem.Trim().Equals("1"))
            {
                cbOrigem.Text = "1 - Estrangeira: importação direta, exceto a indicada no código 6.";
            }
            else if (origem.Trim().Equals("2"))
            {
                cbOrigem.Text = "2 - Estrangeira: adquirida no mercado interno, exceto a indicada no código 7.";
            }
            else if (origem.Trim().Equals("3"))
            {
                cbOrigem.Text = "3 - Nacional: mercadoria ou bem com conteúdo de importação superior a 40% e inferior ou igual a 70%.";
            }
            else if (origem.Trim().Equals("4"))
            {
                cbOrigem.Text = "4 - Nacional: cuja produção tenha sido feita em conformidade com os processos produtivos básicos de que tratam o Decreto-Lei nº 288/1967, e as Leis nº 8.248/1991, 8.387/1991, 10.176/2001 e 11.484/2007.";
            }
            else if (origem.Trim().Equals("5"))
            {
                cbOrigem.Text = "5 - Nacional: mercadoria ou bem com Conteúdo de Importação inferior ou igual a 40%.";
            }
            else if (origem.Trim().Equals("6"))
            {
                cbOrigem.Text = "6 - Estrangeira: importação direta, sem similar nacional, constante em lista de Resolução Camex e gás natural.";
            }
            else if (origem.Trim().Equals("7"))
            {
                cbOrigem.Text = "7 - Estrangeira: adquirida no mercado interno, sem similar nacional, constante em lista de Resolução Camex e gás natural.";
            }
            else if (origem.Trim().Equals("8"))
            {
                cbOrigem.Text = "8 - Nacional: mercadoria ou bem com Conteúdo de Importação superior a 70%.";
            }
        }

        public void ListarCstIcmsProduto(string cstIcms)
        {
            if (cstIcms.Trim().Equals("00"))
            {
                cbCstIcms.Text = "00 - Tributada integralmente";
            }
            else if (cstIcms.Trim().Equals("10"))
            {
                cbCstIcms.Text = "10 - Tributada e com cobrança do ICMS por substituição tributária";
            }
            else if (cstIcms.Trim().Equals("20"))
            {
                cbCstIcms.Text = "20 - Com redução de base de cálculo";
            }
            else if (cstIcms.Trim().Equals("30"))
            {
                cbCstIcms.Text = "30 - Isenta ou não tributada e com cobrança do ICMS por substituição tributária";
            }
            else if (cstIcms.Trim().Equals("40"))
            {
                cbCstIcms.Text = "40 - Isenta";
            }
            else if (cstIcms.Trim().Equals("41"))
            {
                cbCstIcms.Text = "41 - Não tributada";
            }
            else if (cstIcms.Trim().Equals("50"))
            {
                cbCstIcms.Text = "50 - Suspensão";
            }
            else if (cstIcms.Trim().Equals("51"))
            {
                cbCstIcms.Text = "51 - Diferimento";
            }
            else if (cstIcms.Trim().Equals("60"))
            {
                cbCstIcms.Text = "60 - ICMS cobrado anteriormente por substituição tributária";
            }
            else if (cstIcms.Trim().Equals("70"))
            {
                cbCstIcms.Text = "70 - Com redução de base de cálculo e cobrança do ICMS por substituição tributária";
            }
            else if (cstIcms.Trim().Equals("90"))
            {
                cbCstIcms.Text = "90 - Outras.";
            }
        }

        public void ListarCstCofinsProduto(string cstCofins)
        {
            if (cstCofins.Trim().Equals("01"))
            {
                cbCofins.Text = "01 - Operação Tributável com Alíquota Básica";
            }
            else if (cstCofins.Trim().Equals("02"))
            {
                cbCofins.Text = "02 - Operação Tributável com Alíquota Diferenciada";
            }
            else if (cstCofins.Trim().Equals("03"))
            {
                cbCofins.Text = "03 - Operação Tributável com Alíquota por Unidade de Medida de Produto";
            }
            else if (cstCofins.Trim().Equals("04"))
            {
                cbCofins.Text = "04 - Operação Tributável Monofásica -Revenda a Alíquota Zero";
            }
            else if (cstCofins.Trim().Equals("05"))
            {
                cbCofins.Text = "05 - Operação Tributável por Substituição Tributária";
            }
            else if (cstCofins.Trim().Equals("06"))
            {
                cbCofins.Text = "06 - Operação Tributável a Alíquota Zero";
            }
            else if (cstCofins.Trim().Equals("07"))
            {
                cbCofins.Text = "07 - Operação Isenta da Contribuição";
            }
            else if (cstCofins.Trim().Equals("08"))
            {
                cbCofins.Text = "08 - Operação sem Incidência da Contribuição";
            }
            else if (cstCofins.Trim().Equals("09"))
            {
                cbCofins.Text = "09 - Operação com Suspensão da Contribuição";
            }
            else if (cstCofins.Trim().Equals("49"))
            {
                cbCofins.Text = "49 - Outras Operações de Saída";
            }
            else if (cstCofins.Trim().Equals("50"))
            {
                cbCofins.Text = "50 - Operação com Direito a Crédito -Vinculada Exclusivamente a Receita Tributada no Mercado Interno";
            }
            else if (cstCofins.Trim().Equals("51"))
            {
                cbCofins.Text = "51 - Operação com Direito a Crédito -Vinculada Exclusivamente a Receita Não-Tributada no Mercado Interno";
            }
            else if (cstCofins.Trim().Equals("52"))
            {
                cbCofins.Text = "52 - Operação com Direito a Crédito -Vinculada Exclusivamente a Receita de Exportação";
            }
            else if (cstCofins.Trim().Equals("53"))
            {
                cbCofins.Text = "53 - Operação com Direito a Crédito -Vinculada a Receitas Tributadas e Não - Tributadas no Mercado Interno";
            }
            else if (cstCofins.Trim().Equals("54"))
            {
                cbCofins.Text = "54 - Operação com Direito a Crédito -Vinculada a Receitas Tributadas no Mercado Interno e de Exportação";
            }
            else if (cstCofins.Trim().Equals("55"))
            {
                cbCofins.Text = "55 - Operação com Direito a Crédito -Vinculada a Receitas Não Tributadas no Mercado Interno e de Exportação";
            }
            else if (cstCofins.Trim().Equals("56"))
            {
                cbCofins.Text = "56 - Operação com Direito a Crédito -Vinculada a Receitas Tributadas e Não - Tributadas no Mercado Interno e de Exportação";
            }
            else if (cstCofins.Trim().Equals("60"))
            {
                cbCofins.Text = "60 - Crédito Presumido - Operação de Aquisição Vinculada Exclusivamente a Receita Tributada no Mercado Interno";
            }
            else if (cstCofins.Trim().Equals("61"))
            {
                cbCofins.Text = "61 - Crédito Presumido - Operação de Aquisição Vinculada Exclusivamente a Receita Não - Tributada no Mercado Interno";
            }
            else if (cstCofins.Trim().Equals("62"))
            {
                cbCofins.Text = "62 - Crédito Presumido - Operação de Aquisição Vinculada Exclusivamente a Receita de Exportação";
            }
            else if (cstCofins.Trim().Equals("63"))
            {
                cbCofins.Text = "63 - Crédito Presumido - Operação de Aquisição Vinculada a Receitas Tributadas e Não-Tributadas no Mercado Interno";
            }
            else if (cstCofins.Trim().Equals("64"))
            {
                cbCofins.Text = "64 - Crédito Presumido - Operação de Aquisição Vinculada a Receitas Tributadas no Mercado Interno e de Exportação";
            }
            else if (cstCofins.Trim().Equals("65"))
            {
                cbCofins.Text = "65 - Crédito Presumido - Operação de Aquisição Vinculada a Receitas Não-Tributadas no Mercado Interno e de Exportação";
            }
            else if (cstCofins.Trim().Equals("66"))
            {
                cbCofins.Text = "66 - Crédito Presumido - Operação de Aquisição Vinculada a Receitas Tributadas e Não-Tributadas no Mercado Interno e de Exportação";
            }
            else if (cstCofins.Trim().Equals("67"))
            {
                cbCofins.Text = "67 - Crédito Presumido - Outras Operações";
            }
            else if (cstCofins.Trim().Equals("70"))
            {
                cbCofins.Text = "70 - Operação de Aquisição sem Direito a Crédito";
            }
            else if (cstCofins.Trim().Equals("71"))
            {
                cbCofins.Text = "71 - Operação de Aquisição com Isenção";
            }
            else if (cstCofins.Trim().Equals("72"))
            {
                cbCofins.Text = "72 - Operação de Aquisição com Suspensão";
            }
            else if (cstCofins.Trim().Equals("73"))
            {
                cbCofins.Text = "73 - Operação de Aquisição a Alíquota Zero";
            }
            else if (cstCofins.Trim().Equals("74"))
            {
                cbCofins.Text = "74 - Operação de Aquisição sem Incidência da Contribuição";
            }
            else if (cstCofins.Trim().Equals("74"))
            {
                cbCofins.Text = "74 - Operação de Aquisição sem Incidência da Contribuição";
            }
            else if (cstCofins.Trim().Equals("75"))
            {
                cbCofins.Text = "75 - Operação de Aquisição por Substituição Tributária";
            }
            else if (cstCofins.Trim().Equals("98"))
            {
                cbCofins.Text = "98 - Outras Operações de Entrada";
            }
            else if (cstCofins.Trim().Equals("99"))
            {
                cbCofins.Text = "99 - Outras Operações";
            }
        }

        public void LoadTela()
        {
            Limpar();

            ListarUnidade();
            ListarSetor();
            ListarDepartementos();

            PesquisarProdutoId();
        }

        private void ListarDepartementos()
        {
            try
            {
                DataTable dadosTabela = new DataTable();
                departamentoRegraNegocios = new DepartamentoRegraNegocios();

                dadosTabela = departamentoRegraNegocios.Listar(txtDescricao.Text.Trim());

                if (dadosTabela.Rows.Count > 0)
                {
                    cbDepartamento.DataSource = null;
                    cbDepartamento.DataSource = dadosTabela;
                    cbDepartamento.DisplayMember = "DESCRICAO";
                    cbDepartamento.ValueMember = "ID";
                }
                else
                {
                    cbDepartamento.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void ListarSetor()
        {
            try
            {
                DataTable dadosTabela = new DataTable();
                setorRegraNegocios = new SetorRegraNegocios();

                dadosTabela = setorRegraNegocios.Listar(txtDescricao.Text.Trim());

                if (dadosTabela.Rows.Count > 0)
                {
                    cbSetor.DataSource = null;
                    cbSetor.DataSource = dadosTabela;
                    cbSetor.DisplayMember = "DESCRICAO";
                    cbSetor.ValueMember = "ID";
                }
                else
                {
                    cbSetor.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void ListarUnidade()
        {
            try
            {
                unidadeRegraNegocios = new UnidadeRegraNegocios();
                DataTable dadosTabela = new DataTable();

                dadosTabela = unidadeRegraNegocios.Listar(txtDescricao.Text.Trim());

                if (dadosTabela.Rows.Count > 0)
                {
                    cbUnidade.DataSource = null;
                    cbUnidade.DataSource = dadosTabela;
                    cbUnidade.DisplayMember = "DESCRICAO";
                    cbUnidade.ValueMember = "ID";
                }
                else
                {
                    cbUnidade.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void Limpar()
        {
            txtCodBarra.Text = "";
            txtGtin.Text = "";
            txtDescricao.Text = "";
            cbGranel.Text = "";
            cbSetor.Text = "";
            cbUnidade.Text = "";
            cbTrib.Text = "";
            cbDepartamento.Text = "";
            txtNumDep.Text = "";
            txtValidade.Text = "000";
            txtQtdeAutomatico.Text = "0,00";
            txtCusto.Text = "0,00";
            txtPercentagem.Text = "0,00";
            txtPreco.Text = "0,00";
            txtQtde.Text = "0,00";
            txtEstoqueMin.Text = "0,00";
            txtEstoque.Text = "0,00";
            txtPrecoPromocao.Text = "0,00";
            cbOrigem.Text = "";
            cbCofins.Text = "";
            //cbNatOperacao.Text = "";
            cbCstIcms.Text = "";
            cbCstPis.Text = "";
            cbCstIpi.Text = "";
            cbModRedBC.Text = "";
            cbCfop.Text = "5102";
            cbNcm.Text = "";
            txtCest.Text = "";
            txtPercIpi.Text = "0,00";
            txtPercRedBC.Text = "0,00";
            txtPercCofins.Text = "0,00";
            txtPercPis.Text = "0,00";
            cbTrib.Text = "";
            cbCfop.Text = "";
            lblUltimaAlt.Text = DateTime.Now.ToString("dd/MM/yyyy");

            txtCodBarra.Focus();
            txtCodBarra.SelectAll();

            cbxDescAutomatico.Checked = false;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {

        }

        public void CadastrarProduto(EventArgs e)
        {
            try
            {
                if (txtCodBarra.Text.Trim().Equals(""))
                {
                    MessageBox.Show("Campo de Código de Barra não Pode ser Nulo ou Vazio..", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCodBarra.Focus();
                }
                else if (txtDescricao.Text.Trim().Equals(""))
                {
                    MessageBox.Show("Campo de Descrição não Pode ser Nulo ou Vazio..", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtDescricao.Focus();
                }

                else if (cbDepartamento.Text.Trim().Equals(""))
                {
                    MessageBox.Show("Campo de Departamento não Pode ser Nulo ou Vazio..", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbDepartamento.Focus();
                }

                else if (cbUnidade.Text.Trim().Equals(""))
                {
                    MessageBox.Show("Campo de Unidade não Pode ser Nulo ou Vazio..", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbUnidade.Focus();
                }
                else if (txtPreco.Text.Trim().Equals("0,00"))
                {
                    MessageBox.Show("Campo de Preço não Pode ser Nulo ou Vazio..", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPreco.Focus();
                }

                else if (txtCusto.Text.Trim().Equals("0,00"))
                {
                    MessageBox.Show("Campo de Custo não Pode ser Nulo ou Vazio..", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCusto.Focus();
                }
                else if (cbCstIcms.Text.Trim().Equals(""))
                {
                    MessageBox.Show("Campo de ICMS não Pode ser Nulo ou Vazio..", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbCstIcms.Focus();
                }

                else if (txtCest.Text.Trim().Equals(""))
                {
                    MessageBox.Show("Campo de CEST não Pode ser Nulo ou Vazio..", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCest.Focus();
                }
                else if (cbCstPis.Text.Trim().Equals(""))
                {
                    MessageBox.Show("Campo de PIS não Pode ser Nulo ou Vazio..", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbCstPis.Focus();
                }
                else if (cbCofins.Text.Trim().Equals(""))
                {
                    MessageBox.Show("Campo de COFINS não Pode ser Nulo ou Vazio..", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbCofins.Focus();
                }

                else if (cbNcm.Text.Trim().Equals(""))
                {
                    MessageBox.Show("Campo de CNCM não Pode ser Nulo ou Vazio..", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbNcm.Focus();
                }
                else if (cbCfop.Text.Trim().Equals(""))
                {
                    MessageBox.Show("Campo de CFOP não Pode ser Nulo ou Vazio..", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbCfop.Focus();
                }
                else if (cbSetor.Text.Trim().Equals(""))
                {
                    MessageBox.Show("Campo de Setor não Pode ser Nulo ou Vazio..", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbSetor.Focus();
                }
                else if (txtValidade.Text.Trim() == "")
                {
                    MessageBox.Show("Campo de Validade não Pode ser Nulo ou Vazio..", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtValidade.Focus();
                }
                else
                {
                    produto = new ProdutoC();

                    filtrar = new FILTRAR();

                    produtoRegraNegocios = new ProdutoRegraNegocios();

                    produto.idProduto = Convert.ToInt32(txtId.Text);
                    produto.codBarra = filtrar.RemoverCaracteres(txtCodBarra.Text.Trim());
                    produto.numDepartamento = Convert.ToInt32(cbDepartamento.SelectedValue);
                    produto.DepartamentoDesc = cbDepartamento.Text.Trim();
                    produto.descricao = filtrar.RemoverCaracteres(txtDescricao.Text.Trim());
                    produto.estoque = Convert.ToDecimal(txtEstoque.Text);
                    produto.preco = Convert.ToDecimal(txtPreco.Text);
                    produto.unid = cbUnidade.Text.Trim();
                    produto.custo = Convert.ToDecimal(txtCusto.Text);
                    produto.trib = cbTrib.Text.Trim();
                    produto.reducao = Convert.ToDecimal("0,00").ToString();
                    produto.desc = Convert.ToDecimal("0,00");
                    produto.estoqueMin = Convert.ToDecimal(txtEstoqueMin.Text);
                    produto.tecla = Convert.ToDecimal("0,00");
                    produto.granel = cbGranel.Text.Trim();
                    produto.descAuto = cbxDescAutomatico.Checked;
                    produto.qtdeDesc = Convert.ToDecimal(txtQtde.Text);
                    produto.atualiza = "";
                    produto.embal = Convert.ToDecimal("0,00");
                    produto.custoCaixa = Convert.ToDecimal("0,00");
                    produto.lixo = Convert.ToDecimal("0,00");
                    produto.dtAjuste = DateTime.Now;
                    produto.setor = Convert.ToDecimal(cbSetor.SelectedValue);
                    produto.validade = txtValidade.Text.Trim();
                    produto.vencimento = "";
                    produto.margem = Convert.ToDecimal("0,00");
                    produto.qtdeCom = Convert.ToDecimal("0,00");
                    produto.dtCom = "";
                    produto.percPis = Convert.ToDecimal(txtPercPis.Text);
                    produto.cstPis = cbCstPis.Text.Substring(0, 2).Trim();
                    produto.valorPis = cbCstPis.Text.Substring(0, 1).Trim();
                    produto.valorCofins = cbCofins.Text.Substring(0, 2).Trim();
                    produto.cstCofins = cbCofins.Text.Substring(0, 2).Trim();
                    produto.percCofins = Convert.ToDecimal(txtPercCofins.Text);
                    produto.cfop = cbCfop.Text.Trim();
                    produto.origemProduto = cbOrigem.Text.Substring(0, 1).Trim();
                    produto.icms = cbCstIcms.Text.Substring(0, 2).Trim();
                    produto.ncm = cbNcm.Text.Trim();
                    produto.cstIcms = cbCstIcms.Text.Substring(0, 2).Trim();
                    produto.cest = txtCest.Text.Trim();
                    produto.gTin = filtrar.RemoverCaracteres(txtGtin.Text.Trim());
                    produto.percIpi = Convert.ToDecimal(txtPercIpi.Text);

                    //produto.DepartamentoDesc = cbDepartamento.Text.Trim();
                    //produto.qtdeAutomatica = Convert.ToDecimal(txtQtdeAutomatico.Text);
                    //produto.precoPromocao = Convert.ToDecimal(txtPrecoPromocao.Text);
                    //produto.naturezaOperacao = cbNatOperacao.Text.Substring(0, 1).Trim();
                    //produto.cstIpi = cbCstPis.Text.Substring(0, 2).Trim();
                    //produto.modRedBC = cbModRedBC.Text.Substring(0, 1).Trim();
                    //produto.percIpi = Convert.ToDecimal(txtPercIpi.Text.Trim());
                    //produto.percRedBc = Convert.ToDecimal(txtPercRedBC.Text.Trim());

                    try
                    {
                        int idRet = Convert.ToInt32(produtoRegraNegocios.Salvar(produto, 2));

                        MessageBox.Show("Produto Cadastrado com Sucesso.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        this.OnLoad(e);
                    }
                    catch
                    {
                        MessageBox.Show("Erro ao salvar Novo Produto.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
