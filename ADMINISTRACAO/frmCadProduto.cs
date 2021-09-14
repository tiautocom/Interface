using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OBJETO_TRANSFERENCIA;
using REGRA_NEGOCIOS;

namespace ADMINISTRACAO
{
    public partial class frmCadProduto : Form
    {
        frmPrincipal frmPrincipal;

        public frmCadProduto(frmPrincipal fPrincipal)
        {
            InitializeComponent();

            this.frmPrincipal = fPrincipal;

            this.gdvProduto.AutoGenerateColumns = false;
        }

        public string cest = "";
        public int codBarras = 0;
        public int idProduto = 0;

        #region CLASSES  E OBJETOS

        ProdutoC produto;
        FILTRAR filtrar;
        ProdutoRegraNegocios produtoRegraNegocios;
        UnidadeRegraNegocios unidadeRegraNegocios;
        SetorRegraNegocios setorRegraNegocios;
        DepartamentoRegraNegocios departamentoRegraNegocios;

        #endregion

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

        public void LoadTela()
        {
            Limpar();
            ListarUnidade();
            ListarSetor();
            ListarDepartementos();

            PesquisarProdutos();
        }

        public void PesquisarCodigoBarras()
        {
            try
            {
                produtoRegraNegocios = new ProdutoRegraNegocios();
                DataTable dadosTabela = new DataTable();

                codBarras = produtoRegraNegocios.PesquisarCodigoBarras();

                txtCodBarra.Text = txtGtin.Text = (codBarras + 1).ToString().PadLeft(13, '0').Trim();
            }
            catch
            {
            }
        }

