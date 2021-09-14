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

namespace CONTROLE.OTICA
{
    public partial class frmCadProduto : Form
    {
        public frmCadProduto()
        {
            InitializeComponent();

            this.dgvProduto.AutoGenerateColumns = false;
            this.dgvProduto.RowTemplate.Height = 50;
        }

        ProdutoC produto;
        FILTRAR filtrar;

        ProdutoRegraNegocios produtoRegraNegocios;
        UnidadeRegraNegocios unidadeRegraNegocios;
        DepartamentoRegraNegocios departamentoRegraNegocios;
        SetorRegraNegocios setorRegraNegocios;

        private void lblValorCofins_Click(object sender, EventArgs e)
        {

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


        private void cbValorCofins_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblIPI_Click(object sender, EventArgs e)
        {

        }

        private void txtCstIpi_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void frmCadProduto_Load(object sender, EventArgs e)
        {
            Listar();
        }

        public void Listar()
        {
            ListarDepartementos();
            ListarSetor();
            ListarUnidade();
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
                else if (cbIcms.Text.Trim().Equals(""))
                {
                    MessageBox.Show("Campo de ICMS não Pode ser Nulo ou Vazio..", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbIcms.Focus();
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
                else
                {
                    produto = new ProdutoC();

                    filtrar = new FILTRAR();

                    produtoRegraNegocios = new ProdutoRegraNegocios();

                    produto.idProduto = Convert.ToInt32(lblId.Text);
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
                    produto.descAuto = false;
                    produto.qtdeDesc = Convert.ToDecimal(txtQtde.Text);
                    produto.atualiza = "";
                    produto.embal = Convert.ToDecimal("0,00");
                    produto.custoCaixa = Convert.ToDecimal("0,00");
                    produto.lixo = Convert.ToDecimal("0,00");
                    produto.dtAjuste = DateTime.Now;
                    produto.setor = Convert.ToDecimal(cbSetor.SelectedValue);
                    produto.validade = "000";
                    produto.vencimento = "";
                    produto.margem = Convert.ToDecimal("0,00");
                    produto.qtdeCom = Convert.ToDecimal("0,00");
                    produto.dtCom = "";
                    produto.percPis = Convert.ToDecimal(txtPercIpi.Text);
                    produto.cstPis = cbCstPis.Text.Substring(0, 2).Trim();
                    produto.valorPis = cbCstPis.Text.Substring(0, 1).Trim();
                    produto.valorCofins = cbCofins.Text.Substring(0, 2).Trim();
                    produto.cstCofins = cbCofins.Text.Substring(0, 2).Trim();
                    produto.percCofins = Convert.ToDecimal(txtPerCofins.Text);
                    produto.cfop = cbCfop.Text.Trim();
                    produto.origemProduto = cbOrigem.Text.Substring(0, 1).Trim();
                    produto.icms = cbIcms.Text.Substring(0, 2).Trim();
                    produto.ncm = cbNcm.Text.Trim();
                    produto.cstIcms = cbIcms.Text.Substring(0, 2).Trim();
                    produto.cest = txtCest.Text.Trim();
                    produto.gTin = filtrar.RemoverCaracteres(txtCodBarra.Text.Trim());
                    produto.percIpi = Convert.ToDecimal(txtPercIpi.Text);

                    produto.DepartamentoDesc = cbDepartamento.Text.Trim();
                    produto.qtdeAutomatica = Convert.ToDecimal(0);
                    produto.precoPromocao = Convert.ToDecimal(0);
                    //produto.naturezaOperacao = cbn.Text.Substring(0, 1).Trim();
                    produto.cstIpi = cbCstPis.Text.Substring(0, 2).Trim();
                    produto.modRedBC = cbModRedBC.Text.Substring(0, 1).Trim();
                    produto.percIpi = Convert.ToDecimal(txtPercIpi.Text.Trim());
                    produto.percRedBc = Convert.ToDecimal(txtPercRedBC.Text.Trim());

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

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            CadastrarProduto(e);
        }
    }
}