        public void PesquisarProdutos()
        {
            try
            {
                produtoRegraNegocios = new ProdutoRegraNegocios();
                DataTable dadosTabela = new DataTable();

                dadosTabela = produtoRegraNegocios.PesquisarProdutoNome(txtPesquisaProdutoDesc.Text.Trim());

                if (dadosTabela.Rows.Count > 0)
                {
                    gdvProduto.DataSource = null;
                    gdvProduto.DataSource = dadosTabela;
                }
                else
                {
                    gdvProduto.DataSource = null;
                }

                PesquisarCodigoBarras();

                lblqtdeProdutos.Text = gdvProduto.Rows.Count.ToString().PadLeft(7, '0').Trim();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Realmente Deseja Iniciar Novo Cadastros", "Novo Cadastro", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                this.OnLoad(e);
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

            PesquisarCodigoBarras();

            txtCodBarra.Focus();
            txtCodBarra.SelectAll();

            cbxDescAutomatico.Checked = false;
        }

        private void frmCadProduto_Load(object sender, EventArgs e)
        {
            LoadTela();
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

        private void btnPEsquisarProd_Click(object sender, EventArgs e)
        {
            Process.Start("chrome.exe", "https://www.comtel.pro.br/downloads/Tabela_CEST.pdf");
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            CadastrarProduto(e);
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
                n = n.PadLeft(5, '0');
                if (n.Length > 5 & n.Substring(0, 1) == "0")
                    n = n.Substring(1, n.Length - 1);
                v = Convert.ToDecimal(n) / 100;
                txt.Text = string.Format("{0:N2}", v);
                txt.SelectionStart = txt.Text.Length;
            }
            catch (Exception ex)
            {
                txt.Text = "";
                txt.Focus();
                MessageBox.Show(ex.Message + " Campo Aceita Somente Valores", "Registro do Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                        int idRet = Convert.ToInt32(produtoRegraNegocios.Salvar(produto, 1));

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

        private void txtCusto_TextChanged(object sender, EventArgs e)
        {
            Moeda(ref txtCusto);
        }

        private void txtPercentagem_TextChanged(object sender, EventArgs e)
        {
            Moeda(ref txtPercentagem);
        }

        private void txtPreco_TextChanged(object sender, EventArgs e)
        {
            Moeda(ref txtPreco);
        }

        private void txtQtde_TextChanged(object sender, EventArgs e)
        {
            Moeda(ref txtQtde);
        }

        private void txtEstoqueMin_TextChanged(object sender, EventArgs e)
        {
            Moeda(ref txtEstoqueMin);
        }

        private void txtEstoque_TextChanged(object sender, EventArgs e)
        {
            Moeda(ref txtEstoque);
        }

        private void txtPercIpi_TextChanged(object sender, EventArgs e)
        {
            Moeda(ref txtPercIpi);
        }

        private void txtPercRedBC_TextChanged(object sender, EventArgs e)
        {
            Moeda(ref txtPercRedBC);
        }

        private void txtPercCofins_TextChanged(object sender, EventArgs e)
        {
            Moeda(ref txtPercCofins);
        }

        private void txtPercPis_TextChanged(object sender, EventArgs e)
        {
            Moeda(ref txtPercPis);
        }

        private void btnAddNovoSetor_Click(object sender, EventArgs e)
        {
            frmCadSetor frmCadSetor = new frmCadSetor(frmPrincipal);
            frmCadSetor.ShowDialog();

            ListarSetor();
        }

        private void btnAddNovaUnidade_Click(object sender, EventArgs e)
        {
            frmCadUnidades frmCadUnidades = new frmCadUnidades(frmPrincipal);
            frmCadUnidades.ShowDialog();

            ListarUnidade();
        }

        private void btnAddNovoDepartamento_Click(object sender, EventArgs e)
        {
            frmCadDepartamentos frmCadDepartamentos = new frmCadDepartamentos(frmPrincipal);
            frmCadDepartamentos.ShowDialog();

            ListarDepartementos();
        }

        private void btnPesquisarCest_Click(object sender, EventArgs e)
        {
            Process.Start("chrome.exe", "https://cosmos.bluesoft.com.br/tabelas/cest");
        }

        private void btnPEsquisarCfop_Click(object sender, EventArgs e)
        {
            Process.Start("chrome.exe", "https://cosmos.bluesoft.com.br/tabelas/cfop");
        }

        private void btnPesquisarNcm_Click(object sender, EventArgs e)
        {
            Process.Start("chrome.exe", "https://cosmos.bluesoft.com.br/ncms");
        }

        private void btnCalcPercentagemPreco_Click(object sender, EventArgs e)
        {
            txtPreco.Text = CalcularPercentagemProduto();

            txtPercentagem.Focus();
            txtPercentagem.SelectAll();
        }

        public string CalcularPercentagemProduto()
        {
            try
            {
                decimal valorProdutoCusto = Convert.ToDecimal(txtCusto.Text);
                decimal percentagem = Convert.ToDecimal(txtPercentagem.Text);
                decimal soma = 0;

                if (percentagem > 0 || valorProdutoCusto > 0)
                {
                    soma = (valorProdutoCusto + ((valorProdutoCusto * percentagem) / 100));
                }

                return soma.ToString("N2");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro" + ex.Message + ": ao Calcular Percetagem Produto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return "0,00";
            }
        }

        public string CalcularMagemLucro()
        {
            try
            {
                decimal valorProdutoCusto = Convert.ToDecimal(txtCusto.Text);
                decimal valorProduto = Convert.ToDecimal(txtPreco.Text);
                decimal percentagem = Convert.ToDecimal(txtPercentagem.Text);
                decimal soma = 0;

                if (valorProdutoCusto > 0)
                {
                    soma = (((valorProduto / valorProdutoCusto) - 1) * 100);
                }
                else
                {
                    MessageBox.Show("Impossível Dividir por Zero.\nInforme Valor para Custo do Produto.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                return soma.ToString("N2");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao Calcular Percetagem Produto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return "0,00";
            }
        }

        private void txtPercentagem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnCalcPercentagemPreco_Click(sender, e);
            }
        }

        private void btnCalcularLucro_Click(object sender, EventArgs e)
        {
            txtPercentagem.Text = CalcularMagemLucro();

            txtPercentagem.Focus();
            txtPercentagem.SelectAll();
        }

        private void cbTrib_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTrib.Text.Trim().Contains("II"))
            {
                cbCstIcms.Text = "40 - Isenta";

                cbCfop.Text = "5102";
            }
            else if (cbTrib.Text.Trim().Contains("NN"))
            {
                cbCstIcms.Text = "41 - Não tributada";

                cbCfop.Text = "5102";
            }
            else if (cbTrib.Text.Trim().Contains("FF"))
            {
                cbCstIcms.Text = "60 - ICMS cobrado anteriormente por substituição tributária";

                cbCfop.Text = "5405";
            }
            else
            {
                cbCstIcms.Text = "";
                cbCfop.Text = "5102";
            }
        }

        private void lblICMS_Click(object sender, EventArgs e)
        {

        }

        private void cbCstIcms_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtPreco_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnCalcularLucro_Click(sender, e);
            }
        }

        private void cbDepartamento_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                txtNumDep.Text = Convert.ToInt32(cbDepartamento.SelectedValue).ToString().PadLeft(3, '0');
            }
            catch
            {
                txtNumDep.Text = "000";
            }
        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPage == tpListar)
            {
                PesquisarProdutos();
            }
        }

        private void txtPesquisaProdutoDesc_TextChanged(object sender, EventArgs e)
        {
            PesquisarProdutos();
        }

        private void txtPesquisaProdutoCodigo_TextChanged(object sender, EventArgs e)
        {
            PesquisarCodigoBarrasDescricao();
        }

        public void PesquisarCodigoBarrasDescricao()
        {
            try
            {
                produtoRegraNegocios = new ProdutoRegraNegocios();
                DataTable dadosTabela = new DataTable();

               // dadosTabela = produtoRegraNegocios.PesquisarCodigoBarras();

                if (dadosTabela.Rows.Count > 0)
                {
                    gdvProduto.DataSource = null;
                    gdvProduto.DataSource = dadosTabela;
                }
                else
                {
                    gdvProduto.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void gdvProduto_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (gdvProduto.Columns[e.ColumnIndex].Name.Trim().Equals("colSel"))
                {
                    idProduto = Convert.ToInt32(gdvProduto.Rows[e.RowIndex].Cells["colIdProduto"].Value);

                    frmAlterarProduto frmAlterarProduto = new frmAlterarProduto(frmPrincipal, idProduto);
                    frmAlterarProduto.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
